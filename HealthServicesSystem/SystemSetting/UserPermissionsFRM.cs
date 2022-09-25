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
    public partial class UserPermissionsFRM : Telerik.WinControls.UI.RadForm
    {
        public UserPermissionsFRM()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static UserPermissionsFRM defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static UserPermissionsFRM Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UserPermissionsFRM();
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


            Close();
        }

        private void OperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GroupId.Text = UserName.SelectedValue.ToString();
            }
            catch (Exception)
            {
                GroupId.Text = "";

                return;
            }
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                if (UserId.Text == "")
                {
                    Interaction.MsgBox("يجب ادخال اسم المستخدم أولا", MsgBoxStyle.Exclamation, "System");
                    UserName.Focus();
                    return;
                }
                if (GRDForm.RowCount > 0)
                {
                    for (int i = 0; i <= GRDForm.RowCount - 1; i++)
                    {
                        if ((bool)(GRDForm.Rows[i].Cells["Choose"].Value) == true)
                        {
                            UserPermission userPermission = new UserPermission();
                            userPermission.UserId = int.Parse(UserId.Text);
                            userPermission.FormId = (int)(GRDForm.Rows[i].Cells[1].Value);
                            db.UserPermissions.Add(userPermission);
                            db.SaveChanges();

                        }


                    }
                    int x = int.Parse(UserId.Text);
                    int Getgroid = db.Users.Where(p => p.Id == x).ToList()[0].GroupId;
                    var SysId = db.UserGroups.Where(p => p.Id == Getgroid).ToList()[0].SystemId;
                    //Interaction.MsgBox(x.ToString());
                    var u = (from usr in db.UserPermissions.Where(p => p.UserId == x)
                             join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                 on usr.FormId equals r.Id
                             select new
                             {
                                 Id = usr.Id,
                                 FormId = usr.FormId,
                                 UserId = usr.UserId,
                                 FormEnglishName = r.ArabicFormName
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
                        var v1 = db.UserPermissions.Where(p => p.UserId == x).Select(x1 => x1.FormId).ToArray();
                        var otherObjects =
                            db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                .Select(x1 => new { FormId = x1.Id, FormEnglishName = x1.ArabicFormName })
                                .ToList();

                        GRDForm.DataSource = otherObjects;
                        if (GRDForm.RowCount > 0)
                        {
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
        }

        private void UserPermissionsFRM_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var cut = db.Users.Where(p => p.Id > 0 && p.UserStatus == 1).ToList();
                UserName.DataSource = cut;
                UserName.DisplayMember = "FullName";
                UserName.ValueMember = "Id";
                UserName.SelectedIndex = -1;
                UserName.Text = "";
                UserId.Text = "";
                // CustomerStatus.SelectedIndex = 
                var v = (from frm in db.SysForms
                         select new
                         {
                             FormId = frm.Id,
                             FormName = frm.FormName,
                             FormEnglishName = frm.ArabicFormName
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

        private void RadButton2_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                //try
                //{
                if (GrdPermIssions.RowCount > 0)
                {
                    for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                    {
                        if ((bool)(GrdPermIssions.Rows[i].Cells["Choose"].Value) == true)
                        {
                            int x = (int)(GrdPermIssions.Rows[i].Cells["Id"].Value);
                            var u = db.UserPermissions.Where(p => p.Id == x).ToList();
                            db.UserPermissions.Remove(u[0]);
                            db.SaveChanges();

                        }
                    }
                    int y = int.Parse(UserId.Text);
                    //Interaction.MsgBox(x.ToString());
                    var w = (from usr in db.UserPermissions
                             join r in db.SysForms
                                 on usr.FormId equals r.Id
                             where usr.UserId == y
                             select new
                             {
                                 Id = usr.Id,
                                 FormId = usr.FormId,
                                 UserId = usr.UserId,
                                 FormEnglishName = r.ArabicFormName
                             }).ToList();
                    GrdPermIssions.DataSource = w;
                    if (w.Count > 0)
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
                    var v1 = db.UserPermissions.Where(p => p.UserId == y).Select(x1 => x1.FormId).ToArray();
                    var otherObjects =
                        db.SysForms.Where(x1 => !v1.Contains(x1.Id))
                            .Select(x1 => new { FormId = x1.Id, FormEnglishName = x1.ArabicFormName })
                            .ToList();

                    GRDForm.DataSource = otherObjects;
                    if (GRDForm.RowCount > 0)
                    {
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


                //}
                //catch (Exception)
                //{

                //    return;
                //}
            }
        }

        private void RadCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
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

        private void RadCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
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

        private void UserName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if(UserName.ContainsFocus)
                { 
                using (dbContext db = new dbContext())
                {
                    if (UserName.Text != "")
                    {
                        UserId.Text = UserName.SelectedValue.ToString();
                        int x = int.Parse(UserId.Text);
                        int Getgroid = db.Users.Where(p => p.Id == x).ToList()[0].GroupId;
                        var SysId = db.UserGroups.Where(p => p.Id == Getgroid).ToList()[0].SystemId;
                        //Interaction.MsgBox(x.ToString());
                        var u = (from usr in db.UserPermissions.Where(p => p.UserId == x)
                                 join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                     on usr.FormId equals r.Id
                                 select new
                                 {
                                     Id = usr.Id,
                                     FormId = usr.FormId,
                                     UserId = usr.UserId,
                                     FormEnglishName = r.ArabicFormName
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
                                var v1 = db.UserPermissions.Where(p => p.UserId == x).Select(x1 => x1.FormId).ToArray();
                                var otherObjects =
                                    db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                        .Select(x1 => new { FormId = x1.Id, FormEnglishName = x1.ArabicFormName })
                                        .ToList();

                                GRDForm.DataSource = otherObjects;
                                if (GRDForm.RowCount > 0)
                                {
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
                            else
                            {
                                var usr = db.Users.Where(p => p.Id == x).ToList();
                                int groupdid = usr[0].GroupId;
                                var grp = db.GroupPermissions.Where(p => p.GroupId == groupdid && p.SysForms.SystemsId == SysId).ToList();
                                //  MessageBox.Show(grp.Count.ToString());
                                if (grp.Count > 0)
                                {
                                    for (int i = 0; i <= grp.Count - 1; i++)
                                    {
                                        UserPermission userPermission = new UserPermission();
                                        userPermission.UserId = x;
                                        userPermission.FormId = grp[i].FormId;
                                        db.UserPermissions.Add(userPermission);
                                        db.SaveChanges();
                                    }


                                    var v = (from us in db.UserPermissions.Where(p => p.UserId == x)
                                             join r in db.SysForms.Where(p => p.SystemsId == SysId)
                                                 on us.FormId equals r.Id
                                             select new
                                             {
                                                 Id = us.Id,
                                                 FormId = us.FormId,
                                                 UserId = us.UserId,
                                                 FormEnglishName = r.ArabicFormName
                                             }).ToList();
                                    GrdPermIssions.DataSource = v;
                                    if (v.Count > 0)
                                    {

                                        for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                        {
                                            GrdPermIssions.Rows[i].Cells[0].Value = i + 1;
                                        }
                                        for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
                                        {
                                            GrdPermIssions.Rows[i].Cells["Choose"].Value = false;
                                        }
                                        var v1 =
                                            db.UserPermissions.Where(p => p.UserId == x).Select(x1 => x1.FormId).ToArray();
                                        var otherObjects =
                                            db.SysForms.Where(x1 => x1.SystemsId == SysId && !v1.Contains(x1.Id))
                                                .Select(x1 => new { FormId = x1.Id, FormEnglishName = x1.ArabicFormName })
                                                .ToList();
                                        GRDForm.DataSource = otherObjects;
                                        if (GRDForm.RowCount > 0)
                                        {
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
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
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
        //    using (dbContext db = new dbContext())
        //    {
        //        var cut = db.users.Where(p => p.Id > 0 && p.UserStatus ==1).ToList();
        //        UserName.DataSource = cut;
        //        UserName.DisplayMember = "FullName";
        //        UserName.ValueMember = "Id";
        //        UserName.SelectedIndex = -1;
        //        UserName.Text = "";
        //        UserId.Text = "";
        //        // CustomerStatus.SelectedIndex = 
        //        var v = (from frm in db.SysForms.Where(p => p.Status == Status.Active)
        //            select new
        //            {
        //                FormId = frm.Id,
        //                FormName = frm.FormName,
        //                FormEnglishName = frm.ArabicFormName
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

        //private void radButton3_Click_1(object sender, EventArgs e)
        //{


        //}

        //private void ChkFrom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        //{
        //    if (GRDForm.RowCount > 0)
        //    {
        //        if (ChkFrom.Checked == true)
        //        {
        //            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
        //            {
        //                GRDForm.Rows[i].Cells["choose"].Value = true;
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 0; i <= GRDForm.RowCount - 1; i++)
        //            {
        //                GRDForm.Rows[i].Cells["choose"].Value = false;
        //            }
        //        }
        //    }
        //}

        //private void ChkTo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        //{
        //    if (GrdPermIssions.RowCount > 0)
        //    {
        //        if (ChkFrom.Checked == true)
        //        {
        //            for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
        //            {
        //                GrdPermIssions.Rows[i].Cells["choose"].Value = true;
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 0; i <= GrdPermIssions.RowCount - 1; i++)
        //            {
        //                GrdPermIssions.Rows[i].Cells["choose"].Value = false;
        //            }
        //        }
        //    }
        //}
    }

}


