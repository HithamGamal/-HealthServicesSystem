using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class ReclaimMedicineReasonsList
    {
        public int Id { get; set; }
        public string MedicineReason { get; set; }
        public bool Activated { get; set; }
    }
}
