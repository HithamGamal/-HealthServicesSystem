using Telerik.WinControls.UI;

namespace HealthServicesSystem.Reclaims
{
    partial class FRMChronicWaitList
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMChronicWaitList));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.AutoScroll = true;
            this.radGridView1.BackColor = System.Drawing.Color.White;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "عرض";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "Show";
            gridViewCommandColumn1.Width = 100;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "PayDate";
            gridViewTextBoxColumn2.HeaderText = "التاريخ";
            gridViewTextBoxColumn2.Name = "PayDate";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InsuranceNo";
            gridViewTextBoxColumn3.HeaderText = "رقم التأمين";
            gridViewTextBoxColumn3.Name = "InsuranceNo";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CustomerName";
            gridViewTextBoxColumn4.HeaderText = "الاســــــــم";
            gridViewTextBoxColumn4.Name = "CustomerName";
            gridViewTextBoxColumn4.Width = 250;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "column1";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "Id";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DocNo";
            gridViewTextBoxColumn6.HeaderText = "رقم الايصال";
            gridViewTextBoxColumn6.Name = "DocNo";
            gridViewTextBoxColumn6.Width = 200;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(1294, 580);
            this.radGridView1.TabIndex = 30;
            this.radGridView1.ThemeName = "Office2010Blue";
            this.radGridView1.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.RadGridView1_CommandCellClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FRMChronicWaitList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1292, 579);
            this.Controls.Add(this.radGridView1);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMChronicWaitList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FRMChronicWaitList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column8;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column7;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column9;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        internal RadGridView radGridView1;
        private System.Windows.Forms.Timer timer1;

        //private static FRMChronicWaitList _Default;
        //public static FRMChronicWaitList Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMChronicWaitList();

        //        return _Default;
        //    }
        //}
    }

}