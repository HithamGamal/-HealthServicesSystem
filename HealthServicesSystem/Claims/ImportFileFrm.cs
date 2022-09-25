using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace MedicalServiceSystem.Claims
{
    public partial class ImportFileFrm : Telerik.WinControls.UI.RadForm
    {
        public ImportFileFrm()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        public int progMax = 0;
        public int _id = 0;
        public int crunt = 0;
        public int impId = 0;
        public int _cntrId = 0;
        public int _m = 0;
        public int _y = 0;
        public int _FileNo;
        dbContext db = new dbContext();
        DateTime _now =  PLC.getdate();
        public void fillMasterGrid()
        {
            PathFile.Text = openFileDialog1.FileName;
            int m = int.Parse(MonthGrd.CurrentRow.Cells["Mnth"].Value.ToString());
            int y = int.Parse(MonthGrd.CurrentRow.Cells["yr"].Value.ToString());
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName AS PatNAme, MasterTb.Age, MasterTb.Gender, Sum(DetailsTb.Total) AS Cost,ContractType.ContractName  AS types FROM(DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID) INNER JOIN ContractType ON MasterTb.TypeId = ContractType.Id  Where  Mnth = " + m + " and yr= " + y + " GROUP BY MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName, MasterTb.Age, MasterTb.Gender, MasterTb.TypeId, ContractType.ContractName", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MasterGrd.DataSource = dt;

            }
        }
//  public  async Task ImportClaims(string path )
//  {
      
//            int _id = 0;
//            int crunt = 0;
//            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + path + ";Persist Security Info =False;");
//            dbContext db = new dbContext();
//            await  Task .Run   (()=>

//                                { 

//    OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName, MasterTb.Age, MasterTb.Gender, MasterTb.CenterId, MasterTb.DateIn, MasterTb.UserName, MasterTb.Mnth, MasterTb.yr, MasterTb.VisitNo, MasterTb.VisitDate, MasterTb.Daignose, MasterTb.TypeId, DetailsTb.ID, DetailsTb.GenericId, DetailsTb.TradeId, DetailsTb.Qty, DetailsTb.Price, DetailsTb.Total, DetailsTb.UserName, DetailsTb.DateIn, Trades.TradeNAme FROM(DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID) INNER JOIN Trades ON DetailsTb.TradeId = Trades.TradeId Order by MasterTb.ID ", con);
//    DataTable dt = new DataTable();
//    da.Fill(dt);

//    if (dt.Rows.Count > 0)
//    {
//        int Msrtid = 0;
//        for (int i = 0; i < dt.Rows.Count; i++)
//        {

//            crunt = int.Parse(dt.Rows[i]["MasterTb.ID"].ToString());
//            if (_id != crunt)
//            {
//                ClmTempMaster t = new ClmTempMaster();
//                t.Age = int.Parse(dt.Rows[i]["Age"].ToString());
//                t.CenterId = int.Parse(dt.Rows[i]["CenterId"].ToString());
//                t.CleintId = 0;
//                t.FileNo = 1;
//                t.Gender = int.Parse(dt.Rows[i]["Gender"].ToString());
//                t.ImpId = 1;
//                t.VisitDate = Convert.ToDateTime(dt.Rows[i]["VisitDate"].ToString());
//                t.VisitNo = dt.Rows[i]["VisitNo"].ToString();
//                t.InsuranceNo = Convert.ToDouble(dt.Rows[i]["InsuranceNo"].ToString());
//                t.Months = int.Parse(dt.Rows[i]["Mnth"].ToString());
//                t.NoOfFile = int.Parse(dt.Rows[i]["MasterTb.Id"].ToString());
//                t.PatName = dt.Rows[i]["FullName"].ToString();
//                t.Years = int.Parse(dt.Rows[i]["Mnth"].ToString());
//                t.UserId = 0;
//                t.DateIn = _now;
//                _id = t.NoOfFile;
//                db.ClmTempMaster.Add(t);
//                if (db.SaveChanges() > 0)
//                {
//                    Msrtid = t.Id;
//                }
//            }
//            ClmTempDet d = new ClmTempDet();
//            d.GenericId = int.Parse(dt.Rows[i]["GenericId"].ToString());
//            d.MasterId = Msrtid;
//            d.Qty = int.Parse(dt.Rows[i]["Qty"].ToString());
//            d.TotalPrice = Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
//            d.TradeName = dt.Rows[i]["TradeName"].ToString();
//            d.UnitPrice = Convert.ToDecimal(dt.Rows[i]["Price"].ToString());
//            d.UserId = 0;
//            d.DateIn = _now ;
//            db.ClmTempDet.Add(d);

//            if (db.SaveChanges() > 0)
//            {

//            }
//        }
//    }
//});
//        }
        private void OfdBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog ();
        }

        private void ImportFileFrm_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            if (openFileDialog1.FileName.Length > 0)
            {
                MonthGrd.DataSource = null;
                PathFile.Text = openFileDialog1.FileName;
                  OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT Distinct  Mnth, yr ,CenterId from  MasterTb ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
        
                if (dt.Rows.Count > 0)
                {
                    MonthGrd .DataSource = dt;

                    int Centerid = int.Parse ( dt.Rows[0]["CenterId"].ToString());
                    var q = db.CenterInfos.Where(p => p.Id == Centerid).ToList();
                    if (q.Count >0)
                    {
                        CenterName.Text = q[0].CenterName;
                    }
                }
             
            }
        }

        private void MonthGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (MonthGrd .RowCount >0)
            {
                MasterGrd.DataSource = null;
                if (MonthGrd.CurrentColumn .Name=="View")
                {
                    fillMasterGrid();
                }
            }
        }

        private void MasterGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (MasterGrd.RowCount > 0)
            {
                OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
                int id = int.Parse(MasterGrd.CurrentRow.Cells["Id"].Value.ToString());
                if (MasterGrd.CurrentColumn.Name == "View")
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT DetailsTb.ID, Generics.GenericName, Trades.TradeName, DetailsTb.Qty, DetailsTb.Price as UnitPrice, DetailsTb.Total as TotalPrice, DetailsTb.MasterId FROM(DetailsTb INNER JOIN Generics ON DetailsTb.GenericId = Generics.GenericId) INNER JOIN Trades ON(Generics.GenericId = Trades.GenericId) AND(DetailsTb.TradeId = Trades.TradeId) where Masterid = " + id + "", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DetailsGrd.DataSource = dt;

                    }
                }
                if (MasterGrd.CurrentColumn.Name == "Del")
                {
                    DialogResult d = MessageBox.Show("هل تريد الحذف؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No) return;
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * from  MasterTb where id = " + id + "", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        OleDbCommand delDet = new OleDbCommand("delete  from  DetailsTb where MasterId =" + id + "", con);
                        OleDbCommand delmstr = new OleDbCommand("delete  from  MasterTb where Id =" + id + "", con);
                        if (con.State == ConnectionState.Closed) con.Open();

                        delDet.ExecuteNonQuery();
                        delmstr.ExecuteNonQuery();
                        con.Close();
                        MasterGrd.CurrentRow.Delete();
                    }
                }
            }
        }

        private void DetailsGrd_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (DetailsGrd.RowCount > 0)
            {
                OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
                int id = int.Parse(DetailsGrd.CurrentRow.Cells["Id"].Value.ToString());
        
                if (DetailsGrd.CurrentColumn.Name == "Del")
                {
                    DialogResult d = MessageBox.Show("هل تريد الحذف؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No) return;
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * from  DetailsTb where id = " + id + "", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        OleDbCommand delDet = new OleDbCommand("delete  from  DetailsTb where Id =" + id + "", con);
                       
                        if (con.State == ConnectionState.Closed) con.Open();

                        delDet.ExecuteNonQuery();
                        DetailsGrd.CurrentRow.Delete();
                       
                        con.Close();
                        fillMasterGrid();
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MasterBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID as Id, first(MasterTb.InsuranceNo) as InsNo, first(MasterTb.FullName) as FullName, first(MasterTb.VisitDate) as VisitDate, Sum(DetailsTb.Total) as TotalPrice FROM DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID  group by MasterTb.ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                PrintCenterReportFrm frm = new PrintCenterReportFrm();
                frm.typid = 1;
                frm.filePath = PathFile.Text;
                frm.ShowDialog();
            }
        }
            private void DetailsBtn_Click(object sender, EventArgs e)
            {



                OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");

                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DetailsTb.GenericId as ItemId, Generics.GenericName as ItemName, sum( DetailsTb.Qty) as Qty, Sum(DetailsTb.Total) as TotalPrice FROM DetailsTb INNER JOIN Generics ON DetailsTb.GenericId = Generics.GenericId  group by DetailsTb.GenericId , Generics.GenericName", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    PrintCenterReportFrm frm = new PrintCenterReportFrm();
                    frm.typid = 2;
                    frm.ShowDialog();
                }
            }

        private void ExpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
                dbContext db = new dbContext();


                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName, MasterTb.Age, MasterTb.Gender, MasterTb.CenterId, MasterTb.DateIn, MasterTb.UserName, MasterTb.Mnth, MasterTb.yr, MasterTb.VisitNo, MasterTb.VisitDate, MasterTb.DaignoseId, MasterTb.TypeId, DetailsTb.ID, DetailsTb.GenericId, DetailsTb.TradeId, DetailsTb.Qty, DetailsTb.Price, DetailsTb.Total, DetailsTb.UserName, DetailsTb.DateIn, Trades.TradeNAme FROM(DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID) INNER JOIN Trades ON DetailsTb.TradeId = Trades.TradeId Order by MasterTb.ID ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    progMax = dt.Rows.Count;
                    progressBar1.Maximum = progMax;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    backgroundWorker1.RunWorkerAsync();
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("In Proccess"+ ex.Message);
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

          

           
           
                OleDbConnection con = new OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source =" + PathFile.Text + ";Persist Security Info =False;");
                dbContext db = new dbContext();


                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MasterTb.ID, MasterTb.InsuranceNo, MasterTb.FullName, MasterTb.Age, MasterTb.Gender, MasterTb.CenterId, MasterTb.DateIn, MasterTb.UserName, MasterTb.Mnth, MasterTb.yr, MasterTb.VisitNo, MasterTb.VisitDate, MasterTb.Daignoseid, MasterTb.TypeId, DetailsTb.ID, DetailsTb.GenericId, DetailsTb.TradeId, DetailsTb.Qty, DetailsTb.Price, DetailsTb.Total, DetailsTb.UserName, DetailsTb.DateIn, Trades.TradeNAme FROM(DetailsTb INNER JOIN MasterTb ON DetailsTb.MasterId = MasterTb.ID) INNER JOIN Trades ON DetailsTb.TradeId = Trades.TradeId Order by MasterTb.ID ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                 _cntrId = int.Parse(dt.Rows[0]["CenterId"].ToString()); 
                _m = int.Parse(dt.Rows[0]["Mnth"].ToString()); 
                 _y = int.Parse(dt.Rows[0]["yr"].ToString());

                var q = db.ClmImpFile .Where(p => p.CenterId == _cntrId && p.Month  == _m && p.year == _y).ToList();
                if (q.Count==0)
                {
                    _FileNo = 1;
                }
                else
                {
                    _FileNo = q.Max(p => p.FileNo)+1;
                }



                // insert into imort
                ClmImpFile im = new ClmImpFile();
                im.CenterId = _cntrId;
                im.Costs = 0;
                im.Counts = dt.Rows.Count;
                im.DrogCount = dt.Rows.Count;
                im.DateIn = _now;
                im.UserId = _UserId ;
                im.RowStatus = RowStatus.NewRow;
                im.Status = Status.Active;
                im.year = _y;
                im.Month = _m;
                im.ImpDate = _now;
                im.FileNo = _FileNo ;
                im.FilePath = PathFile.Text;
                im.ClmStatus = ClmStatus.Temporary;
                im.TemporaryUserId = _UserId;
                im.TemporaryDate = PLC.getdatetime();
                db.ClmImpFile.Add(im);
                if (db.SaveChanges()>0)
                {
                    impId = im.Id;
                }
              
                //
                int Msrtid = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (backgroundWorker1.CancellationPending == true)
                        {
                            e.Cancel = true;
                            return;
                        }
                        System.Threading.Thread.Sleep(100);
                        backgroundWorker1.ReportProgress(i);

                        crunt = int.Parse(dt.Rows[i]["MasterTb.ID"].ToString());
                        if (_id != crunt)
                        {
                            ClmTempMaster t = new ClmTempMaster();
                            t.Age = int.Parse(dt.Rows[i]["Age"].ToString());
                            t.CenterId = int.Parse(dt.Rows[i]["CenterId"].ToString());
                            t.CleintId = 0;
                            t.FileNo = _FileNo ;
                            t.Gender = int.Parse(dt.Rows[i]["Gender"].ToString());
                            t.ImpId = impId ;
                            t.VisitDate = Convert.ToDateTime(dt.Rows[i]["VisitDate"].ToString());
                            t.VisitNo = dt.Rows[i]["VisitNo"].ToString();
                            t.InsuranceNo = Convert.ToDouble(dt.Rows[i]["InsuranceNo"].ToString());
                            t.Months = int.Parse(dt.Rows[i]["Mnth"].ToString());
                            t.NoOfFile = int.Parse(dt.Rows[i]["MasterTb.Id"].ToString());
                            t.PatName = dt.Rows[i]["FullName"].ToString();
                            t.Years = int.Parse(dt.Rows[i]["yr"].ToString());
                            t.UserId = _UserId;
                        t.DaignosisId = int.Parse(dt.Rows[i]["Daignoseid"].ToString()); 
                        t.ContractId= int.Parse(dt.Rows[i]["TypeId"].ToString());
                        t.DateIn = _now;
                            _id = t.NoOfFile;
                            db.ClmTempMaster.Add(t);
                            if (db.SaveChanges() > 0)
                            {
                                Msrtid = t.Id;
                            }
                        }
                        ClmTempDet d = new ClmTempDet();
                        d.GenericId = int.Parse(dt.Rows[i]["GenericId"].ToString());
                        d.MasterId = Msrtid;
                        d.Qty = int.Parse(dt.Rows[i]["Qty"].ToString());
                        d.TotalPrice = Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                        d.TradeName = dt.Rows[i]["TradeName"].ToString();
                        d.UnitPrice = Convert.ToDecimal(dt.Rows[i]["Price"].ToString());
                        d.UserId = _UserId;
                        d.DateIn = _now;
                        db.ClmTempDet.Add(d);

                        if (db.SaveChanges() > 0)
                        {

                        }
                     
                    }
                }

            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            ProcessLb.Text = "process :" + e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (backgroundWorker1.CancellationPending== true )
            {
                MessageBox.Show("Canceled");
                progressBar1.Value = progMax ;
            }
            else
            {
                MessageBox.Show("Completed...");
            }
            FileNoLb.Text = _FileNo.ToString();
            ImpNoLb.Text = impId.ToString();
        }

        private void ExitExpBtn_Click(object sender, EventArgs e)
        {
           backgroundWorker1.CancelAsync();
        }
    }
}
