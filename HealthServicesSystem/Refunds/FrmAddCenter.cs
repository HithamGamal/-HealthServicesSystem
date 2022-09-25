//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using ModelDB;

namespace MedicalServiceSystem
{
    public partial class FrmAddCenter
    {
        internal FrmAddCenter()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

 

        private static FrmAddCenter defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmAddCenter Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmAddCenter();
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
        public int CenterId = 0;


        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmAddCenter_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var grp = db.Localities.ToList();
                Locality.DataSource = grp;
                Locality.ValueMember = "Id";
                Locality.DisplayMember = "LocalityName";
                Locality.SelectedIndex = -1;
                CenterType.DataSource = Enum.GetValues(typeof(CenterType));
                var ExcCenter = db.CenterInfos.Where(p=>p.HasContract==false).ToList();
                CenterName.DataSource = ExcCenter;
                CenterName.ValueMember = "Id";
                CenterName.DisplayMember = "CenterName";
                CenterName.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                CenterName.SelectedIndex = -1;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Dim FrmCenters As New FrmCenters
            //FrmCenters.
            if (CenterName.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال اسم المركز أولاً", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CenterName.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                if (CenterId == 0)
                {
                    string str = CenterName.Text;
                    var fc = db.CenterInfos.Where((p) => p.CenterName == str).ToList();
                    if (fc.Count > 0)
                    {
                        MessageBox.Show("الاسم الذي أدخلته للمؤسسة محفوظ مسبقاً في قاعدة البيانات" + "\r" + "Enter another Center Name", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CenterName.Focus();
                        return;
                    }
                    var Fcen = db.CenterInfos.ToList();
                    if (Fcen.Count > 0)
                    {
                        CenterId = db.CenterInfos.Where(p => p.Id > 50000).Max(p => p.Id) + 1;
                    }
                    else
                    {
                        CenterId = 50000;
                    }
                    CenterInfo cr = new CenterInfo();
                    cr.Id = CenterId;
                    cr.CenterName = CenterName.Text.Trim();
                    cr.CenterTypeId = (CenterType)Enum.Parse(typeof(CenterType), CenterType.Text);
                    cr.Level1 = false;
                    cr.Level2 = false;
                    cr.Level3 = false;
                    cr.Level4 = false;
                    cr.HasContract= false; 
                    cr.LocalityId =Convert.ToInt32( Locality.SelectedValue);
                    cr.IsEnabled = true;
                    cr.IsVisible = true;
                    db.CenterInfos.Add(cr);
                    db.SaveChanges();
                    CenterId = db.CenterInfos.Max(p => p.Id);
                }
                else if (CenterId >0)
                {
                    var FGrp = db.CenterInfos.Where((p) => p.Id == CenterId).ToList();
                    if (FGrp.Count > 0)
                    {
                        // FGrp(0).CenterName = Trim(CenterName.Text)
                        FGrp[0].CenterName = CenterName.Text.Trim();
                        FGrp[0].CenterTypeId = (CenterType)Enum.Parse(typeof(CenterType), CenterType.SelectedText);
                        FGrp[0].Level1 = false;
                        FGrp[0].Level2 = false;
                        FGrp[0].Level3 = false;
                        FGrp[0].Level4 = false;
                        FGrp[0].HasContract = false;
                        FGrp[0].LocalityId = Convert.ToInt32(Locality.SelectedValue);
                        db.SaveChanges();
                    }
                }
            }
            FrmCenters.Default.LoadData();
            this.Close();
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            FrmCenters.Default.LoadData();
            Close();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}