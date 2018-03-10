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
        static void printArray<T>(T[] array)
        {
            Console.WriteLine(string.Join(",", array));
        }

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("../../Client.config");

            SimpleMath math = new SimpleMath();

            Console.WriteLine("5 + 2 = {0}", math.Add(5, 2));
            Console.WriteLine("5 - 2 = {0}", math.Subtract(5,2));

            int[] v = new int[] { 2, 3, 1, 521, 23418, 4321, 152 };
            int[] sorted = math.Sort<int>(v);

            printArray(sorted);
            
            Console.WriteLine(math.IndexOf(v, 521));

            int[] removedElem = math.RemoveElement(v, 23418);
            printArray(removedElem);

            // Ask user to press Enter
            Console.Write("Press enter to end");
            Console.ReadLine();
        }
    }
}
