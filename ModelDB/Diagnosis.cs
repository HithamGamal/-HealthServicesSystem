
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Diagnosis
    {
        //public Item()
        //{
        //    PharmSaleDetails = new List<ModelDB.PharmSaleDetails>();
        //}
        public int Id { get; set; }
        public string DiagnosisName { get; set; }
        public int Activated { get; set; }



    }
}
