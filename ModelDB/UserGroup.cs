using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
 public     class UserGroup 
    {
    public int Id { get; set; }
    public string  GroupName { get; set; }
        public int SystemId { get; set; }
        [ForeignKey("SystemId")]
        public virtual Systems Systems { get; set; }
        public virtual  List<User> Users   { get; set; }

    }

}
