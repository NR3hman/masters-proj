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
    public partial class Map : Form
    {
        public Map(string cn)
        {
            InitializeComponent();
            txb_caseName_m.Text = cn;
        }
        /*This code exits the windows form */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txb_caseName_m_TextChanged(object sender, EventArgs e)
        {

        }
        /* This code uses a sql command to select the first cell latitude and longitude values */
        private void btn_GetLatLon_Click(object sender, EventArgs e)
        {
            string table = txb_caseName_m.Text;
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            using (var sqlcmd = new SqlCommand("SELECT FirstCellLatitude, FirstCellLongitude FROM [dbo].[" + table + "] WHERE FirstCellLatitude IS NOT NULL AND FirstCellLongitude IS NOT NULL;", con))
            using (var adapter = new SqlDataAdapter(sqlcmd))
            {
                con.Open();
                var latlontable = new DataTable();
                adapter.Fill(latlontable);
                dataGridView_LatLon.DataSource = latlontable;   
                con.Close();
            } 
        }

        /*This uses string builder to add to the google maps api URL that uses static maps to plot the latitude and longitude
         * values onto the map and then uses the URL to appear in the web browser on the right hand side of the window*/
        private void btn_Plot_Click(object sender, EventArgs e)
        {
            try
            {
                var url = new StringBuilder();
                url.Append("https://maps.googleapis.com/maps/api/staticmap?size=631x564&maptype=roadmap&key=AIzaSyBaVyAY-MArqBZxggHjmI60nz33_hb9WkU");

                foreach (DataGridViewRow row in dataGridView_LatLon.Rows)
                {
                    var lat = row.Cells[0].Value;
                    var lon = row.Cells[1].Value;
                    if (lat == null || lon == null) continue;
                    url.Append("&markers=color:blue%7C");
                    url.Append(lat.ToString());
                    url.Append(",");
                    url.Append(lon.ToString());   
                }

                webBrowser1.Navigate(url.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    }
}
