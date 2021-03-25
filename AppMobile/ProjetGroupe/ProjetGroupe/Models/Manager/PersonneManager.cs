
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models.Manager
{
    internal static class PersonneManager
    {
        internal static Personne Load(int id)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne3 WHERE id_personne=@id", cnx))
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

        internal static Personne Search(string email)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne3 WHERE email=@email", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@email", email));

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

        internal static Personne Search(string rfid, string password)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne3 WHERE rfid=@rfid AND password=@password", cnx))
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

        internal static List<Personne> List()
        {
            List<Personne> list = new List<Personne>();
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personne3 ORDER BY id_personne", cnx))
                {

                    cnx.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Personne item = new Personne();
                            fill(item, dr);
                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }

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

        internal static void Save(Personne personne)
        {
            if (personne.Id == 0)
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Personne ( sexe, email, password, id_pers_type, date_anniversaire, rfid) VALUES ( @sexe, @email, @password, @type, @dateAnniv, @rfid)", cnx))
                    {
                        FillSql(cmd, personne);

                        cnx.Open();
                        cmd.ExecuteNonQuery();

                        personne.Id = Convert.ToInt32(new MySqlCommand("SELECT @@IDENTITY", cnx).ExecuteScalar());
                    }
                }
            }
            else
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Personne SET sexe=@sexe, email=@email, password=@password, id_pers_type=@type, date_anniversaire=@dateAnniv, rfid=@rfid WHERE id_personne=@id", cnx))
                    {
                        FillSql(cmd, personne);

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void FillSql(MySqlCommand cmd, Personne item)
        {
            cmd.Parameters.Add(new MySqlParameter("@id", item.Id));
            cmd.Parameters.Add(new MySqlParameter("@sexe", item.Sexe));
            cmd.Parameters.Add(new MySqlParameter("@email", item.Email));
            cmd.Parameters.Add(new MySqlParameter("@password", item.Password));
            cmd.Parameters.Add(new MySqlParameter("@type", item.PersonneType));
            cmd.Parameters.Add(new MySqlParameter("@dateAnniv", item.Anniversaire));
            cmd.Parameters.Add(new MySqlParameter("@rfid", item.RFID));
        }

        internal static void Delete(Personne personne)
        {
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Personne WHERE id_personne=@id", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", personne.Id));

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    personne.Id = 0;
                }
            }
        }
        internal static int Count()
        {

            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Personne", cnx))
                {

                    cnx.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
