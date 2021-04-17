using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetGroupe.Models.Manager
{
    /// <summary>
    /// Classe Manager Utilisateur (Personne)
    /// </summary>
    internal static class PersonneManager
    {
        /// <summary>
        /// Fonction Load permettant de charger une utilisateur via son Id en faisant une requête SELECT vers la Base de données MySQL sur RaspberryPI
        /// </summary>
        /// <param name="id">Id de la personne</param>
        /// <returns>Un objet Personne</returns>
        internal static Personne Load(int id)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne WHERE id_personne=@id", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));

                    cnx.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            item = new Personne();
                            fill(item, dr);
                        }
                    }
                }
            }

            return item;
        }
        /// <summary>
        /// Methode permettant de rechercher un utilisateur via son rfid (identifiant) et son password en faisant une requête select dans la bdd
        /// </summary>
        /// <param name="rfid">Identifiant de la personne</param>
        /// <param name="password">mdp de la personne</param>
        /// <returns>un objet personne</returns>
        internal static Personne Search(string rfid, string password)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne WHERE rfid=@rfid AND password=@password", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@rfid", rfid));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));

                    cnx.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            item = new Personne();
                            fill(item, dr);
                        }
                    }
                }
            }

            return item;
        }
        /// <summary>
        /// fill permet de "d'insérer" le contenu des colonnes MySQL dans les getter/setter de la classe Personne
        /// </summary>
        /// <param name="item">Objet Personne</param>
        /// <param name="dr">Classe MySqlDataReader</param>
        private static void fill(Personne item, MySqlDataReader dr)
        {
            item.Id = (int)dr["id_personne"];
            item.Sexe = (string)dr["sexe"];
            item.Email = (string)dr["email"];
            item.Password = (string)dr["password"];
            item.RFID = (string)dr["rfid"];
            item.PersonneType = (PersonneType)dr["id_pers_type"];
            item.Anniversaire = (DateTime)dr["date_anniversaire"];
        }
    }
}
