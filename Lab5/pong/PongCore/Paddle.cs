using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public class Paddle : MarshalByRefObject
    {
        string name;

        public void paddleSays()
        {
            Console.WriteLine("paddle says");
        }
    }
}
