using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMSave : Telerik.WinControls.UI.RadForm
    {
        public FRMSave()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMSave defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMSave Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMSave();
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
            FRMReception.Default.OperationNo.Text = OPr.Text.Trim();
            Close();
        }

        private void FRMSave_Load(object sender, EventArgs e)
        {
          OPr.Text =PLC.Opr;
        }
    }
}
