using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CollabCommon
{
    public class Client
    {
        private const string prefix = @".\private$\";
        public static TimeSpan maxLockTime = TimeSpan.FromMinutes(1);
        
        public readonly string uuid;
        public MessageQueue rxQueue, txQueue;

        public Client()
        {
            uuid = Guid.NewGuid().ToString();
            rxQueue = Util.getMessageQueueAtPath(prefix + "rx_" + uuid);
            txQueue = Util.getMessageQueueAtPath(prefix + "tx_" + uuid);
        }
        
        public Client(string uuid, bool reverse = false)
        {
            this.uuid = uuid;
            if (!reverse)
            {
                rxQueue = Util.getMessageQueueAtPath(prefix + "rx_" + uuid);
                txQueue = Util.getMessageQueueAtPath(prefix + "tx_" + uuid);
            }
            else
            {
                rxQueue = Util.getMessageQueueAtPath(prefix + "tx_" + uuid);
                txQueue = Util.getMessageQueueAtPath(prefix + "rx_" + uuid);
            }
        }

        public bool isConnected()
        {
            return MessageQueue.Exists(rxQueue.Path) 
                && MessageQueue.Exists(txQueue.Path);
        }
    }
}
