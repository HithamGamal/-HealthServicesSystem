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
    public partial class ViewCenterListNonConfirmRepFrm : Telerik.WinControls.UI.RadForm
    {
        public ViewCenterListNonConfirmRepFrm()
        {
            InitializeComponent();
        }

        private void ViewCenterListNonConfirmRepFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p=> p.IsEnabled == true && p.HasContract==true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
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

            var q = db.ClmDetailsData .Where(p => p.RowStatus != RowStatus.Deleted  && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).GroupBy(s => new { s.ClmMasterData.CenterInfo.CenterName , s.ClmMasterData.CenterId  }).Select(p => new
            {
                CenterName = p.Key.CenterName,
                CenterId = p.Key.CenterId,
                TotalClaims = p.Sum (s=> s.TotalPrice ),
                TotalNon= p.Sum (s=> s.NonConfClaims)+ p.Sum(s => s.NonConfItem)+ p.Sum(s => s.NonConfVisit),
                NetClaims = p.Sum(s => s.TotalPrice)- (p.Sum(s => s.NonConfClaims) + p.Sum(s => s.NonConfItem) + p.Sum(s => s.NonConfVisit))
            }).Where (p=> p.TotalNon>0).ToList();

            if (CenterNameDrp.SelectedIndex != -1)
            {
                int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId == _CenterId).ToList();
            }
            if (q.Count > 0)
            {
                CenterListNonConfirmReport rep = new CenterListNonConfirmReport();
                rep.DataSource = q;
             
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();

            }
        }
    }
}
