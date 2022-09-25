using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class UserPermission
    {
      public int Id { get; set; }
      public int FormId { get; set; }
      [ForeignKey("FormId")]
      public virtual SysForm SysForms { get; set; }
      public int UserId { get; set; }
      [ForeignKey("UserId")]
      public virtual User  Users  { get; set; }

    }


}
