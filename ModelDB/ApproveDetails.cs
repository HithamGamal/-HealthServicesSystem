using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApproveDetails
	{
		public int Id { get; set; }
		public int ApproveId { get; set; }
		[ForeignKey("ApproveId")]
		public virtual Approve Approves { get; set; }

		public string ApproveNo { get; set; }

		public int ServiceId { get; set; }
		[ForeignKey("ServiceId")]
		public virtual MedicalServices MedicalServices { get; set; }
		public decimal? ApproveCost { get; set; }
		public decimal? TotalCost { get; set; }
		public decimal? Diff { get; set; }
		public int? Sessions { get; set; }
	}

}
