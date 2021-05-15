using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid
{
    /// <summary>
    /// Login est la class qui permet de grade la session ouverte de l'admin et peut aussi logout 
    /// </summary>
    public class Login
    {
        /// <summary>
        /// sauvgarde du mdp du login de la session
        /// </summary>
       public static string Mdp { get; set; }

        /// <summary>
        /// sauvgarde du Nom  du login de la session
        /// </summary>
        public static string NomLogin { get; set; }

        /// <summary>
        /// sauvgarde du Token  du login de la session
        /// </summary>
        public static  string  Token { get; set; }

        /// <summary>
        /// Verification si la personne qui vas sur une page qu'il a bien le token 
        /// </summary>
        /// <param name="context">La session</param>
        /// <returns>null si il a pas de token et le token si il a le token </returns>
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

        /// <summary>
        /// deconnertion
        /// </summary>
        /// <param name="context">La session</param>
        public static void logout(HttpContext context)
        {
           // HttpContext context = HttpContext;
            context.Session.SetInt32("UtilisateurId", 0);
            context.Session.SetString("Token", null);
            context.Session.SetString("Nom", null);
        }
    }
}
