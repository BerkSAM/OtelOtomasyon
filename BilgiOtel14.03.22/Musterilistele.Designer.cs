namespace BilgiOtel14._03._22
{
    partial class Musterilistele
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
            this.musterilistelepanel = new System.Windows.Forms.Panel();
            this.musteriarabox = new System.Windows.Forms.TextBox();
            this.musterieklebuton = new BilgiOtel14._03._22.RJButton();
            this.musterisorgulabuton = new BilgiOtel14._03._22.RJButton();
            this.musteriview = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.musterilistelepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // musterilistelepanel
            // 
            this.musterilistelepanel.Controls.Add(this.label1);
            this.musterilistelepanel.Controls.Add(this.musteriarabox);
            this.musterilistelepanel.Controls.Add(this.musterieklebuton);
            this.musterilistelepanel.Controls.Add(this.musterisorgulabuton);
            this.musterilistelepanel.Controls.Add(this.musteriview);
            this.musterilistelepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.musterilistelepanel.Location = new System.Drawing.Point(0, 0);
            this.musterilistelepanel.Name = "musterilistelepanel";
            this.musterilistelepanel.Size = new System.Drawing.Size(801, 513);
            this.musterilistelepanel.TabIndex = 0;
            // 
            // musteriarabox
            // 
            this.musteriarabox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.musteriarabox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.musteriarabox.Location = new System.Drawing.Point(60, 60);
            this.musteriarabox.Multiline = true;
            this.musteriarabox.Name = "musteriarabox";
            this.musteriarabox.Size = new System.Drawing.Size(145, 27);
            this.musteriarabox.TabIndex = 16;
            this.musteriarabox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // musterieklebuton
            // 
            this.musterieklebuton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.musterieklebuton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.musterieklebuton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.musterieklebuton.BorderRadius = 20;
            this.musterieklebuton.BorderSize = 0;
            this.musterieklebuton.FlatAppearance.BorderSize = 0;
            this.musterieklebuton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.musterieklebuton.ForeColor = System.Drawing.Color.White;
            this.musterieklebuton.Location = new System.Drawing.Point(587, 49);
            this.musterieklebuton.Name = "musterieklebuton";
            this.musterieklebuton.Size = new System.Drawing.Size(150, 40);
            this.musterieklebuton.TabIndex = 15;
            this.musterieklebuton.Text = "Ekle";
            this.musterieklebuton.TextColor = System.Drawing.Color.White;
            this.musterieklebuton.UseVisualStyleBackColor = false;
            this.musterieklebuton.Click += new System.EventHandler(this.musterieklebuton_Click);
            // 
            // musterisorgulabuton
            // 
            this.musterisorgulabuton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.musterisorgulabuton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.musterisorgulabuton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.musterisorgulabuton.BorderRadius = 20;
            this.musterisorgulabuton.BorderSize = 0;
            this.musterisorgulabuton.FlatAppearance.BorderSize = 0;
            this.musterisorgulabuton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.musterisorgulabuton.ForeColor = System.Drawing.Color.White;
            this.musterisorgulabuton.Location = new System.Drawing.Point(223, 46);
            this.musterisorgulabuton.Name = "musterisorgulabuton";
            this.musterisorgulabuton.Size = new System.Drawing.Size(150, 43);
            this.musterisorgulabuton.TabIndex = 12;
            this.musterisorgulabuton.Text = "Sorgula";
            this.musterisorgulabuton.TextColor = System.Drawing.Color.White;
            this.musterisorgulabuton.UseVisualStyleBackColor = false;
            this.musterisorgulabuton.Click += new System.EventHandler(this.musterisorgulabuton_Click);
            // 
            // musteriview
            // 
            this.musteriview.HideSelection = false;
            this.musteriview.Location = new System.Drawing.Point(44, 118);
            this.musteriview.Name = "musteriview";
            this.musteriview.Size = new System.Drawing.Size(713, 366);
            this.musteriview.TabIndex = 11;
            this.musteriview.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(658, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "Devoloped by Berk SAM";
            // 
            // Musterilistele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 513);
            this.ControlBox = false;
            this.Controls.Add(this.musterilistelepanel);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Musterilistele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musterilistele";
            this.Load += new System.EventHandler(this.Musterilistele_Load);
            this.musterilistelepanel.ResumeLayout(false);
            this.musterilistelepanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel musterilistelepanel;
        private System.Windows.Forms.TextBox musteriarabox;
        private RJButton musterieklebuton;
        private RJButton musterisorgulabuton;
        private System.Windows.Forms.ListView musteriview;
        private System.Windows.Forms.Label label1;
    }
}