namespace MedicalServiceSystem
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class SupplierRPT : Telerik.Reporting.Report
    {
        public SupplierRPT()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
             pictureBox1.Value = "\\\\192.168.10.2\\logo\\InsurLogo.jpg";
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}