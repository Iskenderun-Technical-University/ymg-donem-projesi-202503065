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
using DevExpress.XtraCharts;

namespace Ticari_otomasyon_prj
{
    public partial class Frmstoklar : Form
    {
        public Frmstoklar()
        {
            InitializeComponent();
        }
        sqlconnect bgl= new sqlconnect();
        private void Frmstoklar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(ADET) As 'Miktar' from TB_Urunler group by URUNAD", bgl.bağlan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok Miktarı Listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD,Sum(ADET) As 'Miktar' from TB_Urunler group by URUNAD", bgl.bağlan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.bağlan().Close();

           

        }

       
    }
}
