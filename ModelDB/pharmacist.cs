
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Pharmacist
    {
        public int Id { get; set; }
        public string pharmacistName { get; set; }
        public int Activated { get; set; }



    }
}
