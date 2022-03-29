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
    public partial class Kampanya : Form
    {
        public Kampanya()
        {
            InitializeComponent();
        }

        private void kampanyaekle_Click(object sender, EventArgs e)
        {

            SqlParameter[] paramses = new SqlParameter[5];
            paramses[0] = new SqlParameter("@KampanyaBilgileri", kampanyabilgibox.Text);
            paramses[1] = new SqlParameter("@KampanyaIndirimOran", Convert.ToInt32(oranbox.Text));
            paramses[2] = new SqlParameter("@KampanyaBaslangicZaman", Convert.ToDateTime(kampanyabaslangicdt.Value));
            paramses[3] = new SqlParameter("@KampanyaBitisTarihi", Convert.ToDateTime(kampanyabitisdt.Value));
            paramses[4] = new SqlParameter("@KampanyaTanim", kampanyatanimbox.Text);

            int ess = HelperSQL.SqlGeriDondurmezWithSp("sp_KampanyalarEkle", true, paramses);

            MessageBox.Show(ess > 0 ? "Kampanya Ekleme Başarılı" : "Kampanya Ekleme Başarısız");
        }

        private void Kampanya_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 101; i++)
            {
                oranbox.Items.Add(i);
            }

            //MisafirView Gridler
            kampanyaview.Clear();
            kampanyaview.GridLines = true;
            kampanyaview.View = View.Details;
            kampanyaview.Columns.Add("ID", 60);
            kampanyaview.Columns.Add("Kampanya Bilgi", 130);
            kampanyaview.Columns.Add("Oran", 50);
            kampanyaview.Columns.Add("Kampanya Tanım", 180);
            kampanyaview.Columns.Add("Kampanya Baslangic", 150);
            kampanyaview.Columns.Add("Kampanya Bitis", 150);



            //Misafir view temizle
            kampanyaview.Items.Clear();


            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("select * from tbl_Kampanyalar", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["KampanyaId"].ToString());
                item.SubItems.Add(dr["KampanyaBilgileri"].ToString());
                item.SubItems.Add(dr["KampanyaIndirimOran"].ToString()); 
                item.SubItems.Add(dr["KampanyaTanim"].ToString());
                item.SubItems.Add(dr["KampanyaBaslangicZaman"].ToString());
                item.SubItems.Add(dr["KampanyaBitisTarihi"].ToString());
                kampanyaview.Items.Add(item);
            }
            dr.Close();
        }
    }
}
