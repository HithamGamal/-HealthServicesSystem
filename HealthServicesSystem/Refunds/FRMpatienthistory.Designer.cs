using Telerik.WinControls.UI;

namespace HealthServicesSystem.Reclaims
{
    partial class FRMpatienthistory
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Grid_service = new Telerik.WinControls.UI.RadGridView();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.Totals = new Telerik.WinControls.UI.RadTextBox();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid_service
            // 
            this.Grid_service.AutoScroll = true;
            this.Grid_service.BackColor = System.Drawing.Color.White;
            this.Grid_service.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grid_service.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Grid_service.ForeColor = System.Drawing.Color.Black;
            this.Grid_service.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grid_service.Location = new System.Drawing.Point(0, 268);
            this.Grid_service.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.Grid_service.MasterTemplate.AllowAddNewRow = false;
            this.Grid_service.MasterTemplate.AllowDeleteRow = false;
            gridViewCommandColumn1.HeaderText = "عرض";
            gridViewCommandColumn1.Name = "Show";
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ReclaimNo";
            gridViewTextBoxColumn2.HeaderText = "رقم المعاملة";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "ReclaimNo";
            gridViewTextBoxColumn2.Width = 78;
            gridViewTextBoxColumn3.FieldName = "ApproveCode";
            gridViewTextBoxColumn3.HeaderText = "كود التصديق";
            gridViewTextBoxColumn3.Name = "ApproveCode";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ServiceName";
            gridViewTextBoxColumn4.HeaderText = "الخدمة";
            gridViewTextBoxColumn4.Name = "ServiceName";
            gridViewTextBoxColumn4.Width = 250;
            gridViewTextBoxColumn5.FieldName = "Quantity";
            gridViewTextBoxColumn5.HeaderText = "المطلوب";
            gridViewTextBoxColumn5.Name = "Quantity";
            gridViewTextBoxColumn5.Width = 60;
            gridViewTextBoxColumn6.FieldName = "ApprovedQuantity";
            gridViewTextBoxColumn6.HeaderText = "المصدق";
            gridViewTextBoxColumn6.Name = "ApprovedQuantity";
            gridViewTextBoxColumn6.Width = 60;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Cost";
            gridViewTextBoxColumn7.HeaderText = "التكلفة";
            gridViewTextBoxColumn7.Name = "ReclaimCost";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 78;
            gridViewTextBoxColumn8.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "ReclaimDate";
            gridViewTextBoxColumn8.HeaderText = "التاريخ";
            gridViewTextBoxColumn8.Name = "ReclaimDate";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "UserName";
            gridViewTextBoxColumn9.HeaderText = "الطبيب";
            gridViewTextBoxColumn9.Name = "UserName";
            gridViewTextBoxColumn9.Width = 120;
            gridViewTextBoxColumn10.FieldName = "System";
            gridViewTextBoxColumn10.HeaderText = "النظام";
            gridViewTextBoxColumn10.Name = "column1";
            gridViewTextBoxColumn10.Width = 80;
            gridViewTextBoxColumn11.FieldName = "RequestParty";
            gridViewTextBoxColumn11.HeaderText = "الجهة الطالبة";
            gridViewTextBoxColumn11.Name = "RequestParty";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "ExcuteParty";
            gridViewTextBoxColumn12.HeaderText = "الجهة المنفذة";
            gridViewTextBoxColumn12.Name = "ExcuteParty";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "Atachment";
            gridViewTextBoxColumn13.HeaderText = "ملاحظات";
            gridViewTextBoxColumn13.Name = "Atachment";
            gridViewTextBoxColumn13.Width = 120;
            gridViewTextBoxColumn14.FieldName = "Id";
            gridViewTextBoxColumn14.HeaderText = "column2";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "Id";
            this.Grid_service.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.Grid_service.MasterTemplate.EnableFiltering = true;
            this.Grid_service.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grid_service.Name = "Grid_service";
            this.Grid_service.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grid_service.ShowGroupPanel = false;
            this.Grid_service.Size = new System.Drawing.Size(1294, 270);
            this.Grid_service.TabIndex = 24;
            this.Grid_service.ThemeName = "Office2010Blue";
            this.Grid_service.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.Grid_service_RowFormatting);
            this.Grid_service.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.Grid_service_CommandCellClick);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button1.Location = new System.Drawing.Point(13, 542);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(183, 31);
            this.Button1.TabIndex = 26;
            this.Button1.Text = "رجوع إلى الشاشة السابقة";
            this.Button1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.ThemeName = "Office2010Blue";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Maroon;
            this.Label1.Location = new System.Drawing.Point(446, 547);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 31);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "اجمـــــــالي المبلغ";
            this.Label1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Label1.ThemeName = "Office2010Blue";
            // 
            // Totals
            // 
            this.Totals.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totals.Location = new System.Drawing.Point(256, 544);
            this.Totals.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Totals.Name = "Totals";
            this.Totals.ReadOnly = true;
            this.Totals.Size = new System.Drawing.Size(167, 32);
            this.Totals.TabIndex = 28;
            this.Totals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Totals.ThemeName = "Office2010Blue";
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.BackColor = System.Drawing.Color.White;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 36);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            gridViewCommandColumn2.HeaderText = "عرض";
            gridViewCommandColumn2.Name = "Show";
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.HeaderText = "م";
            gridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn1";
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "ReclaimDate";
            gridViewTextBoxColumn16.HeaderText = "التاريخ";
            gridViewTextBoxColumn16.Name = "ReclaimDate";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 150;
            gridViewTextBoxColumn17.FieldName = "RequestParty";
            gridViewTextBoxColumn17.HeaderText = "الجهة الطالبة";
            gridViewTextBoxColumn17.Name = "RequestParty";
            gridViewTextBoxColumn17.Width = 250;
            gridViewTextBoxColumn18.FieldName = "ExcuteParty";
            gridViewTextBoxColumn18.HeaderText = "الجهة المنفذة";
            gridViewTextBoxColumn18.Name = "ExcuteParty";
            gridViewTextBoxColumn18.Width = 250;
            gridViewTextBoxColumn19.HeaderText = "column1";
            gridViewTextBoxColumn19.IsVisible = false;
            gridViewTextBoxColumn19.Name = "Id";
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn2,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(1294, 196);
            this.radGridView1.TabIndex = 30;
            this.radGridView1.ThemeName = "Office2010Blue";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.RadGridView1_CommandCellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sakkal Majalla", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(1146, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 32);
            this.label2.TabIndex = 31;
            this.label2.Text = "التصاديق المرفوضة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1206, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 32);
            this.label3.TabIndex = 32;
            this.label3.Text = "التصاديق";
            // 
            // FRMpatienthistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1292, 579);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Totals);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Grid_service);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMpatienthistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FRMpatienthistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        internal Telerik.WinControls.UI.RadLabel Label1;
        internal Telerik.WinControls.UI.RadTextBox Totals;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        internal RadGridView radGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        //private static FRMpatienthistory _Default;
        //public static FRMpatienthistory Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMpatienthistory();

        //        return _Default;
        //    }
        //}
    }

}