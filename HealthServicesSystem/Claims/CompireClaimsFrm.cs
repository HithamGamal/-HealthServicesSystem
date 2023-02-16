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
    public partial class CompireClaimsFrm : Telerik.WinControls.UI.RadForm
    {
        public CompireClaimsFrm()
        {
            InitializeComponent();
        }

        private void CompireClaimsFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
            if (qCenter.Count > 0)
            {
                CenterNameDrp.DataSource = qCenter;
                CenterNameDrp.DisplayMember = "CenterName";
                CenterNameDrp.ValueMember = "Id";
                CenterNameDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                CenterNameDrp.SelectedIndex = -1;
            }
        }

        private void OfdBtn_Click(object sender, EventArgs e)
        {
            int _m = FMonthDrp.SelectedIndex + 1;
            int _y = int.Parse(FYearTxt.Text);
            int _cntrId = int.Parse(CenterNameDrp.SelectedValue.ToString());
            int _FileNo = 0;
            if (FileNoTxt.Text.Trim().Length > 0)
            {
                _FileNo = int.Parse(FileNoTxt.Text);
            }
            dbContext db = new dbContext();
            var q = db.ClmTempMaster.Where(p => p.Months == _m && p.Years == _y && p.CenterId == _cntrId && (_FileNo == 0 || p.FileNo == _FileNo)).ToList();
            if (q.Count>0)
            {
                TotalCountTxt.Text = q.Count().ToString ();
                var GetNatq= q.Where(p => p.InsuranceNo.Length == 11).Select(p => new
                {
                    InsNo = p.InsuranceNo,
                    No =Convert.ToInt32( p.InsuranceNo.Substring(0, 2))

                }).Where(p => p.No >= 40 && p.No <= 60).ToList();
                TotalNationalTxt.Text = GetNatq.Count().ToString();
                CountOldTxt.Text = q.Where(p => p.InsuranceNo.ToString().Contains("/")).Count().ToString();

            }
        }
    }
}
