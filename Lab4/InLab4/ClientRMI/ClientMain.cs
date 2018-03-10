using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace MathClient
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("../../Client.config");

            SimpleMath math = new SimpleMath();

            Console.WriteLine("5 + 2 = {0}", math.Add(5, 2));
            Console.WriteLine("5 - 2 = {0}", math.Subtract(5,2));
            // Ask user to press Enter
            Console.Write("Press enter to end");
            Console.ReadLine();
        }
    }
}
