﻿using System;
using log4net.Core;
using Vostok.Logging.Abstractions;
using ILog = Vostok.Logging.Abstractions.ILog;

namespace Vostok.Logging.Log4net
{
    public class Log4netLog : ILog
    {
        private readonly ILogger logger;

        public Log4netLog(log4net.ILog log)
            : this(log.Logger)
        {
        }

        private Log4netLog(ILogger logger)
        {
            this.logger = logger;
        }

        public void Log(LogEvent @event)
        {
            if (!IsEnabledFor(@event.Level))
                return;
            logger.Log(Log4netHelpers.TranslateEvent(logger, @event));
        }

        public bool IsEnabledFor(LogLevel level)
        {
            return logger.IsEnabledFor(Log4netHelpers.TranslateLevel(level));
        }

        public ILog ForContext(string context)
        {
            if (string.IsNullOrEmpty(context))
                throw new ArgumentException("Empty context is not allowed", nameof(context));
            return context == logger.Name ? this : new Log4netLog(logger.Repository.GetLogger(context));
        }
    }
}