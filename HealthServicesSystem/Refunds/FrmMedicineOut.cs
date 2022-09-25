
using ModelDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    public partial class FrmMedicineOut : Form
    {
        public int TradeId = 0;
        public FrmMedicineOut()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmMedicineOut defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmMedicineOut Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmMedicineOut();
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
                var Tlist = db.MedicineForReclaims.Where(p=>p.InContract==false).Select(p => new { p.Id, p.Generic_name,p.MaxCost, p.Activated }).ToList();

                TradeName.DataSource = Tlist;
                TradeName.DisplayMember = "Generic_name";
                TradeName.ValueMember = "Id";
                TradeName.SelectedIndex = -1;
                TradeName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                GrdTrades.DataSource = Tlist;
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (TradeName.Text == "")
            {
                MessageBox.Show("Please insert Medicine Name!");
                TradeName.Focus();
                return;
            }
            if (MaxCost.Text.Length==0)
            {
                MessageBox.Show("Please insert Max Cost!");
                MaxCost.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                if (TradeId == 0)
                {
                    int MaxId = 5000;
                    var GetMed = db.MedicineForReclaims.ToList();
                    if (GetMed.Count > 0)
                    {
                        MaxId = db.MedicineForReclaims.Max(p => p.Id) + 1;
                    }
                    MedicineForReclaim tr = new MedicineForReclaim();
                    tr.Id = MaxId;
                    tr.Generic_name= TradeName.Text.Trim();
                    tr.MaxCost = Convert.ToDecimal(MaxCost.Text);
                    tr.Activated = 1;
                    tr.InContract = false;
                    db.MedicineForReclaims.Add(tr);
                    db.SaveChanges();
                    FillCombo();
                    radButton1.PerformClick();
                    MessageBox.Show("Data has been saved", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (TradeId > 0)
                {
                    var Gtrade = db.MedicineForReclaims.Where(p => p.Id == TradeId).ToList();
                    if (Gtrade.Count > 0)
                    {
                        Gtrade[0].Generic_name= TradeName.Text.Trim();
                        Gtrade[0].MaxCost = Convert.ToDecimal(MaxCost.Text);
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
            if (GrdTrades.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    TradeId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                if (GrdTrades.CurrentColumn.Name == "Delete")
                {
                   
                       
                        var gtrade = db.MedicineForReclaims.Where(p => p.Id == TradeId).ToList();
                        if (gtrade.Count > 0)
                        {
                            if (gtrade[0].Activated == 0)
                            {
                                gtrade[0].Activated = 1;
                                db.SaveChanges();
                            }
                            else
                            {
                                gtrade[0].Activated = 0;
                                db.SaveChanges();
                            }
                            FillCombo();
                        }
                    }

               
                else if(GrdTrades.CurrentColumn.Name == "Edit")
                {
                    //  var form = new AddNewItem();
                    var Gtrade = db.MedicineForReclaims.Where(p => p.Id == TradeId).ToList();
                    if (Gtrade.Count > 0)
                    {

                            TradeName.SelectedValue = Gtrade[0].Id;
                            TradeId= Gtrade[0].Id;
                            MaxCost.Text = Gtrade[0].MaxCost.ToString();
                    }

                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            TradeId = 0;
            TradeName.SelectedIndex = -1;
            MaxCost.Clear();
        }

        private void TradeName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (TradeName.ContainsFocus)
            {
                if (TradeName.SelectedIndex != -1)
                {
                    TradeId = Convert.ToInt32(TradeName.SelectedValue.ToString());

                }
                else
                {
                    TradeId = 0;
                }
            }
        }

        private void TradeName_TextChanged(object sender, EventArgs e)
        {
            if (TradeName.ContainsFocus)
            {
                if (TradeName.Text.Length > 0)
                {
                    // TradeId = Convert.ToInt32(TradeName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var gtrade = db.MedicineForReclaims.Where(p => p.Generic_name== TradeName.Text).ToList();
                        if (gtrade.Count > 0)
                        {
                            TradeId = gtrade[0].Id;
                            MaxCost.Text = gtrade[0].MaxCost.ToString();
                        }
                    }

                }
                else
                {
                    TradeId = 0;
                }
            }
        }

        private void GrdTrades_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["Activated"].Value) == 1)
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

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

