using LeadSoft.Common.Library.Extensions;
using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.DTOs.Validations
{
    /// <summary>
    /// DTO Term validation attribute
    /// </summary>
    public class TermAcceptanceValidation : ValidationAttribute
    {
        /// <summary>
        /// Checks if request is valid
        /// </summary>
        /// <param name="value">Object</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation Result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DTOTermAcceptance dtoRequest = (DTOTermAcceptance)validationContext.ObjectInstance;

            if (!dtoRequest.AcceptedTerm)
                return new ValidationResult("Term must be accepted to proceed.", new[] { nameof(DTOTermAcceptance.AcceptedTerm) });

            return ValidationResult.Success;
        }
    }
}
