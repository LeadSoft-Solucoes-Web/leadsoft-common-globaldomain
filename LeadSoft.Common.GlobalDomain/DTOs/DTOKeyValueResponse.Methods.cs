using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOKeyValueResponse
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        public DTOKeyValueResponse()
        {
        }

        /// <summary>
        /// Value constructor
        /// </summary>
        /// <param name="aKey">Key</param>
        /// <param name="aValue">Value</param>
        public DTOKeyValueResponse(string aKey, string aValue)
        {
            Id = null;
            Key = aKey;
            Value = aValue;
        }

        /// <summary>
        /// Value constructor
        /// </summary>
        /// <param name="aId">Guid Id</param>
        /// <param name="aKey">Key</param>
        /// <param name="aValue">Value</param>
        public DTOKeyValueResponse(Guid aId, string aKey, string aValue)
        {
            Id = aId;
            Key = aKey;
            Value = aValue;
        }

        /// <summary>
        /// Value constructor
        /// </summary>
        /// <param name="aId">Nullable Guid Id</param>
        /// <param name="aKey">Key</param>
        /// <param name="aValue">Value</param>
        public DTOKeyValueResponse(Guid? aId, string aKey, string aValue)
        {
            Id = aId;
            Key = aKey;
            Value = aValue;
        }
    }
}
