namespace HealthServicesSystem
{
    partial class FrmMedicineOut
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.namelbl = new Telerik.WinControls.UI.RadLabel();
            this.Savebtn = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.IDtxt = new Telerik.WinControls.UI.RadTextBox();
            this.GrdTrades = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.TradeName = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.MaxCost = new System.Windows.Forms.TextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TradeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // namelbl
            // 
            this.namelbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.Location = new System.Drawing.Point(12, 13);
            this.namelbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(105, 31);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Medicine Name";
            // 
            // Savebtn
            // 
            this.Savebtn.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Image = global::HealthServicesSystem.Properties.Resources.icons8_downloading_updates_48;
            this.Savebtn.Location = new System.Drawing.Point(12, 51);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(158, 48);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "Save";
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox1.Location = new System.Drawing.Point(458, 16);
            this.radTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(42, 32);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.Visible = false;
            // 
            // IDtxt
            // 
            this.IDtxt.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDtxt.Location = new System.Drawing.Point(409, 16);
            this.IDtxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IDtxt.Name = "IDtxt";
            this.IDtxt.Size = new System.Drawing.Size(42, 32);
            this.IDtxt.TabIndex = 2;
            this.IDtxt.Visible = false;
            // 
            // GrdTrades
            // 
            this.GrdTrades.BackColor = System.Drawing.SystemColors.Control;
            this.GrdTrades.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdTrades.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdTrades.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdTrades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdTrades.Location = new System.Drawing.Point(12, 106);
            // 
            // 
            // 
            this.GrdTrades.MasterTemplate.AllowAddNewRow = false;
            this.GrdTrades.MasterTemplate.AllowColumnReorder = false;
            this.GrdTrades.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Medicine Code";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "Generic_name";
            gridViewTextBoxColumn2.HeaderText = "Medicine Name";
            gridViewTextBoxColumn2.Name = "Generic_name";
            gridViewTextBoxColumn2.Width = 450;
            gridViewTextBoxColumn3.FieldName = "MaxCost";
            gridViewTextBoxColumn3.HeaderText = "Max Cost";
            gridViewTextBoxColumn3.Name = "MaxCost";
            gridViewTextBoxColumn3.Width = 100;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Edit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.DefaultText = "Enable\\Disable";
            gridViewCommandColumn2.HeaderText = "Enable\\Disable";
            gridViewCommandColumn2.Name = "Delete";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 120;
            gridViewTextBoxColumn4.FieldName = "Activated";
            gridViewTextBoxColumn4.HeaderText = "column1";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "Activated";
            this.GrdTrades.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn4});
            this.GrdTrades.MasterTemplate.EnableFiltering = true;
            this.GrdTrades.MasterTemplate.EnableGrouping = false;
            this.GrdTrades.MasterTemplate.EnableSorting = false;
            this.GrdTrades.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdTrades.Name = "GrdTrades";
            this.GrdTrades.ReadOnly = true;
            this.GrdTrades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrdTrades.ShowGroupPanel = false;
            this.GrdTrades.Size = new System.Drawing.Size(869, 322);
            this.GrdTrades.TabIndex = 15;
            this.GrdTrades.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdTrades.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.radButton1.Location = new System.Drawing.Point(675, 51);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(158, 48);
            this.radButton1.TabIndex = 16;
            this.radButton1.Text = "New Medicine";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // TradeName
            // 
            this.TradeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TradeName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TradeName.Location = new System.Drawing.Point(130, 11);
            this.TradeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TradeName.Name = "TradeName";
            this.TradeName.NullText = "Enter or Choose Medicine name";
            this.TradeName.Size = new System.Drawing.Size(463, 32);
            this.TradeName.TabIndex = 0;
            this.TradeName.TextChanged += new System.EventHandler(this.TradeName_TextChanged);
            this.TradeName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TradeName_SelectedIndexChanged);
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(356, 435);
            this.radButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(128, 50);
            this.radButton2.TabIndex = 3;
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // MaxCost
            // 
            this.MaxCost.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.MaxCost.Location = new System.Drawing.Point(744, 7);
            this.MaxCost.Name = "MaxCost";
            this.MaxCost.Size = new System.Drawing.Size(89, 34);
            this.MaxCost.TabIndex = 17;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(675, 9);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 31);
            this.radLabel1.TabIndex = 18;
            this.radLabel1.Text = "Max Cost";
            // 
            // FrmMedicineOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 488);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.MaxCost);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.TradeName);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GrdTrades);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.namelbl);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMedicineOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewItem";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TradeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
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
        public Telerik.WinControls.UI.RadDropDownList TradeName;
        public Telerik.WinControls.UI.RadButton radButton2;

       
        private System.Windows.Forms.TextBox MaxCost;
        public Telerik.WinControls.UI.RadLabel radLabel1;
        //private static FrmMedicineOut _Default;
        //public static FrmMedicineOut Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmMedicineOut();

        //        return _Default;
        //    }
        //}
    }
}