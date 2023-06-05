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
    public partial class Frmfaturaurundetayları : Form
    {
        public Frmfaturaurundetayları()
        {
            InitializeComponent();
        }

        public string id;
        sqlconnect bgl=new sqlconnect();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tb_FATURADETAY where FaturaID='" + id + "'", bgl.bağlan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Frmfaturaurundetayları_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            faturaurundüzenleme fr = new faturaurundüzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
