using LeadSoft.Common.GlobalDomain.Entities.CloudFiles;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOImageDataReadResponse
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public DTOImageDataReadResponse()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImageData"></param>
        /// <returns></returns>
        public static DTOImageDataReadResponse ToDTO(ImageData aImageData) => (DTOImageDataReadResponse)aImageData;
    }
}