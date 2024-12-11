using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Factories
{
    /// <summary>
    /// A design-time factory for creating instances of <see cref="ECommerceAPIDBContext"/>.
    /// This is used by EF Core tools for migrations.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDBContext>
    {
        public ECommerceAPIDBContext CreateDbContext(string[] args)
        {
            // Determine the base path dynamically:
            // Assembly location ensures we know exactly where we are loading configuration from.
            var executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Build a configuration object at design-time:
            // We expect appsettings.json to be in the same directory as the assembly or a known location.
            var config = new ConfigurationBuilder()
                .SetBasePath(executionPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false) // Make sure this file is copied to output directory if needed.
                .AddEnvironmentVariables() // In case you override connection string via environment variables.
                .Build();

            var connectionString = config.GetConnectionString("PostgreSql");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'PostgreSql' was not found.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ECommerceAPIDBContext>()
                .UseNpgsql(connectionString);

            return new ECommerceAPIDBContext(optionsBuilder.Options);
        }
    }
}