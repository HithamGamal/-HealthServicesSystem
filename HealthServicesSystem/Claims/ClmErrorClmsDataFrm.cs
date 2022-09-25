using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.Claims
{
    public partial class ClmErrorClmsDataFrm : Telerik.WinControls.UI.RadForm
    {
        public ClmErrorClmsDataFrm()
        {
            InitializeComponent();
        }
        public int _UserId = LoginForm.Default.UserId;
        public void fillGrid()
        {
            try
            {
                radGridView1.DataSource = null;

                dbContext db = new dbContext();
                int _RecId = int.Parse(ReceiptId.Text);
                var q = db.ClmErrorDataEnter.Where(p => p.ReceiptId == _RecId && p.RowStatus != RowStatus.Deleted).Select(p => new { Id = p.Id, Notes = p.Notes, Cost = p.Cost, VisitNo = p.VistNo, EmpName = p.EmpName , GroupName= p.ErrorGroup ,ErrorName = p.ClmErrorTypes.ErrorName }).ToList();
                if (q.Count >0)
                {
                    radGridView1.DataSource = q;
                }
            }
            catch
            {

            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            IdTxt.Clear();
            VisitNo.Clear();
            CostTxt.Clear();
        }

        private void ClmErrorClmsDataFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            ErrorGroupName.DataSource = Enum.GetValues(typeof(ErrorGroup));
            fillGrid();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            if (IdTxt.Text == "")
            {
               
                ClmErrorDataEnter c = new ClmErrorDataEnter();
                c.Cost = Convert.ToDecimal(CostTxt.Text);
                c.Counts = 0;
                c.DateIn = PLC.getdatetime();
                c.ErrorId = int.Parse(ErrorName.SelectedValue.ToString());
                c.Notes = Notes.Text;
                c.ReceiptId = int.Parse(ReceiptId.Text);
                c.RowStatus = RowStatus.NewRow;
                c.Status = Status.Active;
                c.UserId = _UserId ;
                c.EmpName = EmpName.Text;
                c.ErrorGroup =(ErrorGroup) Enum.Parse (typeof ( ErrorGroup), ErrorGroupName.Text);
                c.ErrorId = int.Parse(ErrorName.SelectedValue.ToString());
                c.VistNo = int.Parse(VisitNo.Text);
                db.ClmErrorDataEnter.Add(c);
                if (db.SaveChanges() > 0)
                {
                    IdTxt.Text = c.Id.ToString();
                }
            }
            else
            {
                int _id = int.Parse(IdTxt.Text);
                var q = db.ClmErrorDataEnter.Where(p => p.Id == _id && p.RowStatus != RowStatus.Deleted).ToList();
                if (q.Count >0)
                {
                    DialogResult d = MessageBox.Show("هل تريد التعديل ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                        q[0].Notes = Notes.Text;
                    q[0].UpdateDate = PLC.getdatetime();
                    q[0].UpdateUser = _UserId;
                    q[0].VistNo = int.Parse(VisitNo.Text);
                    q[0].Cost = Convert.ToDecimal(VisitNo.Text);
                    q[0].EmpName = EmpName.Text;

                    if (db.SaveChanges()>0)
                    {
                        MessageBox.Show("تم التعديل");
                    }
                }
            }
            NewBtn.PerformClick();
            fillGrid();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            int _id = int.Parse(IdTxt.Text);
            var q = db.ClmErrorDataEnter.Where(p => p.Id == _id && p.RowStatus != RowStatus.Deleted).ToList();
            if (q.Count > 0)
            {
                DialogResult d = MessageBox.Show("هل تريد الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
             
                q[0].DeleteDate = PLC.getdatetime();
                q[0].UserDeleted = _UserId;
                q[0].RowStatus  =  RowStatus.Deleted;
              

                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("تم الحذف");
                }
            
        }
        fillGrid();
    }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorGroupName_SelectedValueChanged(object sender, EventArgs e)
        {
            dbContext db = new dbContext();

            var enumid = (ErrorGroup)Enum.Parse(typeof(ErrorGroup), ErrorGroupName.SelectedText);
            var q = db.ClmErrorType.Where(p => p.ErrorGroup == enumid).ToList();
            if (q.Count > 0)
            {
                ErrorName.DataSource = q;
                ErrorName.DisplayMember = "ErrorName";
                ErrorName.ValueMember = "Id";
                ErrorName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ErrorName.SelectedIndex = -1;
            }
            else
            {
                ErrorName.DataSource = null;
            }
        }

        private void radGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            dbContext db = new dbContext();
            if (radGridView1 .RowCount >0)
            {
                if (radGridView1 .CurrentColumn .Name == "View")
                {
                    int _id = int.Parse(radGridView1.CurrentRow.Cells["Id"].Value.ToString());
                    var q = db.ClmErrorDataEnter.Where(p => p.Id == _id).ToList();
                    if (q.Count >0)
                    {
                        IdTxt.Text = q[0].Id.ToString();
                        CostTxt.Text = q[0].Cost .ToString ();
                        ErrorName.SelectedValue=q[0].ErrorId ;
                       Notes.Text = q[0].Notes ;
                        ReceiptId.Text= q[0].ReceiptId.ToString() ;
                        EmpName.Text = q[0].EmpName;
                        ErrorGroupName.SelectedIndex = Convert.ToInt32(q[0].ErrorGroup);
                        
                       ErrorName.SelectedValue = q[0].ErrorId;
                        VisitNo.Text = q[0].VistNo.ToString ();
                    }
                }
            }
        }

        private void PrinBtn_Click(object sender, EventArgs e)
        {
   
        }
    }
}
