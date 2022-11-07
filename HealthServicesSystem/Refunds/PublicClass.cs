using System;
using System.Data.SqlClient;
using System.Net;
using ModelDB;
using System.Linq;

internal static class PLC
{
	static dbContext db=new dbContext() ;
	public static SqlConnection conClame = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=cntr;User ID=sa;Password=123;Trusted_Connection=False");
	public static SqlConnection conNew = new SqlConnection("Data Source=192.168.100.10;Initial Catalog=InsuranceSystem;User ID=sa;Password=123;Trusted_Connection=False");
	public static SqlConnection conOld = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=NewSubData;User ID=sa;Password=123;Trusted_Connection=False");
    public static SqlConnection DbCailm = new SqlConnection("Data Source=192.168.100.4;Initial Catalog=clmdb;User ID=sa;Password=123;Trusted_Connection=False");
    //Get The date Of The Main Server:
    public static DateTime getdate()
    {
        var q = db.Database.SqlQuery<DateTime>("select getdate()");
        DateTime dt = q.First();
        return dt.Date;
    }

	// Get The Time Of The Main Server:
	public static DateTime gettime()
    {
        var q = db.Database.SqlQuery<DateTime>("select getdate()");
        DateTime dt = q.First();
        return dt;
    }

	public static string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        string ipaddress = Convert.ToString(ipEntry.AddressList[1]);

        return ipaddress.ToString();
    }
	// Get The datetime Of The Main Server:
	public static DateTime getdatetime()
    {
        var q = db.Database.SqlQuery<DateTime>("select getdate()");
        DateTime dt = q.First();
        return dt;
    }
	//Get The month Of The Main Server:
	public static int getMonth()
    {
        var q = db.Database.SqlQuery<DateTime>("select getdate()");
        DateTime dt = q.First();
        return dt.Month;
    }
	//Get The month Of The Main Server:
	public static int getyear()
    {
        var q = db.Database.SqlQuery<DateTime>("select getdate()");
        DateTime dt = q.First();
        return dt.Year;
    }
    public static void ExportToExcel(System.Data.DataTable dtTemp, string filepath)
	{
		string strFileName = filepath;
		if (System.IO.File.Exists(strFileName))
		{
			System.IO.File.Delete(strFileName);

		}
        Microsoft.Office.Interop.Excel.Application _excel = new Microsoft.Office.Interop.Excel.Application();
		Microsoft.Office.Interop.Excel.Workbook wBook = null;
		Microsoft.Office.Interop.Excel.Worksheet wSheet = null;

		wBook = _excel.Workbooks.Add();
		wSheet = wBook.ActiveSheet();

		System.Data.DataTable dt = dtTemp;
		//INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#:
		//		System.Data.DataColumn dc = null;
		//INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#:
		//		System.Data.DataRow dr = null;
		int colIndex = 0;
		int rowIndex = 0;
		//If CheckBox1.Checked Then
		foreach (System.Data.DataColumn dc in dt.Columns)
		{
			colIndex = colIndex + 1;
			wSheet.Cells[1, colIndex] = dc.ColumnName;
		}
		// End If
		foreach (System.Data.DataRow dr in dt.Rows)
		{
			rowIndex = rowIndex + 1;
			colIndex = 0;
			foreach (System.Data.DataColumn dc in dt.Columns)
			{
				colIndex = colIndex + 1;
				wSheet.Cells[rowIndex + 1, colIndex] = dr[dc.ColumnName];
			}
		}
		wSheet.Columns.AutoFit();
		wBook.SaveAs(strFileName);

		ReleaseObject(wSheet);
		wBook.Close(false);
		ReleaseObject(wBook);
		_excel.Quit();
		ReleaseObject(_excel);
		GC.Collect();

		// MessageBox.Show("File Export Successfully!")
	}
	private static void ReleaseObject(object o)
	{
		try
		{
			while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
			{
			}
		}
		catch
		{
		}
		finally
		{
			o = null;
		}
	}
	private static string[] ahad = { "", "واحد", "إثنين", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", " ثمانية", " تسعة", " عشرة", " أحد", " اثنى" };
	private static string[] ahad2 = { "", "واحد", "إثنين", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", " عشر", " أحد", " اثنى" };
	private static string[] asharat = { "", "واحد", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
	private static string[] meat = { "", "مائة", "مائتين", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
	private static string[] melion = { "", " مليون", " مليونان", " ملايين" };
	private static string[] alf = { "", " ألف", " ألفين", " آلاف" };
	private static string[] bcur = { " جنيه", "جنيهان", "جنيه" };
	private static string fagat = "فقط";
	private static string lagir = "لاغير";

	public static string NumToStr(double P_Num)
	{
		double rv = 0;
		string accum = "";
		//الملايين
		rv = Convert.ToInt32(Math.Truncate(P_Num / 1000000));

		if (rv > 2)
		{
			accum = NumToStr1(rv, accum);
		}

		if (rv >= 3 && rv < 10)
		{
			accum = accum + melion[3];
		}
		else if (rv == 2)
		{
			accum = accum + melion[2];
		}
		else if ((rv == 1) || (rv >= 10 && rv <= 999))
		{
			accum = accum + melion[1];
		}
		//الآلاف
		rv = P_Num - Convert.ToInt32(Math.Truncate(P_Num / 1000000)) * 1000000;
		rv = Convert.ToInt32(Math.Truncate(rv / 1000));
		if ((P_Num != Convert.ToInt32(Math.Truncate(P_Num / 1000000)) * 1000000) && (P_Num > 1000000))
		{
			accum = accum + " و";
		}
		if (rv > 2)
		{
			accum = NumToStr1(rv, accum);
		}
		if (rv >= 3 && rv < 10)
		{
			accum = accum + alf[3];
		}
		else if (rv == 2)
		{
			accum = accum + alf[2];
		}
		else if ((rv == 1) || (rv >= 10 && rv <= 999))
		{
			accum = accum + alf[1];
		}
		//الباقي
		rv = P_Num - Convert.ToInt32(Math.Truncate(P_Num / 1000)) * 1000;
		rv = Convert.ToInt32(Math.Truncate(rv + 0.0001));

		if ((P_Num != Convert.ToInt32(Math.Truncate(P_Num / 1000)) * 1000) && (P_Num > 1000) && (rv != 0))
		{
			accum = accum + " و ";
		}

		if ((rv >= 2) && (P_Num != 2))
		{
			accum = NumToStr1(rv, accum);
		}

		if (P_Num > 0.999)
		{
			if ((P_Num < 11) && (rv > 2))
			{
				accum = accum + bcur[2];
			}
			else if (P_Num == 2)
			{
				accum = accum + bcur[1];
			}
			else
			{
				accum = accum + bcur[0];
			}
		}

		//الهللات 
		rv = P_Num - Convert.ToInt32(Math.Truncate(P_Num + 0.0001)) + 0.0001;
		rv = Convert.ToInt32(Math.Truncate(rv * 1000));
		rv = rv / 10;

		if ((rv >= 1) && (P_Num > 0.99))
		{
			accum = accum + " و";
		}

		if (rv > 2.9)
		{
			accum = NumToStr1(rv, accum);
		}

		if (rv >= 1)
		{
			if (rv == 2)
			{
				accum = accum + " قرشاً";
			}
			else if ((rv < 11) && (rv > 2.9))
			{
				accum = accum + " قرشاً";
			}
			else
			{
				accum = accum + " قرشاً";
			}
		}
		accum = fagat + " " + accum + " " + lagir;
		return accum;
	}

	//******************* NumToStr1 *************************
	// used by NmToStr
	public static string NumToStr1(double rv, string accum)
	{
		int b = 0;
		int c = 0;
		if (rv >= 100)
		{
			b = Convert.ToInt32(Math.Truncate(rv / 100));
			accum = accum + meat[b];
		}

		b = Convert.ToInt32(Math.Truncate(rv - (Convert.ToInt32(Math.Truncate(rv / 100)) * 100)));
		if ((b != 0) && (rv > 99))
		{
			accum = accum + " و";
		}

		c = b - (Convert.ToInt32(b / 10) * 10);
		if ((b < 13) && (b != 0))
		{
			accum = accum + ahad[b];
		}

		if ((b > 12) && (c != 0))
		{
			accum = accum + ahad2[c];
		}
		if ((b > 10) && (b < 20))
		{
			accum = accum + ahad2[10];
		}

		if (b > 19)
		{
			if (c != 0)
			{
				accum = accum + " و";
			}
			accum = accum + asharat[b / 10];
		}
		return accum;
	}
    public static string Opr { get; set; }
    public static int Flag { get; set; }
    public static string SubId { get; set; }
    public static int FlagMedical { get; set; }
    public static int FlagMedicine { get; set; }
    public static int LocalityId { get; set; }
    public static string InsurNo { get; set; }
}