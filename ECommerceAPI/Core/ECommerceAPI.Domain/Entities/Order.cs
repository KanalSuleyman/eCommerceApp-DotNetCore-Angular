using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    /// <summary>
    /// Represents a customer order consisting of one or more products.
    /// </summary>
    public class Order : BaseEntity
    {
        private readonly List<Product> _products = new();

        /// <summary>
        /// Gets the total amount for this order.
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Gets the foreign key of the customer who placed this order.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the customer who placed this order.
        /// </summary>
        public Customer Customer { get; private set; }

        /// <summary>
        /// Gets the products included in this order.
        /// Represents a Many-to-Many relationship with <see cref="Product"/>.
        /// </summary>
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        // Private constructor for EF Core.
        private Order() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class associated with a specific customer.
        /// </summary>
        /// <param name="customerId">The identifier of the customer placing the order.</param>
        /// <param name="totalAmount">The total amount of the order.</param>
        public Order(Guid customerId, decimal totalAmount)
        {
            CustomerId = customerId;
            TotalAmount = totalAmount;
        }

        /// <summary>
        /// Adds a product to this order.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddProduct(Product product)
        {
            _products.Add(product);
            UpdateLastModified();
        }

        /// <summary>
        /// Removes a product from this order.
        /// </summary>
        /// <param name="product">The product to remove.</param>
        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
            UpdateLastModified();
        }

        /// <summary>
        /// Updates the total amount of this order.
        /// </summary>
        /// <param name="newAmount">The new total amount.</param>
        public void UpdateTotalAmount(decimal newAmount)
        {
            TotalAmount = newAmount;
            UpdateLastModified();
        }
    }
}
