
namespace GestionPaiementApp.Modules.Parametres.View
{
    partial class LogView
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
            this.btnRefreshF = new System.Windows.Forms.Button();
            this.cmbFaculte = new System.Windows.Forms.ComboBox();
            this.Faculté = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstViewData
            // 
            this.lstViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstViewData.HideSelection = false;
            this.lstViewData.Location = new System.Drawing.Point(28, 103);
            this.lstViewData.Margin = new System.Windows.Forms.Padding(2);
            this.lstViewData.Name = "lstViewData";
            this.lstViewData.Size = new System.Drawing.Size(962, 535);
            this.lstViewData.TabIndex = 57;
            this.lstViewData.UseCompatibleStateImageBehavior = false;
            // 
            // btnRefreshF
            // 
            this.btnRefreshF.FlatAppearance.BorderSize = 0;
            this.btnRefreshF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshF.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.btnRefreshF.Location = new System.Drawing.Point(328, 51);
            this.btnRefreshF.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshF.Name = "btnRefreshF";
            this.btnRefreshF.Size = new System.Drawing.Size(33, 34);
            this.btnRefreshF.TabIndex = 60;
            this.btnRefreshF.UseVisualStyleBackColor = true;
            // 
            // cmbFaculte
            // 
            this.cmbFaculte.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFaculte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFaculte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFaculte.FormattingEnabled = true;
            this.cmbFaculte.Location = new System.Drawing.Point(28, 56);
            this.cmbFaculte.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFaculte.Name = "cmbFaculte";
            this.cmbFaculte.Size = new System.Drawing.Size(293, 25);
            this.cmbFaculte.TabIndex = 59;
            // 
            // Faculté
            // 
            this.Faculté.AutoSize = true;
            this.Faculté.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Faculté.Location = new System.Drawing.Point(25, 39);
            this.Faculté.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Faculté.Name = "Faculté";
            this.Faculté.Size = new System.Drawing.Size(34, 15);
            this.Faculté.TabIndex = 58;
            this.Faculté.Text = "Table";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::GestionPaiementApp.Properties.Resources.Command_hhhRefresh;
            this.button1.Location = new System.Drawing.Point(714, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 34);
            this.button1.TabIndex = 63;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(414, 60);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 25);
            this.comboBox1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(411, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 61;
            this.label1.Text = "Utilisateur";
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshF);
            this.Controls.Add(this.cmbFaculte);
            this.Controls.Add(this.Faculté);
            this.Controls.Add(this.lstViewData);
            this.Name = "LogView";
            this.Size = new System.Drawing.Size(1007, 689);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewData;
        private System.Windows.Forms.Button btnRefreshF;
        private System.Windows.Forms.ComboBox cmbFaculte;
        private System.Windows.Forms.Label Faculté;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}
