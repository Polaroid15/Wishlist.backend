using Microsoft.Extensions.Logging;
using Wishlist.Core.Interfaces;

namespace Wishlist.Infrastructure; 

public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
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

    public void LogCritical(string message, params object[] args) {
        _logger.LogCritical(message, args);
    }
}