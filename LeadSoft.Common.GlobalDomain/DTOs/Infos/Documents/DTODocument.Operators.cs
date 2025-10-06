using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocument
    {
        public static implicit operator DTODocument(Document aDocument)
        {
            if (aDocument.IsNull())
                return new DTODocument();

            return new DTODocument()
            {
                Type = aDocument.Type,
                Number = aDocument.Number,
                Expiration = aDocument.Expiration,
                Issue = aDocument.Issue
            };
        }

        public static implicit operator Document(DTODocument aDto)
        {
            if (aDto.IsNull())
                return null;

            Document document = new Document(aDto.Type, aDto.Number)
            {
                Issue = aDto.Issue
            };

            if (aDto.Expiration.HasValue)
                document.SetExpiration(aDto.Expiration.Value);

            return document;
        }
    }
}
