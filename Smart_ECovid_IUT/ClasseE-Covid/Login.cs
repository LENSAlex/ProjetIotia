using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid
{
    public class Login
    {
       public static string Mdp { get; set; }

       public static string NomLogin { get; set; }

        public static  string  Token { get; set; }

        public static string Current(HttpContext context)
        {
           // int? id = context.Session.GetInt32("UtilisateurId");
            //int? id = context.Session.GetInt32("UtilisateurId");
            // int? test = 1;
            string? token = context.Session.GetString("Token");
            if (token != "Connexion refusée" && token != null)
                return token;
            else
                return null;
        }

        public static void logout(HttpContext context)
        {
           // HttpContext context = HttpContext;
            context.Session.SetInt32("UtilisateurId", 0);
            context.Session.SetString("Token", null);
            context.Session.SetString("Nom", null);
        }
    }
}
