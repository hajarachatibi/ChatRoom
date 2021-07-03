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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var username = this.textBox1.Text;
            // Check if username exists
            // If Yes, make it active
            // If not add it and make it active
            UserController.Join(username);
            this.Hide();
            var Room = new Room(username);
            Room.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
