using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    /// <summary>
    /// Represents a product available for purchase.
    /// </summary>
    public class Product : BaseEntity
    {
        private readonly List<Order> _orders = new();

        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the product price.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the available stock quantity for the product.
        /// </summary>
        public int StockQuantity { get; private set; }

        /// <summary>
        /// Gets the orders that include this product.
        /// This property supports a Many-to-Many relationship.
        /// </summary>
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        // Private constructor for EF Core.
        private Product() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified details.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <param name="price">The product price.</param>
        /// <param name="stockQuantity">The initial stock quantity.</param>
        public Product(string name, decimal price, int stockQuantity)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Decreases the product stock quantity by the specified amount.
        /// </summary>
        /// <param name="quantity">The quantity to decrement.</param>
        public void DecreaseStock(int quantity)
        {
            StockQuantity -= quantity;
            UpdateLastModified();
        }

        /// <summary>
        /// Increases the product stock quantity by the specified amount.
        /// </summary>
        /// <param name="quantity">The quantity to increment.</param>
        public void IncreaseStock(int quantity)
        {
            StockQuantity += quantity;
            UpdateLastModified();
        }
    }
}
