using Newtonsoft.Json;

using System.ComponentModel;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public class DTODownloadResponse : DTOResponse
    {
        public DTODownloadResponse()
        {

        }

        public DTODownloadResponse(Stream aFileStream, string aFileName, FileExtension? aFileExtension = null)
        {
            FileStream = aFileStream;
            FileName = aFileName;
            FileExtension = aFileExtension;
        }

        [DataMember]
        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Content { get; set; }
        [DataMember]

        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ContentType { get; set; }
        [DataMember]

        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual FileExtension? FileExtension { get; set; }
        [DataMember]

        [DefaultValue("")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string FileName { get; set; }

        [DataMember]
        public virtual Stream FileStream { get; set; }

        [DataMember]
        [DefaultValue(null)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual byte[] Bytes { get; set; }

        public string GetFileName() => string.Concat(FileName, FileExtension.HasValue ? FileExtension.Value.GetDescription() : string.Empty);
    }
}
