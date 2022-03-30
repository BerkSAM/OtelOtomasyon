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
    public partial class Misafir : Form
    {
        public Misafir()
        {
            InitializeComponent();
        }

        private void Getir_Click(object sender, EventArgs e)
        {
            if (misafirtcbox.Text == string.Empty)
            {
                MessageBox.Show("Lütfen Misafirin TC'sini giriniz.");
            }
            else if (misafirtcbox.Text != string.Empty)
            {
                var sonuc = HelperSQL.SqlNesneDondurWithSP("select MisafirAd + ' ' + MisafirSoyad from tbl_Misafir where MisafirTcKimlik = '" + misafirtcbox.Text + "'", false, null);
                if (sonuc == null)
                {
                    MessageBox.Show("Böyle bir misafir bulunmamakta");
                }
                else
                {
                    MessageBox.Show(sonuc + " adlı misafirin bilgileri getirilmiştir.");
                    SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Misafir where MisafirTcKimlik = '" + misafirtcbox.Text + "'", false, null);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            misafiradbox.Text = dr["MisafirAd"].ToString();
                            misafirsoyadbox.Text = dr["MisafirSoyad"].ToString();
                            misafirtcbox.Text = dr["MisafirTcKimlik"].ToString();
                            misafirdogumdt.Value = Convert.ToDateTime(dr["MisafirDogumTarihi"]);
                            misafiruyrukbox.SelectedIndex = Convert.ToInt32(dr["MisafirUyrukId"]) - 1;
                            misafirepostabox.Text = dr["MisafirEposta"].ToString();
                            misafirtelbox.Text = dr["MisafirTelefon"].ToString();
                            misafirpasaportbox.Text = dr["MisafirPasaportNo"].ToString();
                            misafircinsiyetbox.SelectedIndex = (Convert.ToInt32(dr["CinsiyetId"]) - 1);
                            misafiradresbox.Text = dr["MisafirAdres"].ToString();
                            misafirilbox.SelectedIndex = (Convert.ToInt32(dr["IlId"]) - 1);
                            misafirilcebox.SelectedValue = (Convert.ToInt32(dr["IlceId"]));
                            //misafirilcebox.Text = ((KeyValuePair<int, string>)misafirilcebox.SelectedItem).Value;
                            misafirulkebox.SelectedIndex = (Convert.ToInt32(dr["UlkeId"]) - 1);
                            misafiraciklamabox.Text = dr["MisafirAciklama"].ToString();
                            misafirhesbox.Text = dr["MisafirHesKod"].ToString();
                            misafirdilbox.SelectedIndex = (Convert.ToInt32(dr["DilId"]) - 1);
                        }
                    }
                }
            }
        }

        private void Misafir_Load(object sender, EventArgs e)
        {

            SqlDataReader okuyucu2 = HelperSQL.SqlOkuyucuDondurWithSp("select UlkeAd from tbl_Ulke", false, null);
            if (okuyucu2.HasRows)
            {
                while (okuyucu2.Read())
                {
                    misafirulkebox.Items.Add(okuyucu2["UlkeAd"].ToString());
                    misafiruyrukbox.Items.Add(okuyucu2["UlkeAd"].ToString());
                }
            }
            okuyucu2.Close();

            SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlAd from tbl_Il", false, null);
            if (okuyucu.HasRows)
            {
                while (okuyucu.Read())
                {
                    misafirilbox.Items.Add(okuyucu["IlAd"].ToString());
                }
            }
            okuyucu.Close();


            SqlDataReader okuyucu4 = HelperSQL.SqlOkuyucuDondurWithSp("select DilAd from tbl_Diller", false, null);
            if (okuyucu4.HasRows)
            {
                while (okuyucu4.Read())
                {
                    misafirdilbox.Items.Add(okuyucu4["DilAd"].ToString());
                }
            }
            okuyucu4.Close();

            SqlDataReader okuyucu5 = HelperSQL.SqlOkuyucuDondurWithSp("select CinsiyetAd from tbl_Cinsiyet", false, null);
            if (okuyucu5.HasRows)
            {
                while (okuyucu5.Read())
                {
                    misafircinsiyetbox.Items.Add(okuyucu5["CinsiyetAd"].ToString());
                }
            }

        }

        private void misafirilbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            misafirilcebox.Enabled = true;
            //milcebox.Items.Clear();

            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

                SqlDataReader okuyucu = HelperSQL.SqlOkuyucuDondurWithSp("select IlceId,IlceAd from tbl_Ilce where IlId =" + (misafirilbox.SelectedIndex + 1).ToString(), false, null);
            if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        data.Add(new KeyValuePair<int, string>(Convert.ToInt32(okuyucu["IlceId"]), okuyucu["IlceAd"].ToString()));

                    }
                    misafirilcebox.DataSource = new BindingSource(data, null);
                    misafirilcebox.DisplayMember = "Value";
                    misafirilcebox.ValueMember = "Key";
                }//Okuyucu ile is bittigi icin, kapatilir..
                okuyucu.Close();
            
        }

        private void misafirilcebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)misafirilcebox.SelectedItem;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
           

            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Misafir Silinsin mi ?", "SİL", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (misafirtcbox.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen misafirin TC'sini giriniz");
                }
                else if (misafirtcbox.Text != string.Empty)
                {
                    int ess = HelperSQL.SqlGeriDondurmezWithSp("delete from tbl_Misafir where MisafirTcKimlik= '" + misafirtcbox.Text + "'", false, null);
                    MessageBox.Show(ess > 0 ? "Misafir silindi" : "Misafir Silinemedi");
                }
            }
            else
            {
                MessageBox.Show("Vazgeçildi");
            }
        }

        private void misafirgüncellebtn_Click(object sender, EventArgs e)
        {

            SqlParameter[] paramses = new SqlParameter[16];
            paramses[0] = new SqlParameter("@misafirad", misafiradbox.Text);
            paramses[1] = new SqlParameter("@misafirsoyad", misafirsoyadbox.Text);
            paramses[2] = new SqlParameter("@misafirtc", misafirtcbox.Text);
            paramses[3] = new SqlParameter("@misafirdogum", misafirdogumdt.Value);
            paramses[4] = new SqlParameter("@misafiruyruk", misafiruyrukbox.SelectedIndex + 1);
            paramses[5] = new SqlParameter("@misafireposta", misafirepostabox.Text);
            paramses[6] = new SqlParameter("@misafirtelefon", misafirtelbox.Text);
            paramses[7] = new SqlParameter("@misafirpasaport", misafirpasaportbox.Text);
            paramses[8] = new SqlParameter("@cinsiyetid", misafircinsiyetbox.SelectedIndex + 1);
            paramses[9] = new SqlParameter("@misafiradres", misafiradresbox.Text);
            paramses[10] = new SqlParameter("@ilid", misafirilbox.SelectedIndex + 1);
            paramses[11] = new SqlParameter("@ilceid", ((KeyValuePair<int, string>)misafirilcebox.SelectedItem).Key);
            paramses[12] = new SqlParameter("@ulkeid", misafirulkebox.SelectedIndex + 1);
            paramses[13] = new SqlParameter("@misafiraciklama", misafiraciklamabox.Text);
            paramses[14] = new SqlParameter("@misafirhes", misafirhesbox.Text);
            paramses[15] = new SqlParameter("@dilid", misafirdilbox.SelectedIndex + 1);


            int etkilenenSatirSayisi = HelperSQL.SqlGeriDondurmezWithSp("sp_MisafirUpdate", true, paramses);
            MessageBox.Show(etkilenenSatirSayisi > 0 ? "Misafir başarıyla güncellendi" : "Misafir güncellenemedi");
        }

        private void misafireklebtn_Click(object sender, EventArgs e)
        {
            SqlParameter[] paramses = new SqlParameter[16];
            paramses[0] = new SqlParameter("@misafirad", misafiradbox.Text);
            paramses[1] = new SqlParameter("@misafirsoyad", misafirsoyadbox.Text);
            paramses[2] = new SqlParameter("@misafirtc", misafirtcbox.Text);
            paramses[3] = new SqlParameter("@misafirdogum", misafirdogumdt.Value);
            paramses[4] = new SqlParameter("@misafiruyruk", misafiruyrukbox.SelectedIndex + 1);
            paramses[5] = new SqlParameter("@misafireposta", misafirepostabox.Text);
            paramses[6] = new SqlParameter("@misafirtelefon", misafirtelbox.Text);
            paramses[7] = new SqlParameter("@misafirpasaport", misafirpasaportbox.Text);
            paramses[8] = new SqlParameter("@cinsiyetid", misafircinsiyetbox.SelectedIndex + 1);
            paramses[9] = new SqlParameter("@misafiradres", misafiradresbox.Text);
            paramses[10] = new SqlParameter("@ilid", misafirilbox.SelectedIndex + 1);
            paramses[11] = new SqlParameter("@ilceid", ((KeyValuePair<int, string>)misafirilcebox.SelectedItem).Key);
            paramses[12] = new SqlParameter("@ulkeid", misafirulkebox.SelectedIndex + 1);
            paramses[13] = new SqlParameter("@misafiraciklama", misafiraciklamabox.Text);
            paramses[14] = new SqlParameter("@misafirhes", misafirhesbox.Text);
            paramses[15] = new SqlParameter("@dilid", misafirdilbox.SelectedIndex + 1);

            int ess = HelperSQL.SqlGeriDondurmezWithSp("INSERT INTO[dbo].[tbl_Misafir]([MisafirAd],[MisafirSoyad],[MisafirTcKimlik],[MisafirDogumTarihi],[MisafirUyrukId],[MisafirEposta],[MisafirTelefon],[MisafirPasaportNo],[CinsiyetId],[MisafirAdres],[IlId],[IlceId],[UlkeId],[MisafirAciklama],[MisafirHesKod],[dilId]) VALUES(@misafirad, @misafirsoyad, @misafirtc, @misafirdogum, @misafiruyruk, @misafireposta, @misafirtelefon, @misafirpasaport, @cinsiyetid, @misafiradres, @ilid, @ilceid, @ulkeid, @misafiraciklama, @misafirhes, @dilid)", false, paramses);

            MessageBox.Show(ess > 0 ? "Misafir Ekleme Başarılı" : "Misafir Ekleme Başarısız");

        }


    }
}
