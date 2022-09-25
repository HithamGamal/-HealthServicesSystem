namespace MedicalServiceSystem.SystemSetting
{
    partial class SystemSettingFRM
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
            this.components = new System.ComponentModel.Container();
            this.LocalityName = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.button1 = new Telerik.WinControls.UI.RadButton();
            this.ServerIP = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LocalityName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // LocalityName
            // 
            this.LocalityName.BackColor = System.Drawing.Color.White;
            this.LocalityName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalityName.ForeColor = System.Drawing.Color.Black;
            this.LocalityName.Location = new System.Drawing.Point(26, 72);
            this.LocalityName.Name = "LocalityName";
            this.LocalityName.Size = new System.Drawing.Size(451, 32);
            this.LocalityName.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(506, 76);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(74, 31);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "مكان العمل";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Black";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(481, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(68, 31);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Server IP :";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Black";
            this.radLabel1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(216, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ServerIP
            // 
            this.ServerIP.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIP.Location = new System.Drawing.Point(24, 3);
            this.ServerIP.MaxLength = 15;
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(451, 32);
            this.ServerIP.TabIndex = 1;
            this.ServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServerIP.Visible = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.Red;
            this.radLabel3.Location = new System.Drawing.Point(260, 41);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(215, 31);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "* الرجاء ادخال المحلية التي تعمل بها\r\n";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // SystemSettingFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 174);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ServerIP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.LocalityName);
            this.Controls.Add(this.radLabel2);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SystemSettingFRM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.SystemSettingFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LocalityName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Telerik.WinControls.UI.RadDropDownList LocalityName;
        internal Telerik.WinControls.UI.RadLabel radLabel2;
        internal Telerik.WinControls.UI.RadLabel radLabel1;
        internal Telerik.WinControls.UI.RadButton button1;
        internal Telerik.WinControls.UI.RadTextBox ServerIP;
        internal Telerik.WinControls.UI.RadLabel radLabel3;
        internal System.Windows.Forms.Timer timer1;

        //private static SystemSettingFRM _Default;
        //public static SystemSettingFRM Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new SystemSettingFRM();

        //        return _Default;
        //    }
        //}
    }
}

