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
            RemotingConfiguration.RegisterActivatedClientType(typeof(MathLibrary.Customer),
          "http://localhost:10000");
            // Calling a nondefault constructor. No exceptions now because
            // Customer is a client-activated object.
            Customer cust = new Customer("Homer");
            Console.WriteLine(cust.SayHello());
            Console.ReadLine();
        }
    }
}
