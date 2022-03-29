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
    public partial class Personellistele : Form
    {
        public Personellistele()
        {
            InitializeComponent();
        }

        private void personeleklebuton_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.TopLevel = false;
            personel.FormBorderStyle = FormBorderStyle.None;
            personel.Dock = DockStyle.Fill;
            personellistelepanel.Controls.Add(personel);
            personellistelepanel.Tag = personel;
            personel.BringToFront();
            personel.Show();
        }

        private void personelsorgulabuton_Click(object sender, EventArgs e)
        {
            personelview.Items.Clear();
            if (personelarabox.Text != string.Empty)
            {

                SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("select * from tbl_Personel where PersonelTcKimlikk= '" + personelarabox.Text + "'", false, null);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["PersonelId"].ToString());
                    item.SubItems.Add(dr["PersonelAd"].ToString());
                    item.SubItems.Add(dr["PersonelSoyad"].ToString());
                    item.SubItems.Add(dr["PersonelTcKimlik"].ToString());
                    item.SubItems.Add(dr["PersonelDogumTarihi"].ToString());
                    item.SubItems.Add(dr["PersonelIseGirisTarihi"].ToString());
                    item.SubItems.Add(dr["PersonelTelefon"].ToString());
                    item.SubItems.Add(dr["PersonelAcilDurumKisiAd"].ToString());
                    item.SubItems.Add(dr["PersonelAcilDurumKisiTelefon"].ToString());
                    personelview.Items.Add(item);
                }

            }
            else if (personelarabox.Text == string.Empty)
            {
                SqlParameter[] paramses = new SqlParameter[2];
                paramses[0] = new SqlParameter("@tarih1", Convert.ToDateTime(personelilktarih.Text));
                paramses[1] = new SqlParameter("@tarih2", Convert.ToDateTime(personelsontarih.Text));

                SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("sp_Isegirispersonel", true, paramses);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["PersonelId"].ToString());
                    item.SubItems.Add(dr["PersonelAd"].ToString());
                    item.SubItems.Add(dr["PersonelSoyad"].ToString());
                    item.SubItems.Add(dr["PersonelTcKimlik"].ToString());
                    item.SubItems.Add(dr["PersonelDogumTarihi"].ToString());
                    item.SubItems.Add(dr["PersonelIseGirisTarihi"].ToString());
                    item.SubItems.Add(dr["PersonelTelefon"].ToString());
                    item.SubItems.Add(dr["PersonelAcilDurumKisiAd"].ToString());
                    item.SubItems.Add(dr["PersonelAcilDurumKisiTelefon"].ToString());
                    personelview.Items.Add(item);
                }
                dr.Close();
            }
        }

        private void Personellistele_Load(object sender, EventArgs e)
        {
            //MisafirView Gridler
            personelview.Clear();
            personelview.GridLines = true;
            personelview.View = View.Details;
            personelview.Columns.Add("ID", 40);
            personelview.Columns.Add("Personel Ad", 75);
            personelview.Columns.Add("Personel Soyad", 75);
            personelview.Columns.Add("Personel TC", 109);
            personelview.Columns.Add("Personel Dogum", 100);
            personelview.Columns.Add("Personel İş Giriş", 100);
            personelview.Columns.Add("Personel Telefon", 109);
            personelview.Columns.Add("Personel AD Kişi", 100);
            personelview.Columns.Add("Personel AD Tel", 100);
            personelview.CheckBoxes = true;

            //Misafir view temizle
            personelview.Items.Clear();


            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Personel", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["PersonelId"].ToString());
                item.SubItems.Add(dr["PersonelAd"].ToString());
                item.SubItems.Add(dr["PersonelSoyad"].ToString());
                item.SubItems.Add(dr["PersonelTcKimlik"].ToString());
                item.SubItems.Add(dr["PersonelDogumTarihi"].ToString());
                item.SubItems.Add(dr["PersonelIseGirisTarihi"].ToString());
                item.SubItems.Add(dr["PersonelTelefon"].ToString());
                item.SubItems.Add(dr["PersonelAcilDurumKisiAd"].ToString());
                item.SubItems.Add(dr["PersonelAcilDurumKisiTelefon"].ToString());
                personelview.Items.Add(item);
            }
            dr.Close();
        }
    }
}
