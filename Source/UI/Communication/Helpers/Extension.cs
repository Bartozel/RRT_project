using Microsoft.Extensions.DependencyInjection;

namespace Communication
{
    public static class Extension
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Extension).Assembly));

            return services;
        }

        public static IServiceCollection AddMediatorHandlers<T>(this IServiceCollection services) where T : class
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(T).Assembly));
            return services;
        }
    }
}
