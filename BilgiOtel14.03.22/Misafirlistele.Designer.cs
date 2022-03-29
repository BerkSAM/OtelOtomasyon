namespace BilgiOtel14._03._22
{
    partial class Misafirlistele
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
            this.components = new System.ComponentModel.Container();
            this.misafirlistelepanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.misafirarabox = new System.Windows.Forms.TextBox();
            this.mekleyon = new BilgiOtel14._03._22.RJButton();
            this.misafirtarihsondt = new BilgiOtel14._03._22.Components.RJDatePicker();
            this.misafirtarihilkdt = new BilgiOtel14._03._22.Components.RJDatePicker();
            this.rjButton1 = new BilgiOtel14._03._22.RJButton();
            this.misafirview = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.işlemYAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misafirlistelepanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // misafirlistelepanel
            // 
            this.misafirlistelepanel.Controls.Add(this.label1);
            this.misafirlistelepanel.Controls.Add(this.misafirarabox);
            this.misafirlistelepanel.Controls.Add(this.mekleyon);
            this.misafirlistelepanel.Controls.Add(this.misafirtarihsondt);
            this.misafirlistelepanel.Controls.Add(this.misafirtarihilkdt);
            this.misafirlistelepanel.Controls.Add(this.rjButton1);
            this.misafirlistelepanel.Controls.Add(this.misafirview);
            this.misafirlistelepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.misafirlistelepanel.Location = new System.Drawing.Point(0, 0);
            this.misafirlistelepanel.Name = "misafirlistelepanel";
            this.misafirlistelepanel.Size = new System.Drawing.Size(801, 513);
            this.misafirlistelepanel.TabIndex = 0;
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
            // misafirarabox
            // 
            this.misafirarabox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.misafirarabox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.misafirarabox.Location = new System.Drawing.Point(215, 29);
            this.misafirarabox.Multiline = true;
            this.misafirarabox.Name = "misafirarabox";
            this.misafirarabox.Size = new System.Drawing.Size(145, 27);
            this.misafirarabox.TabIndex = 10;
            this.misafirarabox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.misafirarabox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // mekleyon
            // 
            this.mekleyon.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.mekleyon.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.mekleyon.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.mekleyon.BorderRadius = 20;
            this.mekleyon.BorderSize = 0;
            this.mekleyon.FlatAppearance.BorderSize = 0;
            this.mekleyon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mekleyon.ForeColor = System.Drawing.Color.White;
            this.mekleyon.Location = new System.Drawing.Point(587, 49);
            this.mekleyon.Name = "mekleyon";
            this.mekleyon.Size = new System.Drawing.Size(150, 40);
            this.mekleyon.TabIndex = 9;
            this.mekleyon.Text = "Ekle";
            this.mekleyon.TextColor = System.Drawing.Color.White;
            this.mekleyon.UseVisualStyleBackColor = false;
            this.mekleyon.Click += new System.EventHandler(this.mekleyon_Click);
            // 
            // misafirtarihsondt
            // 
            this.misafirtarihsondt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.misafirtarihsondt.BorderSize = 0;
            this.misafirtarihsondt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.misafirtarihsondt.Location = new System.Drawing.Point(43, 70);
            this.misafirtarihsondt.MinimumSize = new System.Drawing.Size(4, 35);
            this.misafirtarihsondt.Name = "misafirtarihsondt";
            this.misafirtarihsondt.Size = new System.Drawing.Size(144, 35);
            this.misafirtarihsondt.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.misafirtarihsondt.TabIndex = 8;
            this.misafirtarihsondt.TextColor = System.Drawing.Color.White;
            this.misafirtarihsondt.ValueChanged += new System.EventHandler(this.rjDatePicker2_ValueChanged);
            // 
            // misafirtarihilkdt
            // 
            this.misafirtarihilkdt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.misafirtarihilkdt.BorderSize = 0;
            this.misafirtarihilkdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.misafirtarihilkdt.Location = new System.Drawing.Point(43, 29);
            this.misafirtarihilkdt.MinimumSize = new System.Drawing.Size(4, 35);
            this.misafirtarihilkdt.Name = "misafirtarihilkdt";
            this.misafirtarihilkdt.Size = new System.Drawing.Size(144, 35);
            this.misafirtarihilkdt.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.misafirtarihilkdt.TabIndex = 7;
            this.misafirtarihilkdt.TextColor = System.Drawing.Color.White;
            this.misafirtarihilkdt.ValueChanged += new System.EventHandler(this.rjDatePicker1_ValueChanged);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(210, 62);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(150, 43);
            this.rjButton1.TabIndex = 6;
            this.rjButton1.Text = "Sorgula";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // misafirview
            // 
            this.misafirview.ContextMenuStrip = this.contextMenuStrip1;
            this.misafirview.HideSelection = false;
            this.misafirview.Location = new System.Drawing.Point(44, 118);
            this.misafirview.Name = "misafirview";
            this.misafirview.Size = new System.Drawing.Size(713, 366);
            this.misafirview.TabIndex = 5;
            this.misafirview.UseCompatibleStateImageBehavior = false;
            this.misafirview.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemYAPToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // işlemYAPToolStripMenuItem
            // 
            this.işlemYAPToolStripMenuItem.Name = "işlemYAPToolStripMenuItem";
            this.işlemYAPToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.işlemYAPToolStripMenuItem.Text = "İşlem YAP";
            this.işlemYAPToolStripMenuItem.Click += new System.EventHandler(this.işlemYAPToolStripMenuItem_Click);
            // 
            // Misafirlistele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 513);
            this.Controls.Add(this.misafirlistelepanel);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Misafirlistele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misafirlistele";
            this.Load += new System.EventHandler(this.Misafirlistele_Load);
            this.misafirlistelepanel.ResumeLayout(false);
            this.misafirlistelepanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel misafirlistelepanel;
        private RJButton mekleyon;
        private Components.RJDatePicker misafirtarihsondt;
        private Components.RJDatePicker misafirtarihilkdt;
        private RJButton rjButton1;
        private System.Windows.Forms.ListView misafirview;
        private System.Windows.Forms.TextBox misafirarabox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemYAPToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}