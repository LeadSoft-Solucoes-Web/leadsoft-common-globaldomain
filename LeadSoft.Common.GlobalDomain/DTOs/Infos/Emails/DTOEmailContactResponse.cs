using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOEmailContactResponse : DTOContactResponse
    {
        public DTOEmailContactResponse()
        {

        }


        /// <summary>
        /// Address
        /// </summary>
        [DataMember]
        [EmailAddress]
        public string Address { get; set; }
    }
}
