using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using Telerik.WinControls.UI;
using System.Linq;
using System.Xml.Linq;
using ModelDB;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FrmAddGroup : Telerik.WinControls.UI.RadForm
    {
        public FrmAddGroup()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }



        private static FrmAddGroup defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmAddGroup Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmAddGroup();
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
  

    public int groupId = 0;
    private void Button1_Click(object sender, EventArgs e)
    {

        if (GroupEname.Text.Length == 0)
        {
            MessageBox.Show("يجب كتابة اسم المجموعة باللغة الانجليزية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GroupEname.Focus();
            return;
        }
        if (GroupAName.Text.Length == 0)
        {
            MessageBox.Show("يجب كتابة اسم المجموعة باللغة العربية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GroupAName.Focus();
            return;
        }
        if (groupId == 0)
        {
            using (dbContext db = new dbContext())
            {
                MedicalMainGroup mg = new MedicalMainGroup();
                mg.MainGroupArabicName = GroupAName.Text.Trim();
                mg.MainGroupEnglishName = GroupEname.Text.Trim();
                mg.IsEnabled = true;
                db.MedicalMainGroups.Add(mg);
                db.SaveChanges();
            }
        }

        else if (groupId > 0)
        {

            using (dbContext db = new dbContext())
            {
                var Fgroup = db.MedicalMainGroups.Where(p => p.Id == groupId).ToList();
                if (Fgroup.Count > 0)
                {
                    Fgroup[0].MainGroupArabicName = GroupAName.Text.Trim();
                    Fgroup[0].MainGroupEnglishName = GroupEname.Text.Trim();
                    db.SaveChanges();
                }
            }
        }
        FrmMedicalGroup.Default.LoadData();
        Close();
    }



    private void Button2_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FrmAddGroup_Load(object sender, EventArgs e)
    {

    }
}
} 
