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
    /// Summary description for ClmReceiptReport.
    /// </summary>
    public partial class ClmReceiptReport : Telerik.Reporting.Report
    {
        public int ReceiptId = 0;
        public ClmReceiptReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            ViewReceiptRepFrm frm = (ViewReceiptRepFrm)Application.OpenForms["ViewReceiptRepFrm"];
            ReceiptId = frm.ReceiptId;
            dbContext db = new dbContext();


            var q = db.ClmErrorDataEnter.Where(p => p.RowStatus != RowStatus.Deleted && p.ReceiptId == ReceiptId).Select(p => new
            {
                ErrorName = p.ClmErrorTypes.ErrorName,
                OrNo = p.VistNo,
                Notes = p.Notes
            }).ToList();
            if (q.Count > 0)
            {
                SubReportError sr = new SubReportError();
                subReport1.ReportSource = sr;
                sr.DataSource = q;

              
            }



        }
    }
}