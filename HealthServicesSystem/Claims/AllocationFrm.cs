﻿using HealthServicesSystem.SystemSetting;
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
    public partial class AllocationFrm : Telerik.WinControls.UI.RadForm
    {
        public AllocationFrm()
        {
            InitializeComponent();
        }
        int _UserId = LoginForm.Default.UserId;
        public void FillNotAllocat()
        {
            try
            {
                //int _m = MonthDrp.SelectedIndex + 1;
                //int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                UnAllocatGrd .DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Allocation  ).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year }).ToList();
                if (q.Count > 0)
                {
                    UnAllocatGrd.DataSource = q;
                }
            }
            catch
            {

            }
        }

        public void FillAllocat()
        {
            try
            {
                //int _m = MonthDrp.SelectedIndex + 1;
                //int _y = int.Parse(YearTxt.Text);
                dbContext db = new dbContext();
                AllocatGrd.DataSource = null;
                var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Review ).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m = p.Month, y = p.year  , DocName = db.Users .Where (s=> s.Id == p.AllocatedDocId ).Select (s=> s.FullName ).FirstOrDefault ()}).ToList();
                if (q.Count > 0)
                {
                    AllocatGrd.DataSource = q;
                }
            }
            catch
            {

            }


        }
        private void AllocationFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var q = db.Users.Where(p => p.UserStatus == 1 && (p.GroupId ==9|| p.GroupId ==3)).Select(p => new { Id = p.Id, UserName = p.FullName }).ToList();
            if(q.Count>0)
            {
                UserName.DataSource = q;
                UserName.DisplayMember = "UserName";
                UserName.ValueMember = "Id";
                UserName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                UserName.SelectedIndex = -1;
            }
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
          
            FillNotAllocat();
            FillAllocat ();
        }

        private void UnAllocatGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (UnAllocatGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (UnAllocatGrd.CurrentColumn.Name == "Select")
                {
                  
                    ImpNoTxt.Text = UnAllocatGrd.CurrentRow.Cells["Id"].Value.ToString();
                    FileNoTxt .Text = UnAllocatGrd.CurrentRow.Cells["FileNo"].Value.ToString();
                    CenterNameTxt .Text =  UnAllocatGrd.CurrentRow.Cells["CenterName"].Value.ToString();
                  
                }
            }
        }

        private void AllocatGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (AllocatGrd.RowCount > 0)
            {
                dbContext db = new dbContext();
                if (AllocatGrd.CurrentColumn.Name == "Del")
                {
                    DialogResult d = MessageBox.Show("هل تريد الغاء توزيع الملف رقم  ؟", "تأكيد" + "" + AllocatGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " للمركز " + AllocatGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    int _impId = int.Parse(AllocatGrd.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
                    if (q.Count > 0)
                    {
                        q[0].ClmStatus = ClmStatus.Allocation;
                       
                        q[0].AllocatedDocId = 0;
                        db.SaveChanges();
                        FillNotAllocat ();
                        FillAllocat ();
                    }
                }
            }
        }

        private void AllocBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            if (UserName .SelectedIndex ==-1)
            {
                MessageBox.Show("يجب تحديد اسم الصيدلي ");
                return;
            }
            DialogResult d = MessageBox.Show("هل تريد توزيع الملف رقم  ؟", "تأكيد" + "" + UnAllocatGrd.CurrentRow.Cells["FileNo"].Value.ToString() + " \n للمركز " + UnAllocatGrd.CurrentRow.Cells["CenterName"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.No)
            {
                return;
            }
       
            int _impId = int.Parse(UnAllocatGrd.CurrentRow.Cells["Id"].Value.ToString());

            var q = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == _impId).ToList();
            if (q.Count > 0)
            {
                q[0].ClmStatus = ClmStatus.Review;
                q[0].RequestUserId = _UserId;
                q[0].RequestDate = PLC.getdatetime();
                q[0].AllocatedDocId = int.Parse(UserName.SelectedValue.ToString());
                db.SaveChanges();
                FillAllocat();
                FillNotAllocat();
            }
        }
    }
}
