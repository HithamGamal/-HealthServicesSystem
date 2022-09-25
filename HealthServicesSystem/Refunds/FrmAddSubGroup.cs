using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ModelDB;
using System.Linq;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FrmAddSubGroup : Telerik.WinControls.UI.RadForm
    {
        public FrmAddSubGroup()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }



        private static FrmAddSubGroup defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmAddSubGroup Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmAddSubGroup();
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
        public int SubGroupId = 0;
		public int GroupId = 0;
		private void Button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FrmAddSubGroup_Load(object sender, EventArgs e)
		{

		}

		private void GroupEname_TextChanged(object sender, EventArgs e)
		{

		}

		private void Button1_Click_1(object sender, EventArgs e)
		{


			if (GroupEname.Text.Length == 0)
			{
				MessageBox.Show("يجب ادخال اسم المجموعة باللغة الانجليزية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				GroupEname.Focus();
				return;
			}
			if (GroupAName.Text.Length == 0)
			{
				MessageBox.Show("يجب ادخال اسم المجموعة باللغة العربية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				GroupAName.Focus();
				return;
			}
			if (SubGroupId == 0)
			{
				using (dbContext db = new dbContext())
				{
					MedicalSubGroup Msg = new MedicalSubGroup();
					Msg.MainGroupId = GroupId;
					Msg.SubgroupAName = GroupAName.Text.Trim();
					Msg.SubGroupEname = GroupEname.Text.Trim();
					Msg.IsEnabled = true;
					db.MedicalSubGroups.Add(Msg);
					db.SaveChanges();
				}
			}
			else if (SubGroupId > 0)
			{
				using (dbContext db = new dbContext())
				{
					var Fsg = db.MedicalSubGroups.Where(p => p.Id == SubGroupId).ToList();
					if (Fsg.Count > 0)
					{
						Fsg[0].SubgroupAName = GroupAName.Text.Trim();
						Fsg[0].SubGroupEname = GroupEname.Text.Trim();
						db.SaveChanges();
					}
				}
			}
			FrmMedicalSubGroup.Default.LoadData();
			Close();
		}

        private void FrmAddSubGroup_Load_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
