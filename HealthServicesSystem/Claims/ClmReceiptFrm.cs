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
    public partial class ClmReceiptFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmReceiptFrm()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        public void GetFiles(int m, int y, int centerId)
        {
            try
            {
                radGridView1.DataSource = null;
                dbContext db = new dbContext();
                var q = db.ClmReceiptClaimsDet.Where(p => p.ClmReceiptClaims.Month == m && p.ClmReceiptClaims.year == y && p.ClmReceiptClaims.CenterId == centerId && p.RowStatus != RowStatus.Deleted)
                    .Select(p => new { Id = p.Id, FileNo = p.FileNo, FileName = p.FileName, Counts = p.CountOfOrneks, TotalClaims = p.TotalOfClaims, BoxFileNo = p.CountOfBoxFile ,RecieptId = p.ReceiptId  }).ToList();

                if (q.Count > 0)
                {
                    var q1 = db.ClmImpFile.Where(p => p.Month == m && p.year == y && p.CenterId == centerId && p.RowStatus != RowStatus.Deleted  && !db.ClmReceiptClaimsDet.Where(s => s.ClmReceiptClaims.Month == m && s.ClmReceiptClaims.year == y && s.ClmReceiptClaims.CenterId == centerId && s.RowStatus != RowStatus.Deleted && s.ImpId  == p.Id ).Select (s=> s.FileNo).Contains (p.FileNo))
                       .Select(p => new { Id = 0,ImpId= p.Id, FileNo = p.FileNo, Counts = p.Counts, TotalClaims = p.Costs }).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            radGridView1.Rows.Add(0,q1[0].FileNo, "", q1[0].TotalClaims, q1[0].Counts, "");
                        
                        }
                    }
                    radGridView1.DataSource = q;
                    int _id = q[0].RecieptId ;
                    var getq = db.ClmReceiptClaims.Where(p => p.Id == _id).ToList();
                    IdTxt.Text = getq[0].Id.ToString();
                    ContractNameTxt.Text = getq[0].ContactName;
                    TelNoTxt.Text = getq[0].ContactTell;
                    ReceiptDate.Value = getq[0].ReceiptDate;
                    NextDate.Value = getq[0].NextDate ;
                    TimeIn.Value = getq[0].TimeIn ;
                    TimeOut.Value = getq[0].TimeOut ;
                    SortedDrp.SelectedValue = getq[0].Sorted ;
                    DataErrorDrp.SelectedValue = getq[0].DataEntery ;
                    NotesTxt.Text = getq[0].Notes;

                }
                else
                {
                   
                    var q1 = db.ClmImpFile.Where(p => p.Month == m && p.year == y && p.CenterId == centerId && p.RowStatus != RowStatus.Deleted )
                        .Select(p => new { Id = 0,ImpId=p.Id, FileNo = p.FileNo, Counts = p.Counts, TotalClaims = p.Costs }).ToList() ;
                        if (q1.Count >0)
                    {
                        radGridView1.DataSource = q1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            IdTxt.Clear();
            CenterNameDrp.SelectedIndex = -1;
            MonthDrp.SelectedIndex = -1;
            YearTxt.Clear();
            ContractNameTxt.Clear();
            TelNoTxt.Clear();
            ReceiptDate.Value = PLC.getdate();
            NextDate.Value = PLC.getdatetime().AddMonths(1);
            TimeIn.Value = PLC.gettime();
            TimeOut.Value = PLC.gettime();
            SortedDrp.SelectedIndex = -1;
            DataErrorDrp.SelectedIndex = -1;
            NotesTxt.Clear();



        }

        private void SaveBtn_Click(object sender, EventArgs e)
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
            if (YearTxt.Text == "")
            {
                MessageBox.Show("ادخل السنة");
                YearTxt.Focus();
                return;
            }
            if (ContractNameTxt.Text == "")
            {
                MessageBox.Show("ادخل اسم المندوب");
                ContractNameTxt.Focus();
                return;
            }
            if (TelNoTxt.Text == "")
            {
                MessageBox.Show("ادخل رقم تلفون المندوب");
                TelNoTxt.Focus();
                return;
            }
            if (SortedDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر التقييم");
                SortedDrp.Focus();
                return;
            }
            if (DataErrorDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر التقييم");
                DataErrorDrp.Focus();
                return;
            }
            if (IdTxt.Text == "")
            {
                ClmReceiptClaims c = new ClmReceiptClaims();
                c.ContactName = ContractNameTxt.Text;
                c.ContactTell = TelNoTxt.Text;
                c.CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                c.DateIn = PLC.getdatetime();
                c.Month = MonthDrp.SelectedIndex +1;
                c.NextDate = NextDate.Value;
                c.Notes = NotesTxt.Text;
                c.RowStatus = RowStatus.NewRow;
                c.Status = Status.Active;
                c.TimeIn = TimeIn.Value;
                c.TimeOut = TimeOut.Value;
                c.UserId = _UserId;
                c.ReceiptDate = ReceiptDate.Value;
                c.year = int.Parse(YearTxt.Text);
                c.DataEntery = int.Parse(DataErrorDrp.SelectedValue.ToString());
                c.Sorted = int.Parse(SortedDrp.SelectedValue.ToString());
                db.ClmReceiptClaims.Add(c);
                if (db.SaveChanges() > 0)
                {
                    for (int i = 0; i < radGridView1.RowCount; i++)
                    {
                        int _impId = int.Parse(radGridView1.Rows[i].Cells["ImpId"].Value.ToString());
                        ClmReceiptClaimsDet d = new ClmReceiptClaimsDet();
                        d.FileNo = int.Parse(radGridView1.Rows[i].Cells["FileNo"].Value.ToString());
                        d.FileName = radGridView1.Rows[i].Cells["FileName"].Value.ToString();
                        d.ReceiptId = c.Id;
                        d.TotalOfClaims = Convert.ToDecimal(radGridView1.Rows[i].Cells["TotalClaims"].Value.ToString());
                        d.CountOfOrneks = int.Parse(radGridView1.Rows[i].Cells["Counts"].Value.ToString());
                        d.CountOfBoxFile = int.Parse(radGridView1.Rows[i].Cells["Counts"].Value.ToString());
                        d.Percent = 0;
                        d.CountOfError = 0;
                        d.DateIn = PLC.getdatetime();
                        d.UserId = _UserId;
                        d.ImpId = _impId;
                        db.ClmReceiptClaimsDet.Add(d);
                        var qImp = db.ClmImpFile.Where(p => p.Id == _impId && p.RowStatus != RowStatus.Deleted).ToList();
                        if (qImp.Count>0)
                        {
                            qImp[0].ReceiptDate = PLC.getdatetime();
                            qImp[0].ReceiptUserId = _UserId;
                            qImp[0].ClmStatus = ClmStatus.Receipt;
                        }

                    }
                    if (db.SaveChanges() > 0)
                    {
                        IdTxt.Text = c.Id.ToString();
                        MessageBox.Show("تم الحفظ");
                    }
                }
            }
            else
            {
                int _id = int.Parse(IdTxt.Text);
                var q = db.ClmReceiptClaims.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _id).ToList();
                if (q.Count > 0)
                {
                    DialogResult d = MessageBox.Show("هل تريد التعديل ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    q[0].ContactName = ContractNameTxt.Text;
                    q[0].ContactTell = TelNoTxt.Text;
                    q[0].CenterId = int.Parse(CenterNameDrp.SelectedValue.ToString());
                    q[0].DateIn = PLC.getdatetime();
                    q[0].Month = MonthDrp .SelectedIndex +1;
                    q[0].NextDate = NextDate.Value;
                    q[0].Notes = NotesTxt.Text;
                    q[0].TimeIn = TimeIn.Value;
                    q[0].TimeOut = TimeOut.Value;
                    q[0].UserId = _UserId;
                    q[0].ReceiptDate = ReceiptDate.Value;
                    q[0].year = int.Parse(YearTxt.Text);
                    q[0].DataEntery = int.Parse(DataErrorDrp.SelectedValue.ToString());
                    q[0].Sorted = int.Parse(SortedDrp.SelectedValue.ToString());
                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("تم التعديل");
                    }
                }
            }
        }

        private void ClmReceiptFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var qCenter = db.CenterInfos.Where(p=> p.IsEnabled == true && p.HasContract== true).Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
            if (qCenter.Count >0)
            {
                CenterNameDrp.DataSource = qCenter;
                CenterNameDrp.DisplayMember = "CenterName";
                CenterNameDrp.ValueMember = "Id";
                CenterNameDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                CenterNameDrp.SelectedIndex = -1;
            }

           
            var qSort = db.ClmSortedDeg.Select(p => new { Id = p.Id, Name = p.Name  }).ToList();
            if (qCenter.Count > 0)
            {
                SortedDrp.DataSource = qSort;
                SortedDrp.DisplayMember = "Name";
                SortedDrp.ValueMember = "Id";
                SortedDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                SortedDrp.SelectedIndex = -1;

                //
               
            }
            var qError = db.ClmSortedDeg.Select(p => new { Id = p.Id, Name = p.Name }).ToList();
            if (qError.Count > 0)
            {
                DataErrorDrp.DataSource = qError;
                DataErrorDrp.DisplayMember = "Name";
                DataErrorDrp.ValueMember = "Id";
                DataErrorDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                DataErrorDrp.SelectedIndex = -1;
            }
        }

        private void MonthDrp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int m = MonthDrp.SelectedIndex + 1;
                int y = int.Parse(YearTxt.Text);
                int Cntrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
                GetFiles(m, y, Cntrid);
            }
            catch
            {

            }
        }

        private void YearTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CenterNameDrp.SelectedIndex != -1)
                {
                    int m = MonthDrp.SelectedIndex + 1;
                    int y = int.Parse(YearTxt.Text);
                    int Cntrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
                    GetFiles(m, y, Cntrid);
                }
            }
            catch
            {
            }
        }

        private void CenterNameDrp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CenterNameDrp.SelectedIndex != -1)
                {
                    int m = MonthDrp.SelectedIndex + 1;
                    int y = int.Parse(YearTxt.Text);
                    int Cntrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
                    GetFiles(m, y, Cntrid);
                }
            }
            catch
            {
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            int _id = int.Parse(IdTxt.Text);
            var q = db.ClmReceiptClaims.Where(p => p.Id == _id && p.RowStatus!= RowStatus.Deleted).ToList();
            if (q.Count >0)
            {
                DialogResult d = MessageBox.Show("هل تريد الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
                var qdet = db.ClmReceiptClaimsDet.Where(f => f.ReceiptId == _id && f.RowStatus != RowStatus.Deleted ).ToList();
                if (qdet.Count >0)
                {
                    foreach (var item in qdet)
                    {
                        item.RowStatus = RowStatus.Deleted;
                        item.UserDeleted = _UserId;
                        item.DeleteDate = PLC.getdatetime();
                        
                    }
                }
                q[0].RowStatus = RowStatus.Deleted;
                q[0].UserDeleted = _UserId;
                q[0].DeleteDate = PLC.getdatetime();
                if(db.SaveChanges ()>0)
                {
                    radGridView1.DataSource = null;
                    NewBtn.PerformClick();
                    MessageBox.Show("تم الحذف");


                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthDrp_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            try
            {
                if (CenterNameDrp.SelectedIndex != -1)
                {
                    int m = MonthDrp.SelectedIndex + 1;
                    int y = int.Parse(YearTxt.Text);
                    int Cntrid = int.Parse(CenterNameDrp.SelectedValue.ToString());
                    GetFiles(m, y, Cntrid);
                }
            }
            catch
            {

            }

        }

        private void ErrorNotesBtn_Click(object sender, EventArgs e)
        {
            if (IdTxt .Text !="")
            {
                ClmErrorClmsDataFrm  frm = new ClmErrorClmsDataFrm();
                frm.ReceiptId.Text = IdTxt.Text;
                frm.ShowDialog();
            }
        }

        private void PrinBtn_Click(object sender, EventArgs e)
        {
            if (IdTxt.Text != "")
            {
                ViewReceiptRepFrm frm = new ViewReceiptRepFrm();
                frm._RecId = int.Parse(IdTxt .Text);
                frm.ReceiptId  = int.Parse(IdTxt.Text);
                frm.ShowDialog();
            }
        }

        private void IdTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
