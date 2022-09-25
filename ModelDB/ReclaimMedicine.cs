using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ReclaimMedicine:BaseEntity
    {
        public int Id { get; set; }
        public int ReclaimId { get; set; }
        [ForeignKey("ReclaimId")]
        public virtual Reclaim Reclaim { get; set; }
        public int MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public virtual MedicineForReclaim MedicineForReclaim { get; set; }
        public int Quantity { get; set; }
        public decimal ReclaimCost { get; set; }
        public decimal ReclaimTotal { get; set; }
        public int Percentages { get; set; }
        
    }
}
