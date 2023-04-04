using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Claims
{
    public partial class UserReviewRepFrm : Telerik.WinControls.UI.RadForm
    {
        public UserReviewRepFrm()
        {
            InitializeComponent();
        }

        private void UserReviewRepFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var q = db.Users .Where(p => p.GroupId ==9 || p.GroupId ==6 || p.GroupId ==3).Select(p => new { Id = p.Id, UserName = p.FullName  }).ToList();
            if (q.Count > 0)
            {
                DocNameList .DataSource = q;
                DocNameList.DisplayMember = "UserName";
                DocNameList.ValueMember = "Id";
                DocNameList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                DocNameList.SelectedIndex = -1;
            }
            var qCenter = db.CenterInfos.Where(p => p.HasContract == true && p.IsEnabled == true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
            if (qCenter.Count > 0)
            {
                CenterNameDrp.DataSource = qCenter;
                CenterNameDrp.DisplayMember = "CenterName";
                CenterNameDrp.ValueMember = "Id";
                CenterNameDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                CenterNameDrp.SelectedIndex = -1;
            }
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            string det = "";

            if (MonthDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر الشهر");
                MonthDrp.Focus();
                return;
            }
            if (YearTxt.Text.Length != 4)
            {
                MessageBox.Show("ادخل السنة");
                YearTxt.Focus();
                return;
            }
           // int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);


            var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y && p.ClmMasterData.IsReviewed ==1  ).GroupBy(s => new { s.ClmMasterData .ReviewDocId  }).Select(p => new
            {
                UserId = p.Key.ReviewDocId,
              UserName =db.Users.Where (s=> s.Id == p.Key .ReviewDocId).Select (s=> s.FullName ).FirstOrDefault (),
                ReviewCount = p.Select (s=> s.MasterId ).Distinct ().Count (),
                CenterId = p.Select(s=> s.ClmMasterData.CenterId).FirstOrDefault (),
                NonConfirm = p.Sum(s => s.NonConfClaims) + p.Sum(s => s.NonConfItem) + p.Sum(s => s.NonConfVisit)
            }).ToList();
            UserReviewReport rep = new UserReviewReport();
            det = "تقرير مراجعة الاطباء لشهر" + MonthDrp.Text + " لسنة  " + YearTxt.Text;
            if (CenterNameDrp .SelectedIndex >0)
            {
                int Cntrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId == Cntrid).ToList();
                det = det + " لصيدلية  " + CenterNameDrp.Text;
            }
            if (DocNameList.SelectedIndex > 0)
            {
                int Docid = int.Parse(DocNameList.SelectedValue.ToString());
                q = q.Where(p => p.UserId  == Docid).ToList();
                det = det + " للمستخدم " + DocNameList.Text;
            }

            rep.Det.Value = det;
            rep.DataSource = q;
            reportViewer1.ReportSource = rep;
            reportViewer1.RefreshReport();
        }

    }
}

