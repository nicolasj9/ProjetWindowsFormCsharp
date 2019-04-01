using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace prjCovoit
{
    public partial class Form1 : Form
    {
        //Attribut : 
        //Déclaration static de la connexion (visible depuis toutes les classes
        public static MySqlConnection objCnx;
        
        //Constructeur
        public Form1()
        {
            InitializeComponent();
        }

        //Méthodes
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Database=covoiturage;Data Source=localhost;User Id=root;Password=root";
            objCnx = new MySqlConnection(connectionString);
            try
            {
                objCnx.Open();
                label1.Text = "connexion ok";
            }
            catch (Exception ex)
            {
                MessageBox.Show("pb de connexion" + ex.Message);
            }

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vues.FormConsultUser objFormConsult = new vues.FormConsultUser();
            objFormConsult.ShowDialog();    //Affiche l'objet trajet
        }

        private void importUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vues.FormImport objFormImport = new vues.FormImport();
            objFormImport.ShowDialog();
        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
