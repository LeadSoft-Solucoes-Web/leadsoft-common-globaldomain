using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// NCM Class methods
    /// </summary>
    public partial class NCM
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NCM()
        {
        }

        /// <summary>
        /// Data Constructor
        /// </summary>
        /// <param name="aCode"></param>
        /// <param name="aEx"></param>
        /// <param name="aDescription"></param>
        public NCM(string aCode, string aEx, string aDescription)
        {
            Guid = System.Guid.NewGuid();
            Code = aCode.OnlyAlphanumeric();
            Ex = aEx;
            Description = aDescription;
        }
    }
}
