using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public static class Extension
    {
        public static IServiceCollection AddCustomLogging(this IServiceCollection services)
        {
            var lf = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            services.AddSingleton<ILoggerFactory>(lf);

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            return services;
        }
    }
}