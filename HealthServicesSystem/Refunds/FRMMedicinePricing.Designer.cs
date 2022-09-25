using Telerik.WinControls.UI;

namespace MedicalServiceSystem.Reclaims
{
    partial class FRMMedicinePricing
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.ListName = new Telerik.WinControls.UI.RadDropDownList();
            this.GRDMedicine = new Telerik.WinControls.UI.RadGridView();
            this.Button4 = new Telerik.WinControls.UI.RadButton();
            this.Button5 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDMedicine.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(20, 9);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(72, 31);
            this.Label1.TabIndex = 433;
            this.Label1.Text = "List Name:";
            this.Label1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Label1.ThemeName = "Office2010Blue";
            // 
            // ListName
            // 
            this.ListName.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListName.Location = new System.Drawing.Point(96, 9);
            this.ListName.Margin = new System.Windows.Forms.Padding(2);
            this.ListName.Name = "ListName";
            this.ListName.Size = new System.Drawing.Size(361, 28);
            this.ListName.TabIndex = 1;
            this.ListName.ThemeName = "Office2010Blue";
            this.ListName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ListName_SelectedIndexChanged);
            // 
            // GRDMedicine
            // 
            this.GRDMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GRDMedicine.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDMedicine.Font = new System.Drawing.Font("Sakkal Majalla", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDMedicine.ForeColor = System.Drawing.Color.Black;
            this.GRDMedicine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDMedicine.Location = new System.Drawing.Point(0, 63);
            // 
            // 
            // 
            this.GRDMedicine.MasterTemplate.AllowAddNewRow = false;
            this.GRDMedicine.MasterTemplate.AllowColumnResize = false;
            gridViewTextBoxColumn12.FieldName = "GenericId";
            gridViewTextBoxColumn12.HeaderText = "No";
            gridViewTextBoxColumn12.Name = "GenericId";
            gridViewTextBoxColumn12.Width = 80;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Id";
            gridViewTextBoxColumn13.HeaderText = "No.";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "Id";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "Generic_name";
            gridViewTextBoxColumn14.HeaderText = "GENERIC NAME, STRENGTH & DOSAGE FORM ";
            gridViewTextBoxColumn14.Name = "Medical";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 250;
            gridViewTextBoxColumn15.HeaderText = "Price";
            gridViewTextBoxColumn15.Name = "Cost";
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Unit_Name";
            gridViewTextBoxColumn16.HeaderText = "UNIT\r\n";
            gridViewTextBoxColumn16.Name = "Unit_Name";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 80;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "PL";
            gridViewTextBoxColumn17.HeaderText = "PL\r\n";
            gridViewTextBoxColumn17.Name = "PL";
            gridViewTextBoxColumn17.Width = 80;
            gridViewTextBoxColumn18.FieldName = "HICKS_DC";
            gridViewTextBoxColumn18.HeaderText = "HICKS_DC";
            gridViewTextBoxColumn18.Name = "HICKS_DC";
            gridViewTextBoxColumn19.FieldName = "NOTE";
            gridViewTextBoxColumn19.HeaderText = "NOTE";
            gridViewTextBoxColumn19.Name = "NOTE";
            gridViewTextBoxColumn19.Width = 150;
            gridViewTextBoxColumn20.FieldName = "DDD";
            gridViewTextBoxColumn20.HeaderText = "DDD";
            gridViewTextBoxColumn20.IsVisible = false;
            gridViewTextBoxColumn20.Name = "DDD";
            gridViewTextBoxColumn20.Width = 80;
            gridViewTextBoxColumn21.FieldName = "U";
            gridViewTextBoxColumn21.HeaderText = "U";
            gridViewTextBoxColumn21.Name = "U";
            gridViewTextBoxColumn21.Width = 80;
            gridViewTextBoxColumn22.FieldName = "Adm_R";
            gridViewTextBoxColumn22.HeaderText = "Adm.R";
            gridViewTextBoxColumn22.Name = "Adm_R";
            gridViewTextBoxColumn22.Width = 80;
            this.GRDMedicine.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22});
            this.GRDMedicine.MasterTemplate.EnableFiltering = true;
            sortDescriptor2.PropertyName = "Edit";
            this.GRDMedicine.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.GRDMedicine.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GRDMedicine.Name = "GRDMedicine";
            this.GRDMedicine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GRDMedicine.ShowGroupPanel = false;
            this.GRDMedicine.Size = new System.Drawing.Size(1046, 506);
            this.GRDMedicine.TabIndex = 0;
            this.GRDMedicine.ThemeName = "Office2010Blue";
            this.GRDMedicine.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GRDMedicine_CellEndEdit);
            this.GRDMedicine.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.GRDMedicine_CommandCellClick);
            // 
            // Button4
            // 
            this.Button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button4.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button4.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button4.Location = new System.Drawing.Point(882, 575);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(148, 44);
            this.Button4.TabIndex = 15;
            this.Button4.Text = "Exit";
            this.Button4.ThemeName = "Office2010Blue";
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button5
            // 
            this.Button5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button5.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Button5.Image = global::HealthServicesSystem.Properties.Resources.icons8_job_32;
            this.Button5.Location = new System.Drawing.Point(872, 7);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(163, 42);
            this.Button5.TabIndex = 4;
            this.Button5.Text = "List Setting";
            this.Button5.ThemeName = "Office2010Blue";
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.radButton1.Image = global::HealthServicesSystem.Properties.Resources.icons8_copy_32;
            this.radButton1.Location = new System.Drawing.Point(489, 7);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(163, 42);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Copy List";
            this.radButton1.ThemeName = "Office2010Blue";
            this.radButton1.Click += new System.EventHandler(this.RadButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radButton2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.radButton2.Image = global::HealthServicesSystem.Properties.Resources.icons8_paste_32;
            this.radButton2.Location = new System.Drawing.Point(683, 7);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(163, 42);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Paste List";
            this.radButton2.ThemeName = "Office2010Blue";
            this.radButton2.Click += new System.EventHandler(this.RadButton2_Click);
            // 
            // FRMMedicinePricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1042, 621);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.GRDMedicine);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ListName);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRMMedicinePricing";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pricing System For Medicine List";
            this.ThemeName = "Office2010Blue";
            this.Activated += new System.EventHandler(this.FRMMedicinePricing_Activated);
            this.Load += new System.EventHandler(this.FRMMedicineSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDMedicine.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Telerik.WinControls.UI.RadLabel Label1;
        internal Telerik.WinControls.UI.RadDropDownList ListName;
        internal Telerik.WinControls.UI.RadGridView GRDMedicine;
        internal Telerik.WinControls.UI.RadButton Button4;
        internal Telerik.WinControls.UI.RadButton Button5;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
       
        internal RadButton radButton1;
        internal RadButton radButton2;
        //private static FRMMedicinePricing _Default;
        //public static FRMMedicinePricing Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMMedicinePricing();

        //        return _Default;
        //    }
        //}
    }


}