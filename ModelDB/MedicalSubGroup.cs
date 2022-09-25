using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class MedicalSubGroup
	{

		public int Id { get; set; }
		public int MainGroupId { get; set; }
		[ForeignKey("MainGroupId")]
		public virtual MedicalMainGroup MainGroup { get; set; }
		public string SubGroupEname { get; set; }
		public string SubgroupAName { get; set; }
		public bool IsEnabled { get; set; }
		public virtual List<MedicalServices> MedicalServices { get; set; }
	}
}
