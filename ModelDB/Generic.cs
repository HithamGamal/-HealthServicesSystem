using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Generic
    {
      
        public int Id { get; set; }
        public string GenericName { get; set; }
        public int IsActive { get; set; }
    }

}
