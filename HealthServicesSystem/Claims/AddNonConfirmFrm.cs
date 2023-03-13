using HealthServicesSystem.SystemSetting;
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

namespace HealthServicesSystem.Claims
{
    public partial class AddNonConfirmFrm : Telerik.WinControls.UI.RadForm
    {
        public AddNonConfirmFrm()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        public void fillGrid()
        {
            radGridView1.DataSource = null;
            dbContext db = new dbContext();
            var q = db.ClmNonConfirmType.Where(p => p.RowStatus != RowStatus.Deleted).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                GroupName = p.ClmNonConfirmGroup.GroupName,
                DiscType = p.DicountType,
                DiscFrm = p.ValueType,
                DiscValue = p.Value

            }).ToList();
            if (q.Count > 0)
            {
                radGridView1.DataSource = q;
            }
        }
        private void NewBtn_Click(object sender, EventArgs e)
        {
            IdTxt.Clear();
            NameTxt.Clear();
            GroupName.SelectedIndex = -1;
            DiscountFrm.SelectedIndex = -1;
            DiscountType.SelectedIndex = -1;
            DiscoutValue.Clear();
            fillGrid();
        }

        private void AddNonConfirmFrm_Load(object sender, EventArgs e)
        {
            fillGrid();
            dbContext db = new dbContext();
            DiscountType.DataSource = Enum.GetValues(typeof(ModelDB.ValueType));
            DiscountFrm.DataSource = Enum.GetValues(typeof(DicountType));

            var q = db.ClmNonConfirmGroups.ToList();
            if (q.Count > 0)
            {
                GroupName.DataSource = q;
                GroupName.DisplayMember = "GroupName";
                GroupName.ValueMember = "Id";
                GroupName.SelectedIndex = -1;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();

            if (IdTxt.Text == null)
            {
                ClmNonConfirmType n = new ClmNonConfirmType();
                n.Name = NameTxt.Text;
                n.GroupId = int.Parse(GroupName.SelectedValue.ToString());
                n.DicountType = (DicountType)(ModelDB.DicountType)Enum.Parse(typeof(ModelDB.DicountType), DiscountType.SelectedText);
                n.ValueType = (ModelDB.ValueType)(ModelDB.ValueType)Enum.Parse(typeof(ModelDB.ValueType), DiscountFrm.SelectedText);
                n.RowStatus = RowStatus.NewRow;
                n.Status = Status.Active;
                n.DateIn = PLC.getdatetime();
                n.UserId = _UserId;
                db.ClmNonConfirmType.Add(n);
                if (db.SaveChanges() > 0)
                {
                    IdTxt.Text = n.Id.ToString();
                    fillGrid();
                }
            }
            else
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
                int _id = int.Parse(IdTxt.Text);
                var q = db.ClmNonConfirmType.Where(p => p.Id == _id).Take(1).ToList();
                if (q.Count > 0)
                {
                    q[0].Name = NameTxt.Text;
                    q[0].GroupId = int.Parse(GroupName.SelectedValue.ToString());
                    q[0].DicountType = (DicountType)(ModelDB.DicountType)Enum.Parse(typeof(ModelDB.DicountType), DiscountFrm.Text);
                    q[0].ValueType = (ModelDB.ValueType)(ModelDB.ValueType)Enum.Parse(typeof(ModelDB.ValueType), DiscountType.Text);
                    q[0].Value = Convert.ToDecimal(DiscoutValue.Text);
                    q[0].UpdateUser = _UserId;
                    q[0].UpdateDate = PLC.getdatetime();
                    if (db.SaveChanges() > 0)
                    {
                        fillGrid();
                        MessageBox.Show("تمت عملية التعديل بنجاح...");

                    }

                }
            }
        }

        private void radGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int Id = int.Parse(radGridView1.CurrentRow.Cells["Id"].Value.ToString());
                IdTxt.Text = Id.ToString();

            }
        }

        private void IdTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dbContext db = new dbContext();
                int _id = int.Parse(IdTxt.Text);
                var q = db.ClmNonConfirmType.Where(p => p.Id == _id).Take(1).ToList();
                if (q.Count > 0)
                {
                    NameTxt.Text = q[0].Name;
                    GroupName.SelectedValue = q[0].GroupId;
                    DiscountType.SelectedIndex = Convert.ToInt32(q[0].DicountType);
                    DiscountFrm.SelectedIndex = Convert.ToInt32(q[0].ValueType);
                    DiscoutValue.Text = q[0].Value.ToString();



                }
            }
            catch
            {

            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            DialogResult d = MessageBox.Show("هل تريد الحذف؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.No)
            {
                return;
            }
            int _id = int.Parse(IdTxt.Text);
            var q = db.ClmNonConfirmType.Where(p => p.Id == _id).Take(1).ToList();
            if (q.Count > 0)
            {
                q[0].UserDeleted = _UserId;
                q[0].DeleteDate = PLC.getdatetime();
                q[0].RowStatus = RowStatus.Deleted;
                if (db.SaveChanges() > 0)
                {
                    fillGrid();
                    MessageBox.Show("تمت عملية الحذف بنجاح...");

                }

            }
        }
    }
}
