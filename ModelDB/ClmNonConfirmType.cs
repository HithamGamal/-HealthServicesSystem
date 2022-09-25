using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
   public  class ClmNonConfirmType:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal  Value { get; set; }
        public ValueType ValueType { get; set; }
        public DicountType DicountType { get; set; }

    }
    public enum ValueType
    {
        Value,
        Percent
    }
    public enum DicountType
    {
        PerItems,
        PerVisit,
        PerClaims
    }

}
