using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace cdrv4
{
    public partial class form_AddData : Form
    {
        public form_AddData()
        {
            InitializeComponent();
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txb_selectedFile.Text = openFileDialog.FileName;
            }
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txb_CaseName.Text) || string.IsNullOrEmpty(txb_selectedFile.Text))
            {
                MessageBox.Show("Enter case name and select a file");
            }
            else
            {
                parseCsv();
            }
        }

        private void parseCsv()
        {
            string delimiter = ",";
            string tableName = txb_CaseName.Text;
            string fileName = txb_selectedFile.Text;

            var dataset = new DataSet();
            var sr = new StreamReader(fileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("LineID");
            dataset.Tables[tableName].Columns.Add("CaseName");
            dataset.Tables[tableName].Columns.Add("DateofCall");
            dataset.Tables[tableName].Columns.Add("TimeofCall");
            dataset.Tables[tableName].Columns.Add("TypeofCall");
            dataset.Tables[tableName].Columns.Add("CallingNumber");
            dataset.Tables[tableName].Columns.Add("CalledNumber");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split('\r');

            for (var i = 1; i < rows.Length; i++)
            {
                var r = rows[i];
                string[] items = r.Split(delimiter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);
            }

            this.dataGridView1.DataSource = dataset.Tables[0].DefaultView;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Parse first and check data before saving");
            }
            else
            {
                saveCSV();
            }
        }

        private void saveCSV()
        {
            using (var db = new cdrv4.Database.cdrdbContainer())
            {
                MessageBox.Show("This works");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
