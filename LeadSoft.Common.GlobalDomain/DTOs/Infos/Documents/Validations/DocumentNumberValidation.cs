using LeadSoft.Common.Library;
using System.ComponentModel.DataAnnotations;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Documents.Validations
{
    public class DocumentNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DTODocument dtoDocument = (DTODocument)value;

            try
            {
                dtoDocument.ToDocument();
            }
            catch
            {
                return new ValidationResult(string.Format(ApplicationStatusMessage.InvalidDocumentNumber, dtoDocument.Type.GetDescription()), new[] { nameof(DTODocument.Number) });
            }

            return ValidationResult.Success;
        }
    }
}
