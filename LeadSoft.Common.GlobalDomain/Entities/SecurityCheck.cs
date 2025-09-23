using System;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    
    
    public class SecurityCheck
    {
        
        public virtual string Key { get; set; }

        
        public virtual DateTime When { get; set; }
    }
}
