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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        string yol;
        private void personelresimbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            yol = dlg.FileName;

        }

        private void personeleklebtn_Click(object sender, EventArgs e)
        {
            if (yol == null)
            {
                MessageBox.Show("Lütfen fotoğraf ekleyiniz");
            }
            else if (yol != null)
            {
                SqlParameter[] paramses = new SqlParameter[27];
                paramses[0] = new SqlParameter("@ResimUrlAdres", yol);
                paramses[1] = new SqlParameter("@ResimAciklama", Convert.ToString(personeladbox.Text + " adlı kişinin fotoğrafı"));
                paramses[2] = new SqlParameter("@ResimAktifOk", 1);
                paramses[3] = new SqlParameter("@PersonelAd", personeladbox.Text);
                paramses[4] = new SqlParameter("@PersonelSoyad", personelsoyadbox.Text);
                paramses[5] = new SqlParameter("@PersonelTcKimlik", personeltcbox.Text);
                paramses[6] = new SqlParameter("@PersonelDogumTarihi", Convert.ToDateTime(personeldogumdt.Value));
                paramses[7] = new SqlParameter("@PersonelUyrukId", personeluyrukbox.SelectedIndex + 1);
                paramses[8] = new SqlParameter("@PersonelEposta", personelepostabox.Text);
                paramses[9] = new SqlParameter("@PersonelTelefon", personeltelefonbox.Text);
                paramses[10] = new SqlParameter("@PersonelPasaportNo", personelpasaportbox.Text);
                paramses[11] = new SqlParameter("@CinsiyetId", personelcinsiyetbox.SelectedIndex + 1);
                paramses[12] = new SqlParameter("@PersonelIseGirisTarihi", Convert.ToDateTime(personelisegirisdt.Value));
                paramses[13] = new SqlParameter("@PersonelIstenCikisTarihi", Convert.ToDateTime(personelistencikisdt.Value));
                paramses[14] = new SqlParameter("@PersonelSaatlikUcret", Convert.ToDecimal(personelsaatlikbox.Text));
                paramses[15] = new SqlParameter("@PersonelMaas", Convert.ToDecimal(personelmaasbox.Text));
                paramses[16] = new SqlParameter("@PersonelSicilNo", personelsicilbox.Text);
                paramses[17] = new SqlParameter("@GorevId", personelgorevbox.SelectedIndex + 1);
                paramses[18] = new SqlParameter("@YetkiId", personelyetkibox.SelectedIndex + 1);
                paramses[19] = new SqlParameter("@PersonelEngelDurumu", personelengelcheckbox.Checked);
                paramses[20] = new SqlParameter("@PersonelHesKodu", personelhesbox.Text);
                paramses[21] = new SqlParameter("@IlId", personelilbox.SelectedIndex + 1);
                paramses[22] = new SqlParameter("@IlceId", ((KeyValuePair<int, string>)personelilcebox.SelectedItem).Key);
                paramses[23] = new SqlParameter("@UlkeId", personelulkebox.SelectedIndex + 1);
                paramses[24] = new SqlParameter("@PersonelAdres", personeladresbox.Text);
                paramses[25] = new SqlParameter("@PersonelAcilDurumKisiAd", personeladadbox.Text);
                paramses[26] = new SqlParameter("@PersonelAcilDurumKisiTelefon", personeladtelbox.Text);


                int ess = HelperSQL.SqlGeriDondurmezWithSp("sp_personelekle", true, paramses);

                MessageBox.Show(ess > 0 ? "Personel Ekleme Başarılı" : "Personel Ekleme Başarısız");
            }
        }

        private void personelguncellebtn_Click(object sender, EventArgs e)
        {

        }

        private void personelgetirbtn_Click(object sender, EventArgs e)
        {
            if (personeltcbox.Text == string.Empty)
            {
                MessageBox.Show("Lütfen Personelin TC'sini giriniz.");
            }
            else if (personeltcbox.Text != string.Empty)
            {
                var sonuc = HelperSQL.SqlNesneDondurWithSP("select PersonelAd + ' ' + PersonelSoyad from tbl_Personel where PersonelTcKimlik= '" + personeltcbox.Text + "'", false, null);
                if (sonuc == null)
                {
                    MessageBox.Show("Böyle bir misafir bulunmamakta");
                }
                else
                {
                    MessageBox.Show(sonuc + " adlı personelin bilgileri getirilmiştir.");
                    var fotograf = HelperSQL.SqlNesneDondurWithSP("select ResimId from tbl_Personel where PersonelTcKimlik = '" + personeltcbox.Text + "'", false, null);
                    var fotografdondur = HelperSQL.SqlNesneDondurWithSP("select ResimUrlAdres from tbl_Resimler where ResimId= " + fotograf, false, null);
                    SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("select * from tbl_Personel where PersonelTcKimlik = '" + personeltcbox.Text + "'", false, null);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            personeladbox.Text = dr["PersonelAd"].ToString();
                            personelsoyadbox.Text = dr["PersonelSoyad"].ToString();
                            personeltcbox.Text = dr["PersonelTcKimlik"].ToString();
                            personelepostabox.Text = dr["PersonelEposta"].ToString();
                            personeltelefonbox.Text = dr["PersonelTelefon"].ToString();
                            personelpasaportbox.Text = dr["PersonelPasaportNo"].ToString();
                            personelmaasbox.Text = dr["PersonelMaas"].ToString();
                            personelsaatlikbox.Text = dr["PersonelSaatlikUcret"].ToString();
                            personelsicilbox.Text = dr["PersonelSicilNo"].ToString();
                            personelhesbox.Text = dr["PersonelHesKodu"].ToString();
                            personeladresbox.Text = dr["PersonelAdres"].ToString();
                            personeladadbox.Text = dr["PersonelAcilDurumKisiAd"].ToString();
                            personeladtelbox.Text = dr["PersonelAcilDurumKisiTelefon"].ToString();
                            personeldogumdt.Value = Convert.ToDateTime(dr["PersonelDogumTarihi"].ToString());
                            personelisegirisdt.Value = Convert.ToDateTime(dr["PersonelIseGirisTarihi"].ToString());
                            personelistencikisdt.Value = Convert.ToDateTime(dr["PersonelIstenCikisTarihi"].ToString());
                            personeluyrukbox.SelectedIndex = (Convert.ToInt32(dr["PersonelUyrukId"])-1);
                            personelcinsiyetbox.SelectedIndex = (Convert.ToInt32(dr["CinsiyetId"])-1);
                            personelgorevbox.SelectedIndex = (Convert.ToInt32(dr["GorevId"]) - 1);
                            personelyetkibox.SelectedIndex = (Convert.ToInt32(dr["YetkiId"]) - 1);
                            personelulkebox.SelectedIndex = (Convert.ToInt32(dr["UlkeId"]) - 1);
                            personelilbox.SelectedIndex = (Convert.ToInt32(dr["IlId"]) - 1);
                            personelilcebox.SelectedValue = (Convert.ToInt32(dr["IlceId"]));
                            personelpicturebox.Image = Image.FromFile(Convert.ToString(fotografdondur));
                            

                        
                        }
                    }
                }

            }
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            SqlDataReader okuyucu2 = HelperSQL.SqlOkuyucuDondurWithSp("select UlkeAd from tbl_Ulke", false, null);
            if (okuyucu2.HasRows)
            {
                while (okuyucu2.Read())
                {
                    personelulkebox.Items.Add(okuyucu2["UlkeAd"].ToString());
                    personeluyrukbox.Items.Add(okuyucu2["UlkeAd"].ToString());
                }
            }
            okuyucu2.Close();

            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlAd from tbl_Il", false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    personelilbox.Items.Add(okuyucu["IlAd"].ToString());
                }
            }
            okuyucu.Close();

            SqlDataReader okuyucu5 = HelperSQL.SqlOkuyucuDondurWithSp("select CinsiyetAd from tbl_Cinsiyet", false, null);
            if (okuyucu5.HasRows)
            {
                while (okuyucu5.Read())
                {
                    personelcinsiyetbox.Items.Add(okuyucu5["CinsiyetAd"].ToString());
                }
            }
            okuyucu5.Close();

            SqlDataReader okuyucu6 = HelperSQL.SqlOkuyucuDondurWithSp("select YetkiAd from tbl_Yetkiler", false, null);
            if (okuyucu6.HasRows)
            {
                while (okuyucu6.Read())
                {
                    personelyetkibox.Items.Add(okuyucu6["YetkiAd"].ToString());
                }
            }
            okuyucu6.Close();

            SqlDataReader okuyucu7 = HelperSQL.SqlOkuyucuDondurWithSp("select GorevAd from tbl_Gorevler", false, null);
            if (okuyucu7.HasRows)
            {
                while (okuyucu7.Read())
                {
                    personelgorevbox.Items.Add(okuyucu7["GorevAd"].ToString());
                }
            }
            okuyucu7.Close();

        }

        private void personelilbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            personelilcebox.Enabled = true;
            //milcebox.Items.Clear();

            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlceId,IlceAd from tbl_Ilce where IlId =" + (personelilbox.SelectedIndex + 1).ToString(), false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    data.Add(new KeyValuePair<int, string>(Convert.ToInt32(okuyucu["IlceId"]), okuyucu["IlceAd"].ToString()));

                }
                personelilcebox.DataSource = new BindingSource(data, null);
                personelilcebox.DisplayMember = "Value";
                personelilcebox.ValueMember = "Key";
            }//Okuyucu ile is bittigi icin, kapatilir..
            okuyucu.Close();
        }

        private void personelsilbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Personel Silinsin mi ?", "SİL", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (personeltcbox.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen personelin TC'sini giriniz");
                }
                else if (personeltcbox.Text != string.Empty)
                {
                    int ess = HelperSQL.SqlGeriDondurmezWithSp("delete from tbl_Personel where PersonelTcKimlik= '" + personeltcbox.Text + "'", false, null);
                    MessageBox.Show(ess > 0 ? "Personel silindi" : "Personel Silinemedi");
                }
            }
            else
            {
                MessageBox.Show("Vazgeçildi");
            }
        }
    }
}
