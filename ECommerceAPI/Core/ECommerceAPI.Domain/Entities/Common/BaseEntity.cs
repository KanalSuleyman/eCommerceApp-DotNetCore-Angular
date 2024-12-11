namespace ECommerceAPI.Domain.Entities.Common
{
    /// <summary>
    /// Represents a base entity type, providing common auditing properties and a GUID primary key.
    /// All domain entities should derive from this class.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier for this entity.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets the UTC timestamp when the entity was created.
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the UTC timestamp when the entity was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this entity is marked as deleted (soft delete).
        /// </summary>
        public bool IsDeleted { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            IsDeleted = false;
        }

        /// <summary>
        /// Marks this entity as deleted and updates its modification timestamp.
        /// </summary>
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            UpdateLastModified();
        }

        /// <summary>
        /// Updates the <see cref="LastModifiedDate"/> to the current UTC time.
        /// </summary>
        protected void UpdateLastModified()
        {
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}