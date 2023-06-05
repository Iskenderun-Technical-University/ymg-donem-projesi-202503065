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
    public partial class frmnotlardetay : Form
    {
        public frmnotlardetay()
        {
            InitializeComponent();
        }
        public string metin;
        private void frmnotlardetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = metin;
        }
    }
}
