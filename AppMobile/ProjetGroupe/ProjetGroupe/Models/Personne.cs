using MediaSense.Main.Manager;
using MediaSense.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaSense.Main
{
    public enum UtilisateurLevel
    {
        Normal = 1,
        Administrateur = 10
    }
    public enum Newsletter
    {
        Normal = 1,
        Administrateur = 10
    }
    public class Personne
    {
        private int id;
        private string email;
        private string nom;
        private string password;
        private UtilisateurLevel level;
        private Newsletter newsletter;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Password { get => password; set => password = value; }
        public UtilisateurLevel Level { get => level; set => level = value; }
        public Newsletter Newsletter { get => newsletter; set => newsletter = value; }
        public void Save()
        {
            UtilisateurManager.Save(this);
        }

        public static Personne Load(int id)
        {
            return UtilisateurManager.Load(id);
        }

        public static List<Personne> List()
        {
            return UtilisateurManager.List();
        }

        public static Personne Search(string email)
        {
            return UtilisateurManager.Search(email);
        }

        public static Personne Search(string email, string password)
        {
            return UtilisateurManager.Search(email, password);
        }

        public static Personne SearchByHash(int id, string hash)
        {
            return UtilisateurManager.SearchByHash(id, hash);
        }

        public static List<Personne> List(int nbUtilisateurs)
        {
            return UtilisateurManager.List(nbUtilisateurs);
        }

        public static int Count()
        {
            return UtilisateurManager.Count();
        }

        public static int Count(UtilisateurLevel level)
        {
            return UtilisateurManager.Count(level);
        }

        public void Delete()
        {
            UtilisateurManager.Delete(this);
        }

        public string HashPassword {
            get {
                return MHash.HashString(password);
            }
        }

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
