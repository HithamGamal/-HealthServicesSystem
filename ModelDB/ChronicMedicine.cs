using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ChronicMedicine
    {
        public int Id { get; set; }
        public string InsurNo { get; set; }
        public int GenericId { get; set; }
        [ForeignKey("GenericId")]
        public virtual MedicineForReclaim MedicineForReclaim { get; set; }
        public int Quantity { get; set; }
        
    }
}
