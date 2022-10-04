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
            var q = db.ClmNonConfirmType.Where(p => p.RowStatus != RowStatus.Deleted).Select(p=> new {
            Id=p.Id,
            Name = p.Name ,
            GroupName =p.ClmNonConfirmGroup.GroupName,
            DescType = p.DicountType,
            DescFrm = p.ValueType,
            DescValue = p.Value
            
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
            DiscountType.DataSource = Enum.GetValues(typeof(ModelDB.ValueType));
            DiscountFrm.DataSource = Enum.GetValues(typeof(DicountType));
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            
            if (IdTxt.Text== null )
            {
                ClmNonConfirmType  n = new ClmNonConfirmType();
                n.Name = NameTxt.Text;
                n.GroupId =int.Parse( GroupName.SelectedValue.ToString ());
                n.DicountType = (DicountType)(ModelDB.DicountType)Enum.Parse(typeof(ModelDB.DicountType), DiscountType.SelectedText);
                n.ValueType  = (ModelDB.ValueType)(ModelDB.ValueType)Enum.Parse(typeof(ModelDB.ValueType), DiscountFrm.SelectedText);
                n.RowStatus = RowStatus.NewRow;
                n.Status = Status.Active;
                n.DateIn = PLC.getdatetime();
                n.UserId = _UserId;
                db.ClmNonConfirmType.Add(n);
                    if (db.SaveChanges()>0)
                {
                    IdTxt.Text = n.Id.ToString();
                    fillGrid();
                }
            }
            else
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d== DialogResult.No)
                {
                    return;
                }
                int _id = int.Parse(IdTxt.Text);
                var q = db.ClmNonConfirmType.Where(p => p.Id == _id).Take(1).ToList();
                if (q.Count >0)
                {
                    q[0].Name = NameTxt.Text;
                    q[0].GroupId = int.Parse(GroupName.SelectedValue.ToString());
                    q[0].DicountType = (DicountType)(ModelDB.DicountType)Enum.Parse(typeof(ModelDB.DicountType), DiscountType.SelectedText);
                    q[0].ValueType = (ModelDB.ValueType)(ModelDB.ValueType)Enum.Parse(typeof(ModelDB.ValueType), DiscountFrm.SelectedText);
                    q[0].RowStatus = RowStatus.NewRow;
                    if (db.SaveChanges()>0)
                    {
                        MessageBox.Show("تمت عملية التعديل بنجاح...");

                    }

                }
            }
        }
    }
}
