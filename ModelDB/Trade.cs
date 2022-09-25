
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Trade
    {
        //public Item()
        //{
        //    PharmSaleDetails = new List<ModelDB.PharmSaleDetails>();
        //}
        public int Id { get; set; }
        public string TradeName { get; set; }
        public int GenericId { get; set; }
        [ForeignKey("GenericId")]
        public virtual Generic Generic { get; set; }
        public int IsActive { get; set; }


    }
}
