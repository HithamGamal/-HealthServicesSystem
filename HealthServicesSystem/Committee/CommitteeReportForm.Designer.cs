namespace HealthServicesSystem.Committee
{
    partial class CommitteeReportForm
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.DisplayBTN = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ToDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.FromDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.DisplayBTN);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.ToDate);
            this.radGroupBox1.Controls.Add(this.FromDate);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(963, 106);
            this.radGroupBox1.TabIndex = 0;
            // 
            // DisplayBTN
            // 
            this.DisplayBTN.Location = new System.Drawing.Point(187, 52);
            this.DisplayBTN.Name = "DisplayBTN";
            this.DisplayBTN.Size = new System.Drawing.Size(110, 24);
            this.DisplayBTN.TabIndex = 4;
            this.DisplayBTN.Text = "عرض";
            this.DisplayBTN.Click += new System.EventHandler(this.DisplayBTN_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(518, 55);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(55, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "حتى الفترة";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(812, 55);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(70, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "في الفترة من ";
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(333, 53);
            this.ToDate.Name = "ToDate";
            this.ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToDate.Size = new System.Drawing.Size(164, 20);
            this.ToDate.TabIndex = 1;
            this.ToDate.TabStop = false;
            this.ToDate.Text = "2023/03/21";
            this.ToDate.Value = new System.DateTime(2023, 3, 21, 8, 38, 47, 438);
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(628, 53);
            this.FromDate.Name = "FromDate";
            this.FromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FromDate.Size = new System.Drawing.Size(164, 20);
            this.FromDate.TabIndex = 0;
            this.FromDate.TabStop = false;
            this.FromDate.Text = "2023/03/21";
            this.FromDate.Value = new System.DateTime(2023, 3, 21, 8, 38, 47, 438);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.reportViewer1);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 124);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(963, 469);
            this.radGroupBox2.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(2, 18);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(959, 449);
            this.reportViewer1.TabIndex = 0;
            // 
            // CommitteeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 605);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "CommitteeReportForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CommitteeReportForm";
            this.ThemeName = "Office2010Blue";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton DisplayBTN;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker ToDate;
        private Telerik.WinControls.UI.RadDateTimePicker FromDate;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
    }
}
