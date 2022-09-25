using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public  class ClmNonConfirmDet:BaseEntity 
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        [ForeignKey("MasterId")]
        public virtual ClmMasterData  ClmMasterData { get; set; }
        public int NonConfirmId { get; set; }
        [ForeignKey("NonConfirmId")]
        public virtual ClmNonConfirmType ClmNonConfirmType { get; set; }
        public int? DetailsId { get; set; }
        public decimal  Value { get; set; }
        public decimal Percent { get; set; }


    }
}
