using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ModelDB;
using Telerik.WinControls;
using System.Data.SqlClient;

namespace HealthServicesSystem.Reclaims
{
    public partial class FRMChronicWaitList : Telerik.WinControls.UI.RadForm
    {
        public int LocalityId = 0;
        public FRMChronicWaitList()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMChronicWaitList defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMChronicWaitList Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMChronicWaitList();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Grid_service_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            //if (Grid_service.RowCount > 0)
            //{
            //    //foreach (var dr in GrdFulPaysheet.Rows)
            //    //{
            //    if (e.RowElement.RowInfo.Cells["column1"].Value.ToString() == "الاسترداد")
            //    {
            //        e.RowElement.DrawFill = true;
            //        e.RowElement.BackColor = Color.LightBlue;
            //    }
            //    else
            //    {
            //        e.RowElement.DrawFill = true;
            //        e.RowElement.BackColor = Color.White;
            //    }
            //}
        }

        private void FRMChronicWaitList_Load(object sender, EventArgs e)
        {
            LocalityId = SystemSetting.LoginForm.Default.LocalityId;
            using (ModelDB.dbContext db = new ModelDB.dbContext())
            {
                if (PLC.conNew.State == ConnectionState.Open)
                {
                    PLC.conNew.Close();
                }
                PLC.conNew.Open();
                DateTime Dat1 = PLC.getdate().AddDays(-3);
                DateTime Dat2 = PLC.getdate().AddDays(1);
                var Flocal = db.Localities.Where(p => p.Id == LocalityId).ToList();
                string LocalityName = "بحري";
                string srr = "SELECT  [Id],[InsuranceNo],[CustomerName],[PayDate],[Id] as DocNo FROM [InsuranceSystem].[dbo].[CustomerPayments] Where PayDate between '" + Dat1 + "' and '" + Dat2 + "' and (PayTypeId=4 or PayTypeId=6 or PayTypeId=8) and BrachName=N'" + LocalityName + "'";
                //MessageBox.Show(srr);
                SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                DataTable dtsearch = new DataTable();
                dtsearch.Clear();
                dasearch.Fill(dtsearch);
                radGridView1.Rows.Clear();
                int a = 0;
                if (dtsearch.Rows.Count > 0)
                {
                   // MessageBox.Show(dtsearch.Rows.Count.ToString());
                    for (int i = 0; i < dtsearch.Rows.Count; i++)
                    {
                        decimal DocNo = Convert.ToDecimal(dtsearch.Rows[i]["DocNo"]);
                        string InsurNo = dtsearch.Rows[i]["InsuranceNo"].ToString();
                        // MessageBox.Show(InsurNo);
                        var FPay = db.ChronicsBooks.Where(p => p.InsurNo == InsurNo).Select(p => new { p.DocNo }).ToList();
                        if (FPay.Count > 0)
                        {
                            var Fdoc = FPay.Where(p => p.DocNo == DocNo).ToList();
                            if (Fdoc.Count==0)
                            {
                                a += 1;
                                radGridView1.Rows.Add("عرض", a, dtsearch.Rows[i]["PayDate"], dtsearch.Rows[i]["InsuranceNo"], dtsearch.Rows[i]["CustomerName"], dtsearch.Rows[i]["Id"], dtsearch.Rows[i]["DocNo"]);
                            }
                        }
                    }
                }
                PLC.conNew.Close();
            }
        }

        private void Grid_service_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //if (Grid_service.RowCount > 0)
            //{
            //    using (ModelDB.dbContext db = new ModelDB.dbContext())
            //    {
            //        int AppId= Convert.ToInt32(e.Row.Cells["Id"].Value);
            //        FRMApproveMedicine.Default.ApproveNo = AppId;
            //        if (Grid_service.CurrentColumn.Name == "Show")
            //        {
            //            var GetApp = db.ApproveMedicines.Where(p => p.Id == AppId && p.RowStatus != RowStatus.Deleted).ToList();
            //          //  MessageBox.Show(GetApp.Count.ToString());
            //            if (GetApp.Count > 0)
            //            {     
                            
            //                FRMApproveMedicine.Default.card_no.Text = GetApp[0].InsurNo;
            //                FRMApproveMedicine.Default.OperationDate.Value = GetApp[0].ApproveDate;
            //                FRMApproveMedicine.Default.RouchitaNo.Text = GetApp[0].RouchitaNo.ToString();
            //                FRMApproveMedicine.Default.Sex.Text = GetApp[0].Gender;
            //                FRMApproveMedicine.Default.CustName.Text = GetApp[0].InsurName;
            //                FRMApproveMedicine.Default.ServerName.Text = GetApp[0].Server;
            //                FRMApproveMedicine.Default.RequistingParty.SelectedValue = GetApp[0].ReqCenterId;
            //                FRMApproveMedicine.Default.ExcutingParty.SelectedValue = GetApp[0].ExcCenterId;
            //                FRMApproveMedicine.Default.Diagnosis.SelectedValue = GetApp[0].DiagnosisId;
            //                FRMApproveMedicine.Default.pharmacist.SelectedValue = GetApp[0].pharmacistId;
            //                FRMApproveMedicine.Default.ApproveType.SelectedValue = GetApp[0].ApproveTypeId;
            //                FRMApproveMedicine.Default.Atachment.Text = GetApp[0].Atachment;
            //                FRMApproveMedicine.Default.Age.Text = DateAndTime.DateDiff(DateInterval.Year, GetApp[0].BirthDate, PLC.getdate()).ToString();
            //                FRMApproveMedicine.Default.Saved = true;
            //                FRMApproveMedicine.Default.ApprovementId.Text = "كود التصديق" + ":   " + GetApp[0].ApproveCode.ToString();
            //                FRMApproveMedicine.Default.FillGrid();
            //                Close();
            //            }
            //        }
            //    }
            //}
        }

        private void RadGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                using (ModelDB.dbContext db = new ModelDB.dbContext())
                {
                    int AppId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                    FrmRefuseMedicine.Default.ApproveId = AppId;
                    if (radGridView1.CurrentColumn.Name == "Show")
                    {
                        FRMBookInfo.Default.UserId =SystemSetting. LoginForm.Default.UserId;
                        FRMBookInfo.Default.LocalityId = PLC.LocalityId;

                        FRMBookInfo.Default.LoadData();
                        FRMBookInfo.Default.card_no.Text = e.Row.Cells["InsuranceNo"].Value.ToString();
                        FRMBookInfo.Default.BTNSearch.PerformClick();

                        FRMBookInfo.Default.Show();
                        


                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LocalityId = SystemSetting.LoginForm.Default.LocalityId;
            using (ModelDB.dbContext db = new ModelDB.dbContext())
            {
                if (PLC.conNew.State == ConnectionState.Open)
                {
                    PLC.conNew.Close();
                }
                PLC.conNew.Open();
                DateTime Dat1 = PLC.getdate().AddDays(-3);
                DateTime Dat2 = PLC.getdate().AddDays(1);
                var Flocal = db.Localities.Where(p => p.Id == LocalityId).ToList();
                string LocalityName = "امدرمان";
                string srr = "SELECT  [Id],[InsuranceNo],[CustomerName],[PayDate],[Id] as DocNo FROM [InsuranceSystem].[dbo].[CustomerPayments] Where PayDate between '" + Dat1 + "' and '" + Dat2 + "' and (PayTypeId=4 or PayTypeId=6 or PayTypeId=8) and BrachName=N'" + LocalityName + "'";
                //MessageBox.Show(srr);
                SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                DataTable dtsearch = new DataTable();
                dtsearch.Clear();
                dasearch.Fill(dtsearch);
                radGridView1.Rows.Clear();
                int a = 0;
                if (dtsearch.Rows.Count > 0)
                {
                    // MessageBox.Show(dtsearch.Rows.Count.ToString());
                    for (int i = 0; i < dtsearch.Rows.Count; i++)
                    {
                        decimal DocNo = Convert.ToDecimal(dtsearch.Rows[i]["DocNo"]);
                        string InsurNo = dtsearch.Rows[i]["InsuranceNo"].ToString();
                        // MessageBox.Show(InsurNo);
                        var FPay = db.ChronicsBooks.Where(p =>p.InsurNo == InsurNo).Select(p => new { p.DocNo }).ToList();
                        if (FPay.Count > 0)
                        {
                            var Fdoc = FPay.Where(p => p.DocNo == DocNo).ToList();
                            if (Fdoc.Count == 0)
                            {
                                a += 1;
                            radGridView1.Rows.Add("عرض", a, dtsearch.Rows[i]["PayDate"], dtsearch.Rows[i]["InsuranceNo"], dtsearch.Rows[i]["CustomerName"], dtsearch.Rows[i]["Id"], dtsearch.Rows[i]["DocNo"]);
                            }
                        }
                    }
                }
                PLC.conNew.Close();
            }
        }
    }
}
