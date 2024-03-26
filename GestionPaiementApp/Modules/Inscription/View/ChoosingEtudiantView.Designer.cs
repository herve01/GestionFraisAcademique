
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class ChoosingEtudiantView
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(1085, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 41);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(1027, 39);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 23);
            this.lblCount.TabIndex = 27;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(430, 37);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(579, 30);
            this.txtResearch.TabIndex = 26;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // lstViewData
            // 
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(20, 83);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(1110, 740);
            this.lstViewData.TabIndex = 22;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            this.lstViewData.SelectedIndexChanged += new System.EventHandler(this.lstViewData_SelectedIndexChanged);
            // 
            // ChoosingEtudiantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.lstViewData);
            this.Name = "ChoosingEtudiantView";
            this.Size = new System.Drawing.Size(1156, 848);
            this.Load += new System.EventHandler(this.InscriptionView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.ListView lstViewData;
    }
}
