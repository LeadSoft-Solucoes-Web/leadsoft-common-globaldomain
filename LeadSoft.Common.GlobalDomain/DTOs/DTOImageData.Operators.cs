using LeadSoft.Common.GlobalDomain.Entities.CloudFiles;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Image Data Operators
    /// </summary>
    public partial class DTOImageData
    {
        /// <summary>
        /// Image Data class to DTO Image Data
        /// </summary>
        /// <param name="aImageData">ImageData</param>
        public static implicit operator DTOImageData(ImageData aImageData)
        {
            if (aImageData.IsNull())
                return null;

            return new DTOImageData()
            {
                Id = aImageData.Id,
                Title = aImageData.Title,
                Description = aImageData.Description,
                Bytes = aImageData.Bytes,
                Key = aImageData.Key,
                ThumbnailKey = aImageData.ThumbnailKey
            };
        }

        /// <summary>
        /// Image Data DTO to Image Data class
        /// </summary>
        /// <param name="aDto">DTOImageData</param>
        public static implicit operator ImageData(DTOImageData aDto)
        {
            if (aDto.IsNull())
                return new();

            return new()
            {
                Id = aDto.Id,
                Title = aDto.Title,
                Description = aDto.Description,
                Bytes = aDto.Bytes,
                Key = aDto.Key,
                ThumbnailKey = aDto.ThumbnailKey
            };
        }
    }
}
