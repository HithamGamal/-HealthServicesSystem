namespace MedicalServiceSystem
{
    partial class FrmGenericLis
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GrdGenerics = new Telerik.WinControls.UI.RadGridView();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdGenerics
            // 
            this.GrdGenerics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdGenerics.BackColor = System.Drawing.SystemColors.Control;
            this.GrdGenerics.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdGenerics.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdGenerics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdGenerics.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdGenerics.Location = new System.Drawing.Point(3, 2);
            this.GrdGenerics.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.GrdGenerics.MasterTemplate.AllowAddNewRow = false;
            this.GrdGenerics.MasterTemplate.AllowColumnReorder = false;
            this.GrdGenerics.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.DataType = typeof(uint);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Generic Code";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 114;
            gridViewTextBoxColumn2.FieldName = "GenericName";
            gridViewTextBoxColumn2.HeaderText = "Generic Name";
            gridViewTextBoxColumn2.Name = "GenericName";
            gridViewTextBoxColumn2.Width = 571;
            gridViewTextBoxColumn3.FieldName = "Unit_Name";
            gridViewTextBoxColumn3.HeaderText = "Unit";
            gridViewTextBoxColumn3.Name = "Unit";
            gridViewTextBoxColumn3.Width = 114;
            this.GrdGenerics.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.GrdGenerics.MasterTemplate.EnableFiltering = true;
            this.GrdGenerics.MasterTemplate.EnableGrouping = false;
            this.GrdGenerics.MasterTemplate.EnableSorting = false;
            this.GrdGenerics.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdGenerics.Name = "GrdGenerics";
            this.GrdGenerics.ReadOnly = true;
            this.GrdGenerics.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrdGenerics.ShowGroupPanel = false;
            this.GrdGenerics.Size = new System.Drawing.Size(879, 500);
            this.GrdGenerics.TabIndex = 15;
            this.GrdGenerics.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdGenerics.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            this.GrdGenerics.Click += new System.EventHandler(this.GrdGenerics_Click);
            this.GrdGenerics.DoubleClick += new System.EventHandler(this.GrdGenerics_DoubleClick);
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(345, 521);
            this.radButton2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(146, 38);
            this.radButton2.TabIndex = 3;
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // FrmGenericLis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 574);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.GrdGenerics);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenericLis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generic List";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Telerik.WinControls.UI.RadGridView GrdGenerics;
        public Telerik.WinControls.UI.RadButton radButton2;

        //private static FrmGenericLis _Default;

        //public static FrmGenericLis Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmGenericLis();

        //        return _Default;
        //    }
        //}
    }
}