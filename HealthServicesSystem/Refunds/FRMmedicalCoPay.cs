using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMmedicalCoPay : Telerik.WinControls.UI.RadForm
    {
        public FRMmedicalCoPay()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }
        public bool InList = false;
        #region Default Instance

        private static FRMmedicalCoPay defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMmedicalCoPay Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMmedicalCoPay();
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
        public int ReclaimId = 0;
        public int ServiceId = 0;
        public bool Saved = false;
        private void LoadData()
        {

           // GrdMedical.DataSource = null;
            card_no.Clear();
            initMoney.Clear();
            OperationNo.Clear();
            OperationNo.Focus();
            CustName.Clear();
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            InList = false;
            UnitPrice.Clear();
            MoneyPaied.Clear();
            GrdMedical.Rows.Clear();
            dwasum.Clear();
            Saved = false;
        }
        private void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicalId, p.MedicalServices.ServiceEName, p.MedicalServices.InContract, p.MedicalServices.ServiceEmPrice, p.Quantity, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicalResonId }).ToList();
               // GrdMedical.DataSource = FrefMl;
                if (FrefMl.Count > 0)
                {

                    //MoneySum.Text = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal).ToString();
                    GrdMedical.Rows.Clear();
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdMedical.Rows.Add(i + 1, FrefMl[i].Id, FrefMl[i].MedicalId, FrefMl[i].ServiceEName, FrefMl[i].ReclaimTotal, FrefMl[i].InContract, 0, FrefMl[i].Quantity, FrefMl[i].ReclaimCost, FrefMl[i].Percentages);
                    }
                    MoneySum.Text = FrefMl.Sum(p => p.ReclaimCost).ToString();
                   // NewMedical();

                }
                else
                {
                    MoneySum.Text = 0.ToString();
                }
            }
        }
        private void NewMedical()
        {
            ServiceList.SelectedIndex = -1;
            MedicalArabic.SelectedIndex = -1;
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            ServiceList.Focus();


        }
        private void FRMmedicalCoPay_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var ReclaimRes = db.ReclaimMedicalReasonsLists.Where(p=>p.Activated==true).ToList();
                ApproveReason.DataSource = ReclaimRes;
                ApproveReason.DisplayMember = "MedicalReason";
                ApproveReason.ValueMember = "Id";
                ApproveReason.SelectedValue= 12;

                var ReqCenter = db.CenterInfos.ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;

                var ExcCenter = db.CenterInfos.ToList();
                ExcutingParty.DataSource = ExcCenter;
                ExcutingParty.ValueMember = "Id";
                ExcutingParty.DisplayMember = "CenterName";
                ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ExcutingParty.SelectedIndex = -1;

                var EngSer = db.MedicalServices.Where(p => p.ListType == ListType.مساهمة && p.IsVisible == true && p.IsEnabled==true).ToList();
                ServiceList.DataSource = EngSer;
                ServiceList.ValueMember = "Id";
                ServiceList.DisplayMember = "ServiceEName";
                ServiceList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ServiceList.SelectedIndex = -1;

                MedicalArabic.DataSource = EngSer;
                MedicalArabic.ValueMember = "Id";
                MedicalArabic.DisplayMember = "ServiceAName";
                MedicalArabic.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                MedicalArabic.SelectedIndex = -1;
                BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                UserId = LoginForm.Default.UserId;
                LocalityId = PLC.LocalityId;
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (OperationNo.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    var FRef = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Take(1).ToList();
                    if (FRef.Count > 0)
                    {
                        ReclaimId = FRef[0].Id;
                        card_no.Text = FRef[0].InsurNo;
                        CustName.Text = FRef[0].InsurName;
                        OperationDate.Value = FRef[0].ReclaimDate;
                        ApproveReason.SelectedValue = FRef[0].ReclaimMedicalResonId;
                        ServerName.Text = FRef[0].Server;
                        initMoney.Text = FRef[0].BillsTotal.ToString();
                        BillStatus.SelectedIndex = Convert.ToInt32(FRef[0].ReclaimStatus);
                        var FrefMd = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).ToList();
                        if (FrefMd.Count > 0)
                        {
                            dwasum.Text = FRef.Sum(p => p.MedicineTotal).ToString();
                        }
                        else
                        {
                            dwasum.Text = "0";
                        }
                        RequistingParty.SelectedValue = FRef[0].RefMedicalReqCenterId;
                        ExcutingParty.SelectedValue = FRef[0].RefMedicalExcCenterId;
                        FillGrid();
                        string CardNo = card_no.Text;
                        PLC.SubId = FRef[0].InsurNo;
                        // var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.InsurNo == CardNo).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.ReclaimDate }).ToList();
                        //var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.InsurNo == CardNo).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.ReclaimDate,System="النظام" }).ToList();
                        var FrHistoryMd = db.Reclaims.Where(p => p.InsurNo == PLC.SubId && p.IsMedical == true && p.MedicalTotal > 0).ToList();
                        //FRMEstrdadhistory.Default.Grid_service.DataSource = FrHistoryMd;
                        if (FrHistoryMd.Count > 0)
                        {
                            FRMEstrdadhistory frh = new FRMEstrdadhistory();
                            PLC.FlagMedical = 1;
                            frh.ShowDialog();
                            //for (int i = 0; i < FrHistoryMd.Count; i++)
                            //{
                            //    FRMEstrdadhistory.Default.Grid_service.Rows[i].Cells[0].Value = i + 1;
                            //}
                            //FRMEstrdadhistory.Default.Totals.Text = FrHistoryMd.Sum(p => p.ReclaimCost).ToString();
                            //FRMEstrdadhistory.Default.ShowDialog();

                        }

                    }
                }
            }
        }

        private void ServiceList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ServiceList.ContainsFocus)
                {
                    if (ServiceList.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(ServiceList.SelectedValue);
                            var getSer = db.MedicalServices.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {
                                ServiceListType.Text = getSer[0].ListType.ToString();
                                UnitPrice.Text = getSer[0].ServicePrice.ToString();
                                MedicalArabic.SelectedValue = getSer[0].Id;
                                InList = getSer[0].InContract;
                                Percentage.Text = 100.ToString();
                                quantity.Text = 1.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void MedicalArabic_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (MedicalArabic.ContainsFocus)
                {
                    if (MedicalArabic.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(MedicalArabic.SelectedValue);
                            var getSer = db.MedicalServices.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {
                                ServiceListType.Text = getSer[0].ListType.ToString();
                                UnitPrice.Text = getSer[0].ServicePrice.ToString();
                                ServiceList.SelectedValue = getSer[0].Id;
                                Percentage.Text = 100.ToString();
                                InList = getSer[0].InContract;
                                quantity.Text = 1.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (OperationNo.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (ServiceList.SelectedIndex == -1 || MedicalArabic.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الخدمة الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ServiceList.Focus();
                return;
            }
            if (quantity.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال عدد مرات تلقي الخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity.Focus();
                return;
            }
            if (ApproveReason.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار سبب الاسترداد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ApproveReason.Focus();
                return;
            }
            decimal MedSum = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(MoneyPaied.Text) + Convert.ToDecimal(dwasum.Text);
            if (MedSum > Convert.ToDecimal(initMoney.Text))
            {
                MessageBox.Show("المبلغ المدخل أكبر من اجمالي الفاتورة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            ServiceId = Convert.ToInt32(ServiceList.SelectedValue.ToString());
            
            bool SerStatus = false;
            if (BillStatus.SelectedIndex == 0)
            {
                SerStatus = true;
            }

            //for (int i = 0; i < GrdMedical.RowCount; i++)
            //{
            //    if (GrdMedical.Rows[i].Cells["MedicalId"].Value.ToString() == ServiceId.ToString())
            //    {
            //        NewMedical();
            //        return;
            //    }
               
            //}
           // GrdMedical.DataSource = null;
            GrdMedical.Rows.Add(GrdMedical.RowCount + 1, 0, ServiceId.ToString(), MedicalArabic.Text, (Convert.ToDecimal(UnitPrice.Text) * Convert.ToInt32(quantity.Text)).ToString(), InList, UnitPrice.Text, quantity.Text, MoneyPaied.Text, Percentage.Text);
            decimal Mtotal = 0;
            for (int i = 0; i < GrdMedical.RowCount; i++)
            {
                Mtotal +=Convert.ToDecimal(GrdMedical.Rows[i].Cells["ReclaimCost"].Value);

            }
            MoneySum.Text = Mtotal.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdMedical.RowCount > 0)
            {
                int ReclaimMedId = Convert.ToInt32(GrdMedical.CurrentRow.Cells[1].Value);
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف الخدمة الطبية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    GrdMedical.Rows.RemoveAt(GrdMedical.CurrentRow.Index);
                    decimal Mtotal = 0;
                    for (int i = 0; i < GrdMedical.RowCount; i++)
                    {
                        Mtotal +=Convert.ToDecimal(GrdMedical.Rows[i].Cells["ReclaimCost"].Value);

                    }
                    MoneySum.Text = Mtotal.ToString();
                    //using (dbContext db = new dbContext())
                    //{
                    //    var GetMed = db.ReclaimMedicals.Where(p => p.Id == ReclaimMedId).ToList();
                    //    db.ReclaimMedicals.Remove(GetMed[0]);
                    //    db.SaveChanges();
                    //    FillGrid();
                    //}
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OperationNo.Enabled = true;
            OperationNo.Clear();
            OperationNo.Focus();
            LoadData();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperationNo.Text.Length == 0)
                {
                    MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OperationNo.Focus();
                    return;
                }
                if (card_no.Text.Length == 0)
                {
                    MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OperationNo.Focus();
                    return;
                }
                if (GrdMedical.RowCount == 0)
                {
                    MessageBox.Show("لا توجد بيانات لخدمات طبية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NewMedical();
                    return;
                }
                if (RequistingParty.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار الجهة الطالبة للخدمة أولا", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RequistingParty.Focus();
                    return;
                }
                if (ExcutingParty.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار الجهة المنفذة للخدمة أولا", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ExcutingParty.Focus();
                    return;
                }
                using (dbContext db = new dbContext())
                {
                    var GetReclaim = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        GetReclaim[0].ReclaimStatus = (ReclaimStatus)Enum.Parse(typeof(ReclaimStatus), BillStatus.SelectedText);
                        GetReclaim[0].ReclaimMedicalResonId = Convert.ToInt32(ApproveReason.SelectedValue);
                        GetReclaim[0].RefMedicalReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                        GetReclaim[0].RefMedicalExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                        GetReclaim[0].MedicalTotal = Convert.ToDecimal(MoneySum.Text);
                        GetReclaim[0].ReclaimTotal = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(dwasum.Text);
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicals where ReclaimId=" + ReclaimId + "");
                        for (int i = 0; i < GrdMedical.RowCount; i++)
                        {
                            ServiceId = Convert.ToInt32(GrdMedical.Rows[i].Cells["MedicalId"].Value);
                            //var ChkReclaim = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId && p.MedicalId == ServiceId).ToList();
                            //if (ChkReclaim.Count == 0)
                            //{
                                ReclaimMedical rm = new ReclaimMedical();
                                rm.ReclaimId = ReclaimId;
                                rm.MedicalId = ServiceId;
                                rm.Quantity = Convert.ToInt32(GrdMedical.Rows[i].Cells["quantity"].Value);
                                rm.ReclaimTotal = Convert.ToDecimal(GrdMedical.Rows[i].Cells["ReclaimTotal"].Value);
                                rm.ReclaimCost = Convert.ToDecimal(GrdMedical.Rows[i].Cells["ReclaimCost"].Value);
                                rm.Percentages = Convert.ToInt32(GrdMedical.Rows[i].Cells["Percentages"].Value);
                                rm.UserId = UserId;
                                rm.LocalityId = PLC.LocalityId;
                                rm.DateIn = PLC.getdate();
                                db.ReclaimMedicals.Add(rm);
                               

                           // }
                        }
                        db.SaveChanges();
                        Saved = true;
                        MessageBox.Show("لقد تم حفظ بيانات الخدمات الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // FillGrid();

                    }




                }
            }
            catch (Exception)
            {
                MessageBox.Show("توجد مشكلة في الاتصال بالمخدم الرئيسي للبيانات"+(char)13+"قم باعادة المحاولة مرة أخرى", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Saved == false)
            {
                MessageBox.Show("لم يتم حفظ بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (dbContext db = new dbContext())
            {
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات كل الخدمات الطبية المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicals where ReclaimId=" + ReclaimId + "");
                        db.SaveChanges();
                        Saved = false;
                        MessageBox.Show("لقد تم حذف بيانات كل الخدمات الطبية المدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (dbContext db = new dbContext())
                {
                   // var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicineForReclaim.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "أدوية" }).ToList();
                    var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted && p.MedicalServices.ListType==ListType.مساهمة).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicalServices.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "خدمات طبية مساهمات" }).ToList();
                   // var FrHistory = FrHistoryMc.Union(FrHistoryMd).ToList();
                    if (FrHistoryMd.Count > 0)
                    {
                        var Frec = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text).ToList();
                        if (Frec.Count > 0)
                        {
                            Frec[0].ReclaimTotal = Frec[0].MedicalTotal + Frec[0].MedicineTotal;
                            db.SaveChanges();
                        }
                        Estrdad Estr = new Estrdad();
                        Estr.DataSource = FrHistoryMd;
                        double TotalOfMoney = Convert.ToDouble(FrHistoryMd[0].BillsTotal);
                        double TotalOfEstrdad = Convert.ToDouble(FrHistoryMd.Sum(p => p.ReclaimCost));
                        Estr.MoneyWritten.Value = PLC.NumToStr(TotalOfMoney).ToString();
                        Estr.MoneyPaiedWritten.Value = PLC.NumToStr(TotalOfEstrdad).ToString();
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
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void OperationNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void UnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToDecimal(quantity.Text) * Convert.ToDecimal(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToDecimal(quantity.Text) * Convert.ToDecimal(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void Percentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToDecimal(quantity.Text) * Convert.ToDecimal(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void OperationNo_Leave(object sender, EventArgs e)
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

        private void ApproveReason_Leave(object sender, EventArgs e)
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

        private void RequistingParty_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

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

        private void ServiceList_Leave(object sender, EventArgs e)
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

        private void MedicalArabic_Leave(object sender, EventArgs e)
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

        }
    }
    }
