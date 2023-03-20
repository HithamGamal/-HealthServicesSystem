using HealthServicesSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Claims
{
    public partial class ClmApproveAndDelFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmApproveAndDelFrm()
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
        DateTime _now = PLC.getdate();
        private void ViewBtn_Click(object sender, EventArgs e)
        {
            radGridView1.DataSource = null;
            var q = db.ClmImpFile.Where(p => p.RowStatus == RowStatus.NewRow && p.ClmStatus == ClmStatus.Temporary).Select(p => new { Id = p.Id, FileNo = p.FileNo, CenterName = p.CenterInfo.CenterName, CenterId = p.CenterId, DrogCount = p.DrogCount, VistCount = p.Counts, m= p.Month ,y=p.year }).ToList();
            if (q.Count >0)
            {
                radGridView1.DataSource = q;
            }
        }

        private void radGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(radGridView1 .RowCount >0)
            {
                impId = int.Parse(radGridView1.CurrentRow.Cells["Id"].Value.ToString());
                _y = int.Parse(radGridView1.CurrentRow.Cells["y"].Value.ToString());
                _m = int.Parse(radGridView1.CurrentRow.Cells["m"].Value.ToString());
                _FileNo = int.Parse(radGridView1.CurrentRow.Cells["FileNo"].Value.ToString());
                _cntrId = int.Parse(radGridView1.CurrentRow.Cells["CenterId"].Value.ToString());
                if (radGridView1 .CurrentColumn .Name =="Exp")
                {
                    try
                    {
                       
                        

                        var Chq = db.ClmMasterData.Where(p => p.RowStatus != RowStatus.Deleted && p.ImpId == impId && p.FileNo == _FileNo && p.Months == _m && p.Years == _y && p.CenterId == _cntrId).ToList();
                        if (Chq.Count >0)
                        {
                            MessageBox.Show("تم تحويل الملف");
                            return;

                        }
                        var q = db.ClmTempDet.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmTempMaster.Months == _m && p.ClmTempMaster.Years == _y && p.ClmTempMaster.CenterId ==_cntrId && p.ClmTempMaster.FileNo == _FileNo && p.ImpId == impId ).ToList();

                        var q2 = db.ClmTempMaster.Where(p => p.RowStatus != RowStatus.Deleted && p.ImpId == impId).ToList();

                        if (q.Count > 0)
                        {
                            DialogResult d = MessageBox.Show("هل تريد نقل الملف من المؤقت الي مطالبة ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (d == DialogResult.No)
                            {
                                return;
                            }
                            progMax = q.Count+ q2.Count ;
                            progressBar1.Maximum = progMax;
                            progressBar1.Minimum = 0;
                            progressBar1.Value = 0;
                            backgroundWorker1.RunWorkerAsync();

                        }

                    }
                    catch
                    {
                        MessageBox.Show("In Proccess");
                    }

                }
                else if (radGridView1.CurrentColumn.Name == "Del")
                {
                    var q = db.ClmTempMaster.Where(p => p.RowStatus != RowStatus.Deleted && p.ImpId == impId && p.FileNo == _FileNo).ToList();
                    if (q.Count > 0)
                    {
                        DialogResult d = MessageBox.Show("هل تريد حذف الملف من المؤقت  ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (d == DialogResult.No)
                        {
                            return;
                        }
                        var deldet = db.ClmTempDet.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmTempMaster.ImpId == impId && p.ClmTempMaster.FileNo == _FileNo).ToList();
                        if (deldet.Count > 0)
                        {
                            foreach (var item in deldet )
                            {
                                db.ClmTempDet.Remove(item);
                            }
                            db.SaveChanges();
                        }
                        var delMstr = db.ClmTempMaster.Where(p => p.RowStatus != RowStatus.Deleted && p.ImpId == impId && p.FileNo == _FileNo).ToList();
                        if (delMstr .Count> 0)
                        {
                            foreach (var item in delMstr)
                            {
                                db.ClmTempMaster.Remove(item);
                            }
                           if( db.SaveChanges()>0)
                            {
                                var delimp = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == impId && p.FileNo == _FileNo).ToList();
                                if (delimp.Count > 0)
                                {
                                    delimp[0].RowStatus = RowStatus.Deleted;
                                    delimp[0].UserDeleted = _UserId;
                                    delimp[0].DeleteDate = PLC.getdate();
                                    if (db.SaveChanges() > 0)
                                    {
                                        MessageBox.Show("تم حذف الملف");
                                    }
                                }
                            }
                        }


                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            { 
            dbContext db = new dbContext();
            int _mId = 0;
            int pi = 0;
            var q = db.ClmTempMaster.Where(p => p.RowStatus != RowStatus.Deleted && p.ImpId ==impId).ToList();
                if (q.Count > 0)
                {

                    List<ClmDetailsData> datas = new List<ClmDetailsData>();
                    List<ClmMasterData> Mstr = new List<ClmMasterData>();



                    foreach (var item in q)
                    {


                        if (backgroundWorker1.CancellationPending == true)
                        {
                            e.Cancel = true;
                            return;
                        }
                        // System.Threading.Thread.Sleep(100);
                        backgroundWorker1.ReportProgress(pi++);



                        ClmMasterData t = new ClmMasterData();
                        t.Id = item.Id;
                        t.Age = item.Age;
                        t.CenterId = item.CenterId;
                        t.CleintId = item.CleintId;
                        t.FileNo = _FileNo;
                        t.Gender = item.Gender;
                        t.ImpId = impId;
                        t.VisitDate = item.VisitDate;
                        t.VisitNo = item.VisitNo;
                        t.InsuranceNo = item.InsuranceNo;
                        t.Months = item.Months;
                        t.NoOfFile = item.NoOfFile;
                        t.PatName = item.PatName;
                        t.Years = item.Years;

                        t.UserId = _UserId;
                        t.DaignosisId = item.DaignosisId;
                        t.ContractId = item.ContractId;
                        t.DateIn = _now;
                        t.IsReviewed = 0;
                        t.Status = Status.Active;
                        t.RowStatus = RowStatus.NewRow;
                        t.LocalityId = 0;

                        Mstr.Add(t);
                    }
                    db.ClmMasterData.BulkInsert(Mstr);

                    var qdet = db.ClmTempDet.Where(p => p.RowStatus != RowStatus.Deleted && p.ClmTempMaster.ImpId == impId).ToList();
                    if (qdet.Count > 0)
                    {
                        foreach (var item in qdet)
                        {
                            backgroundWorker1.ReportProgress(pi++);

                            ClmDetailsData d = new ClmDetailsData();
                            d.Id = item.Id;
                            d.GenericId = item.GenericId;
                            d.MasterId = item.MasterId;
                            d.Qty = item.Qty;
                            d.TotalPrice = item.TotalPrice;
                            d.TradeName = item.TradeName;
                            d.UnitPrice = item.UnitPrice;
                            d.PatPrice = item.PatPrice;
                            d.ClaimPrice = item.ClaimPrice;
                            d.UserId = _UserId;
                            d.DateIn = _now;
                            d.RowStatus = RowStatus.NewRow;
                            d.Status = Status.Active;
                            d.LocalityId = 0;
                            datas.Add(d);
                        }
                        db.ClmDetailsData.BulkInsert(datas);

                    }
           
            }

                var qUpdate = db.ClmImpFile.Where(p => p.RowStatus != RowStatus.Deleted && p.Id == impId).ToList();
            if (qUpdate.Count > 0)
            {
                qUpdate[0].ClmStatus = ClmStatus.Import;
                qUpdate[0].EnabledDate = PLC.getdatetime();
                qUpdate[0].EnabledUserId = _UserId;
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يكتمل عملية التصدير " + ex.Message);
            }
        }
            
        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
           ProcessLb.Text = "process :" + e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (backgroundWorker1.CancellationPending == true)
            {
                MessageBox.Show("Canceled");
                progressBar1.Value = progMax;
            }
            else
            {
                MessageBox.Show("Completed...");
            }
            FileNoLb.Text = _FileNo.ToString();
            ImpNoLb.Text = impId.ToString();
        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ClmApproveAndDelFrm_Load(object sender, EventArgs e)
        {

        }
      
    }
}
