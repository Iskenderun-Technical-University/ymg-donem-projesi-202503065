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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlconnect bgl  = new sqlconnect();
        void firmaliste()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from TB_FIRMALAR",bgl.bağlan());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            gridControl2.DataSource= dt;


        }
          void temizle()
        {
            txtAd.Text = "";
            txtId.Text = "";
            txtMail.Text = "";
            txtSektor.Text = "";
            txtTc.Text = "";
            txtVergi.Text = "";
            txtYetkili.Text = "";
            txtYetkiligorev.Text = "";
            mskTelefon.Text = "";
            mskTelefon2.Text = "";
            comboİL.Text = "";
            comboİlce.Text = "";
            richAdres.Text = "";





        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmaliste();
            
            sehirler();
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
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtYetkiligorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                txtTc.Text = dr["TC"].ToString();
                mskTelefon.Text = dr["TELEFON1"].ToString();
                mskTelefon2.Text = dr["TELEFON2"].ToString();
                txtMail.Text = dr["MAİL"].ToString();
                comboİL.Text = dr["IL"].ToString();
                comboİlce.Text = dr["ILCE"].ToString();
                txtVergi.Text = dr["VERGIDAIRE"].ToString();
                richAdres.Text = dr["ADRES"].ToString();
                txtSektor.Text = dr["SEKTOR"].ToString();
                
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into TB_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,TC,TELEFON1,TELEFON2,MAİL,IL,ILCE,VERGIDAIRE,ADRES,SEKTOR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiligorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", txtTc.Text);
            komut.Parameters.AddWithValue("@p5", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p6", mskTelefon2.Text);
            komut.Parameters.AddWithValue("@p7", txtMail.Text);
            komut.Parameters.AddWithValue("@p8", comboİL.Text);
            komut.Parameters.AddWithValue("@p9", comboİlce.Text);
            komut.Parameters.AddWithValue("@p10",txtVergi.Text);
            komut.Parameters.AddWithValue("@p11",richAdres.Text);
            komut.Parameters.AddWithValue("@p12",txtSektor.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaliste();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TB_FIRMALAR where ID =@p1 ", bgl.bağlan());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Firma Silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmaliste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,TC=@p4,TELEFON1=@p5,TELEFON2=@p6,MAİL=@p8,IL=@p10,ILCE=@P11,VERGIDAIRE=@p12,ADRES=@p13,SEKTOR=@P14 where ID=@P15", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiligorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", txtTc.Text);
            komut.Parameters.AddWithValue("@p5", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p6", mskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", comboİL.Text);
            komut.Parameters.AddWithValue("@p11", comboİlce.Text);
            komut.Parameters.AddWithValue("@p12", txtVergi.Text);
            komut.Parameters.AddWithValue("@p13", richAdres.Text);
            komut.Parameters.AddWithValue("@p14", txtSektor.Text);
            komut.Parameters.AddWithValue("@p15", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaliste();
            
        }
    }
}
