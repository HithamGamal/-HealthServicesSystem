using System;

namespace ModelDB
{
    public  class MedicalCommitteeRequest : BaseEntity
    {

        public int Id { get; set; }
        public string InsurNo { get; set; }
        public string InsurName { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Server { get; set; }
        public string ClientId { get; set; }
        public DateTime BirthDate { get; set; }
        public string SectorName { get; set; }
        public int? SectorId { get; set; }
        public decimal MedicalTotal { get; set; }
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public string CenterFrom { get; set; }
        public string ExceptionReason { get; set; }
        public string CoInsurance { get; set; }
        public CardType CardType  { get; set; }
        public RequestType RequestType { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }

    public enum RequestStatus  {
        confirmed,
        deny,
        refund_deprtment
    }

    public enum RequestType
    {
        Transfer,
        Cooperation,
        Physiotheraby,
        Committee
    }
    public enum CardType
    {
        national,
        local,
        manual
    }
}
