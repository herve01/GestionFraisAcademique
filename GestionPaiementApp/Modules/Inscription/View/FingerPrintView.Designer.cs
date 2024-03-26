
namespace GestionPaiementApp.Modules.Inscription.View
{
    partial class FingerPrintView
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
            this.lblmsg = new System.Windows.Forms.Label();
            this.flowLayoutPanelFingers = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDoigts = new System.Windows.Forms.ComboBox();
            this.btnValide = new System.Windows.Forms.Button();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Location = new System.Drawing.Point(36, 247);
            this.lblmsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(413, 44);
            this.lblmsg.TabIndex = 1;
            this.lblmsg.Text = "Laissez reposer puis levez 4 fois votre le même doigt";
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelFingers
            // 
            this.flowLayoutPanelFingers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelFingers.Location = new System.Drawing.Point(9, 296);
            this.flowLayoutPanelFingers.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelFingers.Name = "flowLayoutPanelFingers";
            this.flowLayoutPanelFingers.Size = new System.Drawing.Size(466, 141);
            this.flowLayoutPanelFingers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Positionnez votre doigt";
            // 
            // cmbDoigts
            // 
            this.cmbDoigts.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDoigts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDoigts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDoigts.FormattingEnabled = true;
            this.cmbDoigts.Location = new System.Drawing.Point(168, 42);
            this.cmbDoigts.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDoigts.Name = "cmbDoigts";
            this.cmbDoigts.Size = new System.Drawing.Size(143, 25);
            this.cmbDoigts.TabIndex = 34;
            this.cmbDoigts.SelectedIndexChanged += new System.EventHandler(this.cmbDoigts_SelectedIndexChanged);
            // 
            // btnValide
            // 
            this.btnValide.FlatAppearance.BorderSize = 0;
            this.btnValide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValide.Image = global::GestionPaiementApp.Properties.Resources.Document_Check;
            this.btnValide.Location = new System.Drawing.Point(441, 7);
            this.btnValide.Margin = new System.Windows.Forms.Padding(2);
            this.btnValide.Name = "btnValide";
            this.btnValide.Size = new System.Drawing.Size(34, 32);
            this.btnValide.TabIndex = 58;
            this.btnValide.UseVisualStyleBackColor = true;
            this.btnValide.Click += new System.EventHandler(this.btnValide_Click);
            // 
            // pbFinger
            // 
            this.pbFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinger.Location = new System.Drawing.Point(168, 72);
            this.pbFinger.Margin = new System.Windows.Forms.Padding(2);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(143, 172);
            this.pbFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger.TabIndex = 0;
            this.pbFinger.TabStop = false;
            // 
            // FingerPrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnValide);
            this.Controls.Add(this.cmbDoigts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanelFingers);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.pbFinger);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FingerPrintView";
            this.Size = new System.Drawing.Size(486, 448);
            this.Load += new System.EventHandler(this.FingerPrintView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFinger;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFingers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDoigts;
        private System.Windows.Forms.Button btnValide;
    }
}
