using ModelDB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HealthServicesSystem.Refunds
{
    public partial class FRMpreviousRequest : Telerik.WinControls.UI.RadForm
    {
        dbContext db = new dbContext();
        public FRMpreviousRequest()
        {
            InitializeComponent();
        }

        private void FRMpreviousRequest_Load(object sender, EventArgs e)
        {
            var rqsts = (from m in db.medicalCommitteeRequests
                        where m.rowStatus != RowStatus.Deleted
                         select new { Id = m.Id, InsurNo = m.InsurNo, InsurName = m.InsurName,
                             TotalCost = m.MedicalTotal,
                             CenterName = m.CenterName , RequsetType = m.RequestType })
                         .Take(10).ToList();

            rqstGRID.DataSource = rqsts;
        }

        private void RqstGRID_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            FRMMedicalCommitee form = (FRMMedicalCommitee)Application.OpenForms["FRMMedicalCommitee"];
           
            form.rqstId.Text = rqstGRID.CurrentRow.Cells["Id"].Value.ToString();
            this.Close();
        }
    }
}
