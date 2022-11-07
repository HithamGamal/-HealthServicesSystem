﻿using HealthServicesSystem.SystemSetting;
using Microsoft.VisualBasic;
using ModelDB;
using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using HealthServicesSystem.Reclaims;
using Telerik.WinControls;

namespace HealthServicesSystem.Refunds
{
    public partial class FRMMedicalCommitee : Telerik.WinControls.UI.RadForm
    {
        public string ServerName;
        public int UserId = 0;
        public int LocalityId = 0;
        int i = 1;
        decimal totalCost = 0;
        dbContext db = new dbContext();
        public FRMMedicalCommitee()
        {
            InitializeComponent();
        }

        private void FRMMedicalCommitee_Load(object sender, EventArgs e)
        {
            using (dbContext  db = new dbContext())
            {

                DateTime date1 = PLC.getdate();
                UserId = LoginForm.Default.UserId;
                LocalityId = PLC.LocalityId;
                if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
                {
                    PLC.DbCailm.Close();
                }
                PLC.DbCailm.Open();
                SqlDataAdapter daCenter = new SqlDataAdapter("SELECT   center_id,center_name FROM   centers   where center_status= 'فعال'", PLC.DbCailm);
                DataTable dtCenter = new DataTable();
                dtCenter.Clear();
                daCenter.Fill(dtCenter);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtCenter.Rows.Count > 0)
                {
                    ExcutingCenter.DataSource = dtCenter;
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
        }

        private void GRDApprove_Click(object sender, EventArgs e)
        {

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
                            this.Cursor = Cursors.Default;
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
                        string srr = "select top 1 * from Cards where InsuranceNo=" + insurance_no + " and RowStatus<>2";
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
                            if (Information.IsDBNull(dtsearch.Rows[0]["Thirdname"]) == false)
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
                            //CustName.Text = Convert.ToString(dtsearch.Rows[0]["Firstname"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["Secondname"]).Trim() + " " + stri1 + " " + str2;
                            //if (Convert.ToInt32(dtsearch.Rows[0]["Gender"].ToString()) == 0)
                            //{
                            //    sex.Text = "ذكر";
                            //}
                            //else
                            //{
                            //    sex.Text = "انثى";
                            //}
                            //if (dtsearch.Rows[0]["Phone"] == null)
                            //{
                            //    Phone.Text = dtsearch.Rows[0]["Phone"].ToString();
                            //}
                            //else
                            //{
                            //    Phone.Text = "";
                            //}
                            ////Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                            //Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                            ////Birthdate.Value = dtsearch.Rows(0)("birth_date")
                            //ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                            //Rec_No = dtsearch.Rows[0]["ClientId"].ToString();
                            //string serv = "select top 1 * from Clients where Id=" + ClientId + "";
                            //SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                            //DataTable dtServ = new DataTable();
                            //dtServ.Clear();
                            //DaServ.Fill(dtServ);
                            //if (dtServ.Rows.Count > 0)
                            //{
                            //    ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                            //    SectorId = Convert.ToInt32(dtServ.Rows[0]["SubSectorId"]);
                            //    string Sec = "select top 1 * from SubSectors where Id=" + SectorId + "";
                            //    SqlDataAdapter DaSec = new SqlDataAdapter(Sec, PLC.conNew);
                            //    DataTable dtSec = new DataTable();
                            //    dtSec.Clear();
                            //    DaSec.Fill(dtSec);
                            //    if (dtSec.Rows.Count > 0)
                            //    {
                            //        SectorName = dtSec.Rows[0]["SectorName"].ToString();
                            //    }
                            //}
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
            TotalCostTXT.Text = "";
            TXTSearch.Text = "";
            MedicalServiceEn.SelectedIndex = -1;
            MedicalServiceAr.SelectedIndex = -1;
            ExcutingCenter.SelectedIndex =-1;
            totalCost = 0;
            TXTAmount.Text = "";
            MAmount.CheckState = CheckState.Unchecked;
            MPercentage.CheckState = CheckState.Unchecked;
            approve_check.CheckState = CheckState.Unchecked;
            deny_check.CheckState = CheckState.Unchecked;
            GRDApprove.Rows.Clear();
            rqstId.Text = "";
            FulName.Text = "";
            pat_cost_txt.Text = "";
            ServiceCost.Text = "";
            insur_cost_txt.Text = "";
            rqstId.Text = "0";
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
            string service_id = MedicalServiceAr.SelectedValue.ToString();
            decimal Service_Cost =Convert.ToDecimal( ServiceCost .Text);
            decimal patient_cost = Convert.ToDecimal(pat_cost_txt .Text);
            decimal insurance_cost = Convert.ToDecimal(insur_cost_txt .Text);

          
            GRDApprove.Rows.Add(i,i,insurance_no,centerId,service_id, medical_service_en, medical_service_ar, Service_Cost, insurance_cost,patient_cost );

            i++;

            MedicalServiceEn.SelectedIndex = -1;
            MedicalServiceAr.SelectedIndex = -1;
            ServiceCost.Text = "";
            pat_cost_txt .Text = "";
            insur_cost_txt.Text = "";
            totalCost += insurance_cost;
            TotalCostTXT.Text = totalCost.ToString();
        }

        public void print()
        {
            if (transferRadio.IsChecked || coRadio.IsChecked )
            {
                int id = Convert.ToInt32(rqstId.Text);
                TransferRPT rpt = new TransferRPT();
                var data = db.medicalCommitteeRequestDetails.Where(x => x.RequestId == id).Select(x => new { service_id = x.ServiceId, pat_cost = x.Pat_cost, service_Name = x.Service_Name }).ToList();
                rpt.DataSource = data;
                rpt.rqstId.Value = rqstId.Text;
                rpt.centername.Value = ExcutingCenter.Text;
                rpt.patientname.Value = FulName.Text;
                rpt.insur_no.Value = TXTSearch.Text;
                rpt.cor_no.Value = clientIdLBL.Text;
                rpt.rqst_date.Value = DateTime.Today.Date.ToShortDateString();
                rpt.phone_no.Value = phoneNoLBL.Text;
                rpt.cost .Value = ServiceCost .Text;
                rpt.note.Value = noteTXT.Text;

                RequestFrmRPT frm = new RequestFrmRPT();

                frm.reportViewer1.ReportSource = rpt;
                frm.reportViewer1.RefreshReport();
                frm.Show();

                //////RequestFrmRPT pr = new RequestFrmRPT();
                //////PrintDialog pg = new PrintDialog();
                //////pr.PrintReport(rpt, pg.PrinterSettings);
            }
            if (physiotherapyrb.IsChecked)
            {
                int id = Convert.ToInt32(rqstId.Text);
                physiotherapy_session_rpt   rpt = new physiotherapy_session_rpt();
                
                rpt.rqstId.Value = rqstId.Text;
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
            if ( MedicalServiceEn.SelectedIndex != -1)
            {
                try
                {
                    int service_id =Convert.ToInt32( MedicalServiceEn.SelectedValue);
                    int center_id = Convert.ToInt32(ExcutingCenter .SelectedValue);
                    SqlDataAdapter da_service = new SqlDataAdapter("SELECT   servicecost,pat_cost,pat_servicecost FROM servicecost where status= 'Active' and center_id=" + center_id +" and service_id="+service_id +"", PLC.DbCailm);
                    DataTable dtService = new DataTable();
                    dtService.Clear();
                    da_service.Fill(dtService);
                    //   MsgBox (dtCenter .Rows .Count)
                    if (dtService .Rows.Count > 0)
                    {
                        pat_cost_txt.Text = dtService.Rows[0]["pat_cost"].ToString();
                        ServiceCost.Text = dtService.Rows[0]["servicecost"].ToString();
                        insur_cost_txt .Text = dtService.Rows[0]["pat_servicecost"].ToString();
                    }
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

                


                if (PLC.DbCailm.State == (System.Data.ConnectionState)1)
                {
                    PLC.DbCailm.Close();
                }
                PLC.DbCailm.Open();

                SqlDataAdapter da_EN_service = new SqlDataAdapter("SELECT   service_id,service_name_english FROM services where status='T' ", PLC.DbCailm);
                DataTable dtEnService = new DataTable();
                dtEnService.Clear();
                da_EN_service.Fill(dtEnService);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtEnService.Rows.Count > 0)
                {
                    MedicalServiceEn.DataSource = dtEnService;
                    MedicalServiceEn.DisplayMember = "service_name_english";
                    MedicalServiceEn.ValueMember = "service_id";
                    MedicalServiceEn.SelectedIndex = -1;
                    MedicalServiceEn.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                    MedicalServiceAr.DataSource = dtEnService ;
                    MedicalServiceAr.DisplayMember = "service_name";
                    MedicalServiceAr.ValueMember = "service_id";
                    MedicalServiceAr.SelectedIndex = -1;
                    MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                }


                SqlDataAdapter da_AR_service = new SqlDataAdapter("SELECT   service_id,service_name FROM services where status='T'", PLC.DbCailm);
                DataTable dtARService = new DataTable();
                dtARService.Clear();
                da_AR_service.Fill(dtARService);
                //   MsgBox (dtCenter .Rows .Count)
                if (dtARService.Rows.Count > 0)
                {

                    MedicalServiceAr.DataSource = dtARService;
                    MedicalServiceAr.DisplayMember = "service_name";
                    MedicalServiceAr.ValueMember = "service_id";
                    MedicalServiceAr.SelectedIndex = -1;
                    MedicalServiceAr.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void MedicalServiceAr_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
                        pat_cost_txt.Text = dtService.Rows[0]["pat_cost"].ToString();
                        ServiceCost.Text = dtService.Rows[0]["servicecost"].ToString();
                        insur_cost_txt.Text = dtService.Rows[0]["pat_servicecost"].ToString();
                    }
                    else
                    {
                        RadMessageBox.Show("عفواً،،الخدمة غير متوفرة في هذا المركز");
                    }

                    if (coRadio.IsChecked == true)
                    {
                        var da = db.CooperationServices.Where(x => x.Id == service_id).First();
                        pat_cost_txt.Text = "0";
                        ServiceCost.Text = da.Cost ;
                        insur_cost_txt.Text = da.Cost;
                    }

                }
                catch (Exception)
                {

                    //  throw;
                }

                
            }

        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            MedicalCommitteeRequest rqst = new MedicalCommitteeRequest();
            MedicalCommitteeRequestDetails rqstDetails = new MedicalCommitteeRequestDetails();

            rqst.InsurNo = TXTSearch.Text;
            rqst.InsurName = FulName.Text;
            rqst.PhoneNo = phoneNoLBL.Text;
            rqst.Gender = "";
            rqst.Address = "";
            rqst.Server = "";
            rqst.ClientId =clientIdLBL.Text;
            rqst.BirthDate = BirthDate.Value;
            rqst.SectorName = "";
            rqst.SectorId = 0;
            rqst.MedicalTotal =Convert.ToDecimal( TotalCostTXT.Text);
            rqst.CenterId =Convert.ToInt32( ExcutingCenter.SelectedValue);
            rqst.Date_In =DateTime.Today.Date;
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
           
            rqst.rowStatus =RowStatus.NewRow;
            db.medicalCommitteeRequests.Add(rqst);
            db.SaveChanges();

            rqstId.Text  =  rqst.Id.ToString();
            foreach (var row in GRDApprove.Rows)
            {
                rqstDetails.RequestId = rqst.Id;
                rqstDetails.InsurId = TXTSearch.Text;
                rqstDetails.ServiceId =Convert.ToInt32( row.Cells["ServiceId"].Value.ToString());
                rqstDetails.Service_Name  = row.Cells["ServiceAName"].Value.ToString();
                rqstDetails.Pat_cost  = Convert.ToDecimal(row.Cells["PatientPrice"].Value.ToString());
                rqstDetails.Insur_cost  = Convert.ToDecimal(row.Cells["InsurPrice"].Value.ToString());
                rqstDetails.ServiceCost = Convert.ToDecimal(row.Cells["ServicePrice"].Value.ToString());
                rqstDetails.RowStatus = RowStatus.NewRow;
                db.medicalCommitteeRequestDetails.Add(rqstDetails);
                db.SaveChanges();
            }



            MessageBox.Show("تم الحفظ بنجاح!");
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




                    var dataDetails = (from m in db.medicalCommitteeRequestDetails
                                             where m.MedicalCommitteeRequest.Id == ID
                                             && m.RowStatus != RowStatus.Deleted
                                             select m).ToList();

                    foreach (var item in dataDetails )
                    {
                        GRDApprove .Rows.Add(i,i, data.InsurNo, 0,item.ServiceId, item.Service_Name ,
                            item.Service_Name, item.Insur_cost , item.Pat_cost , item.ServiceCost);

                        i++;
                    }


                }
            }
            catch
            {
                //   RadMessageBox.Show(IdLabel.Text);
            }
        }

        private void TransferRadio_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //if (transferRadio.IsChecked == true)
            //{
            //    MessageBox.Show("TransferRadio");
            //    return;
            //}
            //else if (coRadio.IsChecked == true)
            //{
            //    MessageBox.Show("CoRadio");
            //    return;
            //}
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

            }
        }

        private void MAmount_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            TXTAmount.Enabled = true;
        }

        private void MasterTemplate_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDApprove.CurrentColumn.Name == "delete")
            {
                
                int id = Convert.ToInt32(rqstId.Text);
                int serivesId =Convert.ToInt32( GRDApprove.CurrentRow.Cells ["ServiceId"].Value );
                var del = db.medicalCommitteeRequestDetails.Where(x=>x.RequestId== id && x.ServiceId== serivesId ).First();
                del.RowStatus = RowStatus.Deleted;
                db.SaveChanges();
                GRDApprove.CurrentRow.Delete();
                RadMessageBox.Show("تم الحذف");
            }
        }

        private void NoteTXT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
