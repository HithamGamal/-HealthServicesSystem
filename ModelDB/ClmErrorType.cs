using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public  class ClmErrorType:BaseEntity 
    {
        public int Id { get; set; }
        public string ErrorName { get; set; }
        public ErrorGroup ErrorGroup { get; set; }

    }
  
}
