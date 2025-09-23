using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract]
    public class DTOGuidResponse : DTOResponse
    {
        /// <summary>
        /// Constructor that sets informed Guid
        /// </summary>
        /// <param name="aGuid">Guid value to be set</param>
        public DTOGuidResponse(Guid? aGuid)
        {
            Id = aGuid;
        }

        /// <summary>
        /// base constructor
        /// </summary>
        public DTOGuidResponse()
        {
            Id = null;
        }
    }
}
