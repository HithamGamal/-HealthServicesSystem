
using MedicalServiceSystem.Reclaims;
using ModelDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    public partial class FrmMedicineList : Form
    {
        public int ListId = 0;
        public FrmMedicineList()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmMedicineList defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmMedicineList Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmMedicineList();
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
                var Tlist = db.MedicineLists.Select(p => new { p.Id, p.ListName }).ToList();

                ListName.DataSource = Tlist;
                ListName.DisplayMember = "ListName";
                ListName.ValueMember = "Id";
                ListName.SelectedIndex = -1;
                ListName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                GrdListName.DataSource = Tlist;
                
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (ListName.Text == "")
            {
                MessageBox.Show("Please insert List Name!");
                ListName.Focus();
                return;
            }

            using (dbContext db = new dbContext())
            {
                if (ListId == 0)
                {
                    MedicineList tr = new MedicineList();
                    tr.ListName= ListName.Text.Trim();
                    db.MedicineLists.Add(tr);
                    db.SaveChanges();
                    FillCombo();
                    radButton1.PerformClick();
                    MessageBox.Show("Data has been saved", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ListId > 0)
                {
                    var Gtrade = db.MedicineLists.Where(p => p.Id == ListId).ToList();
                    if (Gtrade.Count > 0)
                    {
                        Gtrade[0].ListName= ListName.Text.Trim();
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
            if (GrdListName.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    ListId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                   

                   if (GrdListName.CurrentColumn.Name == "Edit")
                    {
                        //  var form = new AddNewItem();
                        var Gtrade = db.MedicineLists.Where(p => p.Id == ListId).ToList();
                        if (Gtrade.Count > 0)
                        {

                            ListName.SelectedValue = Gtrade[0].Id;
                            ListId = Gtrade[0].Id;
                        }

                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ListId = 0;
            ListName.SelectedIndex = -1;
        }

        private void TradeName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ListName.ContainsFocus)
            {
                if (ListName.SelectedIndex != -1)
                {
                    ListId = Convert.ToInt32(ListName.SelectedValue.ToString());

                }
                else
                {
                    ListId = 0;
                }
            }
        }

        private void TradeName_TextChanged(object sender, EventArgs e)
        {
            if (ListName.ContainsFocus)
            {
                if (ListName.Text.Length > 0)
                {
                    // TradeId = Convert.ToInt32(TradeName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var gtrade = db.MedicineLists.Where(p => p.ListName == ListName.Text).ToList();
                        if (gtrade.Count > 0)
                        {
                            ListId = gtrade[0].Id;
                        }
                    }

                }
                else
                {
                    ListId = 0;
                }
            }
        }

        private void GrdTrades_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
          
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var Mlist = db.MedicineLists.ToList();
                FRMMedicinePricing.Default.ListName.DataSource = Mlist;
                FRMMedicinePricing.Default.ListName.DisplayMember = "ListName";
                FRMMedicinePricing.Default.ListName.ValueMember = "Id";
                FRMMedicinePricing.Default.ListName.SelectedIndex = -1;
            }
            Close();
        }

        private void GrdTrades_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            //if (GrdListName.RowCount > 0)
            //{
            //    if (Convert.ToInt32(e.RowElement.RowInfo.Cells["Activated"].Value) == 0)
            //    {
            //        e.RowElement.DrawFill = true;
            //        e.RowElement.BackColor = System.Drawing.Color.Gray;
            //    }
            //    else if (Convert.ToInt32(e.RowElement.RowInfo.Cells["Activated"].Value) == 1)
            //    {
            //        e.RowElement.DrawFill = true;
            //        e.RowElement.BackColor = System.Drawing.Color.White;
            //    }
            //}
        }
    }
}

