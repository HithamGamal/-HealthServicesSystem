using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMApproveSearch : Telerik.WinControls.UI.RadForm
    {
        public FRMApproveSearch()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }



        private static FRMApproveSearch defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMApproveSearch Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMApproveSearch();
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
        public string StrRPT;

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                db.Database.CommandTimeout = 0;
                var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row6 == card_no.Text).OrderBy(p => p.Row13).ToList();
                Cursor = Cursors.WaitCursor;
                Grid_service.DataSource = GetDet;
                if (GetDet.Count > 0)
                {
                    for (int i = 0; i < GetDet.Count; i++)
                    {
                        Grid_service.Rows[i].Cells[0].Value = i + 1;
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Cursor = Cursors.Default;
                    return;
                }
            }
        }

        private void FRMApproveSearch_Load(object sender, EventArgs e)
        {
            StrRPT = "SELECT  dbo.Users.Id, dbo.InsurNo AS Row6, dbo.InsurName AS Row7, dbo.ApproveMedicines.ApproveDate AS Row13, dbo.ApproveMedicineTypes.ApproveType AS Row8, dbo.Diagnosis.DiagnosisName AS Row9, dbo.Pharmacists.pharmacistName AS Row10, dbo.CenterInfoes.CenterName AS Row15, CenterInfoes_1.CenterName AS Row16, dbo.Server AS Row17 , dbo.MedicineForReclaims.Generic_name AS Row18, dbo.ApproveMedicineDetails.ApprovedQuantity AS Row2, dbo.ApproveMedicineDetails.Quantity AS Row3, dbo.ApproveMedicines.ApproveCode AS Row19,  dbo.ApproveMedicines.Atachment AS Row20 FROM dbo.ApproveMedicines INNER JOIN  dbo.ApproveMedicineTypes ON dbo.ApproveMedicines.ApproveTypeId = dbo.ApproveMedicineTypes.Id INNER JOIN dbo.Diagnosis ON dbo.ApproveMedicines.DiagnosisId = dbo.Diagnosis.Id INNER JOIN dbo.Pharmacists ON dbo.ApproveMedicines.pharmacistId = dbo.Pharmacists.Id INNER JOIN dbos ON dbo.ApproveMedicines.InsurId = dbo.Id INNER JOIN dbo.CenterInfoes ON dbo.ApproveMedicines.ExcCenterId = dbo.CenterInfoes.Id INNER JOIN dbo.CenterInfoes AS CenterInfoes_1 ON dbo.ApproveMedicines.ReqCenterId = CenterInfoes_1.Id INNER JOIN dbo.Users ON dbo.ApproveMedicines.UserId = dbo.Users.Id INNER JOIN dbo.ApproveMedicineDetails ON dbo.ApproveMedicines.Id = dbo.ApproveMedicineDetails.ApproveMedicineId INNER JOIN dbo.MedicineForReclaims ON dbo.ApproveMedicineDetails.ServiceId = dbo.MedicineForReclaims.Id where dbo.ApproveMedicines.Rowstatus<>2 ";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ApproveCode.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال كود التصديق", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                db.Database.CommandTimeout = 0;
                var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && (p.Row19 == ApproveCode.Text || p.Row20== ApproveCode.Text)).OrderBy(p => p.Row13).ToList();
                Cursor = Cursors.WaitCursor;
                Grid_service.DataSource = GetDet;
                if (GetDet.Count > 0)
                {
                    for (int i = 0; i < GetDet.Count; i++)
                    {
                        Grid_service.Rows[i].Cells[0].Value = i + 1;
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Cursor = Cursors.Default;
                    return;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            card_no.Clear();
            ApproveCode.Clear();
            Grid_service.DataSource = null;
        }
    }
    }
