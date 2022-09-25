
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Chronics
    {
        public int Id { get; set; }
        public string ChronicName { get; set; }
        public int Activated { get; set; }



    }
}
