﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    public class Ball : MarshalByRefObject
    {
        public void says()
        {
            Console.WriteLine("ball says");
        }

    }
}
