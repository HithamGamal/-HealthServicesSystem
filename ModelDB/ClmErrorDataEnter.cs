using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
  public  class ClmErrorDataEnter:BaseEntity
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        [ForeignKey("ReceiptId")]
        public virtual ClmReceiptClaims ClmReceiptClaims { get; set; }
        public int ErrorId { get; set; }
        [ForeignKey("ErrorId")]
        public virtual ClmErrorType ClmErrorTypes { get; set; }
        public ErrorGroup ErrorGroup  { get; set; }
        public int  VistNo { get; set; }
        public string EmpName { get; set; }
        public decimal  Cost { get; set; }
        public int Counts { get; set; }
        public string Notes { get; set; }
    }
public enum ErrorGroup
{
    خطاء_ضباط_خدمة,
    خطاء_مدخل_بيانات
}
}

