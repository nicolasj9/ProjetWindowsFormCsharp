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
            string sql = "select * from personne";  //NOM DE LA TABLE DANS LA BDD

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
                int numinscription = int.Parse(objResultat.GetValue(6).ToString());

                //Création d'un objet de la classe User
                métier.User objUser = new métier.User(nom, prenom, mail, statut, badge, numinscription);
                uneListe.Add(objUser);
            }
            objResultat.Close();
            return uneListe;
        }

        public static void insertLigneUser(string nom, string prenom, string mail, string statut, string badge, int numinscription)
        {
            string sql = "insert into importuser (nom, prenom, mail, statut, badge, numInscription) values ('"+nom+"', '"+prenom+"', '"+mail+"', '"+statut+"', '"+badge+"', '"+numinscription+"');";  //NOM DE LA TABLE DANS LA BDD

            //Création d'un objet commande sql
            MySqlCommand cmdSql = new MySqlCommand(sql, Form1.objCnx);
            //Exécution de la comande sql -> objet résultat
            cmdSql.ExecuteNonQuery();
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
            string sql = "insert into users values";
            sql = sql + "(null, '" + nom + "','" + prenom + "', '" + mail + "','" + cat + "','" + badge + "','" + num + "');";
       
            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);

            cmdsql.ExecuteNonQuery();
        }

        public static void supprimerUserDB(int id)
        {
            string sql = "delete from users where id="+id;

            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);
            cmdsql.ExecuteNonQuery();
        }

        public static List<métier.User> rechercherUser(string str)
        {
            List<métier.User> uneListe = new List<métier.User>();
            string sql = "select * from users where nom like '"+str+"'";

            MySqlCommand cmdsql = new MySqlCommand(sql, Form1.objCnx);

            return uneListe;

        }
    }
}
