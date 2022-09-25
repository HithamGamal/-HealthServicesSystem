using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApproveMedicineDetails
    {
		public int Id { get; set; }
		public int ApproveMedicineId { get; set; }
		[ForeignKey("ApproveMedicineId")]
		public virtual ApproveMedicine ApproveMedicine { get; set; }
		public int ServiceId { get; set; }
		[ForeignKey("ServiceId")]
		public virtual MedicineForReclaim MedicineForReclaim { get; set; }
		public int Quantity { get; set; }
		public int ApprovedQuantity { get; set; }
        public int ApproveDuration { get; set; }
    }

}
