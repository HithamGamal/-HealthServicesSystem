namespace HealthServicesSystem.Reclaims
{
    partial class FrmAddGroup
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
            this.GroupEname = new Telerik.WinControls.UI.RadTextBox();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.GroupAName = new Telerik.WinControls.UI.RadTextBox();
            this.Button2 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.GroupEname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupAName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupEname
            // 
            this.GroupEname.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupEname.Location = new System.Drawing.Point(12, 12);
            this.GroupEname.Name = "GroupEname";
            this.GroupEname.Size = new System.Drawing.Size(378, 28);
            this.GroupEname.TabIndex = 0;
            this.GroupEname.ThemeName = "Office2010Blue";
            // 
            // Button1
            // 
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::HealthServicesSystem.Properties.Resources.icons8_downloading_updates_48;
            this.Button1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1.Location = new System.Drawing.Point(301, 107);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(80, 51);
            this.Button1.TabIndex = 4;
            this.Button1.ThemeName = "Office2010Blue";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.Label1.Location = new System.Drawing.Point(413, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(188, 31);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "اسم المجموعة باللغة الانجليزية :";
            this.Label1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Label1.ThemeName = "Office2010Blue";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F);
            this.Label2.Location = new System.Drawing.Point(413, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(175, 31);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "اسم المجموعة باللغة العربية :";
            this.Label2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Label2.ThemeName = "Office2010Blue";
            // 
            // GroupAName
            // 
            this.GroupAName.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupAName.Location = new System.Drawing.Point(12, 53);
            this.GroupAName.Name = "GroupAName";
            this.GroupAName.Size = new System.Drawing.Size(378, 28);
            this.GroupAName.TabIndex = 1;
            this.GroupAName.ThemeName = "Office2010Blue";
            // 
            // Button2
            // 
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Font = new System.Drawing.Font("Sakkal Majalla", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2.Location = new System.Drawing.Point(215, 107);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(80, 51);
            this.Button2.TabIndex = 5;
            this.Button2.ThemeName = "Office2010Blue";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmAddGroup
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(597, 170);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupAName);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupEname);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAddGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعديل أو اضافة مجموعة للخدمات الطبية";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FrmAddGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GroupEname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupAName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Telerik.WinControls.UI.RadTextBox GroupEname;
        internal Telerik.WinControls.UI.RadButton Button1;
        internal Telerik.WinControls.UI.RadLabel Label1;
        internal Telerik.WinControls.UI.RadLabel Label2;
        internal Telerik.WinControls.UI.RadTextBox GroupAName;
        internal Telerik.WinControls.UI.RadButton Button2;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        //private static FrmAddGroup _Default;

        //public static FrmAddGroup Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FrmAddGroup();

        //        return _Default;
        //    }
        //}
        #endregion
    }

}
