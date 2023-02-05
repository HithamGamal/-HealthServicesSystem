using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class MedicinePriceGroup
    {

		public int Id { get; set; }
		public string GroupNameName { get; set; }

        public decimal GroupMaxGroup  { get; set; }
		public bool IsEnabled { get; set; }
      
	}
}
