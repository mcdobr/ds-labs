using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Transmitter
{
    class TransmitterProgram
    {
        private const string messageQueuePath = @".\private$\NewPrivateQueue";

        static void Main(string[] args)
        {
            MessageQueue messageQueue;
            if (MessageQueue.Exists(messageQueuePath))
                messageQueue = new MessageQueue(messageQueuePath);
            else
                messageQueue = MessageQueue.Create(messageQueuePath);

            int i = 0;
            do
            {
                Message msg = new Message();
                msg.Label = "customer message";
                msg.Body = new Customer("Homer Simpson" + (++i), "1234", "hs@abc.com");
                messageQueue.Send(msg);
            } while (Console.ReadLine() != "q");

            messageQueue.Close();
            MessageQueue.Delete(messageQueuePath);
        }
    }
}
