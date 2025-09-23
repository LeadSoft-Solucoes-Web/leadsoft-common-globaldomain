using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CEST Class methods
    /// </summary>
    public partial class CEST
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CEST()
        {
        }

        /// <summary>
        /// Data Constructor
        /// </summary>
        /// <param name="aCode"></param>
        /// <param name="aDescription"></param>
        public CEST(string aCode, string aDescription)
        {
            Guid = System.Guid.NewGuid();
            Code = aCode.OnlyAlphanumeric();
            Description = aDescription;
        }
    }
}
