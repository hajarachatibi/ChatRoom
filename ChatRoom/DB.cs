using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChatRoom
{
    class DB
    {

        public static MySqlConnection Connect()
        {
            var server = "localhost";
            var database = "chatroom";
            var user = "root";
            var password = "";
            var port = "3306";
            var sslM = "none";

            var connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        
    }
}
