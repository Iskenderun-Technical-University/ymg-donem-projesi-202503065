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

namespace Ticari_otomasyon_prj
{
    public partial class PERSONELLER : Form
    {
        public PERSONELLER()
        {
            InitializeComponent();
        }
        sqlconnect bgl = new sqlconnect();
        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TB_PERSONEL",bgl.bağlan());
            da.Fill(dt);
            gridControl2.DataSource= dt;


        }
        private void PERSONELLER_Load(object sender, EventArgs e)
        {

        }
    }
}
