using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Period Class
    /// </summary>
    public partial class Period
    {
        /// <summary>
        /// DateTime value
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? Start { get; set; }
    
        /// <summary>
        /// DateTime value
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? End { get; set; }
    }
}

