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
    public partial class UserFRM : Telerik.WinControls.UI.RadForm
    {
        public UserFRM()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static UserFRM defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static UserFRM Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UserFRM();
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
        public int flag = 0;
        private void RadButton3_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                UserGroupFRM.Default.flag = 1;
                //UserGroupFRM.Default.EditMode.Text = "Edit Mode : Add New";

                UserGroupFRM.Default.ShowDialog();
            }
        }

        private void UserFRM_Load(object sender, EventArgs e)
        {
            UserType.DataSource = Enum.GetValues(typeof(UserType));
            UserType.SelectedIndex = 1;
            StartDate.Value = PLC.getdate();
            EndDate.Value = PLC.getdate().AddMonths(3);
            using (dbContext db = new dbContext())
            {
                flag = 1;
                var grp = db.UserGroups.ToList();
                UserGroup.DataSource = grp;
                UserGroup.DisplayMember = "GroupName";
                UserGroup.ValueMember = "Id";
                UserGroup.SelectedIndex = -1;
                var Loc = db.Localities.ToList();
                Locality.DataSource = Loc;
                Locality.DisplayMember = "LocalityName";
                Locality.ValueMember = "Id";
                Locality.SelectedIndex = -1;
                // MessageBox.Show(UserGroup.Items.Count.ToString());
                UserStatus.Checked = true;
                var u = (from us in db.Users
                         join gp in db.UserGroups on us.GroupId equals gp.Id
                         // where us.RowStatus ==RowStatus.Active
                         select new
                         {
                             UserId = us.Id,
                             FulName = us.FullName,
                             UserName = us.UserName,
                             UserPassWord = us.UserPass,
                             UserGroup = gp.GroupName,
                             RowStatus = us.UserStatus
                         }).OrderBy(p => p.UserId).ToList();
                GRDUsers.DataSource = u;
                if (u.Count > 0)
                {

                    for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                    {
                        GRDUsers.Rows[i].Cells[0].Value =
                            i + 1;


                    }

                }
            }
        }

        private void RadButton4_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())

            {

                if (GroupId.Text == "")
                {
                    Interaction.MsgBox("يجب اختيار المجموعة أولا", MsgBoxStyle.Exclamation, "System");
                    UserGroup.Focus();
                    return;
                }
                if (UserType.Text == "")
                {
                    Interaction.MsgBox("يجب اختيار نوع المستخدم", MsgBoxStyle.Exclamation, "System");
                    UserType.Focus();
                    return;
                }
                //if (UserName.Text == "")
                //{
                //    Interaction.MsgBox("يجب ادخال اسم المستخدم", MsgBoxStyle.Exclamation, "System");
                //    UserName.Focus();
                //    return;
                //}
                if (UserPassWord.Text == "")
                {
                    Interaction.MsgBox("يجب ادخال رمز المرور", MsgBoxStyle.Exclamation, "System");
                    UserPassWord.Focus();
                    return;
                }
                if (UserPassWord.TextLength < 3)
                {
                    Interaction.MsgBox("رمز المرور يجب أن يحتوي على الأقل على 3 رموز", MsgBoxStyle.Exclamation,
                        "System");
                    UserPassWord.Clear();
                    UserPassWord.Focus();
                    return;
                }
                {
                    if (FulName.Text == "")
                    {
                        Interaction.MsgBox("يجب ادخال الاسم الرباعي كاملا", MsgBoxStyle.Exclamation, "System");
                        FulName.Focus();
                        return;
                    }
                    if (RePassWord.Text == "")
                    {
                        Interaction.MsgBox("يجب تكرار رمز المرور", MsgBoxStyle.Exclamation, "System");
                        RePassWord.Focus();
                        return;
                    }
                    if (UserPassWord.Text != RePassWord.Text)
                    {
                        Interaction.MsgBox("رمز المرور لا يساوي رمز المرور المكرر", MsgBoxStyle.Exclamation, "System");
                        UserPassWord.Clear();
                        RePassWord.Clear();
                        UserPassWord.Focus();
                        return;
                    }
                    if (flag == 1)
                    {

                        //var u = db.users.Where(p => p.UserName == UserName.Text).ToList();
                        //if (u.Count > 0)
                        //{
                        //    Interaction.MsgBox("لا يمكن تكرار اسم المستخدم", MsgBoxStyle.Exclamation,
                        //        "System");
                        //    UserName.Text = "";
                        //    UserName.Focus();
                        //    return;
                        //}
                        var FUsers = db.Users.ToList();
                        int UsId = 1;
                        if (FUsers.Count > 0)
                        {

                            UsId= db.Users.Max(o => o.Id) + 1;
                        }
                        User user = new User();
                        user.Id = UsId;
                        user.UserName = (db.Users.Max(p => p.Id) + 1).ToString();
                        user.FullName = FulName.Text;
                        user.GroupId = int.Parse(GroupId.Text);
                        user.UserPass = UserPassWord.Text;
                        user.UserType = (UserType)Enum.Parse(typeof(UserType), UserType.Text); 
                        if (UserStatus.Checked == true)
                        {
                            user.UserStatus = 1;
                        }
                        else
                        {
                            user.UserStatus = 0;
                        }
                        user.StartDate = StartDate.Value.Date;
                        user.LocalityId = Convert.ToInt32(Locality.SelectedValue.ToString());
                        user.EndDate = EndDate.Value.Date;
                        db.Users.Add(user);
                        db.SaveChanges();
                        int Mid = db.Users.Max(p => p.Id);
                        var Fusr = db.Users.Where(p => p.Id == Mid).ToList();
                        if (Fusr.Count > 0)
                        {
                            Fusr[0].UserName = Fusr[0].Id.ToString();
                            db.SaveChanges();
                        }
                        FulName.Text = "";
                        GroupId.Text = "";
                        RePassWord.Text = "";
                        UserGroup.Text = "";
                        UserId.Text = "";
                        UserPassWord.Text = "";
                        UserGroup.SelectedIndex = -1;
                        StartDate.Value = PLC.getdate();
                        EndDate.Value = PLC.getdate().AddMonths(3); ;
                        //AddUserFRM.Default.OperationType.SelectedIndex = -1;
                        UserName.Text = "";
                        var v = (from us in db.Users
                                 join gp in db.UserGroups on us.GroupId equals gp.Id
                                 // where us.RowStatus ==RowStatus.Active
                                 select new
                                 {
                                     UserId = us.Id,
                                     FulName = us.FullName,
                                     UserName = us.UserName,
                                     UserPassWord = us.UserPass,
                                     UserGroup = gp.GroupName,
                                     Status = us.UserStatus,
                                     StartDate = us.StartDate,
                                     EndDate = us.EndDate
                                 }).OrderBy(p => p.UserGroup).ToList();
                        GRDUsers.DataSource = v;
                        if (v.Count > 0)
                        {


                            for (int i = 0; i <= v.Count - 1; i++)
                            {
                                if (v[i].Status == 1)
                                {
                                    GRDUsers.Rows[i].Cells["UserStatus"].Value = true;
                                }
                                else
                                {
                                    GRDUsers.Rows[i].Cells["UserStatus"].Value = false;
                                }
                            }
                            for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                            {
                                GRDUsers.Rows[i].Cells[0].Value =
                                    i + 1;


                            }
                            var mu = db.Users.Max(p => p.Id);
                            UserId.Text = Convert.ToString(mu);
                            int x = int.Parse(UserId.Text);
                            for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                            {
                                if ((int)GRDUsers.Rows[i].Cells[1].Value == x)
                                {
                                    GRDUsers.Rows[i].IsCurrent = true;
                                    GRDUsers.Rows[i].IsSelected = true;

                                }

                            }



                            // Interaction .MsgBox( "User Has Been Saved",MsgBoxStyle.Information ,"System");
                            flag = 1;

                        }
                    }
                    else
                    {
                        if (flag == 2)
                        {
                            int x1 = int.Parse(UserId.Text);
                            var v2 = db.Users.Where(p => p.Id == x1).ToList();
                            //  MessageBox.Show(x1.ToString());
                            if (v2.Count > 0)
                            {
                                // v2[0].UserName = UserName.Text;
                                v2[0].FullName = FulName.Text;
                                v2[0].GroupId = int.Parse(GroupId.Text);
                                v2[0].UserPass = UserPassWord.Text;
                                v2[0].StartDate = StartDate.Value.Date;
                                v2[0].EndDate = EndDate.Value.Date;
                                v2[0].LocalityId = Convert.ToInt32(Locality.SelectedValue.ToString());
                                v2[0].UserType = (UserType)Enum.Parse(typeof(UserType), UserType.Text);
                                if (UserStatus.Checked == true)
                                {
                                    v2[0].UserStatus = 1;
                                }
                                else
                                {
                                    v2[0].UserStatus = 0;
                                }

                                db.SaveChanges();
                                FulName.Text = "";
                                GroupId.Text = "";
                                RePassWord.Text = "";
                                UserGroup.Text = "";
                                UserId.Text = "";
                                UserPassWord.Text = "";
                                UserGroup.SelectedIndex = -1;
                                //AddUserFRM.Default.OperationType.SelectedIndex = -1;
                                UserName.Text = "";
                                var v1 = (from us in db.Users
                                          join gp in db.UserGroups on us.GroupId equals gp.Id
                                          // where us.RowStatus ==RowStatus.Active
                                          select new
                                          {
                                              UserId = us.Id,
                                              FulName = us.FullName,
                                              UserName = us.UserName,
                                              UserPassWord = us.UserPass,
                                              UserGroup = gp.GroupName,
                                              Status = us.UserStatus,
                                              StartDate = us.StartDate,
                                              EndDate = us.EndDate
                                          }).OrderBy(p => p.UserId).ToList();
                                GRDUsers.DataSource = v1;
                                if (v1.Count > 0)
                                {
                                    for (int i = 0; i <= v1.Count - 1; i++)
                                    {
                                        if (v1[i].Status == 1)
                                        {
                                            GRDUsers.Rows[i].Cells["UserStatus"].Value = true;
                                        }
                                        else
                                        {
                                            GRDUsers.Rows[i].Cells["UserStatus"].Value = false;
                                        }
                                    }
                                    for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                                    {
                                        GRDUsers.Rows[i].Cells[0].Value =
                                            i + 1;


                                    }



                                    //int x = int.Parse(UserId.Text);
                                    for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                                    {
                                        if ((int)(GRDUsers.Rows[i].Cells[1].Value) == x1)
                                        {
                                            GRDUsers.Rows[i].IsCurrent = true;
                                            GRDUsers.Rows[i].IsSelected = true;

                                        }

                                    }
                                }


                            }
                            flag = 1;

                        }
                    }

                }
            }
        }

        private void GRDUsers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                if (GRDUsers.RowCount > 0)
                {

                    //Interaction.MsgBox(x.ToString());
                    switch (GRDUsers.CurrentColumn.Name)
                    {
                        case "Edit":
                            //Interaction.MsgBox(GRDUsers.Rows[GRDUsers.CurrentRow.Index].Cells[1].Value);
                            int x = Convert.ToInt32(e.Row.Cells["UserId"].Value.ToString());
                            var usr = db.Users.Where(p => p.Id == x).Select(us =>
                                          new
                                          {
                                              UserId = us.Id,
                                              LocalityId = us.LocalityId,
                                              FulName = us.FullName,
                                              UserName = us.UserName,
                                              UserPassWord = us.UserPass,
                                              UserGroup = us.UserGroup.GroupName,
                                              groupId = us.GroupId,
                                              Status = us.UserStatus,
                                              StartDate = us.StartDate,
                                              EndDate = us.EndDate
                                          }).OrderBy(p => p.UserId).ToList();
                            if (usr.Count > 0)
                            {
                                var cu = db.Users.ToList();
                                UserName.DataSource = cu;
                                UserName.DisplayMember = "UserName";
                                UserName.ValueMember = "Id";
                                UserName.SelectedIndex = -1;
                                var cut =
                                    db.UserGroups.ToList();
                                UserGroup.DataSource = cut;
                                UserGroup.DisplayMember = "GroupName";
                                UserGroup.ValueMember = "Id";
                                UserGroup.SelectedIndex = -1;
                                if (usr[0].Status == 1)
                                {
                                    UserStatus.Checked = true;
                                }
                                else
                                {
                                    UserStatus.Checked = false;
                                }
                                // EditMode.Text = "  Edit Mode : Edit";

                                FulName.Text = usr[0].FulName;
                                GroupId.Text = usr[0].groupId.ToString();
                                RePassWord.Text = usr[0].UserPassWord;
                                UserGroup.Text = usr[0].UserGroup;
                                UserId.Text = usr[0].UserId.ToString();
                                UsId.Text = usr[0].UserId.ToString();
                                Locality.SelectedValue = usr[0].LocalityId;
                                UserPassWord.Text = usr[0].UserPassWord;
                                //AddUserFRM.Default.OperationType.SelectedIndex = -1;
                                UserName.Text = usr[0].UserName;
                                if (usr[0].StartDate != null)
                                {
                                    StartDate.Value = usr[0].StartDate.Value;
                                }
                                if (usr[0].EndDate != null)
                                {
                                    EndDate.Value = usr[0].EndDate.Value;
                                }
                                flag = 2;


                            }




                            break;
                        case "Delete":
                            {
                                if (GRDUsers.RowCount > 0)
                                {
                                    int SId = Convert.ToInt32(e.Row.Cells["UserId"].Value.ToString());
                                    MsgBoxResult msg;
                                    msg = Interaction.MsgBox("سيتم ايقاف هذا المستخدم",
                                        (int)MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "System");
                                    if (msg == MsgBoxResult.Yes)
                                    {
                                        var u = db.Users.Where(p => p.Id == SId).ToList();
                                        if (u.Count > 0)
                                        {
                                            u[0].UserStatus = 0;
                                            db.SaveChanges();
                                        }

                                        GRDUsers.Rows[GRDUsers.CurrentRow.Index].Cells["UserStatus"].Value = false;

                                    }
                                }

                            }
                            break;
                    }
                }
            }
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (UserGroup.ContainsFocus)
            {
                //try
                // {
                if (UserGroup.SelectedValue.ToString() != null)
                {
                    using (dbContext db = new dbContext())
                    {
                        GroupId.Text = UserGroup.SelectedValue.ToString();
                        int gpid = Convert.ToInt32(GroupId.Text);
                        var u = db.Users.Where(p => p.GroupId == gpid).Select(us => new
                        {
                            userid = us.Id,
                            fulname = us.FullName,
                            username = us.UserName,
                            userpassword = us.UserPass,
                            // usergroup = gp.groupname,
                            rowstatus = us.UserStatus,
                            startdate = us.StartDate,
                            enddate = us.EndDate

                        }).OrderBy(p => p.userid).ToList();
                        GRDUsers.DataSource = u;
                        if (u.Count > 0)
                        {
                            for (int i = 0; i <= u.Count - 1; i++)
                            {
                                if (u[i].rowstatus == 1)
                                {
                                    GRDUsers.Rows[i].Cells["userstatus"].Value = true;
                                }
                                else
                                {
                                    GRDUsers.Rows[i].Cells["userstatus"].Value = false;
                                }
                            }
                            for (int i = 0; i <= GRDUsers.RowCount - 1; i++)
                            {
                                GRDUsers.Rows[i].Cells[0].Value =
                                    i + 1;


                            }
                        }
                    }
                }
                else
                {
                    GroupId.Text = "0";
                }
                //}
                //catch (exception)
                //{
                //    return;
                //}

            }
        }
        // private void MainSaleFRM_Load(object sender, EventArgs e)
        // {


        // }





        // private void GRDSales_CommandCellClick(object sender, GridViewCellEventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();

        // }

        // private void radButton4_Click(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        ////     MessageBox.Show(flag.ToString());

        // }

        // private void radButton3_Click(object sender, EventArgs e)
        // {
        //     using (dbContext db = new dbContext())
        //     {
        //         UserGroupFRM.Default.flag = 1;
        //         //UserGroupFRM.Default.EditMode.Text = "Edit Mode : Add New";

        //         UserGroupFRM.Default.ShowDialog();
        //     }
        // }

        // private void UserGroup_SelectedIndexChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();

        // }

        // private void radButton1_Click(object sender, EventArgs e)
        // {
        //     Close();
        // }

        // private void UsId_TextChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void FulName_TextChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void UserName_SelectedIndexChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void UserPassWord_TextChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void RePassWord_TextChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void StartDate_ValueChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void EndDate_ValueChanged(object sender, EventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }

        // private void UserFRM_MouseMove(object sender, MouseEventArgs e)
        // {
        //     MainMenuFrm.Default.timer1.Stop();
        //     MainMenuFrm.Default.timer1.Start();
        // }
    }
}
