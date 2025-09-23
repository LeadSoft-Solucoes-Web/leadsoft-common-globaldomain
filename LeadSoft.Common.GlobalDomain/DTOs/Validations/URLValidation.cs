using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Validations
{
    public class URLValidation : ValidationAttribute
    {
        /// <summary>
        /// Validate if URL value has a valid URL
        /// </summary>
        /// <param name="value">Value of URL to Validate</param>
        public override bool IsValid(object value)
        {
            string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(value.ToString());
        }
    }
}
