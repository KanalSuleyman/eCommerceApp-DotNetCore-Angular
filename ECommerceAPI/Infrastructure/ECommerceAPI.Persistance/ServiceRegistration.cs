using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence
{
    /// <summary>
    /// Provides extension methods for registering persistence-related services, including the EF Core DbContext.
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Registers persistence-layer services, including the ApplicationDbContext with Entity Framework Core,
        /// using the provided connection string from the application configuration.
        /// </summary>
        /// <param name="services">The service collection to which the services will be added.</param>
        /// <param name="builderConfiguration"></param>
        /// <param name="configuration">The application configuration containing the connection string.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            ConfigurationManager builderConfiguration)
        {

            // Register the ApplicationDbContext with EF Core
            // As PostgreSQL is used, ensure you have Microsoft.EntityFrameworkCore.PostgreSQL installed.
            services.AddDbContext<ECommerceAPIDBContext>(options =>
            {
                // Retrieve the connection strings from configuration

                options.UseNpgsql(Configuration.ConnectionString);
            });

            // Additional persistence-related services, repositories, or unit-of-work classes can be registered here.

            return services;
        }
    }
}