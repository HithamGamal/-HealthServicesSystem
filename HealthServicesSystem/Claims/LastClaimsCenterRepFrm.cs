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
    public partial class LastClaimsCenterRepFrm : Telerik.WinControls.UI.RadForm
    {
        public LastClaimsCenterRepFrm()
        {
            InitializeComponent();
        }

        private void LastClaimsCenterRepFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p=> p.HasContract ==true && p.IsEnabled == true) .Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
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
            if (YearTxt.Text.Length != 4)
            {
                MessageBox.Show("ادخل السنة");
                YearTxt.Focus();
                return;
            }
            int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
            int _m = MonthDrp.SelectedIndex + 1;
            int _y = int.Parse(YearTxt.Text);


            var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y).GroupBy(s => new { s.ClmMasterData.CenterInfo.CenterName, s.ClmMasterData.CenterId }).Select(p => new
            {
                CenterName = p.Key.CenterName,
                CenterId = p.Key.CenterId,
                TotalClaims = p.Sum(s => s.TotalPrice),
                TotalNon = p.Sum(s => s.NonConfClaims) + p.Sum(s => s.NonConfItem) + p.Sum(s => s.NonConfVisit),
                NetClaims = p.Sum(s => s.TotalPrice) - (p.Sum(s => s.NonConfClaims) + p.Sum(s => s.NonConfItem) + p.Sum(s => s.NonConfVisit))
            }).ToList();
            LastCenterClaimsReport rep = new LastCenterClaimsReport();
                //rep.DataSource = q;
                rep.CenterNameDet.Value = q[0].CenterName;
                rep.CenterName.Value = q[0].CenterName;
            rep.MedPrice.Value = q[0].TotalClaims.ToString ();
            rep.TotalNon.Value = q[0].TotalNon.ToString();
            rep.NetClaims.Value = q[0].NetClaims.ToString();
            rep.NonPrice.Value = q[0].TotalNon.ToString();
            rep.TotalClaims.Value = q[0].TotalClaims.ToString();

                rep.ClmDate .Value = "" + MonthDrp .Text  + "  " + YearTxt.Text;
        
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();
         }

             
         
    }
}
