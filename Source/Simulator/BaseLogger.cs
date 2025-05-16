using Logging;

namespace PathFindingSimulator
{
    public class BaseLogger
    {
        private ContextLogger _logger;

        public BaseLogger(ILogger logger)
        {
            _logger = new ContextLogger(logger, this.GetType().Name);
        }
    }
}