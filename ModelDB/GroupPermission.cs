using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public   class GroupPermission
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        [ForeignKey("FormId")]
        public virtual SysForm SysForms { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual UserGroup  UserGroups  { get; set; }
    }

}
