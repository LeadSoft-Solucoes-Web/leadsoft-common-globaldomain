using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period Response operators
    /// </summary>

    public partial class DTOPeriodResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImageData"></param>
        public static explicit operator DTOPeriodResponse(Period aPeriod)
        {
            if (aPeriod.IsNull())
                return null;

            return new(aPeriod);
        }
    }
}
