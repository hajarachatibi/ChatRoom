using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatRoom
{
    //Classe MessageController pour CRUD de la classe Message
    class MessageController
    {
        private static MySqlCommand cmd;

        //Fonction pour l'envoi d'un message
        public static void Send(string message, string username)
        {

            using (MySqlConnection connection = DB.Connect())
            {

                cmd = new MySqlCommand("INSERT INTO messages (message, user_id, created_at) VALUES (@message, @id, @date)", connection);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@id", UserController.GetID(username));
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        //Fonction pour lister tous les messages
        public static List<Message> getMessages()
        {
            
            List<Message> messages = new List<Message>();

            using (MySqlConnection connection = DB.Connect())
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM messages", connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    messages.Add(new Message(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(3), UserController.getUserById(dr.GetInt32(2))));
                }

                dr.Close();
            }
            return messages;
        }

    }
}
