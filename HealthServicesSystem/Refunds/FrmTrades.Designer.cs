namespace MedicalServiceSystem
{
    partial class FrmTrades
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
            this.Gnamelist = new Telerik.WinControls.UI.RadDropDownList();
            this.genericlbl = new Telerik.WinControls.UI.RadLabel();
            this.Savebtn = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.IDtxt = new Telerik.WinControls.UI.RadTextBox();
            this.GrdTrades = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.TradeName = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gnamelist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericlbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TradeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // namelbl
            // 
            this.namelbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.Location = new System.Drawing.Point(12, 13);
            this.namelbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(83, 31);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Trade Name";
            // 
            // Gnamelist
            // 
            this.Gnamelist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Gnamelist.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gnamelist.Location = new System.Drawing.Point(130, 51);
            this.Gnamelist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gnamelist.Name = "Gnamelist";
            this.Gnamelist.NullText = "Choose Generic";
            this.Gnamelist.Size = new System.Drawing.Size(463, 32);
            this.Gnamelist.TabIndex = 1;
            // 
            // genericlbl
            // 
            this.genericlbl.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genericlbl.Location = new System.Drawing.Point(12, 51);
            this.genericlbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genericlbl.Name = "genericlbl";
            this.genericlbl.Size = new System.Drawing.Size(95, 31);
            this.genericlbl.TabIndex = 2;
            this.genericlbl.Text = "Generic Name";
            // 
            // Savebtn
            // 
            this.Savebtn.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Location = new System.Drawing.Point(12, 90);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(128, 32);
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
            this.GrdTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdTrades.BackColor = System.Drawing.SystemColors.Control;
            this.GrdTrades.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdTrades.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdTrades.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdTrades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdTrades.Location = new System.Drawing.Point(12, 129);
            // 
            // 
            // 
            this.GrdTrades.MasterTemplate.AllowAddNewRow = false;
            this.GrdTrades.MasterTemplate.AllowColumnReorder = false;
            this.GrdTrades.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Trade Code";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "TradeName";
            gridViewTextBoxColumn2.HeaderText = "Trade Name";
            gridViewTextBoxColumn2.Name = "TradeName";
            gridViewTextBoxColumn2.Width = 400;
            gridViewTextBoxColumn3.FieldName = "GenericName";
            gridViewTextBoxColumn3.HeaderText = "Generic Name";
            gridViewTextBoxColumn3.Name = "GenericName";
            gridViewTextBoxColumn3.Width = 400;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Edit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn2.HeaderText = "Delete";
            gridViewCommandColumn2.Name = "Delete";
            gridViewTextBoxColumn4.FieldName = "IsActive";
            gridViewTextBoxColumn4.HeaderText = "column1";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "IsActive";
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
            this.GrdTrades.Size = new System.Drawing.Size(1100, 516);
            this.GrdTrades.TabIndex = 15;
            this.GrdTrades.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GrdTrades_RowFormatting);
            this.GrdTrades.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdTrades.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(747, 90);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(128, 32);
            this.radButton1.TabIndex = 16;
            this.radButton1.Text = "New Trade";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // TradeName
            // 
            this.TradeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TradeName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TradeName.Location = new System.Drawing.Point(130, 11);
            this.TradeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TradeName.Name = "TradeName";
            this.TradeName.NullText = "Enter or Choose Trade name";
            this.TradeName.Size = new System.Drawing.Size(463, 32);
            this.TradeName.TabIndex = 0;
            this.TradeName.TextChanged += new System.EventHandler(this.TradeName_TextChanged);
            this.TradeName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TradeName_SelectedIndexChanged);
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Location = new System.Drawing.Point(12, 647);
            this.radButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(128, 32);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Close";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // FrmTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 682);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.TradeName);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GrdTrades);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.genericlbl);
            this.Controls.Add(this.Gnamelist);
            this.Controls.Add(this.namelbl);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewItem";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namelbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gnamelist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericlbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TradeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadLabel namelbl;
        public Telerik.WinControls.UI.RadLabel genericlbl;
        public Telerik.WinControls.UI.RadButton Savebtn;
        public Telerik.WinControls.UI.RadTextBox radTextBox1;
        public Telerik.WinControls.UI.RadTextBox IDtxt;
        public Telerik.WinControls.UI.RadDropDownList Gnamelist;
        public Telerik.WinControls.UI.RadGridView GrdTrades;
        public Telerik.WinControls.UI.RadButton radButton1;
        public Telerik.WinControls.UI.RadDropDownList TradeName;
        public Telerik.WinControls.UI.RadButton radButton2;

        //private static FrmTrades _Default;
        //public static FrmTrades Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmTrades();

        //        return _Default;
        //    }
        //}
    }
}