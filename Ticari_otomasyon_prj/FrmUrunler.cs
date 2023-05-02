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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlconnect bgl = new sqlconnect();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TB_URUNLER", bgl.bağlan());
            da.Fill(dt);
            gridControl1.DataSource = dt;



        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            //ÜRÜNLER SEKMESİNDE OTOMATİK YÜKLENSİN DİYE LOAD İÇİNDE

            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //databaseye ürün ekleme
            SqlCommand komut=new SqlCommand("insert into TB_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,MALIYET,SATIS,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.bağlan());
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2",txtMarka.Text);
            komut.Parameters.AddWithValue("@p3",txtModel.Text);
            komut.Parameters.AddWithValue("@p4",txtYil.Text);
            komut.Parameters.AddWithValue("@p5",int.Parse((numerAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6",decimal.Parse(txtAlisfiyat.Text));
            komut.Parameters.AddWithValue("@p7",decimal.Parse(txtSatisfiyat.Text));
            komut.Parameters.AddWithValue("@p8",richDetay.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TB_URUNLER where ID=@p1",bgl.bağlan());
            komutsil.Parameters.AddWithValue("@p1",txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
     }
