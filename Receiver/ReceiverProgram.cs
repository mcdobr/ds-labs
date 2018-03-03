using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    class ReceiverProgram
    {
        private const string messageQueuePath = @".\private$\NewPrivateQueue";
        private static readonly TimeSpan messageTimeout = TimeSpan.FromSeconds(30);

        static void onMessageReceived(IAsyncResult asyncResult)
        {
            MessageQueue messageQueue = (MessageQueue)asyncResult.AsyncState;

            try
            {
                Message msg = messageQueue.EndReceive(asyncResult);

                Customer c = (Customer)msg.Body;
                Console.WriteLine(c.name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                messageQueue.BeginReceive(messageTimeout,
                    messageQueue,
                    new AsyncCallback(onMessageReceived));
            }
        }


        static void Main(string[] args)
        {
            MessageQueue messageQueue = new MessageQueue(messageQueuePath);

            Type[] expectedTypes = new Type[] {typeof(Customer)};
            messageQueue.Formatter = new XmlMessageFormatter(expectedTypes);

            // Al doilea parametru e obiectul care e pasat ca AsyncState
            // in obiectul asyncResult 
            IAsyncResult asyncResult = messageQueue.BeginReceive(
                messageTimeout,
                messageQueue,
                new AsyncCallback(onMessageReceived)
            );

            while (true)
            {
                /*
                Message msg = messageQueue.Receive();
                Console.WriteLine(msg.Body.ToString());*/
            }
        }
    }
}
