using Microsoft.VisualBasic;
using Microsoft.Win32;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.SystemSetting
{
    public partial class LoginForm : Telerik.WinControls.UI.RadForm
    {
        public LoginForm()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static LoginForm defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static LoginForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new LoginForm();
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
        public int UserId = 0;
        //public string Username = "";
        //public int counter = 0;
        public int LocalityId = 0;
        public string FulName;
        private void LoginBTN_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                Interaction.MsgBox("يجب ادخال اسم المستخدم", MsgBoxStyle.Exclamation, "System");
                UserName.Focus();
                return;
            }
            if (UserPassWord.Text == "")
            {
                Interaction.MsgBox("يجب ادخال رمز المرور", MsgBoxStyle.Exclamation, "System");
                UserPassWord.Focus();
                return;
            }

            //try
            //{
            //  var stId = db.Stocks.ToList();
            // StockId = stId[0].Id;

            // Interaction.MsgBox(ShiftId.ToString());
            if (UserName.Text != "Admin")

            {
                // PLC.();
                int counter = 0;
                using (dbContext db = new dbContext())
                {
                    var chk =
                        db.Users.Where(p => p.UserName == UserName.Text && p.UserPass == UserPassWord.Text && p.UserStatus == 1).ToList();
                    if (chk.Count > 0)
                    {
                        if (Convert.IsDBNull(chk[0].LocalityId) == false)
                        {
                            PLC.LocalityId = Convert.ToInt32(chk[0].LocalityId);
                        }
                        else
                        {
                            PLC.LocalityId = 0;
                        }
                        UserId = chk[0].Id;
                        FulName = chk[0].FullName;
                        // CheckLogin();
                        //  MessageBox.Show(UserId.ToString());
                        MainMenuForm mfr = new MainMenuForm();

                        Hide();
                        mfr.Show();
                        // StockId = int.Parse(Stock.SelectedValue.ToString());

                    }
                    else
                    {

                        Interaction.MsgBox("خطأ في اسم المستخدم أو رمز المرور", MsgBoxStyle.Critical, "System");
                        counter += 1;
                        if (counter == 4)
                        {
                            Application.Exit();
                        }
                    }
                }
            }


            else if (UserName.Text == "Admin" && UserPassWord.Text == "Admin123$")
            {
                //   PLC.GetMAC();

                MainMenuForm mfr = new MainMenuForm();
                PLC.LocalityId = 0;
                UserId = 0;
                FulName = UserName.Text;
                Hide();
                mfr.Show();



            }


            //if(q == true)
            //{
            //    RadMessageBox.Show("X");
            //}
            //}
            //catch (Exception ex)
            //{

            //    Interaction.MsgBox("There is an error :" + (char)13 + ex.Message, MsgBoxStyle.Critical, "System");
            //    return;
            //}
        }


        public string ServerIp = "";
        public string SystemName = "";
        public string ConnectionString = "";
        public string ConnectionString1 = "";
        public int StockId = 0;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var GetInfo = db.CompanySettings.FirstOrDefault();
                Byte[] MyData = new byte[0];
                MyData = (Byte[])GetInfo.LogoPath1;
                MemoryStream stream = new MemoryStream(MyData);
                stream.Position = 0;
                CompanyImage.BackgroundImage = Image.FromStream(stream);

                Byte[] MyData1 = new byte[0];
                MyData1 = (Byte[])GetInfo.LogoPath2;
                MemoryStream stream1 = new MemoryStream(MyData1);
                stream1.Position = 0;
                QualityImage.BackgroundImage = Image.FromStream(stream1);
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    PublishVersion.Text = string.Format(" اصدار- v{0} ",
                                     ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision.ToString());
                }
                RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
                rkey.SetValue("sShortDate", "yyyy/MM/dd");
                rkey.SetValue("sLongDate", "yyyy/MM/dd");
                rkey.SetValue("s1159", "am");
                rkey.SetValue("s2359", "pm");
                rkey.SetValue("slanguage", "ENU");
                rkey.SetValue("Locale", "00000401");
                rkey.SetValue("LocaleName", "en-US");
                rkey.SetValue("iCalendarType", "2");
                rkey.SetValue("iDate", "0");

                if (rkey.SubKeyCount > 4)
                {
                    RegistryKey rkey1 = Registry.CurrentUser.OpenSubKey(@"Control Panel\International\🌎🌏🌍", true);
                    if (rkey1 != null)
                    {
                        Registry.CurrentUser.DeleteSubKey(@"Control Panel\International\🌎🌏🌍");
                    }
                }
                rkey.Flush();
                rkey.Close();
                Registry.CurrentUser.Flush();
                var culture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                Ping p = new Ping();
                PingReply r;
                string s = db.Database.Connection.DataSource;
                if (s != ".")
                {
                    r = p.Send(s);

                    if (r.Status != IPStatus.Success)
                    {
                        MessageBox.Show("لايمكن الوصول الى مخدم البيانات" + (char)13 + "الرجاء التأكد من اعدادات الشبكة", "ادارة النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("Locality"))
                {

                    var MyReader = new System.Configuration.AppSettingsReader();
                    string GetSystemName = MyReader.GetValue("Locality", typeof(string)).ToString();
                    string GetServerIp = MyReader.GetValue("ServerIp", typeof(string)).ToString();
                    ServerIp = GetServerIp;

                }

                else
                {
                    SystemSettingFRM.Default.ShowDialog();
                    Hide();
                    return;
                }
                //string IP = PLC.GetIP();
                //string IP3 = IP.Substring(0, 8);
                //int getLoc = db.Localities.Where(x => x.LocalityIP.Contains(IP3)).First().Id;
                //PLC.LocalityId= getLoc;
                //LocalityId = getLoc;
                // MessageBox.Show(LocalityId.ToString());
                DateTime NowDate = PLC.getdate();

                var ChkExpire = db.Users.Where(u => u.EndDate < NowDate && u.UserStatus == 1).ToList();
                if (ChkExpire.Count > 0)
                {
                    for (int i = 0; i <= ChkExpire.Count - 1; i++)
                    {
                        ChkExpire[i].UserStatus = 0;
                        db.SaveChanges();
                    }
                }
                try
                {
                    DateTime date2 = PLC.getdate().Date;
                    var chk = db.ChkUpdates.Where(o => o.UpdateDate == date2).ToList();
                    if (chk.Count == 0)
                    {
                        Cursor = Cursors.WaitCursor;


                        if (PLC.conClame.State == (System.Data.ConnectionState)1)
                        {
                            PLC.conClame.Close();
                        }
                        PLC.conClame.Open();
                        SqlDataAdapter daCenter = new SqlDataAdapter("SELECT   [center_id],[center_name],[locals],[center_level] ,[madic] ,[dawa] FROM [cntr].[dbo].[CENTER_DET] ", PLC.conClame);
                        DataTable dtCenter = new DataTable();
                        dtCenter.Clear();
                        daCenter.Fill(dtCenter);
                        //   MsgBox (dtCenter .Rows .Count)
                        if (dtCenter.Rows.Count > 0)
                        {
                            for (var i = 0; i < dtCenter.Rows.Count; i++)
                            {
                                int aa = 0;
                                aa = Convert.ToInt32(dtCenter.Rows[i]["center_id"]);
                                var chkc = db.CenterInfos.Where(o => o.Id == aa).ToList();
                                if (chkc.Count == 0)
                                {
                                    CenterInfo excc = new CenterInfo();


                                    excc.Id = aa;


                                    excc.CenterName = (dtCenter.Rows[i]["center_name"]).ToString().Trim();
                                    if (Convert.IsDBNull(dtCenter.Rows[i]["locals"]) != true)
                                    {
                                        if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 2)
                                        {
                                            excc.LocalityId = 3;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 4)
                                        {
                                            excc.LocalityId = 4;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 3)
                                        {
                                            excc.LocalityId = 2;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 5)
                                        {
                                            excc.LocalityId = 125;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 6)
                                        {
                                            excc.LocalityId = 5;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 7)
                                        {
                                            excc.LocalityId = 124;
                                        }
                                        else if (Convert.ToInt32(dtCenter.Rows[i]["locals"]) == 1)
                                        {
                                            excc.LocalityId = 1;
                                        }

                                    }
                                    else
                                    {
                                        excc.LocalityId = 1;
                                    }

                                    if (Convert.ToBoolean(dtCenter.Rows[i]["dawa"].ToString()) == true && Convert.ToBoolean(dtCenter.Rows[i]["madic"].ToString()) == false)
                                    {
                                        excc.CenterTypeId = CenterType.صيدلية;
                                    }

                                    else if (Convert.ToBoolean(dtCenter.Rows[i]["dawa"].ToString()) == true && Convert.ToBoolean(dtCenter.Rows[i]["madic"].ToString()) == true)
                                    {
                                        excc.CenterTypeId = CenterType.مركزوصيدلية;
                                    }
                                    else if (Convert.ToBoolean(dtCenter.Rows[i]["dawa"].ToString()) == false && Convert.ToBoolean(dtCenter.Rows[i]["madic"].ToString()) == true)
                                    {
                                        excc.CenterTypeId = CenterType.مركز;

                                    }

                                    else
                                    {
                                        excc.CenterTypeId = CenterType.None;
                                    }
                                    excc.Level1 = false;
                                    excc.Level2 = false;
                                    excc.Level3 = false;
                                    excc.Level4 = false;
                                    excc.HasContract = false;
                                    excc.IsEnabled = false;
                                    excc.IsVisible = true;
                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 1)
                                    {
                                        excc.Level1 = true;
                                    }




                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 2)
                                    {
                                        excc.Level2 = true;
                                    }




                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 3)
                                    {
                                        excc.Level3 = true;
                                    }

                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 4)
                                    {
                                        excc.Level1 = true;
                                        excc.Level2 = true;
                                    }
                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 5)
                                    {
                                        excc.Level2 = true;
                                        excc.Level3 = true;
                                    }
                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 6)
                                    {
                                        excc.Level1 = true;
                                        excc.Level2 = true;
                                        excc.Level3 = true;
                                    }

                                    if (Convert.ToInt32(dtCenter.Rows[i]["center_level"]) == 7)
                                    {
                                        excc.Level4 = true;
                                    }


                                    excc.HasContract = true;
                                    excc.IsEnabled = true;


                                    db.CenterInfos.Add(excc);
                                    db.SaveChanges();


                                }

                                db.SaveChanges();
                            }


                        }
                        ChkUpdate chk1 = new ChkUpdate();
                        chk1.Updated = true;
                        chk1.UpdateDate = PLC.getdate();
                        db.ChkUpdates.Add(chk1);
                        db.SaveChanges();
                    }


                }
                catch (Exception ex)
                {

                    return;

                    this.Cursor = Cursors.Default;
                }
                UserName.Focus();
                this.Cursor = Cursors.Default;
            }
        }

        private void LogoutBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QualityImage1_Click(object sender, EventArgs e)
        {

        }
        //#region Default Instance

        //private static LoginForm defaultInstance;

        ///// <summary>
        ///// Added by the VB.Net to C# Converter to support default instance behavour in C#
        ///// </summary>
        //public static LoginForm Default
        //{
        //    get
        //    {
        //        if (defaultInstance == null)
        //        {
        //            defaultInstance = new LoginForm();
        //            defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
        //        }

        //        return defaultInstance;
        //    }
        //    set { defaultInstance = value; }
        //}

        //static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    defaultInstance = null;
        //}

        //#endregion


        //private void LoginBTN_Click(object sender, EventArgs e)
        //{
        //    if (UserName.Text == "")
        //    {
        //        Interaction.MsgBox("يجب ادخال اسم المستخدم", MsgBoxStyle.Exclamation, "System");
        //        UserName.Focus();
        //        return;
        //    }
        //    if (UserPassWord.Text == "")
        //    {
        //        Interaction.MsgBox("يجب ادخال رمز المرور", MsgBoxStyle.Exclamation, "System");
        //        UserPassWord.Focus();
        //        return;
        //    }

        //    //try
        //    //{
        //    //  var stId = db.Stocks.ToList();
        //    // StockId = stId[0].Id;

        //    // Interaction.MsgBox(ShiftId.ToString());
        //    if (UserName.Text != "Admin")

        //    {
        //        PLC.GetMAC();
        //        using (dbContext db = new dbContext())
        //        {
        //            var chk =
        //                db.users.Where(p => p.UserName == UserName.Text && p.UserPass == UserPassWord.Text && p.UserStatus==1).ToList();
        //            if (chk.Count > 0)
        //            {


        //                UserId = chk[0].Id;
        //                Username = chk[0].FullName;
        //                // CheckLogin();
        //                //  MessageBox.Show(UserId.ToString());
        //                MainMenuFrm mfr = new MainMenuFrm();

        //                Hide();
        //                mfr.Show();
        //                // StockId = int.Parse(Stock.SelectedValue.ToString());

        //            }
        //            else
        //            {
        //                Interaction.MsgBox("خطأ في اسم المستخدم أو رمز المرور", MsgBoxStyle.Critical, "System");
        //                counter += 1;
        //                if (counter == 4)
        //                {
        //                    Application.Exit();
        //                }
        //            }
        //        }
        //    }


        //    else if (UserName.Text == "Admin" && UserPassWord.Text == "Admin123$")
        //    {
        //        PLC.GetMAC();

        //        MainMenuFrm mfr = new MainMenuFrm();
        //        UserId = 0;
        //        Username = UserName.Text;
        //        Hide();
        //        mfr.Show();



        //    }


        //    //if(q == true)
        //    //{
        //    //    RadMessageBox.Show("X");
        //    //}
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    Interaction.MsgBox("There is an error :" + (char)13 + ex.Message, MsgBoxStyle.Critical, "System");
        //    //    return;
        //    //}
        //}

        //public void CheckLogin()
        //{
        //    var q = db.logs.Where(x => x.UserId == UserId
        //        && x.Date == DateTime.Today.Date)
        //        .Select(x => new
        //        {
        //            x.Id,
        //            x.MACAddress,
        //            x.logStatus
        //        });

        //    if (q.Count() > 0)
        //    {
        //        int x = q.Select(u => u.Id).Max();
        //        var i = q.Where(p => p.Id == x).Select(o => new
        //        {
        //            o.logStatus,
        //            o.MACAddress
        //        }).First();

        //        if (i.MACAddress == PLC.staticClass.MACAddress &&
        //            i.logStatus == true)
        //        {
        //            MainMenuFrm mfr = new MainMenuFrm();
        //            Hide();
        //            mfr.Show();
        //        }
        //        else if (i.MACAddress != PLC.staticClass.MACAddress
        //            && i.logStatus == true)
        //        {
        //            RadMessageBox.Show("المستخدم " + UserName.Text + "دخل الى النظام من جهاز آخر" + " " + "ورقم الجهاز هو :" + PLC.staticClass.MACAddress + (char)13 + "ولا يمكنه الدخول من هذا الجهاز", "النظام", MessageBoxButtons.OK, RadMessageIcon.Error);
        //            return;
        //        }
        //        else if (i.MACAddress != PLC.staticClass.MACAddress
        //         && i.logStatus == false)
        //        {
        //            using (dbContext db = new dbContext())
        //            {
        //                Log log = new Log();
        //                var id = db.logs.DefaultIfEmpty()
        //                    .Max(m => m == null ? 0 : m.Id);
        //                log.Id = id + 1;
        //                log.UserId = UserId;
        //                log.MACAddress = PLC.staticClass.MACAddress;
        //                log.Date = DateTime.Today.Date;
        //                log.logStatus = true;

        //                db.logs.Add(log);
        //                db.SaveChanges();

        //            }
        //        }
        //    }

        //    else
        //    {
        //        using (dbContext db = new dbContext())
        //        {
        //            Log log = new Log();
        //            var id = db.logs.DefaultIfEmpty()
        //                .Max(x => x == null ? 0 : x.Id);
        //            log.Id = id + 1;
        //            log.UserId = UserId;
        //            log.MACAddress = PLC.staticClass.MACAddress;
        //            log.Date = DateTime.Today.Date;
        //            log.logStatus = true;

        //            db.logs.Add(log);
        //            db.SaveChanges();

        //        }
        //    }
        //}

        //private void LogoutBTN_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void UserPassWord_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {

        //        LoginBTN_Click(sender, e);

        //    }
        //}

        //private void RadGroupBox1_Click(object sender, EventArgs e)
        //{

        //}
    }
}


