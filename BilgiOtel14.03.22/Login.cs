using Bilgi_Hotel_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiOtel14._03._22
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private Form1 form1;

        public Login(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void personelgiris_Click(object sender, EventArgs e)
        {

            if (loginbox.Text == string.Empty)
            {
                MessageBox.Show("Lütfen TC giriniz.");
            }
            else if (loginbox.Text != string.Empty)
            {
                var sonuc = HelperSQL.SqlNesneDondurWithSP("select ResimId from tbl_Personel where PersonelTcKimlik='" + loginbox.Text + "'", false, null);
                if (sonuc == null)
                {
                    MessageBox.Show("Böyle bir personel bulunmamakta");
                }
                else if (sonuc != null)
                {
                    MessageBox.Show("Giriş Başarılı");
                    Thread.Sleep(300);
                    (this.Owner as Form1).pictureBox1.Image = Image.FromFile(Convert.ToString(HelperSQL.SqlNesneDondurWithSP("Select ResimUrlAdres from tbl_Resimler where ResimId=" + sonuc, false, null)));
                    (this.Owner as Form1).prsadlabel.Text = Convert.ToString(HelperSQL.SqlNesneDondurWithSP("Select PersonelAd from tbl_Personel where PersonelTcKimlik='" + loginbox.Text + "'", false, null));
                    (this.Owner as Form1).misafirbtn.Enabled = true;
                    (this.Owner as Form1).musteribtn.Enabled = true;
                    (this.Owner as Form1).kampanyabtn.Enabled = true;
                    (this.Owner as Form1).personelbtn.Enabled = true;
                    (this.Owner as Form1).odabtn.Enabled = true;
                    (this.Owner as Form1).kampanyabtn.Enabled = true;

                }
            }
        }
    }
}
