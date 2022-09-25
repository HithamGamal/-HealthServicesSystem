using System;
namespace ModelDB
{
    public class CompanySetting
    {

        public int Id { get; set; }
        public string CompanyName{ get; set; }
        public  byte[] LogoPath1 { get; set; }
        public byte[] LogoPath2 { get; set; }
        public string  ManagerName { get; set; }
        public string WebSite { get; set; }
        public string Management { get; set; }
        public string Department { get; set; }
    }
}
