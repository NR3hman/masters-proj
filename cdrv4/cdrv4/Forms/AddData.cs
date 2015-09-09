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

        //This buttton opens up file explorer and allows the user to select the file.
        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txb_selectedFile.Text = openFileDialog.FileName;
            }
        }
        //This displays a message to prompt the user to enter a case name to the file.
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

        /*This code using streamreader to read through the CSV and add the data to a datatable called 'datatable' this is then displayed
        in the data grid view */
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
                datatable.Columns.Add("FirstCellEasting");
                datatable.Columns.Add("FirstCellNorthing");
                datatable.Columns.Add("LastCellEasting");
                datatable.Columns.Add("LastCellNorthing");
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
        /*This code prompts the user to parse the CSV before saving the data  */
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
        /*This code uses the SQL command to create the table using the case name entered by the user as the table name */
        private void createTable()
        {
            using (var db = new cdrv4.Database.cdrdbContainer())
            {
                string table = txb_CaseName.Text;
                db.Database.ExecuteSqlCommand("CREATE TABLE [dbo].[" + table + "] ([LineId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,[DateofCall] DATE NULL,[TimeofCall] TIME NULL,[TypeofCall] VARCHAR(70) NULL,[CallingNumber] VARCHAR(15) NULL,[CalledNumber] VARCHAR(15) NULL, [CallingIMEI] VARCHAR(20) NULL, [CalledIMEI] VARCHAR(20) NULL,[Duration] VARCHAR(30) NULL,[DateTime] VARCHAR(50) NULL, [IsDuplicate] INT NULL, [FirstCellEasting] VARCHAR(50) NULL, [FirstCellNorthing] VARCHAR(50) NULL, [LastCellEasting] VARCHAR(50) NULL, [LastCellNorthing] VARCHAR(50) NULL, [FirstCellLatitude] VARCHAR(50) NULL, [FirstCellLongitude] VARCHAR(50) NULL, [LastCellLatitude] VARCHAR(50) NULL, [LastCellLongitude] VARCHAR(50) NULL);");
                db.SaveChanges();
                MessageBox.Show("Table created in database, the table name is: " + table);
                copyCSV();
            }
            
        }
        /*This code copies the data from the CSV into the table that has just been created */
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
                        sbc.ColumnMappings.Add("Duration", "Duration");
                        sbc.ColumnMappings.Add("DateTime", "DateTime");
                        sbc.ColumnMappings.Add("FirstCellEasting", "FirstCellEasting");
                        sbc.ColumnMappings.Add("FirstCellNorthing", "FirstCellNorthing");
                        sbc.ColumnMappings.Add("LastCellEasting", "LastCellEasting");
                        sbc.ColumnMappings.Add("LastCellNorthing", "LastCellNorthing");
                        sbc.DestinationTableName = txb_CaseName.Text;
                        sbc.WriteToServer(datatable);
                    }
            }
            MessageBox.Show("CSV copied, please click next");
        }

        /*This button exits the application */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* This code copies the case name from the text box in this windows form to the tools panel windows form*/
        private void btn_Next_Click(object sender, EventArgs e)
        {
            string casename = txb_CaseName.Text;
            var tp = new cdrv4.Forms.form_ToolsPanel(casename);
            tp.ShowDialog();

        }
    }
}
