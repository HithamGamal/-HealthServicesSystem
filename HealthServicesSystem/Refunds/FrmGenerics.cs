
using ModelDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    public partial class FrmGenerics : Form
    {
        public int GenericId = 0;
        public FrmGenerics()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmGenerics defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmGenerics Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmGenerics();
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

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {

                FillCombo();
            }
        }

        public void FillCombo()
        {
            using (dbContext db = new dbContext())
            {
                var Tlist = db.Generics.Select(p => new { p.Id, p.GenericName, p.Unit.Unit_Name, p.IsActive }).ToList();

                GenericName.DataSource = Tlist;
                GenericName.DisplayMember = "GenericName";
                GenericName.ValueMember = "Id";
                GenericName.SelectedIndex = -1;
                GenericName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                GrdGenerics.DataSource = Tlist;
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (Unit.SelectedIndex !=-1)
            {
                MessageBox.Show("Please insert Unit Name!");
                Unit.Focus();
                return;
            }
            if (GenericName.SelectedIndex != -1)
            {
                MessageBox.Show("Please insert Generic Name!");
                GenericName.Focus();
                return;
            }

            using (dbContext db = new dbContext())
            {
                if (GenericId == 0)
                {
                    Generic gn = new Generic();
                    gn.GenericName = GenericName.Text.Trim();
                    gn.Unit_Id = Convert.ToInt32(GenericName.SelectedValue.ToString());
                    gn.IsActive = 0;
                    db.Generics.Add(gn);
                    db.SaveChanges();
                    FillCombo();
                    radButton1.PerformClick();
                    MessageBox.Show("Data has been saved", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (GenericId > 0)
                {
                    var Gtrade = db.Generics.Where(p => p.Id == GenericId).ToList();
                    if (Gtrade.Count > 0)
                    {
                        Gtrade[0].GenericName = GenericName.Text.Trim();
                        Gtrade[0].Unit_Id = Convert.ToInt32(Unit.SelectedValue.ToString());
                        db.SaveChanges();
                        FillCombo();
                        radButton1.PerformClick();
                        MessageBox.Show("Data has been updated", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //if (flag==1)
            //{
            //    bool iscool;
            //    if (IsCold.Checked == true)
            //    {
            //        iscool = true;
            //    }
            //    else
            //    {
            //        iscool = false;
            //    }
            //    ItemCommand cmd = new ItemCommand(new StockContext());
            //    var Distinct = cmd.GetList().Any(p => p.ItemName.Contains(nametxt.Text));
            //    if (Distinct == false)
            //    {
            //    cmd.Add(new Item()
            //    {
            //        ItemName = nametxt.Text,
            //        GenericId = int.Parse(Gnamelist.SelectedValue.ToString()),
            //        SmallUnitId = int.Parse(ulist.SelectedValue.ToString()),
            //        LargeUnitId= 1,
            //        UseTypeId=1,
            //        SupplierId= int.Parse(SuppList.SelectedValue.ToString()),
            //        CriticalQty= int.Parse(Qtytxt.Text),
            //        UserId = 1,
            //        RowStatus = RowStatus.Active,
            //        IsCold =iscool

            //    });
            //        if (cmd.Commit())
            //        {
            //            MessageBox.Show("saved");
            //            Fill();
            //        }
            //        else
            //        {
            //            MessageBox.Show("not saved");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Record Already Exist!!");
            //    }
            //    nametxt.Text = string.Empty;
            //    Gnamelist.SelectedIndex = 0;
            //    ulist.SelectedIndex = 0;
            // // UTypelist.SelectedIndex = 0;
            //    SuppList.SelectedIndex = 0;
            //    Qtytxt.Text = string.Empty;
            //   // this.Close();
            //}
            //else
            //{
            //    ItemCommand cmd = new ItemCommand(new StockContext());
            //    int id = int.Parse(IDtxt.Text);
            //    int GenericId = int.Parse(Gnamelist.SelectedValue.ToString());
            //    int SmallUnitId = int.Parse(ulist.SelectedValue.ToString());
            //    int UseTypeId = 1;
            //    int SupplierId = int.Parse(SuppList.SelectedValue.ToString());
            //    var q = cmd.FindById(id);

            //    cmd.Edit(q);
            //    q.ItemName = nametxt.Text;
            //    q.GenericId = GenericId;
            //    q.SmallUnitId = SmallUnitId;
            //    q.LargeUnitId =1;
            //    q.UseTypeId = UseTypeId;
            //    q.SupplierId = SupplierId;
            //    q.UserId = 1;
            //    q.RowStatus = RowStatus.Edit;
            //    if (IsCold.Checked == true)
            //    {
            //        q.IsCold = true;
            //    }
            //    else
            //    {
            //        q.IsCold = false;
            //    }

            //    if (cmd.Commit())
            //    {
            //        MessageBox.Show("Updated");
            //        flag = 1;
            //        nametxt.Text = string.Empty;
            //        Gnamelist.SelectedIndex = 0;
            //        ulist.SelectedIndex = 0;
            //        // UTypelist.SelectedIndex = 0;
            //        SuppList.SelectedIndex = 0;
            //        Qtytxt.Text = string.Empty;
            //        IsCold.Checked = false;
            //        Fill();
            //        //  ItemGrid.cu = ItemGrid.Rows[ItemGrid.RowCount - 1].Cells[0];

            //    }
            //    else
            //    {
            //        MessageBox.Show("Not Updated");
            //    }

            //}
        }

        public void RefreshGrid()
        {
            //ItemFrm f = (ItemFrm)Application.OpenForms["ItemFrm"];
            //f.Fill();
        }
        public void Fill()
        {
            //ItemGrid.DataSource = "";
            //ItemCommand cmd = new ItemCommand(new StockContext());
            //var Grid = cmd.GetList().Where
            //                        (p => (p.RowStatus != RowStatus.Deleted && p.RowStatus != RowStatus.suspend)).ToList();

            //ItemGrid.DataSource = Grid;
            //ItemGrid.Columns["Id"].HeaderText = "ID";
            //ItemGrid.Columns["Id"].Width = 80;
            //ItemGrid.Columns["ItemName"].HeaderText = "Generic Name";
            //ItemGrid.Columns["ItemName"].Width = 150;
            //ItemGrid.Columns["GenericId"].HeaderText = "Generic Type Id";
            //ItemGrid.Columns["GenericId"].Width = 100;
            //ItemGrid.Columns["Generic"].IsVisible = false;
            //ItemGrid.Columns["SmallUnitId"].HeaderText = "Unit Id";
            //ItemGrid.Columns["SmallUnitId"].Width = 80;
            //ItemGrid.Columns["SmallUnits"].IsVisible = false;
            //ItemGrid.Columns["LargeUnitId"].IsVisible = false;
            //ItemGrid.Columns["UseTypeId"].IsVisible = false;
            //ItemGrid.Columns["UseType"].IsVisible = false;
            //ItemGrid.Columns["SupplierId"].HeaderText = "Supplier Id";
            //ItemGrid.Columns["SupplierId"].Width = 80;
            //ItemGrid.Columns["Suppliers"].IsVisible = false;
            //ItemGrid.Columns["CriticalQty"].HeaderText = "Critical Qty";
            //ItemGrid.Columns["CriticalQty"].Width = 80;
            //ItemGrid.Columns["UserId"].IsVisible = false;
            //ItemGrid.Columns["ItemStatus"].IsVisible = false;
            //ItemGrid.Columns["RowStatus"].IsVisible = false;
            //ItemGrid.Columns["IsCold"].HeaderText = "Is Cold";
            //ItemGrid.Columns["IsCold"].Width = 80;
            //ItemGrid.Columns["PharmSaleDetails"].IsVisible = false;



        }

        private void ItemGrid_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GrdGenerics.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    GenericId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                if (GrdGenerics.CurrentColumn.Name == "Delete")
                {
                   
                       
                        var gtrade = db.Generics.Where(p => p.Id == GenericId).ToList();
                        if (gtrade.Count > 0)
                        {
                            if (gtrade[0].IsActive == 0)
                            {
                                gtrade[0].IsActive = 1;
                                db.SaveChanges();
                            }
                            else
                            {
                                gtrade[0].IsActive = 0;
                                db.SaveChanges();
                            }
                            FillCombo();
                        }
                    }

               
                else if(GrdGenerics.CurrentColumn.Name == "Edit")
                {
                    //  var form = new AddNewItem();
                    var Gtrade = db.Generics.Where(p => p.Id == GenericId).ToList();
                    if (Gtrade.Count > 0)
                    {
                            GenericName.SelectedValue = Gtrade[0].Id;
                            Unit.SelectedValue = Gtrade[0].Unit_Id;
                            GenericId= Gtrade[0].Id;
                    }

                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            GenericId = 0;
            Unit.SelectedIndex = -1;
            GenericName.SelectedIndex = -1;
        }

        private void TradeName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (GenericName.ContainsFocus)
            {
                if (GenericName.SelectedIndex != -1)
                {
                    GenericId = Convert.ToInt32(GenericName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var gGeneric = db.Generics.Where(p => p.Id == GenericId).ToList();
                        if (gGeneric.Count > 0)
                        {
                            Unit.SelectedValue = gGeneric[0].Unit_Id;
                        }
                    }

                }
                else
                {
                    GenericId = 0;
                    Unit.SelectedIndex = -1;
                }
            }
        }

        private void TradeName_TextChanged(object sender, EventArgs e)
        {
            if (GenericName.ContainsFocus)
            {
                if (GenericName.Text.Length > 0)
                {
                    // GenericId = Convert.ToInt32(GenericName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var gGeneric = db.Generics.Where(p => p.GenericName == GenericName.Text).ToList();
                        if (gGeneric.Count > 0)
                        {
                            Unit.SelectedValue = gGeneric[0].Unit_Id;
                            GenericId = gGeneric[0].Id;
                        }
                    }

                }
                else
                {
                    GenericId = 0;
                    GenericName.SelectedIndex = -1;
                }
            }
        }

        private void GrdTrades_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["IsActive"].Value) == 1)
            {
                e.CellElement.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                e.CellElement.BackColor = System.Drawing.Color.White;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GrdGenerics_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (GrdGenerics.RowCount > 0)
            {
                if (Convert.ToInt32(e.RowElement.RowInfo.Cells["IsActive"].Value) == 0)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.Gray;
                }
                else if (Convert.ToInt32(e.RowElement.RowInfo.Cells["IsActive"].Value) == 1)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}

