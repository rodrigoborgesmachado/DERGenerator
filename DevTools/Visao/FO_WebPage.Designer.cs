namespace Visao
{
    partial class FO_WebPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pan_tot = new System.Windows.Forms.Panel();
            this.wbr_principal = new System.Windows.Forms.WebBrowser();
            this.pan_tot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_tot
            // 
            this.pan_tot.BackColor = System.Drawing.Color.Transparent;
            this.pan_tot.Controls.Add(this.wbr_principal);
            this.pan_tot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tot.Location = new System.Drawing.Point(0, 0);
            this.pan_tot.Name = "pan_tot";
            this.pan_tot.Size = new System.Drawing.Size(697, 452);
            this.pan_tot.TabIndex = 1;
            // 
            // wbr_principal
            // 
            this.wbr_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbr_principal.Location = new System.Drawing.Point(0, 0);
            this.wbr_principal.MinimumSize = new System.Drawing.Size(23, 23);
            this.wbr_principal.Name = "wbr_principal";
            this.wbr_principal.Size = new System.Drawing.Size(697, 452);
            this.wbr_principal.TabIndex = 1;
            // 
            // FO_WebPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 452);
            this.Controls.Add(this.pan_tot);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_WebPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Page";
            this.pan_tot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_tot;
        private System.Windows.Forms.WebBrowser wbr_principal;
    }
}