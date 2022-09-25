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
    public partial class FRMMedicinePricing : Telerik.WinControls.UI.RadForm
    {
        public int MedicineId = 0;
        public int UserId = 0;
        public int LocalityId = 0;
        public int CopId = 0;
        public FRMMedicinePricing()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMMedicinePricing defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMMedicinePricing Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMMedicinePricing();
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
            // ListName.SelectedIndex = 0;

            MedicineId = 0;

        }

        private void FRMMedicineSetting_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = PLC.LocalityId;
            using (dbContext db = new dbContext())
            {
                var Mlist = db.MedicineLists.ToList();
                ListName.DataSource = Mlist;
                ListName.DisplayMember = "ListName";
                ListName.ValueMember = "Id";
                ListName.SelectedIndex = -1;

                AddNew();

            }
        }

        private void ListName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

                if (ListName.ContainsFocus)
                {
                    if (CopId == 0)
                    {
                        int LId = Convert.ToInt32(ListName.SelectedValue.ToString());
                        using (dbContext db = new dbContext())
                        {
                            var GetMedicine = db.Medicines.ToList();
                            
                            var Mlst = db.MedicineListPrices.Where(p => p.ListId == LId).Select(p => new { p.Id,p.GenericId, p.Medicine.Generic_name, p.Medicine.Unit.Unit_Name, p.Medicine.PL, HICKS_DC=p.Medicine.HICKS_DCS.HICKSDC, p.Medicine.NOTE,DDD= p.GenericPrice, p.Medicine.US.U, Adm_R= p.Medicine.AdmRS.AdmR }).ToList();
                            if (GetMedicine.Count == Mlst.Count)
                            {
                                Cursor = Cursors.WaitCursor;
                                GRDMedicine.DataSource = Mlst;
                                for (int i = 0; i < GRDMedicine.RowCount; i++)
                                {
                                    GRDMedicine.Rows[i].Cells["Cost"].Value = GRDMedicine.Rows[i].Cells["DDD"].Value;
                                }
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                for (int i = 0; i < GetMedicine.Count; i++)
                                {
                                    int GenericId = GetMedicine[i].Id;
                                    var ChkMed = db.MedicineListPrices.Where(p => p.ListId == LId && p.GenericId == GenericId).ToList();
                                    if (ChkMed.Count > 0)
                                    {
                                        if (GetMedicine[i].Activated == 0)
                                        {
                                            db.MedicineListPrices.Remove(ChkMed[0]);
                                            db.SaveChanges();
                                        }
                                        
                                    }
                                    else
                                    {
                                        MedicineListPrice Mlp = new MedicineListPrice();
                                        Mlp.ListId = LId;
                                        Mlp.GenericId = GetMedicine[i].Id;
                                        Mlp.GenericPrice = 0;
                                        db.MedicineListPrices.Add(Mlp);
                                        db.SaveChanges();
                                    }
                                   
                                }
                                var Mlst1 = db.MedicineListPrices.Where(p => p.ListId == LId).Select(p => new { p.Id, p.GenericId, p.Medicine.Generic_name, p.Medicine.Unit.Unit_Name, p.Medicine.PL, HICKS_DC = p.Medicine.HICKS_DCS.HICKSDC, p.Medicine.NOTE, DDD = p.GenericPrice, p.Medicine.US.U, Adm_R = p.Medicine.AdmRS.AdmR }).ToList();
                                GRDMedicine.DataSource = Mlst1;
                                for (int i = 0; i < GRDMedicine.RowCount; i++)
                                {
                                    GRDMedicine.Rows[i].Cells["Cost"].Value = GRDMedicine.Rows[i].Cells["DDD"].Value;
                                }
                                Cursor = Cursors.Default;
                            }

                        }
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

        }

        private void GenericName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //if (GenericName.ContainsFocus)
            //{
            //    if (GenericName.SelectedIndex != -1)
            //    {
            //        MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());
            //        int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
            //        using (dbContext db = new dbContext())
            //        {
            //            var Getgeneric = db.MedicineListPrices.Where(p => p.GenericId == MedicineId && p.ListId == ListId).ToList();
            //            if (Getgeneric.Count > 0)
            //            {
            //                UU.Text = Getgeneric[0].GenericPrice.ToString();
            //            }
            //        }
            //    }
            //}
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //if (GenericName.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Enter Generic Name first!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    GenericName.Focus();
            //    return;
            //}
            //if (UU.Text.Length == 0)
            //{
            //    MessageBox.Show("Enter Generic Price first!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    UU.Focus();
            //    return;
            //}
            //using (dbContext db = new dbContext())
            //{
            //    MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());
            //    int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
            //    var getPrice = db.MedicineListPrices.Where(p => p.ListId == ListId && p.GenericId == MedicineId).ToList();
            //    if (getPrice.Count > 0)
            //    {
            //        getPrice[0].GenericPrice = Convert.ToDecimal(UU.Text);
            //        db.SaveChanges();
            //        MessageBox.Show("Price has been Edited", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GRDMedicine_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //if (GRDMedicine.CurrentColumn.Name == "Edit")
            //{
            //    MedicineId = Convert.ToInt32(e.Row.Cells["Id"].Value.ToString());
            //    int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
            //    using (dbContext db = new dbContext())
            //    {
            //        var getPrice = db.MedicineListPrices.Where(p => p.ListId == ListId && p.GenericId == MedicineId).ToList();
            //        if (getPrice.Count > 0)
            //        {
            //            GenericName.SelectedValue = MedicineId;
            //            if (getPrice[0].GenericPrice.ToString() != null)
            //            {
            //                UU.Text = getPrice[0].GenericPrice.ToString();
            //            }
            //            else
            //            {
            //                UU.Text = "0";
            //            }
            //        }
            //    }
            //}
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FRMMedicinePricing.Default.ShowDialog();
        }

        private void GRDMedicine_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDMedicine.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {

                    int PId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                    var GetLst = db.MedicineListPrices.Where(p => p.Id == PId).ToList();
                    if (GetLst.Count > 0)
                    {
                        GetLst[0].GenericPrice = Convert.ToDecimal(e.Row.Cells["Cost"].Value.ToString());
                        db.SaveChanges();
                    }
                }

            }
        }

        private void FRMMedicinePricing_Activated(object sender, EventArgs e)
        {
          
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            if (ListName.SelectedIndex != -1)
            {
                int LId = Convert.ToInt32(ListName.SelectedValue.ToString());
                using (dbContext db = new dbContext())
                {
                    var Mlst = db.MedicineListPrices.Where(p => p.ListId == LId).Select(p => new { p.Id, p.Medicine.Generic_name, p.Medicine.Unit.Unit_Name, p.Medicine.PL, p.Medicine.HICKS_DC, p.Medicine.NOTE, p.GenericPrice, p.Medicine.U, p.Medicine.Adm_R }).ToList();
                    if (Mlst.Count > 0)
                    {
                        CopId = LId;
                        MessageBox.Show("List Has Been Copied", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void RadButton2_Click(object sender, EventArgs e)
        {
            if (ListName.SelectedIndex != -1)
            {
                if (CopId > 0)
                {
                    int LId = Convert.ToInt32(ListName.SelectedValue.ToString());
                    if (LId != CopId)
                        using (dbContext db = new dbContext())
                        {
                            Cursor = Cursors.WaitCursor;
                            var Clst = db.MedicineListPrices.Where(p => p.ListId == CopId).ToList();
                            for (int i = 0; i < Clst.Count; i++)
                            {
                                int GenericId = Clst[i].GenericId;
                                var chklst = db.MedicineListPrices.Where(p => p.ListId == LId && p.GenericId == GenericId).ToList();
                                if (chklst.Count == 0)
                                {
                                    MedicineListPrice mls = new MedicineListPrice();
                                    mls.ListId = LId;
                                    mls.GenericId = GenericId;
                                    mls.GenericPrice = Clst[i].GenericPrice;
                                    db.MedicineListPrices.Add(mls);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    chklst[0].GenericPrice = Clst[i].GenericPrice;
                                    db.SaveChanges();
                                }
                            }


                            Cursor = Cursors.Default;


                            var Mlst1 = db.MedicineListPrices.Where(p => p.ListId == LId).ToList();
                            if (Mlst1.Count > 0)
                            {
                                CopId = 0;
                                MessageBox.Show("List Has Been pasted", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                }
                else
                {
                    MessageBox.Show("No data for pasting", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
        }
    }
}

