using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MACAddress { get; set; }
        public DateTime Date { get; set; }
        public Boolean logStatus { get; set; }
    }
}
