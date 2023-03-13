using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
using Telerik.WinControls;
using System.Linq;
using System.IO;
using HealthServicesSystem.SystemSetting;

namespace HealthServicesSystem.Reclaims
{
    public partial class FrmAddChronicMedicine : Telerik.WinControls.UI.RadForm
    {
        public FrmAddChronicMedicine()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmAddChronicMedicine defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmAddChronicMedicine Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmAddChronicMedicine();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion
        public int UserId = 0;
        public int LocalityId = 0;
        public int BookId = 0;
        public int ServiceId = 0;
        public bool Saved = false;
        public bool InList = false;
        string StrUnit = "";
        private void LoadData()
        {

            card_no.Clear();
            BookNo.Clear();
            BookNo.Focus();
            CustName.Clear();
            dwalist.SelectedIndex = -1;
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            quantity.Clear();
            GrdDwa.Rows.Clear();
            Saved = false;
            InList = false;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            BookNo.Enabled = true;
            BookNo.Clear();
            BookNo.Focus();
            LoadData();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (BookNo.Text.Length == 0)
                {
                    MessageBox.Show("لا توجد بيانات لهذا الدفتر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BookNo.Focus();
                    return;
                }
                if (card_no.Text.Length == 0)
                {
                    MessageBox.Show("لا توجد بيانات لهذا المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    card_no.Focus();
                    return;
                }
                if (GrdDwa.RowCount == 0)
                {
                    MessageBox.Show("لا توجد بيانات لأدوية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NewMedical();
                    return;
                }

                using (dbContext db = new dbContext())
                {

                    //var GetReclaim = db.Reclaims.Where(p => p.Id == BookId).ToList();
                    //if (GetReclaim.Count > 0)
                    //{

                    // db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where BookId=" + BookId + "");
                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["MedicalId"].Value);
                        var ChkMedic = db.ChronicMedicines.Where(p => p.InsurNo == card_no.Text && p.GenericId == ServiceId).ToList();
                        if (ChkMedic.Count == 0)
                        {
                            ChronicMedicine rm = new ChronicMedicine();
                            rm.InsurNo = card_no.Text;
                            rm.GenericId = ServiceId;
                            rm.OperationDate = PLC.getdate();
                            rm.Quantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["quantity"].Value);
                            rm.UserId = UserId;
                            db.ChronicMedicines.Add(rm);


                        }
                        

                        db.SaveChanges();
                    }
                    Saved = true;
                        var ApproveToday = db.ChronicMedicines .Where(p =>  p.OperationDate == OperationDate.Value && p.UserId==UserId).GroupBy(p=> p.InsurNo).Select(p => new {Id= 1, p.Key }).ToList();
                        GrdDailyWork.DataSource = ApproveToday;
                        if (GrdDailyWork.RowCount > 0)
                        {
                            for (int i = 0; i < GrdDailyWork.RowCount; i++)
                            {
                                GrdDailyWork.Rows[i].Cells[0].Value = i + 1;
                            }
                            if (GrdDailyWork.RowCount > 0)
                            {
                                GrdDailyWork.Rows[GrdDailyWork.RowCount - 1].IsCurrent = true;
                                GrdDailyWork.Rows[GrdDailyWork.RowCount - 1].IsSelected = true;

                            }
                        }
                        MessageBox.Show("لقد تم حفظ بيانات الأدوية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   // }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("توجد مشكلة في الاتصال بالمخدم الرئيسي للبيانات" + (char)13 + "قم باعادة المحاولة مرة أخرى", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }



        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (BookNo.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    int BNo = Convert.ToInt32(BookNo.Text);
                    var FRef = db.ChronicsBooks.Where(p => p.BookNo == BNo && p.Activated == true && p.RowStatus != RowStatus.Deleted).Take(1).ToList();
                    if (FRef.Count > 0)
                    {

                        BookId = FRef[0].Id;
                        card_no.Text = FRef[0].InsurNo;
                        CustName.Text = FRef[0].InsurName;
                        //OperationDate.Value = FRef[0].ReclaimDate;
                        ServerName.Text = FRef[0].Server;
                        //var FrefMd = db.ReclaimMedicals.Where(p => p.BookId == BookId).ToList();
                        // medicalsum.Text = FRef[0].MedicineTotal.ToString();
                        FillGrid();


                        //if (FrefMl.Count > 0)
                        //{
                        //    Saved = true;


                        //    BillStatus.SelectedIndex = Convert.ToInt32(FrefMl[0].ReclaimStatus);
                        //    approvereason.SelectedValue = FrefMl[0].ReclaimMedicineResonId;

                        //    for (int i = 0; i < FrefMl.Count; i++)
                        //    {
                        //        GrdDwa.Rows[i].Cells[0].Value = i + 1;
                        //    }

                        //}
                    }
                }
            }
        }

        private void dwalist_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (dwalist.ContainsFocus)
                {
                    if (dwalist.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(dwalist.SelectedValue);
                            var getSer = db.MedicineForReclaims.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {

                                var Dbunit = db.Medicines.Where(p => p.Id == ServiceId).ToList();
                                if (Dbunit.Count > 0)
                                {
                                    StrUnit = Dbunit[0].Unit.Unit_Name;
                                }
                                //UnitInfo.Text = "تكتب بأصغر وحدة " + " " + "وأصغر وحدة هي " + StrUnit;
                                quantity.Text = 30.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ChronicMedicines.Where(p => p.InsurNo == card_no.Text).Select(p => new { p.Id, p.MedicineForReclaim.Generic_name, MedicalId = p.GenericId, p.Quantity }).ToList();
                //  GrdDwa.DataSource = FrefMl;
                if (FrefMl.Count > 0)
                {
                    GrdDwa.Rows.Clear();
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdDwa.Rows.Add(i + 1, FrefMl[i].Id, FrefMl[i].MedicalId, FrefMl[i].Generic_name, FrefMl[i].Quantity);
                    }


                    // NewMedical();

                }

            }
        }
        private void NewMedical()
        {
            dwalist.SelectedIndex = -1;
            quantity.Text = 30.ToString();
            dwalist.Focus();


        }
        private void FrmAddChronicMedicine_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;
            quantity.Text = 30.ToString();
            using (dbContext db = new dbContext())
            {




                var EngSer = db.MedicineForReclaims.Where(p => p.IsVisible == true && p.InContract == true).ToList();
                dwalist.DataSource = EngSer;
                dwalist.ValueMember = "Id";
                dwalist.DisplayMember = "Generic_name";
                dwalist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                dwalist.SelectedIndex = -1;
                var ApproveToday = db.ChronicMedicines.Where(p => p.OperationDate == OperationDate.Value && p.UserId == UserId).GroupBy(p => p.InsurNo).Select(p => new { Id = 1, p.Key }).ToList();
                GrdDailyWork.DataSource = ApproveToday;
                if (GrdDailyWork.RowCount > 0)
                {
                    for (int i = 0; i < GrdDailyWork.RowCount; i++)
                    {
                        GrdDailyWork.Rows[i].Cells[0].Value = i + 1;
                    }
                    if (GrdDailyWork.RowCount > 0)
                    {
                        GrdDailyWork.Rows[GrdDailyWork.RowCount - 1].IsCurrent = true;
                        GrdDailyWork.Rows[GrdDailyWork.RowCount - 1].IsSelected = true;

                    }
                }
                //  BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                //FRMEstrdadWaiting.Default.ShowDialog();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (BookNo.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BookNo.Focus();
                return;
            }
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BookNo.Focus();
                return;
            }
            if (dwalist.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الدواء", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dwalist.Focus();
                return;
            }
            if (quantity.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال عدد مرات تلقي الخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity.Focus();
                return;
            }


            for (int i = 0; i < GrdDwa.RowCount; i++)
            {
                if (GrdDwa.Rows[i].Cells["MedicalId"].Value.ToString() == ServiceId.ToString())
                {
                    NewMedical();
                    return;
                }

            }
            // GrdDwa.DataSource = null;
            GrdDwa.Rows.Add(GrdDwa.RowCount + 1, 0, ServiceId.ToString(), dwalist.Text, quantity.Text);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdDwa.RowCount > 0)
            {
                int ReclaimMedId = Convert.ToInt32(GrdDwa.CurrentRow.Cells[1].Value);
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات هذا الدواء", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    GrdDwa.Rows.RemoveAt(GrdDwa.CurrentRow.Index);
                    //decimal Mtotal = 0;

                    using (dbContext db = new dbContext())
                    {
                        var GetMed = db.ChronicMedicines.Where(p => p.Id == ReclaimMedId).ToList();
                        if (GetMed.Count > 0)
                        {
                            db.ChronicMedicines.Remove(GetMed[0]);
                            db.SaveChanges();
                            FillGrid();
                        }

                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //if (Saved == false)
            //{
            //    MessageBox.Show("لم يتم حفظ بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            ////}
            using (dbContext db = new dbContext())
            {
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات كل الأدوية المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ChronicMedicines.Where(p => p.InsurNo == card_no.Text).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from ChronicMedicines where InsurNo='" + card_no.Text + "'");
                        db.SaveChanges();
                        Saved = false;
                        MessageBox.Show("لقد تم حذف بيانات كل الأدوية المدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void UnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void Percentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (Saved == false)
            {
                MessageBox.Show("لم يتم حفظ بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                using (dbContext db = new dbContext())
                {
                    var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.ReclaimNo == BookNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Id, p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicineForReclaim.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "أدوية" }).ToList();
                    var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.ReclaimNo == BookNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Id, p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicalServices.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "خدمات طبية" }).ToList();
                    var FrHistory = FrHistoryMc.Union(FrHistoryMd).ToList();
                    if (FrHistory.Count > 0)
                    {
                        var Frec = db.Reclaims.Where(p => p.ReclaimNo == BookNo.Text).ToList();
                        if (Frec.Count > 0)
                        {
                            Frec[0].ReclaimTotal = Frec[0].MedicalTotal + Frec[0].MedicineTotal;
                            db.SaveChanges();
                        }
                        Estrdad Estr = new Estrdad();
                        Estr.DataSource = FrHistory;
                        double TotalOfMoney = Convert.ToDouble(FrHistory[0].BillsTotal);
                        double TotalOfEstrdad = Convert.ToDouble(FrHistory.Sum(p => p.ReclaimCost));
                        //MessageBox.Show(TotalOfEstrdad.ToString());
                        Estr.MoneyWritten.Value = PLC.NumToStr(TotalOfMoney).ToString();
                        Estr.MoneyPaiedWritten.Value = PLC.NumToStr(TotalOfEstrdad).ToString();
                        // MessageBox.Show(Estr.MoneyPaiedWritten.Value.ToString());
                        Estr.FormName.Value = "استمارة أ";
                        var GetInfo = db.CompanySettings.FirstOrDefault();
                        Estr.ComanyName.Value = GetInfo.CompanyName;
                        Estr.ManagementName.Value = GetInfo.Management;
                        //Estr.DepartmentName.Value = GetInfo.Department;
                        Byte[] MyData = new byte[0];
                        MyData = (Byte[])GetInfo.LogoPath1;
                        MemoryStream stream = new MemoryStream(MyData);
                        stream.Position = 0;
                        Estr.CompanyLogo.Value = Image.FromStream(stream);

                        Byte[] MyData1 = new byte[0];
                        MyData1 = (Byte[])GetInfo.LogoPath2;
                        MemoryStream stream1 = new MemoryStream(MyData1);
                        stream1.Position = 0;
                        Estr.IsoLogo.Value = Image.FromStream(stream1);
                        ReportProcessor pr = new ReportProcessor();
                        PrintDialog pg = new PrintDialog();
                        pr.PrintReport(Estr, pg.PrinterSettings);
                        // FRMEstrdadWaiting.Default.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

                return;
            }

        }

        private void GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void ServiceListType_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadButton2_Click(object sender, EventArgs e)
        {

            FrmCenters frs = new FrmCenters();
            PLC.Flag = 1;
            frs.ShowDialog();

        }

        private void OperationNo_Leave(object sender, EventArgs e)
        {

        }

        private void Card_no_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void Approvereason_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void RequistingParty_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void ExcutingParty_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void Dwalist_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void UnitPrice_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void Quantity_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void Note_Leave(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void OperationNo_Leave_1(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم رفض استرداد الخدمة الدوائية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.Reclaims.Where(p => p.Id == BookId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("update Reclaims set RefuseMedicine=1 where Id=" + BookId + "");
                        db.SaveChanges();
                        MessageBox.Show("لقد تم رفض هذه العملية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void OperationNo_Leave_2(object sender, EventArgs e)
        {

        }

        private void RequistingParty_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void BookNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void GrdDailyWork_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GrdDailyWork.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                  string   insurNO = e.Row.Cells["InsurNo"].Value.ToString();
                    if (GrdDailyWork.CurrentColumn.Name == "Show")
                    {
                        var FRef = db.ChronicsBooks.Where(p => p.InsurNo == insurNO && p.Activated == true && p.RowStatus != RowStatus.Deleted).Take(1).ToList();
                        if (FRef.Count > 0)
                        {

                            BookId = FRef[0].Id;
                            card_no.Text = FRef[0].InsurNo;
                            CustName.Text = FRef[0].InsurName;
                            //OperationDate.Value = FRef[0].ReclaimDate;
                            ServerName.Text = FRef[0].Server;
                            //var FrefMd = db.ReclaimMedicals.Where(p => p.BookId == BookId).ToList();
                            // medicalsum.Text = FRef[0].MedicineTotal.ToString();
                            FillGrid();


                            //if (FrefMl.Count > 0)
                            //{
                            //    Saved = true;


                            //    BillStatus.SelectedIndex = Convert.ToInt32(FrefMl[0].ReclaimStatus);
                            //    approvereason.SelectedValue = FrefMl[0].ReclaimMedicineResonId;

                            //    for (int i = 0; i < FrefMl.Count; i++)
                            //    {
                            //        GrdDwa.Rows[i].Cells[0].Value = i + 1;
                            //    }

                            //}
                        }
                    }
                }
            }
        }
    }
}
