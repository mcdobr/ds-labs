using System;

namespace PongCore
{
    public class Room
    {
        private RoomInfo coords;

        public Player leftPlayer
        { get; set; }

        public Player rightPlayer
        { get; set; }
        
        public Room()
        {
            leftPlayer = rightPlayer = null;
            coords = new RoomInfo();
        }

        public bool hasOpenSpot()
        {
            return (leftPlayer == null) || (rightPlayer == null);
        }

        public void assignPlayer(Player player)
        {
            if (leftPlayer == null)
            {
                leftPlayer = player;
                player.side = PlayerSide.LEFT;
            }
            else
            {
                rightPlayer = player;
                player.side = PlayerSide.RIGHT;
            }
        }

        public void removePlayer(Player player)
        {
            if (leftPlayer == player)
                leftPlayer = null;
            if (rightPlayer == player)
                rightPlayer = null;
        }

        internal RoomInfo getCoords()
        {
            return coords;
        }
    }
}