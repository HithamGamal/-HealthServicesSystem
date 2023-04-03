using ModelDB;
using System;
using System.Data;
using System.Linq;

namespace HealthServicesSystem.Committee
{
    public partial class CommitteeReportForm : Telerik.WinControls.UI.RadForm
    {
        dbContext db = new dbContext();
        public CommitteeReportForm()
        {
            InitializeComponent();
        }

        private void DisplayBTN_Click(object sender, EventArgs e)
        {
            DateTime fromDate = FromDate.Value;
            DateTime toDate = ToDate.Value;
            committeeWeeklyReport rpt = new committeeWeeklyReport();
            var q = db.medicalCommitteeRequests.Where(x => x.DateIn <= ToDate.Value.Date && x.DateIn >= FromDate.Value.Date)
                                       //.Where(x => locality == "" || x.Unit.Locality.LocalityName == locality)
                                       //.Where(x => mainsector == "" || x.SubSector.MainSector.SectorName == mainsector)
                                       //.Where(x => sector == "" || x.SubSector.SectorName == sector)
                                        .GroupBy(x=>x.RequestType)
                                        .Select(x => new
                                       {
                                            rowData1 = x.Select(p=>p.Id).Count(),
                                            rowData2 = x.Select(p => p.MedicalTotal).Sum(),
                                            rowData3 = x.Key
                                       }).ToList();

            rpt.DataSource = q;


            rpt.dateTime.Value = DateTime.Today.Date.ToShortDateString();
            rpt.fromdate.Value = fromDate.Date.ToShortDateString();
            rpt.todate.Value = toDate.Date.ToShortDateString();

            reportViewer1.ReportSource = rpt;
            reportViewer1.RefreshReport();
        }
    }
}
