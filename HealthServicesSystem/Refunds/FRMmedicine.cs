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
using MedicalServiceSystem.SystemSetting;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMmedicine : Telerik.WinControls.UI.RadForm
    {
        public FRMmedicine()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMmedicine defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMmedicine Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMmedicine();
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
        public bool InList = false;
        private void LoadData()
        {

           // GrdDwa.DataSource = null;
            initMoney.Clear();
            card_no.Clear();
            OperationNo.Clear();
            OperationNo.Focus();
            CustName.Clear();
            dwalist.SelectedIndex = -1;
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            medicalsum.Clear();
            MoneySum.Clear();
            GrdDwa.Rows.Clear();
            approvereason.SelectedIndex = -1;
            RequistingParty.SelectedIndex = -1;
            ExcutingParty.SelectedIndex = -1;
            Saved = false;
            InList = false;
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
                    card_no.Focus();
                    return;
                }
                if (GrdDwa.RowCount == 0)
                {
                    MessageBox.Show("لا توجد بيانات لأدوية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        GetReclaim[0].ReclaimMedicineResonId = Convert.ToInt32(approvereason.SelectedValue);
                        GetReclaim[0].RefMedicineReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                        GetReclaim[0].RefMedicineExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                        GetReclaim[0].MedicineTotal = Convert.ToDecimal(MoneySum.Text);
                        GetReclaim[0].ReclaimTotal = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(medicalsum.Text);
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where ReclaimId=" + ReclaimId + "");
                        for (int i = 0; i < GrdDwa.RowCount; i++)
                        {
                            ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["MedicalId"].Value);
                            //var ChkReclaim = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId && p.MedicineId == ServiceId).ToList();
                            //if (ChkReclaim.Count == 0)
                            //{
                                ReclaimMedicine rm = new ReclaimMedicine();
                                rm.ReclaimId = ReclaimId;
                                rm.MedicineId = ServiceId;
                                rm.Quantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["quantity"].Value);
                                rm.ReclaimTotal = Convert.ToDecimal(GrdDwa.Rows[i].Cells["ReclaimTotal"].Value);
                                rm.ReclaimCost = Convert.ToDecimal(GrdDwa.Rows[i].Cells["ReclaimCost"].Value);
                                rm.Percentages = Convert.ToInt32(GrdDwa.Rows[i].Cells["Percentages"].Value);
                                rm.UserId = UserId;
                                rm.DateIn = PLC.getdate();
                                rm.LocalityId = PLC.LocalityId;
                                db.ReclaimMedicines.Add(rm);


                          // }
                        }

                        db.SaveChanges();
                        Saved = true;
                        MessageBox.Show("لقد تم حفظ بيانات الأدوية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("توجد مشكلة في الاتصال بالمخدم الرئيسي للبيانات"+(char)13+"قم باعادة المحاولة مرة أخرى", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }



        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (OperationNo.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var FRef = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Take(1).ToList();
                    if (FRef.Count > 0)
                    {
                        if (FRef[0].RefuseMedicine == true)
                        {
                            MessageBox.Show("لقد تم رفض هذه العملية من قبل ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ReclaimId = FRef[0].Id;
                        card_no.Text = FRef[0].InsurNo;
                        CustName.Text = FRef[0].InsurName;
                        OperationDate.Value = FRef[0].ReclaimDate;
                        approvereason.SelectedValue = FRef[0].ReclaimMedicineResonId;
                        ServerName.Text = FRef[0].Server;
                        initMoney.Text = FRef[0].BillsTotal.ToString();
                        RequistingParty.SelectedValue = FRef[0].RefMedicineReqCenterId;
                        BillStatus.SelectedIndex = Convert.ToInt32(FRef[0].ReclaimStatus);
                        ExcutingParty.SelectedValue = FRef[0].RefMedicineExcCenterId;
                        //var FrefMd = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                        // medicalsum.Text = FRef[0].MedicineTotal.ToString();
                        FillGrid();
                        var Med = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                        decimal MedSum = 0;
                        if (Med.Count > 0)
                        {
                            MedSum = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal);
                        }
                        medicalsum.Text = MedSum.ToString();
                        string CardNo = card_no.Text;
                        PLC.SubId = FRef[0].InsurNo;
                        var FrHistoryMd = db.Reclaims.Where(p => p.InsurNo == PLC.SubId && p.IsMedicine == true && p.MedicineTotal > 0).ToList();
                        //FRMEstrdadhistory.Default.Grid_service.DataSource = FrHistoryMd;
                        if (FrHistoryMd.Count > 0)
                        {
                            FRMEstrdadhistory frh = new FRMEstrdadhistory();
                            PLC.FlagMedicine = 1;
                            frh.ShowDialog();
                            //for (int i = 0; i < FrHistoryMd.Count; i++)
                            //{
                            //    FRMEstrdadhistory.Default.Grid_service.Rows[i].Cells[0].Value = i + 1;
                            //}
                            //FRMEstrdadhistory.Default.Totals.Text = FrHistoryMd.Sum(p => p.ReclaimCost).ToString();
                            //FRMEstrdadhistory.Default.ShowDialog();

                        }

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
                                if (getSer[0].InContract == true)
                                {
                                    ServiceListType.Text = "داخل العقد";
                                }
                                else
                                {
                                    ServiceListType.Text = "خارج العقد";
                                }
                                string StrUnit = "";
                                var Dbunit = db.Medicines.Where(p => p.Id == ServiceId).ToList();
                                if (Dbunit.Count > 0)
                                {
                                    StrUnit = Dbunit[0].Unit.Unit_Name;
                                }
                                UnitInfo.Text = "تكتب بأصغر وحدة " + " " + "وأصغر وحدة هي " + StrUnit;
                                UnitPrice.Text = getSer[0].UnitCost.ToString();
                                MaxCost.Text = getSer[0].MaxCost.ToString();
                                InList = getSer[0].InContract;
                                Percentage.Text = 75.ToString();
                                quantity.Text = 1.ToString();
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
                var FrefMl = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicineForReclaim.Generic_name, p.MedicineForReclaim.InContract, p.ReclaimTotal, p.ReclaimCost, MedicalId = p.MedicineId, p.Quantity, p.Percentages, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicineResonId }).ToList();
                //  GrdDwa.DataSource = FrefMl;
                if (FrefMl.Count > 0)
                {
                    GrdDwa.Rows.Clear();
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdDwa.Rows.Add(i + 1, FrefMl[i].Id, FrefMl[i].MedicalId, FrefMl[i].Generic_name, FrefMl[i].ReclaimTotal, FrefMl[i].InContract, 0, FrefMl[i].Quantity, FrefMl[i].ReclaimCost, FrefMl[i].Percentages);
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
            dwalist.SelectedIndex = -1;
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            dwalist.Focus();


        }
        private void FRMmedicine_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;
            using (dbContext db = new dbContext())
            {
                var ReclaimRes = db.ReclaimMedicineReasonsLists.Where(p => p.Activated == true).ToList();
                approvereason.DataSource = ReclaimRes;
                approvereason.DisplayMember = "MedicineReason";
                approvereason.ValueMember = "Id";
                approvereason.SelectedIndex = -1;

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

                var EngSer = db.MedicineForReclaims.Where(p => p.IsVisible == true).ToList();
                dwalist.DataSource = EngSer;
                dwalist.ValueMember = "Id";
                dwalist.DisplayMember = "Generic_name";
                dwalist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                dwalist.SelectedIndex = -1;
                BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                //FRMEstrdadWaiting.Default.ShowDialog();
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
            if (approvereason.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار سبب الاسترداد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                approvereason.Focus();
                return;
            }
            if (Convert.ToDecimal(MoneyPaied.Text) > Convert.ToDecimal(MaxCost.Text) && Convert.ToDecimal(MaxCost.Text) > 0)
            {
                MessageBox.Show("المبلغ المدخل أكبر من أقصى مبلغ لاسترداد هذا الدواء", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            decimal MedSum = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(MoneyPaied.Text) + Convert.ToDecimal(medicalsum.Text);
            if (MedSum > Convert.ToDecimal(initMoney.Text))
            {
                MessageBox.Show("المبلغ المدخل أكبر من اجمالي الفاتورة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            ServiceId = Convert.ToInt32(dwalist.SelectedValue.ToString());
            bool SerStatus = false;
            if (BillStatus.SelectedIndex == 0)
            {
                SerStatus = true;
            }

            //for (int i = 0; i < GrdDwa.RowCount; i++)
            //{
            //    if (GrdDwa.Rows[i].Cells["MedicalId"].Value.ToString() == ServiceId.ToString())
            //    {
            //        NewMedical();
            //        return;
            //    }

            //}
            // GrdDwa.DataSource = null;
            GrdDwa.Rows.Add(GrdDwa.RowCount + 1, 0, ServiceId.ToString(), dwalist.Text, (Convert.ToDecimal(UnitPrice.Text) * Convert.ToDecimal(quantity.Text)).ToString(), InList, UnitPrice.Text, quantity.Text, MoneyPaied.Text, Percentage.Text);
            decimal Mtotal = 0;
            for (int i = 0; i < GrdDwa.RowCount; i++)
            {
                Mtotal += Convert.ToDecimal(GrdDwa.Rows[i].Cells["ReclaimCost"].Value);

            }
            MoneySum.Text = Mtotal.ToString();
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
                    decimal Mtotal = 0;
                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        Mtotal +=Convert.ToDecimal(GrdDwa.Rows[i].Cells["ReclaimCost"].Value);

                    }
                    MoneySum.Text = Mtotal.ToString();
                    //using (dbContext db = new dbContext())
                    //{
                    //    var GetMed = db.ReclaimMedicines.Where(p => p.Id == ReclaimMedId).ToList();
                    //    db.ReclaimMedicines.Remove(GetMed[0]);
                    //    db.SaveChanges();
                    //    FillGrid();
                    //}
                }
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
                a = MessageBox.Show("سوف يتم حذف بيانات كل الأدوية المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where ReclaimId=" + ReclaimId + "");
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
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToDecimal(quantity.Text) * Convert.ToDecimal(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void quantity_TextChanged(object sender, EventArgs e)
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
                    var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicineForReclaim.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "أدوية" }).ToList();
                    var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.InsurNo, p.Reclaim.InsurName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Server, p.Reclaim.ClientId, InContract = (p.MedicalServices.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "خدمات طبية" }).ToList();
                    var FrHistory = FrHistoryMc.Union(FrHistoryMd).ToList();
                    if (FrHistory.Count > 0)
                    {
                        var Frec = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text).ToList();
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
                    var GetReclaim = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("update Reclaims set RefuseMedicine=1 where Id=" + ReclaimId + "");
                        db.SaveChanges();
                        MessageBox.Show("لقد تم رفض هذه العملية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void OperationNo_Leave_2(object sender, EventArgs e)
        {

        }
    }
}
