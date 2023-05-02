using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_otomasyon_prj
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();

        }
        
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            
        }
        FrmUrunler fr;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            { 
            fr=new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();
            }
        }

      
    }
}
