using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using LanChat.Network.Client;

namespace LanChat.Network
{
    public class ChatEngine : IServiceBehavior
    {
        public event EventHandler<MessageEventArgs> MessageReceived;

        public void Login(string desiredNick)
        {
            chatService.Open();

            this.myNick = desiredNick;
        }

        public void Send(string message)
        {
            chatClient.SendMessageAsync(this.myNick, message);
        }


        internal void ReceiveMessage(string fromNick, string message)
        {
            var handler = MessageReceived;
            if (handler != null)
                handler(this, new MessageEventArgs(fromNick, message));
        }


        private string myNick;

        private const int Port = 31498;
        private ServiceHost chatService;
        private ChatServiceClient chatClient;

        private static string MulticastAddress
        {
            get { return "soap.udp://224.0.0.1:" + Port; }
        }

        public void Initialize()
        {
            chatService = new ServiceHost(typeof(ChatService), new Uri(MulticastAddress), new Uri("net.tcp://localhost:31499/"));

            var multicastBinding = new UdpBinding();
            chatService.AddServiceEndpoint(typeof(IChatService), multicastBinding, "");

            chatService.Description.Behaviors.Add((IServiceBehavior)this);

            chatClient = new ChatServiceClient(new UdpBinding(), new EndpointAddress(MulticastAddress));
        }

        #region Implementation of IServiceBehavior

        void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }

        void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }

    public class UserEventArgs : EventArgs
    {
        public readonly string Nick;

        public UserEventArgs(string nick)
        {
            Nick = nick;
        }
    }

    public class MessageEventArgs : UserEventArgs
    {
        public readonly string Message;

        public MessageEventArgs(string nick, string message) : base(nick)
        {
            Message = message;
        }
    }
}
