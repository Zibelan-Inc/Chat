using System.ServiceModel;

namespace LanChat.Network
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string nick, string message);
    }

    [ServiceBehavior()]
    public class ChatService : IChatService
    {

        public void SendMessage(string nick, string message)
        {
            Engine.ReceiveMessage(nick, message);
        }

        private static ChatEngine Engine
        {
            get
            {
                return OperationContext.Current.Host.Description.Behaviors.Find<ChatEngine>();
            }
        }
    }
}
