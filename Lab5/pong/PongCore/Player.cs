using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public enum PlayerSide
    {
        LEFT,
        RIGHT,
        NONE
    };

    public enum PlayerMovement
    {
        UP,
        DOWN,
        NONE
    };
    
    public class Player
    {
        const float DEFAULT_VERTICAL_POSITION = 300;
        const float DEFAULT_LEFT_POSITION = 25;
        const float DEFAULT_RIGHT_POSITION = 575;

        public readonly string id;
        float positionY;

        public Room room
        { get; set; }

        public Player(string id)
        {
            this.id = id;
        }
    }
}
