using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ReclaimBills
    {
        public int Id { get; set; }
        public int ReclaimId { get; set; }
        [ForeignKey("ReclaimId")]
        public virtual Reclaim Reclaim { get; set; }
        public int ServiceProviderId { get; set; }
        [ForeignKey("ServiceProviderId")]
        public virtual CenterInfo CenterInfo { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal BillTotal { get; set; }
    }
}
