using Microsoft.Extensions.Logging;

namespace Logging
{
    public interface ILogger : Microsoft.Extensions.Logging.ILogger
    {
        bool IsEnabled(LogLevel logLevel, string context);
    }
}
