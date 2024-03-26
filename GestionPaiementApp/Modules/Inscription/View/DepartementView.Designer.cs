
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class DepartementView
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
            this.lstViewData = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbFaculte = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlZone = new System.Windows.Forms.Panel();
            this.btnRefreshD = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewData
            // 
            this.lstViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(512, 63);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(544, 756);
            this.lstViewData.TabIndex = 1;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(21, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Faculté";
            // 
            // txtNom
            // 
            this.txtNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNom.Location = new System.Drawing.Point(8, 123);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(443, 91);
            this.txtNom.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(309, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 37);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(512, 11);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(424, 30);
            this.txtResearch.TabIndex = 7;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCount.Location = new System.Drawing.Point(946, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 28);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "(1)";
            // 
            // cmbFaculte
            // 
            this.cmbFaculte.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFaculte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFaculte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFaculte.FormattingEnabled = true;
            this.cmbFaculte.Location = new System.Drawing.Point(8, 41);
            this.cmbFaculte.Name = "cmbFaculte";
            this.cmbFaculte.Size = new System.Drawing.Size(389, 31);
            this.cmbFaculte.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(4, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nom *";
            // 
            // pnlZone
            // 
            this.pnlZone.Controls.Add(this.btnRefreshD);
            this.pnlZone.Controls.Add(this.label3);
            this.pnlZone.Controls.Add(this.cmbFaculte);
            this.pnlZone.Controls.Add(this.txtNom);
            this.pnlZone.Controls.Add(this.label1);
            this.pnlZone.Location = new System.Drawing.Point(13, 14);
            this.pnlZone.Name = "pnlZone";
            this.pnlZone.Size = new System.Drawing.Size(460, 229);
            this.pnlZone.TabIndex = 27;
            // 
            // btnRefreshD
            // 
            this.btnRefreshD.FlatAppearance.BorderSize = 0;
            this.btnRefreshD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshD.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshD.Location = new System.Drawing.Point(406, 36);
            this.btnRefreshD.Name = "btnRefreshD";
            this.btnRefreshD.Size = new System.Drawing.Size(45, 41);
            this.btnRefreshD.TabIndex = 26;
            this.btnRefreshD.UseVisualStyleBackColor = true;
            this.btnRefreshD.Click += new System.EventHandler(this.btnRefreshD_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(1008, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 41);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DepartementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlZone);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstViewData);
            this.Name = "DepartementView";
            this.Size = new System.Drawing.Size(1088, 848);
            this.Load += new System.EventHandler(this.DepartementView_Load);
            this.pnlZone.ResumeLayout(false);
            this.pnlZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbFaculte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshD;
        private System.Windows.Forms.Panel pnlZone;
    }
}
