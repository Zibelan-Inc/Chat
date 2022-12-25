using System.ComponentModel;
using LanChat.Network;
using Chat;
using MessageEventArgs = LanChat.Network.MessageEventArgs;

namespace LanChat
{
    public class ChatView 
    {
        public DelegateCommand LoginCommand { get; private set; }
        private ChatEngine engine;

        public ChatView()
        {
            LoginCommand = new DelegateCommand(_ => !string.IsNullOrEmpty(frmMain.NickName), Login);

            this.engine = new ChatEngine();
            this.engine.Initialize();

            this.engine.MessageReceived += EngineOnMessageReceived;

            engine.Login(frmMain.NickName);
        }

        private void Login(object _)
        {
            engine.Login(frmMain.NickName);
        }

        private void EngineOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            frmMain.ProcessNewMessage(messageEventArgs.Message);
        }

        public void Say(string message)
        {
            this.engine.Send(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
