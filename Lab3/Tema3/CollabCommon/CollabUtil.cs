using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CollabCommon
{
    public class CollabUtil
    {
        public static MessageQueue getMessageQueueAtPath(string path)
        {
            MessageQueue mq;
            if (MessageQueue.Exists(path))
                mq = new MessageQueue(path);
            else
                mq = MessageQueue.Create(path);

            return mq;
        }
    }
}
