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
    }
}
