using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace prjCovoit.vues
{
    public partial class FormImport : Form
    {
        List<métier.UserImport> listeAjout = new List<métier.UserImport>();
        List<métier.UserImport> listeSupprimer = new List<métier.UserImport>();

        public FormImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nomFichier = textBox1.Text;

            StreamReader sr = new StreamReader(nomFichier);

            string ligne = sr.ReadLine();
            while(ligne != null)
            {
                string[] lesChamps = ligne.Split(';');
                modele.UserDb.insertLigneUser(lesChamps[0], lesChamps[1], lesChamps[2], lesChamps[3], lesChamps[4], int.Parse(lesChamps[5]));
                ligne = sr.ReadLine();
                listBox1.Items.Add(lesChamps[1] + "\t" + lesChamps[4]);
            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlDataReader resultat1 = modele.UserDb.listeUserAjouter();
            while (resultat1.Read())
            {
                int id = int.Parse(resultat1.GetValue(0).ToString());
                string nom = resultat1.GetValue(1).ToString();
                string prenom = resultat1.GetValue(2).ToString();
                string email = resultat1.GetValue(3).ToString();
                string cat = resultat1.GetValue(4).ToString();
                string badge = resultat1.GetValue(5).ToString();
                int num = int.Parse(resultat1.GetValue(6).ToString());
                métier.UserImport objUserImport = new métier.UserImport(nom, prenom, email, cat, badge, num); 
                listBox2.Items.Add(resultat1.GetValue(0) + "\t" + resultat1.GetValue(1));
            }
            resultat1.Close();

            MySqlDataReader resultat2 = modele.UserDb.listeUserSupprimer();
            while (resultat1.Read())
            {
                int id = int.Parse(resultat2.GetValue(0).ToString());
                string nom = resultat2.GetValue(1).ToString();
                string prenom = resultat2.GetValue(2).ToString();
                string email = resultat2.GetValue(3).ToString();
                string cat = resultat2.GetValue(4).ToString();
                string badge = resultat2.GetValue(5).ToString();
                int num = int.Parse(resultat2.GetValue(6).ToString());
                métier.UserImport objUserSurpprimer = new métier.UserImport(nom, prenom, email, cat, badge, num);
                listBox2.Items.Add(resultat2.GetValue(0) + "\t" + resultat1.GetValue(1));
            }
            resultat2.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader resultat = modele.UserDb.listeUserAjouter();
            while (resultat.Read())
            {
                string nom = resultat.GetValue(0).ToString();
                string prenom = resultat.GetValue(1).ToString();
                string mail = resultat.GetValue(2).ToString();
                string categ = resultat.GetValue(3).ToString();
                string badge = resultat.GetValue(4).ToString();
                int num = int.Parse(resultat.GetValue(5).ToString());

                métier.UserImport objUserImport = new métier.UserImport(nom,prenom,mail, categ,badge,num);

                listBox2.Items.Add(resultat.GetValue(0) + "\t" + resultat.GetValue(1));
            }
            resultat.Close();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listeSupprimer.Count; i++)
            {
                int numero = listeSupprimer[i].getNumInscrip();
                modele.UserDb.supprimerUserDB(numero);
            }
        }

        private void FormImport_Load(object sender, EventArgs e)
        {

        }
    }
}
