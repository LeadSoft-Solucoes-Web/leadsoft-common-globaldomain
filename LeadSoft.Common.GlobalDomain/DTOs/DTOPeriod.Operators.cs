using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period operators
    /// </summary>

    public partial class DTOPeriod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImageData"></param>
        public static explicit operator DTOPeriod(Period aPeriod)
        {
            if (aPeriod.IsNull())
                return null;

            return new(aPeriod);
        }
    }
}
