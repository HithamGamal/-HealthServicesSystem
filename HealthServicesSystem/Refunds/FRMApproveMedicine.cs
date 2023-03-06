using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
using Telerik.WinControls;
using System.Data.Entity;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using HealthServicesSystem.SystemSetting;
using System.Linq;

namespace HealthServicesSystem.Reclaims
{
    public partial class FRMApproveMedicine : Telerik.WinControls.UI.RadForm
    {
        public FRMApproveMedicine()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }
        public bool ChkSearch = false;
        #region Default Instance

        private static FRMApproveMedicine defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMApproveMedicine Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMApproveMedicine();
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
        public int ApproveNo = 0;
        public int ServiceId = 0;
        public int insurId = 0;
        public bool Saved = false;
        public string Rec_No = "";
        public string Phone;
        public string Gender;
        public string ClientId;
        public DateTime BirthDate = PLC.getdate();
        private void LoadData()
        {
            ChkSearch = false;
            SubscriberType.SelectedIndex = 0;
            ApprovementId.Text = "";
            Age.Clear();
            Sex.Text = "";
            GrdDwa.DataSource = null;
            CustName.Clear();
            BirthDate = PLC.getdate();
            dwalist.SelectedIndex = -1;
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            quantity.Clear();
            Atachment.Clear();
            ApprovedQuantity.Clear();
            ApproveType.SelectedIndex = -1;
            pharmacist.SelectedIndex = -1;
            RequistingParty.SelectedIndex = -1;
            ExcutingParty.SelectedIndex = -1;
            Diagnosis.SelectedIndex = -1;
            RouchitaNo.Clear();
            GrdDwa.Rows.Clear();
            card_no.Clear();
            card_no.Focus();
            ApproveDuration.Clear();
            ApproveNo = 0;
            insurId = 0;
            Saved = false;
            using (dbContext db = new dbContext())
            {
                var ApproveToday = db.ApproveMedicines.Where(p => p.UserId == UserId && p.ApproveDate == OperationDate.Value && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Id, p.InsurName }).ToList();
                GrdDailyWork.DataSource = ApproveToday;
                if (GrdDailyWork.RowCount > 0)
                {
                    for (int i = 0; i < GrdDailyWork.RowCount; i++)
                    {
                        GrdDailyWork.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }

        }
        private void Button6_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات للمشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (Sex.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال نوع المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Sex.Focus();
                return;
            }
            if (GrdDwa.RowCount == 0)
            {
                MessageBox.Show("لا توجد بيانات لأدوية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }


            if (ApproveNo == 0)
            {
                using (dbContext db = new dbContext())
                {
                    // insurId = dbs.Where(p => p.InsurNo == card_no.Text).First().Id;
                    ApproveMedicine apv = new ApproveMedicine();
                    // apv.InsurId = insurId;
                    apv.ReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                    apv.ExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                    apv.ApproveDate = OperationDate.Value;
                    apv.ApproveTypeId = Convert.ToInt32(ApproveType.SelectedValue.ToString());
                    apv.DiagnosisId = Convert.ToInt32(Diagnosis.SelectedValue);
                    apv.pharmacistId = Convert.ToInt32(pharmacist.SelectedValue);
                    apv.RouchitaNo = Convert.ToInt32(RouchitaNo.Text);
                    apv.UserId = UserId;
                    apv.LocalityId = PLC.LocalityId;
                    apv.DateIn = OperationDate.Value;
                    apv.RowStatus = RowStatus.NewRow;
                    apv.Status = Status.Active;
                    apv.Atachment = Atachment.Text;
                    apv.PhoneNo = Phone;
                    apv.InsurNo = card_no.Text;
                    apv.InsurName = CustName.Text;
                    apv.Gender = Sex.Text;
                    apv.Server = ServerName.Text;
                    apv.ClientId = Rec_No;
                    apv.BirthDate = BirthDate;

                    db.ApproveMedicines.Add(apv);
                    db.SaveChanges();
                    ApproveNo = db.ApproveMedicines.Where(p => p.InsurNo == card_no.Text && p.UserId == UserId).Max(p => p.Id);
                    var AppCode = db.ApproveMedicines.Where(p => p.Id == ApproveNo).ToList();
                    if (AppCode.Count > 0)
                    {
                        string Nyear = "";
                        Nyear = OperationDate.Value.Year.ToString();
                        Nyear = Nyear.Substring(2, 2);
                        string Nday = "";
                        Nday = OperationDate.Value.Day.ToString();
                        if (Nday.Length == 1)
                        {
                            Nday = "0" + Nday;
                        }
                        else
                        {
                            Nday = Nday;
                        }
                        string Nmonth = "";
                        Nmonth = OperationDate.Value.Month.ToString();
                        if (Nmonth.Length == 1)
                        {
                            Nmonth = "0" + Nmonth;
                        }
                        else
                        {
                            Nmonth = Nmonth;
                        }
                        AppCode[0].ApproveCode = Nyear + Nmonth + Nday + UserId.ToString() + ApproveNo.ToString();
                        db.SaveChanges();
                    }
                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["ServiceId"].Value.ToString());
                        var ChkApr = db.ApproveMedicineDetails.Where(p => p.ApproveMedicineId == ApproveNo && p.ServiceId == ServiceId).ToList();
                        if (ChkApr.Count == 0)
                        {
                            ApproveMedicineDetails aprd = new ApproveMedicineDetails();
                            aprd.ApproveMedicineId = ApproveNo;
                            aprd.ServiceId = ServiceId;
                            aprd.Quantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["Quantity"].Value.ToString());
                            aprd.ApprovedQuantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApprovedQuantity"].Value.ToString());
                            aprd.ApproveDuration = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApproveDuration"].Value.ToString());
                            db.ApproveMedicineDetails.Add(aprd);
                            db.SaveChanges();

                        }

                    }


                    var GetReclaim = db.ApproveMedicines.Where(p => p.Id == ApproveNo).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        Saved = true;
                        ApprovementId.Text = "كود التصديق" + ":   " + GetReclaim[0].ApproveCode.ToString();

                    }
                }
            }
            else if (ApproveNo > 0)
            {
                using (dbContext db = new dbContext())
                {
                    var GetAppv = db.ApproveMedicines.Where(p => p.Id == ApproveNo).ToList();
                    //   MessageBox.Show(GetAppv.Count.ToString());
                    if (GetAppv.Count > 0)
                    {
                        GetAppv[0].ReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                        GetAppv[0].ExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                        GetAppv[0].ApproveDate = OperationDate.Value;
                        GetAppv[0].DiagnosisId = Convert.ToInt32(Diagnosis.SelectedValue);
                        GetAppv[0].pharmacistId = Convert.ToInt32(pharmacist.SelectedValue);
                        GetAppv[0].RouchitaNo = Convert.ToInt32(RouchitaNo.Text);
                        GetAppv[0].RowStatus = RowStatus.Edited;
                        GetAppv[0].Atachment = Atachment.Text;
                        db.SaveChanges();
                    }
                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["ServiceId"].Value.ToString());
                        var ChkApr = db.ApproveMedicineDetails.Where(p => p.ApproveMedicineId == ApproveNo && p.ServiceId == ServiceId).ToList();
                        if (ChkApr.Count == 0)
                        {
                            ApproveMedicineDetails aprd = new ApproveMedicineDetails();
                            aprd.ApproveMedicineId = ApproveNo;
                            aprd.ServiceId = ServiceId;
                            aprd.Quantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["Quantity"].Value.ToString());
                            aprd.ApprovedQuantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApprovedQuantity"].Value.ToString());
                            aprd.ApproveDuration = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApproveDuration"].Value.ToString());
                            db.ApproveMedicineDetails.Add(aprd);
                            db.SaveChanges();

                        }
                        else if (ChkApr.Count > 0)
                        {
                            ChkApr[0].ServiceId = ServiceId;
                            ChkApr[0].Quantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["Quantity"].Value.ToString());
                            ChkApr[0].ApprovedQuantity = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApprovedQuantity"].Value.ToString());
                            ChkApr[0].ApproveDuration = Convert.ToInt32(GrdDwa.Rows[i].Cells["ApproveDuration"].Value.ToString());
                            db.SaveChanges();
                        }

                    }


                    var ApproveToday = db.ApproveMedicines.Where(p => p.UserId == UserId && p.ApproveDate == OperationDate.Value).Select(p => new { p.Id, p.InsurName }).ToList();
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
                    db.SaveChanges();
                    FillGrid();
                }
            }

            MessageBox.Show("لقد تم حفظ بيانات التصديق", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(card_no.Text))
            {
                //try
                //{
                this.Cursor = Cursors.WaitCursor;
                if (SubscriberType.SelectedIndex == 0 && !card_no.Text.Contains("/"))
                {
                    if (card_no.Text.Length < 9 || card_no.Text.Length > 11 || card_no.Text.Length == 10)
                    {
                        MessageBox.Show("رقم التأمين المدخل غير صحيح لأن طوله " + card_no.Text.Length, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        card_no.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                using (dbContext db = new dbContext())
                {
                    var sera = db.StopSubsribers.Where(p => p.InsurNo == card_no.Text).Take(1).ToList();
                    if (sera.Count() > 0)
                    {
                        if (sera[0].IsStoped == true)
                        {
                            MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + sera[0].Comment, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    //var ser = dbs.Where(p => p.InsurNo == card_no.Text).Take(1).ToList();
                    //if (ser.Count > 0)
                    //{
                    if (card_no.Text.Length == 9 && !card_no.Text.Contains("/"))
                    {
                        if (PLC.conNew.State == (System.Data.ConnectionState)1)
                        {
                            PLC.conNew.Close();
                        }
                        PLC.conNew.Open();
                        string srr = "select top 1 * from Cards where InsuranceNo=" + card_no.Text + " and RowStatus<>2";
                        SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                        DataTable dtsearch = new DataTable();
                        dtsearch.Clear();
                        dasearch.Fill(dtsearch);
                        if (dtsearch.Rows.Count > 0)
                        {
                            //int Clint = Convert.ToInt32(dtsearch.Rows[0]["ClientId"]);
                            //string Srcl  = "select top 1 * from Contracts where ClientId=" + Clint + " and RowStatus<>2";
                            //SqlDataAdapter daclient = new SqlDataAdapter(Srcl, PLC.conNew);
                            //DataTable dtclient = new DataTable();
                            //dtclient.Clear();
                            //daclient.Fill(dtclient);
                            //if (Convert.ToInt32(dtclient.Rows[0]["contractStatus"]) ==1)
                            //{
                            //    MessageBox.Show("عقد المخدم الذي يتبع له هذا المشترك موقوف :" + (char)13 +"واسم العقد هو" +" " + dtclient.Rows[0]["Description"]+ " " + dtclient.Rows[0]["ClientId"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //    this.Cursor = Cursors.Default;
                            //    return;
                            //}
                            if (Convert.ToInt32(dtsearch.Rows[0]["Status"]) == 1)
                            {
                                MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + dtsearch.Rows[0]["Comment"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    //if (ser[0].IsStoped == false)
                    //{
                    //this.Cursor = Cursors.WaitCursor;
                    //CustName.Text = ser[0].InsurName;
                    //ServerName.Text = ser[0].Server;
                    //Sex.Text = ser[0].Gender;
                    //insurId = ser[0].Id;
                    // Age.Text = DateAndTime.DateDiff(DateInterval.Year, ser[0].BirthDate, PLC.getdate()).ToString();
                    var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.InsurNo == card_no.Text).Select(p => new { p.Reclaim.Id, p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.ReclaimDate, Cost = p.ReclaimCost, Quantity = p.Quantity, ApprovedQuantity = 0, UserName = "", System = "الاسترداد", RequestParty = (int)p.Reclaim.RefMedicalReqCenterId, ExcuteParty = (int)p.Reclaim.RefMedicineExcCenterId, Note = p.Reclaim.Notes, ApproveCode = "0" }).ToList();
                    decimal Cost = 0;
                    DateTime Olddat = PLC.getdate().AddDays(-3);
                    DateTime dat = PLC.getdate();
                    var Frefuse1 = db.RefuseMedicines.Where(p => p.InsurNo == card_no.Text && p.RefuseDate >= Olddat && p.RefuseDate <= dat).ToList();
                    if (Frefuse1.Count() > 0)
                    {
                        // int SubId = Frefuse1[0].InsurId;
                        //FRMRefuseAlert Rfrt = new FRMRefuseAlert();
                        //Rfrt.ShowDialog();
                        var Frf = db.RefuseMedicines.Where(p => p.InsurNo == card_no.Text).ToList();
                        if (Frf.Count() > 0)
                        {
                            int MaxId = db.RefuseMedicines.Where(p => p.InsurNo == card_no.Text).Max(p => p.Id);
                            var Frfd = db.RefuseMedicineDetails.Where(p => p.RefuseId == MaxId).ToList();
                            string str = "1" + Frfd[0].RefuseReason;
                            for (int i = 1; i < Frfd.Count; i++)
                            {
                                str += (char)13 + (i + 1).ToString() + Frfd[0].RefuseReason;
                            }
                            MessageBox.Show("لقد تم رفض التصديق لهذا المشترك بتاريخ" + Frfd[0].RefuseMedicine.RefuseDate.ToShortDateString() + (char)13 + ":" + "للأسباب الآتية" + (char)13 + str, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        }

                    }
                    var Frefuse = db.RefuseMedicines.Where(p => p.InsurNo == card_no.Text).ToList();
                    if (Frefuse.Count() > 0)
                    {
                        FRMpatienthistory.Default.radGridView1.Rows.Clear();
                        for (int i = 0; i < Frefuse.Count(); i++)
                        {
                            int ReqCenId = Frefuse[i].ReqCenterId;
                            int ExcuCenter = Frefuse[i].ExcCenterId;
                            string ReqCenter = db.CenterInfos.Where(p => p.Id == ReqCenId).ToList()[0].CenterName;
                            string ExcCenter = db.CenterInfos.Where(p => p.Id == ExcuCenter).ToList()[0].CenterName;
                            FRMpatienthistory.Default.radGridView1.Rows.Add("عرض", i + 1, Frefuse[i].RefuseDate, ReqCenter, ExcCenter, Frefuse[i].Id);
                        }
                    }
                    var FamHistory = db.ApproveMedicineDetails.Where(p => p.ApproveMedicine.InsurNo == card_no.Text).Select(p => new { p.ApproveMedicine.Id, ReclaimNo = p.ApproveMedicineId.ToString(), ServiceName = p.MedicineForReclaim.Generic_name, ReclaimDate = p.ApproveMedicine.ApproveDate, Cost = Cost, Quantity = p.Quantity, ApprovedQuantity = p.ApprovedQuantity, UserName = p.ApproveMedicine.Pharmacist.pharmacistName, System = "التصديق", RequestParty = p.ApproveMedicine.ReqCenterId, ExcuteParty = p.ApproveMedicine.ExcCenterId, Note = p.ApproveMedicine.Atachment, p.ApproveMedicine.ApproveCode }).ToList();
                    var Funion = FrHistoryMc.Union(FamHistory).ToList();
                    FRMpatienthistory.Default.Grid_service.Rows.Clear();
                    if (Funion.Count() > 0)
                    {
                        var SumCost = Funion.Sum(p => p.Cost);
                        for (int i = 0; i < Funion.Count(); i++)
                        {
                            int ReqCenId = Funion[i].RequestParty;
                            int ExcuCenter = Funion[i].ExcuteParty;
                            string ReqCenter = db.CenterInfos.Where(p => p.Id == ReqCenId).ToList()[0].CenterName;
                            string ExcCenter = db.CenterInfos.Where(p => p.Id == ExcuCenter).ToList()[0].CenterName;
                            FRMpatienthistory.Default.Grid_service.Rows.Add("Show", i + 1, Funion[i].ReclaimNo, Funion[i].ApproveCode, Funion[i].ServiceName, Funion[i].Quantity, Funion[i].ApprovedQuantity, Funion[i].Cost, Funion[i].ReclaimDate.ToShortDateString(), Funion[i].UserName, Funion[i].System, ReqCenter, ExcCenter, Funion[i].Note, Funion[i].Id);
                        }
                        FRMpatienthistory.Default.Totals.Text = SumCost.ToString();
                        if (Funion.Count() > 0 || Frefuse.Count() > 0)
                        {
                            FRMpatienthistory.Default.ShowDialog();
                        }
                        if (card_no.Text.Length == 11)
                        {
                            var FamHistory1 = db.ApproveMedicineDetails.Where(p => p.ApproveMedicine.InsurNo == card_no.Text).Select(p => new { apv = p.ApproveMedicine }).Take(1).ToList();
                            CustName.Text = FamHistory1[0].apv.InsurName;
                            if (FamHistory1[0].apv.Gender.Length > 0)
                            {
                                Gender = FamHistory1[0].apv.Gender;
                            }
                           
                            if (FamHistory1[0].apv.Gender == "ذكر")
                            {
                                Sex.SelectedIndex = 0;
                            }
                            else if (FamHistory1[0].apv.Gender == "انثي")
                            {
                                Sex.SelectedIndex = 1;
                            }
                            else
                            {
                                Sex.SelectedIndex = -1;
                            }
                            BirthDate = FamHistory1[0].apv.BirthDate;
                            Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();
                            Rec_No = FamHistory1[0].apv.ClientId;
                            ServerName.Text = FamHistory1[0].apv.Server;
                            ChkSearch = true;
                            int LocalId = FamHistory1[0].apv.LocalityId;
                            this.Cursor = Cursors.Default;
                            return;
                            // this.AcceptButton = null;
                        }


                    }
                  

                    this.Cursor = Cursors.Default;
                    // return;






                    if (SubscriberType.SelectedIndex == 0)
                    {


                        if (card_no.Text.Contains("/"))
                        {
                            this.Cursor = Cursors.WaitCursor;
                            string str111 = null;
                            str111 = card_no.Text;

                            int leng = str111.Length;
                            string r1 = "";
                            int a1 = 0;
                            for (var i = 1; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r1 = r1 + Ostr;

                                }
                                else
                                {
                                    a1 = i;
                                    break;
                                }
                            }
                            int corNo = 0;
                            int recNo = 0;
                            int cardSer = 0;
                            int cardNo = 0;
                            corNo = Convert.ToInt32(r1);
                            string r2 = "";
                            int a2 = a1 + 1;
                            for (var i = a2; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r2 = r2 + Ostr;

                                }
                                else
                                {
                                    a2 = i;
                                    break;
                                }
                            }
                            recNo = Convert.ToInt32(r2);
                            string r3 = "";
                            int a3 = a2 + 1;
                            for (var i = a3; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r3 = r3 + Ostr;

                                }
                                else
                                {
                                    a3 = i;
                                    break;
                                }
                            }
                            cardSer = Convert.ToInt32(r3);
                            string r4 = "";
                            int a4 = a3 + 1;
                            // messagebox.show(a4)
                            for (var i = a4; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r4 = r4 + Ostr;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            cardNo = Convert.ToInt32(r4);
                            if (PLC.conOld.State == (System.Data.ConnectionState)1)
                            {
                                PLC.conOld.Close();
                            }
                            PLC.conOld.Open();
                            string srr = "select top 1 * from data where cor_no=" + corNo + " and rec_no=" + recNo + " and card_no=" + cardNo + " and card_ser=" + cardSer + "";
                            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conOld);
                            DataTable dtsearch = new DataTable();
                            dtsearch.Clear();
                            dasearch.Fill(dtsearch);
                            if (dtsearch.Rows.Count > 0)
                            {
                                if (dtsearch.Rows[0]["STOP_CARD"] != null)
                                {
                                    DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                                }
                                // MsgBox(date1.Date)
                                string stri1 = null;
                                string str2 = null;
                                if (Convert.IsDBNull(dtsearch.Rows[0]["name_3"]) == false)
                                {
                                    stri1 = Convert.ToString(dtsearch.Rows[0]["name_3"]).Trim(' ');
                                }
                                else
                                {
                                    stri1 = ".";
                                }
                                if (Convert.IsDBNull(dtsearch.Rows[0]["name_4"]) == false)
                                {
                                    str2 = Convert.ToString(dtsearch.Rows[0]["name_4"]).Trim(' ');
                                }
                                else
                                {
                                    str2 = ".";
                                }
                                CustName.Text = Convert.ToString(dtsearch.Rows[0]["name_1"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["name_2"]).Trim() + " " + stri1 + " " + str2;
                                Gender = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();
                                if (Convert.ToString(dtsearch.Rows[0]["sex"]).Trim() == "ذكر")
                                {
                                    Sex.SelectedIndex = 0;
                                }
                                else if (Convert.ToString(dtsearch.Rows[0]["sex"]).Trim() == "انثي")
                                {
                                    Sex.SelectedIndex = 1;
                                }
                                else
                                {
                                    Sex.SelectedIndex = -1;
                                }

                                if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                                {
                                    Phone = dtsearch.Rows[0]["phone"].ToString();
                                }
                                else
                                {
                                    Phone = "";
                                }
                                //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                BirthDate = Convert.ToDateTime(dtsearch.Rows[0]["birth_date"]);
                                Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();
                                //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                Rec_No = corNo.ToString() + "/" + recNo.ToString();
                                string serv = "select top 1 * from corpration where cor_no=" + corNo + " and rec_no=" + recNo + "";
                                SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conOld);
                                DataTable dtServ = new DataTable();
                                dtServ.Clear();
                                DaServ.Fill(dtServ);
                                if (dtServ.Rows.Count > 0)
                                {
                                    ServerName.Text = dtServ.Rows[0]["COR_NAME"].ToString();
                                }
                                int LocalId = Convert.ToInt32(dtsearch.Rows[0]["L_PR_NO"].ToString());
                                DateTime StopCard;
                                if (Information.IsDBNull(dtsearch.Rows[0]["STOP_CARD"]) == false)
                                {
                                    StopCard = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                                }
                                else
                                {
                                    StopCard = new DateTime(1900, 1, 1);
                                }

                                this.AcceptButton = null;
                                PLC.conOld.Close();

                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (card_no.Text.Length == 9 && !card_no.Text.Contains("/"))
                        {
                            if (PLC.conNew.State == (System.Data.ConnectionState)1)
                            {
                                PLC.conNew.Close();
                            }
                            PLC.conNew.Open();
                            string srr = "select top 1 * from Cards where InsuranceNo=" + card_no.Text + " and RowStatus<>2";
                            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                            DataTable dtsearch = new DataTable();
                            dtsearch.Clear();
                            dasearch.Fill(dtsearch);
                            if (dtsearch.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtsearch.Rows[0]["Status"]) == 1)
                                {
                                    MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + dtsearch.Rows[0]["Comment"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    this.Cursor = Cursors.Default;
                                    return;
                                }
                                this.Cursor = Cursors.WaitCursor;
                                //DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                                // MsgBox(date1.Date)
                                string stri1 = null;
                                string str2 = null;
                                if (Convert.IsDBNull(dtsearch.Rows[0]["Thirdname"]) == false)
                                {
                                    stri1 = dtsearch.Rows[0]["Thirdname"].ToString().Trim();
                                }
                                else
                                {
                                    stri1 = ".";
                                }
                                if (Convert.IsDBNull(dtsearch.Rows[0]["Fourthname"]) == false)
                                {
                                    str2 = dtsearch.Rows[0]["Fourthname"].ToString().Trim();
                                }
                                else
                                {
                                    str2 = ".";
                                }
                                CustName.Text = Convert.ToString(dtsearch.Rows[0]["Firstname"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["Secondname"]).Trim() + " " + stri1 + " " + str2;
                                string str = dtsearch.Rows[0]["Gender"].ToString();
                                if (str == "1")
                                {
                                    Sex.SelectedIndex = 1;
                                }
                                else
                                {
                                    Sex.SelectedIndex = 0;
                                }


                                if (Convert.IsDBNull(dtsearch.Rows[0]["Phone"]) == false)
                                {
                                    Phone = dtsearch.Rows[0]["Phone"].ToString();
                                }
                                else
                                {
                                    Phone = "";
                                }
                                //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                BirthDate = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                                Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();
                                //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                Rec_No = dtsearch.Rows[0]["ClientId"].ToString();
                                string serv = "select top 1 * from Clients where Id=" + Convert.ToInt32(Rec_No) + "";
                                SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                                DataTable dtServ = new DataTable();
                                dtServ.Clear();
                                DaServ.Fill(dtServ);
                                if (dtServ.Rows.Count > 0)
                                {
                                    ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                                }
                                int LocalId = Convert.ToInt32(dtsearch.Rows[0]["LocalityId"]);
                                DateTime StopCard;
                                if (Information.IsDBNull(dtsearch.Rows[0]["ExDate"]) == false)
                                {
                                    StopCard = Convert.ToDateTime(dtsearch.Rows[0]["ExDate"]);
                                }
                                else
                                {
                                    StopCard = new DateTime(1900, 1, 1);
                                }
                                this.AcceptButton = null;
                                PLC.conOld.Close();
                                //Subscriber Sc = new Subscriber();
                                //Sc.PhoneNo = Phone;
                                //Sc.InsurNo = card_no.Text.Trim();
                                //Sc.InsurName = CustName.Text;
                                //Sc.Gender = Sex.Text;
                                //Sc.Server = ServerName.Text;
                                //Sc.ClientId = ClientId.ToString();
                                //Sc.BirthDate = BirthDate;
                                //Sc.localityId = LocalId;
                                //Sc.IsStoped = false;
                                //Sc.StopCard = StopCard;
                                //dbs.Add(Sc);
                                //db.SaveChanges();
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        else if (card_no.Text.Length == 11 && !card_no.Text.Contains("/"))
                        {

                            this.Cursor = Cursors.WaitCursor;
                            SqlConnection conNat = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=card_natoinal;User ID=sa;Password=123;Trusted_Connection=False");
                            if (conNat.State == ConnectionState.Open)
                            {
                                conNat.Close();
                            }

                            conNat.Open();

                            SqlDataAdapter dNat = new SqlDataAdapter("select top 1 * from NationalCard where InsuranceNo=" + Convert.ToDouble(card_no.Text) + "", conNat);

                            DataTable dtNat = new DataTable();

                            dtNat.Clear();

                            dNat.Fill(dtNat);

                            if (dtNat.Rows.Count > 0)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                ChkSearch = true;
                                BirthDate = Convert.ToDateTime(dtNat.Rows[0]["BirthDate"]);
                                Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();

                                // Phone.Text = result.phone

                                CustName.Text = (dtNat.Rows[0]["FullName"]).ToString();


                                Gender = (dtNat.Rows[0]["Gender"]).ToString();
                                if ((dtNat.Rows[0]["Gender"]).ToString() == "ذكر")
                                {
                                    Sex.SelectedIndex = 0;
                                }
                                else if ((dtNat.Rows[0]["Gender"]).ToString() == "انثي")
                                {
                                    Sex.SelectedIndex = 1;
                                }
                                else
                                {
                                    Sex.SelectedIndex = -1;
                                }

                                Rec_No = (dtNat.Rows[0]["Stateid"]).ToString();


                                ServerName.Text = (dtNat.Rows[0]["StateName"]).ToString();
                                //Subscriber Sc = new Subscriber();
                                //Sc.InsurNo = card_no.Text.Trim();
                                //Sc.InsurName = CustName.Text;
                                //Sc.Gender = Gender;
                                //Sc.Server = ServerName.Text;
                                //Sc.ClientId = ClientId.ToString();
                                //Sc.BirthDate = BirthDate;
                                //Sc.LocalityId = PLC.LocalityId;
                                //Sc.IsStoped = false;
                                //dbs.Add(Sc);
                                //db.SaveChanges();
                                this.Cursor = Cursors.Default;

                            }
                            else
                            {
                                var ChkN = db.ApproveMedicines.Where(p => p.InsurNo == card_no.Text).Take(1).ToList();
                                if (ChkN.Count() > 0)
                                {
                                    ChkSearch = true;
                                    BirthDate = ChkN[0].BirthDate;
                                    Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();

                                    // Phone.Text = result.phone

                                    CustName.Text = ChkN[0].InsurName;


                                    Gender = ChkN[0].Gender;
                                    Sex.Text = Gender;
                                    Rec_No = ChkN[0].ClientId;


                                    ServerName.Text = ChkN[0].Server;
                                }
                                else
                                {
                                    ChkSearch = false;
                                    MessageBox.Show("لا توجد بيانات لهذا المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.None);

                                    this.AcceptButton = null;

                                    this.Cursor = Cursors.Default;
                                }
                            }
                            ////else
                            ////{
                            ////    WebReference.CrService Getinfo = new WebReference.CrService();

                            ////    string Str11 = Getinfo.GetNifData(TXTSearch.Text);

                            ////    // MsgBox(Str11)

                            ////    string str = Str11.Replace("\"\"[", "").ToString();

                            ////    string str1 = str.Replace("]\"\"", "").ToString();

                            ////    string str3 = str1.ToString().Replace("\\", "");

                            ////    string str4 = str3.ToString().Replace("\\", "");

                            ////    string str6 = str4.Replace("\"[{", "{").ToString();

                            ////    string str7 = str6.Replace("}]\"", "}").ToString();

                            ////    if (Convert.IsDBNull(str7) == true)
                            ////    {

                            ////        str7 = null;

                            ////    }


                            ////    if (str7 == "\"[]\"")
                            ////    {

                            ////        str7 = null;

                            ////    }

                            ////    //dim obj as JObject = JObject.Parse(str).tostring

                            ////    //dim d = JArray.Parse(obj(0)).tostring


                            ////    //MessageBox.Show(str7)            

                            ////    if (!(string.IsNullOrEmpty(str7)))
                            ////    {

                            ////        var result = JsonConvert.DeserializeObject<Class2>(str7);

                            ////        //Dim strDay As String = Mid(result.BirthDate, 1, 2)

                            ////        //Dim strMonth As String = Mid(result.BirthDate, 4, 2)

                            ////        //Dim strYear As String = Mid(result.BirthDate, 7, 2)

                            ////        // str1 = strYear & "/" & strMonth & "/" & strDay

                            ////        // BirthDate.Value = New DateTime(Convert.ToInt32(strYear), Convert.ToInt32(strMonth), Convert.ToInt32(strDay))

                            ////        BirthDate.Value = JsonConvert.DeserializeObject<Class2>(str7).BirthDate;

                            ////        int ag = Convert.ToInt32(Simulate.DateDiff(Simulate.DateInterval.Year, BirthDate.Value, getdate));

                            ////        if (ag > 0)
                            ////        {

                            ////            LblAge.Text = ag.ToString();

                            ////        }
                            ////        else
                            ////        {

                            ////            LblAge.Text = "1";

                            ////        }

                            ////        // Phone.Text = result.phone

                            ////        Address.Text = result.StateName;

                            ////        FulName.Text = result.FullName;

                            ////        if (result.Gender == "True")
                            ////        {

                            ////            Gender.Text = "ذكر";

                            ////        }
                            ////        else
                            ////        {

                            ////            Gender.Text = "انثى";

                            ////        }


                            ////        Server = "الصندوق القومي";

                            ////        this.Cursor = Cursors.Default;

                            ////    }
                            ////    else
                            ////    {

                            ////        MessageBox.Show("لا توجد بيانات لهذا المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.None);

                            ////        this.AcceptButton = null;

                            ////        this.Cursor = Cursors.Default;

                            ////        return;

                            ////    }

                            //}
                        }
                    }




                    else
                    {
                        var ChkN = db.ApproveMedicines.Where(p => p.InsurNo == card_no.Text).Take(1).ToList();
                        if (ChkN.Count() > 0)
                        {
                            ChkSearch = true;
                            BirthDate = ChkN[0].BirthDate;
                            Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();

                            // Phone.Text = result.phone

                            CustName.Text = ChkN[0].InsurName;


                            Gender = ChkN[0].Gender;
                            Sex.Text = Gender;
                            Rec_No = ChkN[0].ClientId;


                            ServerName.Text = ChkN[0].Server;
                        }
                        //else
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    FRMAddStudent.Default.card_no.Text = card_no.Text;
                        //    FRMAddStudent.Default.ful_name.Clear();
                        //    FRMAddStudent.Default.Age.Clear();
                        //    FRMAddStudent.Default.Sex.SelectedIndex = -1;
                        //    FRMAddStudent.Default.University.SelectedIndex = -1;
                        //    FRMAddStudent.Default.ShowDialog();
                        //}
                    }
                }
            }



            //}
            //        catch (Exception ex)
            //{

            //    MessageBox.Show("توجد مشلكلة في جلب البيانات" + (char)13 + "تأكد من الرقم الصحيح" + (char)13 + ex.Message, "النظام", MessageBoxButtons.OK, MessageBoxIcon.None);

            //    this.AcceptButton = null;

            //    this.Cursor = Cursors.Default;

            //    return;

            //}

        }

        private void dwalist_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (dwalist.ContainsFocus)
                {
                    ServiceId = Convert.ToInt32(dwalist.SelectedValue);
                    using (dbContext db = new dbContext())
                    {
                        var Fdwa = db.Medicines.Where(p => p.Id == ServiceId).ToList();
                        if (Fdwa.Count > 0)
                        {
                            if (Convert.IsDBNull(Fdwa[0].NOTE.ToString()) == false)
                            {
                                if (Fdwa[0].NOTE.ToString() != "")
                                {
                                    MessageBox.Show("Note :" + (char)13 + Fdwa[0].NOTE.ToString(), "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                ServiceId = 0;
                return;
            }
        }
        public void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ApproveMedicineDetails.Where(p => p.ApproveMedicineId == ApproveNo).Select(p => new { p.Id, p.MedicineForReclaim.Generic_name, p.ServiceId, p.Quantity, p.ApprovedQuantity, p.ApproveDuration }).ToList();
                //GrdDwa.DataSource = FrefMl;
                GrdDwa.Rows.Clear();
                if (FrefMl.Count > 0)
                {
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdDwa.Rows.Add(i + 1, FrefMl[i].Generic_name, FrefMl[i].Quantity, FrefMl[i].ApprovedQuantity, FrefMl[i].Id, FrefMl[i].ServiceId, FrefMl[i].ApproveDuration);
                    }


                }
            }
        }
        private void NewMedical()
        {
            dwalist.SelectedIndex = -1;
            quantity.Clear();
            ApprovedQuantity.Clear();
            dwalist.Focus();
            ApproveDuration.Clear();

        }
        private void FRMmedicine_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;

            LoadData();

            using (dbContext db = new dbContext())
            {

                var pharm = db.Pharmacists.Where(p => p.Activated == 1 && p.Id > 0).ToList();
                pharmacist.DataSource = pharm;
                pharmacist.DisplayMember = "pharmacistName";
                pharmacist.ValueMember = "Id";
                pharmacist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                pharmacist.SelectedIndex = -1;
                var diagnos = db.Diagnoses.Where(p => p.Activated == 1 && p.Id > 0).ToList();
                Diagnosis.DataSource = diagnos;
                Diagnosis.DisplayMember = "DiagnosisName";
                Diagnosis.ValueMember = "Id";
                Diagnosis.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                Diagnosis.SelectedIndex = -1;
                var ReqCenter = db.CenterInfos.Where(p => (p.CenterTypeId == CenterType.مركز || p.CenterTypeId == CenterType.مركزوصيدلية) && p.HasContract == true && p.IsVisible == true && p.Id > 0).ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;

                var ExcCenter = db.CenterInfos.Where(p => (p.CenterTypeId == CenterType.صيدلية || p.CenterTypeId == CenterType.مركزوصيدلية) && p.HasContract == true && p.IsVisible == true && p.Id > 0).ToList();
                ExcutingParty.DataSource = ExcCenter;
                ExcutingParty.ValueMember = "Id";
                ExcutingParty.DisplayMember = "CenterName";
                ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ExcutingParty.SelectedIndex = -1;

                var EngSer = db.MedicineForReclaims.Where(p => p.InContract == true && p.IsVisible == true && p.Id > 0).ToList();
                dwalist.DataSource = EngSer;
                dwalist.ValueMember = "Id";
                dwalist.DisplayMember = "Generic_name";
                dwalist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                dwalist.SelectedIndex = -1;
                var GetReason = db.ApproveMedicineTypes.Where(p => p.Activated == 1 && p.Id > 0).ToList();
                ApproveType.DataSource = GetReason;
                ApproveType.ValueMember = "Id";
                ApproveType.DisplayMember = "ApproveType";
                //ApproveType.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ApproveType.SelectedIndex = -1;
                // Diagnosis.DataSource = Enum.GetValues(typeof(ReclaimStatus));




            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (RouchitaNo.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال رقم الروشتة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RouchitaNo.Focus();
                return;
            }
            if (ApproveType.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار سبب التصديق", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ApproveType.Focus();
                return;
            }
            if (pharmacist.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار اسم الصيدلي", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pharmacist.Focus();
                return;
            }
            if (Diagnosis.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار التشخيص", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Diagnosis.Focus();
                return;
            }
            if (RequistingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار المركز المقدم للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequistingParty.Focus();
                return;
            }
            if (ExcutingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الصيدلية المقدمة للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExcutingParty.Focus();
                return;
            }
            if (ExcutingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الصيدلية المقدمة للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExcutingParty.Focus();
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
                MessageBox.Show("يجب ادخال كمية الدواء المطلوبة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity.Focus();
                return;
            }
            if (ApprovedQuantity.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال كمية الدواء المصدقة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ApprovedQuantity.Focus();
                return;
            }
            if (Convert.ToInt32(ApproveType.SelectedValue.ToString()) == 1)
            {
                if (ApproveDuration.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال مدة التصديق", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ApprovedQuantity.Focus();
                    return;
                }
            }
            else
            {
                ApproveDuration.Text = "0";
            }

            using (dbContext db = new dbContext())
            {
                // var ChkSub = dbs.Where(p => p.InsurNo == card_no.Text).ToList();
                if (SubscriberType.SelectedIndex == 0 && ChkSearch == false && card_no.Text.Length == 11 && !card_no.Text.Contains("/"))
                {
                    if (CustName.Text.Length == 0)
                    {
                        MessageBox.Show(" يجب ادخال اسم المشترك يدويا ان لم يوجد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CustName.Focus();
                        return;
                    }
                    if (Age.Text.Length == 0)
                    {
                        MessageBox.Show("يجب ادخال عمر المشترك يدويا ان لم يوجد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Age.Focus();
                        return;
                    }
                    if (Sex.SelectedIndex == -1)
                    {
                        MessageBox.Show("يجب اختيار نوع المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Sex.Focus();
                        return;
                    }
                    SqlConnection conNat = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=card_natoinal;User ID=sa;Password=123;Trusted_Connection=False");
                    if (conNat.State == ConnectionState.Open)
                    {
                        conNat.Close();
                    }
                    int ClientId = Convert.ToInt32(card_no.Text.Substring(0, 2));
                    Rec_No = ClientId.ToString();
                    conNat.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * FROM [card_natoinal].[dbo].[States] where StateId=" + ClientId + "", conNat);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ServerName.Text = dt.Rows[0]["StateName"].ToString();
                    }
                    BirthDate = PLC.getdate().AddYears(-Convert.ToInt32(Age.Text));

                    //Subscriber Sc = new Subscriber();
                    //Sc.PhoneNo = "";
                    //Sc.InsurNo = card_no.Text.Trim();
                    //Sc.InsurName = CustName.Text;
                    //Sc.Gender = Sex.Text;
                    //Sc.Server = ServerName.Text;
                    //Sc.ClientId = ClientId.ToString();
                    //Sc.BirthDate = Birthdate;
                    //Sc.LocalityId = PLC.LocalityId;
                    //Sc.IsStoped = false;
                    //Sc.StopCard = new DateTime(1900, 1, 1);
                }
                //dbs.Add(Sc);
                //db.SaveChanges();
            }
            if (GrdDwa.RowCount == 0)
            {

                GrdDwa.Rows.Add(GrdDwa.RowCount + 1, dwalist.Text, quantity.Text, ApprovedQuantity.Text, "0", dwalist.SelectedValue.ToString(), ApproveDuration.Text);
            }
            else
            {

                for (int i = 0; i < GrdDwa.RowCount; i++)
                {
                    if (GrdDwa.Rows[i].Cells["Generic_name"].Value.ToString() == dwalist.Text)
                    {
                        return;
                    }
                }
                GrdDwa.Rows.Add(GrdDwa.RowCount + 1, dwalist.Text, quantity.Text, ApprovedQuantity.Text, "0", dwalist.SelectedValue.ToString(), ApproveDuration.Text);

            }
            NewMedical();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdDwa.RowCount > 0)
            {
                int ReclaimMedId = 0;
                if (Convert.IsDBNull(GrdDwa.CurrentRow.Cells["Id"].Value) == false)
                {
                    ReclaimMedId = Convert.ToInt32(GrdDwa.CurrentRow.Cells["Id"].Value);
                }

                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات هذا الدواء", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    if (ReclaimMedId > 0)
                    {
                        using (dbContext db = new dbContext())
                        {
                            var GetMed = db.ApproveMedicineDetails.Where(p => p.Id == ReclaimMedId).ToList();
                            if (GetMed.Count > 0)
                            {
                                db.ApproveMedicineDetails.Remove(GetMed[0]);
                                db.SaveChanges();
                                GrdDwa.Rows.RemoveAt(GrdDwa.CurrentRow.Index);
                            }
                        }
                    }
                    else
                    {
                        GrdDwa.Rows.RemoveAt(GrdDwa.CurrentRow.Index);
                    }
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
                a = MessageBox.Show("سوف يتم حذف بيانات التصديق المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ApproveMedicines.Where(p => p.Id == ApproveNo).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        GetReclaim[0].RowStatus = RowStatus.Deleted;
                        GetReclaim[0].DeleteDate = OperationDate.Value;
                        GetReclaim[0].UserDeleted = UserId;
                        db.Database.ExecuteSqlCommand("delete from ApproveMedicineDetails where ApproveMedicineId=" + ApproveNo + "");
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
            if (ApprovedQuantity.Text.Length > 0 && quantity.Text.Length > 0)
            {
                if (int.Parse(ApprovedQuantity.Text) > int.Parse(quantity.Text))
                {
                    ApprovedQuantity.Text = quantity.Text;
                    MessageBox.Show("الكمية المصدقة أكبر من الكمية المطلوبة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {


        }

        private void RouchitaNo_KeyPress(object sender, KeyPressEventArgs e)
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
                    ApproveNo = Convert.ToInt32(e.Row.Cells["Id"].Value);
                    if (GrdDailyWork.CurrentColumn.Name == "Show")
                    {
                        var GetApp = db.ApproveMedicines.Where(p => p.Id == ApproveNo && p.RowStatus != RowStatus.Deleted).ToList();
                        if (GetApp.Count() > 0)
                        {
                            card_no.Text = GetApp[0].InsurNo;
                            OperationDate.Value = GetApp[0].ApproveDate;
                            RouchitaNo.Text = GetApp[0].RouchitaNo.ToString();
                            Sex.Text = GetApp[0].Gender;
                            CustName.Text = GetApp[0].InsurName;
                            ServerName.Text = GetApp[0].Server;
                            RequistingParty.SelectedValue = GetApp[0].ReqCenterId;
                            ExcutingParty.SelectedValue = GetApp[0].ExcCenterId;
                            Diagnosis.SelectedValue = GetApp[0].DiagnosisId;
                            pharmacist.SelectedValue = GetApp[0].pharmacistId;
                            ApproveType.SelectedValue = GetApp[0].ApproveTypeId;
                            Atachment.Text = GetApp[0].Atachment;
                            Age.Text = DateAndTime.DateDiff(DateInterval.Year, GetApp[0].BirthDate, PLC.getdate()).ToString();
                            Saved = true;
                            ApprovementId.Text = "كود التصديق" + ":   " + GetApp[0].ApproveCode.ToString();
                            FillGrid();
                        }
                    }
                }
            }
        }

        private void GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void GrdDwa_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GrdDwa.RowCount > 0)
            {
                int ApvQuantity = Convert.ToInt32(e.Row.Cells["ApprovedQuantity"].Value.ToString());
                if (ApvQuantity > Convert.ToInt32(e.Row.Cells["Quantity"].Value.ToString()))
                {
                    e.Row.Cells["ApprovedQuantity"].Value = e.Row.Cells["Quantity"].Value;
                    MessageBox.Show("الكمية المصدقة أكبر من الكمية المطلوبة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void ApproveReason_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void Card_no_GotFocus(object sender, EventArgs e)
        {

        }

        private void Card_no_TextChanged(object sender, EventArgs e)
        {
            if (card_no.Text.Length > 0)
            {
                this.AcceptButton = BTNSearch;
            }
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (CustName.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            FRMStopSubscriber.Default.card_no.Text = card_no.Text;
            FRMStopSubscriber.Default.ful_name.Text = CustName.Text;
            FRMStopSubscriber.Default.ShowDialog();
        }

        private void RadButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void ApproveType_GotFocus(object sender, EventArgs e)
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

        private void CustName_Leave(object sender, EventArgs e)
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

        private void RouchitaNo_Leave(object sender, EventArgs e)
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

        private void Pharmacist_Leave(object sender, EventArgs e)
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

        private void ApprovedQuantity_Leave(object sender, EventArgs e)
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

        private void ApproveDuration_Leave(object sender, EventArgs e)
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

        private void RadButton2_Click(object sender, EventArgs e)
        {
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (RequistingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار المركز المقدم للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequistingParty.Focus();
                return;
            }
            if (ExcutingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الصيدلية المقدمة للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExcutingParty.Focus();
                return;
            }
            FrmRefuseMedicine Fr = new FrmRefuseMedicine();
            Fr.ApproveId = 0;
            Fr.ReqId = Convert.ToInt32(RequistingParty.SelectedValue);
            Fr.ExcuId = Convert.ToInt32(ExcutingParty.SelectedValue);
            Fr.Phone = Phone;
            Fr.CustName = CustName.Text;
            Fr.Sex = Sex.Text;
            Fr.ServerName = ServerName.Text;
            Fr.BirthDate = BirthDate;
            Fr.Rec_No = Rec_No;
            using (dbContext db = new dbContext())
            {
                //var ChkSub = dbs.Where(p => p.InsurNo == card_no.Text).ToList();
                //if (SubscriberType.SelectedIndex == 0 && ChkSub.Count == 0 && card_no.Text.Length == 11 && !card_no.Text.Contains("/"))
                //{
                if (CustName.Text.Length == 0)
                {
                    MessageBox.Show(" يجب ادخال اسم المشترك يدويا ان لم يوجد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CustName.Focus();
                    return;
                }
                if (Age.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال عمر المشترك يدويا ان لم يوجد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Age.Focus();
                    return;
                }
                if (Sex.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار نوع المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Sex.Focus();
                    return;
                }
                SqlConnection conNat = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=card_natoinal;User ID=sa;Password=123;Trusted_Connection=False");
                if (conNat.State == ConnectionState.Open)
                {
                    conNat.Close();
                }
                int ClientId = Convert.ToInt32(card_no.Text.Substring(0, 2));

                conNat.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * FROM [card_natoinal].[dbo].[States] where StateId=" + ClientId + "", conNat);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ServerName.Text = dt.Rows[0]["StateName"].ToString();
                }
                conNat.Close();
                db.SaveChanges();



                // var FId = dbs.Where(p => p.InsurNo == card_no.Text).ToList()[0].Id;
                Fr.InsurId = card_no.Text;
            }
            Fr.ShowDialog();
        }

        private void GrdDwa_Click(object sender, EventArgs e)
        {

        }
    }
}
