
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
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using MedicalServiceSystem.SystemSetting;
using ModelDB;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMBookInfo : Telerik.WinControls.UI.RadForm
    {
        public FRMBookInfo()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMBookInfo defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMBookInfo Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMBookInfo();
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
        public int flag = 0;
        public bool Saved = false;
        public DateTime BirthDate = PLC.getdate();
        public string Rec_No = "";
        private void LoadData()
        {
            flag = 0;
            SubscriberType.SelectedIndex = 0;
            Age.Clear();
            Sex.Text = "";
            GrdDwa.DataSource = null;
            CustName.Clear();
            BirthDate = PLC.getdate();
            ChronicLst.SelectedIndex = -1;
            BookDate.Value = PLC.getdate();
            ServerName.Clear();
            PhoneNo.Clear();
            Notes.Clear();
            DocumentNo.Clear();
            BookType.SelectedIndex = -1;
            RequistingParty.SelectedIndex = -1;
            BookNo.Clear();
            GrdDwa.Rows.Clear();
            card_no.Clear();
            card_no.Focus();
            ApproveNo = 0;
            insurId = 0;
            Saved = false;
            using (dbContext db = new dbContext())
            {
                var ApproveToday = db.ChronicsBooks.Where(p => p.UserId == UserId && p.BookDate == BookDate.Value && p.RowStatus != RowStatus.Deleted).Select(p => new { p.Id, p.InsurName }).ToList();
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
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (BookNo.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال رقم الدفتر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BookNo.Focus();
                return;
            }
            if (BookType.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار نوع العملية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BookType.Focus();
                return;

            }
            else if (BookType.SelectedIndex == 0)
            {
                using (dbContext db = new dbContext())
                {
                    var Fhis = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.RowStatus != RowStatus.Deleted).ToList();
                    if (Fhis.Count > 0)
                    {
                        if (flag == 0)
                        {

                            BookType.SelectedIndex = 1;

                        }
                    }
                }

            }


            if (RequistingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار المركز الذي كتب فيه التشخيص", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequistingParty.Focus();
                return;
            }
            if (GrdDwa.RowCount == 0)
            {
                MessageBox.Show("لا توجد بيانات لأمراض مزمنة مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            if (flag == 0)
            {
                using (dbContext db = new dbContext())
                {
                    int bkNo = Convert.ToInt32(BookNo.Text);
                    //int DcNo = Convert.ToInt32(DocumentNo.Text);
                    var Fhis1 = db.ChronicsBooks.Where(p => p.BookNo == bkNo && p.RowStatus != RowStatus.Deleted).ToList();
                    if (Fhis1.Count > 0)
                    {

                        MessageBox.Show("رقم الدفتر مكرر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        BookNo.Clear();
                        BookNo.Focus();
                        return;
                    }
                    //var Fhis2 = db.ChronicsBooks.Where(p => p.DocNo == DcNo && p.RowStatus != RowStatus.Deleted).ToList();
                    //if (Fhis2.Count > 0)
                    //{

                    //    MessageBox.Show("لا يمكن اضافة تشخيص رقم الايصال مكرر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    DocumentNo.Clear();
                    //    DocumentNo.Focus();
                    //    return;
                    //}
                }
            }

            if (ApproveNo == 0)
            {
                using (dbContext db = new dbContext())
                {

                    // insurId = dbs.Where(p => p.InsurNo == card_no.Text).First().Id;
                    var Fhis1 = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.RowStatus != RowStatus.Deleted).ToList();
                    if (Fhis1.Count > 0)
                    {

                        int MaxBookId = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.RowStatus != RowStatus.Deleted).Max(p => p.Id);
                        var FId = db.ChronicsBooks.Where(p => p.Id == MaxBookId).ToList();
                        DateTime Date1 = FId[0].EndDate;
                        if (BookDate.Value < Date1)
                        {
                            DialogResult a = 0;
                            a = MessageBox.Show("المشترك   " + FId[0].InsurName + (char)13 + "لديه دفتر ساري بالرقم   " + FId[0].BookNo + (char)13 + "وتاريخ الدفتر هو  " + FId[0].BookDate + (char)13 + "هل تريد متابعة الاجراء", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                            if (a == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    ChronicsBooks apv = new ChronicsBooks();
                    apv.CenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                    apv.BookDate = BookDate.Value;
                    apv.EndDate = BookDate.Value.AddMonths(11);
                    apv.BookTypeId = Convert.ToInt32(BookType.SelectedValue);
                    apv.BookNo = Convert.ToInt32(BookNo.Text);
                    apv.UserId = UserId;
                    apv.LocalityId = PLC.LocalityId;
                    apv.DateIn = BookDate.Value;
                    apv.RowStatus = RowStatus.NewRow;
                    apv.DocNo = Convert.ToDecimal(DocumentNo.Text);
                    apv.Status = Status.Active;
                    apv.Notes = Notes.Text.Trim();
                    apv.LocalityId = PLC.LocalityId;
                    apv.PhoneNo = PhoneNo.Text;
                    apv.InsurNo = card_no.Text;
                    apv.InsurName = CustName.Text;
                    apv.Gender = Sex.Text;
                    apv.Server = ServerName.Text;
                    apv.ClientId = Rec_No;
                    apv.BirthDate = BirthDate;
                    db.ChronicsBooks.Add(apv);
                    db.SaveChanges();
                    Saved = true;
                    ApproveNo = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.UserId == UserId).Max(p => p.Id);

                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["ChronicId"].Value.ToString());
                        var ChkApr = db.ChronicBooksDetails.Where(p => p.BookId == ApproveNo && p.ChronicId == ServiceId).ToList();
                        if (ChkApr.Count == 0)
                        {
                            ChronicBooksDetails aprd = new ChronicBooksDetails();
                            aprd.BookId = ApproveNo;
                            aprd.ChronicId = ServiceId;
                            db.ChronicBooksDetails.Add(aprd);
                            db.SaveChanges();

                        }

                    }

                }
            }
            else if (ApproveNo > 0)
            {
                using (dbContext db = new dbContext())
                {
                    var GetAppv = db.ChronicsBooks.Where(p => p.Id == ApproveNo).ToList();
                    //   MessageBox.Show(GetAppv.Count.ToString());
                    if (GetAppv.Count > 0)
                    {
                        //    GetAppv[0]Id = insurId;
                        GetAppv[0].CenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                        GetAppv[0].BookDate = BookDate.Value;
                        GetAppv[0].EndDate = BookDate.Value.AddMonths(11);
                        GetAppv[0].BookTypeId = Convert.ToInt32(BookType.SelectedValue);
                        GetAppv[0].BookNo = Convert.ToInt32(BookNo.Text);
                        GetAppv[0].UpdateUser = UserId;
                        GetAppv[0].LocalityId = PLC.LocalityId;
                        GetAppv[0].DateIn = BookDate.Value;
                        GetAppv[0].DocNo = Convert.ToDecimal(DocumentNo.Text);
                        GetAppv[0].RowStatus = RowStatus.Edited;
                        GetAppv[0].Status = Status.Active;
                        GetAppv[0].Notes = Notes.Text.Trim();
                        db.SaveChanges();
                        Saved = true;

                    }
                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        ServiceId = Convert.ToInt32(GrdDwa.Rows[i].Cells["ChronicId"].Value.ToString());
                        var ChkApr = db.ChronicBooksDetails.Where(p => p.BookId == ApproveNo && p.ChronicId == ServiceId).ToList();
                        if (ChkApr.Count == 0)
                        {
                            ChronicBooksDetails aprd = new ChronicBooksDetails();
                            aprd.BookId = ApproveNo;
                            aprd.ChronicId = ServiceId;
                            db.ChronicBooksDetails.Add(aprd);
                            db.SaveChanges();

                        }
                        else if (ChkApr.Count > 0)
                        {
                            ChkApr[0].BookId = ApproveNo;
                            ChkApr[0].ChronicId = ServiceId;
                            db.SaveChanges();
                        }

                    }
                }
               
            }

            MessageBox.Show("لقد تم حفظ بيانات الدفتر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (dbContext db = new dbContext())
            {
                DateTime dat = PLC.getdate().Date;
                var ApproveToday = db.ChronicsBooks.Where(p => p.UserId == UserId && p.BookDate == dat).Select(p => new { p.Id, p.InsurName }).ToList();
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

            }

        }


        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (!string.IsNullOrEmpty(card_no.Text))
            {
                using (dbContext db = new dbContext())
                {
                    var ser = db.StopSubsribers.Where(p => p.InsurNo == card_no.Text).Take(1).ToList();
                    if (ser.Count > 0)
                    {
                        if (ser[0].IsStoped == true)
                        {
                            MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Comment, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
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
                            //string Srcl = "select top 1 * from Contracts where ClientId=" + Clint + " and RowStatus<>2";
                            //SqlDataAdapter daclient = new SqlDataAdapter(Srcl, PLC.conNew);
                            //DataTable dtclient = new DataTable();
                            //dtclient.Clear();
                            //daclient.Fill(dtclient);
                            //if (Convert.ToInt32(dtclient.Rows[0]["contractStatus"]) == 1)
                            //{
                            //  MessageBox.Show(dtsearch.Rows[0]["Status"].ToString(), "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //    this.Cursor = Cursors.Default;
                            //    return;
                            //}
                            if (Convert.ToInt32(dtsearch.Rows[0]["Status"].ToString()) == 1)
                            {
                                MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + dtsearch.Rows[0]["Comment"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        DateTime Edate = PLC.getdate();
                        var Hism = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.RowStatus != RowStatus.Deleted && p.EndDate>Edate).Take(1)
                            .ToList();
                        if (Hism.Count > 0)
                        {
                            int localId = Hism[0].LocalityId;
                            string Locality = db.Localities.Where(p => p.Id == localId).ToList()[0].LocalityName;
                            MessageBox.Show("هذا المشترك لديه دفتر آخر مستخرج من محلية" + (char)13 + Locality + (char)13 + "وتاريخ انتهاء الدفتر هو" + (char)13 + Hism[0].EndDate.ToShortDateString(),"النظام",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                            var His = db.ChronicsBooks.Where(p => p.InsurNo == card_no.Text && p.RowStatus!=RowStatus.Deleted).Select(p=> new { p.InsurName,p.BookNo,p.BookDate,p.EndDate,p.ChronicBookType.BookType}).ToList();
                        if (His.Count > 0)
                        {
                            PLC.InsurNo = card_no.Text;
                            FRMBookhistory Fbhis = new FRMBookhistory();
                            Fbhis.Text = "تاريخ استخراج الدفاتر للمشترك " + His[0].InsurName;
                            Fbhis.ShowDialog();
                        }
                        else
                        {
                            PLC.InsurNo = "";
                        }
                           
                            //if (ser[0].IsStoped == false)
                            //{
                            //    this.Cursor = Cursors.WaitCursor;

                            //    CustName.Text = ser[0].InsurName;
                            //    Birthdate.Value = ser[0].BirthDate;
                            //    sex.Text = ser[0].Gender;
                            //    Phone.Text = ser[0].PhoneNo;
                            //    ServerName.Text = ser[0].Server;
                            //    this.Cursor = Cursors.Default;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Notes, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //    return;
                            //}
                        }

                    this.Cursor = Cursors.WaitCursor;
                    string str111 = null;
                    str111 = card_no.Text;
                    if (str111.Contains("/"))
                    {
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

                            DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
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
                            Sex.Text = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();
                            if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                            {
                                PhoneNo.Text = dtsearch.Rows[0]["phone"].ToString();
                            }
                            else
                            {
                                PhoneNo.Text = "";
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
                                ServerName.Text = Convert.ToString(dtServ.Rows[0]["COR_NAME"]).Trim();
                            }

                            this.AcceptButton = null;
                            PLC.conOld.Close();
                            db.SaveChanges();
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
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
                            if (Convert.ToInt32(dtsearch.Rows[0]["Gender"].ToString()) == 0)
                            {
                                Sex.Text = "ذكر";
                            }
                            else
                            {
                                Sex.Text = "انثى";
                            }
                            if (Convert.IsDBNull(dtsearch.Rows[0]["Phone"]) == false)
                            {
                                PhoneNo.Text = dtsearch.Rows[0]["Phone"].ToString();
                            }
                            else
                            {
                                PhoneNo.Text = "";
                            }
                            //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                            BirthDate = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                            Age.Text = DateAndTime.DateDiff(DateInterval.Year, BirthDate, PLC.getdate()).ToString();
                            //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                            //ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                            Rec_No = dtsearch.Rows[0]["ClientId"].ToString();
                            string serv = "select top 1 * from Clients where Id=" + Rec_No + "";
                            SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                            DataTable dtServ = new DataTable();
                            dtServ.Clear();
                            DaServ.Fill(dtServ);
                            if (dtServ.Rows.Count > 0)
                            {
                                ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                            }
                            this.AcceptButton = null;
                            PLC.conNew.Close();

                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }



                }

            }
            //  }

            //catch (Exception ex)
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
                if (ChronicLst.ContainsFocus)
                {
                    ServiceId = Convert.ToInt32(ChronicLst.SelectedValue);
                }
            }
            catch (Exception)
            {
                ServiceId = 0;
                return;
            }
        }
        private void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ChronicBooksDetails.Where(p => p.BookId == ApproveNo).Select(p => new { p.Id, p.Chronics.ChronicName, p.ChronicId }).ToList();
                //GrdDwa.DataSource = FrefMl;
                GrdDwa.Rows.Clear();
                if (FrefMl.Count > 0)
                {
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdDwa.Rows.Add(i + 1, FrefMl[i].ChronicName, FrefMl[i].Id, FrefMl[i].ChronicId);
                    }


                }
            }
        }
        private void NewMedical()
        {
            ChronicLst.SelectedIndex = -1;

            ChronicLst.Focus();

        }
        private void FRMmedicine_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId ;

            LoadData();
            //BookType.DataSource = Enum.GetValues(typeof(BookType));
            BookType.SelectedIndex = 0;
            using (dbContext db = new dbContext())
            {


                var ReqCenter = db.CenterInfos.Where(p => (p.CenterTypeId == CenterType.مركز || p.CenterTypeId == CenterType.مركزوصيدلية) && p.HasContract == true && p.IsVisible == true).ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;


                var EngSer = db.Chronics.Where(p => p.Activated == 1).ToList();
                ChronicLst.DataSource = EngSer;
                ChronicLst.ValueMember = "Id";
                ChronicLst.DisplayMember = "ChronicName";
                //  ChronicLst.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ChronicLst.SelectedIndex = -1;

                // Diagnosis.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                var Bkt = db.ChronicBookTypes.ToList();
                BookType.DataSource = Bkt;
                BookType.ValueMember = "Id";
                BookType.DisplayMember = "BookType";
                //  ChronicLst.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                BookType.SelectedIndex = -1;



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {

                if (card_no.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    card_no.Focus();
                    return;
                }
               

                if (ChronicLst.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار المرض المزمن", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ChronicLst.Focus();
                    return;
                }
                if (PhoneNo.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال رقم هاتف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PhoneNo.Focus();
                    return;
                }
                if (DocumentNo.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال رقم الايصال المادي", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DocumentNo.Focus();
                    return;
                }

              
                if (GrdDwa.RowCount == 0)
                {


                    GrdDwa.Rows.Add(GrdDwa.RowCount + 1, ChronicLst.Text, "0", ChronicLst.SelectedValue.ToString());
                }
                else
                {

                    for (int i = 0; i < GrdDwa.RowCount; i++)
                    {
                        if (GrdDwa.Rows[i].Cells["ChronicName"].Value.ToString() == ChronicLst.Text)
                        {
                            return;
                        }
                    }
                    GrdDwa.Rows.Add(GrdDwa.RowCount + 1, ChronicLst.Text, "0", ChronicLst.SelectedValue.ToString());

                }
                NewMedical();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdDwa.RowCount > 0)
            {
                int ChronId = 0;
                if (Convert.IsDBNull(GrdDwa.CurrentRow.Cells["Id"].Value) == false)
                {
                    ChronId = Convert.ToInt32(GrdDwa.CurrentRow.Cells["Id"].Value);
                }

                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات هذا المرض", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    if (ChronId > 0)
                    {
                        using (dbContext db = new dbContext())
                        {
                            var GetMed = db.ChronicBooksDetails.Where(p => p.Id == ChronId).ToList();
                            if (GetMed.Count > 0)
                            {
                                db.ChronicBooksDetails.Remove(GetMed[0]);
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
                    var GetReclaim = db.ChronicsBooks.Where(p => p.Id == ApproveNo).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        GetReclaim[0].RowStatus = RowStatus.Deleted;
                        GetReclaim[0].DeleteDate = BookDate.Value;
                        GetReclaim[0].UserDeleted = UserId;
                       
                        db.Database.ExecuteSqlCommand("delete from ChronicBooksDetails where BookId=" + ApproveNo + "");
                       // db.Database.ExecuteSqlCommand("delete from ChronicsBooks where Id=" + ApproveNo + "");
                        db.SaveChanges();
                        Saved = false;
                        MessageBox.Show("لقد تم حذف بيانات هذا المرض ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        var GetApp = db.ChronicsBooks.Where(p => p.Id == ApproveNo && p.RowStatus != RowStatus.Deleted).ToList();
                        if (GetApp.Count > 0)
                        {
                            flag = 1;
                            // insurId = GetApp[0]Id;
                            card_no.Text = GetApp[0].InsurNo;
                            BookDate.Value = GetApp[0].BookDate;
                            BookNo.Text = GetApp[0].BookNo.ToString();
                            PhoneNo.Text = GetApp[0].PhoneNo;
                            DocumentNo.Text = GetApp[0].DocNo.ToString();
                            Sex.Text = GetApp[0].Gender;
                            CustName.Text = GetApp[0].InsurName;
                            ServerName.Text = GetApp[0].Server;
                            RequistingParty.SelectedValue = GetApp[0].CenterId;
                            BookType.SelectedValue = GetApp[0].BookTypeId;
                            Notes.Text = GetApp[0].Notes;
                            Age.Text = DateAndTime.DateDiff(DateInterval.Year, GetApp[0].BirthDate, PLC.getdate()).ToString();
                            Saved = true;
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

        }

        private void RadButton1_Click_1(object sender, EventArgs e)
        {
            if (BookNo.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    int BkNo = Convert.ToInt32(BookNo.Text);

                    var GetApp = db.ChronicsBooks.Where(p => p.BookNo == BkNo && p.RowStatus != RowStatus.Deleted).ToList();
                    if (GetApp.Count > 0)
                    {
                        flag = 1;
                        ApproveNo = GetApp[0].Id;
                        //insurId = GetApp[0]Id;
                        card_no.Text = GetApp[0].InsurNo;
                        BookDate.Value = GetApp[0].BookDate;
                        BookNo.Text = GetApp[0].BookNo.ToString();
                        PhoneNo.Text = GetApp[0].PhoneNo;
                        DocumentNo.Text = GetApp[0].DocNo.ToString();
                        Sex.Text = GetApp[0].Gender;
                        CustName.Text = GetApp[0].InsurName;
                        ServerName.Text = GetApp[0].Server;
                        RequistingParty.SelectedValue = GetApp[0].CenterId;
                        BookType.SelectedValue = GetApp[0].BookTypeId;
                        Notes.Text = GetApp[0].Notes;
                        Age.Text = DateAndTime.DateDiff(DateInterval.Year, GetApp[0].BirthDate, PLC.getdate()).ToString();
                        Saved = true;
                        FillGrid();
                    }

                }
            }
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

        private void BookNo_Leave(object sender, EventArgs e)
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

        private void DocumentNo_Leave(object sender, EventArgs e)
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

        private void ChronicLst_Leave(object sender, EventArgs e)
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

        private void Notes_Leave(object sender, EventArgs e)
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
    }
}
