using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApproveMedicine:BaseEntity
    {
		public int Id { get; set; }
		public int ReqCenterId { get; set; }
        public int RouchitaNo { get; set; }
        public int ExcCenterId { get; set; }
		public DateTime ApproveDate { get; set; }
        public string ApproveCode { get; set; }
        public int DiagnosisId { get; set; }
        [ForeignKey("DiagnosisId")]
        public virtual Diagnosis Diagnosis { get; set; }
        public int pharmacistId { get; set; }
        [ForeignKey("pharmacistId")]
        public virtual Pharmacist Pharmacist { get; set; }
        public int ApproveTypeId { get; set; }
        [ForeignKey("ApproveTypeId")]
        public virtual ApproveMedicineType ApproveMedicineType { get; set; }
        public string Atachment { get; set; }
        public string PhoneNo { get; set; }
        public string InsurNo { get; set; }
        public string InsurName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Server { get; set; }
        public string ClientId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; }

    }

}
