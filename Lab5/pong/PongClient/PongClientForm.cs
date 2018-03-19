using PongCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongClient
{
    public partial class PongClientForm : Form
    {
        private Ball ball;
        private Paddle leftPaddle, rightPaddle;


        public PongClientForm()
        {
            InitializeComponent();
        }

        private void PongClientForm_Load(object sender, EventArgs e)
        {
            AllocConsole();
            RemotingConfiguration.Configure("PongClient.exe.config");

            PongManager pongManager = new PongManager();
            pongManager.says();

        }

        /* adaugat pt a vedea dacă se realizează remoting-ul calumea */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}
