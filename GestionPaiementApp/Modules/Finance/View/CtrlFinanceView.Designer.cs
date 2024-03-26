
namespace GestionPaiementApp.Modules.Finance.View
{
    partial class CtrlFinanceView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDept = new System.Windows.Forms.Button();
            this.btnAnnee = new System.Windows.Forms.Button();
            this.btnPromotion = new System.Windows.Forms.Button();
            this.btnFaculte = new System.Windows.Forms.Button();
            this.signMenu = new System.Windows.Forms.Panel();
            this.pnlCtner = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDept);
            this.panel1.Controls.Add(this.btnAnnee);
            this.panel1.Controls.Add(this.btnPromotion);
            this.panel1.Controls.Add(this.btnFaculte);
            this.panel1.Controls.Add(this.signMenu);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 689);
            this.panel1.TabIndex = 0;
            // 
            // btnDept
            // 
            this.btnDept.BackColor = System.Drawing.SystemColors.Control;
            this.btnDept.FlatAppearance.BorderSize = 0;
            this.btnDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDept.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDept.Image = global::GestionPaiementApp.Properties.Resources.Payment_02;
            this.btnDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDept.Location = new System.Drawing.Point(9, 53);
            this.btnDept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(194, 37);
            this.btnDept.TabIndex = 5;
            this.btnDept.Text = "           Paiement frais";
            this.btnDept.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDept.UseVisualStyleBackColor = false;
            this.btnDept.Click += new System.EventHandler(this.btnPaiement_Click);
            // 
            // btnAnnee
            // 
            this.btnAnnee.BackColor = System.Drawing.SystemColors.Control;
            this.btnAnnee.FlatAppearance.BorderSize = 0;
            this.btnAnnee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAnnee.Image = global::GestionPaiementApp.Properties.Resources.Report_Editor;
            this.btnAnnee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnee.Location = new System.Drawing.Point(9, 139);
            this.btnAnnee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnnee.Name = "btnAnnee";
            this.btnAnnee.Size = new System.Drawing.Size(194, 37);
            this.btnAnnee.TabIndex = 3;
            this.btnAnnee.Text = "           Reporting";
            this.btnAnnee.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAnnee.UseVisualStyleBackColor = false;
            this.btnAnnee.Click += new System.EventHandler(this.btnReporting_Click);
            // 
            // btnPromotion
            // 
            this.btnPromotion.BackColor = System.Drawing.SystemColors.Control;
            this.btnPromotion.FlatAppearance.BorderSize = 0;
            this.btnPromotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromotion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPromotion.Image = global::GestionPaiementApp.Properties.Resources.Payment_01;
            this.btnPromotion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromotion.Location = new System.Drawing.Point(9, 96);
            this.btnPromotion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPromotion.Name = "btnPromotion";
            this.btnPromotion.Size = new System.Drawing.Size(194, 37);
            this.btnPromotion.TabIndex = 2;
            this.btnPromotion.Text = "           Contrôle frais";
            this.btnPromotion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPromotion.UseVisualStyleBackColor = false;
            this.btnPromotion.Click += new System.EventHandler(this.btnControlFrais_Click);
            // 
            // btnFaculte
            // 
            this.btnFaculte.BackColor = System.Drawing.SystemColors.Control;
            this.btnFaculte.FlatAppearance.BorderSize = 0;
            this.btnFaculte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFaculte.Image = global::GestionPaiementApp.Properties.Resources.Money;
            this.btnFaculte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFaculte.Location = new System.Drawing.Point(9, 10);
            this.btnFaculte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFaculte.Name = "btnFaculte";
            this.btnFaculte.Size = new System.Drawing.Size(194, 37);
            this.btnFaculte.TabIndex = 1;
            this.btnFaculte.Text = "           Prevision";
            this.btnFaculte.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnFaculte.UseVisualStyleBackColor = false;
            this.btnFaculte.Click += new System.EventHandler(this.btnPrevision_Click);
            // 
            // signMenu
            // 
            this.signMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.signMenu.Location = new System.Drawing.Point(2, 10);
            this.signMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.signMenu.Name = "signMenu";
            this.signMenu.Size = new System.Drawing.Size(6, 37);
            this.signMenu.TabIndex = 0;
            // 
            // pnlCtner
            // 
            this.pnlCtner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCtner.Location = new System.Drawing.Point(205, 37);
            this.pnlCtner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCtner.Name = "pnlCtner";
            this.pnlCtner.Size = new System.Drawing.Size(815, 689);
            this.pnlCtner.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(37, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(45, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlFinanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlCtner);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlFinanceView";
            this.Size = new System.Drawing.Size(1019, 726);
            this.Load += new System.EventHandler(this.CtrlFinanceView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlCtner;
        private System.Windows.Forms.Button btnFaculte;
        private System.Windows.Forms.Panel signMenu;
        private System.Windows.Forms.Button btnPromotion;
        private System.Windows.Forms.Button btnAnnee;
        private System.Windows.Forms.Button btnDept;
        private System.Windows.Forms.Label lblTitle;
    }
}
