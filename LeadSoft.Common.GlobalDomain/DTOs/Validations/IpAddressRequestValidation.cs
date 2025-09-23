using LeadSoft.Common.Library.Extensions;
using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.DTOs.Validations
{
    /// <summary>
    /// DTO Ip Address request validation attribute
    /// </summary>
    public class IpAddressRequestValidation : ValidationAttribute
    {
        /// <summary>
        /// Checks if request is valid
        /// </summary>
        /// <param name="value">Object</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation Result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DTOIpAddressRequest dtoRequest = (DTOIpAddressRequest)validationContext.ObjectInstance;

            if (!dtoRequest.IpAddress.IsValidIpAddress())
                return new ValidationResult("IP Address must be valid.", new[] { nameof(DTOIpAddressRequest.IpAddress) });

            return ValidationResult.Success;
        }
    }
}
