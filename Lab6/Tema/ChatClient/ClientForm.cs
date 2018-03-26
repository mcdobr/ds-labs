using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.localhost;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        private string username;
        private ChatService chatService;
        private Timer updateMessagesTimer;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            chatService = new ChatService();
            chatService.CookieContainer = new System.Net.CookieContainer();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (username != null)
                chatService.disconnect(username);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userBox.Text))
            {
                username = userBox.Text;
                bool hasConnected = chatService.connect(username);

                if (hasConnected)
                {
                    messageBox.Enabled = true;
                    sendButton.Enabled = true;
                    userBox.Enabled = false;
                    connectButton.Enabled = false;

                    // Now start the timer
                    updateMessagesTimer = new Timer();
                    updateMessagesTimer.Tick += UpdateMessagesTimer_Tick;
                    updateMessagesTimer.Interval = 25;
                    updateMessagesTimer.Start();
                }
                else
                {
                    MessageBox.Show("Username taken!");
                }
            }
            else
            {
                MessageBox.Show("Username invalid!");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            // need to modify for private message, but for now broadcast is fine
            ChatMessage msg = new ChatMessage();
            msg.Sender = username;
            msg.Receiver = null;
            msg.Content = messageBox.Text;

            chatService.broadcastMessage(msg);

            messageBox.Text = string.Empty;
        }

        private void UpdateMessagesTimer_Tick(object sender, EventArgs e)
        {
            var arr = chatService.getUnreadMessages(username);

            foreach (ChatMessage msg in arr)
            {
                chatBox.AppendText(msg.Content);
            }
        }
    }
}
