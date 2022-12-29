using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public class ExceptionClient:BaseEntity 
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
      


    }
}
