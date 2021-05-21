namespace Visao
{
    partial class FO_Consulta
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
            this.tbx_nomeCampo = new System.Windows.Forms.TextBox();
            this.grb_consulta = new System.Windows.Forms.GroupBox();
            this.grb_consulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_nomeCampo
            // 
            this.tbx_nomeCampo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_nomeCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_nomeCampo.Location = new System.Drawing.Point(3, 19);
            this.tbx_nomeCampo.MaxLength = 5000;
            this.tbx_nomeCampo.Multiline = true;
            this.tbx_nomeCampo.Name = "tbx_nomeCampo";
            this.tbx_nomeCampo.Size = new System.Drawing.Size(434, 355);
            this.tbx_nomeCampo.TabIndex = 9;
            // 
            // grb_consulta
            // 
            this.grb_consulta.Controls.Add(this.tbx_nomeCampo);
            this.grb_consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_consulta.Location = new System.Drawing.Point(0, 0);
            this.grb_consulta.Name = "grb_consulta";
            this.grb_consulta.Size = new System.Drawing.Size(440, 377);
            this.grb_consulta.TabIndex = 10;
            this.grb_consulta.TabStop = false;
            this.grb_consulta.Text = "Consulta";
            // 
            // FO_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(440, 377);
            this.Controls.Add(this.grb_consulta);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_Consulta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.grb_consulta.ResumeLayout(false);
            this.grb_consulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_nomeCampo;
        private System.Windows.Forms.GroupBox grb_consulta;
    }
}