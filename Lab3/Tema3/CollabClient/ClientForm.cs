using CollabCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Message = System.Messaging.Message;

namespace CollabClient
{
    public partial class ClientForm : Form
    {
        private const string serverQueuePath = @".\private$\serverQueue";

        private MessageQueue serverQueue;
        private Client client;
        private List<string> lines = new List<string>();

        public ClientForm()
        {
            InitializeComponent();
            
            /* Initialize other stuff */
            serverQueue = Util.getMessageQueueAtPath(serverQueuePath);
            
            client = new Client();
            Message connectMessage = new Message();
            connectMessage.Label = "New user";
            connectMessage.Body = client.uuid;

            serverQueue.Send(connectMessage);

            // TODO: Add parameters here
            client.rxQueue.BeginReceive();

        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            string text = paragraphTextBox.Text;

            Message msg = new Message();
            msg.Label = "Line";
            msg.Body = text + Environment.NewLine;

            client.txQueue.Send(msg);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            client.rxQueue.Close();
            MessageQueue.Delete(client.rxQueue.Path);

            client.txQueue.Close();
            MessageQueue.Delete(client.txQueue.Path);
        }
    }
}
