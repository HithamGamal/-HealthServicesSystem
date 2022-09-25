using System;
using System.Data;
using System.Windows.Forms;
using 
    ModelDB;
using System.Linq;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using MedicalServiceSystem.SystemSetting;

namespace MedicalServiceSystem
{
    public partial class UserGroupFRM
    {
        public int flag = 0;

        public int a = 0;

        public UserGroupFRM()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static UserGroupFRM defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static UserGroupFRM Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UserGroupFRM();
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















        private void radButton4_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                flag = 0;
                var cu = db.UserGroups.Where(p => p.Id > 0).ToList();
                UserFRM.Default.UserGroup.DataSource = cu;
                UserFRM.Default.UserGroup.DisplayMember = "GroupName";
                UserFRM.Default.UserGroup.ValueMember = "Id";
                if (UserFRM.Default.UserGroup.Items.Count > 0)
                {
                    UserFRM.Default.UserGroup.SelectedIndex = -1;
                }

                Close();
            }
        }

        private void OperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void CustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GroupId.Text = GroupName.SelectedValue.ToString();
            }
            catch (Exception)
            {
                GroupId.Text = "";

                return;
            }
        }




        private void Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }

        private void CustomerFRM_Load(object sender, EventArgs e)
        {
            
            using (dbContext db = new dbContext())
            {
                var cut = db.UserGroups.Where(p => p.Id > 0).ToList();
                GroupName.DataSource = cut;
                GroupName.DisplayMember = "GroupName";
                GroupName.ValueMember = "Id";
                GroupName.SelectedIndex = -1;
                var Sys = db.Systems.ToList();
                SystemName.DataSource = Sys;
                SystemName.DisplayMember = "SystemName";
                SystemName.ValueMember = "Id";
                SystemName.SelectedIndex = -1;
                // GroupStatus.SelectedIndex = 0;
            }
            flag = 1;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                if (flag == 1)
                {


                    if (GroupName.Text.Length==0)
                    {
                        Interaction.MsgBox("يجب كتابة اسم المجموعة أولا", MsgBoxStyle.Exclamation, "System");
                        GroupName.Focus();
                        return;
                    }
                    if (SystemName.SelectedIndex==-1)
                    {
                        Interaction.MsgBox("يجب كتابة اسم النظام الذي تتبع له المجموعة أولا", MsgBoxStyle.Exclamation, "System");
                        SystemName.Focus();
                        return;
                    }
                    UserGroup userGroup = new UserGroup();
                    string str =GroupName.Text.Trim();
                    int SysId = Convert.ToInt32(SystemName.SelectedValue);
                    userGroup.GroupName = str;
                    userGroup.SystemId = SysId;
                    db.UserGroups.Add(userGroup);
                    db.SaveChanges();

                    var u = db.UserGroups.Where(p => p.Id > 0).ToList();
                    GRDGroups.DataSource = u;

                    for (int i = 0; i <= GRDGroups.RowCount - 1; i++)
                    {
                        GRDGroups.Rows[i].Cells[0].Value = i + 1;
                    }
                    GRDGroups.Rows[GRDGroups.RowCount - 1].IsCurrent = true;
                    GRDGroups.Rows[GRDGroups.RowCount - 1].IsCurrent = true;
                }
                else
                {
                    if (flag == 2)
                    {

                        int x1 = int.Parse(GroupId.Text);
                        var v = db.UserGroups.Where(p => p.Id == x1).ToList();
                        if (v.Count > 0)
                        {
                            v[0].GroupName = Strings.Trim(GroupName.Text);
                            db.SaveChanges();

                            Interaction.MsgBox("لقد تم تعديل البيانات", MsgBoxStyle.Information, "System");


                        }
                    }
                }

                GroupName.Text = "";
                //GroupStatus.SelectedIndex = 0;
                GroupId.Text = "";
                var cu1 = db.UserGroups.ToList();
                GroupName.DataSource = cu1;
                GroupName.DisplayMember = "GroupName";
                GroupName.ValueMember = "Id";
                GroupName.Text = "";
                GroupId.Text = "";
               // GroupStatus.SelectedIndex = 0;
               // EditMode.Text = "Edit Mode : Add New";
                flag = 1;
                // CustomerTypeName.Focus();
            }

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (dbContext db = new dbContext())
                {
                    if (GroupName.Text != "")
                    {

                        int x = int.Parse(GroupId.Text);
                        flag = 2;
                       // EditMode.Text = "Edit Mode : Modify";

                        var cu = db.UserGroups.Where(p => p.Id == x).ToList();
                        if (cu.Count > 0)
                        {
                            
                        }

                    }
                }
            }
            catch (Exception)
            {


                return;
            }
        }

        private void GRDGroups_Click(object sender, EventArgs e)
        {

        }

        private void GRDGroups_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDGroups.RowCount > 0)
            {
                if (GRDGroups.CurrentColumn.Name == "Edit")
                {
                    flag = 2;
                    GroupId.Text = GRDGroups.Rows[GRDGroups.CurrentRow.Index].Cells[1].Value.ToString();
                    GroupName.Text = GRDGroups.Rows[GRDGroups.CurrentRow.Index].Cells[2].Value.ToString();

                    for (int i = 0; i <= GRDGroups.RowCount - 1; i++)
                    {
                        if (GRDGroups.Rows[i].Cells[1].Value.ToString() == GroupId.Text)
                        {
                            GRDGroups.Rows[i].IsCurrent = true;
                            GRDGroups.Rows[i].IsSelected = true;
                            return;
                        }
                    }
                }
            }
        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.60.3;Initial Catalog=PharmacySysDb;User ID=Admin;Password=Admin123";
            if (conn.State == ConnectionState.Open) { conn.Close(); }
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT  dbo.Batches.ItemId, SUM(dbo.Transactions.Qty) AS Qty FROM dbo.Batches INNER JOIN dbo.Transactions ON dbo.Batches.Id = dbo.Transactions.BatchId WHERE(dbo.Transactions.Id >= 93370) AND(dbo.Transactions.OperationId=45) GROUP BY dbo.Batches.ItemId ORDER BY dbo.Batches.ItemId", conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                SqlDataAdapter tr =
                    new SqlDataAdapter(
                        "select * from Transactions where BatchId in (select id from batches where ItemId =" +
                        dt.Rows[i]["ItemId"] + ") and id >= 93370 and OperationId <>45  order by id", conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(tr);
                DataTable dttr = new DataTable();
                tr.Fill(dttr);
                if (dttr.Rows.Count > 0)
                {
                    a = int.Parse(dt.Rows[i]["Qty"].ToString());
                    //   Interaction.MsgBox(a.ToString());
                    for (int j = 0; j <= dttr.Rows.Count - 1; j++)
                    {
                        int b = int.Parse(dttr.Rows[j]["qty"].ToString());
                        a = a + b;
                        //  Interaction.MsgBox(a.ToString());
                        dttr.Rows[j]["AvailQty"] = a;



                    }
                    tr.Fill(dttr);
                    tr.Update(dttr);
                    tr.UpdateCommand = cmd.GetUpdateCommand();
                }
            }
            Interaction.MsgBox("ok");
        }

        private void radButton3_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.60.3;Initial Catalog=PharmacySysDb;User ID=Admin;Password=Admin123";
            if (conn.State == ConnectionState.Open) { conn.Close(); }
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT  batchid,  sum(Qty) as qty FROM  dbo.Transactions  WHERE (Id >= 93370) group by batchid  having sum(Qty)>=0 ", conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                SqlDataAdapter bt = new SqlDataAdapter("select * from batches where id=" + dt.Rows[i]["batchid"],
                   conn);
                SqlCommandBuilder cmd1 = new SqlCommandBuilder(bt);
                DataTable dttr1 = new DataTable();
                bt.Fill(dttr1);
                if (dttr1.Rows.Count > 0)
                {
                    dttr1.Rows[0]["Quantity"] = dt.Rows[i]["qty"];
                    bt.Update(dttr1);
                    bt.UpdateCommand = cmd1.GetUpdateCommand();
                }
            }

            //tr.Fill(dttr);
            // tr.Update(dttr);
            //  tr.UpdateCommand = cmd.GetUpdateCommand();


            Interaction.MsgBox("ok");
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                "Data Source=192.168.60.3;Initial Catalog=PharmacySysDb;User ID=Admin;Password=Admin123";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            SqlDataAdapter da1 =
                new SqlDataAdapter(
                    "SELECT  dbo.Batches.ItemId, SUM(dbo.Transactions.Qty) AS Qty FROM dbo.Batches INNER JOIN dbo.Transactions ON dbo.Batches.Id = dbo.Transactions.BatchId WHERE(dbo.Transactions.Id >= 93370) AND(dbo.Transactions.OperationId<>45) and operationid in (select id from operations where operationtype=0) and dbo.Batches.ItemId not in (select itemid from (SELECT  dbo.Batches.ItemId, SUM(dbo.Transactions.Qty) AS Qty FROM dbo.Batches INNER JOIN dbo.Transactions ON dbo.Batches.Id = dbo.Transactions.BatchId WHERE(dbo.Transactions.Id >= 93370) AND(dbo.Transactions.OperationId=45) GROUP BY dbo.Batches.ItemId )pp) GROUP BY dbo.Batches.ItemId ",
                    conn);
            DataTable dt1 = new DataTable();

            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    SqlDataAdapter tr =
                        new SqlDataAdapter(
                            "select * from Transactions where BatchId in (select id from batches where ItemId =" +
                            dt1.Rows[i]["ItemId"] + ") and id >= 93370 and OperationId <>45  order by id", conn);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(tr);
                    DataTable dttr = new DataTable();
                    tr.Fill(dttr);
                    if (dttr.Rows.Count > 0)
                    {
                        a = int.Parse(dttr.Rows[0]["qty"].ToString());
                        dttr.Rows[0]["AvailQty"] = a;
                        //   Interaction.MsgBox(a.ToString());
                        for (int j = 1; j <= dttr.Rows.Count - 1; j++)
                        {
                            int b = int.Parse(dttr.Rows[j]["qty"].ToString());
                            a = a + b;
                            //  Interaction.MsgBox(a.ToString());
                            dttr.Rows[j]["AvailQty"] = a;



                        }
                        tr.Fill(dttr);
                        tr.Update(dttr);
                        tr.UpdateCommand = cmd.GetUpdateCommand();
                    }
                }

            }
            Interaction.MsgBox("ok");
        }

        private void GroupName_TextChanged(object sender, EventArgs e)
        {
            if (GroupName.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    var ChkName = db.UserGroups.Where(p => p.GroupName == GroupName.Text).ToList();
                    if (ChkName.Count > 0)
                    {
                        flag = 2;
                    }
                }
                }
        }
    }

}

