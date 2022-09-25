using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class ClmImpFile : BaseEntity
    {
        public int Id { get; set; }
        public int FileNo { get; set; }
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual  CenterInfo CenterInfo  { get; set; }
        public int Month { get; set; }
        public int year { get; set; }
        public DateTime  ImpDate { get; set; }
        public int Counts { get; set; }
        public int DrogCount { get; set; }
        public string FilePath { get; set; }
        public decimal  Costs { get; set; }
        public ClmStatus ClmStatus { get; set; }
        public int? TemporaryUserId { get; set; }
        public DateTime? TemporaryDate { get; set; }
        public int? ImportUserId { get; set; }
        public DateTime? ImportDate { get; set; }
        public int? ReceiptUserId { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int? EnabledUserId { get; set; }
        public DateTime? EnabledDate { get; set; }
        public int? RequestUserId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? AllocationUserId { get; set; }
        public DateTime? AllocationtDate { get; set; }
        public int? ReviewUserId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? ApproveUserId { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? CompleteId { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int AllocatedDocId { get; set; }
        [ForeignKey("AllocatedDocId")]
        public virtual User User  { get; set; }
    }
    public enum ClmStatus
    {
       Temporary,
       Import,
        Receipt,
        Enabled,
        Request,
        Allocation,
        Review,
        Approve,
        Complete


    }
}
