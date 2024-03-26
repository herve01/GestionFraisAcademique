
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class PromotionView
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNiveau = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFiliere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.cmbDepartement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFaculte = new System.Windows.Forms.ComboBox();
            this.Faculté = new System.Windows.Forms.Label();
            this.pnlZone = new System.Windows.Forms.Panel();
            this.btnRefreshN = new System.Windows.Forms.Button();
            this.btnRefreshF = new System.Windows.Forms.Button();
            this.btnRefreshD = new System.Windows.Forms.Button();
            this.btnAddNiveau = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(10, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Filiere";
            // 
            // cmbNiveau
            // 
            this.cmbNiveau.BackColor = System.Drawing.SystemColors.Control;
            this.cmbNiveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNiveau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNiveau.FormattingEnabled = true;
            this.cmbNiveau.Location = new System.Drawing.Point(15, 175);
            this.cmbNiveau.Name = "cmbNiveau";
            this.cmbNiveau.Size = new System.Drawing.Size(357, 31);
            this.cmbNiveau.TabIndex = 20;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(954, 21);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 23);
            this.lblCount.TabIndex = 18;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(521, 18);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(423, 30);
            this.txtResearch.TabIndex = 17;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(316, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 37);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtFiliere
            // 
            this.txtFiliere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiliere.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFiliere.Location = new System.Drawing.Point(14, 243);
            this.txtFiliere.Multiline = true;
            this.txtFiliere.Name = "txtFiliere";
            this.txtFiliere.Size = new System.Drawing.Size(443, 91);
            this.txtFiliere.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(10, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Niveau";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(28, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 37);
            this.btnSave.TabIndex = 13;
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
            this.lstViewData.Location = new System.Drawing.Point(521, 68);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(543, 747);
            this.lstViewData.TabIndex = 12;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // cmbDepartement
            // 
            this.cmbDepartement.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDepartement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepartement.FormattingEnabled = true;
            this.cmbDepartement.Location = new System.Drawing.Point(15, 107);
            this.cmbDepartement.Name = "cmbDepartement";
            this.cmbDepartement.Size = new System.Drawing.Size(389, 31);
            this.cmbDepartement.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Departement";
            // 
            // cmbFaculte
            // 
            this.cmbFaculte.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFaculte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFaculte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFaculte.FormattingEnabled = true;
            this.cmbFaculte.Location = new System.Drawing.Point(15, 39);
            this.cmbFaculte.Name = "cmbFaculte";
            this.cmbFaculte.Size = new System.Drawing.Size(389, 31);
            this.cmbFaculte.TabIndex = 27;
            // 
            // Faculté
            // 
            this.Faculté.AutoSize = true;
            this.Faculté.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Faculté.Location = new System.Drawing.Point(11, 15);
            this.Faculté.Name = "Faculté";
            this.Faculté.Size = new System.Drawing.Size(55, 20);
            this.Faculté.TabIndex = 26;
            this.Faculté.Text = "Faculté";
            // 
            // pnlZone
            // 
            this.pnlZone.Controls.Add(this.btnRefreshN);
            this.pnlZone.Controls.Add(this.btnRefreshF);
            this.pnlZone.Controls.Add(this.cmbFaculte);
            this.pnlZone.Controls.Add(this.Faculté);
            this.pnlZone.Controls.Add(this.btnRefreshD);
            this.pnlZone.Controls.Add(this.btnAddNiveau);
            this.pnlZone.Controls.Add(this.cmbDepartement);
            this.pnlZone.Controls.Add(this.label2);
            this.pnlZone.Controls.Add(this.label3);
            this.pnlZone.Controls.Add(this.cmbNiveau);
            this.pnlZone.Controls.Add(this.txtFiliere);
            this.pnlZone.Controls.Add(this.label1);
            this.pnlZone.Location = new System.Drawing.Point(14, 18);
            this.pnlZone.Name = "pnlZone";
            this.pnlZone.Size = new System.Drawing.Size(471, 346);
            this.pnlZone.TabIndex = 29;
            // 
            // btnRefreshN
            // 
            this.btnRefreshN.FlatAppearance.BorderSize = 0;
            this.btnRefreshN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshN.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshN.Location = new System.Drawing.Point(413, 170);
            this.btnRefreshN.Name = "btnRefreshN";
            this.btnRefreshN.Size = new System.Drawing.Size(44, 42);
            this.btnRefreshN.TabIndex = 29;
            this.btnRefreshN.UseVisualStyleBackColor = true;
            this.btnRefreshN.Click += new System.EventHandler(this.btnRefreshN_Click);
            // 
            // btnRefreshF
            // 
            this.btnRefreshF.FlatAppearance.BorderSize = 0;
            this.btnRefreshF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshF.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshF.Location = new System.Drawing.Point(413, 34);
            this.btnRefreshF.Name = "btnRefreshF";
            this.btnRefreshF.Size = new System.Drawing.Size(44, 42);
            this.btnRefreshF.TabIndex = 28;
            this.btnRefreshF.UseVisualStyleBackColor = true;
            this.btnRefreshF.Click += new System.EventHandler(this.btnRefreshF_Click);
            // 
            // btnRefreshD
            // 
            this.btnRefreshD.FlatAppearance.BorderSize = 0;
            this.btnRefreshD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshD.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshD.Location = new System.Drawing.Point(413, 101);
            this.btnRefreshD.Name = "btnRefreshD";
            this.btnRefreshD.Size = new System.Drawing.Size(44, 42);
            this.btnRefreshD.TabIndex = 25;
            this.btnRefreshD.UseVisualStyleBackColor = true;
            this.btnRefreshD.Click += new System.EventHandler(this.btnRefreshD_Click);
            // 
            // btnAddNiveau
            // 
            this.btnAddNiveau.FlatAppearance.BorderSize = 0;
            this.btnAddNiveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNiveau.Image = global::GestionPaiementApp.Properties.Resources.Data_Edit;
            this.btnAddNiveau.Location = new System.Drawing.Point(381, 175);
            this.btnAddNiveau.Name = "btnAddNiveau";
            this.btnAddNiveau.Size = new System.Drawing.Size(28, 31);
            this.btnAddNiveau.TabIndex = 24;
            this.btnAddNiveau.UseVisualStyleBackColor = true;
            this.btnAddNiveau.Click += new System.EventHandler(this.btnAddNiveau_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(1016, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 41);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PromotionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlZone);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstViewData);
            this.Name = "PromotionView";
            this.Size = new System.Drawing.Size(1088, 848);
            this.Load += new System.EventHandler(this.PromotionView_Load);
            this.pnlZone.ResumeLayout(false);
            this.pnlZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNiveau;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFiliere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.ComboBox cmbDepartement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNiveau;
        private System.Windows.Forms.Button btnRefreshD;
        private System.Windows.Forms.Button btnRefreshF;
        private System.Windows.Forms.ComboBox cmbFaculte;
        private System.Windows.Forms.Label Faculté;
        private System.Windows.Forms.Panel pnlZone;
        private System.Windows.Forms.Button btnRefreshN;
    }
}
