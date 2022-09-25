using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public  class ClmDetailsData:BaseEntity 
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        [ForeignKey("MasterId")]
        public virtual ClmMasterData ClmMasterData { get; set; }
        public int GenericId { get; set; }
        [ForeignKey("GenericId")]
        public virtual Medicine Medicine { get; set; }
        public string TradeName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal  NonConfItem { get; set; }
        public decimal NonConfVisit { get; set; }
        public decimal NonConfClaims { get; set; }



    }
}
