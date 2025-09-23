using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.DTOs.Validations
{
    public class GuidValidation : ValidationAttribute
    {
        /// <summary>
        /// Validate if Guid value is not null or empty
        /// </summary>
        /// <param name="value">Value to Validate</param>
        public override bool IsValid(object value)
        {
            return value != null && (Guid)value != Guid.Empty;
        }
    }
}