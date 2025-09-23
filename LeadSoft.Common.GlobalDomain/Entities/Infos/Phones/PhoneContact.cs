using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Phone contact class
    /// Inherits from Contact
    /// </summary>
    public partial class PhoneContact : Contact
    {
        /// <summary>
        /// Discagem Direta Internacional
        /// </summary>
        public string DDI { get; private set; } = "55";

        /// <summary>
        /// Discagem Direta à Distância
        /// </summary>
        [Required(ErrorMessage = "DDD is required")]
        public string DDD { get; private set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; private set; }
    }
}
