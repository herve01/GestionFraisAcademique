
namespace GestionPaiementApp.Modules.Parametres.View
{
    partial class DbConnectorView
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
            this.txtServeur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbDbs = new System.Windows.Forms.ComboBox();
            this.Faculté = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nom du serveur ou adresse IP *";
            // 
            // txtServeur
            // 
            this.txtServeur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServeur.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtServeur.Location = new System.Drawing.Point(10, 29);
            this.txtServeur.Margin = new System.Windows.Forms.Padding(2);
            this.txtServeur.Name = "txtServeur";
            this.txtServeur.Size = new System.Drawing.Size(346, 25);
            this.txtServeur.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(7, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Port *";
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPort.Location = new System.Drawing.Point(10, 251);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(346, 25);
            this.txtPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Utilisateur *";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserName.Location = new System.Drawing.Point(10, 103);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(346, 25);
            this.txtUserName.TabIndex = 1;
            // 
            // cmbDbs
            // 
            this.cmbDbs.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDbs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDbs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDbs.FormattingEnabled = true;
            this.cmbDbs.Location = new System.Drawing.Point(10, 325);
            this.cmbDbs.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDbs.Name = "cmbDbs";
            this.cmbDbs.Size = new System.Drawing.Size(346, 25);
            this.cmbDbs.TabIndex = 4;
            this.cmbDbs.DropDown += new System.EventHandler(this.cmbDbs_DropDown);
            // 
            // Faculté
            // 
            this.Faculté.AutoSize = true;
            this.Faculté.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Faculté.Location = new System.Drawing.Point(7, 304);
            this.Faculté.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Faculté.Name = "Faculté";
            this.Faculté.Size = new System.Drawing.Size(275, 15);
            this.Faculté.TabIndex = 36;
            this.Faculté.Text = "Sélectionner ou entrer un nom de base de données";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(240, 402);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTest.Location = new System.Drawing.Point(10, 402);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(116, 30);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(7, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Mot de passe *";
            // 
            // txtPW
            // 
            this.txtPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPW.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPW.Location = new System.Drawing.Point(10, 177);
            this.txtPW.Margin = new System.Windows.Forms.Padding(2);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '•';
            this.txtPW.Size = new System.Drawing.Size(346, 25);
            this.txtPW.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPW);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.cmbDbs);
            this.panel1.Controls.Add(this.Faculté);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtServeur);
            this.panel1.Location = new System.Drawing.Point(422, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 452);
            this.panel1.TabIndex = 43;
            // 
            // DbConnectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "DbConnectorView";
            this.Size = new System.Drawing.Size(1071, 474);
            this.Load += new System.EventHandler(this.DbConnectorView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServeur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbDbs;
        private System.Windows.Forms.Label Faculté;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Panel panel1;
    }
}
