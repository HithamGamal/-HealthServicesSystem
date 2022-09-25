using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class Approve
	{
		public int Id { get; set; }
		public string ApproveNo { get; set; }

		public int ReqCenterId { get; set; }
		public int ExcCenterId { get; set; }
		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual User  Users { get; set; }
		public int LocalityId { get; set; }
		[ForeignKey("LocalityId")]
		public virtual Locality Locality { get; set; }
		public DateTime ApproveDate { get; set; }
		public int ApproveYear { get; set; }
		public int ApproveMonth { get; set; }
		public string AttendenceReason { get; set; }
		public string ExceptionReason { get; set; }
		public string OtherExceptions { get; set; }
		public bool? Uploaded { get; set; }
		public bool? Answered { get; set; }
		public bool? UnderProcess { get; set; }
		public bool? Printed { get; set; }
		public bool? IsEngaged { get; set; }
		public DateTime EngeDate { get; set; }
		public DateTime EngeTime { get; set; }
		public string UpdateUser { get; set; }
		public bool? InContract { get; set; }
	}

}
