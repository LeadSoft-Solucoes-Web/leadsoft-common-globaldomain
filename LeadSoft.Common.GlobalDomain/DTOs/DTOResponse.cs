using Newtonsoft.Json;

using System.ComponentModel;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Abstract DTO Response
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract partial class DTOResponse
    {
        /// <summary>
        /// Main object Id
        /// </summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Guid? Id { get; set; } = null;

        /// <summary>
        /// Optional external Integration Key
        /// </summary>
        [DataMember]
        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Key { get; set; } = string.Empty;

        /// <summary>
        /// Main object Created at Property
        /// </summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual DateTime? CreatedAt { get; set; } = null;

        /// <summary>
        /// Main object Updated at Property
        /// </summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual DateTime? UpdatedAt { get; set; } = null;

        /// <summary>
        /// Main object Is Enabled property
        /// </summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool? IsEnabled { get; set; } = null;

        /// <summary>
        /// Object validation flag if the model is valid, based in IsValid or IsValidCollection class abstraction
        /// </summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool? IsInvalid { get; set; } = null;

        /// <summary>
        /// Object validations based in IsValid or IsValidCollection class abstraction
        /// </summary>
        [DataMember]
        [JsonProperty("Validations", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual IList<DTOValidation>? DtoValidations { get; set; } = null;
    }
}
