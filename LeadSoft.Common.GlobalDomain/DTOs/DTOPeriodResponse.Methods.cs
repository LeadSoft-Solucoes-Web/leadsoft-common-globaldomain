using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period Response methods
    /// </summary>

    public partial class DTOPeriodResponse
    {
        public DTOPeriodResponse()
        {
        }

        public DTOPeriodResponse(Period aPeriod)
        {
            Since = aPeriod.Start;
            Until = aPeriod.End;
            IsInIt = aPeriod.IsInIt();
        }

        public static DTOPeriodResponse ToDTO(Period aPeriod) => (DTOPeriodResponse)aPeriod;
    }
}
