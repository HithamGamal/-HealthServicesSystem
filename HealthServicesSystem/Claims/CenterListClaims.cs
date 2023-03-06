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
    public partial class CenterListClaims : Telerik.Reporting.Report
    {
        public CenterListClaims()
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
    }
}