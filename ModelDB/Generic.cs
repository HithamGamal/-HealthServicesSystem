using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Generic
    {
      
        public int Id { get; set; }
        public string GenericName { get; set; }
        public int Unit_Id { get; set; }
        [ForeignKey("Unit_Id")]
        public virtual Unit Unit { get; set; }
        public int IsActive { get; set; }
    }

}
