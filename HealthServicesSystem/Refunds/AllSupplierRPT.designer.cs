namespace MedicalServiceSystem
{
    partial class SupplierRPT
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.Cost = new Telerik.Reporting.TextBox();
            this.Retail = new Telerik.Reporting.TextBox();
            this.Profit = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.StockName = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.CompanyName = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.SumProfit = new Telerik.Reporting.TextBox();
            this.SumRetail = new Telerik.Reporting.TextBox();
            this.SumCost = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox29,
            this.Cost,
            this.Retail,
            this.Profit,
            this.textBox3});
            this.detailSection1.Name = "detailSection1";
            // 
            // textBox29
            // 
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.4D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox29.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.StyleName = "Normal.TableBody";
            this.textBox29.Value = "=SupplierName";
            // 
            // Cost
            // 
            this.Cost.Format = "{0:N4}";
            this.Cost.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.Cost.Name = "Cost";
            this.Cost.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.Cost.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Cost.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.Cost.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Cost.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Cost.StyleName = "Normal.TableBody";
            this.Cost.Value = "=[CostPrice] ";
            // 
            // Retail
            // 
            this.Retail.Format = "{0:N4}";
            this.Retail.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.4D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.Retail.Name = "Retail";
            this.Retail.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.Retail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.Retail.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Retail.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Retail.StyleName = "Normal.TableBody";
            this.Retail.Value = "= [RetailPrice] ";
            // 
            // Profit
            // 
            this.Profit.Format = "{0:N4}";
            this.Profit.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.2D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.Profit.Name = "Profit";
            this.Profit.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.Profit.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Profit.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.Profit.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Profit.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Profit.StyleName = "Normal.TableBody";
            this.Profit.Value = "=RetailPrice-CostPrice ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.StyleName = "Normal.TableBody";
            this.textBox3.Value = "= RowNumber()";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Bindings.Add(new Telerik.Reporting.Binding("Visible", "=PageNumber>1"));
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.8D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Style.Visible = true;
            this.textBox17.StyleName = "Normal.TableHeader";
            this.textBox17.Value = "Seial";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(3.8D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.4D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox18.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Style.Visible = true;
            this.textBox18.StyleName = "Normal.TableHeader";
            this.textBox18.Value = "Supplier Name";
            // 
            // textBox22
            // 
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7D), Telerik.Reporting.Drawing.Unit.Cm(3.8D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox22.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.StyleName = "Normal.TableHeader";
            this.textBox22.Value = "Actual Total";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.4D), Telerik.Reporting.Drawing.Unit.Cm(3.8D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox23.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox23.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.StyleName = "Normal.TableHeader";
            this.textBox23.Value = "Retail Total";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.2D), Telerik.Reporting.Drawing.Unit.Cm(3.8D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "Profit Total";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.6D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Normal.TableHeader";
            this.textBox7.Value = "Supplier Cost ";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.001D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.299D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "Normal.TableHeader";
            this.textBox10.Value = "Date";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.501D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.299D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "Normal.TableHeader";
            this.textBox11.Value = "Total Cost";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.302D), Telerik.Reporting.Drawing.Unit.Cm(2.001D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.6D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox13.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.StyleName = "Normal.TableBody";
            this.textBox13.Value = "=  Now()";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.501D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.299D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.StyleName = "Normal.TableHeader";
            this.textBox6.Value = "StockName";
            // 
            // StockName
            // 
            this.StockName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.3D), Telerik.Reporting.Drawing.Unit.Cm(1.501D));
            this.StockName.Name = "StockName";
            this.StockName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.598D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.StockName.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.StockName.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.StockName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.StockName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StockName.StyleName = "Normal.TableBody";
            this.StockName.Value = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16D), Telerik.Reporting.Drawing.Unit.Cm(1.7D));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.92D), Telerik.Reporting.Drawing.Unit.Cm(1.5D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pictureBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pictureBox1.Value = "";
            // 
            // CompanyName
            // 
            this.CompanyName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.8D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.CompanyName.Style.BackgroundColor = System.Drawing.Color.White;
            this.CompanyName.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CompanyName.Style.Font.Bold = true;
            this.CompanyName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.CompanyName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.CompanyName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.CompanyName.StyleName = "Normal.TableHeader";
            this.CompanyName.Value = "";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.005D), Telerik.Reporting.Drawing.Unit.Cm(3.001D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.299D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Ridge;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "Normal.TableHeader";
            this.textBox5.Value = "Total Retail";
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:N4}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.305D), Telerik.Reporting.Drawing.Unit.Cm(2.501D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.593D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.StyleName = "Normal.TableBody";
            this.textBox2.Value = "= Sum([CostPrice])";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:N4}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.305D), Telerik.Reporting.Drawing.Unit.Cm(3.001D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.598D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "Normal.TableBody";
            this.textBox4.Value = "=Sum([RetailPrice])";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.9D), Telerik.Reporting.Drawing.Unit.Cm(0.2D));
            this.textBox16.Name = "ReportPageNumberTextBox";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox16.Style.Font.Name = "Sakkal Majalla";
            this.textBox16.Value = "Page: {PageNumber}";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox16});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // SumProfit
            // 
            this.SumProfit.Format = "{0:N4}";
            this.SumProfit.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.205D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.SumProfit.Name = "SumProfit";
            this.SumProfit.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.SumProfit.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.SumProfit.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.SumProfit.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.SumProfit.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SumProfit.StyleName = "Normal.TableBody";
            this.SumProfit.Value = "=Sum(RetailPrice-CostPrice)";
            // 
            // SumRetail
            // 
            this.SumRetail.Format = "{0:N4}";
            this.SumRetail.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.405D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.SumRetail.Name = "SumRetail";
            this.SumRetail.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.SumRetail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.SumRetail.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.SumRetail.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SumRetail.StyleName = "Normal.TableBody";
            this.SumRetail.Value = "=Sum([RetailPrice] )";
            // 
            // SumCost
            // 
            this.SumCost.Format = "{0:N4}";
            this.SumCost.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.705D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.SumCost.Name = "SumCost";
            this.SumCost.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.SumCost.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.SumCost.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.SumCost.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.SumCost.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SumCost.StyleName = "Normal.TableBody";
            this.SumCost.Value = "= Sum(CostPrice)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.005D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Outset;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.StyleName = "Normal.TableHeader";
            this.textBox8.Value = "Total";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(4.3D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.CompanyName,
            this.textBox18,
            this.textBox22,
            this.textBox23,
            this.textBox1,
            this.textBox7,
            this.textBox10,
            this.textBox11,
            this.textBox13,
            this.textBox6,
            this.StockName,
            this.pictureBox1,
            this.textBox17,
            this.textBox5,
            this.textBox2,
            this.textBox4});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.6D);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.SumProfit,
            this.SumRetail,
            this.SumCost});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // SupplierRPT
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detailSection1,
            this.pageHeaderSection1,
            this.pageFooterSection1,
            this.reportHeaderSection1,
            this.reportFooterSection1});
            this.Name = "SupplierRPT";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Normal.TableNormal")});
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Sakkal Majalla";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableBody")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Font.Name = "Sakkal Majalla";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableHeader")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Font.Name = "Sakkal Majalla";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.805D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox Cost;
        private Telerik.Reporting.TextBox Profit;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox13;
        //private Telerik.WinControls.UI.RadReminder radReminder1;
        private System.ComponentModel.IContainer components;
        private Telerik.Reporting.TextBox textBox6;
        internal Telerik.Reporting.TextBox StockName;
        private Telerik.Reporting.TextBox SumProfit;
        private Telerik.Reporting.TextBox SumRetail;
        private Telerik.Reporting.TextBox SumCost;
        private Telerik.Reporting.TextBox textBox8;
        internal Telerik.Reporting.TextBox Retail;
        private Telerik.Reporting.PictureBox pictureBox1;
        internal Telerik.Reporting.TextBox CompanyName;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.ReportFooterSection reportFooterSection1;
    }
}