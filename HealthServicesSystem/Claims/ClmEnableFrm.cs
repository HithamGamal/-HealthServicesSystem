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

namespace MedicalServiceSystem.Claims
{
    public partial class ClmEnableFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmEnableFrm()
        {
            InitializeComponent();
        }
        int _UserId = LoginForm.Default.UserId;
        public void FillNotEnabled()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                NotEnabledGrd.DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Receipt && p.Month ==_m && p.year==_y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    NotEnabledGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }

        public void FillEnabled()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                EnabledGrd.DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Enabled  && p.Month == _m && p.year == _y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    EnabledGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }
        private void ClmEnableFrm_Load(object sender, EventArgs e)
        {

        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
          if(MonthDrp.SelectedIndex ==-1)
            {
                MessageBox.Show("اختر الشهر ");
                return;
            }
            if (YearTxt.Text.Length != 4)
            {
                MessageBox.Show("اختر السنة ");
                return;
            }
            FillEnabled();
            FillNotEnabled();
        }

        private void NotEnabledGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (NotEnabledGrd.RowCount >0)
            {
                dbContext db = new dbContext();
                if (NotEnabledGrd.CurrentColumn .Name =="Enable")
                {
                    DialogResult d = MessageBox.Show("هل تريد اتاحة الملف رقم  ؟", "تأكيد" +"" + NotEnabledGrd.CurrentRow.Cells["FileNo"].Value.ToString() +" \n للمركز " + NotEnabledGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(NotEnabledGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId ).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Enabled;
                        q[0].EnabledUserId = _UserId;
                        q[0].EnabledDate = PLC.getdatetime();
                        db.SaveChanges();
                        FillEnabled();
                        FillNotEnabled();
                    }
                }
            }
        }

        private void EnabledGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (EnabledGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (EnabledGrd.CurrentColumn.Name == "UnEnable")
                {
                    DialogResult d = MessageBox.Show("هل تريد الغاء اتاحة الملف رقم  ؟", "تأكيد" + "" + EnabledGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " للمركز " + EnabledGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(EnabledGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Receipt ;
                        q[0].EnabledUserId = _UserId;
                        q[0].EnabledDate = PLC.getdatetime();
                        db.SaveChanges();
                        FillEnabled();
                        FillNotEnabled();
                    }
                }
            }
        }
    }
}
