using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    /// <summary>
    /// Represents a customer using the e-commerce platform.
    /// </summary>
    public class Customer : BaseEntity
    {
        private readonly List<Address> _addresses = new();
        private readonly List<Order> _orders = new();

        /// <summary>
        /// Gets the first name of the customer.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name of the customer.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the addresses associated with this customer.
        /// </summary>
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

        /// <summary>
        /// Gets the orders placed by this customer.
        /// </summary>
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        // Private constructor required by EF Core.
        private Customer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="firstName">The customer's first name.</param>
        /// <param name="lastName">The customer's last name.</param>
        /// <param name="email">The customer's email address.</param>
        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        /// <summary>
        /// Associates a new address with this customer.
        /// </summary>
        /// <param name="address">The address to associate.</param>
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
            UpdateLastModified();
        }

        /// <summary>
        /// Associates a new order with this customer.
        /// </summary>
        /// <param name="order">The order to associate.</param>
        public void AddOrder(Order order)
        {
            _orders.Add(order);
            UpdateLastModified();
        }
    }
}
