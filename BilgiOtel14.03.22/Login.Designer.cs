namespace BilgiOtel14._03._22
{
    partial class Login
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
            this.pnllogin = new System.Windows.Forms.Panel();
            this.loginbox = new System.Windows.Forms.TextBox();
            this.personelgiris = new BilgiOtel14._03._22.RJButton();
            this.pnllogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnllogin
            // 
            this.pnllogin.Controls.Add(this.personelgiris);
            this.pnllogin.Controls.Add(this.loginbox);
            this.pnllogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnllogin.Location = new System.Drawing.Point(0, 0);
            this.pnllogin.Name = "pnllogin";
            this.pnllogin.Size = new System.Drawing.Size(801, 513);
            this.pnllogin.TabIndex = 0;
            // 
            // loginbox
            // 
            this.loginbox.BackColor = System.Drawing.Color.Silver;
            this.loginbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginbox.Location = new System.Drawing.Point(320, 218);
            this.loginbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loginbox.Name = "loginbox";
            this.loginbox.Size = new System.Drawing.Size(116, 23);
            this.loginbox.TabIndex = 4;
            // 
            // personelgiris
            // 
            this.personelgiris.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.personelgiris.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.personelgiris.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.personelgiris.BorderRadius = 20;
            this.personelgiris.BorderSize = 0;
            this.personelgiris.FlatAppearance.BorderSize = 0;
            this.personelgiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personelgiris.ForeColor = System.Drawing.Color.White;
            this.personelgiris.Location = new System.Drawing.Point(287, 248);
            this.personelgiris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.personelgiris.Name = "personelgiris";
            this.personelgiris.Size = new System.Drawing.Size(175, 46);
            this.personelgiris.TabIndex = 5;
            this.personelgiris.Text = "Personel Giriş";
            this.personelgiris.TextColor = System.Drawing.Color.White;
            this.personelgiris.UseVisualStyleBackColor = false;
            this.personelgiris.Click += new System.EventHandler(this.personelgiris_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 513);
            this.Controls.Add(this.pnllogin);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Login";
            this.Text = "Login";
            this.pnllogin.ResumeLayout(false);
            this.pnllogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnllogin;
        private RJButton personelgiris;
        private System.Windows.Forms.TextBox loginbox;
    }
}