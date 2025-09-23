using System.Collections.Generic;
using System.Linq;

namespace LeadSoft.Common.GlobalDomain.Entities.Pricing
{
    /// <summary>
    /// Prices class
    /// </summary>
    public partial class Prices
    {
        /// <summary>
        /// Value vigency
        /// </summary>
        public List<Price> This { get; private set; }
        
        /// <summary>
        /// Price value
        /// </summary>
        public decimal CurrentValue { get => GetValue().Value; }
    }
}