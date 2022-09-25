using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModelDB
{
   
    public class MedicineTemp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string ATC_code { get; set; }
        public int ATCId { get; set; }
        public int GenericId { get; set; }
        public string Generic_name { get; set; }
        public int Unit_Id { get; set; }
        public PLS PL { get; set; }
        public int HICKS_DC { get; set; }
        public string NOTE { get; set; }
        public decimal DDD { get; set; }
        public int U { get; set; }
        public int Adm_R { get; set; }
        public string Regestration { get; set; }
        public string TermsOfUse { get; set; }
        public EditeMode EditeMode { get; set; }
        public int UserId { get; set; }
        public int? UpdateUser { get; set; }
        public int? DeleteUser { get; set; }

        public int Activated { get; set; }
    }

 


   

    public enum EditeMode
    {
        None,
        Update,
        Insert,
        Delete

    }

}
