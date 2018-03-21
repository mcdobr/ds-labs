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
        const int TIMER_INTERVAL = 30;
        
        private PlayerMovement lastMovement = PlayerMovement.NONE;
        private PongManager pongManager;
        private string playerID;
        private PlayerSide playerSide;
        private Timer gameClock;
        private RoomInfo coords;

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
            coords = pongManager.getRoomCoords(playerID);


            this.ClientSize = new Size(RoomInfo.GAME_WIDTH, RoomInfo.GAME_HEIGHT);

            gameClock = new Timer();
            gameClock.Interval = TIMER_INTERVAL;
            gameClock.Tick += onGameClockTick;
            gameClock.Start();
        }

        private void PongClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (playerSide == PlayerSide.LEFT)
            {
                if (e.KeyCode == Keys.A)
                    lastMovement = PlayerMovement.UP;
                else if (e.KeyCode == Keys.D)
                    lastMovement = PlayerMovement.DOWN;
                else
                    lastMovement = PlayerMovement.NONE;
            }
            else if (playerSide == PlayerSide.RIGHT)
            {
                if (e.KeyCode == Keys.Right)
                    lastMovement = PlayerMovement.UP;
                else if (e.KeyCode == Keys.Left)
                    lastMovement = PlayerMovement.DOWN;
                else
                    lastMovement = PlayerMovement.NONE;
            }
        }
        
        private void PongClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            lastMovement = PlayerMovement.NONE;
        }
        
        private void PongClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pongManager.disconnectPlayer(playerID);
        }

        private void PongClientForm_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            // Paint the screen black
            e.Graphics.FillRectangle(blackBrush, 0, 0, this.Size.Width, this.Size.Height);

            // Paint the white paddles
            e.Graphics.FillRectangle(whiteBrush, coords.leftPaddleCoords.x, coords.leftPaddleCoords.y, RoomInfo.PADDLE_WIDTH, RoomInfo.PADDLE_HEIGHT);
            e.Graphics.FillRectangle(whiteBrush, coords.rightPaddleCoords.x, coords.rightPaddleCoords.y, RoomInfo.PADDLE_WIDTH, RoomInfo.PADDLE_HEIGHT);

            // Paint the ball
            e.Graphics.FillRectangle(whiteBrush, coords.ballPosition.x, coords.ballPosition.y, RoomInfo.BALL_SIDE_LENGTH, RoomInfo.BALL_SIDE_LENGTH);
        }

        private void onGameClockTick(object sender, EventArgs e)
        {
            // coordinates = pongManager.getCoords();
            coords = pongManager.updateEntityCoordinates(playerID, lastMovement);

            this.Invalidate();
        }
    }
}
