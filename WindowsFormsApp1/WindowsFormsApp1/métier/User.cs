using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCovoit.métier
{
    class User
    {
        //Attribut
        private int id;
        private string nom;
        private string prenom;
        private string mail;
        private string statut;
        private string badge;
        private int numInscrip;

        //Constructeur User
        public User(string unNom, string unPrenom, string unMail, string unStatut, string unBadge, int num)
        {
            nom = unNom;
            prenom = unPrenom;
            mail = unMail;
            statut = unStatut;
            badge = unBadge;
            numInscrip = num;
        }
        //Methodes
        public int getId()
        {
            return id;
        }
        public string getNom()
        {
            return nom;
        }
        public string getPrenom()
        {
            return prenom;
        }
        public string getMail()
        {
            return mail;
        }
        public string getStatut()
        {
            return statut;
        }
        public string getBadge()
        {
            return badge;
        }
        public int getNumInscrip()
        {
            return numInscrip;
        }


    }
}
