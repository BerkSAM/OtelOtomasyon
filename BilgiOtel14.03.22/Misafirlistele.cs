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
    public partial class Misafirlistele : Form
    {
        public Misafirlistele()
        {
            InitializeComponent();
        }

        private void mekleyon_Click(object sender, EventArgs e)
        {
            Misafir misafir = new Misafir();
            misafir.TopLevel = false;
            misafir.FormBorderStyle = FormBorderStyle.None;
            misafir.Dock = DockStyle.Fill;
            misafirlistelepanel.Controls.Add(misafir);
            misafirlistelepanel.Tag = misafir;
            misafir.BringToFront();
            misafir.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            //Misafir view temizle
            misafirview.Items.Clear();
            if (misafirarabox.Text != string.Empty)
            {

                SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("select * from tbl_Misafir where MisafirTcKimlik= '" + misafirarabox.Text + "'", false, null);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["MisafirTcKimlik"].ToString());
                    item.SubItems.Add(dr["MisafirAd"].ToString());
                    item.SubItems.Add(dr["MisafirSoyad"].ToString());
                    item.SubItems.Add(dr["MisafirDogumTarihi"].ToString());
                    item.SubItems.Add(dr["MisafirEposta"].ToString());
                    item.SubItems.Add(dr["MisafirTelefon"].ToString());
                    item.SubItems.Add(dr["MisafirHesKod"].ToString());
                    misafirview.Items.Add(item);
                }

            }
            else if (misafirarabox.Text == string.Empty)
            {
                SqlParameter[] paramses = new SqlParameter[2];
                paramses[0] = new SqlParameter("@tarih1", Convert.ToDateTime(misafirtarihilkdt.Text));
                paramses[1] = new SqlParameter("@tarih2", Convert.ToDateTime(misafirtarihsondt.Text));

                SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("sp_misafirsorgulama", true, paramses);
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["MisafirTcKimlik"].ToString());
                    item.SubItems.Add(dr["MisafirAd"].ToString());
                    item.SubItems.Add(dr["MisafirSoyad"].ToString());
                    item.SubItems.Add(dr["MisafirDogumTarihi"].ToString());
                    item.SubItems.Add(dr["MisafirEposta"].ToString());
                    item.SubItems.Add(dr["MisafirTelefon"].ToString());
                    item.SubItems.Add(dr["MisafirHesKod"].ToString());
                    misafirview.Items.Add(item);
                }
                dr.Close();
            } 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Misafirlistele_Load(object sender, EventArgs e)
        {
            //MisafirView Gridler
            misafirview.Clear();
            misafirview.GridLines = true;
            misafirview.View = View.Details;
            misafirview.Columns.Add("Misafir TC", 100);
            misafirview.Columns.Add("Misafir Ad", 100);
            misafirview.Columns.Add("Misafir Soyad", 100);
            misafirview.Columns.Add("Misafir Dogum Tarihi", 109);
            misafirview.Columns.Add("Misafir EPosta", 100);
            misafirview.Columns.Add("Misafir Telefon", 100);
            misafirview.Columns.Add("Misafir HES", 100);
            misafirview.CheckBoxes=true;

            //Misafir view temizle
            misafirview.Items.Clear();


            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Misafir", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["MisafirTcKimlik"].ToString());
                item.SubItems.Add(dr["MisafirAd"].ToString());
                item.SubItems.Add(dr["MisafirSoyad"].ToString());
                item.SubItems.Add(dr["MisafirDogumTarihi"].ToString());
                item.SubItems.Add(dr["MisafirEposta"].ToString());
                item.SubItems.Add(dr["MisafirTelefon"].ToString());
                item.SubItems.Add(dr["MisafirHesKod"].ToString());
                misafirview.Items.Add(item);
            }
            dr.Close();

        }

        private void işlemYAPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }  
}
