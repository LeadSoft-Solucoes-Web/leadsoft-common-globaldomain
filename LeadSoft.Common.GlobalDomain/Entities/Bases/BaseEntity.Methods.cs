namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Base entity to provide basic information for database domain entity classes methods
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Enable entity.
        /// Sets IsEnabled field as true
        /// Virtual method.
        /// </summary>
        public virtual BaseEntity Enable()
        {
            IsEnabled = true;

            if (UpdatedAt.HasValue)
                Update();

            return this;
        }

        /// <summary>
        /// Disable entity.
        /// Sets IsEnabled field as false
        /// Virtual method.
        /// </summary>
        public virtual BaseEntity Disable()
        {
            IsEnabled = false;

            if (UpdatedAt.HasValue)
                Update();

            return this;
        }

        /// <summary>
        /// Date when entity was updated
        /// </summary>
        public virtual BaseEntity Update()
        {
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        /// <summary>
        /// Clears current Id to empty
        /// </summary>
        /// <returns>This for chain calls.</returns>
        public virtual BaseEntity ClearId()
        {
            Id = Guid.Empty;
            return this;
        }

        /// <summary>
        /// Creates a new Id replacing prior one.
        /// </summary>
        /// <returns>self guid</returns>
        public virtual Guid NewId()
        {
            Id = Guid.NewGuid();
            return Id;
        }

        /// <summary>
        /// Sets a new Id to image
        /// </summary>
        /// <param name="aId"></param>
        /// <returns></returns>
        public virtual BaseEntity SetId(Guid aId)
        {
            Id = aId;
            return this;
        }
    }
}
