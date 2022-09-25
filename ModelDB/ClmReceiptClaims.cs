using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ClmReceiptClaims:BaseEntity 
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int year { get; set; }
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual CenterInfo CenterInfo { get; set; }
        public string ContactName { get; set; }
        public string ContactTell { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime  ReceiptDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string Notes { get; set; }
        public int Sorted { get; set; }
        public int DataEntery { get; set; }

    }
}
