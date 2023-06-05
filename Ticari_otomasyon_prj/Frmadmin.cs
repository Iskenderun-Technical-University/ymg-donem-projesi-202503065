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
    public partial class Frmadmin : Form
    {
        public Frmadmin()
        {
            InitializeComponent();
        }

      sqlconnect bgl = new sqlconnect();    

        private void Frmadmin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TB_ADMIN where KullaniciAd=@p1 and sifre=@p2", bgl.bağlan());
            komut.Parameters.AddWithValue("@p1", textEdit1.Text);
            komut.Parameters.AddWithValue("@p2", textEdit2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Frmanasayfa fr = new Frmanasayfa();
               
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.bağlan().Close();
        }
    }
    }

