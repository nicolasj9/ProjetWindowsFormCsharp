using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.vues
{
    public partial class FormSmtp : Form
    {
        public FormSmtp()
        {
            InitializeComponent();
        }

        private void FormSmtp_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMail.label1.Text = textBox1.ToString();
            FormMail.label2.Text = textBox2.ToString();
            FormMail.label3.Text = textBox3.ToString();
            FormMail.label4.Text = textBox4.ToString();
            this.Close();

        }
    }
}
