namespace PongCore
{
    public class Room
    {
        public Player leftPlayer
        { get; set; }

        public Player rightPlayer
        { get; set; }
        
        public Room()
        {
            leftPlayer = rightPlayer = null;
        }

        public bool hasOpenSpot()
        {
            return (leftPlayer == null) || (rightPlayer == null);
        }

        public void assignPlayer(Player player)
        {
            if (leftPlayer == null)
                leftPlayer = player;
            else
                rightPlayer = player;
        }

        public void removePlayer(Player player)
        {
            if (leftPlayer == player)
                leftPlayer = null;
            if (rightPlayer == player)
                rightPlayer = null;
        }
    }
}