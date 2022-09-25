using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMAddStudent : Telerik.WinControls.UI.RadForm
    {
        public FRMAddStudent()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }



        private static FRMAddStudent defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMAddStudent Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMAddStudent();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }
        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public int LocalityId ;
		public string UserName = "";
		private void Button1_Click(object sender, System.EventArgs e)
		{
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (ful_name.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (Sex.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال النوع", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Sex.Focus();
                return;
            }
            if (Age.Text.Length== 0)
            {
                MessageBox.Show("يجب ادخال العمر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Age.Focus();
                return;
            }
            if (University.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال الجامعة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                University.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                //var Ssc = dbs.Where(p => p.InsurNo == card_no.Text).ToList();
                //if (Ssc.Count == 0)
                //{
                //    DateTime Birthdate = PLC.getdate().AddYears(-Convert.ToInt32(Age.Text));
                //    Subscriber Sc = new Subscriber();
                //    Sc.PhoneNo = "";
                //    Sc.InsurNo = card_no.Text.Trim();
                //    Sc.InsurName = ful_name.Text.Trim();
                //    Sc.Gender = Sex.Text;
                //    Sc.Server = University.Text.Trim();
                //    Sc.ClientId =University.SelectedValue.ToString();
                //    Sc.BirthDate = Birthdate;
                //    Sc.LocalityId = PLC.LocalityId;
                //    Sc.IsStoped = false;
                //    dbs.Add(Sc);
                //    db.SaveChanges();
                    FRMApproveMedicine.Default.card_no.Text = card_no.Text.Trim();
                    FRMApproveMedicine.Default.CustName.Text = ful_name.Text.Trim();
                    FRMApproveMedicine.Default.Sex.SelectedIndex = Sex.SelectedIndex;
                    FRMApproveMedicine.Default.ServerName.Text = University.Text.Trim();
                    FRMApproveMedicine.Default.Age.Text = Age.Text.Trim();

               // }
            }
            
                this.Close();
		}

		private void patienthistory_Load(object sender, System.EventArgs e)
		{
            LocalityId = FRMApproveMedicine.Default.LocalityId;
            using (dbContext db = new dbContext())
            {
                if (PLC.conNew.State == (System.Data.ConnectionState)1)
                {
                    PLC.conNew.Close();
                }
                PLC.conNew.Open();
                string srr = "SELECT Id,ArabicClientName FROM [InsuranceSystem].[dbo].[Clients] where SubSectorId=6";
                SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                DataTable dtsearch = new DataTable();
                dtsearch.Clear();
                dasearch.Fill(dtsearch);
                University.DataSource = dtsearch;
                University.ValueMember = "Id";
                University.DisplayMember = "ArabicClientName";
                University.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                
                }
            }

		private void grid_transfer_CellContentClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{

		}

		private void grid_transfer_Click(object sender, System.EventArgs e)
		{

		}

		private void card_ser_TextChanged(object sender, EventArgs e)
		{

		}

		private void Label6_Click(object sender, EventArgs e)
		{

		}

    

        private void RadButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
