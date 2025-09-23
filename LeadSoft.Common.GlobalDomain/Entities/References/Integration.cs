using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Integration Class
    /// </summary>
    public partial class Integration
    {
        /// <summary>
        /// Integration Type
        /// </summary>
        public IntegrationServiceType IntegrationServiceType { get; set; }

        /// <summary>
        /// App Key
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// App Secret
        /// </summary>
        public string AppSecret { get; private set; }
    }
}
