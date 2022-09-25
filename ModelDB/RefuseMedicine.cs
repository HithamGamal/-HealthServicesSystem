using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class RefuseMedicine 
    {
		public int Id { get; set; }
		public int ReqCenterId { get; set; }
        public int ExcCenterId { get; set; }
		public DateTime RefuseDate { get; set; }

        public int UserId { get; set; }
        public string PhoneNo { get; set; }
        public string InsurNo { get; set; }
        public string InsurName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Server { get; set; }
        public string ClientId { get; set; }
        public DateTime BirthDate { get; set; }
    }

}
