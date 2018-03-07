using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace MathServer
{
    class ServerMain
    {
        static void Main(string[] args)
        { // Read remoting info from config file.
            RemotingConfiguration.Configure("Server.config");
            // Keep the server alive until Enter is pressed.
            Console.WriteLine("Server started. Press Enter to end ...");
            Console.ReadLine();
        }
    }
}