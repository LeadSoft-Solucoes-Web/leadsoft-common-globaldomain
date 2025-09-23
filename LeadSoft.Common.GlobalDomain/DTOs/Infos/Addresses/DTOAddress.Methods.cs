using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Address methods
    /// </summary>
    public partial class DTOAddress
    {
        /// <summary>
        /// Set Primary methods
        /// </summary>
        public void SetPrimary() => IsPrimary = true;
        
        /// <summary>
        /// 
        /// </summary>
        public Address ToAddress() => (Address)this;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aAddress"></param>
        /// <returns></returns>
        public static DTOAddress ToDTO(Address aAddress) => (DTOAddress)aAddress;
    }
}
