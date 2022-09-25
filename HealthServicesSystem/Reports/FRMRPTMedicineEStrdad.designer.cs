using System;

namespace MedicalServiceSystem
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FRMRPTMedicineEStrdad
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            this.rd_books = new System.Windows.Forms.RadioButton();
            this.GroupControl1 = new System.Windows.Forms.Panel();
            this.DrGrouping = new Telerik.WinControls.UI.RadDropDownList();
            this.ForNum = new System.Windows.Forms.TextBox();
            this.GroupingBy = new Telerik.WinControls.UI.RadDropDownList();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ExcutingParty = new Telerik.WinControls.UI.RadDropDownList();
            this.RequistingParty = new Telerik.WinControls.UI.RadDropDownList();
            this.ApproveReason = new Telerik.WinControls.UI.RadDropDownList();
            this.BillStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.RDDwaCNT = new System.Windows.Forms.RadioButton();
            this.RDServerCNT = new System.Windows.Forms.RadioButton();
            this.RDUser = new System.Windows.Forms.RadioButton();
            this.card_no = new Telerik.WinControls.UI.RadTextBox();
            this.RDPharamcy = new System.Windows.Forms.RadioButton();
            this.RDCenter = new System.Windows.Forms.RadioButton();
            this.RDpharm = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RDpharmacyDetails = new System.Windows.Forms.RadioButton();
            this.RDCenterDetails = new System.Windows.Forms.RadioButton();
            this.RDSubDetails = new System.Windows.Forms.RadioButton();
            this.RDpharmDetails = new System.Windows.Forms.RadioButton();
            this.RdDiosDetails = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GroupControl2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.d_end = new System.Windows.Forms.DateTimePicker();
            this.d_start = new System.Windows.Forms.DateTimePicker();
            this.sector_no = new System.Windows.Forms.TextBox();
            this.RptiewChronics = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupingBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExcutingParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequistingParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_no)).BeginInit();
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
            this.rd_books.Location = new System.Drawing.Point(4, 63);
            this.rd_books.Name = "rd_books";
            this.rd_books.Size = new System.Drawing.Size(598, 34);
            this.rd_books.TabIndex = 0;
            this.rd_books.Text = "تفاصيل الاسترداد";
            this.rd_books.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rd_books.UseVisualStyleBackColor = false;
            this.rd_books.CheckedChanged += new System.EventHandler(this.Rd_books_CheckedChanged);
            // 
            // GroupControl1
            // 
            this.GroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl1.BackColor = System.Drawing.Color.LightGray;
            this.GroupControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupControl1.Controls.Add(this.DrGrouping);
            this.GroupControl1.Controls.Add(this.ForNum);
            this.GroupControl1.Controls.Add(this.GroupingBy);
            this.GroupControl1.Controls.Add(this.radioButton2);
            this.GroupControl1.Controls.Add(this.radioButton1);
            this.GroupControl1.Controls.Add(this.ExcutingParty);
            this.GroupControl1.Controls.Add(this.RequistingParty);
            this.GroupControl1.Controls.Add(this.ApproveReason);
            this.GroupControl1.Controls.Add(this.BillStatus);
            this.GroupControl1.Controls.Add(this.RDDwaCNT);
            this.GroupControl1.Controls.Add(this.RDServerCNT);
            this.GroupControl1.Controls.Add(this.RDUser);
            this.GroupControl1.Controls.Add(this.rd_books);
            this.GroupControl1.Controls.Add(this.card_no);
            this.GroupControl1.Controls.Add(this.RDPharamcy);
            this.GroupControl1.Controls.Add(this.RDCenter);
            this.GroupControl1.Controls.Add(this.RDpharm);
            this.GroupControl1.Controls.Add(this.label1);
            this.GroupControl1.Controls.Add(this.RDpharmacyDetails);
            this.GroupControl1.Controls.Add(this.RDCenterDetails);
            this.GroupControl1.Controls.Add(this.RDSubDetails);
            this.GroupControl1.Controls.Add(this.RDpharmDetails);
            this.GroupControl1.Controls.Add(this.RdDiosDetails);
            this.GroupControl1.Controls.Add(this.label4);
            this.GroupControl1.Controls.Add(this.label8);
            this.GroupControl1.Controls.Add(this.label7);
            this.GroupControl1.Controls.Add(this.label6);
            this.GroupControl1.Controls.Add(this.label5);
            this.GroupControl1.Location = new System.Drawing.Point(751, 2);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(607, 591);
            this.GroupControl1.TabIndex = 40;
            this.GroupControl1.Text = "����� ��������";
            this.GroupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupControl1_Paint);
            // 
            // DrGrouping
            // 
            this.DrGrouping.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "بدون";
            radListDataItem2.Text = "المحليات";
            this.DrGrouping.Items.Add(radListDataItem1);
            this.DrGrouping.Items.Add(radListDataItem2);
            this.DrGrouping.Location = new System.Drawing.Point(81, 271);
            this.DrGrouping.Margin = new System.Windows.Forms.Padding(2);
            this.DrGrouping.Name = "DrGrouping";
            this.DrGrouping.Size = new System.Drawing.Size(86, 28);
            this.DrGrouping.TabIndex = 77;
            // 
            // ForNum
            // 
            this.ForNum.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForNum.Location = new System.Drawing.Point(3, 271);
            this.ForNum.Name = "ForNum";
            this.ForNum.Size = new System.Drawing.Size(48, 30);
            this.ForNum.TabIndex = 76;
            this.ForNum.TextChanged += new System.EventHandler(this.ForNum_TextChanged);
            // 
            // GroupingBy
            // 
            this.GroupingBy.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem3.Text = "التردد";
            radListDataItem4.Text = "التكلفة";
            this.GroupingBy.Items.Add(radListDataItem3);
            this.GroupingBy.Items.Add(radListDataItem4);
            this.GroupingBy.Location = new System.Drawing.Point(230, 272);
            this.GroupingBy.Margin = new System.Windows.Forms.Padding(2);
            this.GroupingBy.Name = "GroupingBy";
            this.GroupingBy.Size = new System.Drawing.Size(82, 28);
            this.GroupingBy.TabIndex = 73;
            this.GroupingBy.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.GroupingBy_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.Purple;
            this.radioButton2.Location = new System.Drawing.Point(3, 515);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(598, 34);
            this.radioButton2.TabIndex = 65;
            this.radioButton2.Text = "مرت بالتأمين /لم تمر بالتأمين";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.BackColor = System.Drawing.Color.AliceBlue;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(2, 551);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(598, 34);
            this.radioButton1.TabIndex = 64;
            this.radioButton1.Text = "مقارنة بين استرداد الخدمة الطبية واسترداد الخدمة الدوائية";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // ExcutingParty
            // 
            this.ExcutingParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ExcutingParty.DropDownHeight = 95;
            this.ExcutingParty.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcutingParty.Location = new System.Drawing.Point(4, 244);
            this.ExcutingParty.Margin = new System.Windows.Forms.Padding(2);
            this.ExcutingParty.Name = "ExcutingParty";
            this.ExcutingParty.NullText = "اختر الجهة المنفذة للخدمة الطبية";
            this.ExcutingParty.Size = new System.Drawing.Size(471, 28);
            this.ExcutingParty.TabIndex = 63;
            // 
            // RequistingParty
            // 
            this.RequistingParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.RequistingParty.DropDownHeight = 95;
            this.RequistingParty.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequistingParty.Location = new System.Drawing.Point(4, 209);
            this.RequistingParty.Margin = new System.Windows.Forms.Padding(2);
            this.RequistingParty.Name = "RequistingParty";
            this.RequistingParty.NullText = "اختر الجهة الطالبة للخدمة الطبية";
            this.RequistingParty.Size = new System.Drawing.Size(471, 28);
            this.RequistingParty.TabIndex = 62;
            // 
            // ApproveReason
            // 
            this.ApproveReason.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproveReason.Location = new System.Drawing.Point(4, 139);
            this.ApproveReason.Margin = new System.Windows.Forms.Padding(2);
            this.ApproveReason.Name = "ApproveReason";
            this.ApproveReason.NullText = "اختر سبب استرداد الخدمة الطبية";
            this.ApproveReason.Size = new System.Drawing.Size(471, 28);
            this.ApproveReason.TabIndex = 61;
            // 
            // BillStatus
            // 
            this.BillStatus.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillStatus.Location = new System.Drawing.Point(4, 174);
            this.BillStatus.Margin = new System.Windows.Forms.Padding(2);
            this.BillStatus.Name = "BillStatus";
            this.BillStatus.NullText = "اختر هل الخدمة مرت بالتأمين أم لا";
            this.BillStatus.Size = new System.Drawing.Size(471, 28);
            this.BillStatus.TabIndex = 60;
            // 
            // RDDwaCNT
            // 
            this.RDDwaCNT.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDDwaCNT.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDDwaCNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDDwaCNT.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDDwaCNT.ForeColor = System.Drawing.Color.Purple;
            this.RDDwaCNT.Location = new System.Drawing.Point(3, 303);
            this.RDDwaCNT.Name = "RDDwaCNT";
            this.RDDwaCNT.Size = new System.Drawing.Size(598, 34);
            this.RDDwaCNT.TabIndex = 59;
            this.RDDwaCNT.Text = "الأدوية";
            this.RDDwaCNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDDwaCNT.UseVisualStyleBackColor = false;
            this.RDDwaCNT.CheckedChanged += new System.EventHandler(this.RDDwaCNT_CheckedChanged);
            // 
            // RDServerCNT
            // 
            this.RDServerCNT.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDServerCNT.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDServerCNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDServerCNT.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDServerCNT.ForeColor = System.Drawing.Color.Purple;
            this.RDServerCNT.Location = new System.Drawing.Point(3, 479);
            this.RDServerCNT.Name = "RDServerCNT";
            this.RDServerCNT.Size = new System.Drawing.Size(598, 34);
            this.RDServerCNT.TabIndex = 58;
            this.RDServerCNT.Text = "المخدمين";
            this.RDServerCNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDServerCNT.UseVisualStyleBackColor = false;
            this.RDServerCNT.CheckedChanged += new System.EventHandler(this.RDServerCNT_CheckedChanged);
            // 
            // RDUser
            // 
            this.RDUser.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDUser.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDUser.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDUser.ForeColor = System.Drawing.Color.Purple;
            this.RDUser.Location = new System.Drawing.Point(3, 338);
            this.RDUser.Name = "RDUser";
            this.RDUser.Size = new System.Drawing.Size(598, 34);
            this.RDUser.TabIndex = 46;
            this.RDUser.Text = "المستخدمون";
            this.RDUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDUser.UseVisualStyleBackColor = false;
            this.RDUser.CheckedChanged += new System.EventHandler(this.RDUser_CheckedChanged);
            // 
            // card_no
            // 
            this.card_no.BackColor = System.Drawing.Color.White;
            this.card_no.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.card_no.ForeColor = System.Drawing.Color.Crimson;
            this.card_no.Location = new System.Drawing.Point(4, 100);
            this.card_no.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.card_no.MaxLength = 20;
            this.card_no.Name = "card_no";
            this.card_no.NullText = "رقم التأمين القديم : 0/1/0/1";
            this.card_no.Size = new System.Drawing.Size(471, 32);
            this.card_no.TabIndex = 57;
            this.card_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.card_no.ThemeName = "Office2010Blue";
            // 
            // RDPharamcy
            // 
            this.RDPharamcy.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDPharamcy.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDPharamcy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDPharamcy.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDPharamcy.ForeColor = System.Drawing.Color.Purple;
            this.RDPharamcy.Location = new System.Drawing.Point(4, 408);
            this.RDPharamcy.Name = "RDPharamcy";
            this.RDPharamcy.Size = new System.Drawing.Size(598, 34);
            this.RDPharamcy.TabIndex = 51;
            this.RDPharamcy.Text = "الجهات المنفذة";
            this.RDPharamcy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDPharamcy.UseVisualStyleBackColor = false;
            this.RDPharamcy.CheckedChanged += new System.EventHandler(this.RDPharamcy_CheckedChanged);
            // 
            // RDCenter
            // 
            this.RDCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDCenter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDCenter.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDCenter.ForeColor = System.Drawing.Color.Purple;
            this.RDCenter.Location = new System.Drawing.Point(4, 443);
            this.RDCenter.Name = "RDCenter";
            this.RDCenter.Size = new System.Drawing.Size(598, 34);
            this.RDCenter.TabIndex = 50;
            this.RDCenter.Text = "الجهات الطالبة";
            this.RDCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDCenter.UseVisualStyleBackColor = false;
            this.RDCenter.CheckedChanged += new System.EventHandler(this.RDCenter_CheckedChanged);
            // 
            // RDpharm
            // 
            this.RDpharm.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDpharm.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDpharm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDpharm.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDpharm.ForeColor = System.Drawing.Color.Purple;
            this.RDpharm.Location = new System.Drawing.Point(4, 373);
            this.RDpharm.Name = "RDpharm";
            this.RDpharm.Size = new System.Drawing.Size(598, 34);
            this.RDpharm.TabIndex = 48;
            this.RDpharm.Text = "أسباب الاسترداد";
            this.RDpharm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDpharm.UseVisualStyleBackColor = false;
            this.RDpharm.CheckedChanged += new System.EventHandler(this.RDpharm_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 35);
            this.label1.TabIndex = 43;
            this.label1.Text = "قائمة التقارير";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RDpharmacyDetails
            // 
            this.RDpharmacyDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDpharmacyDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDpharmacyDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDpharmacyDetails.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDpharmacyDetails.ForeColor = System.Drawing.Color.Purple;
            this.RDpharmacyDetails.Location = new System.Drawing.Point(479, 203);
            this.RDpharmacyDetails.Name = "RDpharmacyDetails";
            this.RDpharmacyDetails.Size = new System.Drawing.Size(123, 34);
            this.RDpharmacyDetails.TabIndex = 7;
            this.RDpharmacyDetails.Text = "الجهة الطالبة";
            this.RDpharmacyDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDpharmacyDetails.UseVisualStyleBackColor = false;
            this.RDpharmacyDetails.CheckedChanged += new System.EventHandler(this.RDBookTYP_CheckedChanged);
            // 
            // RDCenterDetails
            // 
            this.RDCenterDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDCenterDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDCenterDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDCenterDetails.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDCenterDetails.ForeColor = System.Drawing.Color.Purple;
            this.RDCenterDetails.Location = new System.Drawing.Point(479, 238);
            this.RDCenterDetails.Name = "RDCenterDetails";
            this.RDCenterDetails.Size = new System.Drawing.Size(123, 34);
            this.RDCenterDetails.TabIndex = 5;
            this.RDCenterDetails.Text = "الجهة المنفذة";
            this.RDCenterDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDCenterDetails.UseVisualStyleBackColor = false;
            this.RDCenterDetails.CheckedChanged += new System.EventHandler(this.RDUsers_CheckedChanged);
            // 
            // RDSubDetails
            // 
            this.RDSubDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDSubDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDSubDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDSubDetails.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDSubDetails.ForeColor = System.Drawing.Color.Purple;
            this.RDSubDetails.Location = new System.Drawing.Point(479, 98);
            this.RDSubDetails.Name = "RDSubDetails";
            this.RDSubDetails.Size = new System.Drawing.Size(123, 34);
            this.RDSubDetails.TabIndex = 3;
            this.RDSubDetails.Text = "مشترك محدد";
            this.RDSubDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDSubDetails.UseVisualStyleBackColor = false;
            this.RDSubDetails.CheckedChanged += new System.EventHandler(this.Rd_center_CheckedChanged);
            // 
            // RDpharmDetails
            // 
            this.RDpharmDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.RDpharmDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RDpharmDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDpharmDetails.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDpharmDetails.ForeColor = System.Drawing.Color.Purple;
            this.RDpharmDetails.Location = new System.Drawing.Point(479, 168);
            this.RDpharmDetails.Name = "RDpharmDetails";
            this.RDpharmDetails.Size = new System.Drawing.Size(123, 34);
            this.RDpharmDetails.TabIndex = 2;
            this.RDpharmDetails.Text = "نوع الوصفة";
            this.RDpharmDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RDpharmDetails.UseVisualStyleBackColor = false;
            this.RDpharmDetails.CheckedChanged += new System.EventHandler(this.RDLocal_CheckedChanged);
            // 
            // RdDiosDetails
            // 
            this.RdDiosDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.RdDiosDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RdDiosDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RdDiosDetails.Font = new System.Drawing.Font("Sakkal Majalla", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdDiosDetails.ForeColor = System.Drawing.Color.Purple;
            this.RdDiosDetails.Location = new System.Drawing.Point(479, 133);
            this.RdDiosDetails.Name = "RdDiosDetails";
            this.RdDiosDetails.Size = new System.Drawing.Size(123, 34);
            this.RdDiosDetails.TabIndex = 1;
            this.RdDiosDetails.Text = "سبب الاسترداد";
            this.RdDiosDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RdDiosDetails.UseVisualStyleBackColor = false;
            this.RdDiosDetails.CheckedChanged += new System.EventHandler(this.Rd_chronic_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(446, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "تفاصيل الاسترداد حسب :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(46, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 25);
            this.label8.TabIndex = 75;
            this.label8.Text = "لعدد";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(302, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 74;
            this.label7.Text = "تجميع حسب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Purple;
            this.label6.Location = new System.Drawing.Point(163, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 78;
            this.label6.Text = "و حسب :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(381, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 25);
            this.label5.TabIndex = 45;
            this.label5.Text = "تردد وتكلفة استرداد الخدمة الدوائية  :";
            // 
            // GroupControl2
            // 
            this.GroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl2.BackColor = System.Drawing.Color.LightGray;
            this.GroupControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupControl2.Controls.Add(this.textBox1);
            this.GroupControl2.Controls.Add(this.label3);
            this.GroupControl2.Controls.Add(this.label2);
            this.GroupControl2.Controls.Add(this.d_end);
            this.GroupControl2.Controls.Add(this.d_start);
            this.GroupControl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupControl2.ForeColor = System.Drawing.Color.PeachPuff;
            this.GroupControl2.Location = new System.Drawing.Point(2, 2);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(742, 80);
            this.GroupControl2.TabIndex = 41;
            this.GroupControl2.Text = "��� ������";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(615, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 30);
            this.textBox1.TabIndex = 77;
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(200, 11);
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
            this.label2.Location = new System.Drawing.Point(457, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاريخ البداية :";
            // 
            // d_end
            // 
            this.d_end.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_end.Location = new System.Drawing.Point(32, 9);
            this.d_end.Name = "d_end";
            this.d_end.Size = new System.Drawing.Size(162, 34);
            this.d_end.TabIndex = 1;
            // 
            // d_start
            // 
            this.d_start.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_start.Location = new System.Drawing.Point(289, 9);
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
            this.RptiewChronics.Size = new System.Drawing.Size(741, 504);
            this.RptiewChronics.TabIndex = 43;
            // 
            // FRMRPTMedicineEStrdad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1358, 595);
            this.Controls.Add(this.RptiewChronics);
            this.Controls.Add(this.sector_no);
            this.Controls.Add(this.GroupControl2);
            this.Controls.Add(this.GroupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMRPTMedicineEStrdad";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير استرداد الخدمة الدوائية";
            this.ThemeName = "Office2010Blue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.reports_FormClosed);
            this.Load += new System.EventHandler(this.reports_Load);
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupingBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExcutingParty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequistingParty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproveReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_no)).EndInit();
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
        internal System.Windows.Forms.RadioButton RDpharmDetails;
        internal System.Windows.Forms.RadioButton RdDiosDetails;
        internal System.Windows.Forms.RadioButton RDSubDetails;
        internal System.Windows.Forms.TextBox sector_no;
        internal System.Windows.Forms.RadioButton RDCenterDetails;
        internal System.Windows.Forms.RadioButton RDpharmacyDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Telerik.ReportViewer.WinForms.ReportViewer RptiewChronics;
        internal System.Windows.Forms.RadioButton RDPharamcy;
        internal System.Windows.Forms.RadioButton RDCenter;
        internal System.Windows.Forms.RadioButton RDpharm;
        internal System.Windows.Forms.RadioButton RDUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal Telerik.WinControls.UI.RadTextBox card_no;
        internal System.Windows.Forms.RadioButton RDServerCNT;
        internal System.Windows.Forms.RadioButton RDDwaCNT;
        internal Telerik.WinControls.UI.RadDropDownList BillStatus;
        internal Telerik.WinControls.UI.RadDropDownList ApproveReason;
        internal Telerik.WinControls.UI.RadDropDownList RequistingParty;
        internal Telerik.WinControls.UI.RadDropDownList ExcutingParty;
        internal System.Windows.Forms.RadioButton radioButton1;
        internal System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox ForNum;
        private System.Windows.Forms.Label label8;
        internal Telerik.WinControls.UI.RadDropDownList GroupingBy;
        private System.Windows.Forms.Label label7;
        internal Telerik.WinControls.UI.RadDropDownList DrGrouping;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
    }
}