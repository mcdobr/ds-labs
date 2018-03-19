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
        private Keys lastPressed = Keys.None;
        private PongManager pongManager;


        public PongClientForm()
        {
            InitializeComponent();
        }

        private void PongClientForm_Load(object sender, EventArgs e)
        {
            AllocConsole();
            RemotingConfiguration.Configure("PongClient.exe.config");
            
            pongManager = new PongManager();
            pongManager.connectPlayer();
            pongManager.says();

        }

        private void PongClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            lastPressed = e.KeyCode;
        }
        
        private void PongClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            lastPressed = Keys.None;
        }
        
        private void PongClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pongManager.disconnectPlayer();
        }

        private void PongClientForm_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            e.Graphics.FillRectangle(blackBrush, 0, 0, this.Size.Width, this.Size.Height);
        }

        /* adaugat pt a vedea dacă se realizează remoting-ul calumea */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}
