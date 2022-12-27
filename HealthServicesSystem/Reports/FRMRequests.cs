using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Reports
{
    public partial class FRMRequests : Telerik.WinControls.UI.RadForm
    {

        dbContext db = new dbContext();
        public FRMRequests()
        {
            InitializeComponent();
        }

        private void DisplayBTN_Click(object sender, EventArgs e)
        {
            
            
            DateTime fromDate = FromDate .Value;
            DateTime toDate = ToDate.Value;


            if (reportName.SelectedIndex== 0)
            {
                RPTRequestByCost rpt = new RPTRequestByCost();
                var q = db.medicalCommitteeRequests
                    //.Where(x => x.DateIn <= ToDate.Value.Date && x.DateIn >= FromDate.Value.Date)

                          .Select(x => new
                          {
                              countt = x.Id,
                              cost = x.MedicalTotal,
                              card_type = x.CardType
                          }).ToList();

                rpt.DataSource = q;
                //rpt.col1.Value = "رقم المخدم";
                //rpt.col2.Value = "اسم المخدم";
                //rpt.col3.Value = "المحلية";
                //rpt.col4.Value = "العنوان";
                //rpt.col5.Value = "الرقم الخاص";
                //rpt.col6.Value = "رقم الحساب";
                //rpt.reportName.Value = "تقرير بيانات المخدمين اجمالي";
                rpt.date1.Value = fromDate.Date.ToShortDateString();
                rpt.date2.Value = toDate.Date.ToShortDateString();
                rpt.dateIn.Value = DateTime.Today.Date.ToShortDateString();
                reportViewer1.ReportSource = rpt;
                reportViewer1.RefreshReport();

            }

            if (reportName.SelectedIndex == 1)
            {
                RPTRequestsByCount rpt = new RPTRequestsByCount();
                var q1 = db.medicalCommitteeRequestDetails
                           //.Where(x => x.DateIn <= ToDate.Value.Date && x.DateIn >= FromDate.Value.Date)

                           //.GroupBy(p => p.MedicalCommitteeRequest.CardType)
                          .Select(p => new
                          {
                              countt = p.RequestId,
                              cost = p.ServiceCost ,
                              services = p.Service_Name ,
                              cardType=p.MedicalCommitteeRequest.CardType,
                          }).ToList();

                rpt.DataSource = q1;
                rpt.date1.Value = fromDate.Date.ToShortDateString();
                rpt.date2.Value = toDate.Date.ToShortDateString();
                rpt.dateIn.Value = DateTime.Today.Date.ToShortDateString();
                reportViewer1.ReportSource = rpt;
                reportViewer1.RefreshReport();

            }

            if (reportName.SelectedIndex == 2)
            {
                RPTRequestsByServices rpt = new RPTRequestsByServices();

                var q2 = db.medicalCommitteeRequestDetails
                    //.Where(x => x.DateIn <= ToDate.Value.Date && x.DateIn >= FromDate.Value.Date)
                   .GroupBy(p=>p.Service_Name)
                          .Select(p => new
                          {
                              countt = p.Count(),
                              cost = p.Sum(j=>j.ServiceCost),
                              services = p.Key
                          }).ToList();

                rpt.DataSource = q2;
                rpt.date1.Value = fromDate.Date.ToShortDateString();
                rpt.date2.Value = toDate.Date.ToShortDateString();
                rpt.dateIn.Value = DateTime.Today.Date.ToShortDateString();
                reportViewer1.ReportSource = rpt;
                reportViewer1.RefreshReport();
            }


            



        }
    }
}
