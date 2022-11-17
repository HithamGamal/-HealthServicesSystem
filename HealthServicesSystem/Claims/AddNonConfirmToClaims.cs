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
        public int _NonConId = 0;
        public decimal _NonPercent = 0;
        public int _NonType = 0;
        public int _DicountType = 0;
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

        private void AddNonBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            ////if (Convert.ToDecimal(ValueTxt.Text) > 0)
            ////{
            ////    
            ////    int _impid = int.Parse(ImpDrp.SelectedValue.ToString());
            ////    var GetImpDet = db.ClmImpFile.Where(p => p.Id == _impid).ToList();
            ////   
            //// 
            ////    int _m = GetImpDet[0].Month;
            ////    int _y = GetImpDet[0].year;
            ////    int _CenterId = GetImpDet[0].CenterId;

            ////    decimal _NonVlaue = 0;

            //int _visitId = 0;
            //int _NonConfID = int.Parse(NonConfirmDrp.SelectedValue.ToString());
            //for (int i = 0; i < radGridView1 .RowCount ; i++)
            //{

            
            //int _idDet = int.Parse(radGridView1 .Rows [i].Cells["Id"].Value .ToString ());

            //decimal ItemTotalPrice = db.ClmDetailsData.Where(p => p.Id == _idDet).Select(p => p.TotalPrice).FirstOrDefault();

            //    var GetNonConInfo = db.ClmNonConfirmType.Where(p => p.Id == _NonConfID).Take(1).ToList();
            //    _visitId= db.ClmDetailsData.Where(p => p.Id == _idDet).Select(p => p.MasterId).FirstOrDefault();

            //    var q = db.ClmNonConfirmDet.Where(p => p.DetailsId == _idDet && p.RowStatus != RowStatus.Deleted).ToList();
            //    if (q.Count > 0)
            //    {
            //        DialogResult d = MessageBox.Show("هل تريد ادراج مخالفة مرة اخرى ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (d == DialogResult.No)
            //        {
            //            return;
            //        }
            //    }
            //    ClmNonConfirmDet c = new ClmNonConfirmDet();
            //    c.MasterId = _visitId ;
            //    c.DateIn = PLC.getdatetime();
            //    if (_DicountType == 0)
            //    {
            //        c.DetailsId = _idDet;
            //        _NonVlaue = (ItemTotalPrice * _NonPercent) / 100;
            //        var UpNon = db.ClmDetailsData.Where(p => p.Id == _idDet).ToList();
            //        if (UpNon.Count > 0)
            //        {
            //            UpNon[0].NonConfItem = UpNon[0].NonConfItem + _NonVlaue;
            //        }
            //        if (GetNonConInfo[0].ValueType == ModelDB.ValueType.Percent)
            //        {
            //            c.Value = _NonVlaue;
            //        }
            //        else
            //        {
            //            c.Value = Convert.ToDecimal(Discounttxt.Text);
            //        }

            //    }
            //    else if (_DicountType == 1)
            //    {

            //        var UpNon = db.ClmDetailsData.Where(p => p.MasterId == _visitId && p.RowStatus != RowStatus.Deleted).ToList();
            //        if (UpNon.Count > 0)
            //        {
            //            foreach (var item in UpNon)
            //            {
            //                _NonVlaue = (item.TotalPrice * _NonPercent) / 100;
            //                item.NonConfVisit = item.NonConfVisit + _NonVlaue;

            //            }
            //            if (GetNonConInfo[0].ValueType == ModelDB.ValueType.Percent)
            //            {
            //                c.Value = (db.ClmDetailsData.Where(p => p.MasterId == _visitId && p.RowStatus != RowStatus.Deleted).Sum(p => p.TotalPrice) * _NonPercent) / 100;
            //            }
            //            else
            //            {
            //                c.Value = Convert.ToDecimal(Discounttxt.Text);
            //            }

            //        }
            //        c.DetailsId = 0;
            //    }
            //    else if (_DicountType == 2)
            //    {

            //        var UpNon = db.ClmDetailsData.Where(p => p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y && p.ClmMasterData.CenterId == _CenterId && p.RowStatus != RowStatus.Deleted).ToList();
            //        if (UpNon.Count > 0)
            //        {
            //            foreach (var item in UpNon)
            //            {
            //                _NonVlaue = (item.TotalPrice * _NonPercent) / 100;
            //                item.NonConfClaims = item.NonConfClaims + _NonVlaue;

            //            }
            //            if (GetNonConInfo[0].ValueType == ModelDB.ValueType.Percent)
            //            {
            //                c.Value = (db.ClmDetailsData.Where(p => p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y && p.ClmMasterData.CenterId == _CenterId && p.RowStatus != RowStatus.Deleted).Sum(p => p.TotalPrice) * _NonPercent) / 100;
            //            }
            //            else
            //            {
            //                c.Value = Convert.ToDecimal(Discounttxt.Text);
            //            }


            //        }
            //        c.DetailsId = 0;

            //    }


            //    c.Percent = _NonPercent;
            //    c.NonConfirmId = _NonConfID;
            //    c.RowStatus = RowStatus.NewRow;
            //    c.Status = Status.Active;
            //    c.UserId = _UserId;
            //    db.ClmNonConfirmDet.Add(c);
            //    if (db.SaveChanges() > 0)
            //    {

            //        MessageBox.Show("تمت اضافة مخالفة");
            //        NonConfirmDrp.SelectedIndex = -1;
            //        GetNonConfirm();
            //    }


            //}
        }

        private void NonConfirmDrp_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    dbContext db = new dbContext();
            //    if (NonConfirmDrp.SelectedValue != null)
            //    {
            //        int _Id = int.Parse(NonConfirmDrp.SelectedValue.ToString());

            //        var q = db.ClmNonConfirmType.Where(p => p.Id == _Id && p.RowStatus != RowStatus.Deleted).Take(1).ToList();
            //        if (q.Count > 0)
            //        {
            //            _NonConId = q[0].Id;
            //            _NonPercent = q[0].Value;
            //            _NonType = ((int)q[0].ValueType);
            //            _DicountType = ((int)q[0].DicountType);
            //            if (q[0].ValueType == ModelDB.ValueType.Percent)
            //            {
            //                Discounttxt.Text = (Convert.ToDecimal(ValueTxt.Text) * q[0].Value / 100).ToString();
            //                Discounttxt.Enabled = false;
            //            }
            //            else
            //            {
            //                Discounttxt.Text = "0";
            //                Discounttxt.Enabled = true;
            //            }
            //            NetValue.Text = (Convert.ToDecimal(ValueTxt.Text) - Convert.ToDecimal(Discounttxt.Text)).ToString();
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }
    }
}
