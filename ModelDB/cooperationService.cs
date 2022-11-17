namespace ModelDB
{
    public class cooperationService
    {
        public int Id { get; set; }
        public string Service_AR_Name { get; set; }
        public string Service_EN_Name { get; set; }
        public string Cost { get; set; }
        public string Validity { get; set; }
        public RowStatus rowStatus { get; set; }
    }
}
