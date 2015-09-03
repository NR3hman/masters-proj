﻿using System;
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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ReturnToToolsPanel_Click(object sender, EventArgs e)
        {
            //var tp = new cdrv4.Forms.form_ToolsPanel();
            //tp.Show();
        }

        private void txb_caseName_m_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_GetLatLon_Click(object sender, EventArgs e)
        {
            string table = txb_caseName_m.Text;
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            using (var sqlcmd = new SqlCommand("SELECT FirstCellLatitude, FirstCellLongitude FROM [dbo].[" + table + "];", con))
            using (var adapter = new SqlDataAdapter(sqlcmd))
            {
                con.Open();
                var latlontable = new DataTable();
                adapter.Fill(latlontable);
                dataGridView_LatLon.DataSource = latlontable;   
                con.Close();
            } 
        }

        private void btn_Plot_Click(object sender, EventArgs e)
        {
            try
            {
                var url = new StringBuilder();
                url.Append("https://maps.googleapis.com/maps/api/staticmap?size=631x564&maptype=roadmap&");
                int currentRow = 0;
                foreach (dataGridView_LatLon row in Rows)
                {
                    foreach (dataGridView_LatLon columns in Columns)
                    {
                        url.Append("markers=color:blue%7C");
                        url.Append(dataGridView_LatLon.Rows[currentRow].Cells[col].Value.ToString());
                        currentRow++;

                    }
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