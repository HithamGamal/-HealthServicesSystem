namespace MedicalServiceSystem
{
    partial class FrmMedicineList
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.namelbl = new Telerik.WinControls.UI.RadLabel();
            this.Savebtn = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.IDtxt = new Telerik.WinControls.UI.RadTextBox();
            this.GrdListName = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.ListName = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdListName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdListName.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // namelbl
            // 
            this.namelbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.Location = new System.Drawing.Point(18, 14);
            this.namelbl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(129, 31);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Medicine List Name";
            // 
            // Savebtn
            // 
            this.Savebtn.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Image = global::HealthServicesSystem.Properties.Resources.icons8_usb_connected_32;
            this.Savebtn.Location = new System.Drawing.Point(18, 75);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(182, 36);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "Save";
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox1.Location = new System.Drawing.Point(654, 18);
            this.radTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(60, 32);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.Visible = false;
            // 
            // IDtxt
            // 
            this.IDtxt.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDtxt.Location = new System.Drawing.Point(584, 18);
            this.IDtxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IDtxt.Name = "IDtxt";
            this.IDtxt.Size = new System.Drawing.Size(60, 32);
            this.IDtxt.TabIndex = 2;
            this.IDtxt.Visible = false;
            // 
            // GrdListName
            // 
            this.GrdListName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdListName.BackColor = System.Drawing.SystemColors.Control;
            this.GrdListName.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdListName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdListName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdListName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdListName.Location = new System.Drawing.Point(18, 119);
            this.GrdListName.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.GrdListName.MasterTemplate.AllowAddNewRow = false;
            this.GrdListName.MasterTemplate.AllowColumnReorder = false;
            this.GrdListName.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "List Code";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 171;
            gridViewTextBoxColumn2.FieldName = "ListName";
            gridViewTextBoxColumn2.HeaderText = "List Name";
            gridViewTextBoxColumn2.Name = "ListName";
            gridViewTextBoxColumn2.Width = 714;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 71;
            this.GrdListName.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.GrdListName.MasterTemplate.EnableFiltering = true;
            this.GrdListName.MasterTemplate.EnableGrouping = false;
            this.GrdListName.MasterTemplate.EnableSorting = false;
            this.GrdListName.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdListName.Name = "GrdListName";
            this.GrdListName.ReadOnly = true;
            this.GrdListName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrdListName.ShowGroupPanel = false;
            this.GrdListName.Size = new System.Drawing.Size(1241, 360);
            this.GrdListName.TabIndex = 15;
            this.GrdListName.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GrdTrades_RowFormatting);
            this.GrdListName.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdListName.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.radButton1.Location = new System.Drawing.Point(1060, 75);
            this.radButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(182, 36);
            this.radButton1.TabIndex = 16;
            this.radButton1.Text = "New List";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // ListName
            // 
            this.ListName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ListName.DropDownHeight = 151;
            this.ListName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListName.Location = new System.Drawing.Point(186, 12);
            this.ListName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListName.Name = "ListName";
            this.ListName.NullText = "Enter or Choose List Name";
            this.ListName.Size = new System.Drawing.Size(661, 32);
            this.ListName.TabIndex = 0;
            this.ListName.TextChanged += new System.EventHandler(this.TradeName_TextChanged);
            this.ListName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TradeName_SelectedIndexChanged);
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.radButton2.Location = new System.Drawing.Point(1060, 495);
            this.radButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(182, 36);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Close";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // FrmMedicineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 545);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.ListName);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GrdListName);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.namelbl);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMedicineList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Medicine List";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdListName.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdListName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadLabel namelbl;
        public Telerik.WinControls.UI.RadButton Savebtn;
        public Telerik.WinControls.UI.RadTextBox radTextBox1;
        public Telerik.WinControls.UI.RadTextBox IDtxt;
        public Telerik.WinControls.UI.RadGridView GrdListName;
        public Telerik.WinControls.UI.RadButton radButton1;
        public Telerik.WinControls.UI.RadDropDownList ListName;
        public Telerik.WinControls.UI.RadButton radButton2;

        //private static FrmMedicineList _Default;
        //public static FrmMedicineList Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmMedicineList();

        //        return _Default;
        //    }
        //}
    }
}