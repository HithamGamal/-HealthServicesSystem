using ModelDB;
using System;
using System.Data;
using System.Linq;

namespace HealthServicesSystem.Committee
{
    public partial class CommitteeListHistory : Telerik.WinControls.UI.RadForm
    {
        dbContext db = new dbContext();
        public CommitteeListHistory()
        {
            InitializeComponent();
        }

        private void CommitteeListHistory_Load(object sender, EventArgs e)
        {
            string id = PLC.SubId;
            var services = (from m in db.medicalCommitteeRequestDetails
                         where m.RowStatus == RowStatus.NewRow
                         && m.InsurId == id
                         select new
                         {
                             Service_Name = m.Service_Name,
                             Pat_cost = m.Pat_cost,
                             Insur_cost = m.Insur_cost,
                             ServiceCost = m.ServiceCost,
                             Co_cost = m.Co_cost,
                             InvoiceCost = m.InvoiceCost,
                             AllowCost = m.AllowCost,
                             CenterName= m.MedicalCommitteeRequest.CenterName,
                             CoInsurance = m.MedicalCommitteeRequest.CoInsurance,
                             DateIn = m.MedicalCommitteeRequest.DateIn,

                         })
                        .ToList();

            serviceListGRD.DataSource = services;


        }
    }
}
