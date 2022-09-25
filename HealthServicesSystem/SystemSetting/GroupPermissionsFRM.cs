using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ModelDB;
using Telerik.WinControls;

namespace MedicalServiceSystem.SystemSetting
{
    public partial class GroupPermissionsFRM : Telerik.WinControls.UI.RadForm
    {
        public GroupPermissionsFRM()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static GroupPermissionsFRM defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static GroupPermissionsFRM Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new GroupPermissionsFRM();
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
        private void radButton4_Click(object sender, EventArgs e)
        {


            Dispose();
        }

        private void OperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GroupId.Text = GroupName.SelectedValue.ToString();
            }
            catch (Exception)
            {
                GroupId.Text = "";

                return;
            }
        }

        private void GroupPermissionsFRM_Load(object sender, EventArgs e)
        {
            //    MainMenuFrm.Default.timer1.Stop();
            //    MainMenuFrm.Default.timer1.Start();
            using (dbContext db = new dbContext())
            {
                var cut = db.UserGroups.ToList();
                GroupName.DataSource = cut;
                GroupName.DisplayMember = "GroupName";
                GroupName.ValueMember = "Id";
                GroupName.SelectedIndex = -1;
                GroupName.Text = "";
                GroupId.Text = "";
                // CustomerStatus.SelectedIndex = 
                var v = (from frm in db.SysForms
                         select new
                         {
                             FormId = frm.Id,
                             FormName = frm.ArabicFormName
                         }).ToList();
                if (v.Count > 0)
                {
                    GRDForm.DataSource = v;
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        GRDForm.Rows[i].Cells[0].Value = i + 1;
                    }
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        GRDForm.Rows[i].Cells["Choose"].Value = false;
                    }
                }
            }
        }

        private void GroupName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //try
            //{
            if (GroupName.ContainsFocus)
            {


                using (dbContext db = new dbContext())
                {
                    if (GroupName.Text != "")
                    {
                        GroupId.Text = GroupName.SelectedValue.ToString();

                        int x = int.Parse(GroupId.Text);
                        var SysId = db.UserGroups.Where(p => p.Id == x).ToList()[0].SystemId;
                        //Interaction.MsgBox(x.ToString());
                        if (x > 1)
                        {
                            var u = (from usr in db.GroupPermissions.Where(p => p.GroupId == x)
                                     join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                         on usr.FormId equals r.Id
                                     select new
                                     {
                                         Id = usr.Id,
                                         FormId = usr.FormId,
                                         GroupId = usr.GroupId,
                                         FormName = r.ArabicFormName
                                     }).ToList();

                            GrdPermIssions.DataSource = u;
                            if (u.Count > 0)
                            {

                                for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                {
                                    GrdPermIssions.Rows[i].Cells[0].Value = i + 1;
                                }
                                for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                {
                                    GrdPermIssions.Rows[i].Cells["Choose"].Value = false;
                                }
                            }
                            var v1 = db.GroupPermissions.Where(p => p.GroupId == x).Select(x1 => x1.FormId).ToArray();
                            var otherObjects =
                                db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                    .Select(x1 => new { FormId = x1.Id, FormName = x1.ArabicFormName })
                                    .ToList();

                            GRDForm.DataSource = otherObjects;
                            if (GRDForm.RowCount > 0)
                                for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                                {
                                    GRDForm.Rows[i].Cells[0].Value = i + 1;
                                }
                            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                            {
                                GRDForm.Rows[i].Cells["Choose"].Value = false;
                            }
                        }
                        else
                        {
                            var u = (from usr in db.GroupPermissions
                                     join r in db.SysForms
                                         on usr.FormId equals r.Id
                                     where usr.GroupId == x
                                     select new
                                     {
                                         Id = usr.Id,
                                         FormId = usr.FormId,
                                         GroupId = usr.GroupId,
                                         FormName = r.ArabicFormName
                                     }).ToList();

                            GrdPermIssions.DataSource = u;
                            if (u.Count > 0)
                            {

                                for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                {
                                    GrdPermIssions.Rows[i].Cells[0].Value = i + 1;
                                }
                                for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                {
                                    GrdPermIssions.Rows[i].Cells["Choose"].Value = false;
                                }
                            }
                            var v1 = db.GroupPermissions.Where(p => p.GroupId == x).Select(x1 => x1.FormId).ToArray();
                            var otherObjects =
                                db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                    .Select(x1 => new { FormId = x1.Id, FormName = x1.ArabicFormName })
                                    .ToList();

                            GRDForm.DataSource = otherObjects;
                            if (GRDForm.RowCount > 0)
                                for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                                {
                                    GRDForm.Rows[i].Cells[0].Value = i + 1;
                                }
                            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                            {
                                GRDForm.Rows[i].Cells["Choose"].Value = false;
                            }
                        }
                    }
                }
            }
            //}
            //catch (Exception)
            //{

            //    return;
            //}
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            if (GroupId.Text.Length == 0)
            {
                Interaction.MsgBox("يجب اختيار المجموعة أولا", MsgBoxStyle.Exclamation, "System");
                GroupName.Focus();
                return;
            }
            if (GRDForm.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        if ((bool)(GRDForm.Rows[i].Cells["Choose"].Value) == true)
                        {

                            GroupPermission groupPermission = new GroupPermission();
                            groupPermission.GroupId = int.Parse(GroupId.Text);
                            groupPermission.FormId = (int)(GRDForm.Rows[i].Cells[1].Value);
                            db.GroupPermissions.Add(groupPermission);
                            db.SaveChanges();

                        }


                    }
                    int x = int.Parse(GroupId.Text);
                    var SysId = db.UserGroups.Where(p => p.Id == x).ToList()[0].SystemId;

                    var u = (from usr in db.GroupPermissions.Where(p => p.GroupId == x)
                             join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                 on usr.FormId equals r.Id
                             select new
                             {
                                 Id = usr.Id,
                                 FormId = usr.FormId,
                                 GroupId = usr.GroupId,
                                 FormName = r.ArabicFormName
                             }).ToList();

                    GrdPermIssions.DataSource = u;
                    if (u.Count > 0)
                    {

                        for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                        {
                            GrdPermIssions.Rows[i].Cells[0].Value = i + 1;
                        }
                        for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                        {
                            GrdPermIssions.Rows[i].Cells["Choose"].Value = false;
                        }
                    }
                    var v1 = db.GroupPermissions.Where(p => p.GroupId == x).Select(x1 => x1.FormId).ToArray();
                    var otherObjects =
                        db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                            .Select(x1 => new { FormId = x1.Id, FormName = x1.ArabicFormName })
                            .ToList();

                    GRDForm.DataSource = otherObjects;
                    if (GRDForm.RowCount > 0)
                        for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                        {
                            GRDForm.Rows[i].Cells[0].Value = i + 1;
                        }
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        GRDForm.Rows[i].Cells["Choose"].Value = false;
                    }
                }
            }

        }

        private void RadButton2_Click(object sender, EventArgs e)
        {
            //    MainMenuFrm.Default.timer1.Stop();
            //    MainMenuFrm.Default.timer1.Start();
            try
            {
                using (dbContext db = new dbContext())
                {
                    if (GrdPermIssions.RowCount > 0)
                    {
                        for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                        {
                            if ((bool)(GrdPermIssions.Rows[i].Cells["Choose"].Value) == true)
                            {
                                int x1 = (int)(GrdPermIssions.Rows[i].Cells["Id"].Value);
                                var u1 = db.GroupPermissions.Where(p => p.Id == x1).ToList();
                                db.GroupPermissions.Remove(u1[0]);
                                db.SaveChanges();

                            }
                        }
                        int x = int.Parse(GroupId.Text);
                        var SysId = db.UserGroups.Where(p => p.Id == x).ToList()[0].SystemId;

                        var u = (from usr in db.GroupPermissions.Where(p => p.GroupId == x)
                                 join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                     on usr.FormId equals r.Id
                                 select new
                                 {
                                     Id = usr.Id,
                                     FormId = usr.FormId,
                                     GroupId = usr.GroupId,
                                     FormName = r.ArabicFormName
                                 }).ToList();

                        GrdPermIssions.DataSource = u;
                        if (u.Count > 0)
                        {

                            for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                            {
                                GrdPermIssions.Rows[i].Cells[0].Value = i + 1;
                            }
                            for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                            {
                                GrdPermIssions.Rows[i].Cells["Choose"].Value = false;
                            }
                        }
                        var v1 = db.GroupPermissions.Where(p => p.GroupId == x).Select(x1 => x1.FormId).ToArray();
                        var otherObjects =
                            db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                .Select(x1 => new { FormId = x1.Id, FormName = x1.ArabicFormName })
                                .ToList();

                        GRDForm.DataSource = otherObjects;
                        if (GRDForm.RowCount > 0)
                            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                            {
                                GRDForm.Rows[i].Cells[0].Value = i + 1;
                            }
                        for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                        {
                            GRDForm.Rows[i].Cells["Choose"].Value = false;
                        }
                    }
                }

            }
            catch (Exception)
            {

                return;
            }
        }

        private void ChkFrom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (GRDForm.RowCount > 0)
            {
                if (ChkFrom.Checked == true)
                {
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        GRDForm.Rows[i].Cells["choose"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        GRDForm.Rows[i].Cells["choose"].Value = false;
                    }
                }
            }
        }

        private void ChkTo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (GrdPermIssions.RowCount > 0)
            {
                if (ChkFrom.Checked == true)
                {
                    for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                    {
                        GrdPermIssions.Rows[i].Cells["choose"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                    {
                        GrdPermIssions.Rows[i].Cells["choose"].Value = false;
                    }
                }
            }
        }

        //private void CustomerName_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}




        //private void Discount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //     (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void radButton2_Click(object sender, EventArgs e)
        //{

        //}

        //private void CustomerFRM_Load(object sender, EventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //    using (dbContext db = new dbContext())
        //    {
        //        var cut = db.UserGroups.Where(p => p.Id > 0 && p.RowStatus != RowStatus.Deleted).ToList();
        //        GroupName.DataSource = cut;
        //        GroupName.DisplayMember = "GroupName";
        //        GroupName.ValueMember = "Id";
        //        GroupName.SelectedIndex = -1;
        //        GroupName.Text = "";
        //        GroupId.Text = "";
        //        // CustomerStatus.SelectedIndex = 
        //        var v = (from frm in db.SysForms.Where(p => p.Status == Status.Active)
        //            select new
        //            {
        //                FormId = frm.Id,
        //                FormName = frm.ArabicFormName
        //            }).ToList();
        //        if (v.Count > 0)
        //        {
        //            GRDForm.DataSource = v;
        //            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
        //            {
        //                GRDForm.Rows[i].Cells[0].Value = i + 1;
        //            }
        //            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
        //            {
        //                GRDForm.Rows[i].Cells["Choose"].Value = false;
        //            }
        //        }
        //    }
        //}

        //private void radButton1_Click(object sender, EventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();

        //}


        //private void radButton3_Click(object sender, EventArgs e)
        //{

        //}

        //private void GRDGroups_Click(object sender, EventArgs e)
        //{

        //}

        //private void GRDGroups_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        //{

        //}

        //private void radButton2_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void ChkFrom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();

        //}

        //private void ChkTo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        //{

        //}

        //private void radButton2_MouseMove(object sender, MouseEventArgs e)
        //{

        //}

        //private void GroupPermissionFRM_MouseMove(object sender, MouseEventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //}
    }

}
