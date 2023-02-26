using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Claims
{
    public partial class PrintCenterReportFrm : Telerik.WinControls.UI.RadForm
    {
        public PrintCenterReportFrm()
        {
            InitializeComponent();
        }
        public int typid = 0;
        public string filePath = "";
        public string PharName = "";
        public int Mon = 0;
        public int yr = 0;
        private void PrintCenterReportFrm_Load(object sender, EventArgs e)
        {

           
        }

        private void MasterBtn_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + filePath + ";Persist Security Info =False;");


            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID as Id, first(MasterTb.InsuranceNo) as InsNo, first(MasterTb.FullName) as FullName, first(MasterTb.VisitDate) as VisitDate, Sum(DetailsTb.Total) as TotalPrice  ,Max(mnth) as Mnth ,Max(yr)  as Yr FROM DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID  group by MasterTb.ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    CustomerReport rep = new CustomerReport();
                    rep.DataSource = dt;
                    rep.Det.Value = "تقرير المسير  لشهر  " + Mon +" لسنة "+ yr;
                    rep.PharName.Value = PharName;
                    reportViewer1.ReportSource = rep;
                    reportViewer1.RefreshReport();
                }
            }

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + filePath + ";Persist Security Info =False;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT DetailsTb.GenericId as ItemId, Generics.GenericName as ItemName, sum( DetailsTb.Qty) as Qty, Sum(DetailsTb.Total) as TotalPrice FROM DetailsTb INNER JOIN Generics ON DetailsTb.GenericId = Generics.GenericId  group by DetailsTb.GenericId , Generics.GenericName", con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ItemsReport rep = new ItemsReport();
                rep.DataSource = dt;
                rep.Det.Value = "تقرير الادوية  لشهر  " + Mon + " لسنة " + yr;
                rep.PharName.Value = PharName;
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();
            }
        }

        private void SummeryBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + filePath + ";Persist Security Info =False;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT  Max (MasterId) AS MaxId, count (MasterId) AS MasterId, Count(GenericId) AS ItemId, Sum(Total) AS TotalPrice, Sum(ClaimPrice) AS ClaimPrice FROM DetailsTb", con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                OleDbDataAdapter da1 = new OleDbDataAdapter("SELECT   count (Id)  as MasterId FROM MasterTb", con);
                DataTable dt1 = new DataTable();
                dt1.Clear();
                da1.Fill(dt1);
                CenterSummeryRep rep = new CenterSummeryRep();
                rep.DataSource = dt;
                rep.Det.Value = " ملخص المطالبة   لشهر  " + Mon + " لسنة " + yr;
                rep.PharName.Value = PharName;
                rep.MasterId .Value = dt1.Rows[0]["MasterId"].ToString();
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();
            }
        }
    }
}
