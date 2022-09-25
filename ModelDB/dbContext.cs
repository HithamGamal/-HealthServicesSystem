using System.Data.Entity;

namespace ModelDB
{
    public class dbContext : DbContext
    {
      //  public DbSet<HICKS_DC> HICKS_DCs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
       // public DbSet<Prescription_Level> Prescription_Levels { get; set; }
        public DbSet<Approve> Approves { get; set; }
        public DbSet<ApproveDetails> ApproveDetails { get; set; }
        public DbSet<ApprovePictures> ApprovePictures { get; set; }
        public DbSet<ApprovePrint> ApprovePrints { get; set; }
        public DbSet<CenterInfo> CenterInfos { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MedicalMainGroup> MedicalMainGroups { get; set; }
        public DbSet<MedicalSubGroup> MedicalSubGroups { get; set; }
        public DbSet<MedicalServices> MedicalServices { get; set; }
        public DbSet<MedicalServicesTemp> MedicalServicesTemp { get; set; }
        public DbSet<Reclaim> Reclaims { get; set; }
        public DbSet<ReclaimBills> ReclaimBills { get; set; }
        public DbSet<ReclaimMedical> ReclaimMedicals { get; set; }
        public DbSet<ReclaimMedicalReasonsList> ReclaimMedicalReasonsLists { get; set; }
        public DbSet<ReclaimMedicine> ReclaimMedicines { get; set; }
        public DbSet<ReclaimMedicineReasonsList> ReclaimMedicineReasonsLists { get; set; }
        public DbSet<SysForm> SysForms { get; set; }
        public DbSet<Systems> Systems { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet <ATCclassification> ATCclassifications { get; set; }
        public DbSet<MedicineLevel> MedicineLevels { get; set; }
        public DbSet<MedicineList> MedicineLists { get; set; }
        public DbSet<MedicineListPrice> MedicineListPrices { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Generic> Generics { get; set; }
        public DbSet<MedicineTemp> MedicineTemps { get; set; }
        public DbSet<MedicineForReclaim> MedicineForReclaims { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ApproveMedicine> ApproveMedicines { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<ApproveMedicineDetails> ApproveMedicineDetails { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<AdmRS> AdMRS { get; set; }
        public DbSet<HICKS_DCS> HICKS_DCS { get; set; }
        public DbSet<US> US { get; set; }
        public DbSet<ChkUpdate> ChkUpdates { get; set; }
        public DbSet<Chronics> Chronics { get; set; }
        public DbSet<ChronicsBooks> ChronicsBooks { get; set; }
        public DbSet<ChronicBooksDetails> ChronicBooksDetails { get; set; }
        public DbSet<ApproveMedicineType > ApproveMedicineTypes { get; set; }
        public DbSet<ChronicBookType> ChronicBookTypes { get; set; }
        public DbSet<ClmContractType> ClmContractType { get; set; }
        public DbSet<ClmDetailsData> ClmDetailsData { get; set; }
        public DbSet<ClmImpFile> ClmImpFile { get; set; }
        public DbSet<ClmMasterData> ClmMasterData { get; set; }
        public DbSet<ClmReceiptClaims> ClmReceiptClaims { get; set; }
        public DbSet<ClmReceiptClaimsDet> ClmReceiptClaimsDet { get; set; }
        public DbSet<ClmTempDet> ClmTempDet { get; set; }
        public DbSet<ClmTempMaster> ClmTempMaster { get; set; }
        public DbSet<ClmNonConfirmDet> ClmNonConfirmDet { get; set; }
        public DbSet<ClmNonConfirmType> ClmNonConfirmType { get; set; }
        public DbSet<ClmErrorType> ClmErrorType { get; set; }
        public DbSet<ClmSortedDeg> ClmSortedDeg { get; set; }
        public DbSet<ClmErrorDataEnter> ClmErrorDataEnter { get; set; }
        public DbSet<RefuseMedicine> RefuseMedicines { get; set; }
        public DbSet<RefuseMedicineDetails> RefuseMedicineDetails { get; set; }
        public DbSet<StopSubsriber> StopSubsribers { get; set; }

    }
}
