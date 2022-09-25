using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalServiceSystem.SystemSetting;
using ModelDB;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMEstrdadWaiting : Telerik.WinControls.UI.RadForm
    {
        public FRMEstrdadWaiting()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMEstrdadWaiting defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMEstrdadWaiting Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMEstrdadWaiting();
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
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Grid_service_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (Grid_service.RowCount > 0)
            {
                //foreach (var dr in GrdFulPaysheet.Rows)
                ////{
                //if (e.RowElement.RowInfo.Cells["column1"].Value.ToString() == "الاسترداد")
                //{
                //    e.RowElement.DrawFill = true;
                //    e.RowElement.BackColor = Color.LightBlue;
                //}
                //else
                //{
                //    e.RowElement.DrawFill = true;
                //    e.RowElement.BackColor = Color.White;
                //}
            }
        }

        private void FRMEstrdadWaiting_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            using (dbContext db = new dbContext())
            {
                var Fform = db.UserPermissions.Where(p => p.UserId == UserId).ToList();
                if (Fform.Count > 0)
                {
                    var Subfform = Fform.Where(p => p.FormId == 7).ToList();
                    if (Subfform.Count > 0)
                    {
                        var Fmedical = db.Reclaims.Where(p => p.IsMedical == true && p.MedicalTotal == 0).Select(p => new { p.Id, p.ReclaimNo, p.InsurName, p.InsurNo, p.BillsTotal, p.ReclaimDate, p.IsMedical, p.IsMedicine }).ToList();
                        Grid_service.DataSource = Fmedical;
                    }
                    var Subfform1 = Fform.Where(p => p.FormId == 12).ToList();
                    if (Subfform1.Count > 0)
                    {
                        var Fmedical = db.Reclaims.Where(p => p.IsMedicine == true && p.MedicineTotal == 0).Select(p => new { p.Id, p.ReclaimNo, p.InsurName, p.InsurNo, p.BillsTotal, p.ReclaimDate, p.IsMedical, p.IsMedicine }).ToList();
                        Grid_service.DataSource = Fmedical;
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            using (dbContext db = new dbContext())
            {
                var Fform = db.UserPermissions.Where(p => p.UserId == UserId).ToList();
                if (Fform.Count > 0)
                {
                    var Subfform = Fform.Where(p => p.FormId == 7).ToList();
                    if (Subfform.Count > 0)
                    {
                        var Fmedical = db.Reclaims.Where(p => p.IsMedical == true && p.MedicalTotal == 0).Select(p => new { p.ReclaimNo, p.InsurName, p.InsurNo, p.BillsTotal, p.ReclaimDate, p.IsMedical, p.IsMedicine }).ToList();
                        Grid_service.DataSource = Fmedical;
                    }
                    var Subfform1 = Fform.Where(p => p.FormId == 12).ToList();
                    if (Subfform1.Count > 0)
                    {
                        var Fmedical = db.Reclaims.Where(p => p.IsMedicine == true && p.MedicineTotal == 0).Select(p => new { p.ReclaimNo, p.InsurName, p.InsurNo, p.BillsTotal, p.ReclaimDate, p.IsMedical, p.IsMedicine }).ToList();
                        Grid_service.DataSource = Fmedical;
                    }
                }
            }
        }

        private void Grid_service_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            using (dbContext db = new dbContext())
            {

                int RId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                if (Grid_service.CurrentColumn.Name == "Show")
                {


                    var Fform = db.UserPermissions.Where(p => p.UserId == UserId).ToList();
                    if (Fform.Count > 0)
                    {
                        var Subfform = Fform.Where(p => p.FormId == 7).ToList();
                        if (Subfform.Count > 0)
                        {

                            var FRef = db.Reclaims.Where(p => p.Id == RId && p.RowStatus != RowStatus.Deleted).ToList();
                            if (FRef.Count > 0)
                            {
                                if (FRef[0].RefuseMedical == true)
                                {
                                    MessageBox.Show("لقد تم رفض هذه العملية من قبل ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                FRMmedical.Default.ReclaimId = FRef[0].Id;
                                FRMmedical.Default.card_no.Text = FRef[0].InsurNo;
                                FRMmedical.Default.CustName.Text = FRef[0].InsurName;
                                FRMmedical.Default.OperationDate.Value = FRef[0].ReclaimDate;
                                FRMmedical.Default.ApproveReason.SelectedValue = FRef[0].ReclaimMedicalResonId;
                                FRMmedical.Default.ServerName.Text = FRef[0].Server;
                                FRMmedical.Default.initMoney.Text = FRef[0].BillsTotal.ToString();
                                FRMmedical.Default.BillStatus.SelectedIndex = Convert.ToInt32(FRef[0].ReclaimStatus);
                                var FrefMd = db.ReclaimMedicines.Where(p => p.ReclaimId == RId).ToList();
                                if (FrefMd.Count > 0)
                                {
                                    FRMmedical.Default.dwasum.Text = FRef.Sum(p => p.MedicineTotal).ToString();
                                }
                                FRMmedical.Default.RequistingParty.SelectedValue = FRef[0].RefMedicalReqCenterId;
                                FRMmedical.Default.ExcutingParty.SelectedValue = FRef[0].RefMedicalExcCenterId;
                                FRMmedical.Default.FillGrid();
                                string CardNo = FRMmedical.Default.card_no.Text;
                                // var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.InsurNo == CardNo).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.ReclaimDate }).ToList();
                                //var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.InsurNo == CardNo).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.ReclaimDate,System="النظام" }).ToList();
                                var FrHistoryMd = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Reclaims.Id AS Row1, dbo.Reclaims.ReclaimNo AS Row6, dbo.Reclaims.ReclaimDate AS Row13, CenterInfoes_1.CenterName AS Row8, dbo.CenterInfoes.CenterName AS Row9, dbo.InsurNo AS Row10,  dbo.InsurName AS Row15, dbo.MedicalServices.ServiceAName AS Row7, dbo.ReclaimMedicals.Quantity AS Row2, dbo.ReclaimMedicals.ReclaimCost AS Row11, dbo.ReclaimMedicalReasonsLists.MedicalReason AS Row20 FROM dbo.Reclaims INNER JOIN dbo.CenterInfoes AS CenterInfoes_1 ON dbo.Reclaims.RefMedicineExcCenterId = CenterInfoes_1.Id INNER JOIN dbo.CenterInfoes ON dbo.Reclaims.RefMedicineReqCenterId = dbo.CenterInfoes.Id INNER JOIN dbos ON dbo.ReclaimsId = dbo.Id INNER JOIN dbo.ReclaimMedicals ON dbo.Reclaims.Id = dbo.ReclaimMedicals.ReclaimId INNER JOIN dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id INNER JOIN dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id").Where(p => p.Row10 == CardNo).Select(p => new { ReclaimNo = p.Row6, ServiceName = p.Row7, ReclaimDate = p.Row13, System = "الاسترداد", Quantity = p.Row2, ReclaimCost = p.Row11, RequestParty = p.Row9, ExcuteParty = p.Row8, ApproveReason = p.Row20 }).ToList();
                                FRMEstrdadWaiting.Default.Grid_service.DataSource = FrHistoryMd;
                                if (FrHistoryMd.Count > 0)
                                {
                                    for (int i = 0; i < FrHistoryMd.Count; i++)
                                    {
                                        FRMEstrdadWaiting.Default.Grid_service.Rows[i].Cells[0].Value = i + 1;
                                    }
                                    FRMEstrdadWaiting.Default.Totals.Text = FrHistoryMd.Sum(p => p.ReclaimCost).ToString();
                                    FRMEstrdadWaiting.Default.ShowDialog();


                                }
                                Close();
                            }
                        }
                        var Subfform1 = Fform.Where(p => p.FormId == 12).ToList();
                        if (Subfform1.Count > 0)
                        {
                            db.Database.CommandTimeout = 0;
                            var FRef = db.Reclaims.Where(p => p.Id == RId && p.RowStatus != RowStatus.Deleted).ToList();
                            if (FRef.Count > 0)
                            {
                                if (FRef[0].RefuseMedicine == true)
                                {
                                    MessageBox.Show("لقد تم رفض هذه العملية من قبل ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                FRMmedicine.Default.ReclaimId = FRef[0].Id;
                                FRMmedicine.Default.card_no.Text = FRef[0].InsurNo;
                                FRMmedicine.Default.CustName.Text = FRef[0].InsurName;
                                FRMmedicine.Default.OperationDate.Value = FRef[0].ReclaimDate;
                                FRMmedicine.Default.approvereason.SelectedValue = FRef[0].ReclaimMedicineResonId;
                                FRMmedicine.Default.ServerName.Text = FRef[0].Server;
                                FRMmedicine.Default.initMoney.Text = FRef[0].BillsTotal.ToString();
                                FRMmedicine.Default.RequistingParty.SelectedValue = FRef[0].RefMedicineReqCenterId;
                                FRMmedicine.Default.BillStatus.SelectedIndex = Convert.ToInt32(FRef[0].ReclaimStatus);
                                FRMmedicine.Default.ExcutingParty.SelectedValue = FRef[0].RefMedicineExcCenterId;
                                //var FrefMd = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                                // medicalsum.Text = FRef[0].MedicineTotal.ToString();
                                FRMmedicine.Default.FillGrid();
                                var Med = db.ReclaimMedicals.Where(p => p.ReclaimId == RId).ToList();
                                decimal MedSum = 0;
                                if (Med.Count > 0)
                                {
                                    MedSum = db.ReclaimMedicals.Where(p => p.ReclaimId == RId).Sum(p => p.ReclaimTotal);
                                }
                                FRMmedicine.Default.medicalsum.Text = MedSum.ToString();
                                string CardNo = FRMmedicine.Default.card_no.Text;
                                var FrHistoryMc = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Reclaims.Id AS Row1, dbo.Reclaims.ReclaimNo AS Row6, dbo.Reclaims.ReclaimDate AS Row13, dbo.MedicineForReclaims.Generic_name AS Row7, dbo.ReclaimMedicines.Quantity AS Row2,  dbo.ReclaimMedicines.ReclaimCost AS Row11, dbo.ReclaimMedicines.ReclaimTotal AS Row12, CenterInfoes_1.CenterName AS Row8, dbo.CenterInfoes.CenterName AS Row9, dbo.InsurNo AS Row10,  dbo.InsurName AS Row15, dbo.Reclaims.RowStatus, dbo.ReclaimMedicineReasonsLists.MedicineReason  AS Row20 FROM dbo.Reclaims INNER JOIN dbo.ReclaimMedicines ON dbo.Reclaims.Id = dbo.ReclaimMedicines.ReclaimId INNER JOIN  dbo.MedicineForReclaims ON dbo.ReclaimMedicines.MedicineId = dbo.MedicineForReclaims.Id INNER JOIN  dbo.CenterInfoes AS CenterInfoes_1 ON dbo.Reclaims.RefMedicineExcCenterId = CenterInfoes_1.Id INNER JOIN dbo.CenterInfoes ON dbo.Reclaims.RefMedicineReqCenterId = dbo.CenterInfoes.Id INNER JOIN dbos ON dbo.ReclaimsId = dbo.Id INNER JOIN  dbo.ReclaimMedicineReasonsLists ON dbo.Reclaims.ReclaimMedicineResonId = dbo.ReclaimMedicineReasonsLists.Id WHERE (dbo.Reclaims.RowStatus <> 2) AND (dbo.InsurNo = '" + CardNo.ToString() + "')").Select(p => new { ReclaimNo = p.Row6, ServiceName = p.Row7, ReclaimDate = p.Row13, System = "الاسترداد", Quantity = p.Row2, ReclaimCost = p.Row11, RequestParty = p.Row9, ExcuteParty = p.Row8, ApproveReason = p.Row20 }).ToList();
                                // var FrHistoryMd = db.Database.SqlQuery<ReportForAll>("SELECT  dbo.Reclaims.Id AS Row1, dbo.Reclaims.ReclaimNo AS Row6, dbo.Reclaims.ReclaimDate AS Row13, CenterInfoes_1.CenterName AS Row8, dbo.CenterInfoes.CenterName AS Row9, dbo.InsurNo AS Row10,  dbo.InsurName AS Row15, dbo.MedicalServices.ServiceAName AS Row7, dbo.ReclaimMedicals.Quantity AS Row2, dbo.ReclaimMedicals.ReclaimCost AS Row11 FROM dbo.Reclaims INNER JOIN dbo.CenterInfoes AS CenterInfoes_1 ON dbo.Reclaims.RefMedicineExcCenterId = CenterInfoes_1.Id INNER JOIN dbo.CenterInfoes ON dbo.Reclaims.RefMedicineReqCenterId = dbo.CenterInfoes.Id INNER JOIN dbos ON dbo.ReclaimsId = dbo.Id INNER JOIN dbo.ReclaimMedicals ON dbo.Reclaims.Id = dbo.ReclaimMedicals.ReclaimId INNER JOIN dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id").Where(p => p.Row10 == CardNo).Select(p => new { ReclaimNo = p.Row6, ServiceName = p.Row7, ReclaimDate = p.Row13, System = "الاسترداد", Qunatity = p.Row2, ReclaimCost = p.Row11 }).ToList();
                                if (FrHistoryMc.Count > 0)
                                {
                                    FRMEstrdadWaiting.Default.Grid_service.DataSource = FrHistoryMc;
                                    if (FrHistoryMc.Count > 0)
                                    {
                                        for (int i = 0; i < FrHistoryMc.Count; i++)
                                        {
                                            FRMEstrdadWaiting.Default.Grid_service.Rows[i].Cells[0].Value = i + 1;
                                        }

                                    }
                                    FRMEstrdadWaiting.Default.Totals.Text = FrHistoryMc.Sum(p => p.ReclaimCost).ToString();
                                    FRMEstrdadWaiting.Default.ShowDialog();
                                }
                                
                            }
                            Close();
                        }
                    }
                }
            }
        }
    }
}
