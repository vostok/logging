﻿using System;
using System.Collections.Generic;

namespace Vostok.Logging
{
    public sealed class LogEvent
    {
        public LogLevel Level { get; }

        public DateTimeOffset Timestamp { get; }

        public string MessageTemplate { get; }

        public IReadOnlyDictionary<string, object> Properties { get; }

        public Exception Exception { get; }

        public LogEvent(LogLevel level, DateTimeOffset timestamp, string messageTemplate, IReadOnlyDictionary<string, object> properties = null, Exception exception = null)
        {
            Level = level;
            Timestamp = timestamp;
            MessageTemplate = messageTemplate;
            Properties = properties;
            Exception = exception;
        }
    }
}