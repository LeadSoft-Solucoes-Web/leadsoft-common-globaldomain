using System.Net.Mail;
using System.Text.RegularExpressions;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Email contact methods
    /// </summary>
    public partial class EmailContact
    {
        public EmailContact() : base()
        {
        }

        /// <summary>
        /// Base Constructor requires a Contact type
        /// </summary>
        /// <param name="aContactType">Contact type enum</param>
        public EmailContact(ContactType aContactType, string aAddress) : base(aContactType)
        {
            Address = aAddress;
        }

        /// <summary>
        /// Checks if string is an e-mail
        /// </summary>
        /// <param name="aEmail">E-mail Address</param>
        /// <returns>Boolean</returns>
        public static bool IsValidEmail(string aEmail)
        {
            Regex regex = new(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase);

            try
            {
                string email = new MailAddress(aEmail).Address;

                return email.Equals(aEmail) && regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}
