
using LeadSoft.Common.Library.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Integration DTO methods
    /// </summary>
    public partial class DTOIntegration
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DTOIntegration()
        {
        }

        /// <summary>
        /// Conversion To Integration Object
        /// </summary>
        /// <returns>Integration</returns>
        public LeadSoft.Common.GlobalDomain.Entities.Integration ToIntegration() => (LeadSoft.Common.GlobalDomain.Entities.Integration)this;
    }
}