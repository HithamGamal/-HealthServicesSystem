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
using Telerik.WinControls.UI;

namespace MedicalServiceSystem
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FrmCenters
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn5 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCenters));
            this.GRDCenter = new Telerik.WinControls.UI.RadGridView();
            this.Button2 = new Telerik.WinControls.UI.RadButton();
            this.GroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.Button3 = new Telerik.WinControls.UI.RadButton();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GRDCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCenter.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Button3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GRDCenter
            // 
            this.GRDCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDCenter.BackColor = System.Drawing.Color.White;
            this.GRDCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDCenter.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDCenter.ForeColor = System.Drawing.Color.Black;
            this.GRDCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDCenter.Location = new System.Drawing.Point(0, 73);
            // 
            // 
            // 
            this.GRDCenter.MasterTemplate.AllowAddNewRow = false;
            this.GRDCenter.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Column1";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 94;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "م";
            gridViewTextBoxColumn2.Name = "Serial";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 54;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "CenterName";
            gridViewTextBoxColumn3.HeaderText = "المؤسسة الصحية";
            gridViewTextBoxColumn3.Name = "CenterName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 350;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CenterTypeId";
            gridViewTextBoxColumn4.HeaderText = "نوع المؤسسة";
            gridViewTextBoxColumn4.Name = "CenterTypeId";
            gridViewTextBoxColumn4.Width = 175;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "HasContract";
            gridViewCheckBoxColumn1.HeaderText = "قائمة التأمين";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "HasContract";
            gridViewCheckBoxColumn1.Width = 109;
            gridViewCheckBoxColumn2.FieldName = "Level1";
            gridViewCheckBoxColumn2.HeaderText = "مستوى أول";
            gridViewCheckBoxColumn2.Name = "Level1";
            gridViewCheckBoxColumn2.Width = 81;
            gridViewCheckBoxColumn3.FieldName = "Level2";
            gridViewCheckBoxColumn3.HeaderText = "مستوى ثاني";
            gridViewCheckBoxColumn3.Name = "Level2";
            gridViewCheckBoxColumn3.Width = 81;
            gridViewCheckBoxColumn4.FieldName = "Level3";
            gridViewCheckBoxColumn4.HeaderText = "مستوى ثالث";
            gridViewCheckBoxColumn4.Name = "Level3";
            gridViewCheckBoxColumn4.Width = 81;
            gridViewCheckBoxColumn5.EnableExpressionEditor = false;
            gridViewCheckBoxColumn5.FieldName = "IsEnabled";
            gridViewCheckBoxColumn5.IsVisible = false;
            gridViewCheckBoxColumn5.MinWidth = 20;
            gridViewCheckBoxColumn5.Name = "IsEnabled";
            gridViewCheckBoxColumn5.Width = 83;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "تعديل";
            gridViewImageColumn1.Name = "BtnEditing";
            gridViewImageColumn1.Width = 85;
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.HeaderText = "حذف";
            gridViewImageColumn2.Name = "BtnDeleting";
            gridViewImageColumn2.Width = 85;
            gridViewTextBoxColumn5.DataType = typeof(bool);
            gridViewTextBoxColumn5.HeaderText = "column1";
            gridViewTextBoxColumn5.Name = "Deleted";
            this.GRDCenter.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3,
            gridViewCheckBoxColumn4,
            gridViewCheckBoxColumn5,
            gridViewImageColumn1,
            gridViewImageColumn2,
            gridViewTextBoxColumn5});
            this.GRDCenter.MasterTemplate.EnableFiltering = true;
            this.GRDCenter.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDCenter.Name = "GRDCenter";
            this.GRDCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDCenter.ShowGroupPanel = false;
            this.GRDCenter.Size = new System.Drawing.Size(1170, 482);
            this.GRDCenter.TabIndex = 10;
            this.GRDCenter.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GRDCenter_RowFormatting);
            this.GRDCenter.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GRDCenter_CellFormatting);
            this.GRDCenter.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GRDGroup_CellClick);
            this.GRDCenter.Click += new System.EventHandler(this.GRDCenter_Click);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.Button2.Location = new System.Drawing.Point(876, 6);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(284, 61);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "اضافة مؤسسة (تأكد من عدم وجود المؤسسة)";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.GRDCenter);
            this.GroupBox1.HeaderText = "";
            this.GroupBox1.Location = new System.Drawing.Point(-3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1170, 560);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Click += new System.EventHandler(this.GroupBox1_Click);
            // 
            // Button3
            // 
            this.Button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button3.BackgroundImage")));
            this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button3.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Button3.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button3.Location = new System.Drawing.Point(5, 6);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(145, 61);
            this.Button3.TabIndex = 5;
            this.Button3.Text = "خروج";
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // FrmCenters
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 560);
            this.Controls.Add(this.GroupBox1);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCenters";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعداد المراكز";
            this.Activated += new System.EventHandler(this.FrmCenters_Activated);
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRDCenter.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Button3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

	}

		internal RadGridView GRDCenter;
		internal RadButton Button2;
		internal GridViewTextBoxColumn Id;
		internal GridViewTextBoxColumn Serial;
		internal GridViewTextBoxColumn CenterName;
		internal GridViewCheckBoxColumn chk;
		internal RadGroupBox GroupBox1;
		internal GridViewImageColumn BtnEditing;
		internal GridViewImageColumn BtnDeleting;
		internal GridViewCheckBoxColumn IsEnabled;
		internal RadButton Button3;
		internal ToolTip ToolTip1;
		internal GridViewTextBoxColumn CenterBelongsTo;
		internal GridViewTextBoxColumn CenterSort;
		internal GridViewTextBoxColumn ServiceState;
		

	
        //private static FrmCenters _Default;
        //public static FrmCenters Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmCenters();

        //        return _Default;
        //    }
        //}
    }

}