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
        //private Dictionary<Client, int> lockedLine = new Dictionary<Client, int>();
        private List<string> lines = new List<string>();

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

        private void ackClientMessage(Client client)
        {
            Message wholeDocument = new Message();
            wholeDocument.Label = "Ack";
            wholeDocument.Body = documentTextBox.Text;

            client.txQueue.Send(wholeDocument);
        }

        private void broadcastCurrentState()
        {
            clients.RemoveAll(client => !client.isConnected());
            
            foreach (Client client in clients)
            {
                ackClientMessage(client);
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
                ackClientMessage(client);
                clients.Add(client);

                client.rxQueue.BeginReceive(Client.maxLockTime,
                    client,
                    new AsyncCallback(onLineReceived));
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

        private void onLineReceived(IAsyncResult asyncResult)
        {

            Client client = (Client)asyncResult.AsyncState;
            try
            {
                Message lineMessage = client.rxQueue.EndReceive(asyncResult);
                string line = (string)lineMessage.Body;

                documentTextBox.AppendText(line);
                broadcastCurrentState();
            }
            catch
            {
                // TimeOut
            }
            finally
            {
                client.rxQueue.BeginReceive(Client.maxLockTime,
                    client,
                    new AsyncCallback(onLineReceived));
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            serverQueue.Close();
            MessageQueue.Delete(serverQueuePath);
        }
    }
}
