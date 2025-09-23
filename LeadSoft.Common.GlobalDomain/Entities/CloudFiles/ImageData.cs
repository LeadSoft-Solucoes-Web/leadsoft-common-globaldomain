using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.CloudFiles
{
    /// <summary>
    /// Class that stores Image properties
    /// 
    /// TODO: In a near future, this class should extends IImageData
    /// </summary>
    [Obsolete("Use Could Image instead.")]
    public partial class ImageData
    {
        /// <summary>
        /// Unique image Id
        /// </summary>
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Title for image
        /// Use file name if title is not applicable
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Description for image
        /// Subtitle? Maybe it's a good place to store it
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Image size in bytes.
        /// </summary>
        public virtual int Bytes { get; set; }

        /// <summary>
        /// Image Uri
        /// </summary>
        [Required]
        [DataType(DataType.ImageUrl)]
        public virtual Uri Url { get; set; }

        /// <summary>
        /// Image thumbnail Uri
        /// </summary>
        [Required]
        [DataType(DataType.ImageUrl)]
        public virtual Uri ThumbnailUrl { get; set; }

        /// <summary>
        /// Image key, if it was used some kind of container service
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// Image thumbnail key, if it was used some kind of container service
        /// </summary>
        public virtual string ThumbnailKey { get; set; }
    }
}
