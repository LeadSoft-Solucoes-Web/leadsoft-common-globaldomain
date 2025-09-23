using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTODocumentFileInfo
    {
        /// <summary>
        /// File extension enum
        /// </summary>
        [DataMember]
        public FileExtension Extension { get; set; }

        /// <summary>
        /// File size in bytes (b)
        /// </summary>
        [DataMember]

        public long Size { get; set; }
    }
}
