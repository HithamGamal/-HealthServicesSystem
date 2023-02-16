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
    public partial class ClmsFilterCenterDataFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmsFilterCenterDataFrm()
        {
            InitializeComponent();
        }
        public string Path = "";
        private void ClmsFilterCenterDataFrm_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source ="+Path+";Persist Security Info =False;");
            OleDbDataAdapter da = new OleDbDataAdapter("Select MasterTb.ID,MasterTb.FullName as PatName ,MasterTb.InsuranceNo ,MasterTb.Mnth as Months, MasterTb.yr as Years ,MasterTb.Age, MasterTb.Gender ,MasterTb.VisitNo , MasterTb.VisitDate, MasterTb.StateId, DetailsTb.TradeName, DetailsTb.Qty, DetailsTb.Price as UnitPrice, DetailsTb.Total as TotalPrice, DetailsTb.PatPrice, DetailsTb.ClaimPrice, Generics.GenericName , ContractType.ContractName as VisitType FROM ContractType INNER JOIN((Generics INNER JOIN DetailsTb ON Generics.GenericId = DetailsTb.GenericId) INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID) ON ContractType.Id = MasterTb.TypeId ", con);
                 // OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName as PatName, MasterTb.Age, MasterTb.Gender, MasterTb.Mnth as Month, MasterTb.yr as Year, MasterTb.VisitNo , MasterTb.VisitDate, MasterTb.StateId, DetailsTb.TradeName, DetailsTb.Qty, DetailsTb.Price, DetailsTb.Total, DetailsTb.PatPrice, DetailsTb.ClaimPrice, Generics.GenericName FROM(Generics INNER JOIN DetailsTb ON Generics.GenericId = DetailsTb.GenericId) INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID ", con);
                 DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    radGridView2 .DataSource = dt;

                }
            }
        
    }
}
