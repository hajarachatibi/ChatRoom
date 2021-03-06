using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    //Classe UserController pour les fonctions CRUD de la classe User
    class UserController
    {
        private static MySqlCommand cmd;
        //Fonction pour ajouter un nouveau utilisateur si il n'existe pas dans la base de donnees 
        //Sinon c'est a dire si il existe deja dans BD alors on le rend active
        public static void Join(string username)
        {
            using (MySqlConnection connection = DB.Connect())
            {
                cmd = new MySqlCommand("SELECT id FROM users WHERE username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    cmd = new MySqlCommand("UPDATE users SET is_active = 1 WHERE username=@Username", connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    dr.Close();
                    cmd = new MySqlCommand("INSERT INTO users  (username, is_active) VALUES (@Username,1)", connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
                dr.Close();
            }
        }

        //Fonction: si un utilisateur quitte la discussion on le rend desactive
        public static void Leave(string username)
        {
            using (MySqlConnection connection = DB.Connect())
            {
                cmd = new MySqlCommand("UPDATE users SET is_active = 0 WHERE username=@Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.ExecuteNonQuery();
            }
        }

        //Fonction pour lister tous les utilisateurs connectes (actives)

        public static List<User> getActiveUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection connection = DB.Connect())
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE is_active=1", connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    users.Add(new User(dr.GetInt32(0), dr.GetString(1)));
                }
                dr.Close();
            }
            return users;
        }

        // Fonction pour obtenir user ID en offrant username
        public static int GetID(string username)
        {

            using (MySqlConnection connection = DB.Connect())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id FROM users WHERE username=@Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int result = dr.GetInt32(0);
                    dr.Close();
                    return result;
                }
            }
            return 0;
        }

        //Fonction pour obtenir l'utilisateur en offrant user ID
        public static User getUserById(int id)
        {
            User user = null;

            using (MySqlConnection connection = DB.Connect()) {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    user = new User(dr.GetInt32(0), dr.GetString(1));
                }
                dr.Close();
            }
            return user;
        }
    }
}
