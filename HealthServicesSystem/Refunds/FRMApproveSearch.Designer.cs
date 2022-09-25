using Telerik.WinControls.UI;

namespace MedicalServiceSystem.Reclaims
{
    partial class FRMApproveSearch
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Grid_service = new Telerik.WinControls.UI.RadGridView();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.card_no = new Telerik.WinControls.UI.RadTextBox();
            this.ApproveCode = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.d_end = new System.Windows.Forms.DateTimePicker();
            this.d_start = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid_service
            // 
            this.Grid_service.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_service.AutoScroll = true;
            this.Grid_service.AutoSizeRows = true;
            this.Grid_service.BackColor = System.Drawing.Color.White;
            this.Grid_service.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grid_service.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Grid_service.ForeColor = System.Drawing.Color.Black;
            this.Grid_service.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grid_service.Location = new System.Drawing.Point(3, 144);
            this.Grid_service.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.Grid_service.MasterTemplate.AllowAddNewRow = false;
            this.Grid_service.MasterTemplate.AllowDeleteRow = false;
            this.Grid_service.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            gridViewTextBoxColumn1.Width = 51;
            gridViewTextBoxColumn2.FieldName = "Row6";
            gridViewTextBoxColumn2.HeaderText = "رقم التأمين";
            gridViewTextBoxColumn2.Name = "InsurNo";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "Row7";
            gridViewTextBoxColumn3.HeaderText = "الاسم";
            gridViewTextBoxColumn3.Name = "InsurName";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "Row19";
            gridViewTextBoxColumn4.HeaderText = "الكود";
            gridViewTextBoxColumn4.Name = "ApproveCode";
            gridViewTextBoxColumn4.Width = 102;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Row18";
            gridViewTextBoxColumn5.HeaderText = "الخدمة";
            gridViewTextBoxColumn5.Name = "ServiceName";
            gridViewTextBoxColumn5.Width = 254;
            gridViewTextBoxColumn6.FieldName = "Row3";
            gridViewTextBoxColumn6.HeaderText = "الكمية المطلوبة";
            gridViewTextBoxColumn6.Name = "Quantity";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.FieldName = "Row3";
            gridViewTextBoxColumn7.HeaderText = "الكمية المصدقة";
            gridViewTextBoxColumn7.Name = "ApprovedQuantity";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Row13";
            gridViewTextBoxColumn8.HeaderText = "التاريخ";
            gridViewTextBoxColumn8.Name = "ReclaimDate";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 102;
            gridViewTextBoxColumn9.FieldName = "Row10";
            gridViewTextBoxColumn9.HeaderText = "الطبيب";
            gridViewTextBoxColumn9.Name = "UserName";
            gridViewTextBoxColumn9.Width = 122;
            gridViewTextBoxColumn10.FieldName = "Row16";
            gridViewTextBoxColumn10.HeaderText = "المركز الطالب";
            gridViewTextBoxColumn10.Name = "RequestParty";
            gridViewTextBoxColumn10.Width = 152;
            gridViewTextBoxColumn11.FieldName = "Row15";
            gridViewTextBoxColumn11.HeaderText = "الصيدلية المنفذة";
            gridViewTextBoxColumn11.Name = "ExcuteParty";
            gridViewTextBoxColumn11.Width = 152;
            gridViewTextBoxColumn12.FieldName = "Row20";
            gridViewTextBoxColumn12.HeaderText = "ملاحظات";
            gridViewTextBoxColumn12.Name = "Atachment";
            gridViewTextBoxColumn12.Width = 121;
            this.Grid_service.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.Grid_service.MasterTemplate.EnableFiltering = true;
            this.Grid_service.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grid_service.Name = "Grid_service";
            this.Grid_service.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grid_service.ShowGroupPanel = false;
            this.Grid_service.Size = new System.Drawing.Size(1340, 98);
            this.Grid_service.TabIndex = 24;
            this.Grid_service.ThemeName = "Office2010Blue";
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::HealthServicesSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button1.Location = new System.Drawing.Point(1165, 537);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(164, 31);
            this.Button1.TabIndex = 26;
            this.Button1.Text = "خروج";
            this.Button1.ThemeName = "Office2010Blue";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // card_no
            // 
            this.card_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.card_no.BackColor = System.Drawing.Color.White;
            this.card_no.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.card_no.ForeColor = System.Drawing.Color.Crimson;
            this.card_no.Location = new System.Drawing.Point(890, 64);
            this.card_no.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.card_no.MaxLength = 20;
            this.card_no.Name = "card_no";
            this.card_no.NullText = "رقم التأمين القديم : 0/1/0/1";
            this.card_no.Size = new System.Drawing.Size(349, 32);
            this.card_no.TabIndex = 58;
            this.card_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.card_no.ThemeName = "Office2010Blue";
            // 
            // ApproveCode
            // 
            this.ApproveCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApproveCode.BackColor = System.Drawing.Color.White;
            this.ApproveCode.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproveCode.ForeColor = System.Drawing.Color.Crimson;
            this.ApproveCode.Location = new System.Drawing.Point(441, 66);
            this.ApproveCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ApproveCode.MaxLength = 20;
            this.ApproveCode.Name = "ApproveCode";
            this.ApproveCode.Size = new System.Drawing.Size(204, 32);
            this.ApproveCode.TabIndex = 59;
            this.ApproveCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ApproveCode.ThemeName = "Office2010Blue";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1244, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 60;
            this.label5.Text = "رقم التأمين";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(650, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "كود التصديق";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::HealthServicesSystem.Properties.Resources.icons8_search_24;
            this.button2.Location = new System.Drawing.Point(801, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 62;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Image = global::HealthServicesSystem.Properties.Resources.icons8_search_24;
            this.button3.Location = new System.Drawing.Point(361, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 63;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(969, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 67;
            this.label3.Text = "تاريخ النهاية :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1244, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 66;
            this.label4.Text = "تاريخ البداية :";
            // 
            // d_end
            // 
            this.d_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_end.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_end.Location = new System.Drawing.Point(801, 7);
            this.d_end.Name = "d_end";
            this.d_end.Size = new System.Drawing.Size(162, 34);
            this.d_end.TabIndex = 65;
            // 
            // d_start
            // 
            this.d_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_start.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_start.Location = new System.Drawing.Point(1076, 7);
            this.d_start.Name = "d_start";
            this.d_start.Size = new System.Drawing.Size(162, 34);
            this.d_start.TabIndex = 64;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Image = global::HealthServicesSystem.Properties.Resources.icons8_search_24;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(12, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 53);
            this.button4.TabIndex = 68;
            this.button4.Text = "بحث جديد";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // FRMApproveSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1342, 579);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.d_end);
            this.Controls.Add(this.d_start);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ApproveCode);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Grid_service);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMApproveSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FRMApproveSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Telerik.WinControls.UI.RadGridView Grid_service;
        internal Telerik.WinControls.UI.RadButton Button1;
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

       
        internal RadTextBox card_no;
        internal RadTextBox ApproveCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker d_end;
        internal System.Windows.Forms.DateTimePicker d_start;
        private System.Windows.Forms.Button button4;
        //private static FRMApproveSearch _Default;
        //public static FRMApproveSearch Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMApproveSearch();

        //        return _Default;
        //    }
        //}
    }

}