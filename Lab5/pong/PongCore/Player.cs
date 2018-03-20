using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public class Player
    {
        const float DEFAULT_POSITION = 300;
        
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
