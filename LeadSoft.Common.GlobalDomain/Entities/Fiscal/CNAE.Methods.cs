using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CNAE Class methods
    /// </summary>
    public partial class CNAE
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CNAE()
        {
        }

        /// <summary>
        /// Data Constructor
        /// </summary>
        /// <param name="aCode"></param>
        /// <param name="aStructure"></param>
        /// <param name="aDescription"></param>
        public CNAE(string aCode, string aStructure, string aDescription)
        {
            Guid = System.Guid.NewGuid();
            Code = aCode.OnlyAlphanumeric();
            Structure = aStructure;
            Description = aDescription;
        }
    }
}
