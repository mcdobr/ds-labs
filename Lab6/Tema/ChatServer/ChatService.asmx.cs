using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace ChatServer
{
    /// <summary>
    /// Summary description for ChatService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ChatService : System.Web.Services.WebService
    {
        public ChatService()
        {
            if (Application["users"] == null)
                Application["users"] = new List<string>();
            if (Application["userMessageQueues"] == null)
                Application["userMessageQueues"] = new Dictionary<string, Queue<ChatMessage>>();
        }

        [WebMethod(EnableSession = true)]
        public bool connect(string username)
        {
            var users = Application["users"] as List<string>;
            if (users.Contains(username))
                return false;

            if (!Regex.IsMatch(username, "^[a-zA-Z]+"))
                return false;

            users.Add(username);
            var userMessageQueues = Application["userMessageQueues"] as Dictionary<string, Queue<ChatMessage>>;
            userMessageQueues[username] = new Queue<ChatMessage>();

            return true;
        }

        [WebMethod(EnableSession = true)]
        public void disconnect(string username)
        {
            var users = Application["users"] as List<string>;
            var userMessageQueues = Application["userMessageQueues"] as Dictionary<string, Queue<ChatMessage>>;

            users.Remove(username);
            userMessageQueues.Remove(username);
        }

        [WebMethod(EnableSession = true)]
        public void broadcastMessage(ChatMessage msg)
        {
            var userMessageQueues = Application["userMessageQueues"] as Dictionary<string, Queue<ChatMessage>>;
            foreach (var entry in userMessageQueues)
            {
                var queue = entry.Value;
                queue.Enqueue(msg);
            }
        }

        [WebMethod(EnableSession = true)]
        public void sendPrivateMessage(ChatMessage msg)
        {
            var userMessageQueues = Application["userMessageQueues"] as Dictionary<string, Queue<ChatMessage>>;

            var senderQueue = userMessageQueues[msg.Sender];
            senderQueue.Enqueue(msg);

            // Receiver could be null. must check
            var receiverQueue = userMessageQueues[msg.Receiver];
            receiverQueue.Enqueue(msg);
        }

        // Can't use queue for some reason
        [WebMethod(EnableSession = true)]
        public ChatMessage[] getUnreadMessages(string username)
        {
            var userMessageQueues = Application["userMessageQueues"] as Dictionary<string, Queue<ChatMessage>>;
            var array = userMessageQueues[username].ToArray();
            userMessageQueues[username].Clear();

            return array;
        }

        [WebMethod(EnableSession = true)]
        public string[] getConnectedUsers()
        {
            var us = Application["users"] as List<string>;
            return us.ToArray();
        }
    }
}
