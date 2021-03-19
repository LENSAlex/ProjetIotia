using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MediaSense.Main.Manager
{
    internal static class UtilisateurManager
    {
        internal static Personne Load(int id)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Utilisateurs WHERE ut_id=@id", cnx))
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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Utilisateurs WHERE ut_email=@email", cnx))
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

        internal static Personne Search(string email, string password)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Utilisateurs WHERE ut_email=@email AND ut_password=@password", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@email", email));
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

        internal static Personne SearchByHash(int id, string hash)
        {
            Personne item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Utilisateurs WHERE ut_id=@id", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", id));

                    cnx.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            item = new Personne();
                            fill(item, dr);
                            if (item.Password != hash)
                                item = null;
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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Utilisateurs ORDER BY ut_id", cnx))
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
            item.Id = (int)dr["ut_id"];
            item.Nom = (string)dr["ut_nom"];
            item.Email = (string)dr["ut_email"];
            item.Password = (string)dr["ut_password"];
            item.Level = (UtilisateurLevel)dr["ut_level"];
            item.Newsletter = (Newsletter)dr["ut_newsletter"];
        }

        internal static void Save(Personne client)
        {
            if (client.Id == 0)
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Utilisateurs ( ut_nom, ut_email, ut_password, ut_level, ut_newsletter) VALUES ( @nom, @email, @password, @level, @newsletter)", cnx))
                    {
                        FillSql(cmd, client);

                        cnx.Open();
                        cmd.ExecuteNonQuery();

                        client.Id = Convert.ToInt32(new MySqlCommand("SELECT @@IDENTITY", cnx).ExecuteScalar());
                    }
                }
            }
            else
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Utilisateurs SET ut_nom=@nom, ut_email=@email, ut_password=@password, ut_level=@level, ut_newsletter=@newsletter WHERE ut_id=@id", cnx))
                    {
                        FillSql(cmd, client);

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void FillSql(MySqlCommand cmd, Personne item)
        {
            cmd.Parameters.Add(new MySqlParameter("@id", item.Id));
            cmd.Parameters.Add(new MySqlParameter("@nom", item.Nom));
            cmd.Parameters.Add(new MySqlParameter("@email", item.Email));
            cmd.Parameters.Add(new MySqlParameter("@password", item.Password));
            cmd.Parameters.Add(new MySqlParameter("@level", item.Level));
            cmd.Parameters.Add(new MySqlParameter("@newsletter", item.Newsletter));
        }

        internal static void Delete(Personne client)
        {
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Utilisateurs WHERE ut_id=@id", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id", client.Id));

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    client.Id = 0;
                }
            }
        }


        internal static List<Personne> List(int nbUtilisateurs)
        {
            List<Personne> list = new List<Personne>();
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {

            }

            return list;
        }

        internal static int Count()
        {

            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Utilisateurs", cnx))
                {

                    cnx.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        internal static int Count(UtilisateurLevel level)
        {

            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Utilisateurs WHERE ut_level = @level", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@level", (int)level));
                    cnx.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

    }
}
