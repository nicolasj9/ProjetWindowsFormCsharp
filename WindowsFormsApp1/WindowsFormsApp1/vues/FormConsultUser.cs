using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjCovoit.vues
{
    public partial class FormConsultUser : Form
    {
        public FormConsultUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<métier.User> listeUser = modele.UserDb.genererListeUser();
            foreach(métier.User unUser in listeUser)
            {
                listBox1.Items.Add(unUser.getId()); //+ "\t" + pour sauter une ligne et concaténer
                listBox2.Items.Add(unUser.getNom());
                listBox3.Items.Add(unUser.getPrenom());
                listBox4.Items.Add(unUser.getMail());
                /*listBox5.Items.Add(unUser.getVille());*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void FormConsultUser_Load(objet sender, EventArgs e)
        {
            List<métier.User> listeUser = modele.UserDb.genererListeUser();

            foreach (métier.User unUser in listeUser)
            {
                dataGridView1.Rows.Add(unUser.getId(), unUser.getNom(), unUser.getPrenom());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numLigne = dataGridView1.CurrentRow.Index;
                label3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("selectionnez une ligne : " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<métier.User> listeUser = modele.UserDb.rechercherUser(textBox1.Text);
            foreach (métier.User unUser in listeUser)
            {
                dataGridView1.Rows.Add(unUser.getId(), unUser.getNom(), unUser.getPrenom());
            }
        }
    }
}
