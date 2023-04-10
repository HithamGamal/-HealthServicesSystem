using HealthServicesSystem.SystemSetting;
using ModelDB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Refunds
{
    public partial class FRMpreviousRequest : Telerik.WinControls.UI.RadForm
    {
        dbContext db = new dbContext();
        public int _UserId = LoginForm.Default.UserId;
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
                             username= m.UserId,
                             DateIn = m.DateIn,
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

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (rqstGRID.CurrentColumn.Name == "delete")
            {

                int Id = Convert.ToInt32(rqstGRID.CurrentRow.Cells["Id"].Value);
                if (Id != 0)
                {


                    var del_main = db.medicalCommitteeRequests.Where(x => x.Id == Id).First();

                    del_main.RowStatus = RowStatus.Deleted;
                    del_main.UserDeleted = _UserId;
                    del_main.DeleteDate = PLC.getdate();
                    db.SaveChanges();

                    var del_details = db.medicalCommitteeRequestDetails.Where(x => x.RequestId == Id).ToList();
                    foreach (var item in del_details)
                    {


                        item.RowStatus = RowStatus.Deleted;
                        item.UserDeleted = _UserId;
                        item.DeleteDate = PLC.getdate();
                        db.SaveChanges();
                    }
                }

                rqstGRID.CurrentRow.Delete();
                RadMessageBox.Show("تم الحذف");
            }
        }
    }
}
