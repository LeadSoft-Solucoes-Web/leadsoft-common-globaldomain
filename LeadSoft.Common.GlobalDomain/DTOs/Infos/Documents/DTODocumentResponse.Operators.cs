using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocumentResponse
    {
        public DTODocumentResponse()
        {

        }

        public static explicit operator DTODocumentResponse(Document aDocument)
        {
            if (aDocument.IsNull())
                return new DTODocumentResponse();

            return new DTODocumentResponse()
            {
                Type = aDocument.Type,
                Number = aDocument.Number,
                Expiration = aDocument.Expiration,
                Issue = aDocument.Issue
            };
        }
    }
}
