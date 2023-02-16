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
        public ExceptionReason()
        {
            InitializeComponent();
        }

        private void ApproveBTN_Click(object sender, EventArgs e)
        {
            if (ExecptionReason.SelectedText =="" || CoInsuranceType.SelectedText == ""|| ExecptionCost.Text == "")
            {
                RadMessageBox.Show("الرجاء اكمال البيانات !");
            }


        }

        private void ExceptionReason_Load(object sender, EventArgs e)
        {
            ExecptionReason.SelectedIndex = -1;
            CoInsuranceType.SelectedIndex = -1;

        }
    }
}
