using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
  public class SysForm 
    { 
        public int Id { get; set; }
        public int SystemsId { get; set; }
        [ForeignKey("SystemsId")]
        public virtual Systems Systems { get; set; }
        public string FormName { get; set; }
        public string EnglishFormName { get; set; }
        public string ArabicFormName { get; set; }
        public string FormType { get; set; }

    //    public virtual GroupPermission GroupPermissions { get; set; }


    }
}
