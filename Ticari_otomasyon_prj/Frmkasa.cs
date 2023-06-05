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
using System.Data.SqlClient;

namespace Ticari_otomasyon_prj
{
    public partial class Frmkasa : Form
    {
        public Frmkasa()
        {
            InitializeComponent();
        }
        sqlconnect bgl = new sqlconnect();
       

       

        void Giderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TB_GIDERLER order by ID asc", bgl.bağlan());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }


        public string ad;
        private void Frmkasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;

            

           

            Giderler();

            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From TB_Faturadetay", bgl.bağlan());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = dr1[0].ToString() + " TL";
            }
            bgl.bağlan().Close();

            //Son ayın faturaları
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOĞALGAZ+INTERNET+EKSTRA) from TB_GIDERLER order by ID asc", bgl.bağlan());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.bağlan().Close();

            //Son ayın personel maaşları
            SqlCommand komut3 = new SqlCommand("Select Maaslar From TB_GIDERLER order by ID asc", bgl.bağlan());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaasları.Text = dr3[0].ToString() + " TL";
            }
            bgl.bağlan().Close();

            //Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("Select Count(*) From TB_Musterıler", bgl.bağlan());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.bağlan().Close();

            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("Select Count(*) From TB_FIRMALAR", bgl.bağlan());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.bağlan().Close();

            //Toplam Firma Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(IL)) From TB_FIRMALAR", bgl.bağlan());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblSehirSayısı.Text = dr6[0].ToString();
            }
            bgl.bağlan().Close();

            //Toplam Müşteri Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(İL)) From TB_MUSTERILER", bgl.bağlan());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblSehirSayisi2.Text = dr7[0].ToString();
            }
            bgl.bağlan().Close();

            //Toplam Personel Sayısı
            SqlCommand komut8 = new SqlCommand("Select Count(*) From TB_PERSONEL", bgl.bağlan());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.bağlan().Close();

            //Toplam Ürün Sayısı
            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) From TB_URUNLER", bgl.bağlan());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.bağlan().Close();
        }
    }
}
