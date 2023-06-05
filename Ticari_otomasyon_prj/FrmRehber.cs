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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

       
        sqlconnect bgl=new sqlconnect();
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,SOYAD,TELEFON,MAİL from TB_MUSTERILER",bgl.bağlan());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //firma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select AD,YETKILISTATU,TELEFON1,TELEFON2,MAİL from TB_FIRMALAR",bgl.bağlan());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr !=null)
            {
                frm.mail = dr["MAİL"].ToString();

            }
            frm.Show();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr["MAİL"].ToString();

            }
            frm.Show();
        }
    }
}
