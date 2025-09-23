using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.CloudFiles
{
    /// <summary>
    /// Image abstraction of Cloud File
    /// </summary>
    /// <remarks>
    /// Use this class to store images on S3 with thumbnail.
    /// You can also resize images or create thumbnails from it.
    /// This class doesn't use System.Drawing, so it's Linux safe.
    /// </remarks>
    public partial class CloudImage : CloudFile
    {
        /// <summary>
        /// Title for image
        /// Use file name if title is not applicable
        /// </summary>
        public virtual string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description for image
        /// Subtitle? Maybe it's a good place to store it
        /// </summary>
        public virtual string Description { get; set; } = string.Empty;

        /// <summary>
        /// Image thumbnail Uri
        /// </summary>
        [DataType(DataType.ImageUrl)]
        public virtual Uri? ThumbnailUrl { get; set; } = null;

        /// <summary>
        /// Image thumbnail key, if it was used some kind of container service
        /// </summary>
        public virtual string? ThumbnailKey { get; set; } = string.Empty;
    }
}

