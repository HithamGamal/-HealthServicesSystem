using HealthServicesSystem.SystemSetting;
using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Claims
{
    public partial class ViewReceiptRepFrm : Telerik.WinControls.UI.RadForm
    {
        public ViewReceiptRepFrm()
        {
            InitializeComponent();
        }
        public int _RecId = 0;
        public int ReceiptId = 0;
        public Image ByteArrayImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void ViewReceiptRepFrm_Load(object sender, EventArgs e)
        {
          

            dbContext db = new dbContext();
            var q = db.ClmReceiptClaimsDet.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ReceiptId == _RecId)
                .Select(p => new
                {
                    MedFile = 0,
                    MedCount = 0,
                    MedCost = 0,
                    MedVisit = 0,
                    DawaFile = p.CountOfBoxFile,
                    DawaCount = p.CountOfOrneks,
                    DawaCost = p.TotalOfClaims,
                    DawaVisit= p.CountOfOrneks,
                    FileName = p.FileName,
                    CenterName = p.ClmReceiptClaims.CenterInfo.CenterName,
                    Sorted = db.ClmSortedDeg .Where (s=> s.Id== p.ClmReceiptClaims.Sorted).Select(s=>s.Name).FirstOrDefault (),
                    Entered = db.ClmSortedDeg.Where(s => s.Id == p.ClmReceiptClaims.DataEntery).Select(s => s.Name).FirstOrDefault() ,
                    ReceiptDate = p.ClmReceiptClaims.ReceiptDate,
                    TimeIn = p.ClmReceiptClaims.TimeIn,
                    TimeOut = p.ClmReceiptClaims.TimeOut,
                    NextDate = p.ClmReceiptClaims.NextDate,
                    ErrorCount = 0,
                    ErrorPercent = 0,
                    NextTime = p.ClmReceiptClaims.NextDate,
                    ContactName = p.ClmReceiptClaims.ContactName,
                    TellNo = p.ClmReceiptClaims.ContactTell,
                    Notes = p.ClmReceiptClaims.Notes ,
                    Month = p.ClmReceiptClaims.Month ,
                    Years = p.ClmReceiptClaims.year,
                    UserId = p.UserId
                }) .ToList();
            if (q.Count >0)
            {
               var GetName= db.CompanySettings.Select(p => new
                {
                    CompName = p.CompanyName,
                    Log1= p.LogoPath1 ,
                    Log2= p.LogoPath2
                }).ToList ();

                Claims.ClmReceiptReport rep = new ClmReceiptReport();
                rep.DataSource = q;
                reportViewer1.ReportSource = rep;
                rep.ComanyName.Value  = GetName[0].CompName;
                var GetInfo = db.CompanySettings.FirstOrDefault();
                Byte[] MyData = new byte[0];
                MyData = (Byte[])GetInfo.LogoPath1;
                MemoryStream stream = new MemoryStream(MyData);
                stream.Position = 0;
                rep.CompanyLogo.Value = Image.FromStream(stream);
                //===============
                int UserIn = q[0].UserId;
                int UserPrint = LoginForm.Default.UserId;
                var getUserPrint = db.Users.Where(p => p.Id == UserPrint).Take(1).ToList();
                rep.UserPrint.Value = getUserPrint[0].UserName;
                
                var getUser = db.Users.Where(p => p.Id == UserIn).Take(1).ToList ();
                rep.UserIn.Value = getUser[0].UserName;

                MyData = (Byte[])GetInfo.LogoPath2;
                MemoryStream stream1 = new MemoryStream(MyData);
                stream.Position = 0;
                rep.IsoLogo.Value = Image.FromStream(stream1); ;
                rep.ClmsDet.Value = "مطالبة شهر " + q[0].Month + "لسنة " + q[0].Years;
                reportViewer1.RefreshReport();

          

            }
            
        }
    }
}
