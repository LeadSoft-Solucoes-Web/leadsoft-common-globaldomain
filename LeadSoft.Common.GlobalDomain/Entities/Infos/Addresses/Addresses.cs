using System.Collections.Generic;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Addresses list
    /// </summary>
    public partial class Addresses
    {
        /// <summary>
        /// Primary Address 
        /// </summary>
        protected virtual string Primary { get; set; }

        /// <summary>
        /// List of Address type
        /// </summary>
        protected List<Address> This { get; set; }
    }
}
