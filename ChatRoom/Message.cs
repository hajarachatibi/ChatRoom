using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class Message
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public User user { get; set; }
        public Message(int id, string message, DateTime created_at, User user)
        {
            this.id = id;
            this.message = message;
            this.created_at = created_at;
            this.user = user;
        }

        public Message(string message)
        {
            this.id = id;
            this.message = message;
        }
    }
}
