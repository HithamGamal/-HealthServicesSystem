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
    public partial class ClmRequestFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmRequestFrm()
        {
            InitializeComponent();
        }

        int _UserId = LoginForm.Default.UserId;
        public void FillNotRequest()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                UnRequsetGrd .DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Enabled && p.Month == _m && p.year == _y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    UnRequsetGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }

        public void FillRequest()
        {
            try
            {
                int _m = MonthDrp.SelectedIndex + 1;
                int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                RequestGrd .DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Request  && p.Month == _m && p.year == _y).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    RequestGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }
    
    private void ClmRequestFrm_Load(object sender, EventArgs e)
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
            FillRequest ();
            FillNotRequest ();
        }

        private void UnRequsetGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (UnRequsetGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (UnRequsetGrd.CurrentColumn.Name == "Req")
                {
                    DialogResult d = MessageBox.Show("هل تريد طلب الملف رقم  ؟", "تأكيد" + "" + UnRequsetGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " \n للمركز " + UnRequsetGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(UnRequsetGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Request;
                        q[0].RequestUserId = _UserId;
                        q[0].RequestDate = PLC.getdatetime();
                        db.SaveChanges();
                        FillNotRequest ();
                        FillRequest();
                    }
                }
            }
        }

        private void RequestGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (RequestGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (RequestGrd.CurrentColumn.Name == "UnReq")
                {
                    DialogResult d = MessageBox.Show("هل تريد الغاء طلب الملف رقم  ؟", "تأكيد" + "" + RequestGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " للمركز " + RequestGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(RequestGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Receipt;
                        q[0].EnabledUserId = _UserId;
                        q[0].EnabledDate = PLC.getdatetime();
                        db.SaveChanges();
                        FillRequest ();
                        FillNotRequest();
                    }
                }
            }
        }
    }
    
}
