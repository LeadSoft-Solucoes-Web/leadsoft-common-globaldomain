using LeadSoft.Common.GlobalDomain.Entities.CloudFiles;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Image Data Upsert Operators
    /// </summary>
    public partial class DTOImageDataUpsert
    {
        /// <summary>
        /// Image Data class to DTO Image Data
        /// </summary>
        /// <param name="aDto">DTOImageDataUpsert</param>
        public static explicit operator ImageData(DTOImageDataUpsert aDto)
        {
            if (aDto.IsNull())
                return null;

            return new()
            {
                Title = aDto.Title,
                Description = aDto.Description,
                Bytes = aDto.Bytes,
                Key = aDto.Key,
                ThumbnailKey = aDto.ThumbnailKey
            };
        }
    }
}
