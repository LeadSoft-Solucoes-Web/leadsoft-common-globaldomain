using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    /// <summary>
    /// Constructor that sets informed Value
    /// </summary>
    /// <param name="aUrl">Value to be set</param>
    /// <param name="aThumbnailUrl">Value to be set</param>
    [Serializable]
    [DataContract]
    public class DTOUploadResponse(Uri aUrl, Uri aThumbnailUrl = null) : DTOResponse
    {
        [DataMember]
        public virtual Uri Url { get; set; } = aUrl;

        [DataMember]
        public virtual Uri ThumbnailUrl { get; set; } = aThumbnailUrl;
    }
}
