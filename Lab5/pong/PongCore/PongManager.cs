using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public class PongManager : MarshalByRefObject
    {

        private List<Player> players;
        private List<Room> rooms;

        public PongManager()
        {
            players = new List<Player>();
            rooms = new List<Room>();
        }
        
        public string connectPlayer()
        {
            Console.WriteLine("Connecting new player");

            string playerID = Guid.NewGuid().ToString();

            Player player = new Player(playerID);
            players.Add(player);

            // If there are no rooms
            if (rooms.Any())
                rooms.Add(new Room());

            // Find first open room
            int openIndex = rooms.FindIndex(r => r.hasOpenSpot());

            Room room;
            if (openIndex == -1)
            {
                room = new Room();
                rooms.Add(room);
                // Link the objects between them
                room.assignPlayer(player);
                player.room = room;
            }
            else
            {
                room = rooms.ElementAt(openIndex);
                room.assignPlayer(player);
                player.room = room;
            }

            Console.WriteLine("Assigned player with id {0} to room {1}", player.id, rooms.FindIndex(r => r == room));
            return playerID;
        }

        public void disconnectPlayer(string playerID)
        {
            Console.WriteLine("Disconnecting player with id {0}", playerID);

            int playerIndex = players.FindIndex(p => p.id == playerID);
            if (playerIndex > -1)
            {
                Player player = players.ElementAt(playerIndex);

                Room room = player.room;
                room.removePlayer(player);
                // No clearing of empty rooms needed for this. At least yet

                player.room = null;
                players.Remove(player);
            }
        }

        public PlayerSide getPlayerSide(string playerID)
        {
            int playerIndex = players.FindIndex(p => p.id == playerID);
            if (playerIndex == -1)
                return PlayerSide.NONE;

            Player player = players.ElementAt(playerIndex);
            return (player == player.room.leftPlayer) ? PlayerSide.LEFT : PlayerSide.RIGHT;
        }

        public RoomInfo getRoomCoords(string playerID)
        {
            int playerIndex = players.FindIndex(p => p.id == playerID);
            if (playerIndex == -1)
                return null;

            Player player = players.ElementAt(playerIndex);
            return player.room.getCoords();
        }

        private Player getPlayerByID(string playerID)
        {
            int playerIndex = players.FindIndex(p => p.id == playerID);
            if (playerIndex == -1)
                return null;

            Player player = players.ElementAt(playerIndex);
            return player;
        }

        public RoomInfo updateEntityCoordinates(string playerID, PlayerMovement playerMovement)
        {
            RoomInfo coords = getRoomCoords(playerID);

            if (playerMovement != PlayerMovement.NONE)
            {
                Player player = getPlayerByID(playerID);

                if (playerMovement == PlayerMovement.UP)
                {
                    if (player.side == PlayerSide.LEFT)
                        coords.leftPaddleCoords -= RoomInfo.dPaddle;
                    else if (player.side == PlayerSide.RIGHT)
                        coords.rightPaddleCoords -= RoomInfo.dPaddle;
                }
                else
                {
                    if (player.side == PlayerSide.LEFT)
                        coords.leftPaddleCoords += RoomInfo.dPaddle;
                    else if (player.side == PlayerSide.RIGHT)
                        coords.rightPaddleCoords += RoomInfo.dPaddle;
                }
            }
            return coords;
        }
    }
}
