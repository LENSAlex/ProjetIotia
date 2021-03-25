﻿using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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
        public Personne SearchMail(string email)
        {
            return PersonneManager.Search(email);
        }
        public static Personne SearchLike(string query)
        {
            return PersonneManager.SearchLike(query);
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

        public static Personne IsLogged()
        {
            int result = Convert.ToInt32(Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result);
            if (result == 1)
            {
                int id = Convert.ToInt32(Xamarin.Essentials.SecureStorage.GetAsync("Id").Result);
                Personne Personne = Personne.Load(id);
                if(Personne != null)
                {
                    return Personne;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //public static void LogOff(HttpContext context)
        //{
        //    context.Session.SetInt32("UtilisateurId", 0);
        //}
        public bool RappelMail(string MailPatient)
        {
            //juste ici verifier que le mail existe bien
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("soignantsniriotia@gmail.com");
                mail.To.Add(MailPatient);
                mail.Subject = "Formulaire à remplir ";
                mail.Body = "<h1 style='text-align:center'>Bonjour</h1>";
                mail.IsBodyHtml = true;
   
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("soignantsniriotia@gmail.com", "testtest25.");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                return true;
            }
            //return false;
        }


    }
}
