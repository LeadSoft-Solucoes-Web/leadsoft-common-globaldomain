using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period methods
    /// </summary>

    public partial class DTOPeriod
    {
        public DTOPeriod()
        {
        }

        public DTOPeriod(Period aPeriod)
        {
            Since = aPeriod.Start;
            Until = aPeriod.End;
            IsInIt = aPeriod.IsInIt();
        }

        public static DTOPeriod ToDTO(Period aPeriod) => (DTOPeriod)aPeriod;
    }
}
