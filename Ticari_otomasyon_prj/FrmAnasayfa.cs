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
    public partial class ANASAYFA : Form
    {
        public ANASAYFA()
        {
            InitializeComponent();

        }
        
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            
        }
        FrmUrunler fr;
        MÜŞTERİLER fr2;
        PERSONELLER fr3;
        
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            { 
            fr=new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();
            }
        }

        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr2 == null)
            {
                fr2=new MÜŞTERİLER();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if( fr3 == null)
            {

                fr3 = new PERSONELLER();
                fr3.MdiParent = this;
                fr3.Show();

            }
        }
    }
}
