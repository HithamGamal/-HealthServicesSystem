using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModelDB
{
    public class MedicineListPrice
    {

        public int Id { get; set; }
        public int ListId { get; set; }
        [ForeignKey("ListId")]
        public virtual MedicineList MedicineList { get; set; }
        public int GenericId { get; set; }
        [ForeignKey("GenericId")]
        public virtual Medicine Medicine { get; set; }
        public decimal GenericPrice { get; set; }

    }


}
