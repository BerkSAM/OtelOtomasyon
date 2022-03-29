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
    public partial class odalistele : Form
    {
        public odalistele()
        {
            InitializeComponent();
        }


        private void odasatisbuton_Click_1(object sender, EventArgs e)
        {
            Oda oda = new Oda();
            oda.TopLevel = false;
            oda.FormBorderStyle = FormBorderStyle.None;
            oda.Dock = DockStyle.Fill;
            odalistelepanel.Controls.Add(oda);
            odalistelepanel.Tag = oda;
            oda.BringToFront();
            oda.Show();
        }

        private void odalistele_Load(object sender, EventArgs e)
        {
            //MisafirView Gridler
            odaview.Clear();
            odaview.GridLines = true;
            odaview.View = View.Details;
            odaview.Columns.Add("OdaID", 50);
            odaview.Columns.Add("NO", 50);
            odaview.Columns.Add("Kat", 50);
            odaview.Columns.Add("Ebat", 50);
            odaview.Columns.Add("Tipi", 50);
            odaview.Columns.Add("Minibar", 50);
            odaview.Columns.Add("Klima", 50);
            odaview.Columns.Add("Kurutma", 50);
            odaview.Columns.Add("Wifi", 50);
            odaview.Columns.Add("Kasa", 50);
            odaview.Columns.Add("Balkon", 50);
            odaview.Columns.Add("TV", 50);
            odaview.Columns.Add("Acikla", 109);

            odaview.CheckBoxes = true;
            odaview.FullRowSelect = true;
            odaview.LabelEdit = true;

            //Misafir view temizle
            odaview.Items.Clear();


            SqlDataReader dr = HelperSQL.SqlOkuyucuDondurWithSp("Select * from tbl_Odalar", false, null);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["OdaId"].ToString());
                item.SubItems.Add(dr["OdaNo"].ToString());
                item.SubItems.Add(dr["OdaKat"].ToString());
                item.SubItems.Add(dr["OdaEbatMsqr"].ToString());
                item.SubItems.Add(dr["OdaTipiId"].ToString());
                item.SubItems.Add(dr["OdaMiniBarOk"].ToString());
                item.SubItems.Add(dr["OdaKlimaOk"].ToString());
                item.SubItems.Add(dr["OdaKurutmaOk"].ToString());
                item.SubItems.Add(dr["OdaWifiOk"].ToString());
                item.SubItems.Add(dr["OdaKasaOk"].ToString());
                item.SubItems.Add(dr["OdaBalkonOk"].ToString());
                item.SubItems.Add(dr["OdaTvOk"].ToString());
                item.SubItems.Add(dr["OdaAciklama"].ToString());
                odaview.Items.Add(item);
            }
            dr.Close();
        }
    }
}
