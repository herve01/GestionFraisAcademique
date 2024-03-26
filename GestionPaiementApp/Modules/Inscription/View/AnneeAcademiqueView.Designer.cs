
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class AnneeAcademiqueView
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.dtpOuverture = new System.Windows.Forms.DateTimePicker();
            this.dtpCloture = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlZone = new System.Windows.Forms.Panel();
            this.pnlZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Année Académique *";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(1016, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 41);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(954, 15);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 23);
            this.lblCount.TabIndex = 27;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(523, 14);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(421, 30);
            this.txtResearch.TabIndex = 26;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(317, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 37);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAnnee
            // 
            this.txtAnnee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnnee.Location = new System.Drawing.Point(16, 45);
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(443, 30);
            this.txtAnnee.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(29, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 37);
            this.btnSave.TabIndex = 23;
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
            this.lstViewData.Location = new System.Drawing.Point(523, 62);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(541, 735);
            this.lstViewData.TabIndex = 22;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // dtpOuverture
            // 
            this.dtpOuverture.CustomFormat = "dd/MM/yyyy";
            this.dtpOuverture.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpOuverture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOuverture.Location = new System.Drawing.Point(16, 117);
            this.dtpOuverture.Name = "dtpOuverture";
            this.dtpOuverture.Size = new System.Drawing.Size(443, 30);
            this.dtpOuverture.TabIndex = 30;
            // 
            // dtpCloture
            // 
            this.dtpCloture.CustomFormat = "dd/MM/yyyy";
            this.dtpCloture.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCloture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCloture.Location = new System.Drawing.Point(16, 189);
            this.dtpCloture.Name = "dtpCloture";
            this.dtpCloture.Size = new System.Drawing.Size(443, 30);
            this.dtpCloture.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Date d\'ouverture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Date de clôture";
            // 
            // pnlZone
            // 
            this.pnlZone.Controls.Add(this.label2);
            this.pnlZone.Controls.Add(this.label1);
            this.pnlZone.Controls.Add(this.dtpCloture);
            this.pnlZone.Controls.Add(this.dtpOuverture);
            this.pnlZone.Controls.Add(this.label3);
            this.pnlZone.Controls.Add(this.txtAnnee);
            this.pnlZone.Location = new System.Drawing.Point(13, 17);
            this.pnlZone.Name = "pnlZone";
            this.pnlZone.Size = new System.Drawing.Size(474, 244);
            this.pnlZone.TabIndex = 34;
            // 
            // AnneeAcademiqueView
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
            this.Name = "AnneeAcademiqueView";
            this.Size = new System.Drawing.Size(1088, 848);
            this.Load += new System.EventHandler(this.AnneeAcademiqueView_Load);
            this.pnlZone.ResumeLayout(false);
            this.pnlZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAnnee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.DateTimePicker dtpOuverture;
        private System.Windows.Forms.DateTimePicker dtpCloture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlZone;
    }
}
