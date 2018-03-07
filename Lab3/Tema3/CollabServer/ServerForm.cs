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

namespace CollabServer
{
    public partial class ServerForm : Form
    {
        private const string serverQueuePath = @".\private$\serverQueue";
        private static readonly TimeSpan connectTimeout = TimeSpan.FromSeconds(2);

        private MessageQueue serverQueue = Util.getMessageQueueAtPath(serverQueuePath);
        private List<Client> clients = new List<Client>();

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            IAsyncResult asyncResult = serverQueue.BeginReceive(connectTimeout,
                serverQueue,
                new AsyncCallback(onClientConnect)
            );

        }

        private void updateClientMessage(Client client)
        {
            Message wholeDocument = new Message();
            wholeDocument.Label = "Update";
            wholeDocument.Body = documentTextBox.Text;

            client.txQueue.Send(wholeDocument);
        }

        private void broadcastCurrentState(Client excludedClient)
        {
            clients.RemoveAll(client => !client.isConnected());
            
            foreach (Client client in clients)
            {
                if (client != excludedClient)
                    updateClientMessage(client);
            }
        }
        
        private void onClientConnect(IAsyncResult asyncResult)
        {
            try
            {
                Message msg = serverQueue.EndReceive(asyncResult);

                string clientUUID = (string)msg.Body;

                // Create client and send the acknowledge 
                Client client = new Client(clientUUID, true);
                updateClientMessage(client);
                clients.Add(client);

                client.rxQueue.BeginReceive(Client.maxLockTime,
                    client,
                    new AsyncCallback(onMessageReceived));
            }
            catch
            { }
            finally
            {
                serverQueue.BeginReceive(connectTimeout,
                    serverQueue,
                    new AsyncCallback(onClientConnect)
                );
            }
        }

        private void onMessageReceived(IAsyncResult asyncResult)
        {
            Client client = (Client)asyncResult.AsyncState;
            try
            {
                Message msg = client.rxQueue.EndReceive(asyncResult);
                string text = (string)msg.Body;


                this.Invoke((MethodInvoker)delegate ()
                {
                    documentTextBox.Text = (string)msg.Body;
                    broadcastCurrentState(client);
                });

            }
            catch
            {
                // TimeOut
            }
            finally
            {
                client.rxQueue.BeginReceive(Client.maxLockTime,
                    client,
                    new AsyncCallback(onMessageReceived));
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            serverQueue.Close();
            MessageQueue.Delete(serverQueuePath);
        }
    }
}
