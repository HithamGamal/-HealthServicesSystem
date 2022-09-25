using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class RefuseMedicineDetails 
    {
		public int Id { get; set; }
		public int RefuseId { get; set; }
		[ForeignKey("RefuseId")]
		public virtual RefuseMedicine RefuseMedicine { get; set; }
		public string RefuseReason { get; set; }
    }

}
