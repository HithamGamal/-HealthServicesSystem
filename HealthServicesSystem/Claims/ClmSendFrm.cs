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
    public partial class ClmSendFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmSendFrm()
        {
            InitializeComponent();
        }
        int _UserId = LoginForm.Default.UserId;
        public void FillNotSend()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                UnSendClmGrd.DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Request && p.Month == _m && p.year == _y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    UnSendClmGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }

        public void FillSend()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                SendClmGrd.DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Allocation && p.Month == _m && p.year == _y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    SendClmGrd.DataSource = q;
                }
            }
            catch
            {

            }
       

        }

        private void ClmSendFrm_Load(object sender, EventArgs e)
        {

        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            if (MonthDrp.SelectedIndex == -1)
            {
                MessageBox.Show("اختر الشهر ");
                return;
            }
            if (YearTxt.Text.Length != 4)
            {
                MessageBox.Show("اختر السنة ");
                return;
            }
            FillNotSend();
            FillSend();
        }

        private void UnSendClmGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (UnSendClmGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (UnSendClmGrd.CurrentColumn.Name == "Send")
                {
                    DialogResult d = MessageBox.Show("هل تريد ارسال الملف رقم  ؟", "تأكيد" + "" + UnSendClmGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " \n للمركز " + UnSendClmGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(UnSendClmGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Allocation ;
                        q[0].RequestUserId = _UserId;
                        q[0].RequestDate = PLC.getdatetime();
                        db.SaveChanges();
                        FillSend ();
                       FillNotSend ();
                    }
                }
            }
        }

        private void SendClmGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (SendClmGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (SendClmGrd.CurrentColumn.Name == "UnSend")
                {
                    DialogResult d = MessageBox.Show("هل تريد الغاء طلب الملف رقم  ؟", "تأكيد" + "" + SendClmGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " للمركز " + SendClmGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(SendClmGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Request;
                        q[0].EnabledUserId = _UserId;
                        q[0].EnabledDate = PLC.getdatetime();
                        db.SaveChanges();
                      FillNotSend();
                        FillSend();
                    }
                }
            }
        }
    }
}
