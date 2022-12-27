namespace HealthServicesSystem.Reports
{
    partial class FRMRequests
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.ToDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.FromDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.displayBTN = new Telerik.WinControls.UI.RadButton();
            this.reportName = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.reportViewer1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(841, 680);
            this.radGroupBox1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(2, 18);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(837, 660);
            this.reportViewer1.TabIndex = 0;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.reportName);
            this.radGroupBox2.Controls.Add(this.ToDate);
            this.radGroupBox2.Controls.Add(this.FromDate);
            this.radGroupBox2.Controls.Add(this.displayBTN);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(847, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(436, 666);
            this.radGroupBox2.TabIndex = 1;
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(37, 273);
            this.ToDate.Name = "ToDate";
            this.ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToDate.Size = new System.Drawing.Size(164, 20);
            this.ToDate.TabIndex = 2;
            this.ToDate.TabStop = false;
            this.ToDate.Text = "2022/12/06";
            this.ToDate.Value = new System.DateTime(2022, 12, 6, 8, 54, 52, 666);
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(37, 189);
            this.FromDate.Name = "FromDate";
            this.FromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FromDate.Size = new System.Drawing.Size(164, 20);
            this.FromDate.TabIndex = 1;
            this.FromDate.TabStop = false;
            this.FromDate.Text = "2022/12/06";
            this.FromDate.Value = new System.DateTime(2022, 12, 6, 8, 54, 52, 666);
            // 
            // displayBTN
            // 
            this.displayBTN.Location = new System.Drawing.Point(56, 365);
            this.displayBTN.Name = "displayBTN";
            this.displayBTN.Size = new System.Drawing.Size(145, 44);
            this.displayBTN.TabIndex = 0;
            this.displayBTN.Text = "radButton1";
            this.displayBTN.Click += new System.EventHandler(this.DisplayBTN_Click);
            // 
            // reportName
            // 
            radListDataItem1.Text = "تقرير التردد";
            radListDataItem2.Text = "تقرير التكلفة";
            radListDataItem3.Text = "تقرير الخدمات";
            this.reportName.Items.Add(radListDataItem1);
            this.reportName.Items.Add(radListDataItem2);
            this.reportName.Items.Add(radListDataItem3);
            this.reportName.Location = new System.Drawing.Point(38, 108);
            this.reportName.Name = "reportName";
            this.reportName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportName.Size = new System.Drawing.Size(163, 20);
            this.reportName.TabIndex = 3;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(284, 108);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "التقرير";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(284, 189);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(67, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "في الفترة من";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(284, 275);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(55, 18);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "حتى الفترة";
            // 
            // FRMRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 681);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FRMRequests";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FRMRequests";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton displayBTN;
        private Telerik.WinControls.UI.RadDateTimePicker ToDate;
        private Telerik.WinControls.UI.RadDateTimePicker FromDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList reportName;
    }
}
