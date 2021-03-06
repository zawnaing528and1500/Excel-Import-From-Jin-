﻿namespace Toyo
{
    partial class Frm_ExcelImportForEmp
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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(16, 80);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(265, 28);
            this.txtFileName.TabIndex = 9;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnimport
            // 
            this.btnimport.Location = new System.Drawing.Point(368, 77);
            this.btnimport.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(75, 31);
            this.btnimport.TabIndex = 8;
            this.btnimport.Text = "Import";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(287, 77);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 31);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.lblHeaderPCat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 43);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.ForeColor = System.Drawing.Color.Blue;
            this.lblSetup.Location = new System.Drawing.Point(11, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(50, 20);
            this.lblSetup.TabIndex = 50;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderPCat.Location = new System.Drawing.Point(69, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(195, 20);
            this.lblHeaderPCat.TabIndex = 48;
            this.lblHeaderPCat.Text = "> Employee Excel Import";
            this.lblHeaderPCat.Click += new System.EventHandler(this.lblHeaderPCat_Click);
            // 
            // Frm_ExcelImportForEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 157);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ExcelImportForEmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Import For Employee";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
    }
}