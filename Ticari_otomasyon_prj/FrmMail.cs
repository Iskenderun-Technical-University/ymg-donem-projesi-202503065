using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Ticari_otomasyon_prj
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
         txtmail.Text = mail; 
        }

        private void btngonder_Click(object sender, EventArgs e)
        { 
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("isteeproje53@gmail.com","odevproje");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl= true;
            message.To.Add(txtmail.Text);
            message.From = new MailAddress("isteeproje53@gmail.com");
            message.Subject=txtkonu.Text;
            message.Body=txtmesaj.Text;
            client.Send(message);
            

        }
    }
}
