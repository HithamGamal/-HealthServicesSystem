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
    public partial class NonConfirmFiltterFrm : Telerik.WinControls.UI.RadForm
    {
        public NonConfirmFiltterFrm()
        {
            InitializeComponent();
        }

        private void NonConfirmFiltterFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p=> p.IsEnabled == true && p.HasContract == true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
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
            // var q = db.Database.SqlQuery<dbContext>("SELECT  dbo.ClmNonConfirmTypes.Id, dbo.ClmNonConfirmTypes.Name, dbo.ClmNonConfirmDets.MasterId, dbo.ClmNonConfirmTypes.ValueType, dbo.ClmNonConfirmTypes.DicountType, dbo.ClmDetailsDatas.GenericId, dbo.ClmDetailsDatas.TradeName, dbo.Medicines.Generic_name, dbo.CenterInfoes.CenterName, dbo.ClmNonConfirmDets.Value AS NonValue FROM    dbo.CenterInfoes INNER JOIN  dbo.ClmNonConfirmDets INNER JOIN  dbo.ClmMasterDatas ON dbo.ClmNonConfirmDets.MasterId = dbo.ClmMasterDatas.Id INNER JOIN  dbo.ClmNonConfirmTypes ON dbo.ClmNonConfirmDets.NonConfirmId = dbo.ClmNonConfirmTypes.Id ON dbo.CenterInfoes.Id = dbo.ClmMasterDatas.CenterId LEFT OUTER JOIN   dbo.Medicines INNER JOIN  dbo.ClmDetailsDatas ON dbo.Medicines.Id = dbo.ClmDetailsDatas.GenericId ON dbo.ClmNonConfirmDets.DetailsId = dbo.ClmDetailsDatas.Id").ToList ();

            var q = db.ClmNonConfirmDet.Where (p=> p.RowStatus != RowStatus.Deleted &&  p .ClmMasterData .RowStatus != RowStatus.Deleted && DbFunctions.CreateDateTime(p.ClmMasterData.Years, p.ClmMasterData.Months, 01, 0, 0, 00) >= fDate && DbFunctions.CreateDateTime(p.ClmMasterData.Years, p.ClmMasterData.Months, 01, 0, 0, 00) <= LDate).
                Select(p => new { CenterName = p.ClmMasterData.CenterInfo.CenterName, 
                    NonConfirmName = p.ClmNonConfirmType.Name, 
                    ValueType = p.ClmNonConfirmType.ValueType,
                    Value = p.ClmNonConfirmType.Value,
                    MastrId = p.ClmMasterData.Id, CenterId = p.ClmMasterData.CenterId,
                    DiscountType = p.ClmNonConfirmType.DicountType, 
                    Price = p.Value,
                    Month= p.ClmMasterData.Months,
                    VisitType= p.ClmMasterData.ClmContractType .ContractName,
                    Daignosis= p.ClmMasterData.Diagnosis.DiagnosisName,
                    Year = p.ClmMasterData.Years,
                    GenericName = p.DetailsId != null ? db.ClmDetailsData.Where(d => d.Id == p.DetailsId).Select(d => d.Medicine.Generic_name).FirstOrDefault() : null, 
                    TradeName = p.DetailsId != null ? db.ClmDetailsData.Where(d => d.Id == p.DetailsId).Select(d => d.TradeName).FirstOrDefault() : null }).ToList();
            if (CenterNameDrp.SelectedIndex != -1)
            {
                int _CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                q = q.Where(p => p.CenterId==_CenterId).ToList();
            }
            radGridView1.DataSource = q;
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            radGridView1.PrintPreview();
        }

        private void ExpBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();

            s.ShowDialog();
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
            spreadExporter.RunExport(s.FileName + ".xlsx", exportRenderer);
        }
    }
}
