
namespace GestionPaiementApp.Modules.Finance.View
{
    partial class ControleFraisView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.lblFinger = new System.Windows.Forms.Label();
            this.pbEtudiant = new System.Windows.Forms.PictureBox();
            this.lblPromotion = new System.Windows.Forms.Label();
            this.lblSexe = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefreshA = new System.Windows.Forms.Button();
            this.cmbAnnee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtResearch = new System.Windows.Forms.TextBox();
            this.lstViewData = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlZone.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEtudiant)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlZone
            // 
            this.pnlZone.Controls.Add(this.groupBox1);
            this.pnlZone.Controls.Add(this.label5);
            this.pnlZone.Controls.Add(this.btnRefreshA);
            this.pnlZone.Controls.Add(this.cmbAnnee);
            this.pnlZone.Controls.Add(this.label1);
            this.pnlZone.Location = new System.Drawing.Point(10, 22);
            this.pnlZone.Margin = new System.Windows.Forms.Padding(2);
            this.pnlZone.Name = "pnlZone";
            this.pnlZone.Size = new System.Drawing.Size(452, 246);
            this.pnlZone.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbError);
            this.groupBox1.Controls.Add(this.lblFinger);
            this.groupBox1.Controls.Add(this.pbEtudiant);
            this.groupBox1.Controls.Add(this.lblPromotion);
            this.groupBox1.Controls.Add(this.lblSexe);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(439, 133);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // pbError
            // 
            this.pbError.Image = global::GestionPaiementApp.Properties.Resources.Close;
            this.pbError.Location = new System.Drawing.Point(371, 26);
            this.pbError.Margin = new System.Windows.Forms.Padding(2);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(36, 32);
            this.pbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbError.TabIndex = 51;
            this.pbError.TabStop = false;
            // 
            // lblFinger
            // 
            this.lblFinger.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinger.Location = new System.Drawing.Point(338, 59);
            this.lblFinger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinger.Name = "lblFinger";
            this.lblFinger.Size = new System.Drawing.Size(97, 44);
            this.lblFinger.TabIndex = 50;
            this.lblFinger.Text = "Empreinte non reconnue";
            this.lblFinger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbEtudiant
            // 
            this.pbEtudiant.Image = global::GestionPaiementApp.Properties.Resources.Woman_04;
            this.pbEtudiant.Location = new System.Drawing.Point(4, 12);
            this.pbEtudiant.Margin = new System.Windows.Forms.Padding(2);
            this.pbEtudiant.Name = "pbEtudiant";
            this.pbEtudiant.Size = new System.Drawing.Size(101, 107);
            this.pbEtudiant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEtudiant.TabIndex = 48;
            this.pbEtudiant.TabStop = false;
            // 
            // lblPromotion
            // 
            this.lblPromotion.AutoSize = true;
            this.lblPromotion.Font = new System.Drawing.Font("Segoe UI", 9.7F);
            this.lblPromotion.Location = new System.Drawing.Point(118, 78);
            this.lblPromotion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromotion.Name = "lblPromotion";
            this.lblPromotion.Size = new System.Drawing.Size(171, 17);
            this.lblPromotion.TabIndex = 40;
            this.lblPromotion.Text = "Promotion : L1 Informatique";
            // 
            // lblSexe
            // 
            this.lblSexe.AutoSize = true;
            this.lblSexe.Font = new System.Drawing.Font("Segoe UI", 9.7F);
            this.lblSexe.Location = new System.Drawing.Point(118, 98);
            this.lblSexe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSexe.Name = "lblSexe";
            this.lblSexe.Size = new System.Drawing.Size(58, 17);
            this.lblSexe.TabIndex = 39;
            this.lblSexe.Text = "Sexe : M";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(108, 55);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(218, 20);
            this.lblName.TabIndex = 38;
            this.lblName.Text = "BISHIMBA LUKASU Anderson";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Etudiant";
            // 
            // btnRefreshA
            // 
            this.btnRefreshA.FlatAppearance.BorderSize = 0;
            this.btnRefreshA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshA.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshA.Location = new System.Drawing.Point(397, 28);
            this.btnRefreshA.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshA.Name = "btnRefreshA";
            this.btnRefreshA.Size = new System.Drawing.Size(34, 33);
            this.btnRefreshA.TabIndex = 29;
            this.btnRefreshA.UseVisualStyleBackColor = true;
            this.btnRefreshA.Click += new System.EventHandler(this.btnRefreshA_Click);
            // 
            // cmbAnnee
            // 
            this.cmbAnnee.BackColor = System.Drawing.SystemColors.Control;
            this.cmbAnnee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnnee.FormattingEnabled = true;
            this.cmbAnnee.Location = new System.Drawing.Point(10, 32);
            this.cmbAnnee.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnnee.Name = "cmbAnnee";
            this.cmbAnnee.Size = new System.Drawing.Size(381, 25);
            this.cmbAnnee.TabIndex = 20;
            this.cmbAnnee.SelectedIndexChanged += new System.EventHandler(this.cmbAnnee_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Année Academique";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.Location = new System.Drawing.Point(910, 25);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(25, 19);
            this.lblCount.TabIndex = 34;
            this.lblCount.Text = "(1)";
            // 
            // txtResearch
            // 
            this.txtResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResearch.Location = new System.Drawing.Point(595, 23);
            this.txtResearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtResearch.Name = "txtResearch";
            this.txtResearch.Size = new System.Drawing.Size(309, 25);
            this.txtResearch.TabIndex = 33;
            this.txtResearch.Tag = "Recherche....";
            this.txtResearch.TextChanged += new System.EventHandler(this.txtResearch_TextChanged);
            // 
            // lstViewData
            // 
            this.lstViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(483, 63);
            this.lstViewData.Margin = new System.Windows.Forms.Padding(2);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(511, 608);
            this.lstViewData.TabIndex = 30;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(957, 20);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 33);
            this.btnRefresh.TabIndex = 35;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ControleFraisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlZone);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtResearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstViewData);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControleFraisView";
            this.Size = new System.Drawing.Size(1007, 689);
            this.Load += new System.EventHandler(this.PaiementFraisView_Load);
            this.pnlZone.ResumeLayout(false);
            this.pnlZone.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEtudiant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlZone;
        private System.Windows.Forms.ComboBox cmbAnnee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtResearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.Button btnRefreshA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPromotion;
        private System.Windows.Forms.Label lblSexe;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbEtudiant;
        private System.Windows.Forms.Label lblFinger;
        private System.Windows.Forms.PictureBox pbError;
    }
}
