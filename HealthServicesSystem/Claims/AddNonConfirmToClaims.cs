using HealthServicesSystem.SystemSetting;
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
    public partial class AddNonConfirmToClaims : Telerik.WinControls.UI.RadForm
    {
        public AddNonConfirmToClaims()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        private void radLabel13_Click(object sender, EventArgs e)
        {

        }

        private void NonConfirmDrp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddNonConfirmToClaims_Load(object sender, EventArgs e)
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

            var qMed = db.Medicines.Select(p => new { Id = p.Id, Generic_name =  p.Generic_name }).ToList();
            if (qCenter.Count > 0)
            {
                ItemName .DataSource = qMed;
                ItemName.DisplayMember = "Generic_name";
                ItemName.ValueMember = "Id";
                ItemName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ItemName.SelectedIndex = -1;
            }

            var qNon = db.ClmErrorType.Select(p => new { Id = p.Id, NonName = p.ErrorName }).ToList();
            if (qCenter.Count > 0)
            {
                NonConfirmDrp.DataSource = qMed;
                NonConfirmDrp.DisplayMember = "NonName";
                NonConfirmDrp.ValueMember = "Id";
                NonConfirmDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                NonConfirmDrp.SelectedIndex = -1;
            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            if (CenterNameDrp.SelectedIndex != -1)
            {
                MessageBox.Show("يجب اختيار المركز");
                return;
            }
            if (MonthDrp.SelectedIndex != -1)
            {
                MessageBox.Show("يجب اختيار الشهر");
                return;
            }
            if (MonthDrp.SelectedIndex != -1)
            {
                MessageBox.Show("يجب اختيار الشهر");
                return;
            }
            if (ItemName.SelectedIndex != -1)
            {
                MessageBox.Show("يجب اختيار الصنف");
                return;
            }
            if (ItemName.SelectedIndex != -1)
            {
                MessageBox.Show("يجب اختيار الصنف");
                return;
            }
            int _Centrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
            int _Month = MonthDrp.SelectedIndex + 1;
            int _year = int.Parse(YearTxt.Text);
            int _GenId = int.Parse(ItemName.SelectedValue.ToString());
            var q = db.ClmDetailsData.Where(p => p.ClmMasterData.CenterId == _Centrid && p.ClmMasterData.Months == _Month && p.ClmMasterData.Years == _year).Select(
                p => new
                {
                    Id = p.Id ,
                    ItemName = p.Medicine.GenericId,
                    Cost = p.TotalPrice,
                    Name = p.ClmMasterData .PatName 
                    
                }).ToList();
        }
    }
}
