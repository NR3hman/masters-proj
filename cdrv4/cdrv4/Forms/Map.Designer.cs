namespace cdrv4.Forms
{
    partial class Map
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Plot = new System.Windows.Forms.Button();
            this.btn_GetLatLon = new System.Windows.Forms.Button();
            this.txb_caseName_m = new System.Windows.Forms.TextBox();
            this.lb_CaseName_tp = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.dataGridView_LatLon = new System.Windows.Forms.DataGridView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LatLon)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.btn_Plot);
            this.splitContainer1.Panel1.Controls.Add(this.btn_GetLatLon);
            this.splitContainer1.Panel1.Controls.Add(this.txb_caseName_m);
            this.splitContainer1.Panel1.Controls.Add(this.lb_CaseName_tp);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Exit);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_LatLon);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(952, 564);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Plot
            // 
            this.btn_Plot.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_Plot.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Plot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Plot.Location = new System.Drawing.Point(13, 497);
            this.btn_Plot.Name = "btn_Plot";
            this.btn_Plot.Size = new System.Drawing.Size(154, 40);
            this.btn_Plot.TabIndex = 14;
            this.btn_Plot.Text = "Plot";
            this.btn_Plot.UseVisualStyleBackColor = false;
            this.btn_Plot.Click += new System.EventHandler(this.btn_Plot_Click);
            // 
            // btn_GetLatLon
            // 
            this.btn_GetLatLon.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_GetLatLon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_GetLatLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GetLatLon.Location = new System.Drawing.Point(13, 451);
            this.btn_GetLatLon.Name = "btn_GetLatLon";
            this.btn_GetLatLon.Size = new System.Drawing.Size(154, 40);
            this.btn_GetLatLon.TabIndex = 13;
            this.btn_GetLatLon.Text = "Get Lat and Long";
            this.btn_GetLatLon.UseVisualStyleBackColor = false;
            this.btn_GetLatLon.Click += new System.EventHandler(this.btn_GetLatLon_Click);
            // 
            // txb_caseName_m
            // 
            this.txb_caseName_m.Location = new System.Drawing.Point(116, 12);
            this.txb_caseName_m.Name = "txb_caseName_m";
            this.txb_caseName_m.ReadOnly = true;
            this.txb_caseName_m.Size = new System.Drawing.Size(183, 20);
            this.txb_caseName_m.TabIndex = 11;
            this.txb_caseName_m.TextChanged += new System.EventHandler(this.txb_caseName_m_TextChanged);
            // 
            // lb_CaseName_tp
            // 
            this.lb_CaseName_tp.AutoSize = true;
            this.lb_CaseName_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CaseName_tp.Location = new System.Drawing.Point(9, 11);
            this.lb_CaseName_tp.Name = "lb_CaseName_tp";
            this.lb_CaseName_tp.Size = new System.Drawing.Size(96, 20);
            this.lb_CaseName_tp.TabIndex = 10;
            this.lb_CaseName_tp.Text = "Case Name:";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(214, 512);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 40);
            this.btn_Exit.TabIndex = 9;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dataGridView_LatLon
            // 
            this.dataGridView_LatLon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LatLon.Location = new System.Drawing.Point(13, 38);
            this.dataGridView_LatLon.Name = "dataGridView_LatLon";
            this.dataGridView_LatLon.Size = new System.Drawing.Size(250, 394);
            this.dataGridView_LatLon.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(631, 564);
            this.webBrowser1.TabIndex = 0;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 564);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Map";
            this.Text = "Map";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LatLon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_LatLon;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TextBox txb_caseName_m;
        private System.Windows.Forms.Label lb_CaseName_tp;
        private System.Windows.Forms.Button btn_GetLatLon;
        private System.Windows.Forms.Button btn_Plot;

    }
}