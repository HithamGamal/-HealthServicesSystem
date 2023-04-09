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
                        where m.RowStatus != RowStatus.Deleted
                         select new { Id = m.Id, InsurNo = m.InsurNo,
                             InsurName = m.InsurName,
                             TotalCost = m.MedicalTotal,
                             CenterName = m.CenterName ,
                             RequsetType = m.RequestType == RequestType.Transfer ?"تحويل" : 
                                           m.RequestType== RequestType.Cooperation ? "مساهمة" :
                                           m.RequestType == RequestType.Physiotheraby ? "علاج طبيعي":
                                             m.RequestType == RequestType.Committee ? "لجنة " : ""
                         })
                         .ToList();

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
