using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Google.Maps;

namespace cdrv4.Forms
{
    public partial class form_ToolsPanel : Form
    {
        public form_ToolsPanel(string casename)
        {
            InitializeComponent();
            txb_caseName_tp.Text = casename;
        }

        private void txb_caseName_tp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CheckDuplicates_Click(object sender, EventArgs e)
        {
            string table = txb_caseName_tp.Text;
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            using (var sqlcmd = new SqlCommand("SELECT * FROM [dbo].[" + table + "] WHERE [DateTime] IN (SELECT [DateTime] FROM [dbo].[" + table + "] GROUP BY [DateTime] HAVING COUNT([DateTime])>1);", con))
            using (var adapter = new SqlDataAdapter(sqlcmd))
            {
                con.Open();
                var checktable = new DataTable();
                adapter.Fill(checktable);
                dataGridView2_tp.DataSource = checktable;
                con.Close();
            } 
        }

        private void btn_AcceptDuplicates_Click(object sender, EventArgs e)
        {
            using (var db = new cdrv4.Database.cdrdbContainer())
            {
                string table = txb_caseName_tp.Text;
                db.Database.ExecuteSqlCommand("Update [dbo].["+table+"] SET [IsDuplicate] = 1 WHERE [DateTime] IN (SELECT [DateTime] FROM [dbo].["+table+"] GROUP BY [DateTime] HAVING COUNT([DateTime])>1);");
                btn_CheckDuplicates.PerformClick();
                MessageBox.Show("Duplicates accepted");
            }
        }

        private void btn_MergeDuplicates_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To be completed");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void form_ToolsPanel_Load(object sender, EventArgs e)
        {

        }

        private void btn_ConvertNE_Click(object sender, EventArgs e)
        {
            string table = txb_caseName_tp.Text;
            var latlon = new DataTable();
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            using (var sqlcmd = new SqlCommand("SELECT LineID, FirstCellEasting, FirstCellNorthing, FirstCellLatitude, FirstCellLongitude FROM [dbo].[" + table + "];", con))
            using (var adapter = new SqlDataAdapter(sqlcmd))
            {
                con.Open();
                adapter.Fill(latlon);
                con.Close();
            }

            foreach (DataRow row in latlon.Rows)
            {
              
                var firsteasting = row.ItemArray[1];
                var firstnorthing = row.ItemArray[2];
                if (firsteasting == null || firstnorthing == null) continue;
                var feasting = Convert.ToDouble(firsteasting);
                var fnorthing = Convert.ToDouble(firstnorthing);
                var latLong = NEConverter.ConvertOSToLatLon(feasting, fnorthing);
                row.ItemArray[3] = latLong.Latitude;
                row.ItemArray[4] = latLong.Longitude;
  
                using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"));
                using (var sqlcmd = new SqlCommand("UPDATE ", con)) ;
                

               
                
            }
           

        }

        private void btn_Mapping_Click(object sender, EventArgs e)
        {
            string cn = txb_caseName_tp.Text;
            var tp = new cdrv4.Forms.Map(cn);
            tp.ShowDialog();
        }

        


    }
}
