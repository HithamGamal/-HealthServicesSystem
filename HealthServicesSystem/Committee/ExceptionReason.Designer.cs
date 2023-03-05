namespace HealthServicesSystem.Committee
{
    partial class ExceptionReason
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ExecptionReason = new Telerik.WinControls.UI.RadDropDownList();
            this.CoInsuranceType = new Telerik.WinControls.UI.RadDropDownList();
            this.approveBTN = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ExecptionCost = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecptionReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoInsuranceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.approveBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecptionCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(295, 44);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(90, 24);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "سبب الاستثناء";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(274, 96);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(111, 24);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "قيمة تحمل التأمين";
            // 
            // ExecptionReason
            // 
            this.ExecptionReason.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            radListDataItem1.Text = "استثناء  من المدير العام";
            radListDataItem2.Text = "استثناء مدير الادارة العامة للخدمات الصحية";
            radListDataItem3.Text = "استثناء مدير الخدمات الطبية";
            this.ExecptionReason.Items.Add(radListDataItem1);
            this.ExecptionReason.Items.Add(radListDataItem2);
            this.ExecptionReason.Items.Add(radListDataItem3);
            this.ExecptionReason.Location = new System.Drawing.Point(24, 44);
            this.ExecptionReason.Name = "ExecptionReason";
            this.ExecptionReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExecptionReason.Size = new System.Drawing.Size(245, 25);
            this.ExecptionReason.TabIndex = 2;
            // 
            // CoInsuranceType
            // 
            this.CoInsuranceType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            radListDataItem4.Text = "تحمل كامل";
            radListDataItem5.Text = "تحمل بمبلغ مالي";
            this.CoInsuranceType.Items.Add(radListDataItem4);
            this.CoInsuranceType.Items.Add(radListDataItem5);
            this.CoInsuranceType.Location = new System.Drawing.Point(24, 96);
            this.CoInsuranceType.Name = "CoInsuranceType";
            this.CoInsuranceType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CoInsuranceType.Size = new System.Drawing.Size(245, 25);
            this.CoInsuranceType.TabIndex = 3;
            // 
            // approveBTN
            // 
            this.approveBTN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveBTN.Location = new System.Drawing.Point(137, 205);
            this.approveBTN.Name = "approveBTN";
            this.approveBTN.Size = new System.Drawing.Size(132, 33);
            this.approveBTN.TabIndex = 4;
            this.approveBTN.Text = "موافق";
            this.approveBTN.Click += new System.EventHandler(this.ApproveBTN_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(296, 151);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(89, 24);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = " مبلغ الاستثناء";
            // 
            // ExecptionCost
            // 
            this.ExecptionCost.Enabled = false;
            this.ExecptionCost.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ExecptionCost.Location = new System.Drawing.Point(24, 152);
            this.ExecptionCost.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.ExecptionCost.Name = "ExecptionCost";
            this.ExecptionCost.Size = new System.Drawing.Size(245, 25);
            this.ExecptionCost.TabIndex = 6;
            this.ExecptionCost.TabStop = false;
            this.ExecptionCost.Text = "0";
            this.ExecptionCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExceptionReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 255);
            this.Controls.Add(this.ExecptionCost);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.approveBTN);
            this.Controls.Add(this.CoInsuranceType);
            this.Controls.Add(this.ExecptionReason);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "ExceptionReason";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاستثناء";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.ExceptionReason_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecptionReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoInsuranceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approveBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecptionCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadDropDownList ExecptionReason;
        public Telerik.WinControls.UI.RadDropDownList CoInsuranceType;
        private Telerik.WinControls.UI.RadButton approveBTN;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        public Telerik.WinControls.UI.RadMaskedEditBox ExecptionCost;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
    }
}
