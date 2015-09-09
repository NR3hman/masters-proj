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
        /*This button exits the tools panel windows form */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*This code uses the SQL command to select the items in the table as shown in the case name, it selects all the items where the
         * DateTime field equal each other*/
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
        /*This code uses the SQL command updates the IsDuplicate field to 1 where the DateTime fields are equal*/
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
        /*This code deletes a duplicate item rather than merges them - The merging will be required in future work*/
        private void btn_MergeDuplicates_Click(object sender, EventArgs e)
        {
            using (var db = new cdrv4.Database.cdrdbContainer())
            {
                string table = txb_caseName_tp.Text;
                db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[" + table + "] WHERE IsDuplicate = 1 AND TypeofCall = 'Calls Forwarded';");
                MessageBox.Show("De-duplicated");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            

        }

        private void form_ToolsPanel_Load(object sender, EventArgs e)
        {

        }
        /*This code selects the first cell, easting, northing, latitude and longitude and fills this in the datatable after running
         this through the converter code*/
        private void btn_ConvertNE_Click(object sender, EventArgs e)
        {
            string table = txb_caseName_tp.Text;
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            using (var sqlcmd = new SqlCommand("SELECT LineID, FirstCellEasting, FirstCellNorthing, FirstCellLatitude, FirstCellLongitude FROM [dbo].[" + table + "] WHERE FirstCellNorthing != 'NULL' AND FirstCellEasting != 'NULL';", con))
            using (var adapter = new SqlDataAdapter(sqlcmd))
            {
                con.Open();
                var latlon = new DataTable();
                adapter.Fill(latlon);
                dataGridView2_tp.DataSource = latlon;
                con.Close();
            }

            foreach (DataGridViewRow row in dataGridView2_tp.Rows)
            {
                
                var firsteasting = Convert.ToDouble(row.Cells[1].Value);
                var firstnorthing = Convert.ToDouble(row.Cells[2].Value);
                //var lasteasting = Convert.ToDouble(row.Cells[5].Value);
                //var lastnorthing = Convert.ToDouble(row.Cells[6].Value);
                if (row.IsNewRow) continue;
               // if (firsteasting == null || firstnorthing == null || lastnorthing == null || lasteasting == null) continue;
                var firstconvert = NEConverter.ConvertOSToLatLon(firsteasting, firstnorthing);
                //var lastconvert = NEConverter.ConvertOSToLatLon(lasteasting, lastnorthing);
                row.Cells[3].Value = firstconvert.Latitude;
                row.Cells[4].Value = firstconvert.Longitude;
                //row.Cells[7].Value = lastconvert.Latitude;
                //row.Cells[8].Value = lastconvert.Longitude;
     
            }

            MessageBox.Show("Success, please save the conversion");
            
        }
        /*This code opens the mapping windows form and copies the case name to the mapping windows form */
        private void btn_Mapping_Click(object sender, EventArgs e)
        {
            string cn = txb_caseName_tp.Text;
            var tp = new cdrv4.Forms.Map(cn);
            tp.ShowDialog();
        }
        /*This code updates the table with the new latitude and longitude fields listed in the datagridview */
        private void btn_SaveLatLong_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2_tp.Rows)
            {   
                string table = txb_caseName_tp.Text;
                using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
                using (var sqlcmd = new SqlCommand("UPDATE [dbo].[" + table + "] SET FirstCellLatitude='" + row.Cells[3].Value + "', FirstCellLongitude='" + row.Cells[4].Value + "' WHERE LineId ='" + row.Cells[0].Value + "';", con))

            {
                con.Open();
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }
            }
            MessageBox.Show("Conversion saved for first cell easting and first cell northing");
        }

        


    }
}
