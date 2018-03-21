using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    [Serializable]
    public class RoomInfo
    {
        public const int PADDLE_WIDTH = 10;
        public const int PADDLE_HEIGHT = 60;
        public const int BALL_SIDE_LENGTH = 10;

        public const int GAME_WIDTH = 600;
        public const int GAME_HEIGHT = 400;

        public const int DEFAULT_LEFT_PADDLE_X_POSITION = 15;
        public const int DEFAULT_RIGHT_PADDLE_X_POSITION = GAME_WIDTH - DEFAULT_LEFT_PADDLE_X_POSITION - PADDLE_WIDTH;
        public const int DEFAULT_PADDLE_Y_POSITION = (GAME_HEIGHT - PADDLE_HEIGHT) / 2;

        public const int DEFAULT_BALL_X_POSITION = (GAME_WIDTH - BALL_SIDE_LENGTH) / 2;
        public const int DEFAULT_BALL_Y_POSITION = (GAME_HEIGHT - BALL_SIDE_LENGTH) / 2;

        public Vector2 leftPaddleCoords, rightPaddleCoords;
        public Vector2 ballPosition;

        public RoomInfo()
        {
            leftPaddleCoords = new Vector2(DEFAULT_LEFT_PADDLE_X_POSITION, DEFAULT_PADDLE_Y_POSITION);
            rightPaddleCoords = new Vector2(DEFAULT_RIGHT_PADDLE_X_POSITION, DEFAULT_PADDLE_Y_POSITION);
            ballPosition = new Vector2(DEFAULT_BALL_X_POSITION, DEFAULT_BALL_Y_POSITION);
        }
    }
}
