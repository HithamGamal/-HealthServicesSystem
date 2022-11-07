using ModelDB;
using System;
using System.Linq;
using System.Data;
using Telerik.WinControls;

namespace HealthServicesSystem.Refunds
{
    public partial class FRMCooperationServices : Telerik.WinControls.UI.RadForm
    {
        dbContext db = new dbContext();
        public FRMCooperationServices()
        {
            InitializeComponent();
        }

        private void FRMCooperationServices_Load(object sender, EventArgs e)
        {
            fillgrid();


        }
        public void fillgrid()
        {
            var x = db.CooperationServices
                       .Where(y => y.rowStatus != RowStatus.Deleted)
                       .Select(c=> new {
                           Id= c.Id,
                           serviceAR = c.Service_AR_Name,
                           serviceEN = c.Service_EN_Name,
                           cost = c.Cost
                       })
                       .ToList();
            radGridView1.DataSource = x;
        }


        public void clear()
        {
            Cost.Text = "";
            ServiceARTB .Text = "";
            ServiceENTB.Text = "";
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            cooperationService co = new cooperationService();
            co.Service_AR_Name = ServiceARTB.Text;
            co.Service_EN_Name = ServiceENTB.Text;
            co.Cost  = Cost .Text;

            db.CooperationServices.Add(co);
            db.SaveChanges();
            RadMessageBox.Show("تم الحفظ");

            fillgrid();
            clear();

        }

        private void RadGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int id =Convert.ToInt32( radGridView1.CurrentRow.Cells["Id"].Value);

            var da = db.CooperationServices.Where(a => a.Id == id).First();
            idlbl.Text = da.Id.ToString();
            ServiceARTB.Text = da.Service_AR_Name ;
             ServiceENTB.Text= da.Service_EN_Name;
             Cost.Text = da.Cost;


            addBTN.Enabled = false;

        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32( idlbl.Text);
            var da = db.CooperationServices.Where(a => a.Id == id).First();
          
            ServiceARTB.Text = da.Service_AR_Name;
            ServiceENTB.Text = da.Service_EN_Name;
            Cost.Text = da.Cost;


           
            db.SaveChanges();
            RadMessageBox.Show("تم التعديل");
            addBTN.Enabled = true;
            fillgrid();
            clear();
        }

        private void RadGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (radGridView1.CurrentColumn.Name == "delete")
            {

                int id = Convert.ToInt32(radGridView1.CurrentRow.Cells["Id"].Value);

                var del = db.CooperationServices.Where(x => x.Id == id ).First();
                del.rowStatus = RowStatus.Deleted;
                db.SaveChanges();
                radGridView1.CurrentRow.Delete();
                RadMessageBox.Show("تم الحذف");
                fillgrid();
            }
        }
    }
}
