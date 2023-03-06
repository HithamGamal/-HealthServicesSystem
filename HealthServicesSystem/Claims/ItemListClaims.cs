using ModelDB;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace HealthServicesSystem.Claims
{
    /// <summary>
    /// Summary description for CenterListNonConfirmReport.
    /// </summary>
    public partial class ItemListClaims: Telerik.Reporting.Report
    {
        public ItemListClaims()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            dbContext db = new dbContext();
            var q = db.CompanySettings.ToList();
            if (q.Count > 0)
            {
                ComanyName.Value = q[0].CompanyName;
                //pictureBox1.Value = PLC.ByteArrayImage(q[0].LogoPath2);
            }
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ItemListClaims_ItemDataBinding(object sender, EventArgs e)
        {
           

            
        }

        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
            //  Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "Relate");
            //float Per = Convert.ToSingle(section.DataObject["ClaimPrice"])/ Convert.ToSingle (section.DataObject["Total"])*100;
            decimal Per = Convert.ToDecimal(Total.Value);
            decimal Per1 = Convert.ToDecimal(section.DataObject["ClaimPrice"]);
            Percent.Value =Math .Round ( (Per1 / Per * 100) ,2).ToString();
        }
    }
}