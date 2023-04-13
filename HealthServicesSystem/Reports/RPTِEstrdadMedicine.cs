namespace HealthServicesSystem.Reports
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using Telerik.WinForms.Documents.Model;

    /// <summary>
    /// Summary description for RPTChronicBooksDetails.
    /// </summary>
    public partial class RPTöEstrdadMedicine : Telerik.Reporting.Report
    {
        public RPTöEstrdadMedicine()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            if (PLC.conNew.State == (System.Data.ConnectionState)1)
            {
                PLC.conNew.Close();
            }
            PLC.conNew.Open();
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
            string srr = "select top 1 * from Cards where InsuranceNo=" + section.DataObject["Row6"].ToString() + " and RowStatus<>2";
            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
            DataTable dtsearch = new DataTable();
            dtsearch.Clear();
            dasearch.Fill(dtsearch);
            if (dtsearch.Rows.Count > 0)
            {
                string MNo = dtsearch.Rows[0]["SubscribeId"].ToString();
                string srr1 = "select top 1 * from Cards where InsuranceNo=" + MNo + " and RowStatus<>2";
                SqlDataAdapter dasearch1 = new SqlDataAdapter(srr1, PLC.conNew);
                DataTable dtsearch1 = new DataTable();
                dtsearch1.Clear();
                dasearch1.Fill(dtsearch1);
                if (dtsearch1.Rows.Count > 0) { 
                InsurName.Value = dtsearch1.Rows[0]["Firstname"].ToString() + " " + dtsearch1.Rows[0]["Secondname"].ToString() + " " + dtsearch1.Rows[0]["Thirdname"].ToString() + " " + dtsearch1.Rows[0]["Fourthname"].ToString();
                }
                else
                {
                    InsurName.Value = "";
                }
            }
        }

        private void RPTöEstrdadMedicine_Disposed(object sender, EventArgs e)
        {

        }
    }
}