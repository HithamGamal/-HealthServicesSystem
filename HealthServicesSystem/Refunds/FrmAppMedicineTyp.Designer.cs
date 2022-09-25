namespace MedicalServiceSystem
{
    partial class FrmAppMedicineTyp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.namelbl = new Telerik.WinControls.UI.RadLabel();
            this.Savebtn = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.IDtxt = new Telerik.WinControls.UI.RadTextBox();
            this.GRDApproveType = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.ApproveType = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDApproveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDApproveType.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // namelbl
            // 
            this.namelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.namelbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.Location = new System.Drawing.Point(682, 14);
            this.namelbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(82, 31);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "نوع التصديق";
            this.namelbl.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // Savebtn
            // 
            this.Savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Savebtn.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Image = global::HealthServicesSystem.Properties.Resources.icons8_downloading_updates_48;
            this.Savebtn.Location = new System.Drawing.Point(10, 76);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(160, 52);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "حفظ";
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox1.Location = new System.Drawing.Point(91, 14);
            this.radTextBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(36, 32);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.Visible = false;
            // 
            // IDtxt
            // 
            this.IDtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IDtxt.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDtxt.Location = new System.Drawing.Point(49, 14);
            this.IDtxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.IDtxt.Name = "IDtxt";
            this.IDtxt.Size = new System.Drawing.Size(36, 32);
            this.IDtxt.TabIndex = 2;
            this.IDtxt.Visible = false;
            // 
            // GRDApproveType
            // 
            this.GRDApproveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDApproveType.BackColor = System.Drawing.SystemColors.Control;
            this.GRDApproveType.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDApproveType.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDApproveType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GRDApproveType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDApproveType.Location = new System.Drawing.Point(10, 137);
            this.GRDApproveType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.GRDApproveType.MasterTemplate.AllowAddNewRow = false;
            this.GRDApproveType.MasterTemplate.AllowColumnReorder = false;
            this.GRDApproveType.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "الكود";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 86;
            gridViewTextBoxColumn2.FieldName = "ApproveType";
            gridViewTextBoxColumn2.HeaderText = "نوع التصديق";
            gridViewTextBoxColumn2.Name = "ApproveType";
            gridViewTextBoxColumn2.Width = 429;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Edit";
            gridViewCommandColumn1.HeaderText = "تعديل";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 43;
            gridViewCommandColumn2.HeaderText = "حذف";
            gridViewCommandColumn2.Name = "Delete";
            gridViewCommandColumn2.Width = 43;
            gridViewTextBoxColumn3.FieldName = "Activated";
            gridViewTextBoxColumn3.HeaderText = "column1";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "Activated";
            this.GRDApproveType.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn3});
            this.GRDApproveType.MasterTemplate.EnableFiltering = true;
            this.GRDApproveType.MasterTemplate.EnableGrouping = false;
            this.GRDApproveType.MasterTemplate.EnableSorting = false;
            this.GRDApproveType.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDApproveType.Name = "GRDApproveType";
            this.GRDApproveType.ReadOnly = true;
            this.GRDApproveType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDApproveType.ShowGroupPanel = false;
            this.GRDApproveType.Size = new System.Drawing.Size(776, 417);
            this.GRDApproveType.TabIndex = 15;
            this.GRDApproveType.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GRDApproveType_RowFormatting);
            this.GRDApproveType.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GRDApproveType.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            this.GRDApproveType.Click += new System.EventHandler(this.GrdTrades_Click);
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.radButton1.Location = new System.Drawing.Point(615, 76);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(160, 52);
            this.radButton1.TabIndex = 16;
            this.radButton1.Text = "تصديق جديد";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // ApproveType
            // 
            this.ApproveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApproveType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ApproveType.DropDownHeight = 91;
            this.ApproveType.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproveType.Location = new System.Drawing.Point(279, 14);
            this.ApproveType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ApproveType.Name = "ApproveType";
            this.ApproveType.Size = new System.Drawing.Size(397, 32);
            this.ApproveType.TabIndex = 0;
            this.ApproveType.TextChanged += new System.EventHandler(this.TradeName_TextChanged);
            this.ApproveType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TradeName_SelectedIndexChanged);
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(310, 563);
            this.radButton2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 55);
            this.radButton2.TabIndex = 3;
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // FrmAppMedicineTyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 632);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.ApproveType);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GRDApproveType);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.namelbl);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppMedicineTyp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أنواع تصديق الأدوية";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDApproveType.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDApproveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadLabel namelbl;
        public Telerik.WinControls.UI.RadButton Savebtn;
        public Telerik.WinControls.UI.RadTextBox radTextBox1;
        public Telerik.WinControls.UI.RadTextBox IDtxt;
        public Telerik.WinControls.UI.RadGridView GRDApproveType;
        public Telerik.WinControls.UI.RadButton radButton1;
        public Telerik.WinControls.UI.RadDropDownList ApproveType;
        public Telerik.WinControls.UI.RadButton radButton2;

        //private static FrmAppMedicineTyp _Default;
        //public static FrmAppMedicineTyp Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmAppMedicineTyp();

        //        return _Default;
        //    }
        //}
    }
}