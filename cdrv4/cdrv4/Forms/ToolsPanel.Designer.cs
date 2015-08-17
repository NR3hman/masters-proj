﻿namespace cdrv4.Forms
{
    partial class form_ToolsPanel
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
            this.lb_CaseName_tp = new System.Windows.Forms.Label();
            this.txb_caseName_tp = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_CheckDuplicates = new System.Windows.Forms.Button();
            this.btn_MergeDuplicates = new System.Windows.Forms.Button();
            this.dataGridView2_tp = new System.Windows.Forms.DataGridView();
            this.btn_AcceptDuplicates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_tp)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_CaseName_tp
            // 
            this.lb_CaseName_tp.AutoSize = true;
            this.lb_CaseName_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CaseName_tp.Location = new System.Drawing.Point(12, 9);
            this.lb_CaseName_tp.Name = "lb_CaseName_tp";
            this.lb_CaseName_tp.Size = new System.Drawing.Size(96, 20);
            this.lb_CaseName_tp.TabIndex = 4;
            this.lb_CaseName_tp.Text = "Case Name:";
            // 
            // txb_caseName_tp
            // 
            this.txb_caseName_tp.Location = new System.Drawing.Point(119, 10);
            this.txb_caseName_tp.Name = "txb_caseName_tp";
            this.txb_caseName_tp.ReadOnly = true;
            this.txb_caseName_tp.Size = new System.Drawing.Size(252, 20);
            this.txb_caseName_tp.TabIndex = 5;
            this.txb_caseName_tp.TextChanged += new System.EventHandler(this.txb_caseName_tp_TextChanged);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(870, 472);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 40);
            this.btn_Exit.TabIndex = 8;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_CheckDuplicates
            // 
            this.btn_CheckDuplicates.BackColor = System.Drawing.Color.LightCoral;
            this.btn_CheckDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CheckDuplicates.Location = new System.Drawing.Point(16, 371);
            this.btn_CheckDuplicates.Name = "btn_CheckDuplicates";
            this.btn_CheckDuplicates.Size = new System.Drawing.Size(160, 36);
            this.btn_CheckDuplicates.TabIndex = 9;
            this.btn_CheckDuplicates.Text = "Check duplicates";
            this.btn_CheckDuplicates.UseVisualStyleBackColor = false;
            this.btn_CheckDuplicates.Click += new System.EventHandler(this.btn_CheckDuplicates_Click);
            // 
            // btn_MergeDuplicates
            // 
            this.btn_MergeDuplicates.BackColor = System.Drawing.Color.LightCoral;
            this.btn_MergeDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MergeDuplicates.Location = new System.Drawing.Point(16, 456);
            this.btn_MergeDuplicates.Name = "btn_MergeDuplicates";
            this.btn_MergeDuplicates.Size = new System.Drawing.Size(160, 36);
            this.btn_MergeDuplicates.TabIndex = 10;
            this.btn_MergeDuplicates.Text = "Merge duplicates";
            this.btn_MergeDuplicates.UseVisualStyleBackColor = false;
            this.btn_MergeDuplicates.Click += new System.EventHandler(this.btn_MergeDuplicates_Click);
            // 
            // dataGridView2_tp
            // 
            this.dataGridView2_tp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_tp.Location = new System.Drawing.Point(16, 65);
            this.dataGridView2_tp.Name = "dataGridView2_tp";
            this.dataGridView2_tp.Size = new System.Drawing.Size(954, 283);
            this.dataGridView2_tp.TabIndex = 11;
            this.dataGridView2_tp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_AcceptDuplicates
            // 
            this.btn_AcceptDuplicates.BackColor = System.Drawing.Color.LightCoral;
            this.btn_AcceptDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AcceptDuplicates.Location = new System.Drawing.Point(16, 414);
            this.btn_AcceptDuplicates.Name = "btn_AcceptDuplicates";
            this.btn_AcceptDuplicates.Size = new System.Drawing.Size(160, 36);
            this.btn_AcceptDuplicates.TabIndex = 12;
            this.btn_AcceptDuplicates.Text = "Accept duplicates";
            this.btn_AcceptDuplicates.UseVisualStyleBackColor = false;
            this.btn_AcceptDuplicates.Click += new System.EventHandler(this.btn_AcceptDuplicates_Click);
            // 
            // form_ToolsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 524);
            this.Controls.Add(this.btn_AcceptDuplicates);
            this.Controls.Add(this.dataGridView2_tp);
            this.Controls.Add(this.btn_MergeDuplicates);
            this.Controls.Add(this.btn_CheckDuplicates);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.txb_caseName_tp);
            this.Controls.Add(this.lb_CaseName_tp);
            this.Name = "form_ToolsPanel";
            this.Text = "ToolsPanel";
            this.Load += new System.EventHandler(this.form_ToolsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_tp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_CaseName_tp;
        private System.Windows.Forms.TextBox txb_caseName_tp;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_CheckDuplicates;
        private System.Windows.Forms.Button btn_MergeDuplicates;
        private System.Windows.Forms.DataGridView dataGridView2_tp;
        private System.Windows.Forms.Button btn_AcceptDuplicates;
    }
}