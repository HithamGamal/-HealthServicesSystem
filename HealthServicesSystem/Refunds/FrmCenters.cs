//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic
using Telerik.WinControls.UI;
using ModelDB;
using MedicalServiceSystem.SystemSetting;
using MedicalServiceSystem.Reclaims;

namespace MedicalServiceSystem
{


    public partial class FrmCenters : Telerik.WinControls.UI.RadForm
    {
        public FrmCenters()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmCenters defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FrmCenters Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmCenters();
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

        public int flag = 0;
        public int CenterId = 0;
        private string strC;
        public int LocalityId = 0;
        private void TXTSearch_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var list1 = Module1.Con.ExecuteCenter.ToList();
            //    var list2 = Module1.Con.ExecuteCenter.ToList();
            //    if (!string.IsNullOrEmpty(TXTSearch.Text))
            //    {

            //        if (Locality.Text != "" & CenterType.Text != "")
            //        {
            //            int a = CenterType.SelectedIndex;
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 = Module1.Con.ExecuteCenter.Where((p) => p.LocalityId == b && p.CenterTypeId == a && p.InInsurance == true).OrderBy((o) => o.CenterName).ToList();
            //            list2 = Module1.Con.ExecuteCenter.Where((p) => p.LocalityId == b && p.CenterTypeId == a && p.IsEnabled == false && p.InInsurance == true).ToList();
            //        }
            //        else if (!string.IsNullOrEmpty(Locality.Text) && string.IsNullOrEmpty(CenterType.Text))
            //        {
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 = Module1.Con.ExecuteCenter.Where((p) => p.LocalityId == b && p.InInsurance == true).OrderBy((o) => o.CenterName).ToList();
            //            list2 = Module1.Con.ExecuteCenter.Where((p) => p.LocalityId == b && p.IsEnabled == false && p.InInsurance == true).ToList();
            //        }
            //        else if (string.IsNullOrEmpty(Locality.Text) && !string.IsNullOrEmpty(CenterType.Text))
            //        {
            //            int a = CenterType.SelectedIndex;
            //            list1 = Module1.Con.ExecuteCenter.Where((p) => p.CenterTypeId == a).OrderBy((o) => o.CenterName).ToList();
            //            list2 = Module1.Con.ExecuteCenter.Where((p) => p.CenterTypeId == a && p.IsEnabled == false && p.InInsurance == true).ToList();
            //        }
            //        else
            //        {
            //            list1 = Module1.Con.ExecuteCenter.Where((p) => p.InInsurance == true).OrderBy((o) => o.CenterName).ToList();
            //            list2 = Module1.Con.ExecuteCenter.Where((p) => p.IsEnabled == false && p.InInsurance == true).ToList();
            //        }
            //        // Dim gCenter =Module1.Con.ExecuteCenter.Where(Function(p) p.LocalityId = b And p.CenterTypeId= a And p.CenterName .Contains (TXTSearch.Text)).OrderBy(Function(o) o.CenterName).Select(Function(x) New With {Key .Id = x.Id, Key .CenterName = x.CenterName ,CenterBelongsTo=x.CenterBelongsTos.CenterBelongName ,CenterSort=x.CenterSorts.CenterSortName  ,ServiceState=x.ServiceStates.ServiceStateName  , Key .IsEnabled = x.IsEnabled}).ToList

            //        GRDCenter.DataSource = list1;
            //        if (GRDCenter.RowCount > 0)
            //        {
            //            for (int i = 0, loopTo = GRDCenter.RowCount - 1; i <= loopTo; i++)
            //                // GRDCenter.Rows[i].Cells["BtnEdit").Value = "Edit"
            //                // GRDCenter.Rows[i].Cells["BtnDelete").Value = "Enabel&Disable"
            //                GRDCenter.Rows[i].Cells["Serial"].Value = i.ToString();
            //        }


            //        // lis =Module1.Con.ExecuteCenter.Where(Function(p) p.LocalityId = b And p.CenterTypeId= a And p.IsEnabled = False And p.CenterName .Contains (TXTSearch.Text)).ToList
            //        if (list2.Count() > 0)
            //        {
            //            for (int j = 0, loopTo1 = list2.Count() - 1; j <= loopTo1; j++)
            //            {
            //                for (int i = 0, loopTo2 = GRDCenter.RowCount - 1; i <= loopTo2; i++)
            //                {
            //                    if (GRDCenter.Rows[i].Cells["Id"].Value.ToString() == list2[j].Id.ToString())
            //                    {
            //                        GRDCenter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                        // Dim DisableImage As Gizmox.WebGUI.Common.Resources.ImageResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle
            //                        // DisableImage.File = "DisabldDelte.png"
            //                        GRDCenter.Rows[i].Cells["BtnDeleting"].Value = global::My.Resources.DisabldDelte;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {

            //        if (Locality.Text != "" & CenterType.Text != "")
            //        {
            //            int a = CenterType.SelectedIndex;
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList();
            //            list2 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else if (Locality.Text != "" & CenterType.Text == "")
            //        {
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else if (locality.Text == "" & CenterType.Text != "")
            //        {
            //            int a = CenterType.Selectedindex;
            //            list1 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else
            //        {
            //            list1 = Module1.Con.ExecuteCenter.Where(p => Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false)).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 = Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }

            //        GRDCenter.DataSource = list1;
            //        if (GRDCenter.RowCount > 0)
            //        {
            //            for (int i = 0, loopTo3 = GRDCenter.RowCount - 1; i <= loopTo3; i++)
            //                // GRDCenter.Rows[i].Cells["BtnEdit").Value = "Edit"
            //                // GRDCenter.Rows[i].Cells["BtnDelete").Value = "Enabel&Disable"
            //                GRDCenter.Rows[i].Cells["Serial").Value = Operators.AddObject(i, 1);
            //        }


            //        // Dim sgrpe =Module1.Con.ExecuteCenter.Where(Function(p) p.LocalityId = b And p.CenterTypeId= a And p.IsEnabled = False).ToList
            //        if (list2.Count() > 0)
            //        {
            //            for (int j = 0, loopTo4 = list2.Count() - 1; j <= loopTo4; j++)
            //            {
            //                for (int i = 0, loopTo5 = GRDCenter.RowCount - 1; i <= loopTo5; i++)
            //                {
            //                    if (GRDCenter.Rows[i].Cells["Id").Value.ToString == list2.ElementAtOrDefault(j).Id.ToString())
            //                    {
            //                        GRDCenter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                        // Dim DisableImage As Gizmox.WebGUI.Common.Resources.ImageResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle
            //                        // DisableImage.File = "DisabldDelte.png"
            //                        GRDCenter.Rows[i].Cells["BtnDeleting").Value = global::My.Resources.DisabldDelte;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void FrmGroup_Load(object sender, EventArgs e)
        {

            LocalityId = PLC.LocalityId;
            LoadData();

        }

        public void LoadData()
        {
            using (dbContext db = new dbContext())
            {
                var CInfo = db.CenterInfos.Select(p => new { p.Id, p.CenterName, p.Level1, p.Level2, p.Level3, p.CenterTypeId, p.HasContract, p.IsEnabled }).ToList();
                GRDCenter.DataSource = CInfo;
                if (GRDCenter.RowCount > 0)
                {
                    for (int i = 0; i < GRDCenter.RowCount; i++)
                    {
                        GRDCenter.Rows[i].Cells["Serial"].Value = i + 1;
                        GRDCenter.Rows[i].Cells["BtnEditing"].Value = "تعديل";
                        GRDCenter.Rows[i].Cells["BtnDeleting"].Value = "حذف";
                        GRDCenter.Rows[i].Cells["Deleted"].Value = GRDCenter.Rows[i].Cells["IsEnabled"].Value;
                    }
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //if (GRDCenter.RowCount > 0)
            //{
            //    if (TXTSearch.Text != "")
            //    {
            //        strC = TXTSearch.Text;
            //        if (GRDCenter.CurrentRow.Index != GRDCenter.RowCount - 1)
            //        {
            //            int a = GRDCenter.CurrentRow.Index;
            //            for (int i = a + 1, loopTo = GRDCenter.RowCount - 1; i <= loopTo; i++)
            //            {
            //                if (GRDCenter.Rows[i].Cells["chk").Value == 1)
            //                {
            //                    GRDCenter.CurrentCell = GRDCenter.Rows[i].Cells[1);
            //                    GRDCenter.Rows[i].Selected = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            // If Len(CenterType.Text) = 0 Then
            // MessageBox.Show("يجب اختيار نوع المركز أولاً", "النظام", MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            // Exit Sub
            // End If
            var fr = new FrmAddCenter();
            flag = 1;
            CenterId = 0;
            fr.Locality.SelectedValue = LocalityId;
            fr.CenterId = 0;
            fr.ShowDialog();
        }

        private void GRDGroup_CellClick(object sender, GridViewCellEventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                if (e.ColumnIndex == GRDCenter.Columns["BtnEditing"].Index)
                {
                    var FrmAddCenter = new FrmAddCenter();
                    flag = 1;
                    CenterId = Convert.ToInt32(e.Row.Cells["Id"].Value.ToString());

                    var cti = db.CenterInfos.Where(p => p.Id == CenterId).ToList();
                    if (cti.Count > 0)
                    {
                        FrmAddCenter.CenterName.Text = cti[0].CenterName;
                        FrmAddCenter.CenterId = CenterId;
                        FrmAddCenter.LocalityId.Text = cti[0].LocalityId.ToString();
                        FrmAddCenter.CenterType.SelectedValue = cti[0].CenterTypeId;
                        FrmAddCenter.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == GRDCenter.Columns["BtnDeleting"].Index)
                {
                    // Dim result As MsgBoxResult
                    flag = 0;
                    if ((bool)GRDCenter.CurrentRow.Cells["Deleted"].Value == true)
                    {
                        //DialogResult msg;
                        //msg = MessageBox.Show("هل تريد إلغاء تفعيل هذه المؤسسة", "النظام", MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        //if (msg == DialogResult.OK)
                        //{
                        CenterId = Convert.ToInt32(e.Row.Cells["Id"].Value.ToString());
                        int a1 = Convert.ToInt32(GRDCenter.CurrentRow.Cells["Id"].Value);
                        var chkFound = db.CenterInfos.Where(p => p.Id == CenterId && p.HasContract == false).ToList();
                        if (chkFound.Count > 0)
                        {
                            if (chkFound[0].IsEnabled == true )
                            {
                                chkFound[0].IsEnabled = false;
                            }
                            db.SaveChanges();
                            using (dbContext con = new dbContext())
                            {
                                var chkFound1 = con.CenterInfos.Where(p => p.Id == CenterId && p.HasContract == false).ToList();
                                if (chkFound.Count > 0)
                                {
                                    GRDCenter.CurrentRow.Cells["Deleted"].Value = chkFound[0].IsEnabled;
                                }
                            }
                            // LoadData();
                        }
                        // }
                    }
                    else if ((bool)GRDCenter.CurrentRow.Cells["Deleted"].Value == false)
                    {
                        //DialogResult msg;
                        //msg = MessageBox.Show("هل تريد  تفعيل هذه المؤسسة", "النظام", MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        //if (msg == DialogResult.OK)
                        //{
                        CenterId = Convert.ToInt32(e.Row.Cells["Id"].Value.ToString());
                        var chkFound = db.CenterInfos.Where(p => p.Id == CenterId && p.HasContract==false).ToList();
                        if (chkFound.Count > 0)
                        {

                            if (chkFound[0].IsEnabled == false)
                            {
                                chkFound[0].IsEnabled = true;
                            }

                            db.SaveChanges();
                            using (dbContext con = new dbContext())
                            {
                                var chkFound1 = con.CenterInfos.Where(p => p.Id == CenterId && p.HasContract == false).ToList();
                                if (chkFound.Count > 0)
                                {
                                    GRDCenter.CurrentRow.Cells["Deleted"].Value = chkFound[0].IsEnabled;
                                }
                            }
                            //LoadData();
                            //}
                        }
                    }
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    IEnumerable<object> list1;
            //    IEnumerable<object> list2;
            //    if (locality.Text != "" & CenterType.Text != "")
            //    {
            //        int a = CenterType.Selectedindex;
            //        int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //        list1 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //        list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //    }
            //    else if (locality.Text != "" & CenterType.Text == "")
            //    {
            //        int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //        list1 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //        list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //    }
            //    else if (locality.Text == "" & CenterType.Text != "")
            //    {
            //        int a = CenterType.Selectedindex;
            //        list1 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //        list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //    }
            //    else
            //    {
            //        list1 =Module1.Con.ExecuteCenter.Where(p => Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false)).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //        list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //    }

            //    GRDCenter.DataSource = list1;
            //    if (GRDCenter.RowCount > 0)
            //    {
            //        for (int i = 0, loopTo = GRDCenter.RowCount - 1; i <= loopTo; i++)
            //            // GRDCenter.Rows[i].Cells["BtnEdit").Value = "Edit"
            //            // GRDCenter.Rows[i].Cells["BtnDelete").Value = "Enabel&Disable"
            //            GRDCenter.Rows[i].Cells["Serial").Value = Operators.AddObject(i, 1);
            //    }

            //    if (list2.Count() > 0)
            //    {
            //        for (int j = 0, loopTo1 = list2.Count() - 1; j <= loopTo1; j++)
            //        {
            //            for (int i = 0, loopTo2 = GRDCenter.RowCount - 1; i <= loopTo2; i++)
            //            {
            //                if (GRDCenter.Rows[i].Cells["Id").Value.ToString == list2.ElementAtOrDefault(j).Id.ToString())
            //                {
            //                    GRDCenter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                    // Dim DisableImage As Gizmox.WebGUI.Common.Resources.ImageResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle
            //                    // DisableImage.File = "DisabldDelte.png"
            //                    GRDCenter.Rows[i].Cells["BtnDeleting").Value = global::My.Resources.DisabldDelte;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void BindMessageHandler(object sender, EventArgs e)
        {
        }

        private void FrmCenters_Activated(object sender, EventArgs e)
        {
            //try
            //{
            //    if (flag == 1)
            //    {
            //        IEnumerable<object> list1;
            //        IEnumerable<object> list2;
            //        if (locality.Text != "" & CenterType.Text != "")
            //        {
            //            int a = CenterType.Selectedindex;
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else if (locality.Text != "" & CenterType.Text == "")
            //        {
            //            int b = Convert.ToInt32(Locality.SelectedValue.ToString());
            //            list1 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, b, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else if (locality.Text == "" & CenterType.Text != "")
            //        {
            //            int a = CenterType.Selectedindex;
            //            list1 =Module1.Con.ExecuteCenter.Where(p => Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false)).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.CenterTypeId, a, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }
            //        else
            //        {
            //            list1 =Module1.Con.ExecuteCenter.Where(p => Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false)).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //            list2 =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        }

            //        GRDCenter.DataSource = list1;
            //        if (GRDCenter.RowCount > 0)
            //        {
            //            for (int i = 0, loopTo = GRDCenter.RowCount - 1; i <= loopTo; i++)
            //                // GRDCenter.Rows[i].Cells["BtnEdit").Value = "Edit"
            //                // GRDCenter.Rows[i].Cells["BtnDelete").Value = "Enabel&Disable"
            //                GRDCenter.Rows[i].Cells["Serial").Value = Operators.AddObject(i, 1);
            //            // Dim sgrpe =Module1.Con.ExecuteCenter.Where(Function(p) p.LocalityId = b And p.CenterType= a1 And p.IsEnabled = False).ToList
            //            if (list2.Count() > 0)
            //            {
            //                for (int j = 0, loopTo1 = list2.Count() - 1; j <= loopTo1; j++)
            //                {
            //                    for (int i = 0, loopTo2 = GRDCenter.RowCount - 1; i <= loopTo2; i++)
            //                    {
            //                        if (GRDCenter.Rows[i].Cells["Id").Value.ToString == list2.ElementAtOrDefault(j).Id.ToString())
            //                        {
            //                            GRDCenter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                            // Dim DisableImage As Gizmox.WebGUI.Common.Resources.ImageResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle
            //                            // DisableImage.File = "DisabldDelte.png"
            //                            GRDCenter.Rows[i].Cells["BtnDeleting").Value = global::My.Resources.DisabldDelte;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void UploadControl1_Click(object sender, EventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {

                if (PLC.Flag == 1)
                {
                    var ExcCenter = db.CenterInfos.Where(p => p.IsVisible == true && p.IsEnabled == true).ToList();
                    FRMmedicine.Default.ExcutingParty.DataSource = ExcCenter;
                    FRMmedicine.Default.ExcutingParty.ValueMember = "Id";
                    FRMmedicine.Default.ExcutingParty.DisplayMember = "CenterName";
                    FRMmedicine.Default.ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                    FRMmedicine.Default.ExcutingParty.SelectedIndex = -1;

                    var ReqCenter = db.CenterInfos.Where(p => p.IsVisible == true && p.IsEnabled == true).ToList();
                    FRMmedicine.Default.RequistingParty.DataSource = ReqCenter;
                    FRMmedicine.Default.RequistingParty.ValueMember = "Id";
                    FRMmedicine.Default.RequistingParty.DisplayMember = "CenterName";
                    FRMmedicine.Default.RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                    FRMmedicine.Default.RequistingParty.SelectedIndex = -1;
                }
                if (PLC.Flag == 2)
                {

                    var ExcCenter = db.CenterInfos.Where(p => p.IsVisible == true && p.IsEnabled == true).ToList();
                    FRMmedical.Default.ExcutingParty.DataSource = ExcCenter;
                    FRMmedical.Default.ExcutingParty.ValueMember = "Id";
                    FRMmedical.Default.ExcutingParty.DisplayMember = "CenterName";
                    FRMmedical.Default.ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                    FRMmedical.Default.ExcutingParty.SelectedIndex = -1;

                    var ReqCenter = db.CenterInfos.Where(p => p.IsVisible == true && p.IsEnabled == true).ToList();
                    FRMmedical.Default.RequistingParty.DataSource = ReqCenter;
                    FRMmedical.Default.RequistingParty.ValueMember = "Id";
                    FRMmedical.Default.RequistingParty.DisplayMember = "CenterName";
                    FRMmedical.Default.RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                    FRMmedical.Default.RequistingParty.SelectedIndex = -1;
                }
                if (PLC.Flag == 3)
                {
                    var Gcenter = db.CenterInfos.Where(p => p.IsEnabled == true && p.IsVisible == true).ToList();
                    FRMReception.Default.CenterList.DataSource = Gcenter;
                    FRMReception.Default.CenterList.ValueMember = "Id";
                    FRMReception.Default.CenterList.DisplayMember = "CenterName";
                    FRMReception.Default.CenterList.SelectedIndex = -1;
                    FRMReception.Default.CenterList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                }

            }
            Close();
        }

        private void GroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Locality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Locality.Text != "")
            //    {
            //        int a = Convert.ToInt32(Locality.SelectedValue.ToString());
            //        var gCenter =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, a, false), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).OrderBy(o => o.CenterName).Select(x => new { x.Id, x.CenterName, CenterBelongsTo = x.CenterBelongsTos.CenterBelongName, CenterSort = x.CenterSorts.CenterSortName, ServiceState = x.ServiceStates.ServiceStateName, x.IsEnabled }).ToList;
            //        GRDCenter.DataSource = gCenter;
            //        if (GRDCenter.RowCount > 0)
            //        {
            //            for (int i = 0, loopTo = GRDCenter.RowCount - 1; i <= loopTo; i++)
            //                // GRDCenter.Rows[i].Cells["BtnEdit").Value = "Edit"
            //                // GRDCenter.Rows[i].Cells["BtnDelete").Value = "Enabel&Disable"
            //                GRDCenter.Rows[i].Cells["Serial").Value = Operators.AddObject(i, 1);
            //        }

            //        var sgrpe =Module1.Con.ExecuteCenter.Where(p => (bool)Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(p.LocalityId, a, false), Operators.ConditionalCompareObjectEqual(p.IsEnabled, false, false)), Operators.ConditionalCompareObjectEqual(p.InInsurance, true, false))).ToList;
            //        if (sgrpe.Count > 0)
            //        {
            //            for (int j = 0, loopTo1 = sgrpe.Count - 1; j <= loopTo1; j++)
            //            {
            //                for (int i = 0, loopTo2 = GRDCenter.RowCount - 1; i <= loopTo2; i++)
            //                {
            //                    if (GRDCenter.Rows[i].Cells["Id").Value.ToString == sgrpe(j).Id.ToString)
            //                    {
            //                        GRDCenter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                        // Dim DisableImage As Gizmox.WebGUI.Common.Resources.ImageResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle
            //                        // DisableImage.File = "DisabldDelte.png"
            //                        GRDCenter.Rows[i].Cells["BtnDeleting").Value = global::My.Resources.DisabldDelte;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void GRDCenter_CellFormatting(object sender, CellFormattingEventArgs e)
        {

        }

        private void GRDCenter_Click(object sender, EventArgs e)
        {

        }

        private void GRDCenter_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (Convert.ToBoolean(e.RowElement.RowInfo.Cells["Deleted"].Value) == false)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                e.RowElement.DrawFill = true;
                e.RowElement.BackColor = System.Drawing.Color.White;
            }
        }
    }
}