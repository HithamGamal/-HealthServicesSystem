using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public  class ClmTempMaster:BaseEntity 
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public int ContractId { get; set; }
        public int DaignosisId { get; set; }
        public int ImpId { get; set; }
        public int FileNo { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public int NoOfFile { get; set; }
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }

        public double InsuranceNo { get; set; }
        public string PatName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int CleintId { get; set; }

   
    }
}
