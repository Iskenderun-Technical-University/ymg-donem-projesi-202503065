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
using System.Xml;

namespace Ticari_otomasyon_prj
{
    public partial class Frmanamodul : Form
    {
        public Frmanamodul()
        {
            InitializeComponent();
        }
        sqlconnect bgl=new sqlconnect();
        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Urunad,Sum(Adet) as 'Adet' From TB_URUNLER group by Urunad having Sum(adet)<=20 order by Sum(adet)", bgl.bağlan());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 10 tarıh,saat,baslık From TB_Notlar order by ID desc", bgl.bağlan());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

       

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 From TB_Fırmalar", bgl.bağlan());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("http://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }



        private void Frmanamodul_Load(object sender, EventArgs e)
        {
            stoklar();

            ajanda();

         

            fihrist();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");

            haberler();
        }
    }
}
