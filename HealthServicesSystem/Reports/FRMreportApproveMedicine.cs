using System;
using System.Windows.Forms;
using System.Data;
//using System.Data.sql;
using System.Data.SqlClient;
using ModelDB;
using System.Linq;
using MedicalServiceSystem.Reports;

namespace MedicalServiceSystem
{

    public partial class FRMreportApproveMedicine : Telerik.WinControls.UI.RadForm
    {
        internal FRMreportApproveMedicine()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMreportApproveMedicine defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMreportApproveMedicine Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMreportApproveMedicine();
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
        public string StrRPT;
        private void SimpleButton1_Click(object sender, System.EventArgs e)
        {


        }

        private void reports_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ;
        }

        private void reports_Load(object sender, System.EventArgs e)
        {
            d_start.Value = PLC.getdate();
            d_end.Value = PLC.getdate();
            UserId = SystemSetting.LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;
            using (dbContext db = new dbContext())
            {

                var pharm = db.Pharmacists.Where(p => p.Activated == 1).ToList();
                pharmacist.DataSource = pharm;
                pharmacist.DisplayMember = "pharmacistName";
                pharmacist.ValueMember = "Id";
                pharmacist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                pharmacist.SelectedIndex = -1;
                var diagnos = db.Diagnoses.Where(p => p.Activated == 1).ToList();
                Diagnosis.DataSource = diagnos;
                Diagnosis.DisplayMember = "DiagnosisName";
                Diagnosis.ValueMember = "Id";
                Diagnosis.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                Diagnosis.SelectedIndex = -1;
                var ReqCenter = db.CenterInfos.Where(p => (p.CenterTypeId == CenterType.مركز || p.CenterTypeId == CenterType.مركزوصيدلية) && p.HasContract == true && p.IsVisible == true).ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;

                var ExcCenter = db.CenterInfos.Where(p => (p.CenterTypeId == CenterType.صيدلية || p.CenterTypeId == CenterType.مركزوصيدلية) && p.HasContract == true && p.IsVisible == true).ToList();
                ExcutingParty.DataSource = ExcCenter;
                ExcutingParty.ValueMember = "Id";
                ExcutingParty.DisplayMember = "CenterName";
                ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ExcutingParty.SelectedIndex = -1;
                StrRPT = "SELECT  dbo.Users.Id, dbo.ApproveMedicines.InsurNo AS Row6, dbo.ApproveMedicines.InsurName AS Row7, dbo.ApproveMedicines.ApproveDate AS Row13, dbo.ApproveMedicineTypes.ApproveType AS Row8, dbo.Diagnosis.DiagnosisName AS Row9, dbo.Pharmacists.pharmacistName AS Row10, dbo.CenterInfoes.CenterName AS Row15, CenterInfoes_1.CenterName AS Row16, dbo.ApproveMedicines.Server AS Row17 , dbo.MedicineForReclaims.Generic_name AS Row18, dbo.ApproveMedicineDetails.ApprovedQuantity AS Row2, dbo.ApproveMedicineDetails.Quantity AS Row3 FROM dbo.ApproveMedicines INNER JOIN  dbo.ApproveMedicineTypes ON dbo.ApproveMedicines.ApproveTypeId = dbo.ApproveMedicineTypes.Id INNER JOIN dbo.Diagnosis ON dbo.ApproveMedicines.DiagnosisId = dbo.Diagnosis.Id INNER JOIN dbo.Pharmacists ON dbo.ApproveMedicines.pharmacistId = dbo.Pharmacists.Id INNER JOIN dbo.CenterInfoes ON dbo.ApproveMedicines.ExcCenterId = dbo.CenterInfoes.Id INNER JOIN dbo.CenterInfoes AS CenterInfoes_1 ON dbo.ApproveMedicines.ReqCenterId = CenterInfoes_1.Id INNER JOIN dbo.Users ON dbo.ApproveMedicines.UserId = dbo.Users.Id INNER JOIN dbo.ApproveMedicineDetails ON dbo.ApproveMedicines.Id = dbo.ApproveMedicineDetails.ApproveMedicineId INNER JOIN dbo.MedicineForReclaims ON dbo.ApproveMedicineDetails.ServiceId = dbo.MedicineForReclaims.Id where dbo.ApproveMedicines.Rowstatus<>2 ";
            }

        }

        [Obsolete]
        private void Rd_books_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_books.Checked)
            {
                card_no.Clear();
                Diagnosis.SelectedIndex = -1;
                pharmacist.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {

                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => p.Row13 >= d_start.Value && p.Row13 <= d_end.Value).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value)).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        rd_books.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rd_books.Checked = false;
                        return;
                    }
                }

            }
        }

        private void Rd_center_CheckedChanged(object sender, EventArgs e)
        {
            if (RDSubDetails.Checked)
            {
                if (card_no.Text.Length == 0)
                {
                    MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    card_no.Focus();
                    RDSubDetails.Checked = false;
                    return;
                }
                Diagnosis.SelectedIndex = -1;
                pharmacist.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row6 == card_no.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب المشترك" + " " + GetDet[0].Row7;
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.InsurNo == card_no.Text).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        RDSubDetails.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDSubDetails.Checked = false;
                        return;
                    }
                }
            }
        }

        private void Rd_chronic_CheckedChanged(object sender, EventArgs e)
        {
            if (RdDiosDetails.Checked)
            {
                if (Diagnosis.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار التشخيص", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Diagnosis.Focus();
                    RdDiosDetails.Checked = false;
                    return;
                }


                card_no.Clear();
                pharmacist.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;


                using (dbContext db = new dbContext())
                {

                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row9 == Diagnosis.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب التشخيص" + " " + Diagnosis.Text;
                        int DioId = Convert.ToInt32(Diagnosis.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.DiagnosisId == DioId).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        RdDiosDetails.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RdDiosDetails.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (RDpharmDetails.Checked)
            {
                if (pharmacist.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار اسم الصيدلي", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pharmacist.Focus();
                    RDpharmDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                Diagnosis.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row10 == pharmacist.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب الصيدلي" + " " + pharmacist.Text;
                        int pharmacistId = Convert.ToInt32(pharmacist.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.pharmacistId == pharmacistId).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        RDpharmDetails.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDpharmDetails.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDBookTYP_CheckedChanged(object sender, EventArgs e)
        {
            if (RDpharmacyDetails.Checked)
            {

                if (ExcutingParty.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار الصيدلية المقدمة للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ExcutingParty.Focus();
                    RDpharmacyDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                Diagnosis.SelectedIndex = -1;
                pharmacist.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row15 == ExcutingParty.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب الصيدلية" + " " + ExcutingParty.Text;
                        int ExcutingPartyId = Convert.ToInt32(ExcutingParty.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.ExcCenterId == ExcutingPartyId).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        RDpharmacyDetails.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDpharmacyDetails.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (RDCenterDetails.Checked)
            {
                if (RequistingParty.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار المركز المقدم للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RequistingParty.Focus();
                    RDCenterDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                Diagnosis.SelectedIndex = -1;
                pharmacist.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row16 == RequistingParty.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِApproveMedicineDetails Rdet = new RPTِApproveMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب مقدم الخدمة" + " " + RequistingParty.Text;
                        int RequistingPartyId = Convert.ToInt32(RequistingParty.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.ReqCenterId == RequistingPartyId).ToList().Count.ToString();
                        Rdet.DwaCNT.Value = GetDet.Count.ToString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        Cursor = Cursors.Default;
                        RDCenterDetails.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDCenterDetails.Checked = false;
                        return;
                    }

                }
            }
        }

        private void GroupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RDUser_CheckedChanged(object sender, EventArgs e)
        {
            if (RDUser.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Users.FullName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN dbo.Users ON dbo.ApproveMedicines.UserId = dbo.Users.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.Users.FullName ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDUser.Text;
                        Rdet.ReportٍSubject.Value = "اسم المستخدم";
                        Rdet.ReportٍSubject1.Value = "اسم المستخدم";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDUser.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDUser.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDDios_CheckedChanged(object sender, EventArgs e)
        {
            if (RDDios.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Diagnosis.DiagnosisName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.Diagnosis ON dbo.ApproveMedicines.DiagnosisId = dbo.Diagnosis.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.Diagnosis.DiagnosisName ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDDios.Text;
                        Rdet.ReportٍSubject.Value = "التشخيص";
                        Rdet.ReportٍSubject1.Value = "التشخيص";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDDios.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDUser.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDpharm_CheckedChanged(object sender, EventArgs e)
        {
            if (RDpharm.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Pharmacists.pharmacistName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN dbo.Pharmacists ON dbo.ApproveMedicines.pharmacistId = dbo.Pharmacists.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.Pharmacists.pharmacistName ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDpharm.Text;
                        Rdet.ReportٍSubject.Value = "اسم الصيدلي";
                        Rdet.ReportٍSubject1.Value = "اسم الصيدلي";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDpharm.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDpharm.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDPharamcy_CheckedChanged(object sender, EventArgs e)
        {
            if (RDPharamcy.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.CenterInfoes.CenterName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.CenterInfoes ON  dbo.ApproveMedicines.ExcCenterId = dbo.CenterInfoes.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.CenterInfoes.CenterName ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDPharamcy.Text;
                        Rdet.ReportٍSubject.Value = "اسم الصيدلية";
                        Rdet.ReportٍSubject1.Value = "اسم الصيدلية";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDPharamcy.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDPharamcy.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (RDCenter.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.CenterInfoes.CenterName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.CenterInfoes  ON dbo.ApproveMedicines.ReqCenterId = dbo.CenterInfoes.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.CenterInfoes.CenterName ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDCenter.Text;
                        Rdet.ReportٍSubject.Value = "اسم مقدم المركز";
                        Rdet.ReportٍSubject1.Value = "اسم مقدم المركز";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDCenter.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDCenter.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDAppType_CheckedChanged(object sender, EventArgs e)
        {
            if (RDAppType.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.ApproveMedicineTypes.ApproveType AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.ApproveMedicineTypes ON dbo.ApproveMedicines.ApproveTypeId = dbo.ApproveMedicineTypes.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.ApproveMedicineTypes.ApproveType ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDAppType.Text;
                        Rdet.ReportٍSubject.Value = "اسم نوع التصديق";
                        Rdet.ReportٍSubject1.Value = "اسم نوع التصديق";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDAppType.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDAppType.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDServerCNT_CheckedChanged(object sender, EventArgs e)
        {
            if (RDServerCNT.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.ApproveMedicines.Server AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.ApproveMedicines.Server ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِApproveMedicineCount Rdet = new RPTِApproveMedicineCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDServerCNT.Text;
                        Rdet.ReportٍSubject.Value = "اسم المخدم";
                        Rdet.ReportٍSubject1.Value = "اسم المخدم";
                        Rdet.Frequency.Value = "عدد التصاديق";
                        Rdet.Frequency1.Value = "عدد التصاديق";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDServerCNT.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDServerCNT.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RDDwaCNT_CheckedChanged(object sender, EventArgs e)
        {
            if (RDDwaCNT.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.MedicineForReclaims.Generic_name AS Row6, SUM(dbo.ApproveMedicineDetails.Quantity) AS Row2, SUM(dbo.ApproveMedicineDetails.ApprovedQuantity)  AS Row3, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN dbo.ApproveMedicineDetails ON dbo.ApproveMedicines.Id = dbo.ApproveMedicineDetails.ApproveMedicineId INNER JOIN dbo.MedicineForReclaims ON dbo.ApproveMedicineDetails.ServiceId = dbo.MedicineForReclaims.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.MedicineForReclaims.Generic_name ORDER BY Row1 DESC").ToList();
                    if (GetCent.Count > 0)
                    {
                        RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDDwaCNT.Text;
                        Rdet.ReportٍSubject.Value = "اسم الدواء";
                        Rdet.ReportٍSubject1.Value = "اسم الدواء";
                        Rdet.Frequency.Value = "عدد الأدوية";
                        Rdet.Frequency1.Value = "عدد الأدوية";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        RDDwaCNT.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDDwaCNT.Checked = false;
                        return;
                    }
                }
            }
        }
    }
}
