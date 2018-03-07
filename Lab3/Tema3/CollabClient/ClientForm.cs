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

        public ClientForm()
        {
            InitializeComponent();
        }
        
        private void ClientForm_Load(object sender, EventArgs e)
        {
            serverQueue = Util.getMessageQueueAtPath(serverQueuePath);

            client = new Client();
            Message connectMessage = new Message();
            connectMessage.Label = "New user";
            connectMessage.Body = client.uuid;

            serverQueue.Send(connectMessage);

            client.rxQueue.BeginReceive(Client.maxLockTime,
                client,
                new AsyncCallback(onUpdateReceived)
            );

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            client.rxQueue.Close();
            MessageQueue.Delete(client.rxQueue.Path);

            client.txQueue.Close();
            MessageQueue.Delete(client.txQueue.Path);
        }

        private void onUpdateReceived(IAsyncResult asyncResult)
        {
            Client client = (Client)asyncResult.AsyncState;
            try
            {
                Message msg = client.rxQueue.EndReceive(asyncResult);

                documentTextBox.TextChanged -= documentTextBox_TextChanged;
                documentTextBox.Text = (string)msg.Body;
                documentTextBox.TextChanged += documentTextBox_TextChanged;
                /*
                this.Invoke((MethodInvoker)delegate ()
                {
                });*/
            }
            catch
            { }
            finally
            {
                client.rxQueue.BeginReceive(Client.maxLockTime,
                    client,
                    new AsyncCallback(onUpdateReceived)
                );
            }
        }

        private void documentTextBox_TextChanged(object sender, EventArgs e)
        {
            Message msg = new Message();
            msg.Label = "Update";
            msg.Body = documentTextBox.Text;

            client.txQueue.Send(msg);
        }
    }
}
