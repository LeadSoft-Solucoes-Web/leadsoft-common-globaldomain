using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{
    
    
    public class DTOBankAccountParameters
    {
        
        public string Code { get; set; }

        
        public string AgencyNumber { get; set; }

        
        public string AccountNumber { get; set; }
    }
}
