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
    public partial class Frmanasayfa : Form
    {
        public Frmanasayfa()
        {
            InitializeComponent();

        }
        FrmUrunler fr;
        MÜŞTERİLER fr2;
        PERSONELLER fr3;
        FrmFirmalar fr4;
        FrmRehber fr5;
        Frmgiderler fr6;
        Frmfaturalar fr7;
        Frmnotlar fr8;
        Frmayarlar fr9;
        Frmanamodul fr10;
        Frmstoklar fr11;
        Frmkasa fr12;
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            if (fr10 == null)
            {

                fr10 = new Frmanamodul();
                fr10.MdiParent = this;

                fr10.Show();

            }
        }
        
        
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

        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)
            {

                fr4 = new FrmFirmalar();
                fr4.MdiParent = this;
                fr4.Show();

            }
        }

        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null)
            {

                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();

            }
        }

       

        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null)
            {

                fr6 = new Frmgiderler();
                fr6.MdiParent = this;
                fr6.Show();

            }
        }

        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null)
            {

                fr7 = new Frmfaturalar();
                fr7.MdiParent = this;
                fr7.Show();

            }
        }

        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {

                fr8 = new Frmnotlar();
                fr8.MdiParent = this;
                fr8.Show();

            }

        }

        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {

                fr9 = new Frmayarlar();
                
                fr9.Show();

            }
        }

        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null)
            {

                fr10 = new Frmanamodul();
                fr10.MdiParent = this;

                fr10.Show();

            }
        }

        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null)
            {

                fr11 = new Frmstoklar();
                fr11.MdiParent = this;

                fr11.Show();

            }
        }

        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null)
            {

                fr12 = new Frmkasa();
                fr12.MdiParent = this;

                fr12.Show();

            }
        }
    }
}
