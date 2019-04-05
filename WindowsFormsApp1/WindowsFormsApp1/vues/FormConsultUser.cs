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
        List<métier.User> listeUser;

        public FormConsultUser()
        {
            InitializeComponent();
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
        
        private void FormConsultUser_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numLigne = dataGridView1.CurrentRow.Index;

                label1.Text = listeUser[numLigne].getNom();
                label2.Text = listeUser[numLigne].getPrenom();
                label3.Text = listeUser[numLigne].getMail();
                label4.Text = listeUser[numLigne].getStatut();
                label5.Text = listeUser[numLigne].getBadge();
                label6.Text = listeUser[numLigne].getNumInscrip().ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            listeUser = modele.UserDb.genererListeUser();
            foreach (métier.User unUser in listeUser)
            {
                //  listBox1.Items.Add(unUser.getId() + "\t" + unUser.getNom());
                dataGridView1.Rows.Add(unUser.getId(), unUser.getNom(), unUser.getPrenom());
            }
        }

        /* private void button2_Click(object sender, EventArgs e)
         {
             label10.Text();
             FormMail objForm = new FormMail;
             objForm.ShowDialog();
         }*/
    }
}
