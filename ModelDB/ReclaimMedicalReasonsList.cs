using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ReclaimMedicalReasonsList
    {
        public int Id { get; set; }
        public string MedicalReason { get; set; }
        public bool Activated { get; set; }
    }
}
