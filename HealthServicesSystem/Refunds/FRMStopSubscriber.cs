using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMStopSubscriber : Telerik.WinControls.UI.RadForm
    {
        public FRMStopSubscriber()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMStopSubscriber defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMStopSubscriber Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMStopSubscriber();
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

        #endregion
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
            if (StopCause.Text.Length == 0)
            {
                MessageBox.Show("يجب سبب ايقاف المشترك المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                StopCause.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                var ser = db.StopSubsribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (ser.Count == 0)
                {
                    StopSubsriber Sts = new StopSubsriber();
                    Sts.InsurNo = card_no.Text;
                    Sts.StopDate = PLC.getdate();
                    Sts.IsStoped = true;
                    Sts.Comment= StopCause.Text.Trim();
                    db.StopSubsribers.Add(Sts);
                    db.SaveChanges();
                    MessageBox.Show("لقد تم ايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                var ser1 = db.StopSubsribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (ser1.Count > 0)
                {

                    ser1[0].IsStoped = true;
                    ser1[0].Comment = StopCause.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("لقد تم ايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //var Ssc = dbs.Where(p => p.InsurNo == card_no.Text).ToList();
                //if (Ssc.Count > 0)
                //{
                //    Ssc[0].IsStoped = true;
                //    Ssc[0].Notes = StopCause.Text.Trim();
                //    db.SaveChanges();
                //    MessageBox.Show("لقد تم ايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            
                this.Close();
		}

		private void patienthistory_Load(object sender, System.EventArgs e)
		{
            using (dbContext db = new dbContext())
            {
                //var Ssc = dbs.Where(p => p.InsurNo == card_no.Text).ToList();
                //if (Ssc.Count > 0)
                //{
                //    StopCause.Text = Ssc[0].Notes;

                //}
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

        private void RadButton1_Click(object sender, EventArgs e)
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
            if (StopCause.Text.Length == 0)
            {
                MessageBox.Show("يجب سبب ايقاف المشترك المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                StopCause.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                var ser = db.StopSubsribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (ser.Count > 0)
                {

                    ser[0].IsStoped = false;
                    ser[0].Comment = StopCause.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("لقد تم إلغاءايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

                this.Close();
        }
    }
}
