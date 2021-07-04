using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class Room : Form
    {
        private string username;
        public Room(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        //Bouton "Leave" pour quitter la discussion
        private void button1_Click(object sender, EventArgs e)
        {
            MessageController.Send("a quitté la discussion.", this.username);
            UserController.Leave(this.username);
            this.Hide();
            Auth form = new Auth();
            form.Show();
        }

        //Fonction pour rafraichir les messages
        public void RefreshMessages()
        {
            //pour eviter le blinking de l'ecran
            int nb_msg = 0;
            foreach (Message message in MessageController.getMessages())
            {
                if (message.message == "a quitté la discussion." || message.message == "a rejoint la discussion.")
                    nb_msg++;
                else
                    nb_msg += 2;
            }

            //Rafraichir les msgs s'il y en a un nouveau msg 
            if (nb_msg != this.listView1.Items.Count)
            {
                this.listView1.Items.Clear();
                foreach (Message message in MessageController.getMessages())
                {
                    if (message.message == "a quitté la discussion." || message.message == "a rejoint la discussion.")
                    {
                        var msg = this.listView1.Items.Add(new ListViewItem(message.user.username + " " + message.message + "    " + message.created_at.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg.BackColor = Color.FromArgb(194, 196, 161);
                    }
                    else
                    {
                        this.listView1.Items.Add(new ListViewItem(message.user.username + ":" + message.message));
                        var date = this.listView1.Items.Add(new ListViewItem(message.created_at.ToString("dd/MM/yyyy HH:mm:ss")));
                        date.ForeColor = Color.Gray;
                        date.Font = new Font(FontFamily.GenericSansSerif, 7.5F);
                    }

                }
                this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            }
        }

        //Fonction pour rafraichir les personnes connectees
        public void RefreshActiveList()
        {
            string result = "\n";
            foreach (User user in UserController.getActiveUsers())
            {
                result += "- " + user.username + "\n \n";
            }

            if (!result.Equals(this.activeLabel.Text)) this.activeLabel.Text = result;
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshActiveList();
            this.RefreshMessages();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageController.Send(this.richTextBox1.Text, this.username);
            this.richTextBox1.Text = "";
            this.RefreshMessages();
        }

        //Chargement du form
        private void Room_Load(object sender, EventArgs e)
        {
            this.RefreshActiveList();
            this.RefreshMessages();
        }
    }
}
