using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_otomasyon_prj
{
    public partial class faturaurundüzenleme : Form
    {
        public faturaurundüzenleme()
        {
            InitializeComponent();
        }
        sqlconnect bgl= new sqlconnect();   
        public string urunid;

        private void faturaurundüzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunid.Text = urunid;
            SqlCommand komut = new SqlCommand("Select * From TB_FATURADETAY where FaturaUrunID=@p1", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtFiyat.Text = dr[3].ToString();
                TxtMiktar.Text = dr[2].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtUrunAd.Text = dr[1].ToString();

                bgl.bağlan().Close();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_FATURADETAY set URUNAD=@P1,MİKTAR=@P2,FİYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p5", TxtUrunid.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TB_FATURADETAY where FATURAURUNID=@p1", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", TxtUrunid.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
