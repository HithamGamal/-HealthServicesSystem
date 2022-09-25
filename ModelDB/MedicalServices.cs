using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class MedicalServices
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public int SubGroupID { get; set; }
		[ForeignKey("SubGroupID")]
		public virtual MedicalSubGroup SubGroup { get; set; }
		public string ServiceEName { get; set; }
		public string ServiceAName { get; set; }
		public decimal? ServiceEmPrice { get; set; }
		public decimal ServicePrice { get; set; }
		public int? ServiceFrequency { get; set; }
		public int? Duration { get; set; }
		public ListType ListType { get; set; }
		public bool? NeedApproveMent { get; set; }
		public bool InContract { get; set; }
		public bool? IsEnabled { get; set; }
		public int? Sessions { get; set; }
        public bool? IsVisible { get; set; }
        public bool FromTheList { get; set; }
        public int Percentag { get; set; }
    }
	public enum ListType
    {
		مايعادل,
		مساهمة
	}
}

