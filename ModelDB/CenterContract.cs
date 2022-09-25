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
	public class CenterContract
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id {get; set;}
		public int CenterId {get; set;}
		[ForeignKey("CenterId")]
		public virtual  CenterInfo CenterInfo { get; set;}
		public int ServiceId {get; set;}
		[ForeignKey("ServiceId")]
		public virtual MedicalServices MedicalServices {get; set;}
		public decimal? TotalPrice {get; set;}
		public decimal? InsurPrice {get; set;}
		public decimal? PatientPrice {get; set;}
		public int? Sessions {get; set;}
		public bool? IsEnabled {get; set;}

	}

}