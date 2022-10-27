using System.Windows.Forms;

namespace HealthServicesSystem.Reclaims
{
    partial class FrmMedicalGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GRDGroup = new Telerik.WinControls.UI.RadGridView();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Button2 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.Button4 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GRDGroup
            // 
            this.GRDGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDGroup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GRDGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDGroup.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.GRDGroup.ForeColor = System.Drawing.Color.Black;
            this.GRDGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDGroup.Location = new System.Drawing.Point(-3, 65);
            // 
            // 
            // 
            this.GRDGroup.MasterTemplate.AllowAddNewRow = false;
            this.GRDGroup.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Column1";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 84;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "م";
            gridViewTextBoxColumn2.Name = "Serial";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 43;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "MainGroupEnglishName";
            gridViewTextBoxColumn3.HeaderText = "اسم المجموعة انجليزي";
            gridViewTextBoxColumn3.Name = "SerEName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "MainGroupArabicName";
            gridViewTextBoxColumn4.HeaderText = "اسم المجموعة عربي";
            gridViewTextBoxColumn4.Name = "SerANAme";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 250;
            gridViewCommandColumn1.HeaderText = "تعديل";
            gridViewCommandColumn1.Image = global::HealthServicesSystem.Properties.Resources.edit;
            gridViewCommandColumn1.Name = "BtnEditing";
            gridViewCommandColumn2.HeaderText = "تفعيل/الغاء تفعيل";
            gridViewCommandColumn2.Image = global::HealthServicesSystem.Properties.Resources.DELETE;
            gridViewCommandColumn2.Name = "BtnDeleting";
            gridViewCommandColumn2.Width = 100;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "IsEnabled";
            gridViewCheckBoxColumn1.HeaderText = "IsEnabled";
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "IsEnabled";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn1.Width = 70;
            this.GRDGroup.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCheckBoxColumn1});
            this.GRDGroup.MasterTemplate.EnableFiltering = true;
            this.GRDGroup.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDGroup.Name = "GRDGroup";
            this.GRDGroup.ReadOnly = true;
            this.GRDGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDGroup.ShowGroupPanel = false;
            this.GRDGroup.Size = new System.Drawing.Size(800, 493);
            this.GRDGroup.TabIndex = 0;
            this.GRDGroup.ThemeName = "Office2010Blue";
            this.GRDGroup.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GRDGroup_CellFormatting);
            this.GRDGroup.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GRDGroup_CellClick);
            this.GRDGroup.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.GRDGroup_CommandCellClick);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Location = new System.Drawing.Point(798, -1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(87, 61);
            this.PictureBox1.TabIndex = 10;
            this.PictureBox1.TabStop = false;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.Button2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.Button2.Location = new System.Drawing.Point(-3, 2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(188, 47);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "اضافة مجموعة جديدة";
            this.Button2.ThemeName = "Office2010Blue";
            this.ToolTip1.SetToolTip(this.Button2, "اضافة مجموعة للمستخدمين");
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button4.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button4.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button4.Location = new System.Drawing.Point(-3, 564);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(188, 44);
            this.Button4.TabIndex = 452;
            this.Button4.Text = "خروج";
            this.Button4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Button4.ThemeName = "Office2010Blue";
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // FrmMedicalGroup
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(795, 610);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.GRDGroup);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMedicalGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = " اعدادات المجموعة الرئيسية للخدمة الطبية";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        internal Telerik.WinControls.UI.RadGridView GRDGroup;
        internal PictureBox PictureBox1;
        internal ToolTip ToolTip1;
        internal Telerik.WinControls.UI.RadButton Button2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Id;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Serial;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerEName;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerANAme;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnEditing;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnDeleting;
        internal Telerik.WinControls.UI.GridViewCheckBoxColumn IsEnabled;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
     
        internal Telerik.WinControls.UI.RadButton Button4;
        //private static FrmMedicalGroup _Default;
        //public static FrmMedicalGroup Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmMedicalGroup();

        //        return _Default;
        //    }
        //}
    }

}