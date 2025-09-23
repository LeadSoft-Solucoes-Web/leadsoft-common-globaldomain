using LeadSoft.Common.GlobalDomain.Entities.CloudFiles;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOImageDataRead
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public DTOImageDataRead()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImageData"></param>
        /// <returns></returns>
        public static DTOImageDataRead ToDTO(ImageData aImageData) => (DTOImageDataRead)aImageData;
    }
}