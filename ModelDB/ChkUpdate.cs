//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ChkUpdate
	{
		public int Id {get; set;}
		public bool Updated {get; set;}
		public DateTime UpdateDate {get; set;}
	}

}