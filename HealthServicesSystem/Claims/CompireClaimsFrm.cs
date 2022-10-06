using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HealthServicesSystem.Claims
{
    public partial class CompireClaimsFrm : Telerik.WinControls.UI.RadForm
    {
        public CompireClaimsFrm()
        {
            InitializeComponent();
        }

        private void CompireClaimsFrm_Load(object sender, EventArgs e)
        {
            try
            {
                FMonthDrp.SelectedIndex = PLC.getMonth() - 2;
                FYearTxt.Text = PLC.getyear().ToString();
                dbContext db = new dbContext();
                var qCenter = db.CenterInfos.Select(p => new { Id = p.Id, CenterName = p.Id + " " + p.CenterName }).ToList();
                if (qCenter.Count > 0)
                {
                    CenterNameDrp.DataSource = qCenter;
                    CenterNameDrp.DisplayMember = "CenterName";
                    CenterNameDrp.ValueMember = "Id";
                    CenterNameDrp.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                    CenterNameDrp.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
