using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls;
using System.Linq;
namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMRefuseAlert : Telerik.WinControls.UI.RadForm
    {
        public FRMRefuseAlert()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMRefuseAlert defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMRefuseAlert Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMRefuseAlert();
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
        private void Button1_Click(object sender, System.EventArgs e)
        {
          //  FRMReception.Default.OperationNo.Text = OPr.Text.Trim();
            Close();
        }

        private void FRMRefuseAlert_Load(object sender, EventArgs e)
        {
            if (PLC.SubId.Length>0)
            {
                using (dbContext db = new dbContext())
                {
                    var Frf = db.RefuseMedicines.Where(p => p.InsurNo == PLC.SubId).ToList();
                    if (Frf.Count > 0)
                    {
                        int MaxId = db.RefuseMedicines.Where(p => p.InsurNo == PLC.SubId).Max(p => p.Id);
                        var Frfd = db.RefuseMedicineDetails.Where(p => p.RefuseId == MaxId).ToList();
                        string str ="1." + Frfd[0].RefuseReason;
                        for (int i = 1; i < Frfd.Count; i++)
                        {
                            str=str+(char)13+(i+1).ToString()+"."+ Frfd[0].RefuseReason;
                        }
                        OPr.Text = str;
                    }
                }
            }
        }
    }
}
