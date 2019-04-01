using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.vues
{
    public partial class FormMail : Form
    {
        private string mail;
        public FormMail(string unMail)
        {
            mail = unMail;
            InitializeComponent();
        }

        public void FormMail_Load(object sender, EventArgs e)
        {
            textBox2.Text = mail;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            MailMessage envoieMail = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            envoieMail.From = new MailAddress(textBox1.Text);
            envoieMail.To.Add(textBox2.Text);
            envoieMail.Subject = textBox3.Text;
            envoieMail.Body = richTextBox1.Text;
            server.Port = 587;
            server.Credentials = new System.Net.NetworkCredential("adresse", "mdp");
            server.EnableSsl = true;
            server.Send(envoieMail);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
