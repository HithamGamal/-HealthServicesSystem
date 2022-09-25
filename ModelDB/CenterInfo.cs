using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class CenterInfo
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string CenterName { get; set; }
		public int LocalityId { get; set; }
        public bool Level1 { get; set; }
        public bool Level2 { get; set; }
        public bool Level3 { get; set; }
        public bool Level4 { get; set; }
        public bool HasContract { get; set; }		
		public CenterType CenterTypeId { get; set; }
		public bool IsEnabled { get; set; }
        public bool IsVisible { get; set; }
    }
	public enum CenterType
	{
        None,
		مركز,
		مستشفى,
		صيدلية,
        معمل,
        مركزوصيدلية

	}


}
