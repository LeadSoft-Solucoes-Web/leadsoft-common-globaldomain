using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Collection base abstract class means that this class contains basic properties for all entity that will be saved as Collection on database.
    /// </summary>
    public abstract partial class CollectionsBase
    {
        /// <summary>
        /// Id string field to be recorded on Database
        /// </summary>
        [Key]
        [JsonProperty]
        public virtual string Id { get; protected set; } = string.Empty;

        /// <summary>
        /// Tells if entity is enabled or disabled
        /// </summary>
        public virtual bool IsEnabled { get; private set; }

        /// <summary>
        /// Created At
        /// </summary>
        public virtual DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Updated at
        /// </summary>
        public virtual DateTime? UpdatedAt { get; private set; }
    }
}
