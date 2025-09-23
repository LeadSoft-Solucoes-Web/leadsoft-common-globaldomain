using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Base entity to provide basic information for database domain entity classes
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Database unique Id as Guid.
        /// </summary>
        [Key]
        [Required]
        public virtual Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Created At date and time information
        /// </summary>
        /// <remarks>
        /// Set automatically with current datetime on object first instance
        /// </remarks>
        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Updated at date and time information
        /// </summary>
        /// <remarks>
        /// On every update on any field saved on database, this property must be updated to now.
        /// </remarks>
        [DataType(DataType.DateTime)]
        public virtual DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Tells if entity is enabled or disabled
        /// </summary>
        public virtual bool IsEnabled { get; private set; }
    }
}
