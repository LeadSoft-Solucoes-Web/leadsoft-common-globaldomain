using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public class DTOBoolResponse : DTOResponse
    {
        [DataMember]
        public virtual bool? Result { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DTOBoolResponse()
        {

        }

        /// <summary>
        /// Constructor that sets Result property
        /// </summary>
        /// <param name="aResult">Boolean argument</param>
        public DTOBoolResponse(bool aResult)
        {
            Result = aResult;
        }

        /// <summary>
        /// Return if Result is true.
        /// Null means false
        /// </summary>
        /// <returns>True or False</returns>
        public bool IsTrue()
        {
            return (bool)Result;
        }

        /// <summary>
        /// Return if Result is false. If false, then true
        /// Null means false, so it returns true
        /// Mindfuck!
        /// </summary>
        /// <returns>True or False if false or true</returns>
        public bool IsFalse()
        {
            return (bool)!Result;
        }
    }
}
