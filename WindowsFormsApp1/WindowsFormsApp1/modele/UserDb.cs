using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace prjCovoit.modele
{
    class UserDb
    {
        public static List<métier.User> genererListeUser()
        {
            List<métier.User> uneListe = new List<métier.User>();
            string sql = "select * from personnes";  //NOM DE LA TABLE DANS LA BDD

            //Création d'un objet commande sql
            MySqlCommand cmdSql = new MySqlCommand(sql, Form1.objCnx);
            //Exécution de la comande sql -> objet résultat
            MySqlDataReader objResultat = cmdSql.ExecuteReader();

            while (objResultat.Read())
            {
                //Afficher les valeurs à partir de la BDD (les chiffres correspondent aux places des attributs dans la BDD)
                int id = int.Parse(objResultat.GetValue(0).ToString());
                string nom = objResultat.GetValue(1).ToString();
                string prenom = objResultat.GetValue(2).ToString();
                string mail = objResultat.GetValue(3).ToString();
                string badge = objResultat.GetValue(4).ToString();
                string statut = objResultat.GetValue(5).ToString();
                int numinscription = Int.TryParse(objResultat.GetValue(6).ToString());
                //Création d'un objet de la classe User
                métier.User objUser = new métier.User(nom, prenom, mail, statut, badge, numinscription);
                uneListe.Add(objUser);
            }
            objResultat.Close();
            return uneListe;
        }

        public static void insertLigneUser(string nom, string prenom, string mail, string statut, string badge, int numinscription)
        {
            string verif = "select * from importuser where nom='"+nom+"', prenom='"+prenom+"', mail='"+mail+"', statut='"+statut+"', badge='"+badge+"', numInscription='"+numinscription+"'";
            string verifTwo = "select * from importuser where numInscription='" + numinscription + "'";

            //int intverif = 0;

            //int intverifTwo = 0;

            MySqlCommand veriff = new MySqlCommand(verif, Form1.objCnx);
            MySqlCommand verifTwof = new MySqlCommand(verifTwo, Form1.objCnx);

            MySqlDataReader myReaderVerif = veriff.ExecuteReader();
            MySqlDataReader myReaderVerifTwo = verifTwof.ExecuteReader();

            if (!myReaderVerifTwo.Read() || !myReaderVerif.Read())
            {
                string sql = "insert into importuser (nom, prenom, mail, statut, badge, numInscription) values ('" + nom + "', '" + prenom + "', '" + mail + "', '" + statut + "', '" + badge + "', '" + numinscription + "');";  //NOM DE LA TABLE DANS LA BDD
                                                                                                                                                                                                                                  //Création d'un objet commande sql
                MySqlCommand cmdSql = new MySqlCommand(sql, Form1.objCnx);
                //Exécution de la comande sql -> objet résultat
                cmdSql.ExecuteNonQuery();
            }
        }

        public static MySqlDataReader listeUserAjouter()
        {
            string sql = "select * from importuser where numInscription NOT IN (select numInscription from personnes)";

            MySqlCommand cmd = new MySqlCommand(sql, Form1.objCnx);

            MySqlDataReader resultat = cmd.ExecuteReader();

            return resultat;
        }

        public static MySqlDataReader listeUserSupprimer()
        {
            string sql = "select * from importuser where numInscription NOT IN (select numInscription from personnes)";

            MySqlCommand cmd = new MySqlCommand(sql, Form1.objCnx);

            MySqlDataReader resultat = cmd.ExecuteReader();
            return resultat;
        }

        public static void ajouterNouveauUser(string nom, string prenom, string mail, string cat, string badge, int num)
        {
            string sql = "insert into personnes (nom, prenom, mail, statut, badge, numInscription) values  ('" + nom + "','" + prenom + "', '" + mail + "','" + cat + "','" + badge + "','" + num + "');";
       
            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);

            cmdsql.ExecuteNonQuery();
        }

       /* public static void supprimerUserDB(int id)
        {
            string sql = "delete from peron where id="+id;

            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);
            cmdsql.ExecuteNonQuery();
        } */

        public static List<métier.User> rechercherUser(string str)
        {
            List<métier.User> uneListe = new List<métier.User>();
            string sql = "select * from users where nom like '"+str+"'";

            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);

            MySqlDataReader objResultat = cmdsql.ExecuteReader();

            while(objResultat.Read())
            {
                //int id = int.Parse(objResultat.GetValue(0).ToString());
                string nom = objResultat.GetValue(1).ToString();
                string prenom = objResultat.GetValue(2).ToString();
                string email = objResultat.GetValue(3).ToString();
                string cat = objResultat.GetValue(4).ToString();
                string badge = objResultat.GetValue(5).ToString();
                int num = int.Parse(objResultat.GetValue(6).ToString());

                métier.User unUser = new métier.User(nom, prenom, email, cat, badge, num);

                uneListe.Add(unUser); 
            }

            return uneListe;

        }
    }
}
