using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjetGroupe.Models
{
    public enum PersonneType
    {
        Etudiant = 1,
        Professeur = 2,
        Personnel = 3
    }

    public class Personne
    {
        private int id;
        private string email;
        private string sexe;
        private string password;
        private PersonneType persType;
        private DateTime anniversaire;
        private string rfid;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Password { get => password; set => password = value; }
        public PersonneType PersonneType { get => persType; set => persType = value; }
        public DateTime Anniversaire { get => anniversaire; set => anniversaire = value; }
        public string RFID { get => rfid; set => rfid = value; }
        public void Save()
        {
            PersonneManager.Save(this);
        }

        public static Personne Load(int id)
        {
            return PersonneManager.Load(id);
        }

        public static List<Personne> List()
        {
            return PersonneManager.List();
        }

        public static Personne Search(string email)
        {
            return PersonneManager.Search(email);
        }

        public static Personne Search(string rfid, string password)
        {
            return PersonneManager.Search(rfid, password);
        }

        public static int Count()
        {
            return PersonneManager.Count();
        }

  

        //public void Delete()
        //{
        //    UtilisateurManager.Delete(this);
        //}

        //public static Utilisateur Current()
        //{

        //    if (id != null)
        //        return Load(id.Value);
        //    else if (utilisateurEmail != null && utilisateurPassword != null)
        //        return Utilisateur.Search(utilisateurEmail, utilisateurPassword);
        //    else
        //        return null;
        //}

        //public static void LogOff(HttpContext context)
        //{
        //    context.Session.SetInt32("UtilisateurId", 0);
        //}
    
    }
}
