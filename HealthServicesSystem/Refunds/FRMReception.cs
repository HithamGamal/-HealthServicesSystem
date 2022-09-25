using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using MedicalServiceSystem.SystemSetting;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMReception : Telerik.WinControls.UI.RadForm
    {
        public FRMReception()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMReception defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMReception Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMReception();
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
        public int ClientId = 0;
        public string ReNo = "";
        public string Rec_No = "";
        public DateTime BirthDate;
        public string SectorName = "";
        public int SectorId = 0;
        private void card_no_TextChanged(object sender, EventArgs e)
        {
            if (InsuranceNo.Text.Length == 0)
            {
                CustName.Clear();
                ServerName.Clear();
            }
        }

        private void PartMoney_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            chsave.Checked = false;
            OperationDate.Value = PLC.getdate();
            OperationNo.Clear();
            InsuranceNo.Clear();
            CustName.Clear();
            ServerName.Clear();
            money.Clear();
            Phone.Clear();
            moneywritten.Clear();
            medicalNote.Clear();
            CenterList.Text = "";
            PartMoney.Clear();
            ReclaimId = 0;
            ClientId = 0;
            SectorName = "";
            SectorId = 0;
            money.Enabled = false;
            BillNo.Clear();
            GrdBill.Rows.Clear();
            InsuranceNo.Focus();
        }

        private void Reception_Load(object sender, EventArgs e)
        {
            OperationDate.Value = PLC.getdate();
            UserId = LoginForm.Default.UserId;
            LocalityId =PLC.LocalityId;
            // MessageBox.Show(LocalityId.ToString());
            BillDate.Value = PLC.getdate();
            using (dbContext db = new dbContext())
            {
                var Gcenter = db.CenterInfos.ToList();
                CenterList.DataSource = Gcenter;
                CenterList.ValueMember = "Id";
                CenterList.DisplayMember = "CenterName";
                CenterList.SelectedIndex = -1;
                CenterList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InsuranceNo.Text))
            {
                using (dbContext db = new dbContext())
                {
                    //var ser = dbs.Where(p => p.InsurNo == InsuranceNo.Text).Take(1).ToList();
                    //if (ser.Count > 0)
                    //{
                    var ser = db.StopSubsribers.Where(p => p.InsurNo == InsuranceNo.Text).Take(1).ToList();
                    if (ser.Count > 0)
                    {
                        if (ser[0].IsStoped == true)
                        {
                            MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Comment, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    if (InsuranceNo.Text.Length == 9 && !InsuranceNo.Text.Contains("/"))
                    {
                        if (PLC.conNew.State == (System.Data.ConnectionState)1)
                        {
                            PLC.conNew.Close();
                        }
                        PLC.conNew.Open();
                        string srr = "select top 1 * from Cards where InsuranceNo=" + InsuranceNo.Text + " and RowStatus<>2";
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
                    str111 = InsuranceNo.Text;
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
                            sex.Text = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();
                            if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                            {
                                Phone.Text = dtsearch.Rows[0]["phone"].ToString();
                            }
                            else
                            {
                                Phone.Text = "";
                            }
                            //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                            Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["birth_date"]);

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
                                SectorId = Convert.ToInt32(dtServ.Rows[0]["SEC_NO"]);
                                //string Sec = "select top 1 * from sec where sec_no=" + SectorId + "";
                                if (PLC.conNew.State == (System.Data.ConnectionState)1)
                                {
                                    PLC.conNew.Close();
                                }
                                PLC.conNew.Open();
                                string Sec = "select top 1 * from SubSectors where Id=" + SectorId + "";
                                SqlDataAdapter DaSec = new SqlDataAdapter(Sec, PLC.conNew);
                                DataTable dtSec = new DataTable();
                                dtSec.Clear();
                                DaSec.Fill(dtSec);
                                if (dtSec.Rows.Count > 0)
                                {
                                    SectorName = dtSec.Rows[0]["SectorName"].ToString();
                                }
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
                        string srr = "select top 1 * from Cards where InsuranceNo=" + InsuranceNo.Text + " and RowStatus<>2";
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
                            if (Information.IsDBNull( dtsearch.Rows[0]["Thirdname"] )== false)
                            {
                                stri1 = dtsearch.Rows[0]["Thirdname"].ToString().Trim();
                            }
                            else
                            {
                                stri1 = ".";
                            }
                            if (Information.IsDBNull(dtsearch.Rows[0]["Fourthname"]) == false)
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
                                sex.Text = "ذكر";
                            }
                            else
                            {
                                sex.Text = "انثى";
                            }
                            if (dtsearch.Rows[0]["Phone"] == null)
                            {
                                Phone.Text = dtsearch.Rows[0]["Phone"].ToString();
                            }
                            else
                            {
                                Phone.Text = "";
                            }
                            //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                            Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                            //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                            ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                            Rec_No = dtsearch.Rows[0]["ClientId"].ToString();
                            string serv = "select top 1 * from Clients where Id=" + ClientId + "";
                            SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                            DataTable dtServ = new DataTable();
                            dtServ.Clear();
                            DaServ.Fill(dtServ);
                            if (dtServ.Rows.Count > 0)
                            {
                                ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                                SectorId = Convert.ToInt32(dtServ.Rows[0]["SubSectorId"]);
                                string Sec = "select top 1 * from SubSectors where Id=" + SectorId + "";
                                SqlDataAdapter DaSec = new SqlDataAdapter(Sec, PLC.conNew);
                                DataTable dtSec = new DataTable();
                                dtSec.Clear();
                                DaSec.Fill(dtSec);
                                if (dtSec.Rows.Count > 0)
                                {
                                    SectorName = dtSec.Rows[0]["SectorName"].ToString();
                                }
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CenterList.Text))
            {

                if (string.IsNullOrEmpty(CustName.Text))
                {
                    MessageBox.Show("يجب ادخال بيانات المشترك أولاً", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InsuranceNo.Focus();
                    return;
                }
                if (CenterList.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار المركز من القائمة أولاً", "النظام" + (char)13 + "واذا لم يوجد المركز في القائمة فيجب اضافته", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InsuranceNo.Focus();
                    return;
                }
                if (ChkMedical.Checked == false && ChkMedicine.Checked == false)
                {
                    MessageBox.Show("يجب اختيار توع الخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ChkMedical.Focus();
                    return;
                }
                if (GrdBill.RowCount > 0)
                {
                    for (int i = 0; i < GrdBill.RowCount; i++)
                    {
                        if (GrdBill.Rows[i].Cells[3].Value.ToString() == BillNo.Text && GrdBill.Rows[i].Cells[1].Value.ToString() == CenterList.Text)
                        {
                            return;
                        }
                    }
                }
                GrdBill.Rows.Add(GrdBill.RowCount + 1, CenterList.Text, Convert.ToDouble(PartMoney.Text), BillNo.Text, BillDate.Value, CenterList.SelectedValue.ToString());
                if (GrdBill.RowCount > 0)
                {
                    double a = 0;
                    for (int i = 0; i < GrdBill.RowCount; i++)
                    {
                        a += Convert.ToDouble(GrdBill.Rows[i].Cells[2].Value);
                    }
                    money.Text = a.ToString();
                    CenterList.Text = "";
                    CenterList.Focus();
                    PartMoney.Clear();
                    BillNo.Clear();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdBill.RowCount > 0)
            {

                GrdBill.Rows.RemoveAt(GrdBill.CurrentRow.Index);
            }


            if (GrdBill.RowCount > 0)
            {
                double a = 0;
                for (int i = 0; i < GrdBill.RowCount; i++)
                {
                    a += Convert.ToDouble(GrdBill.Rows[i].Cells[2].Value);
                }
                money.Text = a.ToString();
            }
            else
            {
                money.Clear();
            }
        }

        private void money_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(money.Text))
                {
                    moneywritten.Text = PLC.NumToStr(Convert.ToDouble(money.Text));
                }
                else if (money.Text == "0")
                {
                    moneywritten.Text = "";
                }
                else
                {
                    moneywritten.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(OperationNo.Text))
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var Fref = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).ToList();
                    if (Fref.Count > 0)
                    {
                        this.AcceptButton = null;
                        OperationDate.Value = Fref[0].ReclaimDate;
                        InsuranceNo.Text = Fref[0].InsurNo;
                        CustName.Text = Fref[0].InsurName;
                        ServerName.Text = Fref[0].Server;
                        sex.Text = Fref[0].Gender;
                        Birthdate.Value = Fref[0].BirthDate;
                        money.Text = Fref[0].BillsTotal.ToString();
                        Phone.Text = Fref[0].PhoneNo;
                        medicalNote.Text = Fref[0].Notes;
                        ReclaimId = Fref[0].Id;
                        //int RefId = Fref[0].Id;
                        var Fbill = db.ReclaimBills.Where(p => p.ReclaimId == ReclaimId).ToList(); ;
                        if (Fbill.Count > 0)
                        {
                            GrdBill.Rows.Clear();
                            for (int i = 0; i < Fbill.Count; i++)
                            {
                                GrdBill.Rows.Add(i + 1, Fbill[i].CenterInfo.CenterName, Fbill[i].BillTotal, Fbill[i].BillNo, Fbill[i].BillDate, Fbill[i].ServiceProviderId);
                            }
                        }
                        chsave.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        OperationNo.Clear();
                        OperationNo.Focus();
                        return;
                    }
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (GrdBill.RowCount > 0)
            {
                if (OperationNo.Text.Length == 0)
                {

                    using (dbContext db = new dbContext())
                    {
                        ModelDB.Reclaim Rf = new ModelDB.Reclaim();
                        Rf.ReclaimDate = OperationDate.Value;
                        Rf.BillsTotal = Convert.ToDecimal(money.Text);
                        Rf.ReclaimTotal = 0;
                        Rf.MedicalTotal = 0;
                        Rf.MedicineTotal = 0;
                        Rf.Notes = medicalNote.Text.Trim();
                        Rf.UserId = UserId;
                        Rf.DateIn = OperationDate.Value;
                        Rf.LocalityId = PLC.LocalityId;
                        Rf.ReclaimMedicalResonId = 0;
                        Rf.ReclaimMedicineResonId = 0;
                        Rf.RefMedicalExcCenterId = 50000;
                        Rf.RefMedicalReqCenterId = 50000;
                        Rf.RefMedicineExcCenterId = 50000;
                        Rf.RefMedicineReqCenterId = 50000;
                        Rf.IsMedical = Convert.ToBoolean(ChkMedical.CheckState);
                        Rf.IsMedicine = Convert.ToBoolean(ChkMedicine.CheckState);
                        Rf.RefuseMedical = false;
                        Rf.RefuseMedicine = false;
                        Rf.PhoneNo = Phone.Text;
                        Rf.InsurNo = InsuranceNo.Text;
                        Rf.InsurName = CustName.Text;
                        Rf.Gender = sex.Text;
                        Rf.Server = ServerName.Text;
                        Rf.ClientId = Rec_No;
                        Rf.BirthDate =Birthdate.Value ;
                        Rf.SectorId = SectorId;
                        Rf.SectorName = SectorName;
                        db.Reclaims.Add(Rf);
                        db.SaveChanges();
                        int GId = db.Reclaims.Where(p => p.UserId == UserId).Max(p => p.Id);
                        ReclaimId = GId;
                        string ltr = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityLetter;
                        // string ltr = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityLetter;
                        //  MessageBox.Show(LocalityId.ToString() + "          " + ltr);
                        ReNo = ltr + GId.ToString();
                        OperationNo.Text = ReNo;
                        var RNo = db.Reclaims.Where(p => p.Id == GId).ToList();
                        if (RNo.Count > 0)
                        {
                            RNo[0].ReclaimNo = ReNo;
                        }
                        db.SaveChanges();
                        for (int i = 0; i < GrdBill.RowCount; i++)
                        {
                            ReclaimBills Reb = new ReclaimBills();
                            Reb.ReclaimId = GId;
                            Reb.ServiceProviderId = Convert.ToInt32(GrdBill.Rows[i].Cells["CenterId"].Value);
                            Reb.BillNo = GrdBill.Rows[i].Cells["BillNo"].Value.ToString();
                            Reb.BillDate = Convert.ToDateTime(GrdBill.Rows[i].Cells["BillDate"].Value);
                            Reb.BillTotal = Convert.ToDecimal(GrdBill.Rows[i].Cells["Money"].Value);
                            db.ReclaimBills.Add(Reb);
                            db.SaveChanges();
                        }
                        FRMSave frms = new FRMSave();

                        PLC.Opr = ReNo;
                        //FRMSave.Default.OPr.Text = ReNo;
                        frms.ShowDialog();


                    }



                }
                else
                {
                    using (dbContext db = new dbContext())
                    {
                        if (ReclaimId > 0)
                        {
                            var Fref = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                            if (Fref.Count > 0)
                            {
                                Fref[0].BillsTotal = Convert.ToDecimal(money.Text);
                                Fref[0].ReclaimTotal = 0;
                                Fref[0].Notes = medicalNote.Text.Trim();
                                Fref[0].UpdateDate = OperationDate.Value;
                                Fref[0].UpdateUser = UserId;
                            }
                            db.Database.ExecuteSqlCommand("delete from ReclaimBills where ReclaimId=" + ReclaimId + " ");
                            for (int i = 0; i < GrdBill.RowCount; i++)
                            {
                                ReclaimBills Reb = new ReclaimBills();
                                Reb.ReclaimId = ReclaimId;
                                Reb.ServiceProviderId = Convert.ToInt32(GrdBill.Rows[i].Cells["CenterId"].Value);
                                Reb.BillNo = GrdBill.Rows[i].Cells["BillNo"].Value.ToString();
                                Reb.BillDate = Convert.ToDateTime(GrdBill.Rows[i].Cells["BillDate"].Value);
                                Reb.BillTotal = Convert.ToDecimal(GrdBill.Rows[i].Cells["Money"].Value);
                                db.ReclaimBills.Add(Reb);
                                db.SaveChanges();
                            }
                            MessageBox.Show("لقد تم حفظ التعديل ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("لا توجد بيانات للتعديل", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات للحفظ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (ReclaimId > 0)
            {
                DateTime date1 = OperationDate.Value;
                DateTime date2 = PLC.getdate();
                int Datedif = (int)DateAndTime.DateDiff(DateInterval.Day, date1, date2);
                if (Datedif <= 30)
                {
                    using (dbContext db = new dbContext())
                    {
                        DialogResult a = 0;
                        a = MessageBox.Show("سوف يتم حذف بيانات العملية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                        if (a == DialogResult.Yes)
                        {
                            db.Database.ExecuteSqlCommand("update  Reclaims set RowStatus=2 , UserDeleted =" + UserId + ",DeleteDate=GetDate() where Id=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimBills where ReclaimId=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimMedicals where ReclaimId=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where ReclaimId=" + ReclaimId + "");
                            //SqlCommand cmddel2 = new SqlCommand("delete from treatmentdetails where operationno='" + OperationNo.Text + "'  ", PLC.con);
                            //cmddel2.ExecuteNonQuery();
                            ClearFields();
                            MessageBox.Show("لقد تم حذف البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("لا يمكن حذف معاملة بعد 30 يوماً من ادخالها", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات للحذف", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            FrmSearch frs = new FrmSearch();
            frs.ShowDialog();
        }

        private void BTNStop_Click(object sender, EventArgs e)
        {
            if (InsuranceNo.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InsuranceNo.Focus();
                return;
            }
            if (CustName.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CustName.Focus();
                return;
            }
            FRMStopSubscriber.Default.card_no.Text = InsuranceNo.Text;
            FRMStopSubscriber.Default.ful_name.Text = CustName.Text;
            FRMStopSubscriber.Default.ShowDialog();
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RadButton2_Click(object sender, EventArgs e)
        {

            PLC.Flag = 3;
            FrmCenters.Default.ShowDialog();

        }

        private void InsuranceNo_Leave(object sender, EventArgs e)
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

        private void CenterList_Leave(object sender, EventArgs e)
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

        private void PartMoney_Leave(object sender, EventArgs e)
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

        private void BillNo_Leave(object sender, EventArgs e)
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

        private void RadGroupBox2_Click(object sender, EventArgs e)
        {

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
    }
}
