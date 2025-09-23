using LeadSoft.Common.Library.Extensions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Collection base abstract class means that this class contains basic properties for all entity that will be saved as Collection on database.
    /// </summary>
    public abstract partial class CollectionsBase
    {
        /// <summary>
        /// Guid to be used and validated inside .net
        /// Should not be recorded in database
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public virtual Guid? Guid
        {
            get => Id.ToNullableGuid();
            set
            {
                Id = value.GetString();
            }
        }

        /// <summary>
        /// Expiration seconds for this entity, if null, means that this entity will not expire.
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public virtual long? ExpirationSeconds { get; private set; }

        /// <summary>
        /// Calculated property that returns the expiration date based on CreatedAt and ExpirationSeconds.
        /// </summary>
        [JsonIgnore]
        public virtual DateTime? ExpiresAt
        {
            get
            {
                if (ExpirationSeconds.HasValue)
                    return CreatedAt.AddSeconds(ExpirationSeconds.Value);

                return null;
            }
        }

        /// <summary>
        /// List of TimeSeries associated with this entity document.
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public IList<TimeSerie> TimeSeries { get; private set; } = [];

        /// <summary>
        /// List of Counters associated with this entity document.
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public ISet<string> CountersNames { get; private set; } = new HashSet<string>();
    }
}
