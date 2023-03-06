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
    public partial class CenterListClaimsRepFrm : Telerik.WinControls.UI.RadForm
    {
        public CenterListClaimsRepFrm()
        {
            InitializeComponent();
        }

        private void CenterListClaimsRepFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p => p.IsEnabled == true && p.HasContract == true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
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

            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);

            var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).GroupBy(s => new { s.ClmMasterData.CenterInfo.CenterName, s.ClmMasterData.CenterId }).Select(p => new
            {
                CenterName = p.Key.CenterName,
                CenterId = p.Key.CenterId,
                ClaimPrice = p.Sum(s => s.ClaimPrice),
     TotalPrice= p.Sum (s=> s.TotalPrice )
            }).ToList();

            if (CenterNameDrp.SelectedIndex != -1)
            {
                int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId == _CenterId).ToList();
            }
            if (q.Count > 0)
            {
                CenterListClaims rep = new CenterListClaims();
                rep.DataSource = q;
                rep.Det.Value = "تقرير قيمة المطالبة  لشهر " + MonthDrp.Text + " لسنة " + YearTxt.Text;
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();

            }
        }

        private void ViewItemBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();


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

            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);

            var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).GroupBy(s => new { s.Medicine .Generic_name, s.GenericId }).Select(p => new
            {
                ItemName = p.Key.Generic_name,
                Id = p.Key.GenericId,
                CenterId = p.Select (s=> s.ClmMasterData .CenterId).FirstOrDefault (),
                ClaimPrice = p.Sum(s => s.ClaimPrice),
                TotalPrice = p.Sum(s => s.TotalPrice),
                Qty=p.Sum (s=> s.Qty)
               

            }).ToList();

            if (CenterNameDrp.SelectedIndex != -1)
            {
                int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId == _CenterId).ToList();
            }
            if (q.Count > 0)
            {
                
                ItemListClaims rep = new ItemListClaims();
                rep.DataSource = q;
              rep.Total .Value  = q.Sum(s => s.ClaimPrice).ToString();
             
                rep.Det.Value = "تقرير قيمة المطالبة  لشهر " + MonthDrp.Text + " لسنة " + YearTxt.Text;
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();

            }
        }
    }
    
}
