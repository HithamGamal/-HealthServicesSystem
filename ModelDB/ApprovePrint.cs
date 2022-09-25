using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApprovePrint
	{
		public int Id { get; set; }
		public int ApproveId { get; set; }
		[ForeignKey("ApproveId")]
		public virtual Approve Approves { get; set; }
		public string ApproveNo { get; set; }


		public DateTime PrintDate { get; set; }
	}
}
