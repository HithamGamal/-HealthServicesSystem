using System.Windows.Forms;

namespace HealthServicesSystem.Reclaims
{
    partial class FrmMedicalSubGroup
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GRDSubGroup = new Telerik.WinControls.UI.RadGridView();
            this.TxtGrp = new Telerik.WinControls.UI.RadDropDownList();
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Button2 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.Button4 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSubGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSubGroup.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GRDSubGroup
            // 
            this.GRDSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDSubGroup.BackColor = System.Drawing.Color.White;
            this.GRDSubGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDSubGroup.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.GRDSubGroup.ForeColor = System.Drawing.Color.Black;
            this.GRDSubGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDSubGroup.Location = new System.Drawing.Point(1, 62);
            // 
            // 
            // 
            this.GRDSubGroup.MasterTemplate.AllowAddNewRow = false;
            this.GRDSubGroup.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Column1";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 87;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "م";
            gridViewTextBoxColumn2.Name = "Serial";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 43;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "SubGroupEname";
            gridViewTextBoxColumn3.HeaderText = "اسم المجموعة الفرعية انجليزي";
            gridViewTextBoxColumn3.Name = "SerEName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 221;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "SubgroupAName";
            gridViewTextBoxColumn4.HeaderText = "اسم المجموعة الفرعية عربي";
            gridViewTextBoxColumn4.Name = "SerANAme";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 206;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "Column1";
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Chk";
            gridViewCheckBoxColumn1.Width = 87;
            gridViewImageColumn1.AllowFiltering = false;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "تعديل";
            gridViewImageColumn1.Name = "BtnEditing";
            gridViewImageColumn1.Width = 80;
            gridViewImageColumn2.AllowFiltering = false;
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.HeaderText = "تفعيل/إلغاء تفعيل";
            gridViewImageColumn2.Name = "BtnDeleting";
            gridViewImageColumn2.Width = 120;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "IsEnabled";
            gridViewCheckBoxColumn2.HeaderText = "IsEnabled";
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "IsEnabled";
            gridViewCheckBoxColumn2.Width = 76;
            this.GRDSubGroup.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewImageColumn1,
            gridViewImageColumn2,
            gridViewCheckBoxColumn2});
            this.GRDSubGroup.MasterTemplate.EnableFiltering = true;
            this.GRDSubGroup.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDSubGroup.Name = "GRDSubGroup";
            this.GRDSubGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDSubGroup.ShowGroupPanel = false;
            this.GRDSubGroup.Size = new System.Drawing.Size(882, 487);
            this.GRDSubGroup.TabIndex = 0;
            this.GRDSubGroup.ThemeName = "Office2010Blue";
            this.GRDSubGroup.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GRDSubGroup_CellClick);
            this.GRDSubGroup.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.GRDSubGroup_CommandCellClick_1);
            // 
            // TxtGrp
            // 
            this.TxtGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtGrp.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGrp.Location = new System.Drawing.Point(392, 7);
            this.TxtGrp.Name = "TxtGrp";
            this.TxtGrp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtGrp.Size = new System.Drawing.Size(352, 28);
            this.TxtGrp.TabIndex = 0;
            this.TxtGrp.ThemeName = "Office2010Blue";
            this.ToolTip1.SetToolTip(this.TxtGrp, "المجموعة الرئيسية التابعة لها المجموعة الفرعية");
            this.TxtGrp.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TxtGrp_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.Label2.Location = new System.Drawing.Point(750, 6);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label2.Size = new System.Drawing.Size(119, 31);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "المجموعة الرئيسية :";
            this.Label2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Label2.ThemeName = "Office2010Blue";
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.Button2.Location = new System.Drawing.Point(1, 4);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(276, 42);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "اضاقة مجموعة فرعية للخدمة الطبية";
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
            this.Button4.Location = new System.Drawing.Point(1, 555);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(276, 44);
            this.Button4.TabIndex = 453;
            this.Button4.Text = "خروج";
            this.Button4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Button4.ThemeName = "Office2010Blue";
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // FrmMedicalSubGroup
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(880, 603);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtGrp);
            this.Controls.Add(this.GRDSubGroup);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMedicalSubGroup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادات المجموعة الفرعية للخدمة الطبية";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FrmSubGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRDSubGroup.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSubGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Telerik.WinControls.UI.RadGridView GRDSubGroup;
        internal Telerik.WinControls.UI.RadDropDownList TxtGrp;
        internal Telerik.WinControls.UI.RadLabel Label2;
        internal ToolTip ToolTip1;
        internal Telerik.WinControls.UI.RadButton Button2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Id;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Serial;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerEName;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerANAme;
        internal Telerik.WinControls.UI.GridViewCheckBoxColumn Chk;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnEditing;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnDeleting;
        internal Telerik.WinControls.UI.GridViewCheckBoxColumn IsEnabled;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        
        internal Telerik.WinControls.UI.RadButton Button4;
        //private static FrmMedicalSubGroup _Default;
        //public static FrmMedicalSubGroup Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmMedicalSubGroup();

        //        return _Default;
        //    }
        //}
    }

}