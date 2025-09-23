using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Email contact class
    /// Inherits from Contact
    /// </summary>
    public partial class EmailContact : Contact
    {
        /// <summary>
        /// Address
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [EmailAddress]
        public string Address { get; set; }
    }
}
