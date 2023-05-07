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
    public partial class MÜŞTERİLER : Form
    {
        public MÜŞTERİLER()
        {
            InitializeComponent();
        }
        sqlconnect bgl = new sqlconnect(); 
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("Select * From TB_MUSTERILER",bgl.bağlan());
            dr.Fill(dt);
            gridControl2.DataSource = dt;
        }
       
            void sehirler()
        {
            SqlCommand cmd = new SqlCommand("select SEHIR From TB_ILLER",bgl.bağlan());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboİL.Properties.Items.Add(dr[0]);

            
     
            
            }
            bgl.bağlan().Close();

        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirler();
        }

        private void comboİL_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TB_ILCELER where SEHIR=@p1", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1",comboİL.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read()) 
            {
                comboİlce.Properties.Items.Add(dr[0]);            
            }
            bgl.bağlan().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TB_MUSTERILER (AD,SOYAD,TELEFON,TC,MAİL,İL,İLÇE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboİL.Text);
            komut.Parameters.AddWithValue("@p7", comboİlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtVergi.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TB_MUSTERILER where ID =@p1 ",bgl.bağlan());
            komutsil.Parameters.AddWithValue("@p1",txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.bağlan() .Close();
            MessageBox.Show("Müşteri Silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();  

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
                comboİlce.Text = dr["İLÇE"].ToString();
                richAdres.Text = dr["ADRES"].ToString();
                txtVergi.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_MUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAİL=@p5,İL=@p6,İLÇE=@p7,ADRES=@p8,VERGIDAIRE=@p9 where ID=@p10", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboİL.Text);
            komut.Parameters.AddWithValue("@p7", comboİlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtVergi.Text);
            komut.Parameters.AddWithValue("@p10", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon.Text = "";
            mskTc.Text = "";
            txtMail.Text = "";
            comboİL.Text = "";
            richAdres.Text = "";
            txtVergi.Text = "";

        }
    }
}
