﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
  public   class ClmMasterData:BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual CenterInfo CenterInfo { get; set; }
        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public virtual ClmContractType ClmContractType { get; set; }
        public int DaignosisId { get; set; }
        [ForeignKey("DaignosisId")]
        public virtual Diagnosis  Diagnosis { get; set; }
        public int ImpId { get; set; }
        public int FileNo { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public int NoOfFile { get; set; }
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public string   InsuranceNo { get; set; }
        public string PatName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int CleintId { get; set; }
        public int? ReviewDocId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? ApproveUserId { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int IsReviewed { get; set; }




    }
 
}
