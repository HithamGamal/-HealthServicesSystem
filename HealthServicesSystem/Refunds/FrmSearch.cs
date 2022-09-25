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
    public partial class FrmSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmSearch()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmSearch defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmSearch Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmSearch();
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
        private void txtname_TextChanged(object sender, System.EventArgs e)
		{
            if (!string.IsNullOrEmpty(txtname.Text))
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    DateTime dat = PLC.getdate().AddYears(-1);
                    lstName.Items.Clear();
                    var Fref = db.Reclaims.Where(p => p.InsurName.StartsWith(txtname.Text.Trim()) && p.RowStatus != RowStatus.Deleted && p.ReclaimDate>=dat).OrderByDescending(p=>p.Id).Take(30).ToList();
                   // GRDSearch.DataSource = Fref;
                    if (Fref.Count > 0)
                    {
                        for (int i = 0; i < Fref.Count; i++)
                        {
                            lstName.Items.Add(Fref[i].InsurName);
                        }
                    }
                }
            }
            else
            {
                lstName.Items.Clear();

            }
		}

		private void lstName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void FrmSearch_Load(object sender, System.EventArgs e)
		{

		}

        private void LstName_Click(object sender, EventArgs e)
        {
         
        }

        private void LstName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }

        private void LstName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void LstName_Click_1(object sender, EventArgs e)
        {
            if (lstName.Items.Count > 0)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    DateTime dat = PLC.getdate().AddYears(-1);
                    //MessageBox.Show(lstName.Text);
                    var Fref = db.Reclaims.Where(p => p.InsurName == lstName.Text.Trim() && p.RowStatus != RowStatus.Deleted && p.ReclaimDate >= dat).Select(p=> new { p.InsurNo,p.ReclaimNo,p.ReclaimDate,p.ReclaimTotal}).Take(30).ToList();
                    GRDSearch.DataSource = Fref;
                    if (Fref.Count > 0)
                    {
                        for (int i = 0; i < Fref.Count; i++)
                        {
                            GRDSearch.Rows[i].Cells["Column1"].Value = i + 1;

                        }
                    }
                    else
                    {
                        GRDSearch.DataSource = null;
                    }
                }
            }
            else
            {
                GRDSearch.DataSource = null;
            }
        }
    }
}
