using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMMedicalSetting : Telerik.WinControls.UI.RadForm
    {
        public FRMMedicalSetting()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMMedicalSetting defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMMedicalSetting Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMMedicalSetting();
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
        public int UserId;
        public int MedicalId;
        private void Button5_Click(object sender, EventArgs e)
        {
            FrmMedicalGroup frmGroup = new FrmMedicalGroup();
            frmGroup.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            FrmMedicalSubGroup frmSubGroup = new FrmMedicalSubGroup();
            frmSubGroup.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        private void AddNew()
        {
            MedicaGroup.SelectedIndex = -1;
            SubGroup.SelectedIndex = -1;
            MedicalArabic.SelectedIndex = -1;
            MedicalEnglish.SelectedIndex = -1;
            ListType.SelectedIndex=0;
            NeedApprovement.Checked = false;
            UnitMaxPrice.Text = "0";
            ServiceFrequency.Text = "0";
            Duration.Text = "0";
            Sessions.Text = "0";
            MedicalId = 0;
        }


        private void MedicalSetting_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var Grp = db.MedicalMainGroups.ToList();
                MedicaGroup.DataSource = Grp;
                MedicaGroup.ValueMember = "Id";
                MedicaGroup.DisplayMember = "MainGroupArabicName";
                MedicaGroup.SelectedIndex = -1;
                var SerA = db.MedicalServices.Where(p=>p.IsVisible==true).ToList();
                MedicalEnglish.DataSource = SerA;
                MedicalEnglish.ValueMember = "Id";
                MedicalEnglish.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                MedicalEnglish.DisplayMember = "ServiceEName";
                MedicalArabic.DataSource = SerA;
                MedicalArabic.DisplayMember = "ServiceAName";
                MedicalArabic.ValueMember = "Id";
                MedicalArabic.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                MedicalEnglish.SelectedIndex = -1;
                MedicalArabic.SelectedIndex = -1;
                GRDMedical.DataSource = SerA;
                ListType.DataSource = Enum.GetValues(typeof(ListType));
                UserId = LoginForm.Default.UserId;
            }
        }

        private void MedicaGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (MedicaGroup.ContainsFocus == true)
                {
                    int GroupId = Convert.ToInt32(MedicaGroup.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var Sgrp = db.MedicalSubGroups.Where(p => p.MainGroupId == GroupId).ToList();
                        SubGroup.DataSource = Sgrp;
                        SubGroup.ValueMember = "Id";
                        SubGroup.DisplayMember = "SubgroupAName";
                        var SerA = db.MedicalServices.Where(p => p.SubGroup.MainGroupId == GroupId).ToList();
                        GRDMedical.DataSource = SerA;
                    }


                }
            }
            catch (Exception)
            {

            }
        }

        private void SubGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                int SubGrp = Convert.ToInt32(SubGroup.SelectedValue.ToString());
                if (SubGroup.ContainsFocus == true)
                {
                    using (dbContext db = new dbContext())
                    {
                        var SerA = db.MedicalServicesTemp.Where(p => p.SubGroupID == SubGrp).ToList();
                        MedicalEnglish.DataSource = SerA;
                        MedicalEnglish.ValueMember = "Id";
                        MedicalEnglish.DisplayMember = "ServiceEName";
                        MedicalEnglish.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                        MedicalArabic.DataSource = SerA;
                        MedicalArabic.DisplayMember = "ServiceAName";
                        MedicalArabic.ValueMember = "Id";
                        MedicalArabic.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                        GRDMedical.DataSource = SerA;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void MedicalEnglish_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (MedicalEnglish.ContainsFocus == true)
                {
                    MedicalArabic.SelectedValue = MedicalEnglish.SelectedValue;
                    int SId = Convert.ToInt32(MedicalEnglish.SelectedValue.ToString());
                    MedicalId = SId;
                    using (dbContext db = new dbContext())
                    {
                        var FSer = db.MedicalServices.Where(p => p.Id == SId).ToList();
                        if (FSer.Count > 0)
                        {
                            MedicaGroup.SelectedValue = FSer[0].SubGroup.MainGroupId;
                            int subid = FSer[0].SubGroupID;
                            var Mg = db.MedicalSubGroups.Where(p => p.Id == subid).ToList();
                            SubGroup.DataSource = Mg;
                            SubGroup.ValueMember = "Id";
                            SubGroup.DisplayMember = "SubgroupAName";
                            SubGroup.SelectedValue = subid;
                            ListType.SelectedIndex = Convert.ToInt32(FSer[0].ListType);
                            if (FSer[0].NeedApproveMent == true)
                            {
                                NeedApprovement.CheckState = CheckState.Checked;
                            }
                            else
                            {
                                NeedApprovement.CheckState = CheckState.Unchecked;
                            }
                            ServiceFrequency.Text = FSer[0].ServiceFrequency.ToString();
                            Duration.Text = FSer[0].Duration.ToString();
                            Sessions.Text = FSer[0].Sessions.ToString();

                        }
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void MedicalArabic_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (MedicalArabic.ContainsFocus == true)
                {
                    MedicalEnglish.SelectedValue = MedicalArabic.SelectedValue;
                    int SId = Convert.ToInt32(MedicalArabic.SelectedValue.ToString());
                    MedicalId = SId;
                    using (dbContext db = new dbContext())
                    {
                        var FSer = db.MedicalServices.Where(p => p.Id == SId).ToList();
                        if (FSer.Count > 0)
                        {
                            MedicaGroup.SelectedValue = FSer[0].SubGroup.MainGroupId;
                            int subid = FSer[0].SubGroupID;
                            var Mg = db.MedicalSubGroups.Where(p => p.Id == subid).ToList();
                            SubGroup.DataSource = Mg;
                            SubGroup.ValueMember = "Id";
                            SubGroup.DisplayMember = "SubgroupAName";
                            SubGroup.SelectedValue = subid;
                            ListType.SelectedIndex = Convert.ToInt32(FSer[0].ListType);
                            if (FSer[0].NeedApproveMent == true)
                            {
                                NeedApprovement.CheckState = CheckState.Checked;
                            }
                            else
                            {
                                NeedApprovement.CheckState = CheckState.Unchecked;
                            }
                            ServiceFrequency.Text = FSer[0].ServiceFrequency.ToString();
                            Duration.Text = FSer[0].Duration.ToString();
                            Sessions.Text = FSer[0].Sessions.ToString();

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void UnitMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void ServiceFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void Duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void Sessions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void GRDMedical_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            //    Try
            if (GRDMedical.RowCount > 0)
            {
                if (GRDMedical.CurrentColumn.Name == "Edit")
                {
                    int a = Convert.ToInt32(GRDMedical.CurrentRow.Cells["Id"].Value);
                    using (dbContext db = new dbContext())
                    {
                        var FSer = db.MedicalServices.Where(p => p.Id == a).ToList();
                        if (FSer.Count > 0)
                        {
                            MedicaGroup.SelectedValue = FSer[0].SubGroup.MainGroupId;
                            int subid = FSer[0].SubGroupID;
                            var Mg = db.MedicalSubGroups.Where(p => p.Id == subid).ToList();
                            SubGroup.DataSource = Mg;
                            SubGroup.ValueMember = "Id";
                            SubGroup.DisplayMember = "SubgroupAName";
                            SubGroup.SelectedValue = subid;
                            ListType.SelectedIndex = Convert.ToInt32(FSer[0].ListType);
                            if (FSer[0].NeedApproveMent == true)
                            {
                                NeedApprovement.CheckState = CheckState.Checked;
                            }
                            else
                            {
                                NeedApprovement.CheckState = CheckState.Unchecked;
                            }
                            MedicalEnglish.SelectedValue = FSer[0].Id;
                            MedicalArabic.SelectedValue = FSer[0].Id;
                            ServiceFrequency.Text = FSer[0].ServiceFrequency.ToString();
                            Duration.Text = FSer[0].Duration.ToString();
                            Sessions.Text = FSer[0].Sessions.ToString();
                            UnitMaxPrice.Text = FSer[0].ServicePrice.ToString();
                            ServiceFrequency.Text = FSer[0].ServiceFrequency.ToString();
                            Duration.Text = FSer[0].Duration.ToString();
                        }
                    }

                }
                else if (GRDMedical.CurrentColumn.Name == "Delete")
                {
                    DialogResult del = 0;
                    del = MessageBox.Show("سيتم ايقاف بيانات هذه الخدمة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                    if (del == DialogResult.Yes)
                    {
                        int a = Convert.ToInt32(GRDMedical.CurrentRow.Cells["Id"].Value);
                        using (dbContext db = new dbContext())
                        {
                            var FSer = db.MedicalServices.Where(p => p.Id == a).ToList();
                            if (FSer.Count > 0)
                            {
                                FSer[0].IsEnabled = false;
                                db.SaveChanges();
                                AddNew();
                            }
                        }

                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (MedicaGroup.SelectedIndex == -1)
            {
                MessageBox.Show("يجب تحديد مجموعة الخدمة الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MedicaGroup.Focus();
                return;
            }
            if (SubGroup.SelectedIndex == -1)
            {
                MessageBox.Show("يجب تحديد المجموعة الفرعية للخدمة الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SubGroup.Focus();
                return;
            }
            if (MedicalEnglish.Text.Length > 0)
            {
                MessageBox.Show("يجب كتابة الخدمة باللغة الانجليزية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MedicalEnglish.Focus();
                return;
            }
            if (MedicalArabic.Text.Length == 0)
            {
                MessageBox.Show("يجب كتابة الخدمة باللغة العربية ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MedicalArabic.Focus();
                return;
            }
            if (UnitMaxPrice.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال سعر الاسترداد للخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UnitMaxPrice.Focus();
                return;
            }
            if (ServiceFrequency.Text.Length == 0)
            {
                ServiceFrequency.Text = "0";
            }
            if (Duration.Text.Length == 0)
            {
                Duration.Text = "0";
            }
            if (Sessions.Text.Length == 0)
            {
                Sessions.Text = "0";
            }
            try
            {
                using (dbContext db = new dbContext())
                {

                    if (MedicalId == 0)
                    {
                        string str1 = MedicalArabic.Text;
                        string str2 = MedicalEnglish.Text;
                        var FMedical = db.MedicalServicesTemp.Where(p => p.ServiceAName.Contains(str1)).ToList();
                        if (FMedical.Count > 0)
                        {
                            MessageBox.Show("اسم الخدمة باللغة العربية موجود من قبل", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MedicalArabic.Text = "";
                            MedicalArabic.Focus();
                            return;
                        }
                        var FMedical1 = db.MedicalServicesTemp.Where(p => p.ServiceEName.Contains(str2)).ToList();
                        if (FMedical1.Count > 0)
                        {
                            MessageBox.Show("اسم الخدمة باللغة الانجليزية موجود من قبل", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MedicalEnglish.Text = "";
                            MedicalEnglish.Focus();
                            return;
                        }
                        int MaxId = 1;
                        var Allmedical = db.MedicalServicesTemp.ToList();
                        if (Allmedical.Count > 0)
                        {
                            MaxId = db.MedicalServicesTemp.Max(p => p.Id) + 1;


                        }
                        MedicalServicesTemp Mst = new MedicalServicesTemp();
                        Mst.Id = MaxId;
                        Mst.SubGroupID = Convert.ToInt32(SubGroup.SelectedValue.ToString());
                        Mst.ServiceEName = MedicalEnglish.Text.Trim();
                        Mst.ServiceAName = MedicalArabic.Text.Trim();
                        Mst.ServicePrice = Convert.ToDecimal(UnitMaxPrice.Text);
                        Mst.ServiceFrequency = Convert.ToInt32(ServiceFrequency.Text);
                        Mst.Duration = Convert.ToInt32(Duration.Text);
                        Mst.ListType= (ListType)Enum.Parse(typeof(ListType), ListType.SelectedText); 
                        Mst.NeedApproveMent = Convert.ToBoolean(NeedApprovement.CheckState);
                        Mst.InContract = true;
                        Mst.IsEnabled = true;
                        Mst.Sessions = Convert.ToInt32(Sessions.Text);
                        Mst.Notes = "A";
                        db.MedicalServicesTemp.Add(Mst);
                        db.SaveChanges();

                    }
                    else
                    {

                        var UpMed = db.MedicalServicesTemp.Where(p => p.Id == MedicalId).ToList();
                        if (UpMed.Count > 0)
                        {
                            UpMed[0].SubGroupID = Convert.ToInt32(SubGroup.SelectedValue.ToString());
                            UpMed[0].ServiceEName = MedicalEnglish.Text.Trim();
                            UpMed[0].ServiceAName = MedicalArabic.Text.Trim();
                            UpMed[0].ServicePrice = Convert.ToDecimal(UnitMaxPrice.Text);
                            UpMed[0].ServiceFrequency = Convert.ToInt32(ServiceFrequency.Text);
                            UpMed[0].Duration = Convert.ToInt32(Duration.Text);
                            UpMed[0].ListType = (ListType)Enum.Parse(typeof(ListType), ListType.SelectedText);
                            UpMed[0].NeedApproveMent = Convert.ToBoolean(NeedApprovement.CheckState);
                            UpMed[0].InContract = true;
                            UpMed[0].IsEnabled = true;
                            UpMed[0].Sessions = Convert.ToInt32(Sessions.Text);
                            UpMed[0].Notes = "U";
                            db.SaveChanges();

                        }

                    }
                    MessageBox.Show("لقد تم حفظ البيانات بنجاح", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int SubGrp = Convert.ToInt32(SubGroup.SelectedValue.ToString());
                    var Gmed = db.MedicalServicesTemp.Where(p => p.SubGroupID == SubGrp).ToList();
                    GRDMedical.DataSource = Gmed;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult del = 0;
            del = MessageBox.Show("سيتم تطبيق التعديلات للاستخدام الرسمي", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                using (dbContext db = new dbContext())
                {
                    var Gdata = db.MedicalServicesTemp.Where(p => p.Notes == "A").ToList();
                    if (Gdata.Count > 0)
                    {
                        for (int i = 0; i <= Gdata.Count - 1; i++)
                        {
                            MedicalServices mds = new MedicalServices();
                            mds.Id = Gdata[i].Id;
                            mds.SubGroupID = Gdata[i].SubGroupID;
                            mds.ServiceEName = Gdata[i].ServiceEName;
                            mds.ServiceAName = Gdata[i].ServiceAName;
                            mds.ServicePrice = Gdata[i].ServicePrice;
                            mds.ServiceFrequency = Gdata[i].ServiceFrequency;
                            mds.Duration = Gdata[i].Duration;
                            mds.ListType = Gdata[i].ListType;
                            mds.NeedApproveMent = Gdata[i].NeedApproveMent;
                            mds.InContract = Gdata[i].InContract;
                            mds.IsEnabled = true;
                            mds.Sessions = Gdata[i].Sessions;
                            db.SaveChanges();
                        }
                    }
                    var GdataU = db.MedicalServicesTemp.Where(p => p.Notes == "U").ToList();
                    if (GdataU.Count > 0)
                    {
                        for (int i = 0; i <= GdataU.Count - 1; i++)
                        {
                            int SID = GdataU[i].Id;
                            var mdsU = db.MedicalServices.Where(p => p.Id == SID).ToList();
                            if (mdsU.Count > 0)
                            {
                                mdsU[0].SubGroupID = GdataU[i].SubGroupID;
                                mdsU[0].ServiceEName = GdataU[i].ServiceEName;
                                mdsU[0].ServiceAName = GdataU[i].ServiceAName;
                                mdsU[0].ServicePrice = GdataU[i].ServicePrice;
                                mdsU[0].ServiceFrequency = GdataU[i].ServiceFrequency;
                                mdsU[0].Duration = GdataU[i].Duration;
                                mdsU[0].ListType = GdataU[i].ListType;
                                mdsU[0].NeedApproveMent = GdataU[i].NeedApproveMent;
                                mdsU[0].InContract = GdataU[i].InContract;
                                mdsU[0].IsEnabled = GdataU[i].IsEnabled;
                                mdsU[0].Sessions = GdataU[i].Sessions;
                                db.SaveChanges();
                            }
                        }
                    }
                    var GdataD = db.MedicalServicesTemp.Where(p => p.Notes == "D").ToList();
                    if (GdataD.Count > 0)
                    {
                        for (int i = 0; i <= GdataD.Count - 1; i++)
                        {
                            int SID = GdataD[i].Id;
                            var mdsD = db.MedicalServices.Where(p => p.Id == SID).ToList();
                            if (mdsD.Count > 0)
                            {
                                mdsD[0].IsEnabled = false;
                                db.SaveChanges();
                            }
                        }
                    }
                    db.Database.ExecuteSqlCommand("Update MedicalServicesTemp set Notes=null where Notes is not null");
                    db.SaveChanges();
                }
                MessageBox.Show("لقد تم حفظ البيانات بنجاح", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
        }

        private void GRDMedical_CellFormatting(object sender, CellFormattingEventArgs e)
        {
          
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult del = 0;
            del = MessageBox.Show("سيتم إلغاء التعديلات قبل تحديث قاعدة البيانات الرئيسية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {
                using (dbContext db = new dbContext())
                {
                    var GDataA = db.MedicalServicesTemp.Where(p => p.Notes != null).ToList();
                    if (GDataA.Count > 0)
                    {
                        var GData = db.MedicalServicesTemp.Where(p => p.Notes == "A").ToList();
                        if (GData.Count > 0)
                        {
                            db.Database.ExecuteSqlCommand("delete from MedicalServicesTemp where Notes='A' ");
                        }
                        var GDataD = db.MedicalServicesTemp.Where(p => p.Notes == "D").ToList();
                        if (GDataD.Count > 0)
                        {
                            db.Database.ExecuteSqlCommand("update MedicalServicesTemp set IsEnabled=1 where Notes='D' ");
                        }
                        var GdataU = db.MedicalServicesTemp.Where(p => p.Notes == "U").ToList();
                        if (GdataU.Count > 0)
                        {
                            for (int i = 0; i <= GdataU.Count - 1; i++)
                            {
                                int SID = GdataU[i].Id;
                                var mdsU = db.MedicalServices.Where(p => p.Id == SID).ToList();
                                if (mdsU.Count > 0)
                                {
                                    GdataU[i].SubGroupID = mdsU[0].SubGroupID;
                                    GdataU[i].ServiceEName = mdsU[0].ServiceEName;
                                    GdataU[i].ServiceAName = mdsU[0].ServiceAName;
                                    GdataU[i].ServicePrice = mdsU[0].ServicePrice;
                                    GdataU[i].ServiceFrequency = mdsU[0].ServiceFrequency;
                                    GdataU[i].Duration = mdsU[0].Duration;
                                    GdataU[i].ListType = mdsU[0].ListType;
                                    GdataU[i].NeedApproveMent = mdsU[0].NeedApproveMent;
                                    GdataU[i].InContract = mdsU[0].InContract;
                                    GdataU[i].IsEnabled = mdsU[0].IsEnabled;
                                    GdataU[i].Sessions = mdsU[0].Sessions;

                                }
                            }
                        }
                        db.Database.ExecuteSqlCommand("Update MedicalServicesTemp set Notes=null where Notes is not null");
                        db.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("لا توجد تعديلات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        private void GRDMedical_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (GRDMedical.RowCount > 0)
            {
                if (Convert.ToBoolean(e.RowElement.RowInfo.Cells["IsEnabled"].Value) == true)
                {
                    e.RowElement.BackColor = Color.White;
                }
                else
                {
                    e.RowElement.BackColor = Color.LightBlue;
                }
            }
        }
    }

}
