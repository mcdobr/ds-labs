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
        const int TIMER_INTERVAL = 20;

        private Keys lastPressed = Keys.None;
        private PongManager pongManager;
        private string playerID;
        private PlayerSide playerSide;
        private Timer gameClock;

        public PongClientForm()
        {
            InitializeComponent();
        }

        private void PongClientForm_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure("PongClient.exe.config");
            
            pongManager = new PongManager();
            playerID = pongManager.connectPlayer();
            playerSide = pongManager.getPlayerSide(playerID);

            gameClock = new Timer();
            gameClock.Interval = TIMER_INTERVAL;
            gameClock.Tick += onGameClockTick;
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
            pongManager.disconnectPlayer(playerID);
        }

        private void PongClientForm_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            e.Graphics.FillRectangle(blackBrush, 0, 0, this.Size.Width, this.Size.Height);
        }

        private void onGameClockTick(object sender, EventArgs e)
        {
            // coordinates = pongManager.getCoords();
            pongManager.getCoordinates(playerID);

            this.Invalidate();
        }
    }
}
