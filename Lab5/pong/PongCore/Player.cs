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
        public readonly string id;
        float positionY;

        public Room room
        { get; set; }

        public PlayerSide side
        { get; set; }

        public Player(string id)
        {
            this.id = id;
            this.side = PlayerSide.NONE;
        }
    }
}
