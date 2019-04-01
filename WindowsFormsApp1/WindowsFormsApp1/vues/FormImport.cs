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

        //ajout dans userDB
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
                bool boucle = false;
                for (int i = 0; i < listeAjout.Count; i++)
                {
                    if(num == listeAjout[i].getNumInscrip())
                    {
                        boucle = true;
                        break;
                    }
                }

                if (boucle == false)
                {
                    listeAjout.Add(objUserImport);
                    listBox2.Items.Add(resultat1.GetValue(0) + "\t" + resultat1.GetValue(1));
                }
            }
            resultat1.Close();

            MySqlDataReader resultat2 = modele.UserDb.listeUserSupprimer();
            while (resultat2.Read())
            {
                int id = int.Parse(resultat2.GetValue(0).ToString());
                string nom = resultat2.GetValue(1).ToString();
                string prenom = resultat2.GetValue(2).ToString();
                string email = resultat2.GetValue(3).ToString();
                string cat = resultat2.GetValue(4).ToString();
                string badge = resultat2.GetValue(5).ToString();
                int num = int.Parse(resultat2.GetValue(6).ToString());
                métier.UserImport objUserSurpprimer = new métier.UserImport(nom, prenom, email, cat, badge, num);
                listBox3.Items.Add(resultat2.GetValue(0) + "\t" + resultat2.GetValue(1));
            }
            resultat2.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listeAjout.Count; i++)
            {
                string nom = listeAjout[i].getNom();
                string prenom = listeAjout[i].getPrenom();
                string mail = listeAjout[i].getMail();
                string categ = listeAjout[i].getStatut();
                string badge = listeAjout[i].getBadge();
                int num= listeAjout[i].getNumInscrip();

                métier.User objUserImport = new métier.User(nom,prenom,mail, categ,badge,num);
                modele.UserDb.ajouterNouveauUser(nom, prenom, mail, categ, badge, num);
            }
            listBox2.Items.Clear();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listeSupprimer.Count; i++)
            {
                int numero = listeSupprimer[i].getId();
                //modele.UserDb.supprimerUserDB(numero);
            }
        }

        private void FormImport_Load(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
