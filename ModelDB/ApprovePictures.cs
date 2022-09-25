using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApprovePictures
	{
		public int Id { get; set; }
		public int ApproveId { get; set; }
		[ForeignKey("ApproveId")]
		public virtual Approve Approves { get; set; }
		public int UploadId { get; set; }
		[ForeignKey("UploadId")]
		public virtual Upload Uploades { get; set; }
		public string ApproveNo { get; set; }


		public byte[] ScannedPicture { get; set; }
		public string PhotoName { get; set; }
	}

}
