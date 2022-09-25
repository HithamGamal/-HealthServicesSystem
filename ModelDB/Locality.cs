
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class Locality
	{
		public int Id { get; set; }
		public string LocalityName { get; set; }
		public string LocalityLetter { get; set; }
        public string LocalityIP { get; set; }

    }
}
