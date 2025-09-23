using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain
{

    
    public class PagingMetadata
    {
        
        public virtual int CurrentPage { get; set; }

        
        public virtual int PageSize { get; set; }

        
        public virtual long TotalResults { get; set; }

        
        public virtual int TotalPages { get; set; }

        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string PreviousPageLink { get; set; }

        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string CurrentPageLink { get; set; }

        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string NextPageLink { get; set; }

        public PagingMetadata()
        {
            PreviousPageLink = null;
            CurrentPageLink = null;
            NextPageLink = null;
        }
    }
}
