
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace MedicalServiceSystem.Claims
{
    public partial class AdvanceFillterFrm : Telerik.WinControls.UI.RadForm
    {
        public AdvanceFillterFrm()
        {
            InitializeComponent();
        }

        private void AdvanceFillterFrm_Load(object sender, EventArgs e)
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

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            radGridView1.DataSource = null;
            dbContext db = new dbContext();
          

            if (FMonthDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر الشهر");
                FMonthDrp.Focus();
                return;
            }
            if (FYearTxt.Text.Length != 4)
            {
                MessageBox.Show("ادخل السنة");
                FYearTxt.Focus();
                return;
            }
            if (LMonthDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر الشهر");
                LMonthDrp.Focus();
                return;
            }
            if (LYearTxt.Text.Length != 4)
            {
                MessageBox.Show("ادخل السنة");
                LYearTxt.Focus();
                return;
            }
          
            int _Fm = FMonthDrp.SelectedIndex + 1;
            int _Fy = int.Parse(FYearTxt.Text);
            int _Lm = FMonthDrp.SelectedIndex + 1;
            int _Ly = int.Parse(FYearTxt.Text);
            DateTime fDate = new DateTime(_Fy, _Fm, 01);
            DateTime LDate = new DateTime(_Ly, _Lm, 01);
            var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && DbFunctions.CreateDateTime (p.ClmMasterData.Years, p.ClmMasterData.Months, 01 ,0,0,00)>= fDate  && DbFunctions.CreateDateTime(p.ClmMasterData.Years, p.ClmMasterData.Months, 01, 0, 0, 00) <= LDate).Select(p => new
            {
                CenterName = p.ClmMasterData.CenterInfo.CenterName,
                FileNo = p.ClmMasterData.FileNo,
                PatName = p.ClmMasterData.PatName,
                InsuranceNo = p.ClmMasterData.InsuranceNo ,
                CleintNo = p.ClmMasterData.CleintId,
                VisitDate= p.ClmMasterData.VisitDate ,
                VisitType = p.ClmMasterData.ClmContractType.ContractName,
                Daignosis= p.ClmMasterData.Diagnosis.DiagnosisName ,
                GenericName = p.Medicine.Generic_name ,
               TradeName = p.TradeName,
               Qty= p.Qty,
               UnitPrice= p.UnitPrice,
               TotalPrice = p.TotalPrice ,
               CenterId = p.ClmMasterData.CenterId ,
               Month = p.ClmMasterData.Months,
               Year= p.ClmMasterData.Years


            }).ToList();
            if (CenterNameDrp .SelectedIndex != -1)
            {
                int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId == _CenterId).ToList();
            }
            radGridView1.DataSource = q;
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            radGridView1.PrintPreview();
        }

        private void ExpBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog  s = new SaveFileDialog ();
           
            s.ShowDialog();
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
            spreadExporter.RunExport(s.FileName+ ".xlsx", exportRenderer);
        }
    }
}
