using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChatRoom
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var username = this.textBox1.Text;
            // verifier si le nom d'utilisateur deja existe
            // Si oui, on le rend active
            // Sinon, on l'ajoute et on le met active
            UserController.Join(username);
            MessageController.Send("a rejoint la discussion.", username);
            this.Hide();
            var Room = new Room(username);
            Room.Show();
        }
    }
}
