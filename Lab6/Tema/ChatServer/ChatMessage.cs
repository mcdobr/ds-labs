using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer
{
    public class ChatMessage
    {
        public ChatMessage() { }

        public ChatMessage(ChatMessage other)
        {
            Sender = other.Sender;
            Receiver = other.Receiver;
            Content = other.Content;
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
    }
}