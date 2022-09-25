using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System.Linq;
namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMMedicineSetting : Telerik.WinControls.UI.RadForm
    {
        public int MedicineId = 0;
        public int UserId = 0;
        public int LocalityId = 0;
        public FRMMedicineSetting()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMMedicineSetting defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMMedicineSetting Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMMedicineSetting();
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
            AddNew();
        }
        private void AddNew()
        {

            ListType.SelectedIndex = -1;
            GenericId.Clear();
            TermsOfUse.Clear();
            Regestration.Clear();
            Unit.SelectedIndex = -1;
            HICKS_DC.SelectedIndex = -1;
            U.SelectedIndex = -1;
            Adm_R.SelectedIndex =-1;
            GenericName.SelectedIndex = -1;
            AtcCode.Clear();
            Note.Clear();  
            MedicineId = 0;
            GenericName.Focus();
        }

        private void FRMMedicineSetting_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            ListType.DataSource = Enum.GetValues(typeof(PLS));
            ListType.SelectedIndex = -1;
            LocalityId = PLC.LocalityId;
            using (dbContext db = new dbContext())
            {
                var Atc = db.ATCclassifications.ToList();
                ATCclassification.DataSource = Atc;
                ATCclassification.DisplayMember = "ATC_classification";
                ATCclassification.ValueMember = "Id";
                ATCclassification.SelectedIndex = -1;

                var Gunit = db.Units.ToList();
                Unit.DataSource = Gunit;
                Unit.DisplayMember = "Unit_Name";
                Unit.ValueMember = "Id";
                Unit.SelectedIndex = -1;

                var adm = db.AdMRS.ToList();
                Adm_R.DataSource = adm;
                Adm_R.DisplayMember = "AdmR";
                Adm_R.ValueMember = "Id";
                Adm_R.SelectedIndex = -1;

                var hks= db.HICKS_DCS.ToList();
                HICKS_DC.DataSource = hks;
                HICKS_DC.DisplayMember = "HICKSDC";
                HICKS_DC.ValueMember = "Id";
                HICKS_DC.SelectedIndex = -1;

                var us = db.US.ToList();
                U.DataSource = us;
                U.DisplayMember = "U";
                U.ValueMember = "Id";
                U.SelectedIndex = -1;

                var Geneiclst = db.MedicineTemps.ToList();
                GenericName.DataSource = Geneiclst;
                GenericName.ValueMember = "Id";
                GenericName.DisplayMember = "Generic_name";
                GenericName.SelectedIndex = -1;
                GenericName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                AddNew();

            }
        }

        private void ListName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }
        private void Fill()
        {
            try
            {
                if (ATCclassification.SelectedIndex != -1)
                {
                    int AtcId = Convert.ToInt32(ATCclassification.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var Geneiclst = db.Medicines.Where(p => p.ATCId == AtcId).Select(p => new { p.Id, p.Generic_name, p.Unit.Unit_Name, p.PL, HICKS_DC= p.HICKS_DCS.HICKSDC, p.NOTE, p.DDD,U= p.US.U, Adm_R = p.AdmRS.AdmR,p.Activated }).ToList();
                        GRDMedicine.DataSource = Geneiclst;
                       

                    }
                }
            }
            catch (Exception)
            {

                return;
            }
          
        }
        private void ATCclassification_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            Fill();
        }

        private void GenericName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (GenericName.ContainsFocus)
            {
                try
                {
                    if (GenericName.SelectedIndex != -1)
                    {
                        MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());

                        using (dbContext db = new dbContext())
                        {
                            var Getgeneric = db.MedicineTemps.Where(p => p.Id == MedicineId).ToList();
                            if (Getgeneric.Count > 0)
                            {
                                MedicineId = Getgeneric[0].Id;
                                ListType.SelectedIndex = Convert.ToInt32(Getgeneric[0].PL);
                                ATCclassification.SelectedValue = Getgeneric[0].ATCId;
                                GenericId.Text = Getgeneric[0].GenericId.ToString();
                                TermsOfUse.Text = Getgeneric[0].TermsOfUse;
                                Regestration.Text = Getgeneric[0].Regestration;
                                Unit.SelectedValue = Getgeneric[0].Unit_Id;
                                HICKS_DC.SelectedValue = Getgeneric[0].HICKS_DC;
                                U.SelectedValue  = Getgeneric[0].U;
                                Adm_R.SelectedValue  = Getgeneric[0].Adm_R;
                                Note.Text = Getgeneric[0].NOTE;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    return;
                }

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            FrmGenericLis.Default.Flag = 1;
            FrmGenericLis.Default.ShowDialog();

        }

        private void GenericName_TextChanged(object sender, EventArgs e)
        {
            if (GenericName.ContainsFocus)
            {
                try
                {
                    if (GenericName.SelectedIndex != -1)
                    {
                        MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());

                        using (dbContext db = new dbContext())
                        {
                            var Getgeneric = db.Medicines.Where(p => p.Generic_name == GenericName.Text).ToList();
                            if (Getgeneric.Count > 0)
                            {
                                MedicineId = Getgeneric[0].Id;
                                ListType.SelectedIndex = Convert.ToInt32(Getgeneric[0].PL);
                                ATCclassification.SelectedValue = Getgeneric[0].ATCclassifications;
                                GenericId.Text = Getgeneric[0].GenericId.ToString();
                                TermsOfUse.Text = Getgeneric[0].TermsOfUse;
                                Regestration.Text = Getgeneric[0].Regestration;
                                Unit.SelectedValue = Getgeneric[0].Unit_Id;
                                HICKS_DC.SelectedValue = Getgeneric[0].HICKS_DC;
                                U.SelectedValue = Getgeneric[0].U;
                                Adm_R.SelectedValue = Getgeneric[0].Adm_R;
                                Note.Text = Getgeneric[0].NOTE;
                            }
                            else
                            {
                                MedicineId = 0;
                                //ListType.SelectedIndex = -1;
                                ATCclassification.SelectedIndex = -1; ;
                                GenericId.Clear();
                                TermsOfUse.Clear();
                                Regestration.Clear();
                                Unit.SelectedIndex = -1;
                                HICKS_DC.SelectedIndex = -1;
                                U.SelectedIndex = -1;
                                Adm_R.SelectedIndex = -1;
                                Note.Clear();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    return;
                }

            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ListType.SelectedIndex == -1)
            {
                MessageBox.Show("Choose List type First!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListType.Focus();
                return;
            }
            if (ATCclassification.SelectedIndex == -1)
            {
                MessageBox.Show("Choose ATCclassification First!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATCclassification.Focus();
                return;
            }

            if (Regestration.Text.Length == 0)
            {
                MessageBox.Show("Enter Regestration of use First!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Regestration.Focus();
                return;
            }
            if (Unit.SelectedIndex == -1)
            {
                MessageBox.Show("Choose Generic Uint First!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Unit.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                if (MedicineId == 0)
                {
                    
                    MedicineTemp Mct = new MedicineTemp();
                    int MAxId = db.MedicineTemps.Max(p => p.Id) + 1;
                    Mct.Id = MAxId;
                    Mct.PL = (PLS)Enum.Parse(typeof(PLS), ListType.SelectedText);
                    Mct.ATC_code = AtcCode.Text.Trim();
                    Mct.ATCId = Convert.ToInt32(ATCclassification.SelectedValue.ToString());
                    Mct.GenericId = Convert.ToInt32(GenericId.Text);
                    Mct.Generic_name = GenericName.Text.Trim();
                    Mct.TermsOfUse = TermsOfUse.Text.Trim();
                    Mct.Regestration = Regestration.Text.Trim();
                    Mct.Unit_Id = Convert.ToInt32(Unit.SelectedValue); 
                    Mct.HICKS_DC =  Convert.ToInt32( HICKS_DC.SelectedValue);
                    Mct.U =Convert.ToInt32( U.SelectedValue);
                    Mct.Adm_R = Convert.ToInt32(Adm_R.SelectedValue );
                    Mct.NOTE = Note.Text.Trim();
                    Mct.EditeMode = EditeMode.Insert;
                    Mct.UserId = UserId;
                    Mct.Activated = 1;
                    db.MedicineTemps.Add(Mct);
                    db.SaveChanges();
                    MessageBox.Show("Data has been Inserted", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Fill();
                    if (GRDMedicine.RowCount > 0)
                    {
                        GRDMedicine.Rows[GRDMedicine.RowCount - 1].IsCurrent = true;
                        GRDMedicine.Rows[GRDMedicine.RowCount - 1].IsSelected = true;

                    }
                }
                else if (MedicineId > 0)
                {

                    var GetGen = db.MedicineTemps.Where(p => p.Id == MedicineId).ToList();
                    if (GetGen.Count > 0)
                    {
                        GetGen[0].PL = (PLS)Enum.Parse(typeof(PLS), ListType.SelectedText);
                        GetGen[0].ATCId = Convert.ToInt32(ATCclassification.SelectedValue.ToString());
                        GetGen[0].ATC_code = AtcCode.Text.Trim();
                        GetGen[0].GenericId = Convert.ToInt32(GenericId.Text);
                        GetGen[0].Generic_name = GenericName.Text.Trim();
                        GetGen[0].TermsOfUse = TermsOfUse.Text.Trim();
                        GetGen[0].Regestration = Regestration.Text.Trim();
                        GetGen[0].Unit_Id = Convert.ToInt32(Unit.SelectedValue);
                        GetGen[0].HICKS_DC = Convert.ToInt32(HICKS_DC.SelectedValue);
                        GetGen[0].U = Convert.ToInt32(U.SelectedValue);
                        GetGen[0].Adm_R = Convert.ToInt32(Adm_R.SelectedValue);
                        GetGen[0].NOTE = Note.Text.Trim();
                        GetGen[0].EditeMode = EditeMode.Update;
                        GetGen[0].UpdateUser = UserId;
                        db.SaveChanges();
                        MessageBox.Show("Data has been Updated", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Fill();
                    }
                }

            }
        }

        private void GRDMedicine_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
        }

        private void GRDMedicine_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["Activated"].Value) == 0)
            {
                e.CellElement.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                e.CellElement.BackColor = System.Drawing.Color.White;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GRDMedicine.RowCount > 0)
            {
                DialogResult a = 0;
                a = MessageBox.Show("Data of this Medicine Will Send to the main database ?", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    using (dbContext db = new dbContext())
                    {
                        var EDitMedid = db.MedicineTemps.Where(p => p.EditeMode == EditeMode.Insert).ToList();
                        if (EDitMedid.Count > 0)
                        {
                            for (int i = 0; i < EDitMedid.Count; i++)
                            {
                                Medicine Mct = new Medicine();
                                Mct.Id = EDitMedid[i].Id;
                                Mct.PL = EDitMedid[i].PL;
                                Mct.ATC_code = EDitMedid[i].ATC_code;
                                Mct.ATCId = EDitMedid[i].ATCId;
                                Mct.GenericId = EDitMedid[i].GenericId;
                                Mct.Generic_name = EDitMedid[i].Generic_name;
                                Mct.TermsOfUse = EDitMedid[i].TermsOfUse;
                                Mct.Regestration = EDitMedid[i].Regestration;
                                Mct.Unit_Id = EDitMedid[i].Unit_Id;
                                Mct.HICKS_DC = EDitMedid[i].HICKS_DC;
                                Mct.U = EDitMedid[i].U;
                                Mct.Adm_R = EDitMedid[i].Adm_R;
                                Mct.NOTE = EDitMedid[i].NOTE;
                                Mct.UserId = UserId;
                                Mct.Activated = EDitMedid[i].Activated;
                                db.Medicines.Add(Mct);
                                MedicineForReclaim mdr = new MedicineForReclaim();
                                mdr.Id= EDitMedid[i].Id;
                                mdr.Generic_name = EDitMedid[i].Generic_name;
                                mdr.InContract = true;
                                mdr.Activated = 1;
                                db.MedicineForReclaims.Add(mdr);
                                db.SaveChanges();
                            }

                        }
                        var EDitMedid1 = db.MedicineTemps.Where(p => p.EditeMode == EditeMode.Update).ToList();
                        if (EDitMedid1.Count > 0)
                        {
                            for (int i = 0; i < EDitMedid1.Count; i++)
                            {
                                MedicineId = EDitMedid1[i].Id;
                                var MUpdate = db.Medicines.Where(p => p.Id == MedicineId).ToList();
                                if (MUpdate.Count > 0)
                                {
                                    MUpdate[0].PL = EDitMedid1[i].PL;
                                    MUpdate[0].ATCId = EDitMedid1[i].ATCId;
                                    MUpdate[0].ATC_code = EDitMedid[i].ATC_code;
                                    MUpdate[0].GenericId = EDitMedid1[i].GenericId;
                                    MUpdate[0].Generic_name = EDitMedid1[i].Generic_name;
                                    MUpdate[0].TermsOfUse = EDitMedid1[i].TermsOfUse;
                                    MUpdate[0].Regestration = EDitMedid1[i].Regestration;
                                    MUpdate[0].Unit_Id = EDitMedid1[i].Unit_Id;
                                    MUpdate[0].HICKS_DC = EDitMedid1[i].HICKS_DC;
                                    MUpdate[0].U = EDitMedid1[i].U;
                                    MUpdate[0].Adm_R = EDitMedid1[i].Adm_R;
                                    MUpdate[0].NOTE = EDitMedid1[i].NOTE;
                                    MUpdate[0].UserId = UserId;
                                    MUpdate[0].Activated = EDitMedid1[i].Activated;
                                    db.SaveChanges();
                                }
                                var MUpdate1 = db.MedicineForReclaims.Where(p => p.Id == MedicineId).ToList();
                                if (MUpdate1.Count > 0)
                                {
                                    MUpdate1[0].Generic_name = EDitMedid1[i].Generic_name;
                                }
                                }

                        }
                        var EDitMedid2 = db.MedicineTemps.Where(p => p.EditeMode == EditeMode.Delete).ToList();
                        if (EDitMedid2.Count > 0)
                        {
                            for (int i = 0; i < EDitMedid2.Count; i++)
                            {
                                MedicineId = EDitMedid2[i].Id;
                                var MUpdate = db.Medicines.Where(p => p.Id == MedicineId).ToList();
                                if (MUpdate.Count > 0)
                                {
                                    MUpdate[0].Activated = EDitMedid2[i].Activated;
                                    MUpdate[0].DeleteUser = UserId;
                                    db.SaveChanges();
                                }
                                var MUpdate1 = db.MedicineForReclaims.Where(p => p.Id == MedicineId).ToList();
                                if (MUpdate1.Count > 0)
                                {
                                    MUpdate1[0].Activated = EDitMedid2[i].Activated;
                                    db.SaveChanges();
                                }
                            }
                        }
                        MessageBox.Show("Data has been Submitted", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Database.ExecuteSqlCommand("update MedicineTemps set EditeMode=null where EditeMode is not null");
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (GRDMedicine.RowCount > 0)
            {
                DialogResult a = 0;
                a = MessageBox.Show("Changes will be canceled ?", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    using (dbContext db = new dbContext())
                    {
                        db.Database.ExecuteSqlCommand("delete from MedicineTemps");
                        var EDitMedid = db.Medicines.ToList();
                        for (int i = 0; i < EDitMedid.Count; i++)
                        {
                            MedicineTemp Mct = new MedicineTemp();
                            Mct.Id = EDitMedid[i].Id;
                            Mct.PL = EDitMedid[i].PL;
                            Mct.ATC_code= EDitMedid[i].ATC_code;
                            Mct.ATCId = EDitMedid[i].ATCId;
                            Mct.GenericId =Convert.ToInt32( EDitMedid[i].GenericId);
                            Mct.TermsOfUse = EDitMedid[i].TermsOfUse;
                            Mct.Regestration = EDitMedid[i].Regestration;
                            Mct.Unit_Id = EDitMedid[i].Unit_Id;
                            Mct.HICKS_DC = EDitMedid[i].HICKS_DC;
                            Mct.U = EDitMedid[i].U;
                            Mct.Adm_R = EDitMedid[i].Adm_R;
                            Mct.NOTE = EDitMedid[i].NOTE;
                            Mct.UserId = UserId;
                            Mct.Activated = EDitMedid[i].Activated;
                            db.MedicineTemps.Add(Mct);
                            db.SaveChanges();
                            MessageBox.Show("Changes has been canceled", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GenericId_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void TermsOfUse_TextChanged(object sender, EventArgs e)
        {

        }

        private void Regestration_TextChanged(object sender, EventArgs e)
        {

        }

        private void Unit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void HICKS_DC_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void Adm_R_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void U_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void Note_TextChanged(object sender, EventArgs e)
        {

        }

        private void GRDMedicine_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (GRDMedicine.RowCount > 0)
            {
                if (Convert.ToInt32(e.RowElement.RowInfo.Cells["Activated"].Value) == 0)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.Gray;
                }
                else
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            FrmMedicineATC.Default.ShowDialog();
        }

        private void GRDMedicine_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDMedicine.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    MedicineId = Convert.ToInt32(e.Row.Cells["Id"].Value.ToString());
                    if (GRDMedicine.CurrentColumn.Name == "Edit")
                    {
                        var Getgeneric = db.MedicineTemps.Where(p => p.Id == MedicineId).ToList();
                        if (Getgeneric.Count > 0)
                        {
                            MedicineId = Getgeneric[0].Id;
                            AtcCode.Text = Getgeneric[0].ATC_code;
                            ListType.SelectedIndex =Convert.ToInt32( Getgeneric[0].PL);
                            ATCclassification.SelectedValue = Getgeneric[0].ATCId;
                            GenericName.SelectedValue = Getgeneric[0].Id;
                            GenericId.Text = Getgeneric[0].GenericId.ToString();
                            TermsOfUse.Text = Getgeneric[0].TermsOfUse;
                            Regestration.Text = Getgeneric[0].Regestration;
                            Unit.SelectedValue = Getgeneric[0].Unit_Id;
                            HICKS_DC.SelectedValue = Getgeneric[0].HICKS_DC;
                            U.SelectedValue = Getgeneric[0].U;
                            Adm_R.SelectedValue = Getgeneric[0].Adm_R;
                            Note.Text = Getgeneric[0].NOTE;
                        }
                    }
                    else if (GRDMedicine.CurrentColumn.Name == "Delete")
                    {


                        var Getgeneric = db.MedicineTemps.Where(p => p.Id == MedicineId).ToList();
                        if (Getgeneric.Count > 0)
                        {

                            if (Getgeneric[0].Activated == 1)
                            {
                                DialogResult a = 0;
                                a = MessageBox.Show("Data of this Medicine Will be Disabled ?", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                                if (a == DialogResult.Yes)
                                {
                                    Getgeneric[0].Activated = 0;
                                    Getgeneric[0].DeleteUser = UserId;
                                    Getgeneric[0].EditeMode = EditeMode.Delete;
                                    db.SaveChanges();
                                    MessageBox.Show("Data has been Disabled", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Fill();
                                }
                            }
                            else if (Getgeneric[0].Activated == 0)
                            {
                                DialogResult a = 0;
                                a = MessageBox.Show("Data of this Medicine Will be Enabled?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                                if (a == DialogResult.Yes)
                                {
                                    Getgeneric[0].Activated = 1;
                                    Getgeneric[0].DeleteUser = UserId;
                                    Getgeneric[0].EditeMode = EditeMode.Delete;
                                    db.SaveChanges();
                                    MessageBox.Show("Data has been Enabled", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Fill();
                                }
                            }
                        }
                    }


                }
            }
        }
    }
}
