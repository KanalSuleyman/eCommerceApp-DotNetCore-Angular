using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    /// <summary>
    /// Represents a physical address for billing or shipping.
    /// This is an abstract base class for different address types.
    /// </summary>
    public abstract class Address : BaseEntity
    {
        /// <summary>
        /// Gets the building number component of the address.
        /// </summary>
        public string BuildingNo { get; private set; }

        /// <summary>
        /// Gets the building name component of the address.
        /// </summary>
        public string BuildingName { get; private set; }

        /// <summary>
        /// Gets the primary street line component of the address.
        /// </summary>
        public string StreetLine1 { get; private set; }

        /// <summary>
        /// Gets the optional secondary street line component of the address.
        /// </summary>
        public string StreetLine2 { get; private set; }

        /// <summary>
        /// Gets the neighbourhood or district of the address.
        /// </summary>
        public string Neighbourhood { get; private set; }

        /// <summary>
        /// Gets the city or locality of the address.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the postal or ZIP code of the address.
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// Gets the foreign key identifier of the associated customer.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the customer associated with this address.
        /// </summary>
        public Customer Customer { get; private set; }

        // Private parameterless constructor for EF Core.
        protected Address() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        protected Address(
            string buildingNo,
            string buildingName,
            string streetLine1,
            string streetLine2,
            string neighbourhood,
            string city,
            string zipCode)
        {
            BuildingNo = buildingNo;
            BuildingName = buildingName;
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            Neighbourhood = neighbourhood;
            City = city;
            ZipCode = zipCode;
        }
    }

    /// <summary>
    /// Represents an address used for billing purposes.
    /// </summary>
    public class BillingAddress : Address
    {
        // EF Core requires a parameterless constructor.
        private BillingAddress() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAddress"/> class.
        /// </summary>
        public BillingAddress(
            string buildingNo,
            string buildingName,
            string streetLine1,
            string streetLine2,
            string neighbourhood,
            string city,
            string zipCode)
            : base(buildingNo, buildingName, streetLine1, streetLine2, neighbourhood, city, zipCode)
        {
        }
    }

    /// <summary>
    /// Represents an address used for shipping purposes.
    /// </summary>
    public class ShippingAddress : Address
    {
        // EF Core requires a parameterless constructor.
        private ShippingAddress() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingAddress"/> class.
        /// </summary>
        public ShippingAddress(
            string buildingNo,
            string buildingName,
            string streetLine1,
            string streetLine2,
            string neighbourhood,
            string city,
            string zipCode)
            : base(buildingNo, buildingName, streetLine1, streetLine2, neighbourhood, city, zipCode)
        {
        }
    }
}
