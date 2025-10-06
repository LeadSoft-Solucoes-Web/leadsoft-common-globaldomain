using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocument
    {
        public Document ToDocument() => this;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDocument"></param>
        /// <returns></returns>
        public static DTODocument ToDTO(Document aDocument) => aDocument;
    }
}
