namespace HealthServicesSystem
{
    partial class FrmPharmacist
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
            this.GrdTrades = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.PharmacistList = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PharmacistList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // namelbl
            // 
            this.namelbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.Location = new System.Drawing.Point(18, 14);
            this.namelbl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(115, 31);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Pharmacist Name";
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
            // GrdTrades
            // 
            this.GrdTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdTrades.BackColor = System.Drawing.SystemColors.Control;
            this.GrdTrades.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdTrades.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdTrades.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdTrades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdTrades.Location = new System.Drawing.Point(18, 119);
            this.GrdTrades.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.GrdTrades.MasterTemplate.AllowAddNewRow = false;
            this.GrdTrades.MasterTemplate.AllowColumnReorder = false;
            this.GrdTrades.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "pharmacist Code";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 171;
            gridViewTextBoxColumn2.FieldName = "pharmacistName";
            gridViewTextBoxColumn2.HeaderText = "pharmacist Name";
            gridViewTextBoxColumn2.Name = "pharmacistName";
            gridViewTextBoxColumn2.Width = 714;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 71;
            gridViewCommandColumn2.DefaultText = "Delete";
            gridViewCommandColumn2.HeaderText = "Delete";
            gridViewCommandColumn2.Name = "Delete";
            gridViewCommandColumn2.Width = 71;
            gridViewTextBoxColumn3.FieldName = "Activated";
            gridViewTextBoxColumn3.HeaderText = "column1";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "Activated";
            gridViewTextBoxColumn3.Width = 300;
            this.GrdTrades.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn3});
            this.GrdTrades.MasterTemplate.EnableFiltering = true;
            this.GrdTrades.MasterTemplate.EnableGrouping = false;
            this.GrdTrades.MasterTemplate.EnableSorting = false;
            this.GrdTrades.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdTrades.Name = "GrdTrades";
            this.GrdTrades.ReadOnly = true;
            this.GrdTrades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrdTrades.ShowGroupPanel = false;
            this.GrdTrades.Size = new System.Drawing.Size(1241, 360);
            this.GrdTrades.TabIndex = 15;
            this.GrdTrades.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GrdTrades_RowFormatting);
            this.GrdTrades.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdTrades.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
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
            this.radButton1.Text = "New Pharmacist";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // PharmacistList
            // 
            this.PharmacistList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PharmacistList.DropDownHeight = 151;
            this.PharmacistList.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PharmacistList.Location = new System.Drawing.Point(186, 12);
            this.PharmacistList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PharmacistList.Name = "PharmacistList";
            this.PharmacistList.NullText = "Enter or Choose Pharmacist Name";
            this.PharmacistList.Size = new System.Drawing.Size(661, 32);
            this.PharmacistList.TabIndex = 0;
            this.PharmacistList.TextChanged += new System.EventHandler(this.TradeName_TextChanged);
            this.PharmacistList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TradeName_SelectedIndexChanged);
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
            // FrmPharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 545);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.PharmacistList);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GrdTrades);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.namelbl);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPharmacist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Pharmacist";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PharmacistList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadLabel namelbl;
        public Telerik.WinControls.UI.RadButton Savebtn;
        public Telerik.WinControls.UI.RadTextBox radTextBox1;
        public Telerik.WinControls.UI.RadTextBox IDtxt;
        public Telerik.WinControls.UI.RadGridView GrdTrades;
        public Telerik.WinControls.UI.RadButton radButton1;
        public Telerik.WinControls.UI.RadDropDownList PharmacistList;
        public Telerik.WinControls.UI.RadButton radButton2;

        //private static FrmPharmacist _Default;
        //public static FrmPharmacist Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmPharmacist();

        //        return _Default;
        //    }
        //}
    }
}