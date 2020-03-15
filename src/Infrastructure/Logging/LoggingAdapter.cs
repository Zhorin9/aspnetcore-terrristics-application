using AppCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Logging
{
    public class LoggingAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggingAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }


        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}