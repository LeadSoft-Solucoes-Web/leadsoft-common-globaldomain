using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocumentInsert
    {
        public static explicit operator Document(DTODocumentInsert aDto)
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
