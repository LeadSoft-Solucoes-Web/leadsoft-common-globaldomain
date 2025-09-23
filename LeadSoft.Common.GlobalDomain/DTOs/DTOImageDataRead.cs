
using Newtonsoft.Json;

using System.ComponentModel;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Image Data properties DTO
    /// </summary>
    [Serializable]
    [DataContract]

    public partial class DTOImageDataRead
    {
        /// <summary>
        /// Image unique Id.
        /// </summary>
        [DataMember]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Title for image.
        /// </summary>
        /// <example>Cover picture</example>
        [DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// Description for image.
        /// </summary>
        /// <example>Announcement cover.</example>
        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// Main image size in bytes
        /// </summary>
        /// <example>40960</example>
        [DataMember]
        public virtual int Bytes { get; set; }

        /// <summary>
        /// Image key
        /// </summary>
        /// <example>Cover_w143kxnu.jpg</example>
        [DataMember]
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Key { get; set; }

        /// <summary>
        /// Image thumbnail Key
        /// </summary>
        /// <example>Cover_w143kxnu_thumbnail.jpg</example>
        [DataMember]
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ThumbnailKey { get; set; }

        /// <summary>
        /// Image Url
        /// </summary>
        /// <example>Cover_w143kxnu.jpg</example>
        [DataMember]
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Url { get; set; }

        /// <summary>
        /// Image thumbnail Url
        /// </summary>
        /// <example>Cover_w143kxnu.jpg</example>
        [DataMember]
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ThumbnailUrl { get; set; }

    }
}