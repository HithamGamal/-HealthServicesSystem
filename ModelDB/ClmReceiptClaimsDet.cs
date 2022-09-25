using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
  public  class ClmReceiptClaimsDet:BaseEntity 
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        [ForeignKey("ReceiptId")]
        public virtual ClmReceiptClaims ClmReceiptClaims  { get; set; }
        public int FileNo { get; set; }
        public string FileName { get; set; }
        public int CountOfOrneks { get; set; }
        public decimal TotalOfClaims { get; set; }
        public int CountOfError { get; set; }
        public decimal Percent { get; set; }
        public int CountOfBoxFile { get; set; }
        public int ImpId { get; set; }

    }
}
