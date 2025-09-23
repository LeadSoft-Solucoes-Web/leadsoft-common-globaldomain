using LeadSoft.Common.GlobalDomain.Entities.CloudFiles;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOImageDataReadResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImageData"></param>
        public static explicit operator DTOImageDataReadResponse(ImageData aImageData)
        {
            if (aImageData.IsNull())
                return new();

            return new()
            {
                Id = aImageData.Id,
                Title = aImageData.Title,
                Description = aImageData.Description,
                Bytes = aImageData.Bytes,
                Key = aImageData.Key,
                ThumbnailKey = aImageData.ThumbnailKey,
                Url = aImageData.Url?.AbsoluteUri,
                ThumbnailUrl = aImageData.ThumbnailUrl?.AbsoluteUri
            };
        }
    }
}