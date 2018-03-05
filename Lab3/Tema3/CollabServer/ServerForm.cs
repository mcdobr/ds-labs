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

namespace CollabServer
{
    public partial class ServerForm : Form
    {
        private const string serverQueuePath = @".\private$\serverQueue";

        private MessageQueue serverQueue;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverQueue = CollabUtil.getMessageQueueAtPath(serverQueuePath);
        }
    }
}
