﻿
namespace GestionPaiementApp.Global
{
    partial class Popup
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
            this.pnlCtnr = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlCtnr
            // 
            this.pnlCtnr.AutoSize = true;
            this.pnlCtnr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCtnr.Location = new System.Drawing.Point(0, 0);
            this.pnlCtnr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCtnr.Name = "pnlCtnr";
            this.pnlCtnr.Size = new System.Drawing.Size(600, 366);
            this.pnlCtnr.TabIndex = 0;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pnlCtnr);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.Load += new System.EventHandler(this.Popup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCtnr;
    }
}