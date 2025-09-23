using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CFOP Class methods
    /// </summary>
    public partial class CFOP
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CFOP()
        {
        }

        /// <summary>
        /// Data Constructor
        /// </summary>
        /// <param name="aCode"></param>
        /// <param name="aDescription"></param>
        /// <param name="aType"></param>
        /// <param name="aNotes"></param>
        public CFOP(string aCode, string aDescription, string aType, string aNotes)
        {
            Guid = System.Guid.NewGuid();
            Code = aCode.OnlyAlphanumeric();            
            Description = aDescription;
            Type = aType;
            Notes = aNotes;
        }
    }
}
