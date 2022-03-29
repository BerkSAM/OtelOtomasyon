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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        private void musteripanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void musterigetirbtn_Click(object sender, EventArgs e)
        {
            if (musteritcbox.Text == string.Empty)
            {
                MessageBox.Show("Lütfen Müşterinin TC'sini veya Vergi Numarasını giriniz.");
            }
            else if (musteritcbox.Text != string.Empty)
            {

                var sonuc = HelperSQL.SqlNesneDondurWithSP("select MusteriAd + ' ' + MusteriSoyad from tbl_Musteriler where MusteriTCKimlik = '" + musteritcbox.Text + "' or MusteriVergiNo = '" + musterivergibox.Text + "'", false, null);
                if (sonuc == null)
                {
                    MessageBox.Show("Böyle bir müşteri bulunmamakta");
                }
                else
                {
                    MessageBox.Show(sonuc + " adlı müsterinin bilgileri getirilmiştir.");
                    SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Musteriler where MusteriTCKimlik = '" + musteritcbox.Text + "' or MusteriVergiNo = '" + musterivergibox.Text + "'", false, null);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            musteriadbox.Text = dr["MusteriAd"].ToString();
                            musterisoyadbox.Text = dr["MusteriSoyad"].ToString();
                            musteritcbox.Text = dr["MusteriTCKimlik"].ToString();
                            musteripasaportbox.Text = dr["MusteriPasaportNo"].ToString();
                            musteriunvanbox.Text = dr["MusteriUnvan"].ToString();
                            yetkiliadsoyadbox.Text = dr["MusteriYetkiliAdSoyad"].ToString();
                            musterivergibox.Text = dr["MusteriVergiNo"].ToString();
                            yetkilivergidairesibox.Text = dr["MusteriVergiDairesi"].ToString();
                            musteritelbox.Text = dr["MusteriTelefon"].ToString();
                            musteriepostabox.Text = dr["MusteriPosta"].ToString();
                            musteriadresbox.Text = dr["MusteriAdres"].ToString();
                            ulkebox.SelectedIndex = Convert.ToInt32(dr["UlkeID"]) - 1;
                            ilbox.SelectedIndex = Convert.ToInt32(dr["IlId"]) - 1;
                            ilcebox.SelectedValue = Convert.ToInt32(dr["IlceId"]);
                            musteriaciklamabox.Text = dr["MusteriAciklama"].ToString();
                            checkBox1.Checked = Convert.ToBoolean(dr["MusteriKurumsalOK"]);
                            dilbox.SelectedIndex = Convert.ToInt32(dr["DilId"]) - 1;
                        }
                    }
                }

            }
        }

        private void musterigüncelle_Click(object sender, EventArgs e)
        {
            SqlParameter[] paramses = new SqlParameter[17];
            paramses[0] = new SqlParameter("@MusteriAd", musteriadbox.Text);
            paramses[1] = new SqlParameter("@MusteriSoyad", musterisoyadbox.Text);
            paramses[2] = new SqlParameter("@MusteriTCKimlik", musteritcbox.Text);
            paramses[3] = new SqlParameter("@MusteriPasaportNo", musteripasaportbox.Text);
            paramses[4] = new SqlParameter("@MusteriUnvan", musteriunvanbox.Text);
            paramses[5] = new SqlParameter("@MusteriYetkiliAdSoyad", yetkiliadsoyadbox.Text);
            paramses[6] = new SqlParameter("@MusteriVergiNo", musterivergibox.Text);
            paramses[7] = new SqlParameter("@MusteriVergiDairesi", yetkilivergidairesibox.Text);
            paramses[8] = new SqlParameter("@MusteriTelefon", musteritelbox.Text);
            paramses[9] = new SqlParameter("@MusteriPosta", musteriepostabox.Text);
            paramses[10] = new SqlParameter("@MusteriAdres", musteriadresbox.Text);
            paramses[11] = new SqlParameter("@IlID", ilbox.SelectedIndex + 1);
            paramses[12] = new SqlParameter("@IlceID", ((KeyValuePair<int, string>)ilcebox.SelectedItem).Key);
            paramses[13] = new SqlParameter("@UlkeID", ulkebox.SelectedIndex + 1);
            paramses[14] = new SqlParameter("@MusteriAciklama", musteriaciklamabox.Text);
            paramses[15] = new SqlParameter("@MusteriKurumsalOK", Convert.ToBoolean(checkBox1.Checked));
            paramses[16] = new SqlParameter("@DilID", dilbox.SelectedIndex + 1);


            int etkilenenSatirSayisi = HelperSQL.SqlGeriDondurmezWithSp("sp_musteriupdatenew", true, paramses);
            MessageBox.Show(etkilenenSatirSayisi > 0 ? "Müşteri başarıyla güncellendi" : "Müşteri güncellenemedi");
        }

        private void musterieklebtn_Click(object sender, EventArgs e)
        {
            SqlParameter[] paramses = new SqlParameter[17];
            paramses[0] = new SqlParameter("@MusteriAd", musteriadbox.Text);
            paramses[1] = new SqlParameter("@MusteriSoyad", musterisoyadbox.Text);
            paramses[2] = new SqlParameter("@MusteriTCKimlik", musteritcbox.Text);
            paramses[3] = new SqlParameter("@MusteriPasaportNo", musteripasaportbox.Text);
            paramses[4] = new SqlParameter("@MusteriUnvan", musteriunvanbox.Text);
            paramses[5] = new SqlParameter("@MusteriYetkiliAdSoyad", yetkiliadsoyadbox.Text);
            paramses[6] = new SqlParameter("@MusteriVergiNo", musterivergibox.Text);
            paramses[7] = new SqlParameter("@MusteriVergiDairesi", yetkilivergidairesibox.Text);
            paramses[8] = new SqlParameter("@MusteriTelefon", musteritelbox.Text);
            paramses[9] = new SqlParameter("@MusteriPosta", musteriepostabox.Text);
            paramses[10] = new SqlParameter("@MusteriAdres", musteriadresbox.Text);
            paramses[11] = new SqlParameter("@IlID", ilbox.SelectedIndex + 1);
            paramses[12] = new SqlParameter("@IlceID", ((KeyValuePair<int, string>)ilcebox.SelectedItem).Key);
            paramses[13] = new SqlParameter("@UlkeID", ulkebox.SelectedIndex + 1);
            paramses[14] = new SqlParameter("@MusteriAciklama", musteriaciklamabox.Text);
            paramses[15] = new SqlParameter("@MusteriKurumsalOK", Convert.ToBoolean(checkBox1.Checked));
            paramses[16] = new SqlParameter("@DilID", dilbox.SelectedIndex + 1);

            int ess = HelperSQL.SqlGeriDondurmezWithSp("sp_musterieklenew", true, paramses);

            MessageBox.Show(ess > 0 ? "Müşteri Ekleme Başarılı" : "Müşteri Ekleme Başarısız");
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            SqlDataReader okuyucu2 = HelperSQL.SqlOkuyucuDondurWithSp("select UlkeAd from tbl_Ulke", false, null);
            if (okuyucu2.HasRows)
            {
                while (okuyucu2.Read())
                {
                    ulkebox.Items.Add(okuyucu2["UlkeAd"].ToString());
                }
            }
            okuyucu2.Close();

            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlAd from tbl_Il", false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    ilbox.Items.Add(okuyucu["IlAd"].ToString());
                }
            }
            okuyucu.Close();


            SqlDataReader okuyucu4 = HelperSQL.SqlOkuyucuDondurWithSp("select DilAd from tbl_Diller", false, null);
            if (okuyucu4.HasRows)
            {
                while (okuyucu4.Read())
                {
                    dilbox.Items.Add(okuyucu4["DilAd"].ToString());
                }
            }
            okuyucu4.Close();


        }

        private void ilbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilcebox.Enabled = true;
            //milcebox.Items.Clear();

            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlceId,IlceAd from tbl_Ilce where IlId =" + (ilbox.SelectedIndex + 1).ToString(), false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    data.Add(new KeyValuePair<int, string>(Convert.ToInt32(okuyucu["IlceId"]), okuyucu["IlceAd"].ToString()));

                }
                ilcebox.DataSource = new BindingSource(data, null);
                ilcebox.DisplayMember = "Value";
                ilcebox.ValueMember = "Key";
            }//Okuyucu ile is bittigi icin, kapatilir..
            okuyucu.Close();
        }

        private void musterisil_Click(object sender, EventArgs e)
        {
           

            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Müşteri Silinsin mi ?", "SİL", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (musteritcbox.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen Müşterinin TC'sini veya Vergi Numarasını giriniz.");
                }
                else if (musteritcbox.Text != string.Empty)
                {
                    int ess = HelperSQL.SqlGeriDondurmezWithSp("Select * from tbl_Musteriler where MusteriTCKimlik = '" + musteritcbox.Text + "' or MusteriVergiNo = '" + musterivergibox.Text + "'", false, null);
                    MessageBox.Show(ess > 0 ? "Müşteri silindi" : "Müşteri Silinemedi");
                }
            }
            else
            {
                MessageBox.Show("Vazgeçildi");
            }

        }
    }
}
