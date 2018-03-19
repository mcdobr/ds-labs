using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace PongServer
{
    class PongServerProgram
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("PongServer.exe.config");


            Console.WriteLine("Server started. Press enter to end");
            Console.ReadLine();
        }
    }
}
