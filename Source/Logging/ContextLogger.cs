using Microsoft.Extensions.Logging;
using System;

namespace Logging
{
    public class ContextLogger
    {
        private readonly ILogger _logger;
        private readonly string _context;
        private const string CONTEXT_MESSAGE = "{0} - {1}";

        public ContextLogger(ILogger logger, string context)
        {
            _logger = logger;
            _context = context;
        }

        public void LogTrace(string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(AddContextToMessage(message), args);
            }
        }

        public void LogInformation(string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Information))
            {
                _logger.LogInformation(AddContextToMessage(message), args);
            }
        }

        public void LogWarning(string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(AddContextToMessage(message), args);
            }
        }
        public void LogWarning(Exception ex, string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(ex, AddContextToMessage(message), args);
            }
        }

        public void LogError(string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Error))
            {
                _logger.LogError(AddContextToMessage(message), args);
            }
        }

        public void LogError(Exception ex, string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Error))
            {
                _logger.LogError(ex, AddContextToMessage(message), args);
            }
        }

        public void LogCritical(string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(AddContextToMessage(message), args);
            }
        }

        public void LogCritical(Exception ex, string message, params object?[] args)
        {
            if (IsContextEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(ex, AddContextToMessage(message), args);
            }
        }

        private bool IsContextEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel, _context);
        }

        private string AddContextToMessage(string message)
        {
            return string.Format(CONTEXT_MESSAGE, _context, message);
        }
    }
}
