using MedicalServiceSystem.SystemSetting;
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
    public partial class ClmReviewFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmReviewFrm()
        {
            InitializeComponent();
        }
        public int _NonConId = 0;
        public decimal _NonPercent = 0;
        public int _NonType = 0;
        public int _DicountType = 0;
        public int _UserId = LoginForm.Default.UserId;

        public void GetNonConfirm()
        {
            NonConfrmGrd.DataSource = null;
            dbContext db = new dbContext();
            int MstrId = int.Parse(VisitIdTxt.Text);
            var qNon = db.ClmNonConfirmDet.Where(p => p.RowStatus != RowStatus.Deleted && p.MasterId == MstrId).Select(p => new
            {
                Id = p.Id,
                NonConfName = p.ClmNonConfirmType.Name,
                DiscountType = p.ClmNonConfirmType.DicountType,
                DiscountValue = p.Value,
                Percent = p.Percent,
                DiscountPer = p.ClmNonConfirmType.DicountType,
            }).ToList();
            if (qNon.Count > 0)
            {
                NonConfrmGrd.DataSource = qNon;
            }
        }

        //=========================================== histiry
        public void GetHistory()
        {
            try
            {
                string  _insNo = InsuranceNoTxt.Text;
                dbContext db = new dbContext();
                var q = db.ReclaimMedicines.Where(p => p.Reclaim.InsurNo == _insNo && p.RowStatus != RowStatus.Deleted).Select(p => new
                {
                    CenterName = db.ReclaimMedicineReasonsLists.Where(c => c.Id == p.Reclaim.ReclaimMedicalResonId).Select(c => c.MedicineReason).FirstOrDefault(),
                    Month = p.Reclaim.ReclaimDate.Month,
                    Year = p.Reclaim.ReclaimDate.Year,
                    VisitDate = p.Reclaim.ReclaimDate,
                    GenericName = p.MedicineForReclaim.Generic_name,
                    ProcessName = "استرداد"

                }).ToList();

                //ReClaims
                double InsNo1 = Convert.ToDouble(InsuranceNoTxt.Text);
                var q1 = db.ClmDetailsData.Where(p => p.ClmMasterData.InsuranceNo ==InsNo1 && p.RowStatus != RowStatus.Deleted).Select(p => new
                {
                    CenterName = p.ClmMasterData.CenterInfo.CenterName,
                    Month = p.ClmMasterData.Months,
                    Year = p.ClmMasterData.Years,
                    VisitDate = p.ClmMasterData.VisitDate,
                    GenericName = p.Medicine.Generic_name,
                    ProcessName = "مطالبة"

                }).ToList();
                q.Union(q1);
                HistoryGrd.DataSource = q;
            }
            catch
            {

            }
        }
        //================================================
        public void GetStatistic()
        {
            try
            {
                int _impId = int.Parse(ImpNoTxt.Text);
                dbContext db = new dbContext();

                var GetImpDet = db.ClmImpFile.Where(p => p.Id == _impId).ToList();

                int _m = GetImpDet[0].Month;
                int _y = GetImpDet[0].year;
                int _CenterId = GetImpDet[0].CenterId;
                int _mNow = PLC.getMonth();
                int _yNow = PLC.getyear();
                int _dNow = PLC.getdate().Day;
                InMonthLb.Text = db.ClmMasterData.Where(p => p.RowStatus != RowStatus.Deleted && p.IsReviewed == 1 && p.ReviewDocId == _UserId && p.ReviewDate.Value.Month == _mNow && p.ReviewDate.Value.Year == _yNow).Count().ToString();
                InDayLb.Text = db.ClmMasterData.Where(p => p.RowStatus != RowStatus.Deleted && p.IsReviewed == 1 && p.ReviewDocId == _UserId && p.ReviewDate.Value.Month == _mNow && p.ReviewDate.Value.Year == _yNow && p.ReviewDate.Value.Day == _dNow).Count().ToString();
                InClaimsLb.Text = db.ClmMasterData.Where(p => p.RowStatus != RowStatus.Deleted && p.IsReviewed == 1 && p.ReviewDocId == _UserId && p.Months == _m && p.Years == _y && p.CenterId == _CenterId).Count().ToString();
            }
            catch
            {

            }
        }
        private void ClmReviewFrm_Load(object sender, EventArgs e)
        {
            GetStatistic();
            VisitIdTxt.Clear();
            PatNameTxt.Text = "";
            InsuranceNoTxt.Text = "";
            AgeTxt.Text = "";
            VisitDateTxt.Text = "";
            IdClmLb.Text ="";
            dbContext db = new dbContext();
            var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted ).Select(p => new { ImpId = p.Id, CenterName = p.Id+" "+ p.CenterInfo.CenterName }).ToList();
            if (q.Count >0)
            {
                ImpDrp.DataSource = q;
                ImpDrp.DisplayMember = "CenterName";
                ImpDrp.ValueMember = "ImpId";
                ImpDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ImpDrp.SelectedIndex = -1;
            }
            var qnon = db.ClmNonConfirmType.Where(p => p.RowStatus != RowStatus.Deleted).Select(p => new { Id = p.Id, Name = p.Name  ,Value = p.Value ,ValueType = p.ValueType }).ToList();
            if (qnon.Count > 0)
            {
                NonConfirmDrp.DataSource = qnon;
                NonConfirmDrp.DisplayMember = "Name";
                NonConfirmDrp.ValueMember = "Id";
                NonConfirmDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                NonConfirmDrp.SelectedIndex = -1;
            }


        }

        private void ImpDrp_SelectedValueChanged(object sender, EventArgs e)
        {
          
        }

        private void ImpNoTxt_TextChanged(object sender, EventArgs e)
        {

            VisitIdTxt.Clear();
            PatNameTxt.Text = "";
            InsuranceNoTxt.Text = "";
            AgeTxt.Text = "";
            IdClmLb.Text = "";
            VisitDateTxt.Text = "";
            dbContext db = new dbContext();
            int _impId = int.Parse(ImpNoTxt.Text);
            ClaimsCostTxt.Text = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ClmMasterData.ImpId == _impId).Sum(p => p.TotalPrice).ToString();
            var qm = db.ClmMasterData.Where(p => p.ImpId == _impId && p.RowStatus != RowStatus.Deleted && p.IsReviewed == 0).OrderBy(p => p.NoOfFile).Take(1).ToList();
            if (qm.Count > 0)
            {
                VisitIdTxt.Text = qm[0].Id.ToString();
            }
        }

        private void VisitIdTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
              
                PatNameTxt.Text = "";
                InsuranceNoTxt.Text = "";
                AgeTxt.Text = "";
                VisitDateTxt.Text = "";
                NonConfrmGrd.DataSource = null;
                ItemGrd.DataSource = null;
                IdClmLb.Text = "";
                int MstrId = int.Parse(VisitIdTxt.Text);
                dbContext db = new dbContext();

                var qm = db.ClmMasterData.Where(p => p.Id  == MstrId  && p.RowStatus != RowStatus.Deleted && p.IsReviewed == 0).OrderBy(p => p.NoOfFile).Take(1).ToList();
                if (qm.Count > 0)
                {
                    VisitIdTxt.Text = qm[0].Id.ToString();
                    PatNameTxt.Text = qm[0].PatName;
                    InsuranceNoTxt.Text = qm[0].InsuranceNo.ToString();
                    AgeTxt.Text = qm[0].Age.ToString();
                    VisitDateTxt.Text = qm[0].VisitDate.ToString();
                    DaignosisNameTxt.Text = qm[0].Diagnosis.DiagnosisName;
                    ContractTypesTxt.Text = qm[0].ClmContractType.ContractName;
                    IdClmLb.Text  = qm[0].NoOfFile .ToString();

                }
                var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.MasterId == MstrId).Select(p => new
                {
                    Id = p.Id,
                    GenId = p.GenericId,
                    GenName = p.Medicine.Generic_name,
                    TradeName = p.TradeName,
                    UnitPrice = p.UnitPrice,
                    UnitQty = p.Qty,
                    TotalPrice = p.TotalPrice
                    
                }).ToList();
                if (q.Count > 0)
                {
                    VisitCostTxt.Text = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.MasterId == MstrId).Sum(p => p.TotalPrice).ToString();
                    ItemGrd.DataSource = q;


                    // ===================== view Nonconfirm
                    GetNonConfirm();
                    GetHistory();
                    GetStatistic();


                }
            }
            catch
            {

            }
        }

        private void SaveNextBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            int _impId = int.Parse(ImpNoTxt.Text);
            int _VistId = int.Parse(VisitIdTxt.Text);
            ClaimsCostTxt.Text = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ClmMasterData.ImpId == _impId).Sum(p => p.TotalPrice).ToString();
            //====================
            var qu = db.ClmMasterData.Where(p => p.ImpId == _impId && p.RowStatus != RowStatus.Deleted && p.IsReviewed == 0 && p.Id == _VistId).ToList();
            if (qu.Count >0)
            {
                qu[0].IsReviewed = 1;
                qu[0].ReviewDocId = _UserId;
                qu[0].ReviewDate = PLC.getdatetime();
                if(db.SaveChanges ()>0)
                {
                    var qm = db.ClmMasterData.Where(p => p.ImpId == _impId && p.RowStatus != RowStatus.Deleted && p.IsReviewed == 0 && p.Id > _VistId).OrderBy(p => p.NoOfFile).Select(p => p.Id).FirstOrDefault();

                    VisitIdTxt.Text = qm.ToString();
                }

            }
            //==================

            GetStatistic();
            
        }

        private void ItemId_Click(object sender, EventArgs e)
        {

        }

        private void ItemName_Click(object sender, EventArgs e)
        {

        }

        private void radLabel15_Click(object sender, EventArgs e)
        {

        }

        private void ImpDrp_SelectedValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                dbContext db = new dbContext();
                if (ImpDrp.SelectedValue != null)
                {
                    int _impId = int.Parse(ImpDrp.SelectedValue.ToString());

                    var q = db.ClmImpFile.Where(p => p.Id == _impId && p.RowStatus != RowStatus.Deleted).ToList();
                    if (q.Count > 0)
                    {
                        
                        CenterNameTxt.Text = q[0].CenterInfo.CenterName;
                        FileNoTxt.Text = q[0].FileNo.ToString();
                        MonthTxt.Text = q[0].Month.ToString();
                        YearTxt.Text = q[0].year.ToString();
                        ImpNoTxt.Text = q[0].Id.ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void ItemGrd_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (ItemGrd .RowCount >0)
                {
                    dbContext db = new dbContext();
                    int _id = int.Parse(ItemGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _id).ToList();
                    if (q.Count >0)
                    {
                        IdDetTxt.Text = q[0].Id.ToString();
                        ItemIdTxt.Text = q[0].GenericId.ToString();
                        ItemNameTxt.Text = q[0].Medicine.Generic_name;
                        ValueTxt.Text = q[0].TotalPrice.ToString();
                        
                        
                    }
                }
            }
            catch
            {

            }
        }

        private void NonConfirmDrp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dbContext db = new dbContext();
                if (NonConfirmDrp.SelectedValue != null)
                {
                    int _Id = int.Parse(NonConfirmDrp.SelectedValue.ToString());

                    var q = db.ClmNonConfirmType.Where(p => p.Id == _Id && p.RowStatus != RowStatus.Deleted).ToList();
                    if (q.Count > 0)
                    {
                        _NonConId = q[0].Id;
                        _NonPercent = q[0].Value;
                        _NonType = ((int)q[0].ValueType);
                        _DicountType = ((int)q[0].DicountType);
                       if (q[0].ValueType== ModelDB.ValueType.Percent)
                        {
                            Discounttxt .Text = (Convert.ToDecimal(ValueTxt.Text) * q[0].Value / 100).ToString();
                        }
                        else
                        {
                            Discounttxt.Text = q[0].Value.ToString();
                        }
                        NetValue.Text = (Convert.ToDecimal(ValueTxt.Text) - Convert.ToDecimal(Discounttxt.Text)).ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void AddNonConfirmBtn_Click(object sender, EventArgs e)
        {
            if (Convert .ToDecimal( ValueTxt .Text) >0)
            {
                dbContext db = new dbContext();
                int _impid = int.Parse(ImpDrp.SelectedValue.ToString());
                var GetImpDet = db.ClmImpFile.Where(p => p.Id == _impid).ToList();
                int _visitId = int.Parse(VisitIdTxt.Text);
                int _idDet = int.Parse(IdDetTxt.Text);
                int _m = GetImpDet[0].Month ;
                int _y = GetImpDet[0].year;
                int _CenterId = GetImpDet[0].CenterId;
                decimal _NonVlaue = 0;
                
                decimal ItemTotalPrice = db.ClmDetailsData.Where( p=> p.Id == _idDet ).Select (p=> p.TotalPrice ).FirstOrDefault();
                
              
         
              
                var q = db.ClmNonConfirmDet.Where(p => p.DetailsId == _idDet && p.RowStatus != RowStatus.Deleted).ToList();
                if (q.Count > 0)
                {
                    DialogResult d = MessageBox.Show("هل تريد ادراج مخالفة مرة اخرى ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                }
                    ClmNonConfirmDet c = new ClmNonConfirmDet();
                    c.MasterId = int.Parse(VisitIdTxt.Text);
                    c.DateIn = PLC.getdatetime();
                if( _DicountType ==0)
                {
                    c.DetailsId = _idDet;
                   _NonVlaue = (ItemTotalPrice * _NonPercent )/100;
                    var UpNon = db.ClmDetailsData.Where(p => p.Id == _idDet).ToList();
                    if (UpNon.Count >0)
                    {
                        UpNon [0].NonConfItem = UpNon[0].NonConfItem+ _NonVlaue ;
                    }
                    c.Value = _NonVlaue;

                }
                else if (_DicountType ==1)
                {
                    
                    var UpNon = db.ClmDetailsData.Where(p => p.MasterId == _visitId && p.RowStatus != RowStatus.Deleted).ToList();
                    if (UpNon.Count>0)
                    {
                        foreach (var item in UpNon )
                        {
                            _NonVlaue = (item .TotalPrice  * _NonPercent) / 100;
                            item.NonConfVisit = item.NonConfVisit + _NonVlaue;

                        }
                       c.Value  = (db.ClmDetailsData.Where(p => p.MasterId == _visitId && p.RowStatus != RowStatus.Deleted).Sum(p => p.TotalPrice)*_NonPercent )*100;
                    }
                    c.DetailsId = 0;
                }
                else if (_DicountType ==2)
                {
                    
                    var UpNon = db.ClmDetailsData.Where(p => p.ClmMasterData .Months ==_m && p.ClmMasterData.Years==_y && p.ClmMasterData.CenterId== _CenterId && p.RowStatus != RowStatus.Deleted).ToList();
                    if (UpNon.Count > 0)
                    {
                        foreach (var item in UpNon)
                        {
                            _NonVlaue = (item.TotalPrice * _NonPercent) / 100;
                            item.NonConfClaims  = item.NonConfClaims + _NonVlaue;

                        }
                        c.Value  = (db.ClmDetailsData.Where(p => p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y && p.ClmMasterData.CenterId == _CenterId && p.RowStatus != RowStatus.Deleted).Sum(p => p.TotalPrice)* _NonPercent)/100 ;
                    }
                    c.DetailsId = 0;

                }

             
                c.Percent =_NonPercent  ;
                c.NonConfirmId = int.Parse(NonConfirmDrp.SelectedValue.ToString());
                c.RowStatus = RowStatus.NewRow;
                c.Status = Status.Active;
                c.UserId = _UserId;
                db.ClmNonConfirmDet.Add(c);
                if(db.SaveChanges ()>0)
                {

                    MessageBox.Show("تمت اضافة مخالفة");
                    GetNonConfirm();
                }
                

            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            int _impId = int.Parse(ImpNoTxt.Text);
            int _VistId = int.Parse(VisitIdTxt.Text);
            ClaimsCostTxt.Text = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ClmMasterData.ImpId == _impId).Sum(p => p.TotalPrice).ToString();
            var qm = db.ClmMasterData.Where(p => p.ImpId == _impId && p.RowStatus != RowStatus.Deleted  && p.Id > _VistId).OrderBy(p => p.NoOfFile).Select(p => p.Id).FirstOrDefault();

            VisitIdTxt.Text = qm.ToString();
        }

        private void PervBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            int _impId = int.Parse(ImpNoTxt.Text);
            int _VistId = int.Parse(VisitIdTxt.Text);
            ClaimsCostTxt.Text = db.ClmDetailsData.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ClmMasterData.ImpId == _impId).Sum(p => p.TotalPrice).ToString();
            var qm = db.ClmMasterData.Where(p => p.ImpId == _impId && p.RowStatus != RowStatus.Deleted && p.Id < _VistId ).OrderByDescending (p => p.NoOfFile).Select (p=> p.Id ).FirstOrDefault ();
            
                VisitIdTxt.Text = qm.ToString ();
        }

        private void NonConfrmGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            dbContext db = new dbContext();
            int _impid = int.Parse(ImpDrp.SelectedValue.ToString());
            var GetImpDet = db.ClmImpFile.Where(p => p.Id == _impid).ToList();
            int _visitId = int.Parse(VisitIdTxt.Text);
            int _idDet = int.Parse(IdDetTxt.Text);
            int _m = GetImpDet[0].Month;
            int _y = GetImpDet[0].year;
            int _CenterId = GetImpDet[0].CenterId;
            decimal _NonVlaue = 0;
            if (NonConfrmGrd .RowCount > 0)
            {
                if (NonConfrmGrd .CurrentColumn .Name =="Del")
                {
                    int _NonId = int.Parse(NonConfrmGrd.CurrentRow.Cells["Id"].Value .ToString());
                    var q = db.ClmNonConfirmDet .Where(p => p.Id == _NonId && p.RowStatus != RowStatus.Deleted).ToList();
                    if (q.Count>0)
                    {
                        DialogResult d = MessageBox.Show("هل تريد  الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (d == DialogResult.No)
                        {
                            return;
                        }
                        q[0].RowStatus = RowStatus.Deleted;
                        q[0].UserId = _UserId;
                        q[0].DateIn = PLC.getdatetime();

                        if ( q[0].ClmNonConfirmType.DicountType == DicountType.PerItems)
                        {
                                                           
                                var UpNon = db.ClmDetailsData.Where(p => p.Id == _idDet).ToList();
                                if (UpNon.Count > 0)
                                {
                              
                                UpNon[0].NonConfItem = UpNon[0].NonConfItem - q [0].Value ;
                                }


                            }
                            else if (q[0].ClmNonConfirmType.DicountType == DicountType.PerVisit)
                            {

                                var UpNon = db.ClmDetailsData.Where(p => p.MasterId == _visitId && p.RowStatus != RowStatus.Deleted).ToList();
                                if (UpNon.Count > 0)
                                {
                                    foreach (var item in UpNon)
                                    {
                                        _NonVlaue = (item.TotalPrice * _NonPercent) / 100;
                                        item.NonConfVisit = item.NonConfVisit - _NonVlaue;

                                    }
                                 
                                }
                     
                            }
                            else if (q[0].ClmNonConfirmType.DicountType == DicountType.PerClaims)
                            {

                                var UpNon = db.ClmDetailsData.Where(p => p.ClmMasterData.Months == _m && p.ClmMasterData.Years == _y && p.ClmMasterData.CenterId == _CenterId && p.RowStatus != RowStatus.Deleted).ToList();
                                if (UpNon.Count > 0)
                                {
                                    foreach (var item in UpNon)
                                    {
                                        _NonVlaue = (item.TotalPrice * _NonPercent) / 100;
                                        item.NonConfClaims = item.NonConfClaims - _NonVlaue;

                                    }
                                   
                                }
                              

                            }
                            if (db.SaveChanges()> 0)
                        {
                            MessageBox.Show("تم الحذف");
                            GetNonConfirm();
                        }
                    }
                }
            }
        }

        private void InsuranceNoTxt_TextChanged(object sender, EventArgs e)
        {
            GetHistory();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int _ID = int.Parse(IdClmsTxt.Text);
                dbContext db = new dbContext();

                var qm = db.ClmMasterData.Where(p => p.NoOfFile == _ID && p.RowStatus != RowStatus.Deleted && p.IsReviewed == 0).OrderBy(p => p.NoOfFile).Take(1).ToList();
                if (qm.Count > 0)
                {
                    VisitIdTxt.Text = qm[0].Id.ToString();
                }
            }
            catch
            {

            }
        }

        private void radGroupBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
