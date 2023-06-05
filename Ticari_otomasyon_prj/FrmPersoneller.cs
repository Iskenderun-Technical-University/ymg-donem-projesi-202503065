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

namespace Ticari_otomasyon_prj
{
    public partial class PERSONELLER : Form
    {
        public PERSONELLER()
        {
            InitializeComponent();
        }
        sqlconnect bgl = new sqlconnect();
        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TB_PERSONEL",bgl.bağlan());
            da.Fill(dt);
            gridControl2.DataSource= dt;


        }
        void sehirler()
        {
            SqlCommand cmd = new SqlCommand("select SEHIR From TB_ILLER", bgl.bağlan());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboİL.Properties.Items.Add(dr[0]);




            }
            bgl.bağlan().Close();

        }
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon.Text = "";
            mskTc.Text = "";
            txtMail.Text = "";
            comboİL.Text = "";
            comboİlce.Text = "";
            richAdres.Text = "";
            txtDepartman.Text = "";
            comboİL.Text = "";
            comboİlce.Text = "";
            richAdres.Text = "";
        }
        private void PERSONELLER_Load(object sender, EventArgs e)
        {
            personelliste();
            sehirler();
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TB_PERSONEL (AD,SOYAD,TELEFON,TC,MAİL,İL,İLCE,ADRES,DEPARTMAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboİL.Text);
            komut.Parameters.AddWithValue("@p7", comboİlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtDepartman.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
            temizle();
            
        }

        private void comboİL_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TB_ILCELER where SEHIR=@p1", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", comboİL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboİlce.Properties.Items.Add(dr[0]);
            }
            bgl.bağlan().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TB_PERSONEL where ID =@p1 ", bgl.bağlan());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Personel Silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelliste();
            temizle();  
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTelefon.Text = dr["TELEFON"].ToString();
                mskTc.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAİL"].ToString();
                comboİL.Text = dr["İL"].ToString();
                comboİlce.Text = dr["İLCE"].ToString();
                richAdres.Text = dr["ADRES"].ToString();
                txtDepartman.Text = dr["DEPARTMAN"].ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_PERSONEL set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAİL=@p5,İL=@p6,İLCE=@p7,ADRES=@p8,DEPARTMAN=@p9 where ID=@p10", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboİL.Text);
            komut.Parameters.AddWithValue("@p7", comboİlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtDepartman.Text);
            komut.Parameters.AddWithValue("@p10", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
            temizle();
        }
    }
}
