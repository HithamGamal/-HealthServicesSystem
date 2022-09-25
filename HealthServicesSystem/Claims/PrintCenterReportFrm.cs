using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.Claims
{
    public partial class PrintCenterReportFrm : Telerik.WinControls.UI.RadForm
    {
        public PrintCenterReportFrm()
        {
            InitializeComponent();
        }
        public int typid = 0;
        public string filePath = "";
        private void PrintCenterReportFrm_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + filePath + ";Persist Security Info =False;");
            if (typid == 1)
            {
               

                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID as Id, first(MasterTb.InsuranceNo) as InsNo, first(MasterTb.FullName) as FullName, first(MasterTb.VisitDate) as VisitDate, Sum(DetailsTb.Total) as TotalPrice  ,Max(mnth) as Mnth ,Max(yr)  as Yr FROM DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID  group by MasterTb.ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    CustomerReport rep = new CustomerReport();
                    rep.DataSource = dt;
                    rep.Det.Value = "تقرير المسير  لشهر  " + dt.Rows[0]["mnth"];
                    reportViewer1.ReportSource = rep;
                    reportViewer1.RefreshReport();
                }
            }
            else if (typid == 2)
            {

              

                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DetailsTb.GenericId as ItemId, Generics.GenericName as ItemName, sum( DetailsTb.Qty) as Qty, Sum(DetailsTb.Total) as TotalPrice FROM DetailsTb INNER JOIN Generics ON DetailsTb.GenericId = Generics.GenericId  group by DetailsTb.GenericId , Generics.GenericName", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ItemsReport rep = new ItemsReport();
                    rep.DataSource = dt;
                    rep.Det.Value = "تقرير الادوية  ";
                    reportViewer1.ReportSource = rep;
                    reportViewer1.RefreshReport();
                }
            }
        }
    }
}
