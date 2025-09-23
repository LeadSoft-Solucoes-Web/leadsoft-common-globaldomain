
using LeadSoft.Common.Library.Constants;

using Newtonsoft.Json;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Integration DTO
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOIntegration
    {
        /// <summary>
        /// Integration Type
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public IntegrationServiceType IntegrationServiceType { get; set; }

        /// <summary>
        /// App Key
        /// </summary>
        [DataMember]
        public string AppKey { get; set; }

        /// <summary>
        /// App Secret
        /// </summary>
        [DataMember]

        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AppSecret { get; set; }
    }
}