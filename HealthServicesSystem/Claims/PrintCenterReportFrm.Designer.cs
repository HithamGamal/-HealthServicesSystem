namespace HealthServicesSystem.Claims
{
    partial class PrintCenterReportFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SummeryBtn = new Telerik.WinControls.UI.RadButton();
            this.DetailsBtn = new Telerik.WinControls.UI.RadButton();
            this.MasterBtn = new Telerik.WinControls.UI.RadButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SummeryBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 510);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.reportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 453);
            this.panel3.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1001, 453);
            this.reportViewer1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SummeryBtn);
            this.panel2.Controls.Add(this.DetailsBtn);
            this.panel2.Controls.Add(this.MasterBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 57);
            this.panel2.TabIndex = 0;
            // 
            // SummeryBtn
            // 
            this.SummeryBtn.Location = new System.Drawing.Point(107, 12);
            this.SummeryBtn.Name = "SummeryBtn";
            this.SummeryBtn.Size = new System.Drawing.Size(290, 34);
            this.SummeryBtn.TabIndex = 8;
            this.SummeryBtn.Text = "ملخص";
            this.SummeryBtn.Click += new System.EventHandler(this.SummeryBtn_Click);
            // 
            // DetailsBtn
            // 
            this.DetailsBtn.Location = new System.Drawing.Point(403, 12);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(290, 34);
            this.DetailsBtn.TabIndex = 7;
            this.DetailsBtn.Text = "طباعة الادوية";
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // MasterBtn
            // 
            this.MasterBtn.Location = new System.Drawing.Point(699, 12);
            this.MasterBtn.Name = "MasterBtn";
            this.MasterBtn.Size = new System.Drawing.Size(290, 34);
            this.MasterBtn.TabIndex = 6;
            this.MasterBtn.Text = "طباعة المسير";
            this.MasterBtn.Click += new System.EventHandler(this.MasterBtn_Click);
            // 
            // PrintCenterReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 510);
            this.Controls.Add(this.panel1);
            this.Name = "PrintCenterReportFrm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Print Report";
            this.Load += new System.EventHandler(this.PrintCenterReportFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SummeryBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton MasterBtn;
        private Telerik.WinControls.UI.RadButton SummeryBtn;
        private Telerik.WinControls.UI.RadButton DetailsBtn;
    }
}
