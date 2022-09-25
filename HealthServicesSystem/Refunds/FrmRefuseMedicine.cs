
using ModelDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    public partial class FrmRefuseMedicine : Form
    {
        public int ApproveId = 0;
        public FrmRefuseMedicine()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        public int ExcuId = 0;
        public int ReqId = 0;
        public string InsurId;
        public string Phone;
        public string CustName;
        public string Sex;
        public string ServerName;
        public string Rec_No;
        public DateTime BirthDate;
        public int UserId = 0;
        private static FrmRefuseMedicine defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmRefuseMedicine Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmRefuseMedicine();
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
                GRDApproveType.Rows.Clear();
                if (ApproveId > 0)
                {
                    var Fres = db.RefuseMedicineDetails.Where(p => p.RefuseId == ApproveId).ToList();
                    if (Fres.Count > 0)
                    {
                        for (int i = 0; i < Fres.Count; i++)
                        {
                            GRDApproveType.Rows.Add(Fres[i].Id, Fres[i].RefuseReason, "حذف");
                        }
                    }
                }
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (RefuseReason.Text == "")
            {
                MessageBox.Show("يجب ادخال السبب");
                RefuseReason.Focus();
                return;
            }

            using (dbContext db = new dbContext())
            {
                if (ApproveId == 0)
                {
                    RefuseMedicine tr = new RefuseMedicine();
                    tr.ReqCenterId = ReqId;
                    tr.ExcCenterId = ExcuId;
                    tr.PhoneNo = Phone;
                    tr.InsurNo = InsurId;
                    tr.InsurName = CustName;
                    tr.Gender = Sex;
                    tr.Server = ServerName;
                    tr.ClientId = Rec_No;
                    tr.BirthDate = BirthDate;
                    tr.UserId = UserId;
                    tr.RefuseDate = PLC.getdate();
                    db.RefuseMedicines.Add(tr);
                    db.SaveChanges();
                    var MaxId = db.RefuseMedicines.Where(p => p.UserId == UserId).Max(p => p.Id);
                    ApproveId = MaxId;
                    var Fres = db.RefuseMedicineDetails.Where(p => p.RefuseId == ApproveId && p.RefuseReason == RefuseReason.Text).ToList();
                    if (Fres.Count == 0)
                    {
                        RefuseMedicineDetails refd = new RefuseMedicineDetails();
                        refd.RefuseId = ApproveId;
                        refd.RefuseReason = RefuseReason.Text.Trim();
                        db.RefuseMedicineDetails.Add(refd);
                        db.SaveChanges();
                        FillCombo();
                    }

                    radButton1.PerformClick();
                    MessageBox.Show("لقد حفظت البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ApproveId > 0)
                {
                    var Fres = db.RefuseMedicineDetails.Where(p => p.RefuseId == ApproveId && p.RefuseReason == RefuseReason.Text).ToList();
                    if (Fres.Count == 0)
                    {
                        RefuseMedicineDetails refd = new RefuseMedicineDetails();
                        refd.RefuseId = ApproveId;
                        refd.RefuseReason = RefuseReason.Text.Trim();
                        db.RefuseMedicineDetails.Add(refd);
                        db.SaveChanges();
                        FillCombo();
                    }

                    radButton1.PerformClick();
                    MessageBox.Show("لقد حفظت البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (GRDApproveType.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {


                    int RefuseId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                    if (GRDApproveType.CurrentColumn.Name == "Delete")
                    {
                        if (GRDApproveType.RowCount > 1)
                        {

                            var gtrade = db.RefuseMedicineDetails.Where(p => p.Id == RefuseId).ToList();
                            if (gtrade.Count > 0)
                            {
                                db.RefuseMedicineDetails.Remove(gtrade[0]);
                                db.SaveChanges();
                                FillCombo();
                            }
                        }
                       else if (GRDApproveType.RowCount == 1)
                        {

                            var gtrade = db.RefuseMedicineDetails.Where(p => p.Id == RefuseId).ToList();
                            if (gtrade.Count > 0)
                            {
                                int RId = gtrade[0].RefuseId;
                                

                                db.RefuseMedicineDetails.Remove(gtrade[0]);
                                db.SaveChanges();
                                var MRefuse = db.RefuseMedicines.Where(p => p.Id == RId).ToList();
                                if (MRefuse.Count > 0)
                                {
                                    db.RefuseMedicines.Remove(MRefuse[0]);
                                    db.SaveChanges();
                                }
                                //FillCombo();
                            }
                        }
                    }

                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            RefuseReason.Text = "";
            RefuseReason.Focus();
        }

        private void TradeName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (RefuseReason.ContainsFocus)
            {
                if (RefuseReason.SelectedIndex != -1)
                {
                    ApproveId = Convert.ToInt32(RefuseReason.SelectedValue.ToString());

                }
                else
                {
                    ApproveId = 0;
                }
            }
        }

        private void TradeName_TextChanged(object sender, EventArgs e)
        {
            //if (RefuseReason.ContainsFocus)
            //{
            //    if (RefuseReason.Text.Length > 0)
            //    {
            //        // TradeId = Convert.ToInt32(TradeName.SelectedValue.ToString());
            //        using (dbContext db = new dbContext())
            //        {
            //            var gtrade = db.ApproveMedicineTypes.Where(p => p.ApproveType == RefuseReason.Text).ToList();
            //            if (gtrade.Count > 0)
            //            {
            //                ApproveId = gtrade[0].Id;
            //            }
            //        }

            //    }
            //    else
            //    {
            //        ApproveId = 0;
            //    }
            //}
        }

        private void GrdTrades_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            //if (Convert.ToInt32(e.Row.Cells["Activated"].Value) == 1)
            //{
            //    e.CellElement.BackColor = System.Drawing.Color.Gray;
            //}
            //else
            //{
            //    e.CellElement.BackColor = System.Drawing.Color.White;
            //}
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GrdTrades_Click(object sender, EventArgs e)
        {

        }

        private void GRDApproveType_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            // if (GRDApproveType.RowCount > 0)
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

        private void RadButton3_Click(object sender, EventArgs e)
        {

            if (GRDApproveType.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    DialogResult a = 0;
                    a = MessageBox.Show("سوف يتم حذف بيانات العملية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                    if (a == DialogResult.Yes)
                    {
                        db.Database.ExecuteSqlCommand("delete from RefuseMedicineDetails where RefuseId=" + ApproveId + "");
                        db.Database.ExecuteSqlCommand("delete from RefuseMedicines where Id=" + ApproveId + "");
                        MessageBox.Show("لقد تم حذف البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        GRDApproveType.Rows.Clear();
                        radButton1.PerformClick();
                    }
                    }
            }
        }
    }
}

