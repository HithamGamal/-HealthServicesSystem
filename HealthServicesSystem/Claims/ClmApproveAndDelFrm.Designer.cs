namespace MedicalServiceSystem.Claims
{
    partial class ClmApproveAndDelFrm
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.ViewBtn = new Telerik.WinControls.UI.RadButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.FileNoLb = new Telerik.WinControls.UI.RadLabel();
            this.ImpNoLb = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ProcessLb = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileNoLb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpNoLb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessLb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(93, 60);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "رقم التصدير";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "رقم الملف";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.FieldName = "CenterName";
            gridViewTextBoxColumn3.HeaderText = "المركز";
            gridViewTextBoxColumn3.Name = "CenterName";
            gridViewTextBoxColumn3.Width = 300;
            gridViewTextBoxColumn4.FieldName = "CenterId";
            gridViewTextBoxColumn4.HeaderText = "رقم المركز";
            gridViewTextBoxColumn4.Name = "CenterId";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 80;
            gridViewTextBoxColumn5.FieldName = "M";
            gridViewTextBoxColumn5.HeaderText = "الشهر";
            gridViewTextBoxColumn5.Name = "M";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 70;
            gridViewTextBoxColumn6.FieldName = "y";
            gridViewTextBoxColumn6.HeaderText = "السنة";
            gridViewTextBoxColumn6.Name = "y";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 70;
            gridViewTextBoxColumn7.FieldName = "VistCount";
            gridViewTextBoxColumn7.HeaderText = "عدد الروشتات";
            gridViewTextBoxColumn7.Name = "VistCount";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "drogCount";
            gridViewTextBoxColumn8.HeaderText = "عدد الادوية";
            gridViewTextBoxColumn8.Name = "drogCount";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 100;
            gridViewCommandColumn1.DefaultText = "تصدير";
            gridViewCommandColumn1.FieldName = "Exp";
            gridViewCommandColumn1.HeaderText = "تصدير";
            gridViewCommandColumn1.Name = "Exp";
            gridViewCommandColumn1.Width = 100;
            gridViewCommandColumn1.WrapText = true;
            gridViewCommandColumn2.DefaultText = "حذف";
            gridViewCommandColumn2.FieldName = "Del";
            gridViewCommandColumn2.HeaderText = "حذف";
            gridViewCommandColumn2.Name = "Del";
            gridViewCommandColumn2.Width = 100;
            gridViewCommandColumn2.WrapText = true;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.MultiSelect = true;
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0} عدد المطلبات المؤقتة :";
            gridViewSummaryItem1.Name = "Id";
            this.radGridView1.MasterTemplate.SummaryRowsTop.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1}));
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView1.Size = new System.Drawing.Size(1126, 326);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.TitleText = "قائمة المراكز المطالبات المؤقتة";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridView1_CommandCellClick);
            // 
            // ViewBtn
            // 
            this.ViewBtn.Location = new System.Drawing.Point(1109, 2);
            this.ViewBtn.Name = "ViewBtn";
            this.ViewBtn.Size = new System.Drawing.Size(110, 36);
            this.ViewBtn.TabIndex = 1;
            this.ViewBtn.Text = "عرض";
            this.ViewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(848, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // FileNoLb
            // 
            this.FileNoLb.Font = new System.Drawing.Font("Sakkal Majalla", 14F, System.Drawing.FontStyle.Bold);
            this.FileNoLb.ForeColor = System.Drawing.Color.Red;
            this.FileNoLb.Location = new System.Drawing.Point(1039, 437);
            this.FileNoLb.Name = "FileNoLb";
            this.FileNoLb.Size = new System.Drawing.Size(17, 30);
            this.FileNoLb.TabIndex = 18;
            this.FileNoLb.Text = "0";
            // 
            // ImpNoLb
            // 
            this.ImpNoLb.Font = new System.Drawing.Font("Sakkal Majalla", 14F, System.Drawing.FontStyle.Bold);
            this.ImpNoLb.ForeColor = System.Drawing.Color.Red;
            this.ImpNoLb.Location = new System.Drawing.Point(1039, 404);
            this.ImpNoLb.Name = "ImpNoLb";
            this.ImpNoLb.Size = new System.Drawing.Size(17, 30);
            this.ImpNoLb.TabIndex = 17;
            this.ImpNoLb.Text = "0";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Sakkal Majalla", 14F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(1129, 437);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(66, 30);
            this.radLabel3.TabIndex = 16;
            this.radLabel3.Text = ":رقم الملف";
            this.radLabel3.Click += new System.EventHandler(this.radLabel3_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Sakkal Majalla", 14F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(1110, 404);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(85, 30);
            this.radLabel2.TabIndex = 15;
            this.radLabel2.Text = ":رقم التصدير";
            this.radLabel2.Click += new System.EventHandler(this.radLabel2_Click);
            // 
            // ProcessLb
            // 
            this.ProcessLb.AutoSize = false;
            this.ProcessLb.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProcessLb.ForeColor = System.Drawing.Color.Red;
            this.ProcessLb.Location = new System.Drawing.Point(947, 5);
            this.ProcessLb.Name = "ProcessLb";
            this.ProcessLb.Size = new System.Drawing.Size(156, 36);
            this.ProcessLb.TabIndex = 19;
            this.ProcessLb.Text = "Process :0%";
            this.ProcessLb.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClmApproveAndDelFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 617);
            this.Controls.Add(this.ProcessLb);
            this.Controls.Add(this.FileNoLb);
            this.Controls.Add(this.ImpNoLb);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ViewBtn);
            this.Controls.Add(this.radGridView1);
            this.Name = "ClmApproveAndDelFrm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "اعتماد حذف المطالبات المؤقتة";
            this.Load += new System.EventHandler(this.ClmApproveAndDelFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileNoLb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpNoLb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessLb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton ViewBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Telerik.WinControls.UI.RadLabel FileNoLb;
        private Telerik.WinControls.UI.RadLabel ImpNoLb;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel ProcessLb;
    }
}
