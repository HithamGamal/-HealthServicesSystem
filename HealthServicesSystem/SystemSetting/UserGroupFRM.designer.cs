using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;
namespace MedicalServiceSystem
{
    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public
     partial class UserGroupFRM : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Diagnostics.DebuggerNonUserCode()]
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupFRM));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.GroupName = new System.Windows.Forms.ComboBox();
            this.PayId = new Telerik.WinControls.UI.RadTextBox();
            this.GroupId = new Telerik.WinControls.UI.RadTextBox();
            this.UserId = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.GRDGroups = new Telerik.WinControls.UI.RadGridView();
            this.SystemName = new System.Windows.Forms.ComboBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroups.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(638, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(77, 26);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "رقم المجموعة :";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Black";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(638, 64);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(81, 26);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "اسم المجموعة :";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel3.ThemeName = "Office2010Black";
            // 
            // radButton4
            // 
            this.radButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton4.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton4.Location = new System.Drawing.Point(314, 548);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(164, 40);
            this.radButton4.TabIndex = 6;
            this.radButton4.Text = "تطبيق";
            this.radButton4.ThemeName = "Breeze";
            this.radButton4.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // GroupName
            // 
            this.GroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.GroupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.GroupName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GroupName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupName.FormattingEnabled = true;
            this.GroupName.Location = new System.Drawing.Point(82, 57);
            this.GroupName.Name = "GroupName";
            this.GroupName.Size = new System.Drawing.Size(544, 33);
            this.GroupName.TabIndex = 1;
            this.GroupName.SelectedIndexChanged += new System.EventHandler(this.CustomerName_SelectedIndexChanged);
            this.GroupName.TextChanged += new System.EventHandler(this.GroupName_TextChanged);
            // 
            // PayId
            // 
            this.PayId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PayId.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayId.Location = new System.Drawing.Point(776, 212);
            this.PayId.Name = "PayId";
            this.PayId.Size = new System.Drawing.Size(150, 24);
            this.PayId.TabIndex = 17;
            this.PayId.ThemeName = "Office2010Black";
            this.PayId.Visible = false;
            // 
            // GroupId
            // 
            this.GroupId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupId.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupId.Location = new System.Drawing.Point(451, 12);
            this.GroupId.Name = "GroupId";
            this.GroupId.Size = new System.Drawing.Size(176, 24);
            this.GroupId.TabIndex = 19;
            this.GroupId.ThemeName = "Office2010Black";
            // 
            // UserId
            // 
            this.UserId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserId.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserId.Location = new System.Drawing.Point(776, 246);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(150, 24);
            this.UserId.TabIndex = 18;
            this.UserId.ThemeName = "Office2010Black";
            this.UserId.Visible = false;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(627, 196);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(164, 40);
            this.radButton1.TabIndex = 7;
            this.radButton1.Text = "حفظ";
            this.radButton1.ThemeName = "Breeze";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // GRDGroups
            // 
            this.GRDGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDGroups.BackColor = System.Drawing.Color.White;
            this.GRDGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDGroups.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDGroups.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GRDGroups.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDGroups.Location = new System.Drawing.Point(12, 242);
            // 
            // 
            // 
            this.GRDGroups.MasterTemplate.AllowAddNewRow = false;
            this.GRDGroups.MasterTemplate.AllowDeleteRow = false;
            this.GRDGroups.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "م";
            gridViewTextBoxColumn7.Name = "ser";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Id";
            gridViewTextBoxColumn8.HeaderText = "Group No";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "GroupId";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "GroupName";
            gridViewTextBoxColumn9.HeaderText = "المجموعة";
            gridViewTextBoxColumn9.Name = "GroupName";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 350;
            gridViewCommandColumn3.DefaultText = "Edit";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.HeaderText = "تعديل";
            gridViewCommandColumn3.Name = "Edit";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 100;
            this.GRDGroups.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn3});
            this.GRDGroups.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.GRDGroups.Name = "GRDGroups";
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.RelationName = "lkj";
            this.GRDGroups.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.GRDGroups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDGroups.ShowGroupPanel = false;
            this.GRDGroups.Size = new System.Drawing.Size(779, 300);
            this.GRDGroups.TabIndex = 84;
            this.GRDGroups.ThemeName = "Breeze";
            this.GRDGroups.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.GRDGroups_CommandCellClick);
            this.GRDGroups.Click += new System.EventHandler(this.GRDGroups_Click);
            // 
            // SystemName
            // 
            this.SystemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SystemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SystemName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SystemName.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemName.FormattingEnabled = true;
            this.SystemName.Location = new System.Drawing.Point(82, 109);
            this.SystemName.Name = "SystemName";
            this.SystemName.Size = new System.Drawing.Size(544, 33);
            this.SystemName.TabIndex = 2;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(638, 109);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(153, 26);
            this.radLabel2.TabIndex = 86;
            this.radLabel2.Text = "النظام الذي تتبع له المجموعة :";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Black";
            // 
            // UserGroupFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 602);
            this.Controls.Add(this.SystemName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.GRDGroups);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.GroupId);
            this.Controls.Add(this.PayId);
            this.Controls.Add(this.GroupName);
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UserGroupFRM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعداد مجموعات المستخدمين";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.CustomerFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroups.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal Telerik.WinControls.UI.RadLabel radLabel1;
        internal Telerik.WinControls.UI.RadLabel radLabel3;
        internal Telerik.WinControls.UI.RadButton radButton4;

        internal Telerik.WinControls.UI.RadTextBox PayId;
        internal Telerik.WinControls.UI.RadTextBox GroupId;
        internal Telerik.WinControls.UI.RadTextBox UserId;
        internal ComboBox GroupName;
        internal Telerik.WinControls.UI.RadButton radButton1;
        internal Telerik.WinControls.UI.RadGridView GRDGroups;
        //private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        
        internal ComboBox SystemName;
        internal Telerik.WinControls.UI.RadLabel radLabel2;
        //public static UserGroupFRM _Default;
        //public static UserGroupFRM Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new UserGroupFRM();

        //        return _Default;
        //    }
        //}
    }
}
