using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CollabCommon
{
    public class Util
    {
        public static MessageQueue getMessageQueueAtPath(string path)
        {
            MessageQueue mq;
            if (MessageQueue.Exists(path))
                mq = new MessageQueue(path);
            else
                mq = MessageQueue.Create(path);

            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            return mq;
        }
    }
}
