using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public  class ClmContractType:BaseEntity 
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
    }
}
