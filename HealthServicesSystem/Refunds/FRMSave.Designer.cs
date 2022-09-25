namespace MedicalServiceSystem.Reclaims
{
    partial class FRMSave
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
            this.Label2 = new Telerik.WinControls.UI.RadLabel();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.OPr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Sakkal Majalla", 20.25F);
            this.Label2.ForeColor = System.Drawing.Color.Crimson;
            this.Label2.Location = new System.Drawing.Point(61, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(237, 43);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "لقد تم حفظ البيانات بنجاح";
            this.Label2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Black;
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(119, 153);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(125, 50);
            this.Button1.TabIndex = 3;
            this.Button1.Text = "موافق";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Silver;
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Location = new System.Drawing.Point(1, 1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(382, 31);
            this.PictureBox1.TabIndex = 31;
            this.PictureBox1.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.BackColor = System.Drawing.Color.Silver;
            this.radLabel1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(286, 5);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 25);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "النظام";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // OPr
            // 
            this.OPr.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPr.Location = new System.Drawing.Point(12, 99);
            this.OPr.Name = "OPr";
            this.OPr.Size = new System.Drawing.Size(327, 43);
            this.OPr.TabIndex = 32;
            this.OPr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(351, 262);
            this.Controls.Add(this.OPr);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FRMSave";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMSave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal Telerik.WinControls.UI.RadLabel Label2;
		internal Telerik.WinControls.UI.RadButton Button1;
		internal System.Windows.Forms.PictureBox PictureBox1;

		
        internal Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Label OPr;
  //      private static FRMSave _Default;
  //      public static FRMSave Default
		//{
		//	get
		//	{
		//		if (_Default == null)
		//			_Default = new FRMSave();

		//		return _Default;
		//	}
		//}
	}

}
