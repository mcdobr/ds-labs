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

namespace CollabClient
{
    public partial class ClientForm : Form
    {
        private const string serverQueuePath = @".\private$\serverQueue";

        private readonly string uuid = Guid.NewGuid().ToString();

        private MessageQueue serverQueue;


        public ClientForm()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {

        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            serverQueue = new MessageQueue(serverQueuePath);

            string rxQueueStr = "rx_" + uuid;
            string txQueueStr = "tx_" + uuid;


            
        }
    }
}
