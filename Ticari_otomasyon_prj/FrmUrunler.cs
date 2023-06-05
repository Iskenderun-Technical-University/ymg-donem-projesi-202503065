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
using DevExpress.XtraEditors;

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
        void temizle()
        {
            txtId.Text = null;
            txtAd.Text = null;
            txtAlisfiyat.Text= null;
            txtMarka.Text= null;
            txtModel.Text = null;
            txtYil.Text = null;
            txtSatisfiyat.Text = null;
            richDetay.Text= null;
            numerAdet.Value = 0;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            //ÜRÜNLER SEKMESİNDE OTOMATİK YÜKLENSİN DİYE LOAD İÇİNDE

            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //databaseye ürün ekleme
            SqlCommand komut = new SqlCommand("insert into TB_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,MALIYET,SATIS,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", txtYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((numerAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisfiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisfiyat.Text));
            komut.Parameters.AddWithValue("@p8", richDetay.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TB_URUNLER where ID=@p1", bgl.bağlan());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_URUNLER set URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,MALIYET=@p6,SATIS=@p7,DETAY=@p8 where ID=@p9", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", txtYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((numerAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisfiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisfiyat.Text));
            komut.Parameters.AddWithValue("@p8", richDetay.Text);
            komut.Parameters.AddWithValue("@p9", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.bağlan().Close();
            MessageBox.Show("Ürün bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["URUNAD"].ToString();
            txtMarka.Text = dr["MARKA"].ToString();
            txtModel.Text = dr["MODEL"].ToString();
            txtYil.Text = dr["YIL"].ToString();
            numerAdet.Value = Decimal.Parse(dr["ADET"].ToString());
            txtAlisfiyat.Text = dr["MALIYET"].ToString();
            txtSatisfiyat.Text = dr["SATIS"].ToString();
            richDetay.Text = dr["DETAY"].ToString();
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();

        }
    }
}
