using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Committee
{
    public partial class ExceptionReason : Telerik.WinControls.UI.RadForm
    {
        public string x = "";
        public string c = "";
        public ExceptionReason()
        {
            InitializeComponent();
        }

        private void ApproveBTN_Click(object sender, EventArgs e)
        {
            if (ExecptionReason.Text =="" || CoInsuranceType.Text == ""|| ExecptionCost.Text == "")
            {
                RadMessageBox.Show("الرجاء اكمال البيانات !");
            }
            x = ExecptionReason.Text;
            c = CoInsuranceType.Text;
            this.Hide();
        }

        private void ExceptionReason_Load(object sender, EventArgs e)
        {
            ExecptionReason.SelectedIndex = -1;
         
        }
    }
}
