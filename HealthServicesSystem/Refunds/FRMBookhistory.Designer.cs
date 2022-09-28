using Telerik.WinControls.UI;

namespace HealthServicesSystem.Reclaims
{
    partial class FRMBookhistory
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Grid_service = new Telerik.WinControls.UI.RadGridView();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid_service
            // 
            this.Grid_service.BackColor = System.Drawing.Color.White;
            this.Grid_service.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grid_service.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Grid_service.ForeColor = System.Drawing.Color.Black;
            this.Grid_service.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grid_service.Location = new System.Drawing.Point(2, 0);
            this.Grid_service.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.Grid_service.MasterTemplate.AllowAddNewRow = false;
            this.Grid_service.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "Ser";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "BookNo";
            gridViewTextBoxColumn2.HeaderText = "رقم الدفتر";
            gridViewTextBoxColumn2.Name = "BookNo";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InsurName";
            gridViewTextBoxColumn3.HeaderText = "اسم المشترك";
            gridViewTextBoxColumn3.Name = "InsurName";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "BookDate";
            gridViewTextBoxColumn4.HeaderText = "تاريخ استخراج الدفتر";
            gridViewTextBoxColumn4.Name = "BookDate";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "EndDate";
            gridViewTextBoxColumn5.HeaderText = "تاريخ انتهاء الدفتر";
            gridViewTextBoxColumn5.Name = "EndDate";
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn6.FieldName = "BookType";
            gridViewTextBoxColumn6.HeaderText = "نوع الدفتر";
            gridViewTextBoxColumn6.Name = "BookType";
            gridViewTextBoxColumn6.Width = 100;
            this.Grid_service.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.Grid_service.MasterTemplate.EnableFiltering = true;
            this.Grid_service.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grid_service.Name = "Grid_service";
            this.Grid_service.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grid_service.ShowGroupPanel = false;
            this.Grid_service.Size = new System.Drawing.Size(837, 311);
            this.Grid_service.TabIndex = 24;
            this.Grid_service.ThemeName = "Office2010Blue";
            this.Grid_service.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.Grid_service_RowFormatting);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button1.Location = new System.Drawing.Point(13, 315);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(183, 31);
            this.Button1.TabIndex = 26;
            this.Button1.Text = "رجوع إلى الشاشة السابقة";
            this.Button1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.ThemeName = "Office2010Blue";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FRMBookhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(839, 351);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Grid_service);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMBookhistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FRMBookhistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        internal Telerik.WinControls.UI.RadGridView Grid_service;
        internal Telerik.WinControls.UI.RadButton Button1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column8;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column7;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column9;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;

        //private static FRMBookhistory _Default;
        //public static FRMBookhistory Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMBookhistory();

        //        return _Default;
        //    }
        //}
    }

}