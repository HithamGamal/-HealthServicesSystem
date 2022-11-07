namespace HealthServicesSystem.Refunds
{
    partial class FRMpreviousRequest
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rqstGRID = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rqstGRID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rqstGRID.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rqstGRID
            // 
            this.rqstGRID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rqstGRID.Cursor = System.Windows.Forms.Cursors.Default;
            this.rqstGRID.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rqstGRID.ForeColor = System.Drawing.Color.Black;
            this.rqstGRID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rqstGRID.Location = new System.Drawing.Point(12, 73);
            // 
            // 
            // 
            this.rqstGRID.MasterTemplate.AllowAddNewRow = false;
            this.rqstGRID.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "#";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 117;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "InsurNo";
            gridViewTextBoxColumn2.HeaderText = "رقم التأمين ";
            gridViewTextBoxColumn2.Name = "InsurNo";
            gridViewTextBoxColumn2.Width = 165;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InsurName";
            gridViewTextBoxColumn3.HeaderText = "اسم المريض";
            gridViewTextBoxColumn3.Name = "InsurName";
            gridViewTextBoxColumn3.Width = 216;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "TotalCost";
            gridViewTextBoxColumn4.HeaderText = "تكلفة الفاتورة";
            gridViewTextBoxColumn4.Name = "TotalCost";
            gridViewTextBoxColumn4.Width = 144;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "CenterName";
            gridViewTextBoxColumn5.HeaderText = "المركز";
            gridViewTextBoxColumn5.Name = "CenterName";
            gridViewTextBoxColumn5.Width = 171;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "RequsetType";
            gridViewTextBoxColumn6.HeaderText = "نوع الطلب";
            gridViewTextBoxColumn6.Name = "RequsetType";
            gridViewTextBoxColumn6.Width = 98;
            this.rqstGRID.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rqstGRID.MasterTemplate.EnableFiltering = true;
            this.rqstGRID.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rqstGRID.Name = "rqstGRID";
            this.rqstGRID.ReadOnly = true;
            this.rqstGRID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rqstGRID.Size = new System.Drawing.Size(1070, 458);
            this.rqstGRID.TabIndex = 0;
            this.rqstGRID.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.RqstGRID_CellDoubleClick);
            // 
            // FRMpreviousRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 543);
            this.Controls.Add(this.rqstGRID);
            this.Name = "FRMpreviousRequest";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FRMpreviousRequest";
            this.Load += new System.EventHandler(this.FRMpreviousRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rqstGRID.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rqstGRID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rqstGRID;
    }
}
