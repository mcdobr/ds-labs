using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public class PongManager : MarshalByRefObject
    {
        
        public string connectPlayer()
        {
            string playerID = Guid.NewGuid().ToString();
            // Add player to smth
            return playerID;
        }

        public void disconnectPlayer()
        {
            // Remove player from smth
        }



        public void says()
        {
            Console.WriteLine("ijreiwqjiorewjoq");
        }

    }
}
