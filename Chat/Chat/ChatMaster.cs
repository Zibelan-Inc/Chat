using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static Chat.frmMain;

namespace Chat.Chat
{
    class ChatMaster
    {
        private static UdpClient udpClient;
        private static UdpClient client;
        private static IPAddress multiCastAddress;
        private static IPEndPoint remoteEp;
        private static string userName;
        private static bool alive;
        static Client cliente = new Client();
        public static void Listen()
        {
            try
            {
                client = new UdpClient();
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 2222);
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
                client.ExclusiveAddressUse = false;
                client.Client.Bind(remoteEP);
                client.JoinMulticastGroup(multiCastAddress);

                while (alive)
                {
                    Byte[] data = client.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);
                    cliente.OnMessageRecieved(new MessageEventArgs(message));
                    //mensage.LoadMessage(message);

                }
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }
        public static void ConnectToChat()
        {
            try
            {
                multiCastAddress = IPAddress.Parse("239.0.0.222");
                udpClient = new UdpClient();
                udpClient.JoinMulticastGroup(multiCastAddress);
                remoteEp = new IPEndPoint(multiCastAddress, 2222);
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }

        public static void DisconnectFromChat()
        {
            try
            {
                alive = false;
                Transmit("Desconecto");
                client.DropMulticastGroup(multiCastAddress);
                client.Close();
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        public static void Transmit(string typeMessage, string content = "")
        {
            SmallMessage msg = new SmallMessage();                  //Clase con la estructura del Mensaje
            msg.Handle = NickName;                                  //Nombre de usuario
            msg.typeMessage = typeMessage;                          //Tipo de mensaje 
            msg.ColorID = UserSelectedColor;                        //Color para el bubble en CSS
            msg.content = content;                                  //Contenido del Mensaje
            msg.ID = UserId;
            if (typeMessage == "RecargarLista")                     //Si solicito recargar la lista de usuarios
                msg.content = Avatarlength.ToString();

            byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());   //Convierto la clase en json
             udpClient.Send(buffer, buffer.Length, remoteEp);        //La envio
        }
        public static void TransmitFull(string typeMessage, string content = "")
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


            byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());
            udpClient.Send(buffer, buffer.Length, remoteEp);
        }

        public static void StartListenner()
        {
            Thread ListenStart = new Thread(new ThreadStart(Listen));
            ListenStart.Start();

        }
    }
}
