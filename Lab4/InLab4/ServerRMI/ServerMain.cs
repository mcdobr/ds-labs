using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ServerRMI
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            RemotingConfiguration.Configure("../../Server.config");

            Console.WriteLine("Server started. Press enter to end...");
            Console.ReadLine();
        }
    }
}
