using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Person
{
    /// <summary>
    /// DTONaturalPersonResponse
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTONaturalPersonResponse : DTOResponse
    {
        public DTONaturalPersonResponse()
        {

        }


        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        [DataMember]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [DataMember]
        public Gender? Gender { get; set; }

    }
}
