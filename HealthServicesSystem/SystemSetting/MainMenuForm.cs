using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls.UI;
using HealthServicesSystem.SystemSetting;
using HealthServicesSystem.Reclaims;
using ModelDB;
using HealthServicesSystem.Claims;
using HealthServicesSystem.Refunds;
using Telerik.WinControls;
using HealthServicesSystem.Reports;

namespace HealthServicesSystem
{
    public partial class MainMenuForm : Telerik.WinControls.UI.RadRibbonForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

        }

        public void OpenForm(Form form)
        {
            //timer1.Stop();
            //timer1.Start();
            if (ActiveMdiChild != null)
            {
                //MessageBox.Show(form.Name);
                foreach (var item in MdiChildren)
                {

                    if (item.Name == form.Name)
                    {
                        // MessageBox.Show(item.Text);
                        item.WindowState = FormWindowState.Maximized;
                    }
                    else if (ActiveMdiChild.Name != form.Name)
                    {

                        //ActiveMdiChild.Close();
                        form.MdiParent = this;
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }

                }

            }
        
            else
            {
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }

}

//private void AddPaysheet_Click(object sender, EventArgs e)
//{
//    PaysheetForm form = new PaysheetForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();



//}

//private void NewClient_Click(object sender, EventArgs e)
//{
//    ClientForm form = new ClientForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//    //Forms.ClientShow();

//}



//private void NewContract_Click(object sender, EventArgs e)
//{
//    ContractForm form = new ContractForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void NewCard_Click(object sender, EventArgs e)
//{
//    CardForm form = new CardForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void NewSubSector_Click(object sender, EventArgs e)
//{
//    SubSectorForm form = new SubSectorForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void NewArea_Click(object sender, EventArgs e)
//{
//    AreaForm form = new AreaForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void Target_Click(object sender, EventArgs e)
//{
//    TargetForm form = new TargetForm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void PaysheetAccountingReviewBTN_Click(object sender, EventArgs e)
//{
//    PaysheetAccountReviewFRM form = new PaysheetAccountReviewFRM();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void PaysheetReviewBTN_Click(object sender, EventArgs e)
//{
//    PaysheetReviewFRM form = new PaysheetReviewFRM();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void reviewCardBTN_Click(object sender, EventArgs e)
//{
//    CardRevisionFrm form = new CardRevisionFrm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void printCardBTN_Click(object sender, EventArgs e)
//{
//    PrintCardFrm form = new PrintCardFrm();
//    form.MdiParent = this;
//    form.WindowState = FormWindowState.Maximized;
//    form.Show();
//}

//private void radRibbonBarGroup10_Click(object sender, EventArgs e)
//{

//}

//private void radButtonElement1_Click(object sender, EventArgs e)
//{
//    PaySheetStatusFRM.Default.ShowDialog();
//}

private void MainMenuForm_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                //nam.Text = LogFRM.Default.UserName.Text;


                string username = LoginForm.Default.FulName;
                if (username != "Admin")
                {
                    //  usernamelbl.Text = LoginForm.Default.FulName;
                    int UserId = LoginForm.Default.UserId;
                    var usp = (from uspr in db.UserPermissions
                               join us in db.Users on
                                   uspr.UserId equals us.Id
                               join frm in db.SysForms on uspr.FormId equals frm.Id
                               where us.Id == UserId
                               select new
                               {
                                   FormName = frm.FormName
                               }).ToList();
                    if (usp.Count > 0)
                    {
                        for (int i = 0; i <= usp.Count - 1; i++)
                        {
                            foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                            {
                                foreach (RadRibbonBarGroup buto in tab.Items)
                                {
                                    for (int j = 0; j <= buto.Items.Count - 1; j++)
                                    {

                                        // Interaction.MsgBox(usp[i].FormName.ToString());
                                        if (usp[i].FormName.ToString() == buto.Items[j].Name.ToString())
                                        {
                                            buto.Items[j].Enabled = true;
                                        }

                                    }
                                }


                            }
                        }
                    }
                    else
                    {
                        var ugp = (from ups in db.GroupPermissions
                                   join us in db.UserGroups on
                                       ups.GroupId equals us.Id
                                   join usr in db.Users on
                                       us.Id equals usr.GroupId
                                   join frm in db.SysForms on ups.FormId equals frm.Id
                                   where usr.Id == UserId
                                   select new
                                   {
                                       FormName = frm.FormName
                                   }).ToList();
                        //Interaction.MsgBox(usp.Count.ToString());
                        if (ugp.Count > 0)
                        {

                            for (int i = 0; i <= ugp.Count - 1; i++)
                            {
                                foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                                {
                                    foreach (RadRibbonBarGroup buto in tab.Items)
                                    {
                                        for (int j = 0; j <= buto.Items.Count - 1; j++)
                                        {

                                            // Interaction.MsgBox(usp[i].FormName.ToString());
                                            if (ugp[i].FormName.ToString() == buto.Items[j].Name.ToString())
                                            {
                                                buto.Items[j].Enabled = true;
                                            }

                                        }
                                    }


                                }
                            }
                        }
                    }
                }
                else
                {

                    foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                    {
                        foreach (RadRibbonBarGroup buto in tab.Items)
                        {
                            for (int j = 0; j <= buto.Items.Count - 1; j++)
                            {

                                // Interaction.MsgBox(usp[i].FormName.ToString());

                                buto.Items[j].Enabled = true;


                            }



                        }
                    }
                }
            }
        }

        private void FRMApproveMedicine_Click(object sender, EventArgs e)
        {
            FRMApproveMedicine form = new FRMApproveMedicine();
            OpenForm(form);
          
        }

        private void FrmAppMedicineTyp_Click(object sender, EventArgs e)
        {
            FrmAppMedicineTyp form = new FrmAppMedicineTyp();
             OpenForm(form);
            
        }

        private void FrmPharmacist_Click(object sender, EventArgs e)
        {
            FrmPharmacist form = new FrmPharmacist();
             OpenForm(form);
            
        }

        private void UserFRM_Click(object sender, EventArgs e)
        {
            UserFRM form = new UserFRM();
            OpenForm(form);
           
        }

        private void UserGroup_Click(object sender, EventArgs e)
        {
            UserGroupFRM form = new UserGroupFRM();
             OpenForm(form);
           
        }

        private void UserPermissionsFRM_Click(object sender, EventArgs e)
        {
            UserPermissionsFRM form = new UserPermissionsFRM();
             OpenForm(form);
            
        }

        private void GroupPermissionsFRM_Click(object sender, EventArgs e)
        {
            GroupPermissionsFRM form = new GroupPermissionsFRM();
             OpenForm(form);
            
        }

        private void CompanyConfig_Click(object sender, EventArgs e)
        {
            CompanyConfig form = new CompanyConfig();
            OpenForm(form);
            
        }

        private void ChangePassFrm_Click(object sender, EventArgs e)
        {
            ChangePassFrm form = new ChangePassFrm();
             OpenForm(form);
            
        }

        private void RadButtonElement7_Click(object sender, EventArgs e)
        {
            FrmChronics form = new FrmChronics();
            OpenForm(form);
            
        }

        private void FRMBookInfo_Click(object sender, EventArgs e)
        {
            FRMBookInfo form = new FRMBookInfo();
            OpenForm(form);
            
        }

        private void FRMreportChronics_Click(object sender, EventArgs e)
        {
            FRMreportChronics form = new FRMreportChronics();
            OpenForm(form);

        }

        private void FRMReception_Click(object sender, EventArgs e)
        {
            FRMReception form = new FRMReception();
            OpenForm(form);

        }

        private void FRMmedicine_Click(object sender, EventArgs e)
        {
            FRMmedicine form = new FRMmedicine();
             OpenForm(form);
            
        }

        private void FRMmedical_Click(object sender, EventArgs e)
        {
            FRMmedical form = new FRMmedical();
             OpenForm(form);
            
        }

        private void FRMmedicalCoPay_Click(object sender, EventArgs e)
        {
            FRMmedicalCoPay form = new FRMmedicalCoPay();
            OpenForm(form);
            
        }

        private void RadRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void FRMRPTMedicalEStrdad_Click(object sender, EventArgs e)
        {
            FRMRPTMedicalEStrdad form = new FRMRPTMedicalEStrdad();
             OpenForm(form);
           
        }

        private void FRMRPTMedicineEStrdad_Click(object sender, EventArgs e)
        {
            FRMRPTMedicineEStrdad form = new FRMRPTMedicineEStrdad();
             OpenForm(form);
            
        }

        private void FRMMedicineSetting_Click(object sender, EventArgs e)
        {
            FRMMedicineSetting form = new FRMMedicineSetting();
             OpenForm(form);
            
        }

        private void FRMMedicinePricing_Click(object sender, EventArgs e)
        {
            FRMMedicinePricing form = new FRMMedicinePricing();
             OpenForm(form);
           
        }

        private void FrmDiagnosis_Click(object sender, EventArgs e)
        {

            FrmDiagnosis form = new FrmDiagnosis();
            OpenForm(form);
           
        }

        private void FrmGenerics_Click(object sender, EventArgs e)
        {
            FrmGenerics form = new FrmGenerics();
             OpenForm(form);
            
        }

        private void FrmTrades_Click(object sender, EventArgs e)
        {
            FrmTrades form = new FrmTrades();
             OpenForm(form);
            
        }

        private void FrmMedicineOut_Click(object sender, EventArgs e)
        {
            FrmMedicineOut form = new FrmMedicineOut();
            OpenForm(form);

        }

        private void FRMMedicalSetting_Click(object sender, EventArgs e)
        {
            FRMMedicalSetting form = new FRMMedicalSetting();
             OpenForm(form);
            
        }

        private void FrmMedicalGroup_Click(object sender, EventArgs e)
        {
            FrmMedicalGroup form = new FrmMedicalGroup();
             OpenForm(form);
           
        }

        private void FrmMedicalSubGroup_Click(object sender, EventArgs e)
        {
            FrmMedicalSubGroup form = new FrmMedicalSubGroup();
             OpenForm(form);
            
        }

        private void RadButtonElement5_Click(object sender, EventArgs e)
        {

        }

        private void RadButtonElement2_Click(object sender, EventArgs e)
        {
            FrmDiagnosis form = new FrmDiagnosis();
            OpenForm(form);
            
        }

        private void FrmMedicineReasons_Click(object sender, EventArgs e)
        {
            FrmMedicineReasons form = new FrmMedicineReasons();
             OpenForm(form);
            
        }

        private void FrmMedicalReasons_Click(object sender, EventArgs e)
        {
            FrmMedicalReasons form = new FrmMedicalReasons();
            OpenForm(form);

        }

        private void FRMApproveSearch_Click(object sender, EventArgs e)
        {
            FRMApproveSearch form = new FRMApproveSearch();
             OpenForm(form);
            
        }

        private void FRMApproveMedicineReorts_Click(object sender, EventArgs e)
        {
            FRMreportApproveMedicine form = new FRMreportApproveMedicine();
            OpenForm(form);
            
        }

        private void RequestClm_Click(object sender, EventArgs e)
        {
            Claims.ClmRequestFrm form = new Claims.ClmRequestFrm();
             OpenForm(form);
            
        }

        private void AllocationClm_Click(object sender, EventArgs e)
        {
            Claims.AllocationFrm form = new Claims.AllocationFrm();
             OpenForm(form);
            
        }

        private void MedicenReview_Click(object sender, EventArgs e)
        {
            Claims.ClmReviewFrm form = new Claims.ClmReviewFrm();
             OpenForm(form);
            
        }

        private void ClmConfirm_Click(object sender, EventArgs e)
        {
            Claims.ClmConfirmReviewFrm form = new Claims.ClmConfirmReviewFrm();
             OpenForm(form);
            
        }

        private void CenterNonConRep_Click(object sender, EventArgs e)
        {
            Claims.ViewCenterNonConfirmFrm form = new Claims.ViewCenterNonConfirmFrm();
            OpenForm(form);

        }

        private void NonConfirmReport_Click(object sender, EventArgs e)
        {
            Claims.NonConfirmFiltterFrm form = new Claims.NonConfirmFiltterFrm();
             OpenForm(form);
            
        }

        private void FillterData_Click(object sender, EventArgs e)
        {
            Claims.AdvanceFillterFrm form = new Claims.AdvanceFillterFrm();
             OpenForm(form);
           
        }

        private void CenterListNonConfirm_Click(object sender, EventArgs e)
        {
            Claims.ViewCenterListNonConfirmRepFrm form = new Claims.ViewCenterListNonConfirmRepFrm();
             OpenForm(form);
            
        }


            private void LastClaimsCenter_Click(object sender, EventArgs e)
        {
            Claims.LastClaimsCenterRepFrm form = new Claims.LastClaimsCenterRepFrm();
             OpenForm(form);
            
        }

        private void ExportClms_Click(object sender, EventArgs e)
        {
            Claims.ImportFileFrm form = new Claims.ImportFileFrm();
             OpenForm(form);
           
        }

        private void AppoveClaims_Click(object sender, EventArgs e)
        {
            Claims.ClmApproveAndDelFrm form = new Claims.ClmApproveAndDelFrm();
            OpenForm(form);
        }

        private void ClmReceipt_Click(object sender, EventArgs e)
        {
            Claims.ClmReceiptFrm form = new Claims.ClmReceiptFrm();
            OpenForm(form);


        }

        private void EnableClms_Click(object sender, EventArgs e)
        {
            Claims.ClmEnableFrm form = new Claims.ClmEnableFrm();
            OpenForm(form);

        }

        private void SendClm_Click(object sender, EventArgs e)
        {
            Claims.ClmSendFrm form = new Claims.ClmSendFrm();
            OpenForm(form);

        }

        private void CompireClaims_Click(object sender, EventArgs e)
        {

            CompireClaimsFrm form = new CompireClaimsFrm();
            OpenForm(form);

        }

        private void AddNonConfirm_Click(object sender, EventArgs e)
        {
            //AddNonConfirmFrm form = new AddNonConfirmFrm();
            //            OpenForm(form);

        }

        private void FrmAddChronicMedicine_Click(object sender, EventArgs e)
        {
            FrmAddChronicMedicine frm = new FrmAddChronicMedicine();
            OpenForm(frm);

        }

        private void CommitteeBTN_Click(object sender, EventArgs e)
        {
            FRMMedicalCommitee frm = new FRMMedicalCommitee();
            OpenForm(frm);

        }

        private void CommitteeListBTN_Click(object sender, EventArgs e)
        {
            FRMCooperationServices frm = new FRMCooperationServices();
            OpenForm(frm);

        }

        private void CommitteeReports_Click(object sender, EventArgs e)
        {
          FRMRequests frm = new FRMRequests();
            OpenForm(frm);
        }
    }
}
