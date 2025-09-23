using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// E-mails list
    /// </summary>

    public partial class Emails
    {
        /// <summary>
        /// Primary E-mail Address
        /// </summary>
        [Required(ErrorMessage = "E-mail Address is required.")]
        public string Primary { get; set; }

        /// <summary>
        /// List of EmailContact type
        /// </summary>
        protected List<EmailContact> This { get; set; } = [];
    }
}
