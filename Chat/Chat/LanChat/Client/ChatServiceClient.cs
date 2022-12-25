using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace LanChat.Network.Client
{


    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(ConfigurationName = "Network.Client.IChatService")]
    public interface IChatService
    {

        [OperationContract(IsOneWay = true, Action = "http://tempuri.org/IChatService/SendMessage")]
        void SendMessage(string nick, string message);

        [OperationContract(IsOneWay = true, Action = "http://tempuri.org/IChatService/SendMessage")]
        Task SendMessageAsync(string nick, string message);
    }

    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : IChatService, IClientChannel
    {
    }

    [DebuggerStepThrough()]
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : ClientBase<IChatService>, IChatService
    {

        public ChatServiceClient()
        {
        }

        public ChatServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public ChatServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ChatServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ChatServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }


        public void SendMessage(string nick, string message)
        {
            base.Channel.SendMessage(nick, message);
        }

        public Task SendMessageAsync(string nick, string message)
        {
            return base.Channel.SendMessageAsync(nick, message);
        }
    }
}
