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
    public partial class CheckClaimsFrm : Telerik.WinControls.UI.RadForm
    {
        public CheckClaimsFrm()
        {
            InitializeComponent();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void CheckClaimsFrm_Load(object sender, EventArgs e)
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
            var q = db.ClmTempDet.Where(p => p.ClmTempMaster.Months == _m && p.ClmTempMaster.Years == _y && p.ClmTempMaster.CenterId == _cntrId && (_FileNo == 0 || p.ClmTempMaster.FileNo == _FileNo)).GroupBy (p=> p.ClmTempMaster).Select (
          
               



                    p => new
                    {

                        Id = p.Key.Id,
                        FileNo= p.Key.FileNo ,
                        VisitNo = p.Key.VisitNo,
                        VisitDate= p.Key.VisitDate,
                        InsuranceNo = p.Key.InsuranceNo,
                        PatName = p.Key.PatName,

                        Age = p.Key.Age,
                        Types = db.ClmContractType.Where (s=> s.Id==p.Key.ContractId).Select (s=> s.ContractName).FirstOrDefault (),
                        ClaimPrice = p.Sum(s => s.ClaimPrice),
                        TotalPrice = p.Sum (s=> s.TotalPrice )


                    }).ToList();
            if (q.Count > 0)
            {
                MasterGrd.DataSource = q;
            }

        }

        private void MasterGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            dbContext db = new dbContext();
            if (MasterGrd.RowCount >0)
            {
                if(MasterGrd .CurrentColumn.Name == "View")
                {
                    int _id = int.Parse(MasterGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmTempDet.Where(p => p.MasterId == _id && p.RowStatus != RowStatus.Deleted).Select(

                        p => new
                        {
                            Id = p.Id,
                            GenericName = p.Medicine.Generic_name,
                            TradeName = p.TradeName,
                            Qty = p.Qty,
                            UnitPrice = p.UnitPrice,
                            TotalPrice = p.TotalPrice
                        }).ToList();
                    if (q.Count >0)
                    {
                        DetailsGrd.DataSource = q;
                    }
                }
            }
        }
    }
    
}
