
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class ChronicBooksDetails
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual ChronicsBooks ChronicsBooks { get; set; }
        public int ChronicId { get; set; }
        [ForeignKey("ChronicId")]
        public virtual Chronics Chronics { get; set; }



    }
}
