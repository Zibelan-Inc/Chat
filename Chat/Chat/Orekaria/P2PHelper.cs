using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Chat.frmMain;

namespace Chat
{
    public class P2PHelper : IDisposable
    {
        private const int TimeOut = 1000;

        private readonly bool _encript;

        private readonly string _passPhrase;

        private readonly int _port;

        private readonly Queue<string> _received;

        private readonly Thread _thClient;

        private readonly Thread _thServer;

        private readonly Queue<string> _toSend;

        private bool _disposing;

        public Queue<string> Received => _received;

        public P2PHelper(int port)
            : this(port, string.Empty)
        {
        }

        public P2PHelper(int port, string passPhrase)
        {
            _port = port;
            _encript = !string.IsNullOrEmpty(passPhrase);
            _passPhrase = passPhrase;
            _toSend = new Queue<string>();
            _received = new Queue<string>();
            _thServer = new Thread(ServerThread);
            _thClient = new Thread(ClientThread);
            _thServer.Start();
            _thClient.Start();
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
            _disposing = true;
            _thClient.Join();
            _thServer.Join();
        }

        public void Send(string s)
        {
            _toSend.Enqueue(s);
        }

        private void ServerThread()
        {
            UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, _port));
            udpClient.Client.ReceiveTimeout = 1000;
            UdpClient udpClient2 = udpClient;
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            UDPHelper uDPHelper = new UDPHelper(udpClient2, remoteEP);
            while (!_disposing)
            {
                string text = uDPHelper.Receive();
                //_received.Enqueue(_encript ? EncriptHelper.DecryptString(text, _passPhrase) : text);
                ProcessNewMessage(_encript ? EncriptHelper.DecryptString(text, _passPhrase) : text);
                Thread.Sleep(1);
            }
            uDPHelper.Dispose();
        }

        private void ClientThread()
        {
            UdpClient udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            udpClient.Client.ReceiveTimeout = 1000;
            UdpClient udpClient2 = udpClient;
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Broadcast, _port);
            UDPHelper uDPHelper = new UDPHelper(udpClient2, remoteEP);
            while (!_disposing)
            {
                while (_toSend.Count > 0)
                {
                    string text = _toSend.Dequeue();
                    uDPHelper.Send(_encript ? EncriptHelper.EncryptString(text, _passPhrase) : text);
                }
                Thread.Sleep(10);
            }
            uDPHelper.Dispose();
        }

        public void Transmit(string typeMessage, string content = "")
        {
            SmallMessage msg = new SmallMessage();                  //Clase con la estructura del Mensaje
            msg.Handle = NickName;                                  //Nombre de usuario
            msg.typeMessage = typeMessage;                          //Tipo de mensaje 
            msg.ColorID = UserSelectedColor;                        //Color para el bubble en CSS
            msg.content = content;                                  //Contenido del Mensaje
            msg.ID = UserId;
            if (typeMessage == "RecargarLista")                     //Si solicito recargar la lista de usuarios
                msg.content = Avatarlength.ToString();

            Send(msg.ToJson());
        }
        public void TransmitFull(string typeMessage, string content = "")
        {
            Message msg = new Message();
            msg.Handle = NickName;
            msg.typeMessage = typeMessage;
            msg.content = content;
            msg.ColorID = UserSelectedColor;
            msg.MachineName = Environment.MachineName;
            msg.IP = Modcommon.GetIp();
            msg.State = Modcommon.State(MyStatus);
            msg.FormActivo = WinMod.IsActiveMainWindow().ToString();
            msg.AvatarLength = Avatarlength;
            msg.ConnectedTime = frmMain.frm.ConnectedTime;
            msg.ID = UserId;
            msg.IdleTime = frmMain.frm.IdleTime;

            if (typeMessage == "Idle")
                msg.content = frmMain.frm.IdleTime;

            Send(msg.ToJson());
        }

    }
}
