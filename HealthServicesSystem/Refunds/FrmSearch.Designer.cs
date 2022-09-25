namespace MedicalServiceSystem.Reclaims
{
    partial class FrmSearch
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.txtname = new Telerik.WinControls.UI.RadTextBox();
            this.GRDSearch = new Telerik.WinControls.UI.RadGridView();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.lstName = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSearch.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(724, 31);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(224, 28);
            this.txtname.TabIndex = 0;
            this.txtname.ThemeName = "Office2010Blue";
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            // 
            // GRDSearch
            // 
            this.GRDSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GRDSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDSearch.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.GRDSearch.ForeColor = System.Drawing.Color.Black;
            this.GRDSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDSearch.Location = new System.Drawing.Point(1, 2);
            // 
            // 
            // 
            this.GRDSearch.MasterTemplate.AllowAddNewRow = false;
            this.GRDSearch.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "Column1";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "InsurNo";
            gridViewTextBoxColumn2.HeaderText = "رقم التأمين";
            gridViewTextBoxColumn2.Name = "Column2";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ReclaimNo";
            gridViewTextBoxColumn3.HeaderText = "رقم العملية";
            gridViewTextBoxColumn3.Name = "Column4";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ReclaimDate";
            gridViewTextBoxColumn4.HeaderText = "التاريخ";
            gridViewTextBoxColumn4.Name = "Column6";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "ReclaimTotal";
            gridViewTextBoxColumn5.HeaderText = "التكلفة";
            gridViewTextBoxColumn5.Name = "Column5";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 120;
            this.GRDSearch.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.GRDSearch.MasterTemplate.EnableFiltering = true;
            this.GRDSearch.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDSearch.Name = "GRDSearch";
            this.GRDSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDSearch.ShowGroupPanel = false;
            this.GRDSearch.Size = new System.Drawing.Size(717, 642);
            this.GRDSearch.TabIndex = 2;
            this.GRDSearch.ThemeName = "Office2010Blue";
            // 
            // Label1
            // 
            this.Label1.AutoSize = false;
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Crimson;
            this.Label1.Location = new System.Drawing.Point(845, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(103, 26);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "ادخل اسم المشترك :";
            this.Label1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lstName
            // 
            this.lstName.FormattingEnabled = true;
            this.lstName.Location = new System.Drawing.Point(724, 65);
            this.lstName.Name = "lstName";
            this.lstName.Size = new System.Drawing.Size(224, 576);
            this.lstName.TabIndex = 4;
            this.lstName.Click += new System.EventHandler(this.LstName_Click_1);
            this.lstName.SelectedIndexChanged += new System.EventHandler(this.LstName_SelectedIndexChanged_1);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 651);
            this.Controls.Add(this.lstName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GRDSearch);
            this.Controls.Add(this.txtname);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بحث";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSearch.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Telerik.WinControls.UI.RadTextBox txtname;
        internal Telerik.WinControls.UI.RadGridView GRDSearch;
        internal Telerik.WinControls.UI.RadLabel Label1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column3;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column4;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column5;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private System.Windows.Forms.ListBox lstName;

        //private static FrmSearch _Default;
        //public static FrmSearch Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmSearch();

        //        return _Default;
        //    }
        //}
    }

}
