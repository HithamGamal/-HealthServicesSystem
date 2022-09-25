using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.SystemSetting
{
    public partial class SystemSettingFRM : Telerik.WinControls.UI.RadForm
    {
        public SystemSettingFRM()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static SystemSettingFRM defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static SystemSettingFRM Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new SystemSettingFRM();
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
        private void SystemSettingFRM_Load(object sender, EventArgs e)
        {
            string IP = PLC.GetIP();
            string IP3 = IP.Substring(0, 8);



            ModelDB.dbContext context = new ModelDB.dbContext();

            var itemsLocal = (from m in context.Localities
                              select m).ToList();
            LocalityName.DataSource = itemsLocal;
            LocalityName.ValueMember = "Id";
            LocalityName.DisplayMember = "LocalityName";
            var GetLOcal = context.Localities.Where(x => x.LocalityIP.Equals(IP3)).ToList();
            if (GetLOcal.Count > 0)
            {


                string Local = context.Localities.Where(x => x.LocalityIP.Equals(IP3)).First().LocalityName;
                if (Local.Any())
                {
                    LocalityName.Text = Local;
                }
                else
                {

                    LocalityName.SelectedIndex = -1;
                }
            }
            else
            {
                LocalityName.SelectedIndex = 0;
            }
            try
            {

                if (ConfigurationManager.AppSettings.AllKeys.Contains("Locality"))
                {
                    var MyReader = new System.Configuration.AppSettingsReader();
                    string GetSystemName = MyReader.GetValue("Locality", typeof(string)).ToString();
                    LocalityName.Text = GetSystemName;
                    string GetServerIP = MyReader.GetValue("ServerIP", typeof(string)).ToString();
                    ServerIP.Text = GetServerIP;
                    flag = 2;
                }
                else
                {
                    ServerIP.Text = PLC.GetIP();
                    flag = 1;
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //ConfigurationManager.RefreshSection("appSettings");
            if (ConfigurationManager.AppSettings.AllKeys.Contains("SystemName"))
            {
                var MyReader = new System.Configuration.AppSettingsReader();
                string GetSystemName = MyReader.GetValue("Locality", typeof(string)).ToString();
                Interaction.MsgBox(GetSystemName, MsgBoxStyle.Information, "System");

            }
            if (LocalityName.Text == "")
            {
                Interaction.MsgBox("You have to Choose System Name First!", MsgBoxStyle.Exclamation, "System");
                LocalityName.Focus();
                return;

            }
            if (ServerIP.Text == "")
            {
                Interaction.MsgBox("يجب اختيار المحلية اولاً", MsgBoxStyle.Exclamation, "System");
                ServerIP.Focus();
                return;

            }
            if (flag == 1)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                if (!config.AppSettings.Settings.AllKeys.Contains("ServerIP"))
                {
                    config.AppSettings.Settings.Add("ServerIP", ServerIP.Text);
                }


                //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.AppSettings.Settings.Remove("ServerIP");        
                //config.AppSettings.Settings.Remove("SystemName");
                int LocalityId = Convert.ToInt32(LocalityName.SelectedValue);
                config.AppSettings.Settings.Add("Locality", LocalityId.ToString());
                config.Save();

                ConfigurationManager.RefreshSection("appSettings");
                SystemSettingFRM.Default.Show();
                this.Hide();
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("ServerIP");
                config.AppSettings.Settings.Add("ServerIP", ServerIP.Text);
                config.AppSettings.Settings.Remove("Locality");
                int LocalityId = Convert.ToInt32(LocalityName.SelectedValue);
                config.AppSettings.Settings.Add("Locality", LocalityId.ToString());
                config.Save();

                ConfigurationManager.RefreshSection("appSettings");
                SystemSettingFRM.Default.Show();
                this.Hide();
                //Interaction.MsgBox(config.AppSettings.Settings["SystemName"].Value);
            }
            //  InstallFonts(Application.StartupPath + "\\Resources\\majallab.ttf", "majallab");
            // timer1.Enabled = true;
            //Application.Restart();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{


        //}

        //private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //       (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void Timer1_Tick(object sender, EventArgs e)
        //{
        //    Application.Restart();
        //}
    }
}

