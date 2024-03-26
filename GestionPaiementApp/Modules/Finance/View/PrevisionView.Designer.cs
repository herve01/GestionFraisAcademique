
namespace GestionPaiementApp.Modules.Finance.View
{
    partial class PrevisionView
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
            this.pnlZone = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.cmbNiveau = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAnnee = new System.Windows.Forms.ComboBox();
            this.txtNbreTranche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.tranchePanel = new System.Windows.Forms.Panel();
            this.btnRefreshA = new System.Windows.Forms.Button();
            this.btnRefreshN = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlZone
            // 
            this.pnlZone.Controls.Add(this.label4);
            this.pnlZone.Controls.Add(this.label2);
            this.pnlZone.Controls.Add(this.txtMontant);
            this.pnlZone.Controls.Add(this.btnRefreshA);
            this.pnlZone.Controls.Add(this.btnRefreshN);
            this.pnlZone.Controls.Add(this.cmbNiveau);
            this.pnlZone.Controls.Add(this.label5);
            this.pnlZone.Controls.Add(this.label3);
            this.pnlZone.Controls.Add(this.cmbAnnee);
            this.pnlZone.Controls.Add(this.txtNbreTranche);
            this.pnlZone.Controls.Add(this.label1);
            this.pnlZone.Location = new System.Drawing.Point(19, 28);
            this.pnlZone.Name = "pnlZone";
            this.pnlZone.Size = new System.Drawing.Size(471, 295);
            this.pnlZone.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(15, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.label4.Size = new System.Drawing.Size(56, 30);
            this.label4.TabIndex = 33;
            this.label4.Text = "       $";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(11, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Montant";
            // 
            // txtMontant
            // 
            this.txtMontant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontant.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMontant.Location = new System.Drawing.Point(71, 191);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(387, 30);
            this.txtMontant.TabIndex = 30;
            this.txtMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbNiveau
            // 
            this.cmbNiveau.BackColor = System.Drawing.SystemColors.Control;
            this.cmbNiveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNiveau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNiveau.FormattingEnabled = true;
            this.cmbNiveau.Location = new System.Drawing.Point(15, 120);
            this.cmbNiveau.Name = "cmbNiveau";
            this.cmbNiveau.Size = new System.Drawing.Size(389, 31);
            this.cmbNiveau.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(11, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Niveau";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(11, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nombre tranche";
            // 
            // cmbAnnee
            // 
            this.cmbAnnee.BackColor = System.Drawing.SystemColors.Control;
            this.cmbAnnee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnnee.FormattingEnabled = true;
            this.cmbAnnee.Location = new System.Drawing.Point(15, 50);
            this.cmbAnnee.Name = "cmbAnnee";
            this.cmbAnnee.Size = new System.Drawing.Size(389, 31);
            this.cmbAnnee.TabIndex = 20;
            // 
            // txtNbreTranche
            // 
            this.txtNbreTranche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNbreTranche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNbreTranche.Location = new System.Drawing.Point(15, 259);
            this.txtNbreTranche.Name = "txtNbreTranche";
            this.txtNbreTranche.Size = new System.Drawing.Size(443, 30);
            this.txtNbreTranche.TabIndex = 15;
            this.txtNbreTranche.TextChanged += new System.EventHandler(this.txtNbreTranche_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Année Academique";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(959, 31);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 23);
            this.lblCount.TabIndex = 34;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(526, 28);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(423, 30);
            this.txtResearch.TabIndex = 33;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(322, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 37);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(34, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 37);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstViewData
            // 
            this.lstViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(526, 78);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(543, 747);
            this.lstViewData.TabIndex = 30;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // tranchePanel
            // 
            this.tranchePanel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tranchePanel.Location = new System.Drawing.Point(19, 329);
            this.tranchePanel.Name = "tranchePanel";
            this.tranchePanel.Size = new System.Drawing.Size(471, 92);
            this.tranchePanel.TabIndex = 37;
            // 
            // btnRefreshA
            // 
            this.btnRefreshA.FlatAppearance.BorderSize = 0;
            this.btnRefreshA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshA.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshA.Location = new System.Drawing.Point(413, 45);
            this.btnRefreshA.Name = "btnRefreshA";
            this.btnRefreshA.Size = new System.Drawing.Size(45, 41);
            this.btnRefreshA.TabIndex = 29;
            this.btnRefreshA.UseVisualStyleBackColor = true;
            this.btnRefreshA.Click += new System.EventHandler(this.btnRefreshA_Click);
            // 
            // btnRefreshN
            // 
            this.btnRefreshN.FlatAppearance.BorderSize = 0;
            this.btnRefreshN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshN.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshN.Location = new System.Drawing.Point(413, 115);
            this.btnRefreshN.Name = "btnRefreshN";
            this.btnRefreshN.Size = new System.Drawing.Size(45, 41);
            this.btnRefreshN.TabIndex = 28;
            this.btnRefreshN.UseVisualStyleBackColor = true;
            this.btnRefreshN.Click += new System.EventHandler(this.btnRefreshN_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(1021, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 41);
            this.btnRefresh.TabIndex = 35;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PrevisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tranchePanel);
            this.Controls.Add(this.pnlZone);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstViewData);
            this.Name = "PrevisionView";
            this.Size = new System.Drawing.Size(1088, 848);
            this.Load += new System.EventHandler(this.PrevisionView_Load);
            this.pnlZone.ResumeLayout(false);
            this.pnlZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlZone;
        private System.Windows.Forms.Button btnRefreshN;
        private System.Windows.Forms.ComboBox cmbNiveau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAnnee;
        private System.Windows.Forms.TextBox txtNbreTranche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.Panel tranchePanel;
        private System.Windows.Forms.Button btnRefreshA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label4;
    }
}
