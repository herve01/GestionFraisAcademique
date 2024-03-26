
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class InscriptionView
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
            this.components = new System.ComponentModel.Container();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.cmbAnnee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshD = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifierMenuContext = new System.Windows.Forms.ToolStripMenuItem();
            this.changerPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.PhotoMenuContext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FringerMenuContext = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(618, 25);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(25, 19);
            this.lblCount.TabIndex = 27;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(295, 22);
            this.txtResearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(316, 25);
            this.txtResearch.TabIndex = 26;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.Location = new System.Drawing.Point(804, 20);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 30);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Nouvel etudiant";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstViewData
            // 
            this.lstViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(15, 75);
            this.lstViewData.Margin = new System.Windows.Forms.Padding(2);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(916, 597);
            this.lstViewData.TabIndex = 22;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            this.lstViewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstViewData_MouseClick);
            // 
            // btnImprimer
            // 
            this.btnImprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnImprimer.Location = new System.Drawing.Point(706, 21);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(87, 30);
            this.btnImprimer.TabIndex = 29;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = true;
            // 
            // cmbAnnee
            // 
            this.cmbAnnee.BackColor = System.Drawing.SystemColors.Control;
            this.cmbAnnee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnnee.FormattingEnabled = true;
            this.cmbAnnee.Location = new System.Drawing.Point(15, 32);
            this.cmbAnnee.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnnee.Name = "cmbAnnee";
            this.cmbAnnee.Size = new System.Drawing.Size(185, 25);
            this.cmbAnnee.TabIndex = 31;
            this.cmbAnnee.SelectedIndexChanged += new System.EventHandler(this.cmbAnnee_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Année Academique";
            // 
            // btnRefreshD
            // 
            this.btnRefreshD.FlatAppearance.BorderSize = 0;
            this.btnRefreshD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshD.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshD.Location = new System.Drawing.Point(203, 28);
            this.btnRefreshD.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshD.Name = "btnRefreshD";
            this.btnRefreshD.Size = new System.Drawing.Size(34, 33);
            this.btnRefreshD.TabIndex = 32;
            this.btnRefreshD.UseVisualStyleBackColor = true;
            this.btnRefreshD.Click += new System.EventHandler(this.btnRefreshD_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(649, 16);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 33);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifierMenuContext,
            this.changerPhotoToolStripMenuItem,
            this.PhotoMenuContext,
            this.toolStripMenuItem1,
            this.FringerMenuContext});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 82);
            // 
            // ModifierMenuContext
            // 
            this.ModifierMenuContext.Name = "ModifierMenuContext";
            this.ModifierMenuContext.Size = new System.Drawing.Size(170, 22);
            this.ModifierMenuContext.Text = "Modifier";
            this.ModifierMenuContext.Click += new System.EventHandler(this.ModifierMenuContext_Click);
            // 
            // changerPhotoToolStripMenuItem
            // 
            this.changerPhotoToolStripMenuItem.Name = "changerPhotoToolStripMenuItem";
            this.changerPhotoToolStripMenuItem.Size = new System.Drawing.Size(167, 6);
            // 
            // PhotoMenuContext
            // 
            this.PhotoMenuContext.Name = "PhotoMenuContext";
            this.PhotoMenuContext.Size = new System.Drawing.Size(170, 22);
            this.PhotoMenuContext.Text = "Changer photo";
            this.PhotoMenuContext.Click += new System.EventHandler(this.PhotoMenuContext_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // FringerMenuContext
            // 
            this.FringerMenuContext.Name = "FringerMenuContext";
            this.FringerMenuContext.Size = new System.Drawing.Size(170, 22);
            this.FringerMenuContext.Text = "Ajouter empreinte";
            this.FringerMenuContext.Click += new System.EventHandler(this.FringerMenuContext_Click);
            // 
            // InscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshD);
            this.Controls.Add(this.cmbAnnee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstViewData);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InscriptionView";
            this.Size = new System.Drawing.Size(948, 689);
            this.Load += new System.EventHandler(this.InscriptionView_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.Button btnRefreshD;
        private System.Windows.Forms.ComboBox cmbAnnee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ModifierMenuContext;
        private System.Windows.Forms.ToolStripMenuItem PhotoMenuContext;
        private System.Windows.Forms.ToolStripSeparator changerPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FringerMenuContext;
    }
}
