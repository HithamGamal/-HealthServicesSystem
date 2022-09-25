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

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMpatienthistory : Telerik.WinControls.UI.RadForm
    {
        public FRMpatienthistory()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMpatienthistory defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMpatienthistory Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMpatienthistory();
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
            if (Grid_service.RowCount > 0)
            {
                //foreach (var dr in GrdFulPaysheet.Rows)
                //{
                if (e.RowElement.RowInfo.Cells["column1"].Value.ToString() == "الاسترداد")
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = Color.LightBlue;
                }
                else
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = Color.White;
                }
            }
        }

        private void FRMpatienthistory_Load(object sender, EventArgs e)
        {

        }

        private void Grid_service_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (Grid_service.RowCount > 0)
            {
                using (ModelDB.dbContext db = new ModelDB.dbContext())
                {
                    int AppId= Convert.ToInt32(e.Row.Cells["Id"].Value);
                    FRMApproveMedicine.Default.ApproveNo = AppId;
                    if (Grid_service.CurrentColumn.Name == "Show")
                    {
                        var GetApp = db.ApproveMedicines.Where(p => p.Id == AppId && p.RowStatus != RowStatus.Deleted).ToList();
                      //  MessageBox.Show(GetApp.Count.ToString());
                        if (GetApp.Count > 0)
                        {     
                            
                            FRMApproveMedicine.Default.card_no.Text = GetApp[0].InsurNo;
                            FRMApproveMedicine.Default.OperationDate.Value = GetApp[0].ApproveDate;
                            FRMApproveMedicine.Default.RouchitaNo.Text = GetApp[0].RouchitaNo.ToString();
                            FRMApproveMedicine.Default.Sex.Text = GetApp[0].Gender;
                            FRMApproveMedicine.Default.CustName.Text = GetApp[0].InsurName;
                            FRMApproveMedicine.Default.ServerName.Text = GetApp[0].Server;
                            FRMApproveMedicine.Default.RequistingParty.SelectedValue = GetApp[0].ReqCenterId;
                            FRMApproveMedicine.Default.ExcutingParty.SelectedValue = GetApp[0].ExcCenterId;
                            FRMApproveMedicine.Default.Diagnosis.SelectedValue = GetApp[0].DiagnosisId;
                            FRMApproveMedicine.Default.pharmacist.SelectedValue = GetApp[0].pharmacistId;
                            FRMApproveMedicine.Default.ApproveType.SelectedValue = GetApp[0].ApproveTypeId;
                            FRMApproveMedicine.Default.Atachment.Text = GetApp[0].Atachment;
                            FRMApproveMedicine.Default.Age.Text = DateAndTime.DateDiff(DateInterval.Year, GetApp[0].BirthDate, PLC.getdate()).ToString();
                            FRMApproveMedicine.Default.Saved = true;
                            FRMApproveMedicine.Default.ApprovementId.Text = "كود التصديق" + ":   " + GetApp[0].ApproveCode.ToString();
                            FRMApproveMedicine.Default.FillGrid();
                            Close();
                        }
                    }
                }
            }
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
                        FrmRefuseMedicine.Default.ShowDialog();
                    }
                }
            }
        }
    }
}
