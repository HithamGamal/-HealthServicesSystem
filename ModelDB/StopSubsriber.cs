using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class StopSubsriber
    {
		public int Id { get; set; }
		public DateTime StopDate { get; set; }
        public int UserId { get; set; }
        public string InsurNo { get; set; }
        public Boolean? IsStoped { get; set; }
        public string Comment { get; set; }
    }

}
