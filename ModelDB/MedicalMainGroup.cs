using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class MedicalMainGroup
	{

		public int Id { get; set; }
		public string MainGroupEnglishName { get; set; }

		public string MainGroupArabicName { get; set; }
		public string MainGroupCode { get; set; }
		public bool IsEnabled { get; set; }
		public virtual List<MedicalSubGroup> SubGroup { get; set; }
	}
}
