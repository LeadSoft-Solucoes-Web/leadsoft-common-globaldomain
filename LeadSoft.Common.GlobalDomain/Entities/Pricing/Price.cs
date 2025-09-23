using LeadSoft.Common.GlobalDomain.Entities;
using System;

namespace LeadSoft.Common.GlobalDomain.Entities.Pricing
{
    /// <summary>
    /// Price class
    /// </summary>
    public partial class Price
    {
        /// <summary>
        /// Value vigency
        /// Rules: Required
        /// </summary>
        public DateTime Vigency { get; set; }

        /// <summary>
        /// Price value
        /// Rules: Greater or Equal to 0
        /// </summary>
        public decimal Value { get; set; } = 0;

        /// <summary>
        /// Cost value
        /// Rules: Greater or Equal to zero
        /// </summary>
        public decimal Cost { get; set; } = 0;


        /// <summary>
        /// Notes that gives details for a price
        /// </summary>
        public string Note { get; private set; } = "";
    }

}
