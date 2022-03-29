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
                    
                        //Form1 f1 = new Form1(this);
                    
                    MessageBox.Show("Giriş Başarılı");
                    Thread.Sleep(300);
                    this.Close();
                    //form.Owner = this;
                    (this.Owner as Form1).misafirbtn.Enabled = true;
                  
                }
            }
        }
    }
}
