using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.SystemSetting
{
    public partial class CompanyConfig : Telerik.WinControls.UI.RadForm
    {
        public Image file1;
        public string image1;
        public string image2;
        public CompanyConfig()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static CompanyConfig defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static CompanyConfig Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new CompanyConfig();
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

        public static byte[] Imagetobyte(string ImgePath)
        {

            byte[] imageArray = File.ReadAllBytes(ImgePath);
            return imageArray;

        }




        public Image ByteArrayImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            //try
            //{
                using (dbContext db = new dbContext())
                {
                if (image1 == null)
                {
                    MessageBox.Show("يجب تحديد مسار شعار المؤسسة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (image2 == null)
                {
                    MessageBox.Show("يجب تحديد مسار شعار آخر", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var GetCompany = db.CompanySettings.ToList();
                    if (GetCompany.Count > 0)
                    {
                        var company = db.CompanySettings.First();
                        byte[] x1 = Imagetobyte(image1);
                        company.LogoPath1 = x1;
                        byte[] x2 = Imagetobyte(image2);
                        company.LogoPath2 = x2;
                        company.ManagerName = managerName.Text.Trim();
                        company.WebSite = Website.Text.Trim();
                        company.Management = Management.Text.Trim();
                        company.Department = Department.Text.Trim();
                        company.CompanyName = CompanyName.Text.Trim();
                    }
                    else
                    {
                        CompanySetting cfig = new CompanySetting();
                        // company.Name = CompanyName.Text;
                        byte[] x1 = Imagetobyte(image1);
                        cfig.LogoPath1 = x1;
                        byte[] x2 = Imagetobyte(image2);
                        cfig.LogoPath2 = x2;
                        cfig.ManagerName = managerName.Text.Trim();
                        cfig.WebSite = Website.Text.Trim();
                        cfig.Management = Management.Text.Trim();
                        cfig.Department = Department.Text.Trim();
                        cfig.CompanyName = CompanyName.Text.Trim();
                        db.CompanySettings.Add(cfig);
                    }
                    //  db.CompanyNames.Add(company);
                    db.SaveChanges();
                    MessageBox.Show("لقد حفظت البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            //}
            //catch (Exception)
            //{


            //}

        }

        private void retreiveBTN_Click_1(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    file1 = Image.FromFile(openFileDialog1.FileName);
                    image2 = openFileDialog1.FileName.ToString();
                    // pictureBox1.ImageLocation = label1.Text;
                    pictureBox2.Image = file1;
                    // this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Show();
                }
            }
        }

        private void UploadLogo1_Click(object sender, EventArgs e)
        {
            //radLabel4.Text = @"C:\base.png";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file1 = Image.FromFile(openFileDialog1.FileName);
                image1 = openFileDialog1.FileName.ToString();
                // pictureBox1.ImageLocation = label1.Text;
                pictureBox1.Image = file1;
                // this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Show();
            }
        }

        private void CompanyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompanyConfig_Load(object sender, EventArgs e)
        {
            try
            {
                using (dbContext db = new dbContext())
                {
                    UploadLogo1.Focus();
                    var company = db.CompanySettings.First();
                    Byte[] MyData = new byte[0];
                    MyData = (Byte[])company.LogoPath1;
                    MemoryStream stream = new MemoryStream(MyData);
                    stream.Position = 0;
                    pictureBox1.Image = Image.FromStream(stream);
                    Byte[] MyData1 = new byte[0];
                    MyData1 = (Byte[])company.LogoPath2;
                    MemoryStream stream1 = new MemoryStream(MyData1);
                    stream1.Position = 0;
                    pictureBox2.Image = Image.FromStream(stream1);

                    CompanyName.Text = company.CompanyName;
                    managerName.Text = company.ManagerName;
                    Management.Text = company.Management;
                    Department.Text = company.Department;
                    Website.Text = company.WebSite;

                }
                }
            catch (Exception)
            {

                
            }
        }
    }
}
