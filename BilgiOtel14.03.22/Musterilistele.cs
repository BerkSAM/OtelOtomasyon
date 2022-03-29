using Bilgi_Hotel_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiOtel14._03._22
{
    public partial class Musterilistele : Form
    {
        public Musterilistele()
        {
            InitializeComponent();
        }

        private void Musterilistele_Load(object sender, EventArgs e)
        {
            //MusteriView Gridler
            musteriview.Clear();
            musteriview.GridLines = true;
            musteriview.View = View.Details;
            musteriview.Columns.Add("Musteri Ad", 100);
            musteriview.Columns.Add("Musteri Soyad", 100);
            musteriview.Columns.Add("Musteri Unvan", 100);
            musteriview.Columns.Add("Musteri Yetkili A/S", 109);
            musteriview.Columns.Add("Musteri Telefon", 100);
            musteriview.Columns.Add("Musteri Eposta", 100);
            musteriview.Columns.Add("Musteri Kurumsal", 100);
            musteriview.CheckBoxes = true;

            //MusteriView temizle
            musteriview.Items.Clear();


            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Musteriler", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["MusteriAd"].ToString());
                item.SubItems.Add(dr["MusteriSoyad"].ToString());
                item.SubItems.Add(dr["MusteriUnvan"].ToString());
                item.SubItems.Add(dr["MusteriYetkiliAdSoyad"].ToString());
                item.SubItems.Add(dr["MusteriTelefon"].ToString());
                item.SubItems.Add(dr["MusteriPosta"].ToString());
                item.SubItems.Add(dr["MusteriKurumsalOK"].ToString());
                musteriview.Items.Add(item);
            }
            dr.Close();
        }

        private void musterieklebuton_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.TopLevel = false;
            musteri.FormBorderStyle = FormBorderStyle.None;
            musteri.Dock = DockStyle.Fill;
            musterilistelepanel.Controls.Add(musteri);
            musterilistelepanel.Tag = musteri;
            musteri.BringToFront();
            musteri.Show();
        }

        private void musterisorgulabuton_Click(object sender, EventArgs e)
        {
            musteriview.Items.Clear();
            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("select * from tbl_Musteriler where MusteriTCKimlik= '" + musteriarabox.Text + "' or MusteriVergiNo= '" +musteriarabox.Text +"'", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["MusteriAd"].ToString());
                item.SubItems.Add(dr["MusteriSoyad"].ToString());
                item.SubItems.Add(dr["MusteriUnvan"].ToString());
                item.SubItems.Add(dr["MusteriYetkiliAdSoyad"].ToString());
                item.SubItems.Add(dr["MusteriTelefon"].ToString());
                item.SubItems.Add(dr["MusteriPosta"].ToString());
                item.SubItems.Add(dr["MusteriKurumsalOK"].ToString());
                musteriview.Items.Add(item);
            }
        }
    }
}
