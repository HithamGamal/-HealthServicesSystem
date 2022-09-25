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

    public partial class FRMRPTMedicalEStrdad : Telerik.WinControls.UI.RadForm
    {
        internal FRMRPTMedicalEStrdad()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMRPTMedicalEStrdad defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMRPTMedicalEStrdad Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMRPTMedicalEStrdad();
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
        public string LocalityName = "";
        public string LocalityName1 = "";
        public string LocalityName2 = "";
        public string OrderedBy = "";
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
            DrGrouping.SelectedIndex = 0;
            GroupingBy.SelectedIndex = 0;
            using (dbContext db = new dbContext())
            {
                var GetUser = db.Users.Where(p => p.Id == UserId).ToList();
                if (GetUser.Count > 0)
                {

                    if (GetUser[0].UserType == UserType.User)
                    {
                        LocalityName = "dbo.Reclaims.LocalityId=" + LocalityId + " And";
                        LocalityName1 = " dbo.ReclaimMedicines.LocalityId=" + LocalityId + " And";
                        LocalityName2 = " dbo.ReclaimMedicals.LocalityId=" + LocalityId + " And";
                    }
                }
                var ReclaimRes = db.ReclaimMedicalReasonsLists.Where(p => p.Activated == true).ToList();
                ApproveReason.DataSource = ReclaimRes;
                ApproveReason.DisplayMember = "MedicalReason";
                ApproveReason.ValueMember = "Id";
                ApproveReason.SelectedIndex = -1;

                var ReqCenter = db.CenterInfos.ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;

                var ExcCenter = db.CenterInfos.ToList();
                ExcutingParty.DataSource = ReqCenter;
                ExcutingParty.ValueMember = "Id";
                ExcutingParty.DisplayMember = "CenterName";
                ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ExcutingParty.SelectedIndex = -1;
                BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                StrRPT = "SELECT dbo.Reclaims.InsurNo AS Row6, dbo.Reclaims.InsurName AS Row7, dbo.Reclaims.ReclaimDate AS Row13, dbo.ReclaimMedicineReasonsLists.MedicineReason AS Row8,  dbo.ReclaimMedicalReasonsLists.MedicalReason AS Row10, CenterInfoes_3.CenterName AS Row9, CenterInfoes_2.CenterName AS Row15, CenterInfoes_1.CenterName AS Row16, dbo.CenterInfoes.CenterName AS Row18,  dbo.Reclaims.MedicalTotal AS Row11, dbo.Reclaims.MedicineTotal AS Row12, dbo.Reclaims.ReclaimTotal AS Row21,convert(decimal,dbo.Reclaims.ReclaimStatus) AS Row2 FROM dbo.Reclaims INNER JOIN dbo.ReclaimMedicineReasonsLists ON dbo.Reclaims.ReclaimMedicineResonId = dbo.ReclaimMedicineReasonsLists.Id INNER JOIN dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id INNER JOIN dbo.CenterInfoes ON dbo.Reclaims.RefMedicineExcCenterId = dbo.CenterInfoes.Id INNER JOIN   dbo.CenterInfoes AS CenterInfoes_1 ON dbo.Reclaims.RefMedicineReqCenterId = CenterInfoes_1.Id INNER JOIN  dbo.CenterInfoes AS CenterInfoes_2 ON dbo.Reclaims.RefMedicalExcCenterId = CenterInfoes_2.Id INNER JOIN dbo.CenterInfoes AS CenterInfoes_3 ON dbo.Reclaims.RefMedicalReqCenterId = CenterInfoes_3.Id  WHERE " + LocalityName + "  (dbo.Reclaims.RowStatus <> 2)";
            }

        }

        [Obsolete]
        private void Rd_books_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_books.Checked)
            {
                card_no.Clear();
                ApproveReason.SelectedIndex = -1;
                BillStatus.SelectedIndex = -1;
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
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ApproveCnt.Value = db.Reclaims.Where(p => p.RowStatus != RowStatus.Deleted && (p.ReclaimDate >= d_start.Value && p.ReclaimDate <= d_end.Value)).ToList().Count.ToString();
                        //Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                //Diagnosis.SelectedIndex = -1;
                //pharmacist.SelectedIndex = -1;
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
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل التصاديق الدوائية" + " " + "حسب المشترك" + " " + GetDet[0].Row7;
                        Rdet.ApproveCnt.Value = db.ApproveMedicines.Where(p => p.RowStatus != RowStatus.Deleted && (p.ApproveDate >= d_start.Value && p.ApproveDate <= d_end.Value) && p.InsurNo == card_no.Text).ToList().Count.ToString();
                        //Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                if (ApproveReason.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار سبب الاسترداد خدمة طبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ApproveReason.Focus();
                    RdDiosDetails.Checked = false;
                    return;
                }


                card_no.Clear();
                BillStatus.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;


                using (dbContext db = new dbContext())
                {

                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row10 == ApproveReason.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل الاسترداد" + " " + "حسب سبب الاسترداد" + " " + ApproveReason.Text;
                        int DioId = Convert.ToInt32(ApproveReason.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = db.Reclaims.Where(p => p.RowStatus != RowStatus.Deleted && (p.ReclaimDate >= d_start.Value && p.ReclaimDate <= d_end.Value) && p.ReclaimMedicalResonId == DioId).ToList().Count.ToString();
                        // Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                if (BillStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("يجب اختيار نوع الاسترداد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BillStatus.Focus();
                    RDpharmDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                ApproveReason.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row2 == BillStatus.SelectedIndex).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل الاسترداد" + " " + "حسب نوع الوصفة" + " " + BillStatus.Text;
                        int BillStatusId = Convert.ToInt32(BillStatus.SelectedIndex.ToString());
                        Rdet.ApproveCnt.Value = GetDet.ToList().Count.ToString();
                        //Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                    MessageBox.Show("يجب اختيار الجهة المقدمة للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ExcutingParty.Focus();
                    RDpharmacyDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                ApproveReason.SelectedIndex = -1;
                BillStatus.SelectedIndex = -1;
                RequistingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row16 == ExcutingParty.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل الاسترداد" + " " + "حسب الجهة المقدمة للخدمة" + " " + ExcutingParty.Text;
                        int ExcutingPartyId = Convert.ToInt32(ExcutingParty.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = GetDet.Count.ToString();
                        // Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                    MessageBox.Show("يجب اختيار المركز الطالب للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RequistingParty.Focus();
                    RDCenterDetails.Checked = false;
                    return;
                }
                card_no.Clear();
                BillStatus.SelectedIndex = -1;
                ApproveReason.SelectedIndex = -1;
                ExcutingParty.SelectedIndex = -1;
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var GetDet = db.Database.SqlQuery<ReportForAll>(StrRPT).Where(p => (p.Row13 >= d_start.Value && p.Row13 <= d_end.Value) && p.Row18 == RequistingParty.Text).OrderBy(p => p.Row13).ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        RPTِEstrdadMedicineDetails Rdet = new RPTِEstrdadMedicineDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = "تقرير تفاصيل الاسترداد" + " " + "حسب الجهة المقدمة للخدمة" + " " + RequistingParty.Text;
                        int RequistingPartyId = Convert.ToInt32(RequistingParty.SelectedValue.ToString());
                        Rdet.ApproveCnt.Value = GetDet.Count.ToString();
                        // Rdet.DwaCNT.Value = GetDet.Count.ToString();
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
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.Users.FullName AS Row6,convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21  FROM  dbo.ReclaimMedicals INNER JOIN dbo.Users ON dbo.ReclaimMedicals.UserId = dbo.Users.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) GROUP BY dbo.Users.FullName ORDER BY  " + OrderedBy; ;
                    }
                    else
                    {
                        StrQuery = "SELECT dbo.Localities.LocalityName AS Row7, dbo.Users.FullName AS Row6,convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21 FROM dbo.ReclaimMedicals INNER JOIN dbo.Users ON dbo.ReclaimMedicals.UserId = dbo.Users.Id INNER JOIN  dbo.Localities ON dbo.ReclaimMedicals.LocalityId = dbo.Localities.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) GROUP BY dbo.Users.FullName, dbo.Localities.LocalityName order by " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDUser.Text;
                            Rdet.ReportٍSubject.Value = "اسم المستخدم";
                            Rdet.ReportٍSubject1.Value = "اسم المستخدم";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDUser.Text;
                            Rdet.ReportٍSubject.Value = "اسم المستخدم";
                            Rdet.ReportٍSubject1.Value = "اسم المستخدم";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
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
            //if (RDDios.Checked == true)
            //{
            //    using (dbContext db = new dbContext())
            //    {
            //        db.Database.CommandTimeout = 0;
            //        var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Diagnosis.DiagnosisName AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.Diagnosis ON dbo.ApproveMedicines.DiagnosisId = dbo.Diagnosis.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.Diagnosis.DiagnosisName ORDER BY Row1 DESC").ToList();
            //        if (GetCent.Count > 0)
            //        {
            //            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
            //            Rdet.DataSource = GetCent;
            //            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
            //            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
            //            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
            //            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDDios.Text;
            //            Rdet.ReportٍSubject.Value = "التشخيص";
            //            Rdet.ReportٍSubject1.Value = "التشخيص";
            //            Rdet.Frequency.Value = "عدد التصاديق";
            //            Rdet.Frequency1.Value = "عدد التصاديق";
            //            RptiewChronics.ReportSource = Rdet;
            //            RptiewChronics.RefreshReport();
            //            RptiewChronics.Show();
            //            RDDios.Checked = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            RDUser.Checked = false;
            //            return;
            //        }
            //    }
            //}
        }

        private void RDpharm_CheckedChanged(object sender, EventArgs e)
        {
            if (RDpharm.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.ReclaimMedicalReasonsLists.MedicalReason as Row6,convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0  GROUP BY dbo.ReclaimMedicalReasonsLists.MedicalReason ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT  dbo.Localities.LocalityName AS Row7,  dbo.ReclaimMedicalReasonsLists.MedicalReason as Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id  WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "'   and MedicalTotal>0    GROUP BY dbo.ReclaimMedicalReasonsLists.MedicalReason, dbo.Localities.LocalityName   ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDpharm.Text;
                            Rdet.ReportٍSubject.Value = "أسباب الاسترداد خدمة طبية";
                            Rdet.ReportٍSubject1.Value = "أسباب الاسترداد خدمة طبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDpharm.Text;
                            Rdet.ReportٍSubject.Value = "أسباب الاسترداد خدمة طبية";
                            Rdet.ReportٍSubject1.Value = "أسباب الاسترداد خدمة طبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }


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
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.CenterInfoes.CenterName AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.CenterInfoes ON dbo.Reclaims.RefMedicalExcCenterId = dbo.CenterInfoes.Id WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2  and MedicalTotal>0  GROUP BY dbo.CenterInfoes.CenterName ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT dbo.Localities.LocalityName AS Row7,dbo.CenterInfoes.CenterName AS Row6,convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.CenterInfoes ON dbo.Reclaims.RefMedicalExcCenterId = dbo.CenterInfoes.Id INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id   WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and MedicalTotal>0  GROUP BY dbo.CenterInfoes.CenterName, dbo.Localities.LocalityName ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد تصاديق الاسترداد حسب" + " " + RDPharamcy.Text;
                            Rdet.ReportٍSubject.Value = "اسم الجهة المنفذة";
                            Rdet.ReportٍSubject1.Value = "اسم الجهة المنفذة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد تصاديق الاسترداد حسب" + " " + RDPharamcy.Text;
                            Rdet.ReportٍSubject.Value = "اسم الجهة المنفذة";
                            Rdet.ReportٍSubject1.Value = "اسم الجهة المنفذة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";

                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
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
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.CenterInfoes.CenterName AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.CenterInfoes ON dbo.Reclaims.RefMedicalReqCenterId = dbo.CenterInfoes.Id WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and MedicalTotal>0 GROUP BY dbo.CenterInfoes.CenterName ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT dbo.Localities.LocalityName AS Row7,  dbo.CenterInfoes.CenterName AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims INNER JOIN  dbo.CenterInfoes ON dbo.Reclaims.RefMedicalReqCenterId = dbo.CenterInfoes.Id INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id    WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and MedicalTotal>0 GROUP BY dbo.CenterInfoes.CenterName, dbo.Localities.LocalityName  ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد تصاديق الاسترداد حسب" + " " + RDCenter.Text;
                            Rdet.ReportٍSubject.Value = "اسم الجهةالطالبة";
                            Rdet.ReportٍSubject1.Value = "اسم الجهةالطالبة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد تصاديق الاسترداد حسب" + " " + RDCenter.Text;
                            Rdet.ReportٍSubject.Value = "اسم الجهةالطالبة";
                            Rdet.ReportٍSubject1.Value = "اسم الجهةالطالبة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
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
            //if (RDAppType.Checked == true)
            //{
            //    using (dbContext db = new dbContext())
            //    {
            //        db.Database.CommandTimeout = 0;
            //        var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.ApproveMedicineTypes.ApproveType AS Row6, COUNT(dbo.ApproveMedicines.Id) AS Row1 FROM dbo.ApproveMedicines INNER JOIN  dbo.ApproveMedicineTypes ON dbo.ApproveMedicines.ApproveTypeId = dbo.ApproveMedicineTypes.Id WHERE dbo.ApproveMedicines.ApproveDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.ApproveMedicines.RowStatus<>2 GROUP BY dbo.ApproveMedicineTypes.ApproveType ORDER BY Row1 DESC").ToList();
            //        if (GetCent.Count > 0)
            //        {
            //            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
            //            Rdet.DataSource = GetCent;
            //            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
            //            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
            //            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
            //            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDAppType.Text;
            //            Rdet.ReportٍSubject.Value = "اسم نوع التصديق";
            //            Rdet.ReportٍSubject1.Value = "اسم نوع التصديق";
            //            Rdet.Frequency.Value = "عدد التصاديق";
            //            Rdet.Frequency1.Value = "عدد التصاديق";
            //            RptiewChronics.ReportSource = Rdet;
            //            RptiewChronics.RefreshReport();
            //            RptiewChronics.Show();
            //            RDAppType.Checked = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            RDAppType.Checked = false;
            //            return;
            //        }
            //    }
            //}
        }

        private void RDServerCNT_CheckedChanged(object sender, EventArgs e)
        {
            if (RDServerCNT.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.Reclaims.Server AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.ReclaimTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row21 FROM  dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and dbo.Reclaims.ReclaimTotal>0 GROUP BY dbo.Reclaims.Server ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT  dbo.Localities.LocalityName AS Row7,   dbo.Reclaims.Server AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.ReclaimTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row21 FROM  dbo.Reclaims INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and dbo.Reclaims.ReclaimTotal>0 GROUP BY dbo.Reclaims.Server, dbo.Localities.LocalityName ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDServerCNT.Text;
                            Rdet.ReportٍSubject.Value = "اسم المخدم";
                            Rdet.ReportٍSubject1.Value = "اسم المخدم";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + RDServerCNT.Text;
                            Rdet.ReportٍSubject.Value = "اسم المخدم";
                            Rdet.ReportٍSubject1.Value = "اسم المخدم";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
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
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.MedicalServices.ServiceAName AS Row6, Sum(Convert(decimal,dbo.ReclaimMedicals.Quantity)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) As Row12,(select SUM(Convert(decimal,dbo.ReclaimMedicals.Quantity)) from dbo.ReclaimMedicals WHERE  " + LocalityName1 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE  " + LocalityName1 + "  ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21 FROM dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) and MedicalServices.ListType=0  GROUP BY dbo.MedicalServices.ServiceAName ORDER BY " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT   dbo.Localities.LocalityName AS Row7,  dbo.MedicalServices.ServiceAName AS Row6, Sum(Convert(decimal,dbo.ReclaimMedicals.Quantity)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) As Row12,(select SUM(Convert(decimal,dbo.ReclaimMedicals.Quantity)) from dbo.ReclaimMedicals WHERE  " + LocalityName1 + "  ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE  " + LocalityName1 + "  ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21 FROM dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id   INNER JOIN dbo.Localities ON dbo.ReclaimMedicals.LocalityId = dbo.Localities.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)  and MedicalServices.ListType=0 GROUP BY dbo.MedicalServices.ServiceAName , dbo.Localities.LocalityName ORDER BY " + OrderedBy; ;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            RDDwaCNT.Checked = false;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            RDDwaCNT.Checked = false;
                        }
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

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT N'الاسترداد خدمة دوائية' as Row6,Convert(decimal,Count(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicineTotal) As Row12,(select Convert(decimal,Count(dbo.Reclaims.Id)) from dbo.Reclaims WHERE  " + LocalityName + "   dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE  " + LocalityName + "  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) as Row21 FROM [MedicalServiceDb].[dbo].Reclaims where " + LocalityName1 + "  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.MedicineTotal>0 union SELECT N'الاسترداد خدمة طبية' as Row6,Convert(decimal,Count(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) As Row12,(select Convert(decimal,Count(dbo.Reclaims.Id)) from dbo.Reclaims WHERE  " + LocalityName1 + "  (dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "') And RowStatus<>2) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE  " + LocalityName1 + "  (dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "') And RowStatus<>2) as Row21 FROM [MedicalServiceDb].[dbo].Reclaims where " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.MedicalTotal>0";
                    }
                    else
                    {
                        StrQuery = "SELECT  dbo.Localities.LocalityName AS Row7, N'الاسترداد خدمة دوائية' as Row6,Convert(decimal,Count(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicineTotal) As Row12,(select Convert(decimal,Count(dbo.Reclaims.Id)) from dbo.Reclaims WHERE  " + LocalityName1 + "   dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE  " + LocalityName1 + "  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) as Row21 FROM [MedicalServiceDb].[dbo].Reclaims   INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id where " + LocalityName1 + "  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.MedicineTotal>0 group by  dbo.Localities.LocalityName union SELECT  dbo.Localities.LocalityName AS Row7, N'الاسترداد خدمة طبية' as Row6,Convert(decimal,Count(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) As Row12,(select Convert(decimal,Count(dbo.Reclaims.Id)) from dbo.Reclaims WHERE  " + LocalityName1 + "  (dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "') And RowStatus<>2) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE  " + LocalityName1 + "  (dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "') And RowStatus<>2) as Row21 FROM [MedicalServiceDb].[dbo].Reclaims INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id where " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.MedicalTotal>0  group by dbo.Localities.LocalityName  ";
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();

                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = radioButton1.Text;
                            Rdet.ReportٍSubject.Value = "نوع الخدمة";
                            Rdet.ReportٍSubject1.Value = "نوع الخدمة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            radioButton1.Checked = false;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = radioButton1.Text;
                            Rdet.ReportٍSubject.Value = "نوع الخدمة";
                            Rdet.ReportٍSubject1.Value = "نوع الخدمة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            radioButton1.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        radioButton1.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT case when ReclaimStatus= 0 then N'مرت بالتأمين'  else N'لم تمر بالتأمين' end as Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' And (RowStatus <> 2) and MedicalTotal>0  GROUP BY case when ReclaimStatus= 0 then N'مرت بالتأمين'  else N'لم تمر بالتأمين' end ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT  dbo.Localities.LocalityName AS Row7, case when ReclaimStatus= 0 then N'مرت بالتأمين'  else N'لم تمر بالتأمين' end as Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row3,(select SUM(dbo.Reclaims.MedicalTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and MedicalTotal>0 ) as Row21 FROM dbo.Reclaims  INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' And (RowStatus <> 2) and MedicalTotal>0 GROUP BY case when ReclaimStatus= 0 then N'مرت بالتأمين'  else N'لم تمر بالتأمين' end , dbo.Localities.LocalityName ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + radioButton2.Text;
                            Rdet.ReportٍSubject.Value = "حالة الوصفة";
                            Rdet.ReportٍSubject1.Value = "حالة الوصفة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;

                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب" + " " + radioButton2.Text;
                            Rdet.ReportٍSubject.Value = "حالة الوصفة";
                            Rdet.ReportٍSubject1.Value = "حالة الوصفة";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        radioButton2.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        radioButton2.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.MedicalServices.ServiceAName AS Row6,convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12 )) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12 ) ) as Row21 FROM dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12 )    GROUP BY dbo.MedicalServices.ServiceAName ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT   dbo.Localities.LocalityName AS Row7,  dbo.MedicalServices.ServiceAName AS Row6, convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12) ) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12 )) as Row21 FROM dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id   INNER JOIN dbo.Localities ON dbo.ReclaimMedicals.LocalityId = dbo.Localities.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2 and Reclaims.ReclaimMedicalResonId=12)     GROUP BY dbo.MedicalServices.ServiceAName , dbo.Localities.LocalityName ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            radioButton3.Checked = false;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            radioButton3.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        radioButton3.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";

                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT dbo.MedicalServices.ServiceAName AS Row6, COUNT(dbo.ReclaimMedicals.Id) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12, SUM(dbo.MedicalServices.ServicePrice) AS Row11,  SUM(dbo.ReclaimMedicals.ReclaimCost) - SUM(dbo.MedicalServices.ServicePrice) AS Row21, dbo.ReclaimMedicalReasonsLists.Id FROM  dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id INNER JOIN dbo.Reclaims ON dbo.ReclaimMedicals.ReclaimId = dbo.Reclaims.Id INNER JOIN  dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id WHERE    " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)     and   (dbo.MedicalServices.ListType = 1) and (dbo.MedicalServices.ListType = 1) GROUP BY dbo.MedicalServices.ServiceAName, dbo.ReclaimMedicalReasonsLists.Id HAVING        (dbo.ReclaimMedicalReasonsLists.Id = 36) ORDER BY " + OrderedBy;

                    }
                    else
                    {
                        StrQuery = "SELECT dbo.Localities.LocalityName AS Row7, dbo.MedicalServices.ServiceAName AS Row6, COUNT(dbo.ReclaimMedicals.Id) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12, SUM(dbo.MedicalServices.ServicePrice) AS Row11,  SUM(dbo.ReclaimMedicals.ReclaimCost) - SUM(dbo.MedicalServices.ServicePrice) AS Row21, dbo.ReclaimMedicalReasonsLists.Id FROM  dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id INNER JOIN dbo.Reclaims ON dbo.ReclaimMedicals.ReclaimId = dbo.Reclaims.Id INNER JOIN  dbo.ReclaimMedicalReasonsLists ON dbo.Reclaims.ReclaimMedicalResonId = dbo.ReclaimMedicalReasonsLists.Id    INNER JOIN dbo.Localities ON dbo.ReclaimMedicals.LocalityId = dbo.Localities.Id  WHERE    " + LocalityName + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)     and   (dbo.MedicalServices.ListType = 1) and (dbo.MedicalServices.ListType = 1) GROUP BY dbo.MedicalServices.ServiceAName, dbo.ReclaimMedicalReasonsLists.Id , dbo.Localities.LocalityName HAVING        (dbo.ReclaimMedicalReasonsLists.Id = 36) ORDER BY " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCommittee Rdet = new RPTِEstrdadCommittee();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية مساهمات";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.textBox12.Value = "سقف الاسترداد";
                            Rdet.textBox15.Value = "سقف الاسترداد";
                            Rdet.textBox14.Value = "مساهمة اللجنة";
                            Rdet.textBox17.Value = "مساهمة اللجنة";

                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            radioButton3.Checked = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        radioButton3.Checked = false;
                        return;
                    }
                }
            }
        }

        private void GroupingBy_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (GroupingBy.SelectedIndex == 0)
            {
                OrderedBy = "Row2 DESC";

            }
            else
            {
                OrderedBy = "Row12 DESC";
            }

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void DrGrouping_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void RDGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (RDGroups.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT   dbo.MedicalSubGroups.SubgroupAName AS Row6, convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21 FROM   dbo.ReclaimMedicals INNER JOIN  dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id INNER JOIN   dbo.MedicalSubGroups ON dbo.MedicalServices.SubGroupID = dbo.MedicalSubGroups.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2) GROUP BY dbo.MedicalSubGroups.SubgroupAName  ORDER BY " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT   dbo.Localities.LocalityName AS Row7, dbo.MedicalSubGroups.SubgroupAName AS Row6, convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) AS Row2, SUM(dbo.ReclaimMedicals.ReclaimCost) AS Row12,(select convert(decimal, COUNT(DISTINCT dbo.ReclaimMedicals.ReclaimId)) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row3 ,(select SUM(dbo.ReclaimMedicals.ReclaimCost) from dbo.ReclaimMedicals WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)) as Row21 FROM dbo.ReclaimMedicals INNER JOIN dbo.MedicalServices ON dbo.ReclaimMedicals.MedicalId = dbo.MedicalServices.Id INNER JOIN  dbo.Localities ON dbo.ReclaimMedicals.LocalityId = dbo.Localities.Id INNER JOIN  dbo.MedicalSubGroups ON dbo.MedicalServices.SubGroupID = dbo.MedicalSubGroups.Id WHERE " + LocalityName2 + " ReclaimId in ( select Id from dbo.Reclaims Where dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' AND '" + d_end.Value + "' and Reclaims.RowStatus<>2)   GROUP BY dbo.MedicalSubGroups.SubgroupAName  , dbo.Localities.LocalityName ORDER BY " + OrderedBy; ;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCount Rdet = new RPTِEstrdadCount();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            RDGroups.Checked = false;
                        }
                        else
                        {
                            RPTِEstrdadCountLoc Rdet = new RPTِEstrdadCountLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject.Value = "استرداد الخدمات الطبية";
                            Rdet.ReportٍSubject1.Value = "استرداد الخدمات الطبية";
                            Rdet.RowCNT.Value = "عدد الخدمات الطبية";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                            RptiewChronics.RefreshReport();
                            RptiewChronics.Show();
                            RDGroups.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RDGroups.Checked = false;
                        return;
                    }
                }
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    string StrQuery = "";
                    if (DrGrouping.SelectedIndex == 0)
                    {
                        StrQuery = "SELECT  dbo.Reclaims.SectorName AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2,SUM(dbo.Reclaims.MedicalTotal) AS Row11,SUM(dbo.Reclaims.MedicineTotal) AS Row21, SUM(dbo.Reclaims.ReclaimTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row22 FROM  dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and dbo.Reclaims.ReclaimTotal>0 GROUP BY dbo.Reclaims.SectorName ORDER BY  " + OrderedBy;
                    }
                    else
                    {
                        StrQuery = "SELECT  dbo.Localities.LocalityName AS Row7,   dbo.Reclaims.SectorName AS Row6, convert(decimal, COUNT(dbo.Reclaims.Id)) AS Row2, SUM(dbo.Reclaims.MedicalTotal) AS Row11,SUM(dbo.Reclaims.MedicineTotal) AS Row21, SUM(dbo.Reclaims.ReclaimTotal) AS Row12,(select convert(decimal, COUNT(dbo.Reclaims.Id)) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row3,(select SUM(dbo.Reclaims.ReclaimTotal) from dbo.Reclaims WHERE " + LocalityName + " dbo.Reclaims.RowStatus<>2 and  dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and ReclaimTotal>0 ) as Row22 FROM  dbo.Reclaims INNER JOIN dbo.Localities ON dbo.Reclaims.LocalityId = dbo.Localities.Id WHERE " + LocalityName + " dbo.Reclaims.ReclaimDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "' and dbo.Reclaims.RowStatus<>2 and dbo.Reclaims.ReclaimTotal>0 GROUP BY dbo.Reclaims.SectorName, dbo.Localities.LocalityName ORDER BY  " + OrderedBy;
                    }
                    var GetCent = db.Database.SqlQuery<ReportForAll>(StrQuery).ToList();
                    if (GetCent.Count > 0)
                    {
                        if (DrGrouping.SelectedIndex == 0)
                        {
                            RPTِEstrdadCountSec Rdet = new RPTِEstrdadCountSec();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب القطاعات";
                            Rdet.ReportٍSubject.Value = "اسم القطاع";
                            Rdet.ReportٍSubject1.Value = "اسم القطاع";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.textBox14.Value = "الخدمة الطبية";
                            Rdet.textBox15.Value = "الخدمة الطبية";
                            Rdet.textBox17.Value = "الأدوية";
                            Rdet.textBox18.Value = "الأدوية";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        else
                        {
                            RPTِEstrdadCountSecLoc Rdet = new RPTِEstrdadCountSecLoc();
                            Rdet.DataSource = GetCent;
                            Rdet.Locality.Value = db.Localities.Where(p => p.Id == PLC.LocalityId).ToList()[0].LocalityName;
                            Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                            Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                            Rdet.ReportTitle.Value = "عدد التصاديق حسب القطاعات";
                            Rdet.ReportٍSubject.Value = "اسم القطاع";
                            Rdet.ReportٍSubject1.Value = "اسم القطاع";
                            Rdet.Frequency.Value = "التردد";
                            Rdet.Frequency1.Value = "التردد";
                            Rdet.textBox3.Value = "التكلفة";
                            Rdet.textBox7.Value = "التكلفة";
                            Rdet.textBox14.Value = "الخدمة الطبية";
                            Rdet.textBox15.Value = "الخدمة الطبية";
                            Rdet.textBox17.Value = "الأدوية";
                            Rdet.textBox18.Value = "الأدوية";
                            Rdet.NisbahCost.Value = "نسبة التكلفة";
                            Rdet.NisbahCostH.Value = "نسبة التكلفة";
                            Rdet.NisbahFreq.Value = "نسبة التردد";
                            Rdet.NisbahFreqH.Value = "نسبة التردد";
                            RptiewChronics.ReportSource = Rdet;
                        }
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                        radioButton5.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات خلال الفترة المحددة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        radioButton5.Checked = false;
                        return;
                    }
                }
            }
        }
    }
}
