using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class MedicinePriceGroup
    {

		public int Id { get; set; }
		public string GroupName { get; set; }

        public decimal MaxPrice  { get; set; }
        public int Percentag { get; set; }

        public bool IsEnabled { get; set; }
      
	}
}
