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
    public partial class FRMApproveWindow : Telerik.WinControls.UI.RadForm
    {
        public FRMApproveWindow()
        {
            InitializeComponent();
        }

        public int UserId = 0;
        public int LocalityId = 0;
        public int ReclaimId = 0;
        public int ServiceId = 0;
        public bool Saved = false;
        public string ServerName;
        private void AddNew()
        {

        }

        private void FRMApproveWindow_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                DateTime date1 = PLC.getdate();
                UserId = LoginForm.Default.UserId;
                LocalityId = PLC.LocalityId;
                var ApprCnt = db.Approves.Where((p) => p.ApproveDate == date1 && p.LocalityId == PLC.LocalityId).ToList();
                if (ApprCnt.Count > 0)
                {
                    Label13.Text = "عدد الموافقات المدخلة لهذا اليوم : " + ApprCnt.Count;
                }
                var cen = db.CenterInfos.Where((p) => p.HasContract == true && p.IsEnabled == true).OrderBy((o) => o.CenterName).Select((x) => new { Id = x.Id, CenterName = x.CenterName }).ToList();
                RequistingCenter.DataSource = cen;
                RequistingCenter.DisplayMember = "CenterName";
                RequistingCenter.ValueMember = "Id";
                RequistingCenter.SelectedIndex = -1;
                RequistingCenter.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                var grp = db.MedicalMainGroups.ToList();
                TxtGrp.DataSource = grp;
                TxtGrp.ValueMember = "Id";
                TxtGrp.DisplayMember = "MainGroupArabicName";
                TxtGrp.SelectedIndex = -1;
                var sc = db.MedicalServices.Where((p) => p.IsEnabled == true).ToList();
                MedicalServiceEn.DataSource = sc;
                MedicalServiceEn.DisplayMember = "ServiceEName";
                MedicalServiceEn.ValueMember = "Id";
                MedicalServiceEn.SelectedIndex = -1;
                MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                MedicalServiceAr.DataSource = sc;
                MedicalServiceAr.DisplayMember = "ServiceAName";
                MedicalServiceAr.ValueMember = "Id";
                MedicalServiceAr.SelectedIndex = -1;
                MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
            }
        }

        private void AttendenceReason_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (AttendenceReason.Text == "استثناء")
            {
                InsurCost.ReadOnly = false;
                ExceptionReason.Enabled = true;
            }
            else
            {
                InsurCost.ReadOnly = true;
                ExceptionReason.SelectedIndex = -1;
                ExceptionReason.Enabled = false;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void ChkEngage_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ChkEngage.Checked == true)
            {
                GrpEngage.Enabled = true;
            }
            else
            {
                GrpEngage.Enabled = false;
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TXTSearch.Text))
            {
                using (dbContext db = new dbContext())
                {

                    //var ser = dbs.Where(p => p.InsurNo == TXTSearch.Text).Take(1).ToList();
                    //if (ser.Count > 0)
                    //{
                    //    if (ser[0].IsStoped == false)
                    //    {
                    //        this.Cursor = Cursors.WaitCursor;
                    //        FulName.Text = ser[0].InsurName;
                    //        BirthDate.Value = ser[0].BirthDate;
                    //        Gender.Text = ser[0].Gender;
                    //        Phone.Text = ser[0].PhoneNo;
                    //        ServerName = ser[0].Server;
                    //        this.Cursor = Cursors.Default;
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Notes, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                        if (InsurType.SelectedIndex == 0)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            string str111 = null;
                            str111 = TXTSearch.Text;
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
                                SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
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
                                    FulName.Text = Convert.ToString(dtsearch.Rows[0]["name_1"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["name_2"]).Trim() + " " + stri1 + " " + str2;
                                    Gender.Text = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();
                                    if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                                    {
                                        Phone.Text = dtsearch.Rows[0]["phone"].ToString();
                                    }
                                    else
                                    {
                                        Phone.Text = "";
                                    }
                                    //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                    BirthDate.Value = Convert.ToDateTime(dtsearch.Rows[0]["birth_date"]);

                                    //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                    String Rec_No = corNo.ToString() + "/" + recNo.ToString();
                                    string serv = "select top 1 * from corpration where cor_no=" + corNo + " and rec_no=" + recNo + "";
                                    SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conOld);
                                    DataTable dtServ = new DataTable();
                                    dtServ.Clear();
                                    DaServ.Fill(dtServ);
                                    if (dtServ.Rows.Count > 0)
                                    {
                                        ServerName = Convert.ToString(dtServ.Rows[0]["COR_NAME"]).Trim();
                                    }

                                    this.AcceptButton = null;
                                    PLC.conOld.Close();
                                    //Subscriber Sc = new Subscriber();

                                    //Sc.PhoneNo = Phone.Text;
                                    //Sc.InsurNo = TXTSearch.Text;
                                    //Sc.InsurName = FulName.Text;
                                    //Sc.Gender = Gender.Text;
                                    //Sc.Server = ServerName;
                                    //Sc.ClientId = Rec_No;
                                    //Sc.BirthDate = BirthDate.Value;
                                    //Sc.LocalityId = PLC.LocalityId;
                                    //dbs.Add(Sc);
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
                                string srr = "select top 1 * from Cards where InsuranceNo=" + TXTSearch.Text + " and RowStatus<>2";
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
                                    if (dtsearch.Rows[0]["Thirdname"] == null)
                                    {
                                        stri1 = dtsearch.Rows[0]["Thirdname"].ToString().Trim();
                                    }
                                    else
                                    {
                                        stri1 = ".";
                                    }
                                    if (dtsearch.Rows[0]["Fourthname"] == null)
                                    {
                                        str2 = dtsearch.Rows[0]["Fourthname"].ToString().Trim();
                                    }
                                    else
                                    {
                                        str2 = ".";
                                    }
                                    FulName.Text = Convert.ToString(dtsearch.Rows[0]["Firstname"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["Secondname"]).Trim() + " " + stri1 + " " + str2;
                                    Gender.Text = Convert.ToString(dtsearch.Rows[0]["Gender"]).Trim();
                                    if (dtsearch.Rows[0]["Phone"] == null)
                                    {
                                        Phone.Text = dtsearch.Rows[0]["Phone"].ToString();
                                    }
                                    else
                                    {
                                        Phone.Text = "";
                                    }
                                    //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                    BirthDate.Value = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                                    //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                    int ClientId = 0;
                                    ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                                    string serv = "select top 1 * from Clients where Id=" + ClientId + "";
                                    SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                                    DataTable dtServ = new DataTable();
                                    dtServ.Clear();
                                    DaServ.Fill(dtServ);
                                    if (dtServ.Rows.Count > 0)
                                    {
                                        ServerName = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                                    }
                                    this.AcceptButton = null;
                                    PLC.conOld.Close();
                                    //Subscriber Sc = new Subscriber();
                                    //Sc.PhoneNo = Phone.Text;
                                    //Sc.InsurNo = TXTSearch.Text.Trim();
                                    //Sc.InsurName = FulName.Text;
                                    //Sc.Gender = Gender.Text;
                                    //Sc.Server = ServerName;
                                    //Sc.ClientId = ClientId.ToString();
                                    //Sc.BirthDate = BirthDate.Value;
                                    //Sc.LocalityId = PLC.LocalityId;
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
                        }


                        else if (InsurType.SelectedIndex == 1)
                        {
                            try
                            {

                                this.Cursor = Cursors.WaitCursor;
                                SqlConnection conNat = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=card_natoinal;User ID=sa;Password=123;Trusted_Connection=False");
                                if (conNat.State == ConnectionState.Open)
                                {
                                    conNat.Close();
                                }

                                conNat.Open();

                                SqlDataAdapter dNat = new SqlDataAdapter("select * from NationalCard where InsuranceNo=" + Convert.ToDouble(TXTSearch.Text) + "", conNat);

                                DataTable dtNat = new DataTable();

                                dtNat.Clear();

                                dNat.Fill(dtNat);

                                if (dtNat.Rows.Count > 0)
                                {

                                    BirthDate.Value = Convert.ToDateTime(dtNat.Rows[0]["BirthDate"]);

                                    int ag = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Year, BirthDate.Value, PLC.getdate()));

                                    if (ag > 0)
                                    {

                                        LblAge.Text = ag.ToString();

                                    }
                                    else
                                    {

                                        LblAge.Text = "1";

                                    }

                                    // Phone.Text = result.phone

                                    Address.Text = (dtNat.Rows[0]["StateName"]).ToString();

                                    FulName.Text = (dtNat.Rows[0]["FullName"]).ToString();


                                    Gender.Text = (dtNat.Rows[0]["Gender"]).ToString();
                                    int ClientId = 0;
                                    ClientId = Convert.ToInt32((dtNat.Rows[0]["Stateid"]).ToString());


                                    ServerName = (dtNat.Rows[0]["StateName"]).ToString();
                                    //Subscriber Sc = new Subscriber();
                                    //Sc.InsurNo = TXTSearch.Text.Trim();
                                    //Sc.InsurName = FulName.Text;
                                    //Sc.Gender = Gender.Text;
                                    //Sc.Server = ServerName;
                                    //Sc.ClientId = ClientId.ToString();
                                    //Sc.BirthDate = BirthDate.Value;
                                    //Sc.LocalityId = PLC.LocalityId;
                                    //dbs.Add(Sc);
                                    //db.SaveChanges();
                                    this.Cursor = Cursors.Default;

                                
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

                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("لا توجد بيانات لهذا المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.None);

                                this.AcceptButton = null;

                                this.Cursor = Cursors.Default;

                                return;

                            }
                        }
                    }
                }

        }

        private void TxtGrp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (TxtGrp.ContainsFocus)
                {
                    if (!string.IsNullOrEmpty(TxtGrp.Text))
                    {
                        using (dbContext db = new dbContext())
                        {

                            int a = Convert.ToInt32(TxtGrp.SelectedValue);
                            var grp = db.MedicalSubGroups.Where((p) => p.MainGroupId == a && p.IsEnabled == true).ToList();
                            SubGroup.DataSource = grp;
                            SubGroup.ValueMember = "Id";
                            SubGroup.DisplayMember = "SubGroupAname";
                            SubGroup.SelectedIndex = -1;
                            MedicalServiceAr.SelectedIndex = -1;
                            MedicalServiceEn.SelectedIndex = -1;
                            SubGroup.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
