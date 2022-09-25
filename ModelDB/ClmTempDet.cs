using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
  public   class ClmTempDet:BaseEntity 
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        [ForeignKey("MasterId")]
        public virtual ClmTempMaster ClmTempMaster { get; set; }
        public int GenericId { get; set; }
        [ForeignKey("GenericId")]
        public virtual Medicine  Medicine { get; set; }
        public string TradeName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
