using LeadSoft.Common.Library.Exceptions;

using NUlid;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Collection base methods
    /// </summary>
    public abstract partial class CollectionsBase
    {
        private const string _IUnderstandTheRisks = "I understand the risks.";

        /// <summary>
        /// Generates a new guid for any class.
        /// </summary>
        /// <remarks>
        /// If class has no Id, it will be created.
        /// 
        /// If class already have an Id, the flag that allows or not the replacement must be placed.
        /// If true, it will replace with a new one.
        /// 
        /// Both cases will return the most recent Guid. If not modified, current one.
        /// </remarks>
        /// <param name="aReplace">Use this flag if you want to replace existant value. Default false.</param>
        /// <returns>Guid value</returns>
        public virtual Guid NewId(bool aReplace = false)
        {
            if (!Guid.HasValue || aReplace)
                Guid = Ulid.NewUlid().ToGuid();

            CreatedAt = DateTime.UtcNow;

            if (UpdatedAt.HasValue)
                Update();

            return Guid.Value;
        }

        /// <summary>
        /// Create a new enabled entity with new Id
        /// </summary>
        /// <returns>This for chain calls.</returns>
        public virtual CollectionsBase Create()
        {
            Guid = Ulid.NewUlid().ToGuid();
            CreatedAt = DateTime.UtcNow;
            Enable();

            return this;
        }

        /// <summary>
        /// Clears current Id to empty
        /// </summary>
        /// <returns>This for chain calls.</returns>
        public virtual CollectionsBase ClearId()
        {
            Guid = Ulid.Empty.ToGuid();
            return this;
        }

        /// <summary>
        /// Enable collection base.
        /// Sets IsEnabled field as true
        /// Virtual method.
        /// </summary>
        public virtual CollectionsBase Enable()
        {
            IsEnabled = true;

            if (UpdatedAt.HasValue)
                Update();

            return this;
        }

        /// <summary>
        /// Disable collection base.
        /// Sets IsEnabled field as false
        /// Virtual method.
        /// </summary>
        public virtual CollectionsBase Disable()
        {
            IsEnabled = false;

            if (UpdatedAt.HasValue)
                Update();

            return this;
        }

        /// <summary>
        /// Date when entity was updated
        /// </summary>
        public virtual CollectionsBase Update()
        {
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        /// <summary>
        /// Sets the expiration time for the entity in seconds.
        /// </summary>
        /// <param name="aSeconds">Seconds to expire</param>
        /// <returns>Self for chain calls</returns>
        public CollectionsBase SetExpiration(long aSeconds)
        {
            ExpirationSeconds = Math.Abs(aSeconds);
            return this;
        }

        /// <summary>
        /// Sets the expiration time for the entity to a specific DateTime.
        /// </summary>
        /// <param name="aAt">Should expire at</param>
        /// <returns>Self for chain calls</returns>
        public CollectionsBase SetExpirationTo(DateTime aAt)
        {
            ExpirationSeconds = aAt > DateTime.UtcNow
                                    ? (long)(aAt.ToUniversalTime() - DateTime.UtcNow).TotalSeconds
                                    : 0;

            return this;
        }

        /// <summary>
        /// Determines if the entity has an expiration time set.
        /// </summary>
        /// <returns>Self for chain calls</returns>
        public bool Expires()
            => ExpirationSeconds.HasValue && ExpirationSeconds.Value > 0;

        /// <summary>
        /// Cancels the expiration time for the entity.
        /// </summary>
        /// <returns>Self for chain calls</returns>
        public CollectionsBase CancelExpiration()
        {
            ExpirationSeconds = -1;
            return this;
        }

        /// <summary>
        /// Determines if the entity has an expiration cancellation set.
        /// </summary>
        /// <returns>Self for chain calls</returns>
        public bool HasExpirationCancellation()
            => ExpirationSeconds.HasValue && ExpirationSeconds.Value < 0;

        /// <summary>
        /// <see langword="this"/> method overrides the CreatedAt <see langword="property"/> in current Entity.
        /// </summary>
        /// <remarks>
        /// This <see langword="is"/> not a good practice, but if you need to change it to a new UTC Now Date Time, inform exact text "I understand the risks."
        /// on <see langword="string"/> <see langword="param"/> and comment it into your code to explain yourself to your team why did that. :)
        /// Updated At will be set to <see langword="null"/>.
        /// Be kind, rock on!
        /// </remarks>
        /// <returns>Collection base</returns>
        public virtual CollectionsBase OverrideCreateDateTime(string aAggreeToOverride)
        {
            if (!aAggreeToOverride.Equals(_IUnderstandTheRisks, StringComparison.Ordinal))
                throw new BadRequestAppException("You did not read the method documentation. So creation date won't be updated. :)");

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;

            return this;
        }
    }
}
