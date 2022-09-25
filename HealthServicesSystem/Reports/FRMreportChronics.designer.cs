using System;

namespace MedicalServiceSystem
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FRMreportChronics 
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.rd_books = new System.Windows.Forms.RadioButton();
            this.GroupControl1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RDBookTYP = new System.Windows.Forms.RadioButton();
            this.RDUsers = new System.Windows.Forms.RadioButton();
            this.rd_center = new System.Windows.Forms.RadioButton();
            this.RDLocal = new System.Windows.Forms.RadioButton();
            this.rd_chronic = new System.Windows.Forms.RadioButton();
            this.GroupControl2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.d_end = new System.Windows.Forms.DateTimePicker();
            this.d_start = new System.Windows.Forms.DateTimePicker();
            this.sector_no = new System.Windows.Forms.TextBox();
            this.RptiewChronics = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.GroupControl1.SuspendLayout();
            this.GroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rd_books
            // 
            this.rd_books.Appearance = System.Windows.Forms.Appearance.Button;
            this.rd_books.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rd_books.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_books.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_books.ForeColor = System.Drawing.Color.Purple;
            this.rd_books.Location = new System.Drawing.Point(29, 55);
            this.rd_books.Name = "rd_books";
            this.rd_books.Size = new System.Drawing.Size(279, 38);
            this.rd_books.TabIndex = 0;
            this.rd_books.Text = "تفاصيل الدفاتر المستخرجة";
            this.rd_books.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rd_books.UseVisualStyleBackColor = false;
            this.rd_books.CheckedChanged += new System.EventHandler(this.Rd_books_CheckedChanged);
            // 
            // GroupControl1
            // 
            this.GroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl1.BackColor = System.Drawing.Color.LightGray;
            this.GroupControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupControl1.Controls.Add(this.label1);
            this.GroupControl1.Controls.Add(this.RDBookTYP);
            this.GroupControl1.Controls.Add(this.RDUsers);
            this.GroupControl1.Controls.Add(this.rd_center);
            this.GroupControl1.Controls.Add(this.RDLocal);
            this.GroupControl1.Controls.Add(this.rd_chronic);
            this.GroupControl1.Controls.Add(this.rd_books);
            this.GroupControl1.Location = new System.Drawing.Point(1037, 2);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(321, 613);
            this.GroupControl1.TabIndex = 40;
            this.GroupControl1.Text = "����� ��������";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 35);
            this.label1.TabIndex = 43;
            this.label1.Text = "قائمة التقارير";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RDBookTYP
            // 
            this.RDBookTYP.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDBookTYP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDBookTYP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDBookTYP.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDBookTYP.ForeColor = System.Drawing.Color.Purple;
            this.RDBookTYP.Location = new System.Drawing.Point(29, 215);
            this.RDBookTYP.Name = "RDBookTYP";
            this.RDBookTYP.Size = new System.Drawing.Size(279, 38);
            this.RDBookTYP.TabIndex = 7;
            this.RDBookTYP.Text = "تردد الدفاتر حسب نوع الدفتر";
            this.RDBookTYP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDBookTYP.UseVisualStyleBackColor = false;
            this.RDBookTYP.CheckedChanged += new System.EventHandler(this.RDBookTYP_CheckedChanged);
            // 
            // RDUsers
            // 
            this.RDUsers.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDUsers.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDUsers.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDUsers.ForeColor = System.Drawing.Color.Purple;
            this.RDUsers.Location = new System.Drawing.Point(29, 255);
            this.RDUsers.Name = "RDUsers";
            this.RDUsers.Size = new System.Drawing.Size(279, 38);
            this.RDUsers.TabIndex = 5;
            this.RDUsers.Text = "تردد الدفاتر حسب المستخدم المدخل";
            this.RDUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDUsers.UseVisualStyleBackColor = false;
            this.RDUsers.CheckedChanged += new System.EventHandler(this.RDUsers_CheckedChanged);
            // 
            // rd_center
            // 
            this.rd_center.Appearance = System.Windows.Forms.Appearance.Button;
            this.rd_center.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rd_center.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_center.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_center.ForeColor = System.Drawing.Color.Purple;
            this.rd_center.Location = new System.Drawing.Point(29, 95);
            this.rd_center.Name = "rd_center";
            this.rd_center.Size = new System.Drawing.Size(279, 38);
            this.rd_center.TabIndex = 3;
            this.rd_center.Text = "تردد الدفاتر حسب المراكز";
            this.rd_center.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rd_center.UseVisualStyleBackColor = false;
            this.rd_center.CheckedChanged += new System.EventHandler(this.Rd_center_CheckedChanged);
            // 
            // RDLocal
            // 
            this.RDLocal.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDLocal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDLocal.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDLocal.ForeColor = System.Drawing.Color.Purple;
            this.RDLocal.Location = new System.Drawing.Point(29, 175);
            this.RDLocal.Name = "RDLocal";
            this.RDLocal.Size = new System.Drawing.Size(279, 38);
            this.RDLocal.TabIndex = 2;
            this.RDLocal.Text = "تردد الدفاتر حسب المحلية";
            this.RDLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDLocal.UseVisualStyleBackColor = false;
            this.RDLocal.CheckedChanged += new System.EventHandler(this.RDLocal_CheckedChanged);
            // 
            // rd_chronic
            // 
            this.rd_chronic.Appearance = System.Windows.Forms.Appearance.Button;
            this.rd_chronic.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rd_chronic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_chronic.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_chronic.ForeColor = System.Drawing.Color.Purple;
            this.rd_chronic.Location = new System.Drawing.Point(29, 135);
            this.rd_chronic.Name = "rd_chronic";
            this.rd_chronic.Size = new System.Drawing.Size(279, 38);
            this.rd_chronic.TabIndex = 1;
            this.rd_chronic.Text = "تردد الدفاتر حسب المرض المزمن";
            this.rd_chronic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rd_chronic.UseVisualStyleBackColor = false;
            this.rd_chronic.CheckedChanged += new System.EventHandler(this.Rd_chronic_CheckedChanged);
            // 
            // GroupControl2
            // 
            this.GroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl2.BackColor = System.Drawing.Color.LightGray;
            this.GroupControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupControl2.Controls.Add(this.label3);
            this.GroupControl2.Controls.Add(this.label2);
            this.GroupControl2.Controls.Add(this.d_end);
            this.GroupControl2.Controls.Add(this.d_start);
            this.GroupControl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupControl2.ForeColor = System.Drawing.Color.PeachPuff;
            this.GroupControl2.Location = new System.Drawing.Point(2, 2);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(1029, 80);
            this.GroupControl2.TabIndex = 41;
            this.GroupControl2.Text = "��� ������";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(355, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "تاريخ النهاية :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(725, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاريخ البداية :";
            // 
            // d_end
            // 
            this.d_end.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_end.Location = new System.Drawing.Point(187, 20);
            this.d_end.Name = "d_end";
            this.d_end.Size = new System.Drawing.Size(162, 34);
            this.d_end.TabIndex = 1;
            // 
            // d_start
            // 
            this.d_start.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_start.Location = new System.Drawing.Point(557, 18);
            this.d_start.Name = "d_start";
            this.d_start.Size = new System.Drawing.Size(162, 34);
            this.d_start.TabIndex = 0;
            // 
            // sector_no
            // 
            this.sector_no.Location = new System.Drawing.Point(931, 732);
            this.sector_no.Name = "sector_no";
            this.sector_no.Size = new System.Drawing.Size(100, 20);
            this.sector_no.TabIndex = 42;
            this.sector_no.Visible = false;
            // 
            // RptiewChronics
            // 
            this.RptiewChronics.AccessibilityKeyMap = null;
            this.RptiewChronics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RptiewChronics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RptiewChronics.Location = new System.Drawing.Point(3, 89);
            this.RptiewChronics.Margin = new System.Windows.Forms.Padding(4);
            this.RptiewChronics.Name = "RptiewChronics";
            this.RptiewChronics.Size = new System.Drawing.Size(1028, 526);
            this.RptiewChronics.TabIndex = 43;
            // 
            // FRMreportChronics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1358, 616);
            this.Controls.Add(this.RptiewChronics);
            this.Controls.Add(this.sector_no);
            this.Controls.Add(this.GroupControl2);
            this.Controls.Add(this.GroupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMreportChronics";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير دفاتر الأمراض المزمنة";
            this.ThemeName = "Office2010Blue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.reports_FormClosed);
            this.Load += new System.EventHandler(this.reports_Load);
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl2.ResumeLayout(false);
            this.GroupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.RadioButton rd_books;
        //internal CrystalDecisions.Windows.Forms.CrystalReportViewer crs_show;
        internal System.Windows.Forms.Panel GroupControl1;
        internal System.Windows.Forms.Panel GroupControl2;
        internal System.Windows.Forms.DateTimePicker d_end;
        internal System.Windows.Forms.DateTimePicker d_start;
        internal System.Windows.Forms.RadioButton RDLocal;
        internal System.Windows.Forms.RadioButton rd_chronic;
        internal System.Windows.Forms.RadioButton rd_center;
        internal System.Windows.Forms.TextBox sector_no;
        internal System.Windows.Forms.RadioButton RDUsers;
        internal System.Windows.Forms.RadioButton RDBookTYP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Telerik.ReportViewer.WinForms.ReportViewer RptiewChronics;
    }
}