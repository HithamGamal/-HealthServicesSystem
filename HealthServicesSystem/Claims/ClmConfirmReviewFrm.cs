using MedicalServiceSystem.SystemSetting;
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

namespace MedicalServiceSystem.Claims
{
    public partial class ClmConfirmReviewFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmConfirmReviewFrm()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        private void radLabel4_Click(object sender, EventArgs e)
        {

        }

        private void ClmConfirmReviewFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var q = db.CenterInfos.Where(p => p.IsEnabled  == true && p.HasContract== true  ).Select(p => new { Id = p.Id, CenterName = p.CenterName }).ToList();
            if (q.Count > 0)
            {
                CenterName.DataSource = q;
                CenterName.DisplayMember = "CenterName";
                CenterName.ValueMember = "Id";
                CenterName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                CenterName.SelectedIndex = -1;
            }
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MonthDrp .SelectedIndex ==-1)
                {
                    MessageBox.Show("اختر الشهر");
                    return;
                }
                if (CenterName .SelectedIndex == -1)
                {
                    MessageBox.Show("اختر المركز");
                    return;
                }
                if (YearTxt .Text .Length !=4)
                {
                    MessageBox.Show("ادخل السنة بصورة صحيحة ");
                    return;
                }
                dbContext db = new dbContext();
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                int _CenterId = int.Parse(CenterName.SelectedValue.ToString());
                var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.Years == _y && p.ClmMasterData.Months == _m && p.ClmMasterData.CenterId == _CenterId).ToList();
                if (q.Count >0)
                {
                 NotReviewTxt .Text =   q.Where(s => s.ClmMasterData.IsReviewed == 0).Select (s=>s.MasterId ).Distinct().Count().ToString ();
                    VisitNoTxt.Text = q.Select(s => s.MasterId).Distinct().Count().ToString() ;
                    FilesNotxt.Text = q.Select(s => s.ClmMasterData.FileNo).Distinct().Count().ToString();
                    ItemNoTxt.Text = q.Count().ToString();
                    TotalClaimsTxt.Text = q.Sum(s => s.TotalPrice).ToString();
                    ErrorCostTxt.Text = q.Sum (s =>   (s.NonConfItem + s.NonConfVisit + s.NonConfClaims) ).ToString();
                    NetClaimsTxt .Text = q.Sum (s =>   s.TotalPrice - (s.NonConfItem + s.NonConfVisit + s.NonConfClaims) ).ToString();
                    ClamsStatusTxt .Text = db.ClmImpFile.Where(p => p.CenterId == _CenterId && p.year == _y && p.Month == _m).Select (p=> p.ClmStatus ).FirstOrDefault().ToString ();

                }
                else
                {
                    MessageBox.Show("لاتوجد مطالبة لهذا المركز ");
                    return;
                }
            }
            catch
            {

            }

        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);
            int _CenterId = int.Parse(CenterName.SelectedValue.ToString());
            dbContext db = new dbContext();
            var q = db.ClmImpFile.Where(p => p.CenterId == _CenterId && p.year == _y && p.Month == _m && p.RowStatus!= RowStatus.Deleted && p.ClmStatus== ClmStatus.Review).ToList();
            if (q.Count >0)
            {
                var Chreview = db.ClmMasterData.Where(p => p.CenterId == _CenterId && p.Years == _y && p.Months == _m && p.IsReviewed == 0 && p.RowStatus != RowStatus.Deleted).ToList();
                if (Chreview .Count >0)
                {
                    MessageBox.Show("توجد رشتات غير مراجعة ");
                    return;
                }
                DialogResult d = MessageBox.Show("هل تريد اعتماد المطالبة مركز" + CenterName .Text +" لشهر  "+ MonthDrp .Text +"  لسنة  "  +YearTxt .Text, "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
                foreach (var item in q)
                {
                    item.CompleteDate = PLC.getdatetime();
                    item.CompleteId = _UserId;
                    item.ClmStatus = ClmStatus.Complete;
                }
                if (db.SaveChanges()>0)
                {
                    MessageBox.Show("تم اعتماد المطالبة");
                }
            }
        }
    }
}
