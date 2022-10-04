namespace HealthServicesSystem
{
    partial class FrmGenerics
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
            this.GenericName = new Telerik.WinControls.UI.RadDropDownList();
            this.genericlbl = new Telerik.WinControls.UI.RadLabel();
            this.Savebtn = new Telerik.WinControls.UI.RadButton();
            this.GrdGenerics = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Unit = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.GenericName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericlbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Unit)).BeginInit();
            this.SuspendLayout();
            // 
            // GenericName
            // 
            this.GenericName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.GenericName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenericName.Location = new System.Drawing.Point(130, 13);
            this.GenericName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenericName.Name = "GenericName";
            this.GenericName.NullText = "Enter Generic Name";
            this.GenericName.Size = new System.Drawing.Size(463, 24);
            this.GenericName.TabIndex = 1;
            // 
            // genericlbl
            // 
            this.genericlbl.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genericlbl.Location = new System.Drawing.Point(7, 13);
            this.genericlbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genericlbl.Name = "genericlbl";
            this.genericlbl.Size = new System.Drawing.Size(95, 22);
            this.genericlbl.TabIndex = 2;
            this.genericlbl.Text = "Generic Name";
            // 
            // Savebtn
            // 
            this.Savebtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Image = global::HealthServicesSystem.Properties.Resources.icons8_downloading_updates_48;
            this.Savebtn.Location = new System.Drawing.Point(12, 80);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(147, 52);
            this.Savebtn.TabIndex = 2;
            this.Savebtn.Text = "Save";
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // GrdGenerics
            // 
            this.GrdGenerics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdGenerics.BackColor = System.Drawing.SystemColors.Control;
            this.GrdGenerics.Cursor = System.Windows.Forms.Cursors.Default;
            this.GrdGenerics.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdGenerics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdGenerics.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GrdGenerics.Location = new System.Drawing.Point(12, 139);
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
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "GenericName";
            gridViewTextBoxColumn2.HeaderText = "Generic Name";
            gridViewTextBoxColumn2.Name = "GenericName";
            gridViewTextBoxColumn2.Width = 450;
            gridViewTextBoxColumn3.FieldName = "Unit_Name";
            gridViewTextBoxColumn3.HeaderText = "Unit";
            gridViewTextBoxColumn3.Name = "Unit";
            gridViewTextBoxColumn3.Width = 100;
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
            this.GrdGenerics.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn4});
            this.GrdGenerics.MasterTemplate.EnableFiltering = true;
            this.GrdGenerics.MasterTemplate.EnableGrouping = false;
            this.GrdGenerics.MasterTemplate.EnableSorting = false;
            this.GrdGenerics.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GrdGenerics.Name = "GrdGenerics";
            this.GrdGenerics.ReadOnly = true;
            this.GrdGenerics.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrdGenerics.ShowGroupPanel = false;
            this.GrdGenerics.Size = new System.Drawing.Size(869, 289);
            this.GrdGenerics.TabIndex = 15;
            this.GrdGenerics.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GrdGenerics_RowFormatting);
            this.GrdGenerics.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GrdTrades_CellFormatting);
            this.GrdGenerics.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.ItemGrid_CommandCellClick);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::HealthServicesSystem.Properties.Resources.icons8_add_32;
            this.radButton1.Location = new System.Drawing.Point(723, 80);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(147, 52);
            this.radButton1.TabIndex = 16;
            this.radButton1.Text = "New Generic";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(331, 443);
            this.radButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(147, 32);
            this.radButton2.TabIndex = 3;
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(7, 40);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(32, 22);
            this.radLabel1.TabIndex = 18;
            this.radLabel1.Text = "Unit";
            // 
            // Unit
            // 
            this.Unit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Unit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unit.Location = new System.Drawing.Point(130, 40);
            this.Unit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Unit.Name = "Unit";
            this.Unit.NullText = "Choose Unit";
            this.Unit.Size = new System.Drawing.Size(242, 24);
            this.Unit.TabIndex = 17;
            // 
            // FrmGenerics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 488);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Unit);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.GrdGenerics);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.genericlbl);
            this.Controls.Add(this.GenericName);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenerics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewItem";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GenericName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericlbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Savebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdGenerics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Unit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Telerik.WinControls.UI.RadLabel genericlbl;
        public Telerik.WinControls.UI.RadButton Savebtn;
        public Telerik.WinControls.UI.RadDropDownList GenericName;
        public Telerik.WinControls.UI.RadGridView GrdGenerics;
        public Telerik.WinControls.UI.RadButton radButton1;
        public Telerik.WinControls.UI.RadButton radButton2;

        
        public Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadDropDownList Unit;
        //private static FrmGenerics _Default;
        //public static FrmGenerics Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmGenerics();

        //        return _Default;
        //    }
        //}
    }
}