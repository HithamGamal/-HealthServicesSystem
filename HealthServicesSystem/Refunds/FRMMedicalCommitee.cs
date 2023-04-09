using HealthServicesSystem.SystemSetting;
using Microsoft.VisualBasic;
using ModelDB;
using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using HealthServicesSystem.Reclaims;
using Telerik.WinControls;
using Telerik.Reporting.Processing;
using Telerik.WinControls.UI;
using HealthServicesSystem.Committee;

namespace HealthServicesSystem.Refunds
{
    public partial class FRMMedicalCommitee : Telerik.WinControls.UI.RadForm
    {
        public string ServerName;
        public int LocalityId = 0;
        int i = 1;
        decimal totalCost = 0;
        dbContext db = new dbContext();
        public int _UserId = LoginForm.Default.UserId;
        DateTime date1 = PLC.getdate();
        string y;
        string m ;
        string d ;
        string usercode ;
        string reason = "";
        string coInsuranceType = "";
        string cost = "";
        int requestId =0;


        public FRMMedicalCommitee()
        {
            InitializeComponent();
        }

        private void FRMMedicalCommitee_Load(object sender, EventArgs e)
        {
            OperationDate.Value = PLC.getdate();
            _UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;

            y = date1.Year.ToString().Substring(2,2);
            m = date1.Month.ToString("00");
            d = date1.Day.ToString("00");
            usercode = _UserId.ToString("000");
          
               
            using (dbContext  db = new dbContext())
            {

                    if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
                    {
                        PLC.DbCailm.Close();
                    }
                    PLC.DbCailm.Open();
                SqlDataAdapter daCenter = new SqlDataAdapter("SELECT   center_id,center_name FROM   centers   where center_status= 'فعال' and center_id in (select center_id from servicecost where status ='Active')", PLC.DbCailm);
                SqlDataAdapter daCenter1 = new SqlDataAdapter("SELECT   center_id,center_name FROM   centers   where center_status= 'فعال' and center_id in (select center_id from servicecost where status ='Active')", PLC.DbCailm);
                DataTable dtCenter = new DataTable();
                DataTable dtCenter1 = new DataTable();
                dtCenter.Clear();
                dtCenter1.Clear();
                daCenter.Fill(dtCenter);
                daCenter1.Fill(dtCenter1);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtCenter.Rows.Count > 0)
                {
                    fromCenterDropdown.DataSource = dtCenter;
                    fromCenterDropdown.DisplayMember = "center_name";
                    fromCenterDropdown.ValueMember = "center_id";
                    fromCenterDropdown.SelectedIndex = -1;
                    fromCenterDropdown.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                        Co_Centers.DataSource = dtCenter;
                        Co_Centers.DisplayMember = "center_name";
                        Co_Centers.ValueMember = "center_id";
                        Co_Centers.SelectedIndex = -1;
                        Co_Centers.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;


                    ExcutingCenter.DataSource = dtCenter1;
                    ExcutingCenter.DisplayMember = "center_name";
                    ExcutingCenter.ValueMember = "center_id";
                    ExcutingCenter.SelectedIndex = -1;
                    ExcutingCenter.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                }








            }
            transferRadio.IsChecked = false;

        }

        private void BTNpreviousRequest_Click(object sender, EventArgs e)
        {
            FRMpreviousRequest frm = new FRMpreviousRequest();
            frm.Show();
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            find_insurance_no(TXTSearch.Text);
            transaction_history(TXTSearch.Text);
            services_history(TXTSearch.Text);
        }

        private void GRDApprove_Click(object sender, EventArgs e)
        {

        }


        public void services_history(string insurance_no)
        {
            PLC.SubId = insurance_no;
            var serviceHistory = db.medicalCommitteeRequestDetails
                                   .Where(p => p.InsurId == PLC.SubId && p.RowStatus!=RowStatus.Deleted).ToList();
            if (serviceHistory.Count > 0)
            {
                CommitteeListHistory frm = new CommitteeListHistory();
                frm.ShowDialog();


            }
        }

        public void find_insurance_no(string insurance_no)
        {
            if (!string.IsNullOrEmpty(insurance_no))
            {
                using (dbContext db = new dbContext())
                {
                    
                    var ser = db.StopSubsribers.Where(p => p.InsurNo == insurance_no).Take(1).ToList();
                    if (ser.Count > 0)
                    {
                        if (ser[0].IsStoped == true)
                        {
                            MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Comment, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    if (insurance_no.Length == 9 && !insurance_no.Contains("/"))
                    {
                        if (PLC.conNew.State == (System.Data.ConnectionState)1)
                        {
                            PLC.conNew.Close();
                        }
                        PLC.conNew.Open();
                        string srr = "select top 1 * from Cards where InsuranceNo=" + insurance_no + " and RowStatus<>2";
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

                            FulName.Text = dtsearch.Rows[0]["Firstname"].ToString()+ " "+ dtsearch.Rows[0]["Secondname"].ToString() + " " + dtsearch.Rows[0]["Thirdname"].ToString() + " " + dtsearch.Rows[0]["Fourthname"].ToString();
                            BirthDate .Text = dtsearch.Rows[0]["Birthdate"].ToString();
                            clientIdLBL .Text = dtsearch.Rows[0]["ClientId"].ToString();
                            phoneNoLBL .Text = dtsearch.Rows[0]["Phone"].ToString();
                            genderlbl.Text = dtsearch.Rows[0]["Gender"].ToString();
                            addressLBL .Text = dtsearch.Rows[0]["Address"].ToString();
                            card_typeTB.Text = "0";
                            if (Convert.ToInt32(dtsearch.Rows[0]["Status"].ToString()) == 1)
                            {
                                MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + dtsearch.Rows[0]["Comment"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                               // this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            patDataAlertLBL.Visible = true;
                            FulName.Text = "";
                            FulName.Enabled = true;
                            genderlbl .Text = "";
                            addressLBL.Text = "";
                            phoneNoLBL.Text = "0";
                            clientIdLBL.Text = "0";
                            card_typeTB.Text = "2";
                            return;
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
                    else
                    {
                        if (PLC.DbNational.State == (System.Data.ConnectionState)1)
                        {
                            PLC.DbNational.Close();
                        }
                        PLC.DbNational.Open();
                        string card = "select top 1 * from NationalCard where InsuranceNo=" + insurance_no + " and IsSuspended<>1";
                        SqlDataAdapter dasearch = new SqlDataAdapter(card, PLC.DbNational);
                        DataTable dtsearch = new DataTable();
                        dtsearch.Clear();
                        dasearch.Fill(dtsearch);
                        if (dtsearch.Rows.Count > 0)
                        {


                            FulName.Text = dtsearch.Rows[0]["FullName"].ToString();
                            BirthDate.Text = dtsearch.Rows[0]["BirthDate"].ToString();
                            clientIdLBL.Text = dtsearch.Rows[0]["Stateid"].ToString();
                            phoneNoLBL.Text = "0";
                            
                            if (dtsearch.Rows[0]["Gender"].ToString()== "ذكر")
                            {
                                genderlbl.Text = "0";
                            }
                            else
                            {
                                genderlbl.Text = "1";
                            }
                            addressLBL.Text = dtsearch.Rows[0]["StateName"].ToString();
                            card_typeTB.Text = "1";
                            
                        }
                        else
                        {
                            MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            patDataAlertLBL.Visible = true;
                            FulName.Text = "";
                            FulName.Enabled = true;
                            genderlbl.Text = "";
                            addressLBL.Text = "";
                            phoneNoLBL.Text = "0";
                            clientIdLBL.Text = "0";
                            card_typeTB.Text = "2";

                            return;
                        }

                       
                    }
                   // this.Cursor = Cursors.WaitCursor;
                    string str111 = null;
                    str111 = insurance_no;
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
                            FulName .Text = Convert.ToString(dtsearch.Rows[0]["name_1"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["name_2"]).Trim() + " " + stri1 + " " + str2;
                            genderlbl .Text = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();

                            if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                            {
                                phoneNoLBL .Text = dtsearch.Rows[0]["phone"].ToString();
                            }
                            else
                            {
                                phoneNoLBL.Text = "";
                            }
                            addressLBL.Text  = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                            BirthDate.Value = Convert.ToDateTime(dtsearch.Rows[0]["birth_date"]);
                            card_typeTB.Text = "0";
                            clientIdLBL .Text  = corNo.ToString() + "/" + recNo.ToString();
                            string serv = "select top 1 * from corpration where cor_no=" + corNo + " and rec_no=" + recNo + "";
                            SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conOld);
                            DataTable dtServ = new DataTable();
                            dtServ.Clear();
                            DaServ.Fill(dtServ);
                            if (dtServ.Rows.Count > 0)
                            {
                             //   ServerName.Text = Convert.ToString(dtServ.Rows[0]["COR_NAME"]).Trim();
                               // SectorId = Convert.ToInt32(dtServ.Rows[0]["SEC_NO"]);
                                //string Sec = "select top 1 * from sec where sec_no=" + SectorId + "";
                                if (PLC.conNew.State == (System.Data.ConnectionState)1)
                                {
                                    PLC.conNew.Close();
                                }
                                PLC.conNew.Open();
                                //string Sec = "select top 1 * from SubSectors where Id=" + SectorId + "";
                                //SqlDataAdapter DaSec = new SqlDataAdapter(Sec, PLC.conNew);
                                //DataTable dtSec = new DataTable();
                                //dtSec.Clear();
                                //DaSec.Fill(dtSec);
                                //if (dtSec.Rows.Count > 0)
                                //{
                                // //   SectorName = dtSec.Rows[0]["SectorName"].ToString();
                                //}
                            }

                            this.AcceptButton = null;
                            PLC.conOld.Close();
                            db.SaveChanges();
                          //  this.Cursor = Cursors.Default;
                        }
                        else
                        {
                           /// this.Cursor = Cursors.Default;
                            MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            patDataAlertLBL.Visible = true;
                            FulName.Text = "";
                            FulName.Enabled = true;
                            genderlbl.Text = "";
                            addressLBL.Text = "";
                            phoneNoLBL.Text = "0";
                            clientIdLBL.Text = "0";
                            card_typeTB.Text = "2";

                            return;
                        }
                    }



                    else
                    {
                        //if (PLC.conNew.State == (System.Data.ConnectionState)1)
                        //{
                        //    PLC.conNew.Close();
                        //}
                        //PLC.conNew.Open();
                        //string srr = "select top 1 * from Cards where InsuranceNo=" + insurance_no + " and RowStatus<>2";
                        //SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                        //DataTable dtsearch = new DataTable();
                        //dtsearch.Clear();
                        //dasearch.Fill(dtsearch);
                        //if (dtsearch.Rows.Count > 0)
                        //{

                        //    //DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                        //    // MsgBox(date1.Date)
                        //    string stri1 = null;
                        //    string str2 = null;
                        //    if (Information.IsDBNull(dtsearch.Rows[0]["Thirdname"]) == false)
                        //    {
                        //        stri1 = dtsearch.Rows[0]["Thirdname"].ToString().Trim();
                        //    }
                        //    else
                        //    {
                        //        stri1 = ".";
                        //    }
                        //    if (Information.IsDBNull(dtsearch.Rows[0]["Fourthname"]) == false)
                        //    {
                        //        str2 = dtsearch.Rows[0]["Fourthname"].ToString().Trim();
                        //    }
                        //    else
                        //    {
                        //        str2 = ".";
                        //    }
                        //    //CustName.Text = Convert.ToString(dtsearch.Rows[0]["Firstname"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["Secondname"]).Trim() + " " + stri1 + " " + str2;
                        //    //if (Convert.ToInt32(dtsearch.Rows[0]["Gender"].ToString()) == 0)
                        //    //{
                        //    //    sex.Text = "ذكر";
                        //    //}
                        //    //else
                        //    //{
                        //    //    sex.Text = "انثى";
                        //    //}
                        //    //if (dtsearch.Rows[0]["Phone"] == null)
                        //    //{
                        //    //    Phone.Text = dtsearch.Rows[0]["Phone"].ToString();
                        //    //}
                        //    //else
                        //    //{
                        //    //    Phone.Text = "";
                        //    //}
                        //    ////Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                        //    //Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                        //    ////Birthdate.Value = dtsearch.Rows(0)("birth_date")
                        //    //ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                        //    //Rec_No = dtsearch.Rows[0]["ClientId"].ToString();
                        //    //string serv = "select top 1 * from Clients where Id=" + ClientId + "";
                        //    //SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                        //    //DataTable dtServ = new DataTable();
                        //    //dtServ.Clear();
                        //    //DaServ.Fill(dtServ);
                        //    //if (dtServ.Rows.Count > 0)
                        //    //{
                        //    //    ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                        //    //    SectorId = Convert.ToInt32(dtServ.Rows[0]["SubSectorId"]);
                        //    //    string Sec = "select top 1 * from SubSectors where Id=" + SectorId + "";
                        //    //    SqlDataAdapter DaSec = new SqlDataAdapter(Sec, PLC.conNew);
                        //    //    DataTable dtSec = new DataTable();
                        //    //    dtSec.Clear();
                        //    //    DaSec.Fill(dtSec);
                        //    //    if (dtSec.Rows.Count > 0)
                        //    //    {
                        //    //        SectorName = dtSec.Rows[0]["SectorName"].ToString();
                        //    //    }
                        //    //}
                        //    this.AcceptButton = null;
                        //    PLC.conNew.Close();

                        //    this.Cursor = Cursors.Default;
                        //}
                        //else
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                    }



                }
            }

        }

        public void transaction_history(string insurance_no)
        {
            PLC.SubId = insurance_no;
            var FrHistoryMd = db.Reclaims.Where(p => p.InsurNo == PLC.SubId &&  p.MedicalTotal > 0).ToList();
            if (FrHistoryMd.Count > 0)
            {
                FRMEstrdadhistory frh = new FRMEstrdadhistory();
                PLC.FlagMedical = 1;
                frh.ShowDialog();
             

            }
        }

        public void clear()
        {
            i = 1;
            TotalCostTXT.Text = "";
            TXTSearch.Text = "";
            MedicalServiceEn.SelectedIndex = -1;
            MedicalServiceAr.SelectedIndex = -1;
            Co_MedicalServiceEN.SelectedIndex = -1;
            Co_MedicalServicesAR.SelectedIndex = -1;
            Co_Centers.SelectedIndex = -1;
            ExcutingCenter.SelectedIndex =-1;
            totalCost = 0;
            //TXTAmount.Text = "";
            //MAmount.CheckState = CheckState.Unchecked;
            approve_check.CheckState = CheckState.Unchecked;
            deny_check.CheckState = CheckState.Unchecked;
            refund_check.CheckState = CheckState.Unchecked;
            GRDApprove.Rows.Clear();
            rqstId.Text = "";
            FulName.Text = "";
            addressLBL .Text = "";
            phoneNoLBL.Text = "0";
            clientIdLBL.Text = "0";
            pat_cost_txt.Text = "";
            ServiceCost.Text = "";
            insur_cost_txt.Text = "";
            rqstId.Text = "0";
            COlistRB.CheckState = CheckState.Unchecked;
            transferRadio.CheckState = CheckState.Unchecked;
            physiotherapyrb.CheckState = CheckState.Unchecked;
            coRadio.CheckState = CheckState.Unchecked;
            patDataAlertLBL.Visible = false;
                FulName.Enabled = false;
            TotalCostTB.Text = "";
            Co_CostTB.Text = "";
            ServiceCostTB.Text = "";
            InvoiceCostTB.Text = "";
            ExcutingCenter.Text = ""; 
            fromCenterDropdown .Text = ""; 
            allow_cost_txt .Text = "";
            ExecptionCost.Visible = false;
            radLabel17.Visible = false;
            ExecptionCost.Text = "0";
            ExecptionReason.SelectedIndex = -1;
            CoInsuranceTypee.SelectedIndex = -1;
             requestId = 0;
            radLabel16.Visible = true;
            radLabel15.Visible = true;
            CoInsuranceTypee.Visible = true;
            ExecptionReason.Visible = true;

        }
        private void NewBTN_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void AddBTN_Click(object sender, EventArgs e)
        {

            string insurance_no = TXTSearch.Text;
            string centerId = ExcutingCenter.ValueMember;
            string medical_service_en = MedicalServiceEn.Text;
            string medical_service_ar = MedicalServiceAr.Text;

            int service_id = Convert.ToInt32(MedicalServiceAr.SelectedValue) ;
            if (service_id ==0)
            {
                service_id = Convert.ToInt32(MedicalServiceEn.SelectedValue);
            }
            decimal Service_Cost =Convert.ToDecimal(ServiceCost.Text);
            decimal patient_cost = Convert.ToDecimal(pat_cost_txt .Text);
            decimal insurance_cost = Convert.ToDecimal(insur_cost_txt .Text);
            decimal allow_cost = Convert.ToDecimal(allow_cost_txt  .Text);
            decimal co_cost = 0;
            if (transferRadio .IsChecked)
            {
                co_cost = Service_Cost;
            }
            try
            {
                decimal totalCost = 0;

                totalCost = allow_cost + insurance_cost ;

                //if (allow_cost == 0)
                //{

                //}
                //if (allow_cost = 0)
                //{

                //}
                //if (allow_cost == 0)
                //{

                //}


                if (totalCost <= Service_Cost)
                {
                    TotalCostTB.Text = totalCost.ToString();
                }
                else
                {
                    RadMessageBox.Show("عفواً،، مبلغ التحمل الاضافي أكبر من تكلفة الخدمة");
                    return;
                }



            }
            catch (Exception)
            {

                // throw;
            }

            GRDApprove.Rows.Add(i,i,insurance_no,centerId,service_id, medical_service_en, 
                                medical_service_ar, Service_Cost, insurance_cost,patient_cost,co_cost,allow_cost   );

            i++;

            MedicalServiceEn.SelectedIndex = -1;
            MedicalServiceAr.SelectedIndex = -1;
            ServiceCost.Text = "";
            pat_cost_txt .Text = "";
            insur_cost_txt.Text = "";
            allow_cost_txt.Text = "";
            totalCost += insurance_cost;
            TotalCostTXT.Text = totalCost.ToString();
        }

        public void print()
        {
            ExceptionReason form = new ExceptionReason();
            if (physiotherapyrb.IsChecked)
            {
                int id = requestId;
                physiotherapy_session_rpt   rpt = new physiotherapy_session_rpt();
                
                rpt.rqstId.Value =id.ToString();
                rpt.centerName .Value = ExcutingCenter.Text;
                rpt.patientname.Value = FulName.Text;
                rpt.insur_no.Value = TXTSearch.Text;
                rpt.cor_no.Value = clientIdLBL.Text;
                rpt.rqst_date.Value = DateTime.Today.Date.ToShortDateString();
                rpt.phone_no.Value = phoneNoLBL.Text;
                

                RequestFrmRPT frm = new RequestFrmRPT();

                frm.reportViewer1.ReportSource = rpt;
                frm.reportViewer1.RefreshReport();
                frm.Show();

                //////RequestFrmRPT pr = new RequestFrmRPT();
                //////PrintDialog pg = new PrintDialog();
                //////pr.PrintReport(rpt, pg.PrinterSettings);
                //////////ReportProcessor pr = new ReportProcessor();
                //////////PrintDialog pg = new PrintDialog();
                //////////pr.PrintReport(rpt, pg.PrinterSettings);
            }
            else
            {
               // int id = Convert.ToInt32(rqstId.Text);
                int id = requestId;
                TransferRPT rpt = new TransferRPT();
                var data = db.medicalCommitteeRequestDetails.Where(x => x.RequestId == id)
                             .Select(x => new { service_id = x.ServiceId,
                                                  pat_cost = x.Pat_cost,
                                              service_Name = x.Service_Name,
                                               ServiceCost = x.Insur_cost }).ToList();
                rpt.DataSource = data;
                rpt.rqstId.Value = codelbl.Text;
                rpt.patientname.Value = FulName.Text;
                rpt.insur_no.Value = TXTSearch.Text;
                rpt.cor_no.Value = clientIdLBL.Text;
                rpt.rqst_date.Value = DateTime.Today.Date.ToShortDateString();
                rpt.phone_no.Value = phoneNoLBL.Text;
                rpt.Qrr.Value = codelbl.Text;

                if (coRadio.IsChecked)
                {
                  //  rpt.ServiceCost.Visible = true;
                   // rpt.textBox13.Visible = true;
                    rpt.textBox21.Visible = true;
                }
                if (radPageView2.SelectedPage.Name == "CooperationCommittee")
                {
                    rpt.centername.Value = Co_Centers.Text;
                    rpt.CoInsuranceType.Value = noteTXT.Text;
                }
                else
                {
                    rpt.centername.Value = ExcutingCenter.Text;
                  //  rpt.textBox13.Value = "0";
                    if (coInsuranceType == "")
                    {
                        rpt.CoInsuranceType.Value = "حسب أسعار التعاقد";
                        rpt.CoInsuranceType.Value = coInsuranceType;
                    }
                    else
                    {
                        rpt.CoInsuranceType.Value = coInsuranceType;
                    }
                    
                }



                RequestFrmRPT frm = new RequestFrmRPT();

                frm.reportViewer1.ReportSource = rpt;
                frm.reportViewer1.RefreshReport();
                frm.Show();
                if (transferRadio.IsChecked || coRadio.IsChecked)
                {


                    ReportProcessor pr = new ReportProcessor();
                    PrintDialog pg = new PrintDialog();
                    pr.PrintReport(rpt, pg.PrinterSettings);
                }
            }
        }
        private void PrintBTN_Click(object sender, EventArgs e)
        {
            print();
        }

        private void GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void MedicalServiceEn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
   {

            if (transferRadio.IsChecked || physiotherapyrb.IsChecked)
            {
                if (MedicalServiceEn.SelectedIndex > 0)
                {
                    try
                    {
                        int service_id = Convert.ToInt32(MedicalServiceAr.SelectedValue);
                        int center_id = Convert.ToInt32(ExcutingCenter.SelectedValue);

                        SqlDataAdapter da_service = new SqlDataAdapter("SELECT   servicecost,pat_cost,pat_servicecost FROM servicecost where status= 'Active' and center_id=" + center_id + " and service_id=" + service_id + "", PLC.DbCailm);
                        DataTable dtService = new DataTable();
                        dtService.Clear();
                        da_service.Fill(dtService);
                        //   MsgBox (dtCenter .Rows .Count)
                        if (dtService.Rows.Count > 0)
                        {
                            int serviceCost = Convert.ToInt32(dtService.Rows[0]["pat_servicecost"]) + Convert.ToInt32(dtService.Rows[0]["servicecost"]);
                            pat_cost_txt.Text = dtService.Rows[0]["pat_servicecost"].ToString();
                            ServiceCost.Text = serviceCost.ToString();
                            insur_cost_txt.Text = dtService.Rows[0]["servicecost"].ToString();
                        }





                    }
                    catch (Exception)
                    {

                        //  throw;
                    }


                    //}
                }
            }
            else if (coRadio.IsChecked)
            {
                try
                {
                    int serviceId = Convert.ToInt32(MedicalServiceEn.SelectedValue);
                    var Cs = db.CooperationServices.Where(x => x.Id == serviceId).First();

                    MedicalServiceEn.SelectedText = Cs.Service_EN_Name;
                    ServiceCost.Text = Cs.Cost;
                    insur_cost_txt.Text = Cs.Cost;
                }
                catch (Exception)
                {

                    //  throw;
                }
            }



        }

        private void ExcutingCenter_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (coRadio.IsChecked != true)
                {

              
                int center_id = Convert.ToInt32(ExcutingCenter.SelectedValue);
                int service_id = Convert.ToInt32(MedicalServiceAr.SelectedValue);

              //  SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT  service_id, service_name,service_name_english FROM services where status='T' AND IS_NEW= 'Y' and service_id in ( SELECT   service_id FROM servicecost where  center_id=" + center_id + " and status= 'Active'  ) ", PLC.DbCailm);
                SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT        dbo.services.service_id, dbo.services.service_name, dbo.services.service_name_english FROM       dbo.services INNER JOIN  dbo.servicecost ON dbo.services.service_id = dbo.servicecost.service_id where dbo.services.status='T' AND dbo.services.IS_NEW= 'Y' and dbo.servicecost.center_id ="+center_id+ " ", PLC.DbCailm);
                DataTable dtEnService = new DataTable();
                dtEnService.Clear();
                da_EN_service.Fill(dtEnService);
                //if (transferRadio.IsChecked)
                //{


                //   MsgBox (dtCenter .Rows .Count)
                if (dtEnService.Rows.Count > 0)
                {
                    MedicalServiceEn.DataSource = dtEnService;
                    MedicalServiceEn.DisplayMember = "service_name_english";
                    MedicalServiceEn.ValueMember = "service_id";
                    MedicalServiceEn.SelectedIndex = -1;
                    MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                    MedicalServiceAr.DataSource = dtEnService;
                    MedicalServiceAr.DisplayMember = "service_name";
                    MedicalServiceAr.ValueMember = "service_id";
                    MedicalServiceAr.SelectedIndex = -1;
                    MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;


                }

                }



            }
            catch (Exception)
            {

              //  throw;
            }
        }


        private void MedicalServiceAr_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
       {
            if (transferRadio.IsChecked || physiotherapyrb.IsChecked)
            {
                if (MedicalServiceAr.SelectedIndex > 0)
                {
                    try
                    {
                        int service_id = Convert.ToInt32(MedicalServiceAr.SelectedValue);
                        int center_id = Convert.ToInt32(ExcutingCenter.SelectedValue);
                       
                            SqlDataAdapter da_service = new SqlDataAdapter("SELECT   servicecost,pat_cost,pat_servicecost FROM servicecost where status= 'Active' and center_id=" + center_id + " and service_id=" + service_id + "", PLC.DbCailm);
                            DataTable dtService = new DataTable();
                            dtService.Clear();
                            da_service.Fill(dtService);
                            //   MsgBox (dtCenter .Rows .Count)
                            if (dtService.Rows.Count > 0)
                            {
                                int serviceCost = Convert.ToInt32(dtService.Rows[0]["pat_servicecost"]) + Convert.ToInt32(dtService.Rows[0]["servicecost"]);
                                pat_cost_txt.Text = dtService.Rows[0]["pat_servicecost"].ToString();
                                ServiceCost.Text = serviceCost.ToString();
                                insur_cost_txt.Text = dtService.Rows[0]["servicecost"].ToString();
                            }



                        

                    }
                    catch (Exception)
                    {

                        //  throw;
                    }


                    //}
                }
            }
            else if (coRadio.IsChecked)
            {
                try
                {
                    int serviceId = Convert.ToInt32(MedicalServiceAr.SelectedValue);
                    var Cs = db.CooperationServices.Where(x => x.Id == serviceId).First();

                    MedicalServiceEn.SelectedText = Cs.Service_EN_Name;
                    ServiceCost.Text = Cs.Cost;
                    insur_cost_txt.Text = Cs.Cost;
                }
                catch (Exception)
                {

                  //  throw;
                }
            }



            }

        

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            int allowCost = 0;
            int PatientPrice = 0;
           
          

            if (string.IsNullOrEmpty(TXTSearch.Text ))
            {
                RadMessageBox.Show("الرجاء ادخال بيانات المشترك !");
                return;
            }
           
            foreach (var item in GRDApprove.Rows)
            {
               allowCost += Convert.ToInt32( item.Cells["allowCost"].Value);
               PatientPrice += Convert.ToInt32( item.Cells["PatientPrice"].Value);
            }

            ////if (allowCost > 0)
            ////{
            ////    ExceptionReason form = new ExceptionReason();
            ////    if (allowCost == PatientPrice)
            ////    {
            ////        form.CoInsuranceType.SelectedIndex = 0;
            ////    }
            ////    else
            ////    {
            ////        form.CoInsuranceType.SelectedIndex =1;
            ////    }
            ////    form.ExecptionCost.Text= allowCost.ToString();
            ////    form.ShowDialog();
            ////    reason = form.x;
            ////    coInsuranceType = form.c;
            ////    cost = form.cost;
            ////}

            if (CoInsuranceTypee .Text=="")
            {
                if (coRadio.CheckState ==CheckState.Checked)
                {
                    reason = "";
                    coInsuranceType = " مساهمة بمبلغ" + TotalCostTB.Text;
                  //  cost = TotalCostTB.Text;
                }
                else
                {
                    reason = "";
                    coInsuranceType = "حسب اسعار التعاقد";
                    cost = "";
                }
                
            }
            else
            {
                if (CoInsuranceTypee.SelectedIndex == 0)
                {
                    reason = ExecptionReason.Text;
                    coInsuranceType = CoInsuranceTypee.Text;
                    cost = ExecptionCost.Text;
                }
                else
                {
                    reason = ExecptionReason.Text;
                    coInsuranceType = CoInsuranceTypee.Text + ExecptionCost.Text;
                    cost = ExecptionCost.Text;
                }
                
            }
            if (rqstId.Text != "0")
            {
                int id_forEdit = Convert.ToInt32(rqstId.Text);
               
                    var data = db.medicalCommitteeRequests.Where(x => x.Id == id_forEdit).First();
                data.RowStatus = RowStatus.Edited;
                data.UpdateUser = _UserId;
                data.UpdateDate = PLC.getdate();

                var dataDetails = db.medicalCommitteeRequestDetails.Where(x => x.RequestId == id_forEdit).First();
                dataDetails.RowStatus = RowStatus.Edited;
                dataDetails.UpdateUser = _UserId;
                dataDetails.UpdateDate = PLC.getdate();


                db.SaveChanges();

                
            }
            MedicalCommitteeRequest rqst = new MedicalCommitteeRequest();
            MedicalCommitteeRequestDetails rqstDetails = new MedicalCommitteeRequestDetails();

            var id = db.medicalCommitteeRequests .Select(x => x.Id).Max();
            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MedicalCommitteeRequests',RESEED," + id + ");");
            int centerrId =Convert.ToInt32( ExcutingCenter.SelectedValue);

            rqst.Code = y+m+d+usercode+centerrId.ToString("0000") + id;
            rqst.InsurNo = TXTSearch.Text;
            rqst.InsurName = FulName.Text;
            rqst.PhoneNo = phoneNoLBL.Text;
            rqst.Gender =genderlbl.Text ;
            rqst.Address = addressLBL.Text ;
            rqst.Server = clientIdLBL.Text;
            rqst.ClientId =clientIdLBL.Text;
            rqst.BirthDate = BirthDate.Value;
            rqst.SectorName = "";
            rqst.SectorId = 0;
            rqst.CenterFrom = fromCenterDropdown.Text;
            rqst.Note = noteTXT.Text;

            if (transferRadio.IsChecked)
            {
                rqst.RequestType = RequestType.Transfer;
            }
            if (coRadio.IsChecked)
            {
                rqst.RequestType = RequestType.Cooperation;
            }
            if (physiotherapyrb .IsChecked)
            {
                rqst.RequestType = RequestType.Physiotheraby ;
            }
            if (radPageView2.SelectedPage .Name== "CooperationCommittee")
            {
                rqst.RequestType = RequestType.Committee ;
                rqst.MedicalTotal = Convert.ToDecimal(TotalCostTB .Text);
                rqst.CenterId = Convert.ToInt32(Co_Centers.SelectedValue);
                rqst.CenterName = Co_Centers.SelectedText;
            }
            else
            {

                rqst.MedicalTotal = Convert.ToDecimal(TotalCostTXT.Text);
                rqst.CenterId = Convert.ToInt32(ExcutingCenter.SelectedValue);
                rqst.CenterName =ExcutingCenter.Text;
            }


            if (approve_check.Checked)
            {
                rqst.RequestStatus = RequestStatus.confirmed;
            }
            else if (deny_check .Checked)
            {
                rqst.RequestStatus = RequestStatus.deny;
            }
            else if (refund_check .Checked)
            {
                rqst.RequestStatus = RequestStatus.refund_deprtment;
            }

            if (card_typeTB .Text=="0")
            {
                rqst.CardType = CardType.local;
            }
            else if (card_typeTB.Text == "1")
            {
                rqst.CardType = CardType.national ;
            }
            else if (card_typeTB.Text == "2")
            {
                rqst.CardType = CardType.local;
            }
            rqst.ExceptionReason = reason;
            rqst.CoInsurance = coInsuranceType;
            rqst.UserId = _UserId;
            rqst.DateIn = PLC.getdate();
            rqst.RowStatus =RowStatus.NewRow;
            db.medicalCommitteeRequests.Add(rqst);
            db.SaveChanges();

            requestId  =  rqst.Id;
            codelbl.Text = rqst.Code.ToString();

            if (GRDApprove.Rows.Count > 0)
            {
                foreach (var row in GRDApprove.Rows)
                {
                    rqstDetails.RequestId = rqst.Id;
                    rqstDetails.InsurId = TXTSearch.Text;
                    rqstDetails.ServiceId = Convert.ToInt32(row.Cells["ServiceId"].Value.ToString());
                    rqstDetails.Service_Name = row.Cells["ServiceAName"].Value.ToString();
                    rqstDetails.Co_cost = Convert.ToDecimal(row.Cells["CoPrice"].Value.ToString());
                    rqstDetails.Pat_cost = Convert.ToDecimal(row.Cells["PatientPrice"].Value.ToString());
                    rqstDetails.Insur_cost = Convert.ToDecimal(row.Cells["InsurPrice"].Value.ToString());
                    rqstDetails.ServiceCost = Convert.ToDecimal(row.Cells["ServicePrice"].Value.ToString());
                    rqstDetails.AllowCost  = Convert.ToDecimal(row.Cells["allowCost"].Value.ToString());
                    rqstDetails.InvoiceCost = 0;
                    rqstDetails.UserId = _UserId;
                    rqstDetails.DateIn = PLC.getdate();
                    rqstDetails.RowStatus = RowStatus.NewRow;
                    db.medicalCommitteeRequestDetails.Add(rqstDetails);
                    db.SaveChanges();
                }
        }
            else
            {
                
                rqstDetails.RequestId = rqst.Id;
                rqstDetails.InsurId = TXTSearch.Text;
                rqstDetails.ServiceId = Convert.ToInt32(Co_MedicalServicesAR.SelectedValue);
                rqstDetails.Service_Name = Co_MedicalServicesAR.Text ;
                rqstDetails.Co_cost = Convert.ToDecimal(Co_CostTB.Text);
                rqstDetails.Pat_cost = 0;
                rqstDetails.Insur_cost = 0;
                rqstDetails.ServiceCost = Convert.ToDecimal(ServiceCostTB.Text);
                rqstDetails.InvoiceCost =Convert.ToDecimal(InvoiceCostTB.Text);
                rqstDetails.UserId =_UserId;
                rqstDetails.DateIn = PLC.getdate();
                rqstDetails.RowStatus = RowStatus.NewRow;
                db.medicalCommitteeRequestDetails.Add(rqstDetails);
                db.SaveChanges();

            }


    //MessageBox.Show("تم الحفظ بنجاح!");
    print();
            clear();
        }

        private void GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void RqstId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(rqstId .Text);

                if (ID != 0)
                {




                    var data = (from m in db.medicalCommitteeRequests
                                where m.Id == ID
                                select m).First();

               

                    FulName .Text = data.InsurName ;
                    TXTSearch .Text = data.InsurNo;
                    clientIdLBL .Text = data.ClientId;
                    phoneNoLBL .Text = data.PhoneNo ;
                    noteTXT .Text = data.Note;
                    ExcutingCenter.SelectedValue = data.CenterId;
                    ExcutingCenter.Text = data.CenterName ;
                    fromCenterDropdown.Text = data.CenterFrom ;



                GRDApprove.Rows.Clear();
                    var dataDetails = (from m in db.medicalCommitteeRequestDetails
                                             where m.MedicalCommitteeRequest.Id == ID
                                             && m.RowStatus != RowStatus.Deleted
                                             select m).ToList();

                    foreach (var item in dataDetails )
                    {
                        GRDApprove .Rows.Add(i,i, data.InsurNo, 0,item.ServiceId, item.Service_Name ,
                            item.Service_Name, item.Insur_cost , item.Pat_cost , item.ServiceCost, item.Co_cost ,item.AllowCost);


                        i++;
                    }


                }
            }
            catch (Exception ex)
            {

                RadMessageBox.Show(ex.Message);
            }
        }

        private void TransferRadio_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (transferRadio.IsChecked )
            {
                radLabel16.Visible = true;
                radLabel15.Visible = true;
                CoInsuranceTypee.Visible = true;
                ExecptionReason.Visible = true;
                //if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
                //{
                //    PLC.DbCailm.Close();
                //}
                //PLC.DbCailm.Open();

                //SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT  service_id, service_name,service_name_english FROM services where status='T' AND IS_NEW= 'Y' and serv_typ_id !=77 and service_id in ()", PLC.DbCailm);
                //DataTable dtEnService = new DataTable();
                //dtEnService.Clear();
                //da_EN_service.Fill(dtEnService);
                ////if (transferRadio.IsChecked)
                ////{


                ////   MsgBox (dtCenter .Rows .Count)
                //if (dtEnService.Rows.Count > 0)
                //{
                //    MedicalServiceEn.DataSource = dtEnService;
                //    MedicalServiceEn.DisplayMember = "service_name_english";
                //    MedicalServiceEn.ValueMember = "service_id";
                //    MedicalServiceEn.SelectedIndex = -1;
                //    MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                //    MedicalServiceAr.DataSource = dtEnService;
                //    MedicalServiceAr.DisplayMember = "service_name";
                //    MedicalServiceAr.ValueMember = "service_id";
                //    MedicalServiceAr.SelectedIndex = -1;
                //    MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                //}



                ////}
            }
            pat_cost_txt.Text = "0";
            ServiceCost.Text = "0";
            insur_cost_txt.Text = "0";

        }

        private void CoRadio_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (coRadio.IsChecked == true)
            {
                var Cs = db.CooperationServices.ToList();
                MedicalServiceEn.DataSource = Cs;
                MedicalServiceEn.DisplayMember = "Service_EN_Name";
                MedicalServiceEn.ValueMember = "Id";
                MedicalServiceEn.SelectedIndex = -1;
                MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                MedicalServiceAr.DataSource = Cs;
                MedicalServiceAr.DisplayMember = "Service_AR_Name";
                MedicalServiceAr.ValueMember = "Id";
                MedicalServiceAr.SelectedIndex = -1;
                MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;


                radLabel16.Visible = false;
                radLabel15.Visible = false;
                CoInsuranceTypee.Visible = false;
                ExecptionReason.Visible = false;

            }
            pat_cost_txt.Text = "0";
            ServiceCost.Text = "0";
            insur_cost_txt.Text = "0";
        }

        private void MAmount_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           // TXTAmount.Enabled = true;
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDApprove.CurrentColumn.Name == "delete")
            {
                
                int id = Convert.ToInt32(rqstId.Text);
                int serivesId =Convert.ToInt32( GRDApprove.CurrentRow.Cells ["ServiceId"].Value );
                if (id !=0)
                {
                    var del = db.medicalCommitteeRequestDetails.Where(x => x.RequestId == id && x.ServiceId == serivesId).First();
                    del.RowStatus = RowStatus.Deleted;
                    del.UserDeleted = _UserId;
                    del.DeleteDate = PLC.getdate();
                    db.SaveChanges();
                }
               
                GRDApprove.CurrentRow.Delete();
                RadMessageBox.Show("تم الحذف");
            }
        }

        private void NoteTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void Physiotherapyrb_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //if (physiotherapyrb .IsChecked)
            //{
            //    if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
            //    {
            //        PLC.DbCailm.Close();
            //    }
            //    PLC.DbCailm.Open();

            //    SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT  service_id, service_name,service_name_english FROM services where status='T' AND IS_NEW= 'Y' and serv_typ_id =77", PLC.DbCailm);
            //    DataTable dtEnService = new DataTable();
            //    dtEnService.Clear();
            //    da_EN_service.Fill(dtEnService);
            //    //if (transferRadio.IsChecked)
            //    //{


            //    //   MsgBox (dtCenter .Rows .Count)
            //    if (dtEnService.Rows.Count > 0)
            //    {
            //        MedicalServiceEn.DataSource = dtEnService;
            //        MedicalServiceEn.DisplayMember = "service_name_english";
            //        MedicalServiceEn.ValueMember = "service_id";
            //        MedicalServiceEn.SelectedIndex = -1;
            //        MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

            //        MedicalServiceAr.DataSource = dtEnService;
            //        MedicalServiceAr.DisplayMember = "service_name";
            //        MedicalServiceAr.ValueMember = "service_id";
            //        MedicalServiceAr.SelectedIndex = -1;
            //        MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

            //    }



            //    //}
            //}
            //pat_cost_txt.Text = "0";
            //ServiceCost.Text = "0";
            //insur_cost_txt.Text = "0";
        }

        private void Co_CostTB_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                decimal ServiceCost = Convert.ToDecimal(ServiceCostTB.Text);
                decimal CoCost = Convert.ToDecimal(Co_CostTB.Text);
                decimal Inv_Cost = Convert.ToDecimal(InvoiceCostTB.Text);
                decimal totalCost =0;

                totalCost = ServiceCost + CoCost;

                if (Inv_Cost > totalCost)
                {
                    TotalCostTB.Text = totalCost.ToString();
                   // TotalCostTB.Text = string.Format("{0:#,##0.00}", double.Parse(TotalCostTB.Text));
                }
                else
                {
                    RadMessageBox.Show("عفواً،، مبلغ المساهمة أكبر من تكلفة الفاتورة");
                    TotalCostTB.Text ="";
                    return;
                }



            }
            catch (Exception)
            {

               // throw;
            }

        }


       

     
       

       

        private void Co_Centers_KeyDown(object sender, KeyEventArgs e)
        {
            //if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("ar"))
            //{
            //    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            //}
            //else
            //{
            //    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            //}
        }


        private void Co_CostTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Co_CostTB.Text = string.Format("{0:#,##0.00}", double.Parse(Co_CostTB.Text));

        }

        private void InvoiceCostTB_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  InvoiceCostTB.Text = string.Format("{0:#,##0.00}", double.Parse(InvoiceCostTB.Text));

        }

        private void Co_Centers_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                int center_id = Convert.ToInt32(Co_Centers.SelectedValue);

                if (COlistRB.Checked)
                {
                    Co_MedicalServiceEN.DataSource = "";
                    Co_MedicalServicesAR.DataSource = "";

                    var Cs = db.CooperationServices.ToList();
                    Co_MedicalServiceEN.DataSource = Cs;
                    Co_MedicalServiceEN.DisplayMember = "Service_EN_Name";
                    Co_MedicalServiceEN.ValueMember = "Id";
                    Co_MedicalServiceEN.SelectedIndex = -1;
                    Co_MedicalServiceEN.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                    Co_MedicalServicesAR.DataSource = Cs;
                    Co_MedicalServicesAR.DisplayMember = "Service_AR_Name";
                    Co_MedicalServicesAR.ValueMember = "Id";
                    Co_MedicalServicesAR.SelectedIndex = -1;
                    Co_MedicalServicesAR.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                }
                else
                {

                    if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
                    {
                        PLC.DbCailm.Close();
                    }
                    PLC.DbCailm.Open();



                    SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT        dbo.services.service_id, dbo.services.service_name, dbo.services.service_name_english FROM       dbo.services INNER JOIN  dbo.servicecost ON dbo.services.service_id = dbo.servicecost.service_id where dbo.services.status='T' AND dbo.services.IS_NEW= 'Y' and dbo.servicecost.center_id =" + center_id + " ", PLC.DbCailm);
                    DataTable dtEnService = new DataTable();
                    dtEnService.Clear();
                    da_EN_service.Fill(dtEnService);

                    //if (transferRadio.IsChecked)
                    //{


                    //   MsgBox (dtCenter .Rows .Count)
                    if (dtEnService.Rows.Count > 0)
                    {
                        Co_MedicalServiceEN.DataSource = dtEnService;
                        Co_MedicalServiceEN.DisplayMember = "service_name_english";
                        Co_MedicalServiceEN.ValueMember = "service_id";
                        Co_MedicalServiceEN.SelectedIndex = -1;
                        Co_MedicalServiceEN.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                        Co_MedicalServicesAR.DataSource = dtEnService;
                        Co_MedicalServicesAR.DisplayMember = "service_name";
                        Co_MedicalServicesAR.ValueMember = "service_id";
                        Co_MedicalServicesAR.SelectedIndex = -1;
                        Co_MedicalServicesAR.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                    }

                }



            }
            catch (Exception)
            {

                // throw;
            }
        }

        
        private void COlistRB_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (COlistRB .IsChecked )
            {
                Co_MedicalServiceEN.DataSource = "";
                Co_MedicalServicesAR.DataSource = "";

                var Cs = db.CooperationServices.ToList();
                Co_MedicalServiceEN.DataSource = Cs;
                Co_MedicalServiceEN.DisplayMember = "Service_EN_Name";
                Co_MedicalServiceEN.ValueMember = "Id";
                Co_MedicalServiceEN.SelectedIndex = -1;
                Co_MedicalServiceEN.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                Co_MedicalServicesAR.DataSource = Cs;
                Co_MedicalServicesAR.DisplayMember = "Service_AR_Name";
                Co_MedicalServicesAR.ValueMember = "Id";
                Co_MedicalServicesAR.SelectedIndex = -1;
                Co_MedicalServicesAR.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

            }
            else
            {
                Co_MedicalServiceEN.DataSource = "";
                Co_MedicalServicesAR.DataSource = "";
            }
        }

        private void ServiceCostTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(rqstId.Text);
                if (id==0)
                {
                    clear();
                }
                else
                {
                    var del = db.medicalCommitteeRequests.Where(x => x.Id  == id ).First();
                    del.RowStatus = RowStatus.Deleted;
                    del.UserDeleted = _UserId;
                    del.DeleteDate = PLC.getdate();

                    db.SaveChanges();
                    
                }
                RadMessageBox.Show("تم الحذف");
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("لم يتم الحذف"+ ex.Message);
                // throw;
            }
        }


      
        private void TXTSearch_KeyDown(object sender, KeyEventArgs e)
       {
             if (e.KeyCode == Keys.Enter)
            {

                SearchBTN_Click(sender, e);

            }
        }

      

       
        private void MedicalServiceAr_Enter(object sender, EventArgs e)
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

        private void ExcutingCenter_Enter(object sender, EventArgs e)
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

        private void MedicalServiceEn_Enter(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
        }

        private void FromCenterDropdown_Enter(object sender, EventArgs e)
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

        private void Co_MedicalServiceEN_Enter(object sender, EventArgs e)
        {
            if (InputLanguage.InstalledInputLanguages[0].Culture.Name.ToLower().Contains("en"))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[0];
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
            }
        }

        private void Co_MedicalServicesAR_Enter(object sender, EventArgs e)
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

        private void Co_MedicalServiceEN_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

           
            int serviceId = Convert.ToInt32(Co_MedicalServiceEN.SelectedValue);
            int center_id = Convert.ToInt32(Co_Centers.SelectedValue);
            if (COlistRB.Checked)
            {
                var Cs = db.CooperationServices.Where(x => x.Id == serviceId).First();

                MedicalServiceEn.SelectedText = Cs.Service_EN_Name;
                    ServiceCostTB.Text = Cs.Cost;
            }
            else
            {

                SqlDataAdapter da_service = new SqlDataAdapter("SELECT   servicecost,pat_cost,pat_servicecost FROM servicecost where status= 'Active' and center_id=" + center_id + " and service_id=" + serviceId + "", PLC.DbCailm);
                DataTable dtService = new DataTable();
                dtService.Clear();
                da_service.Fill(dtService);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtService.Rows.Count > 0)
                {
                    int serviceCost = Convert.ToInt32(dtService.Rows[0]["pat_servicecost"]) + Convert.ToInt32(dtService.Rows[0]["servicecost"]);
                        ServiceCostTB.Text = serviceCost.ToString();
                }
            }
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void Co_MedicalServicesAR_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

           
            int serviceId = Convert.ToInt32(Co_MedicalServicesAR.SelectedValue);
            int center_id = Convert.ToInt32(Co_Centers.SelectedValue);

            if (COlistRB.Checked)
            {

            
            var Cs = db.CooperationServices.Where(x => x.Id == serviceId).First();

            MedicalServiceEn.SelectedText = Cs.Service_EN_Name;
                    ServiceCostTB.Text = Cs.Cost;
            }
            else
            {

                SqlDataAdapter da_service = new SqlDataAdapter("SELECT   servicecost,pat_cost,pat_servicecost FROM servicecost where status= 'Active' and center_id=" + center_id + " and service_id=" + serviceId + "", PLC.DbCailm);
                DataTable dtService = new DataTable();
                dtService.Clear();
                da_service.Fill(dtService);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtService.Rows.Count > 0)
                {
                    int serviceCost = Convert.ToInt32(dtService.Rows[0]["pat_servicecost"]) + Convert.ToInt32(dtService.Rows[0]["servicecost"]);
                        ServiceCostTB.Text = serviceCost.ToString();
                }
            }
            }
            catch (Exception)
            {

                //   throw;
            }


        }

        private void Co_CostTB_Click(object sender, EventArgs e)
        {

        }

        private void Co_Centers_Enter(object sender, EventArgs e)
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

        private void CoInsuranceTypee_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (CoInsuranceTypee.SelectedIndex == 1)
            {
                radLabel17.Visible = true;
                ExecptionCost.Visible = true;
                allow_cost_txt.Text = pat_cost_txt.Text;
            }
            else
            {
                radLabel17.Visible = false;
                ExecptionCost.Visible = false;
                allow_cost_txt.Text= pat_cost_txt.Text ;
            }
        }
    }
}
