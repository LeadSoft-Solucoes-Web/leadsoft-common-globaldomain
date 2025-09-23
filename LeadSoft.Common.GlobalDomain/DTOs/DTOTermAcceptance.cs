using LeadSoft.Common.Library.Constants;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Term Acceptance DTO.
    /// </summary>

    [Serializable]
    [DataContract]
    //[TermAcceptanceValidation]
    public class DTOTermAcceptance
    {
        /// <summary>
        /// Boolean that determines if Term was accepted. False results in 404 bad request by definition.
        /// </summary>
        [DataMember]
        public bool AcceptedTerm { get; set; }

        /// <summary>
        /// Term Id
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public Guid TermId { get; set; }

        /// <summary>
        /// Software Id retrieved by header
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public Guid SoftwareId { get; private set; }

        public DTOTermAcceptance()
        {
        }

        public DTOTermAcceptance SetSoftware(Guid aSoftwareId)
        {
            SoftwareId = aSoftwareId;
            return this;
        }
    }
}
