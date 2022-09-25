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
    public partial class ViewCenterNonConfirmFrm : Telerik.WinControls.UI.RadForm
    {
        public ViewCenterNonConfirmFrm()
        {
            InitializeComponent();
        }

        private void ViewCenterNonConfirmFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p=> p.HasContract == true && p.IsEnabled== true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
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
            if (CenterNameDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر المركز");
                CenterNameDrp.Focus();
                return;
            }

            if (MonthDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر الشهر");
                MonthDrp.Focus();
                return;
            }
            if (YearTxt.Text.Length !=4)
            {
                MessageBox.Show("ادخل السنة");
                YearTxt.Focus();
                return;
            }
            int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);

            var q = db.ClmNonConfirmDet.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.CenterId == _CenterId && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).GroupBy(s => s.ClmNonConfirmType.Name).Select(p => new
            {
                NonConfimName = p.Key,
                CountNonConfirm = p.Select(t => t.Id).Count(),
                TolalNonConfirm = p.Sum(t => t.Value)
            }).ToList();
            if (q.Count >0)
            {
                CenterNonConfirmRep rep = new CenterNonConfirmRep();
                rep.DataSource = q;
                var getDet = db.ClmDetailsData.Where(p => p.ClmMasterData.Years == _y && p.ClmMasterData.Months == _m && p.ClmMasterData.CenterId == _CenterId && p.RowStatus != RowStatus.Deleted).ToList();
                rep.CenterNameDet.Value ="تقرير المخالفة لمركز "+ getDet[0].ClmMasterData.CenterInfo.CenterName;
                rep.CenterName.Value = getDet[0].ClmMasterData.CenterInfo.CenterName;
                rep.TotalCount.Value  = getDet.Select(s => s.MasterId).Distinct().Count().ToString ();
                rep.TotalNonVisit.Value  = db.ClmNonConfirmDet.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.CenterId == _CenterId && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).Select(p => p.MasterId).Distinct().Count().ToString();
                rep.ClaimsDate.Value = "شهر " + getDet[0].ClmMasterData.Months + " لسنة " + getDet[0].ClmMasterData.Years;
                rep.WriteTotal.Value = PLC.NumToStr(Convert.ToDouble((q.Sum(s => s.TolalNonConfirm))));
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();

            }
        }
    }
}
