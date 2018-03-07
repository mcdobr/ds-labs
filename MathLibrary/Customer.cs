using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Customer : MarshalByRefObject
    {
        string mName;
        public Customer(string name)
        {
            Console.WriteLine("Customer.ctor({0})", name);
            mName = name;
        }
        public string SayHello()
        {
            Console.WriteLine("Customer.SayHello()");
            return "Hello " + mName;
        }
    }
}
