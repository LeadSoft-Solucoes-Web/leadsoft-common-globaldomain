using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Contact abstract class
    /// </summary>
    public abstract partial class Contact
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Constructor requires a Contact type
        /// </summary>
        /// <param name="aContactType">Contact type enum</param>
        public Contact(ContactType aContactType)
        {
            Type = aContactType;
        }
    }
}
