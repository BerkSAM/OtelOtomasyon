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
    public partial class Oda : Form
    {
        public Oda()
        {
            InitializeComponent();
        }

        private void Oda_Load(object sender, EventArgs e)
        {

            //Kampanyalardan indirim oranları alınır.
            satisindirimbox.Items.Add(0);
            SqlDataReader okuyucu2 = HelperSQL.SqlOkuyucuDondurWithSp("select KampanyaIndirimOran from  tbl_Kampanyalar", false, null);
            if (okuyucu2.HasRows)
            {
                while (okuyucu2.Read())
                {
                    satisindirimbox.Items.Add(okuyucu2["KampanyaIndirimOran"].ToString());
                }
            }
            okuyucu2.Close();

            //MusteriView Gridler
            musteriview.Clear();
            musteriview.GridLines = true;
            musteriview.View = View.Details;
            musteriview.Columns.Add("Musteri ID", 45);
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
                ListViewItem item = new ListViewItem(dr["MusteriID"].ToString());
                item.SubItems.Add(dr["MusteriAd"].ToString());
                item.SubItems.Add(dr["MusteriSoyad"].ToString());
                item.SubItems.Add(dr["MusteriUnvan"].ToString());
                item.SubItems.Add(dr["MusteriYetkiliAdSoyad"].ToString());
                item.SubItems.Add(dr["MusteriTelefon"].ToString());
                item.SubItems.Add(dr["MusteriPosta"].ToString());
                item.SubItems.Add(dr["MusteriKurumsalOK"].ToString());
                musteriview.Items.Add(item);
            }
            dr.Close();

            //MisafirView Gridler
            misafirview.Clear();
            misafirview.GridLines = true;
            misafirview.View = View.Details;
            misafirview.Columns.Add("Misafir ID", 45);
            misafirview.Columns.Add("Misafir TC", 100);
            misafirview.Columns.Add("Misafir Ad", 100);
            misafirview.Columns.Add("Misafir Soyad", 100);
            misafirview.Columns.Add("Misafir Dogum Tarihi", 109);
            misafirview.Columns.Add("Misafir EPosta", 100);
            misafirview.Columns.Add("Misafir Telefon", 100);
            misafirview.CheckBoxes = true;

            //Misafir view temizle
            misafirview.Items.Clear();


            SqlDataReader dr2 = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Misafir", false, null);
            while (dr2.Read())
            {
                ListViewItem item = new ListViewItem(dr2["MisafirId"].ToString());
                item.SubItems.Add(dr2["MisafirTcKimlik"].ToString());
                item.SubItems.Add(dr2["MisafirAd"].ToString());
                item.SubItems.Add(dr2["MisafirSoyad"].ToString());
                item.SubItems.Add(dr2["MisafirDogumTarihi"].ToString());
                item.SubItems.Add(dr2["MisafirEposta"].ToString());
                item.SubItems.Add(dr2["MisafirTelefon"].ToString());
                item.SubItems.Add(dr2["MisafirHesKod"].ToString());
                misafirview.Items.Add(item);
            }
            dr2.Close();
        }

        private void odanobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            odemetipibox.Enabled = true;
            SqlDataReader okuyucu3 = HelperSQL.SqlOkuyucuDondurWithSp("select OdaSatisTipAd from tbl_OdaSatisTip", false, null);
            if (okuyucu3.HasRows)
            {
                while (okuyucu3.Read())
                {
                    odemetipibox.Items.Add(okuyucu3["OdaSatisTipAd"].ToString());
                }
            }
            okuyucu3.Close();




        }

        private void satisindirimbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kartbox.Enabled = true;
            //Kartlar yüklenir
            for (int i = 0; i < 101; i++)
            {
                kartbox.Items.Add(i);
            }
        }


        private void kartbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            odanobox.Enabled = true;
            //OdaNolar Keyvaluepair ile yüklenir
            List<KeyValuePair<int, int>> data = new List<KeyValuePair<int, int>>();
            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select tbl_Odalar.OdaId,tbl_Odalar.OdaNo from tbl_Odalar join tbl_OdaDurum on tbl_Odalar.OdaId = tbl_OdaDurum.OdaId where tbl_OdaDurum.DurumKategoriId = 1", false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    data.Add(new KeyValuePair<int, int>(Convert.ToInt32(okuyucu["OdaId"]), Convert.ToInt32(okuyucu["OdaNo"])));

                }
                odanobox.DataSource = new BindingSource(data, null);
                odanobox.DisplayMember = "Value";
                odanobox.ValueMember = "Key";
            }
            okuyucu.Close();
        }

        private void odemetipibox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (odemetipibox.SelectedIndex == 0 || odemetipibox.SelectedIndex == 1)
            {
                SqlDataReader sqlDataReader = HelperSQL.SqlOkuyucuDondurWithSp("Select OdaFiyat from tbl_Odalar where OdaId=" + odanobox.SelectedValue, false, null);
                sqlDataReader.Read();
                if (satisindirimbox.Text == Convert.ToString(0))
                {
                    label4.Text = sqlDataReader["OdaFiyat"].ToString();
                }
                else
                {
                    int fiyat = Convert.ToInt32(sqlDataReader["OdaFiyat"]);
                    int tutar = Convert.ToInt32(sqlDataReader["OdaFiyat"]);
                    tutar *= Convert.ToInt32(satisindirimbox.Text);
                    tutar /= 100;
                    label4.Text = Convert.ToString(fiyat - tutar);
                }
            }
            else
            {
                MessageBox.Show("Şuanlık sadece tam pansiyon satışı vardır. Otomatik olarak tam pansiyona çevrilmiştir");
                odemetipibox.SelectedIndex = 0;

            }
        }

        private void odemetipibox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader sqlDataReader = HelperSQL.SqlOkuyucuDondurWithSp("Select OdaFiyat from tbl_Odalar where OdaId=" + odanobox.SelectedValue, false, null);
            sqlDataReader.Read();
            if (satisindirimbox.Text == Convert.ToString(0))
            {
                label4.Text = sqlDataReader["OdaFiyat"].ToString();
            }
            else
            {
                int fiyat = Convert.ToInt32(sqlDataReader["OdaFiyat"]);
                int tutar = Convert.ToInt32(sqlDataReader["OdaFiyat"]);
                tutar *= Convert.ToInt32(satisindirimbox.Text);
                tutar /= 100;
                label4.Text = Convert.ToString(fiyat - tutar);
            }
        }

        private void satisbtn(object sender, EventArgs e)
        {

            if (misafirview.CheckedItems.Count == 1)
            {
                //Müşteriyi Diziye Ekle
                int mmevcut = musteriview.CheckedItems.Count;
                string[] musteri = new string[mmevcut];
                foreach (ListViewItem item in musteriview.CheckedItems)
                {
                    var MID = item.SubItems[0].Text;
                    musteri[0] = MID;

                }

                //Misafirleri Diziye Ekle

                int mevcut = misafirview.CheckedItems.Count;
                string[] misafir = new string[mevcut];
                int i = 0;
                foreach (ListViewItem item in misafirview.CheckedItems)
                {
                    var ID = item.SubItems[0].Text;
                    misafir[i] = ID;
                    i++;
                }

                //Satışı Gerçekleştir
                SqlParameter[] paramses = new SqlParameter[11];
                paramses[0] = new SqlParameter("@SatisOdaGirisTarihi", Convert.ToDateTime(odagirisdt.Value));
                paramses[1] = new SqlParameter("@SatisOdaCikisTarihi", Convert.ToDateTime(odacikisdt.Value));
                paramses[2] = new SqlParameter("@SatisIndirim", satisindirimbox.Text);
                paramses[3] = new SqlParameter("@KartId", kartbox.Text);
                paramses[4] = new SqlParameter("@OdaId", ((KeyValuePair<int, int>)odanobox.SelectedItem).Key);
                paramses[5] = new SqlParameter("@OdaSatisDurum", checkBox1.Checked);
                paramses[6] = new SqlParameter("@OdaSatisTutar", Convert.ToDecimal(label4.Text));
                paramses[7] = new SqlParameter("@OdaSatisKDV", 18);
                paramses[8] = new SqlParameter("@OdaSatisOdemeTipiId", odemetipibox.SelectedIndex + 1);
                paramses[9] = new SqlParameter("@MusteriId", musteri[0]);
                paramses[10] = new SqlParameter("@MisafirId", misafir[0]);


                int ess = HelperSQL.SqlGeriDondurmezWithSp("sp_satis", true, paramses);
                MessageBox.Show(ess > 0 ? "Satış başarılı" : "Satış başarısız");
            }
            else if (misafirview.CheckedItems.Count == 2)
            {
                //Müşteriyi Diziye Ekle
                int mmevcut = musteriview.CheckedItems.Count;
                string[] musteri = new string[mmevcut];
                foreach (ListViewItem item in musteriview.CheckedItems)
                {
                    var MID = item.SubItems[0].Text;
                    musteri[0] = MID;

                }

                //Misafirleri Diziye Ekle

                int mevcut = misafirview.CheckedItems.Count;
                string[] misafir = new string[mevcut];
                int i = 0;
                foreach (ListViewItem item in misafirview.CheckedItems)
                {
                    var ID = item.SubItems[0].Text;
                    misafir[i] = ID;
                    i++;
                }

                //Satışı Gerçekleştir
                SqlParameter[] paramses = new SqlParameter[12];
                paramses[0] = new SqlParameter("@SatisOdaGirisTarihi", Convert.ToDateTime(odagirisdt.Value));
                paramses[1] = new SqlParameter("@SatisOdaCikisTarihi", Convert.ToDateTime(odacikisdt.Value));
                paramses[2] = new SqlParameter("@SatisIndirim", satisindirimbox.Text);
                paramses[3] = new SqlParameter("@KartId", kartbox.Text);
                paramses[4] = new SqlParameter("@OdaId", ((KeyValuePair<int, int>)odanobox.SelectedItem).Key);
                paramses[5] = new SqlParameter("@OdaSatisDurum", checkBox1.Checked);
                paramses[6] = new SqlParameter("@OdaSatisTutar", Convert.ToDecimal(label4.Text));
                paramses[7] = new SqlParameter("@OdaSatisKDV", 18);
                paramses[8] = new SqlParameter("@OdaSatisOdemeTipiId", odemetipibox.SelectedIndex + 1);
                paramses[9] = new SqlParameter("@MusteriId", musteri[0]);
                paramses[10] = new SqlParameter("@MisafirId", misafir[0]);
                paramses[11] = new SqlParameter("@MisafirId2", misafir[1]);

                int ess = HelperSQL.SqlGeriDondurmezWithSp("sp_satisikili", true, paramses);
                MessageBox.Show(ess > 0 ? "Satış başarılı" : "Satış başarısız");

            }


        }

        private void odanobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, int> selectedPair = (KeyValuePair<int, int>)odanobox.SelectedItem;
        }

        private void musteriview_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem secilen = musteriview.FocusedItem;//focusedıtem senin seçtiğin listview itemi alır
            //secilen.Checked = secilen.SubItems[0].Text;
            string degisken = secilen.SubItems[0].Text;
            MessageBox.Show(degisken);

        }

        private void musteriview_DoubleClick(object sender, EventArgs e)
        {

        }

        private void musteriara_TextChanged(object sender, EventArgs e)
        {
            musteriview.Items.Clear();
            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Musteriler where MusteriAd like '" + musteriara.Text + "%'", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["MusteriID"].ToString());
                item.SubItems.Add(dr["MusteriAd"].ToString());
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

        private void misafirara_TextChanged(object sender, EventArgs e)
        {
            misafirview.Items.Clear();
            SqlDataReader dr2 = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Misafir where MisafirAd like '" + misafirara.Text + "%'", false, null);
            while (dr2.Read())
            {
                ListViewItem item = new ListViewItem(dr2["MisafirId"].ToString());
                item.SubItems.Add(dr2["MisafirTcKimlik"].ToString());
                item.SubItems.Add(dr2["MisafirAd"].ToString());
                item.SubItems.Add(dr2["MisafirSoyad"].ToString());
                item.SubItems.Add(dr2["MisafirDogumTarihi"].ToString());
                item.SubItems.Add(dr2["MisafirEposta"].ToString());
                item.SubItems.Add(dr2["MisafirTelefon"].ToString());
                item.SubItems.Add(dr2["MisafirHesKod"].ToString());
                misafirview.Items.Add(item);
            }
            dr2.Close();
        }

        private void musteriview_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
