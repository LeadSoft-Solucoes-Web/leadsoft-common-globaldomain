using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocumentInsert
    {
        public static implicit operator Document(DTODocumentInsert aDto)
        {
            if (aDto.IsNull())
                return null;

            Document document = new(aDto.Type, aDto.Number)
            {
                Issue = aDto.Issue
            };

            if (aDto.Expiration.HasValue)
                document.SetExpiration(aDto.Expiration.Value);

            return document;
        }
    }
}
