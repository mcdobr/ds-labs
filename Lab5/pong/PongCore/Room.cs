namespace PongCore
{
    public class Room
    {
        Player leftPlayer, rightPlayer;
        
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