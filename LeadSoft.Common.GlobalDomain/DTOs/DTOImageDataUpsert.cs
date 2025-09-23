
using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Image Data Upsert properties DTO
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOImageDataUpsert
    {
        /// <summary>
        /// Image unique Id.
        /// </summary>
        [DataMember]
        public virtual Guid? Id { get; set; }

        /// <summary>
        /// Title for image to identify it. To display on title session from an Album, for example. Also used by HTML title.
        /// </summary>
        /// <example>Cover picture</example>
        [DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// Description for image. Describe it as a text or something else. Also used by HTML Alt option.
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
        /// Image key, provided by Image container service
        /// </summary>
        /// <example>Cover_w143kxnu.jpg</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual string Key { get; set; }

        /// <summary>
        /// Image thumbnail key, if it was used some kind of container service
        /// </summary>
        /// <example>Cover_w143kxnu_thumbnail.jpg</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual string ThumbnailKey { get; set; }

        /// <summary>
        /// Desired operation (Create, Update or Delete)
        /// </summary>
        /// <example>Create</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual CRUDOperation Operation { get; set; }
    }
}