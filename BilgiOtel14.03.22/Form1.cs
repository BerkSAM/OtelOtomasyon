using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiOtel14._03._22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void misafirbtn_Click(object sender, EventArgs e)
        {
            pnlislem.Controls.Clear();
            Misafirlistele misafirlistele = new Misafirlistele();
            misafirlistele.TopLevel = false;
            pnlislem.Controls.Add(misafirlistele);
            misafirlistele.Show();
            misafirlistele.Dock = DockStyle.Fill;
            misafirlistele.BringToFront();
            misafirbtn.BackColor = Color.DarkSlateBlue;
            musteribtn.BackColor = Color.MediumSlateBlue;
            personelbtn.BackColor = Color.MediumSlateBlue;
            odabtn.BackColor = Color.MediumSlateBlue;
            kampanyabtn.BackColor = Color.MediumSlateBlue;
        }

        private void musteribtn_Click(object sender, EventArgs e)
        {
            pnlislem.Controls.Clear();
            Musterilistele musterilistele = new Musterilistele();
            musterilistele.TopLevel = false;
            pnlislem.Controls.Add(musterilistele);
            musterilistele.Show();
            musterilistele.Dock = DockStyle.Fill;
            musterilistele.BringToFront();
            misafirbtn.BackColor = Color.MediumSlateBlue;
            musteribtn.BackColor = Color.DarkSlateBlue;
            personelbtn.BackColor = Color.MediumSlateBlue;
            odabtn.BackColor = Color.MediumSlateBlue;
            kampanyabtn.BackColor = Color.MediumSlateBlue;
        }

        private void personelbtn_Click(object sender, EventArgs e)
        {
            pnlislem.Controls.Clear();
            Personellistele personellistele = new Personellistele();
            personellistele.TopLevel = false;
            pnlislem.Controls.Add(personellistele);
            personellistele.Show();
            personellistele.Dock = DockStyle.Fill;
            personellistele.BringToFront();
            misafirbtn.BackColor = Color.MediumSlateBlue;
            musteribtn.BackColor = Color.MediumSlateBlue;
            personelbtn.BackColor = Color.DarkSlateBlue;
            odabtn.BackColor = Color.MediumSlateBlue;
            kampanyabtn.BackColor = Color.MediumSlateBlue;
        }

        private void kampanyabtn_Click(object sender, EventArgs e)
        {
            pnlislem.Controls.Clear();
            Kampanya kampanya = new Kampanya();
            kampanya.TopLevel = false;
            pnlislem.Controls.Add(kampanya);
            kampanya.Show();
            kampanya.Dock = DockStyle.Fill;
            kampanya.BringToFront();
            misafirbtn.BackColor = Color.MediumSlateBlue;
            musteribtn.BackColor = Color.MediumSlateBlue;
            personelbtn.BackColor = Color.MediumSlateBlue;
            odabtn.BackColor = Color.MediumSlateBlue;
            kampanyabtn.BackColor = Color.DarkSlateBlue;
        }

        private void odabtn_Click(object sender, EventArgs e)
        {
            pnlislem.Controls.Clear();
            odalistele odalistele = new odalistele();
            odalistele.TopLevel = false;
            pnlislem.Controls.Add(odalistele);
            odalistele.Show();
            odalistele.Dock = DockStyle.Fill;
            odalistele.BringToFront();
            misafirbtn.BackColor = Color.MediumSlateBlue;
            musteribtn.BackColor = Color.MediumSlateBlue;
            personelbtn.BackColor = Color.MediumSlateBlue;
            odabtn.BackColor = Color.DarkSlateBlue;
            kampanyabtn.BackColor = Color.MediumSlateBlue;
        }
    }
}
