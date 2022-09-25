using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelDB
{
      public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual UserGroup UserGroup { get; set; }
        public int UserStatus { get; set; }
        public string Image { get; set; }
        public int? LocalityId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public UserType UserType { get; set; }




    }
    public enum UserType
    {
        Admin,
        User

    }


}
