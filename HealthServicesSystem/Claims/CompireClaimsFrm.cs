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
            MasterGrd.DataSource = null;
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
                var GetNatq= q.Where(p => p.InsuranceNo.Length == 11 && !p.InsuranceNo .Contains("/") &&( p.InsuranceNo.StartsWith("4") || p.InsuranceNo.StartsWith("5")|| p.InsuranceNo.StartsWith("6"))).Select(p => new
                {
                    InsNo = p.InsuranceNo,
                    No = p.InsuranceNo.Substring(0,2)

                }).ToList();
                TotalNationalTxt.Text = GetNatq.Count().ToString();
                CountOldTxt.Text = q.Where(p => p.InsuranceNo.ToString().Contains("/")).Count().ToString();
                TotalNewCardTxt.Text  = q.Where(p => p.InsuranceNo.Length == 9 && p.InsuranceNo.StartsWith("10")).Count().ToString();
                TotalCurrectTxt.Text = (int.Parse(TotalNationalTxt.Text) + int.Parse(CountOldTxt.Text) + int.Parse(TotalNewCardTxt.Text)).ToString();
                TotalNonTxt.Text = (int.Parse(TotalCountTxt.Text) - int.Parse(TotalCurrectTxt.Text)).ToString();
               decimal Per =  ((Convert.ToDecimal(TotalNonTxt.Text) / Convert.ToDecimal(TotalCountTxt.Text)*100) );
                PersentTxt.Text =Math.Round ( Per,2).ToString();
                // fill 

                var ErrorQ = q.Where(p => !(p.InsuranceNo.Length == 9 && p.InsuranceNo.StartsWith("10"))).ToList();
                var ErrorQ2 = ErrorQ. Where  (p=>! ( p.InsuranceNo.Length == 11 && (p.InsuranceNo.StartsWith ("4")|| p.InsuranceNo.StartsWith("5") || p.InsuranceNo.StartsWith("6") ))).Select(

                    p => new
                    {

                        Id= p.Id,
                        InsuranceNo= p.InsuranceNo ,
                        PatName = p.PatName,
                        
                        Age= p.Age ,
                        Types=p.ContractId


                    }).ToList();
                if (ErrorQ2 .Count>0)
                {
                    MasterGrd.DataSource = ErrorQ2;
                }

            }

        }
    }
}
