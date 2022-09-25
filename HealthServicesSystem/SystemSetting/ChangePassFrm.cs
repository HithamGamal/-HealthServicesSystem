using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.SystemSetting
{
    public partial class ChangePassFrm : Telerik.WinControls.UI.RadForm
    {
        public ChangePassFrm()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static ChangePassFrm defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static ChangePassFrm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ChangePassFrm();
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

        //private void Updatebtn_Click(object sender, EventArgs e)
        //{
        //    if (oldpasstxt.Text.Length == 0)
        //    {
        //        MessageBox.Show("يجب كتابة الرمز القديم", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        oldpasstxt.Focus();
        //        return;

        //    }
        //    if (newpasstxt.Text.Length == 0)
        //    {
        //        MessageBox.Show("يجب كتابة الرمز الجديد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        newpasstxt.Focus();
        //        return;

        //    }
        //    if (RePassword.Text.Length == 0)
        //    {
        //        MessageBox.Show("يجب اعادة كتابة الرمز الجديد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        RePassword.Focus();
        //        return;

        //    }
        //    if (RePassword.Text != newpasstxt.Text)
        //    {
        //        MessageBox.Show("اعادة كتابة الرمز الجديد لا تساوي الرمز الجديد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        newpasstxt.Clear();
        //        newpasstxt.Focus();
        //        RePassword.Clear();
        //        return;

        //    }
        //    int user = LoginForm.Default.UserId;
        //    using (dbContext db = new dbContext())
        //    {
        //        var u = db.users.Where(p => p.Id == user).ToList();
        //        if (u.Count > 0)
        //        {
        //            if (oldpasstxt.Text == u[0].UserPass)
        //            {
        //                //cmd.Edit(u);
        //                u[0].UserPass = newpasstxt.Text;
        //                u[0].UserStatus = 1;
        //                if (db.SaveChanges() > 0)
        //                {
        //                    db.SaveChanges();
        //                    RadMessageBox.Show("تم تحديث رمز المرور");
        //                    oldpasstxt.Text = string.Empty;
        //                    newpasstxt.Text = string.Empty;
        //                    RePassword.Text = string.Empty;
        //                    Application.Restart();
        //                }
        //                else
        //                {
        //                    RadMessageBox.Show("لم يتم تحديث رمز المرور");
        //                }
        //            }

        //            else
        //            {
        //                RadMessageBox.Show("خطأ في رمز المرور القديم");
        //                oldpasstxt.Clear();
        //                oldpasstxt.Focus();
        //            }
        //        }

        //    }

        //}

        //private void ChangePassFrm_Load(object sender, EventArgs e)
        //{

        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //    usernamelbl.Text = LoginForm.Default.Username;

        //}

        //private void oldpasstxt_TextChanged(object sender, EventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //}

        //private void newpasstxt_TextChanged(object sender, EventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //}

        //private void RePassword_TextChanged(object sender, EventArgs e)
        //{
        //    MainMenuFrm.Default.timer1.Stop();
        //    MainMenuFrm.Default.timer1.Start();
        //}
    }
}
