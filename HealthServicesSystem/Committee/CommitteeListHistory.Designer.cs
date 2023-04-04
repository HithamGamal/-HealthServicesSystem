namespace HealthServicesSystem.Committee
{
    partial class CommitteeListHistory
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

        #region Windows Form Designer generated code

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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.serviceListGRD = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceListGRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceListGRD.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.serviceListGRD);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1135, 430);
            this.radGroupBox1.TabIndex = 0;
            // 
            // serviceListGRD
            // 
            this.serviceListGRD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.serviceListGRD.Cursor = System.Windows.Forms.Cursors.Default;
            this.serviceListGRD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceListGRD.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.serviceListGRD.ForeColor = System.Drawing.Color.Black;
            this.serviceListGRD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serviceListGRD.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.serviceListGRD.MasterTemplate.AllowAddNewRow = false;
            this.serviceListGRD.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "DateIn";
            gridViewTextBoxColumn1.HeaderText = "تاريخ الطلب";
            gridViewTextBoxColumn1.Name = "DateIn";
            gridViewTextBoxColumn1.Width = 74;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Service_Name";
            gridViewTextBoxColumn2.HeaderText = "الخدمة";
            gridViewTextBoxColumn2.Name = "Service_Name";
            gridViewTextBoxColumn2.Width = 235;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "CenterName";
            gridViewTextBoxColumn3.HeaderText = "المركز المقدم للخدمة";
            gridViewTextBoxColumn3.Name = "CenterName";
            gridViewTextBoxColumn3.Width = 192;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CoInsurance";
            gridViewTextBoxColumn4.HeaderText = "نوع الطلب";
            gridViewTextBoxColumn4.Name = "CoInsurance";
            gridViewTextBoxColumn4.Width = 132;
            gridViewTextBoxColumn5.DataType = typeof(decimal);
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Pat_cost";
            gridViewTextBoxColumn5.HeaderText = "تحمل المريض";
            gridViewTextBoxColumn5.Name = "Pat_cost";
            gridViewTextBoxColumn5.Width = 130;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Insur_cost";
            gridViewTextBoxColumn6.HeaderText = "تحمل التأمين";
            gridViewTextBoxColumn6.Name = "Insur_cost";
            gridViewTextBoxColumn6.Width = 106;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ServiceCost";
            gridViewTextBoxColumn7.HeaderText = "تكلفة الخدمة";
            gridViewTextBoxColumn7.Name = "ServiceCost";
            gridViewTextBoxColumn7.Width = 101;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Co_cost";
            gridViewTextBoxColumn8.HeaderText = "المساهمة";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Co_cost";
            gridViewTextBoxColumn8.Width = 83;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "InvoiceCost";
            gridViewTextBoxColumn9.HeaderText = "تكلفة الفاتورة";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "InvoiceCost";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "AllowCost";
            gridViewTextBoxColumn10.HeaderText = "تحمل اضافي";
            gridViewTextBoxColumn10.Name = "AllowCost";
            gridViewTextBoxColumn10.Width = 82;
            this.serviceListGRD.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.serviceListGRD.MasterTemplate.EnableGrouping = false;
            this.serviceListGRD.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.serviceListGRD.Name = "serviceListGRD";
            this.serviceListGRD.ReadOnly = true;
            this.serviceListGRD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.serviceListGRD.Size = new System.Drawing.Size(1131, 410);
            this.serviceListGRD.TabIndex = 0;
            // 
            // CommitteeListHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 447);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "CommitteeListHistory";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفاصيل الخدمات السابقة";
            this.Load += new System.EventHandler(this.CommitteeListHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceListGRD.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceListGRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView serviceListGRD;
    }
}
