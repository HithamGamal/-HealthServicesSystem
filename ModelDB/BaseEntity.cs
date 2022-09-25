using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class BaseEntity
    {
        public int UserId { get; set; }
        public DateTime DateIn { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public RowStatus RowStatus { get; set; }
        public int LocalityId { get; set; }

    }
    //*************************Change Adding Status Enum && RowStatus
    public enum Status
    {
        Active = 0,
        DisActive = 1,
        Nothing = 2
    }
    public enum RowStatus
    {
        NewRow = 0,
        Edited = 1,
        Deleted = 2
    }
}
