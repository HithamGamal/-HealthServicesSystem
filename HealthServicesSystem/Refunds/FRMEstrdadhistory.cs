using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls;
using System.Linq;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMEstrdadhistory : Telerik.WinControls.UI.RadForm
    {
        public FRMEstrdadhistory()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }
        public int flag1 = 0;
        
        #region Default Instance

        private static FRMEstrdadhistory defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMEstrdadhistory Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMEstrdadhistory();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Grid_service_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (Grid_service.RowCount > 0)
            {
                //foreach (var dr in GrdFulPaysheet.Rows)
                ////{
                //if (e.RowElement.RowInfo.Cells["column1"].Value.ToString() == "الاسترداد")
                //{
                //    e.RowElement.DrawFill = true;
                //    e.RowElement.BackColor = Color.LightBlue;
                //}
                //else
                //{
                //    e.RowElement.DrawFill = true;
                //    e.RowElement.BackColor = Color.White;
                //}
            }
        }
        private void LoadMedical()
        {
            using (dbContext db = new dbContext())
            {
                if (PLC.SubId.Length>0)
                {
                    DateTime dat = PLC.getdate().AddYears(-1);
                    var GetMed = db.ReclaimMedicals.Where(p => p.Reclaim.InsurNo == PLC.SubId && p.DateIn >=dat).ToList();
                    if (GetMed.Count > 0)
                    {
                        Grid_service.Rows.Clear();
                        for (int i = 0; i < GetMed.Count; i++)
                        {
                            int ReqCenId =Convert.ToInt32( GetMed[i].Reclaim.RefMedicalReqCenterId);
                            int ExcuCenter= Convert.ToInt32(GetMed[i].Reclaim.RefMedicalExcCenterId);
                            string ReqCenter = db.CenterInfos.Where(p => p.Id == ReqCenId).ToList()[0].CenterName;
                            string ExcCenter = db.CenterInfos.Where(p => p.Id == ExcuCenter).ToList()[0].CenterName;
                            Grid_service.Rows.Add(i + 1, GetMed[i].Reclaim.ReclaimNo , GetMed[i].MedicalServices.ServiceAName, GetMed[i].ReclaimCost, GetMed[i].DateIn, GetMed[i].Reclaim.ReclaimMedicalReasonsList.MedicalReason, ReqCenter, ExcCenter);
                        }
                        Totals.Text = GetMed.Sum(p => p.ReclaimCost).ToString();
                        PLC.SubId = "";
                        PLC.FlagMedical = 0;
                    }
                      
                }
            }
        }
        private void LoadMedicine()
        {
            using (dbContext db = new dbContext())
            {
                if (PLC.SubId.Length > 0)
                {
                    DateTime dat = PLC.getdate().AddYears(-1);
                    var GetMed = db.ReclaimMedicines.Where(p => p.Reclaim.InsurNo == PLC.SubId && p.DateIn >= dat).ToList();
                    if (GetMed.Count > 0)
                    {
                        Grid_service.Rows.Clear();
                        for (int i = 0; i < GetMed.Count; i++)
                        {
                            int ReqCenId = Convert.ToInt32(GetMed[i].Reclaim.RefMedicalReqCenterId);
                            int ExcuCenter = Convert.ToInt32(GetMed[i].Reclaim.RefMedicalExcCenterId);
                            string ReqCenter = db.CenterInfos.Where(p => p.Id == ReqCenId).ToList()[0].CenterName;
                            string ExcCenter = db.CenterInfos.Where(p => p.Id == ExcuCenter).ToList()[0].CenterName;
                            Grid_service.Rows.Add(i + 1, GetMed[i].Reclaim.ReclaimNo, GetMed[i].MedicineForReclaim.Generic_name, GetMed[i].ReclaimCost, GetMed[i].DateIn, GetMed[i].Reclaim.ReclaimMedicalReasonsList.MedicalReason, ReqCenter, ExcCenter);
                        }
                        Totals.Text = GetMed.Sum(p => p.ReclaimCost).ToString();
                        PLC.SubId ="";
                        PLC.FlagMedicine = 0;
                    }

                }
            }
        }
        private void FRMEstrdadhistory_Load(object sender, EventArgs e)
        {
            if (PLC.FlagMedical == 1)
            {
                LoadMedical();
            }
            if (PLC.FlagMedicine == 1)
            {
                LoadMedicine();
            }
        }
    }
}
