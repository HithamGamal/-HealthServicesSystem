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

namespace MedicalServiceSystem
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FrmAddCenter : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.CenterTypeId = new System.Windows.Forms.TextBox();
            this.LocalityId = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Locality = new System.Windows.Forms.ComboBox();
            this.CenterType = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.CenterName = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.CenterName)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.Control;
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button1.Image = global::HealthServicesSystem.Properties.Resources.icons8_downloading_updates_48;
            this.Button1.Location = new System.Drawing.Point(247, 114);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(59, 42);
            this.Button1.TabIndex = 30;
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(14, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(172, 27);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "اسم المؤسسة الصحية :";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Button2
            // 
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button2.Location = new System.Drawing.Point(346, 114);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(59, 42);
            this.Button2.TabIndex = 31;
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CenterTypeId
            // 
            this.CenterTypeId.Location = new System.Drawing.Point(168, 423);
            this.CenterTypeId.Name = "CenterTypeId";
            this.CenterTypeId.Size = new System.Drawing.Size(100, 30);
            this.CenterTypeId.TabIndex = 6;
            this.CenterTypeId.Visible = false;
            // 
            // LocalityId
            // 
            this.LocalityId.Location = new System.Drawing.Point(50, 423);
            this.LocalityId.Name = "LocalityId";
            this.LocalityId.Size = new System.Drawing.Size(100, 30);
            this.LocalityId.TabIndex = 6;
            this.LocalityId.Visible = false;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(14, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(172, 27);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "المحلية :";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // Locality
            // 
            this.Locality.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Locality.FormattingEnabled = true;
            this.Locality.Location = new System.Drawing.Point(189, 45);
            this.Locality.Name = "Locality";
            this.Locality.Size = new System.Drawing.Size(238, 30);
            this.Locality.TabIndex = 1;
            // 
            // CenterType
            // 
            this.CenterType.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CenterType.FormattingEnabled = true;
            this.CenterType.Items.AddRange(new object[] {
            "لايوجد",
            "مركز",
            "مستشفى",
            "وحدة علاجية"});
            this.CenterType.Location = new System.Drawing.Point(189, 78);
            this.CenterType.Name = "CenterType";
            this.CenterType.Size = new System.Drawing.Size(238, 30);
            this.CenterType.TabIndex = 2;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(14, 82);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(172, 27);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "نوع المؤسسة :";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // CenterName
            // 
            this.CenterName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CenterName.DropDownHeight = 95;
            this.CenterName.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CenterName.Location = new System.Drawing.Point(189, 11);
            this.CenterName.Margin = new System.Windows.Forms.Padding(2);
            this.CenterName.Name = "CenterName";
            this.CenterName.Size = new System.Drawing.Size(433, 28);
            this.CenterName.TabIndex = 0;
            // 
            // FrmAddCenter
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(633, 162);
            this.Controls.Add(this.CenterName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CenterType);
            this.Controls.Add(this.Locality);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LocalityId);
            this.Controls.Add(this.CenterTypeId);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddCenter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة/تعديل مؤسسة علاجية";
            this.Load += new System.EventHandler(this.FrmAddCenter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CenterName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
		internal Button Button1;
		internal Label Label1;
		internal Button Button2;
		internal TextBox CenterTypeId;
		internal TextBox LocalityId;
		internal Label Label2;
		internal ComboBox Locality;
		internal ComboBox CenterType;
		internal Label Label5;


		
        internal Telerik.WinControls.UI.RadDropDownList CenterName;
  //      private static FrmAddCenter _DefaultInstance;
  //      public static FrmAddCenter DefaultInstance
		//{
		//	get
		//	{
		//		if (_DefaultInstance == null)
		//			_DefaultInstance = new FrmAddCenter();

		//		return _DefaultInstance;
		//	}
		//}
	}

}