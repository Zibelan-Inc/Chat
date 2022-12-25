using System;

namespace Chat
{

    public class Client
    {
        public event EventHandler<MessageEventArgs> MessageReceived;
        public static string Userstate { get; set; }
        public virtual void OnMessageRecieved(MessageEventArgs e)
        {
            if (MessageReceived != null) MessageReceived(this, e);
        }
    }
}
