using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }

        public User (int id, string username)
        {
            this.id = id;
            this.username= username;
        }

        public User(string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}
