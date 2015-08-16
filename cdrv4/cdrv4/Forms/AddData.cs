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
using System.Data.Entity;

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

            var datatable = new DataTable();
            using (var sr = new StreamReader(fileName))
            {
            
            datatable.Columns.Add("LineID");
            datatable.Columns.Add("DateofCall");
            datatable.Columns.Add("TimeofCall");
            datatable.Columns.Add("TypeofCall");
            datatable.Columns.Add("CallingNumber");
            datatable.Columns.Add("CalledNumber");
            datatable.Columns.Add("CallingIMEI");
            datatable.Columns.Add("CalledIMEI");
            datatable.Columns.Add("Duration");
            datatable.Columns.Add("DateTime");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split('\r');

            for (var i = 1; i < rows.Length; i++)
            {
                var r = rows[i];
                string[] items = r.Split(delimiter.ToCharArray());
                datatable.Rows.Add(items);
            }

            this.dataGridView1.DataSource = datatable.DefaultView;
            
            }

            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Parse first and check data before saving");
            }
            else
            {
                createTable();
            }
        }

        private void createTable()
        {
            using (var db = new cdrv4.Database.cdrdbContainer())
            {
                string table = txb_CaseName.Text;
                db.Database.ExecuteSqlCommand("CREATE TABLE [dbo].[" + table + "] ([LineId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,[DateofCall] DATE NULL,[TimeofCall] TIME NULL,[TypeofCall] VARCHAR(70) NULL,[CallingNumber] VARCHAR(15) NULL,[CalledNumber] VARCHAR(15) NULL, [CallingIMEI] VARCHAR(20) NULL, [CalledIMEI] VARCHAR(20) NULL,[Duration] TIME NULL,[DateTime] INT NULL);");
                db.SaveChanges();
                MessageBox.Show("Table created in database, the table name is: " + table);
                copyCSV();
            }
            
        }

        private void copyCSV()
        {
            using (var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=cdrdbv1;Integrated Security=True"))
            {
                con.Open();
                   
                    using (var sbc = new SqlBulkCopy(con))
                    {
                        var dataview = this.dataGridView1.DataSource as DataView;
                        var datatable = dataview.Table;
                        sbc.ColumnMappings.Add("LineId", "LineId");
                        sbc.ColumnMappings.Add("DateofCall", "DateofCall");
                        sbc.ColumnMappings.Add("TimeofCall", "TimeofCall");
                        sbc.ColumnMappings.Add("TypeofCall", "TypeofCall");
                        sbc.ColumnMappings.Add("CallingNumber", "CallingNumber");
                        sbc.ColumnMappings.Add("CalledNumber", "CalledNumber");
                        sbc.ColumnMappings.Add("CallingIMEI", "CallingIMEI");
                        sbc.ColumnMappings.Add("CalledIMEI", "CalledIMEI");
                        //sbc.ColumnMappings.Add("Duration", "Duration");
                        sbc.BatchSize = 10000;
                        sbc.DestinationTableName = txb_CaseName.Text;
                        sbc.WriteToServer(datatable);
                    }
            }
            MessageBox.Show("CSV copied, please click next");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            string casename = txb_CaseName.Text;
            var tp = new cdrv4.Forms.form_ToolsPanel(casename);
            tp.ShowDialog();

        }
    }
}
