using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication.Filters.Startup.Interfaces;

namespace WebApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers a configuration instance of IOptions and as a validatable setting.
        /// The configuration object is directly registered withouth referencing IOptions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The <see cref="IServiceCollection "/> to add the services</param>
        /// <param name="configuration">The configuration being bound.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSettings<T>(this IServiceCollection services, IConfiguration configuration) where T : class, IValidatable, new()
        {
            // Bind the configuration of T towards IOptions
            services.Configure<T>(configuration.GetSection(typeof(T).Name));

            // Explicitly register T
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<T>>().Value);

            // Explicitly register T as an IValidatable
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<T>>().Value as IValidatable);

            return services;
        }
    }
}
