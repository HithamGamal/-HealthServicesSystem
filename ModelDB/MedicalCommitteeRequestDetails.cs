using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class MedicalCommitteeRequestDetails
    {
        public int Id { get; set; }
        public string InsurId { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual MedicalCommitteeRequest MedicalCommitteeRequest { get; set; }
        public int ServiceId { get; set; }
        public string Service_Name{ get; set; }
        public decimal Co_cost { get; set; }
        public decimal  Pat_cost { get; set; }
        public decimal Insur_cost { get; set; }
        public decimal ServiceCost { get; set; }
        public RowStatus RowStatus { get; set; }

    }
}
