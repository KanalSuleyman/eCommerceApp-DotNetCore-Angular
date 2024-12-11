using System.Reflection;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Contexts
{
    /// <summary>
    /// Represents the primary database context for the e-commerce application.
    /// It is configured to use Fluent API configurations defined in separate configuration classes.
    /// </summary>
    public class ECommerceAPIDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ECommerceAPIDBContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public ECommerceAPIDBContext(DbContextOptions<ECommerceAPIDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets the Customers DbSet.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets the Orders DbSet.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets the Products DbSet.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets the Addresses DbSet (includes both BillingAddress and ShippingAddress).
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        // Explicit DbSets for derived entities
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        /// <summary>
        /// Configures the entity model using configurations defined in the same assembly.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations located in the same assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}