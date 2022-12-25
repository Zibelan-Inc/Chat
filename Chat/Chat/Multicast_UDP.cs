using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static Chat.frmMain;

namespace Chat
{
    public class Multicast_UDP
    {
        private static UdpClient udpClient;
        private static UdpClient client;
        private static IPAddress multiCastAddress;
        private static IPEndPoint remoteEp;
        private static bool alive = true;
        private static Client cliente;
        static IPEndPoint remoteEP;
        static IPEndPoint RemoteEP;
        public Multicast_UDP()
        {
            multiCastAddress = IPAddress.Parse("239.0.0.222");
            remoteEP = new IPEndPoint(IPAddress.Any, 2222);
            //remoteEP = new IPEndPoint(IPAddress.Any, 0);
            cliente = new Client();

            Thread listenner = new Thread(Listen);
            listenner.IsBackground = true;
            listenner.Start();
        }

        public static void Listen()
        {
            client = new UdpClient();
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
            client.ExclusiveAddressUse = false;
            client.MulticastLoopback = true;
            client.Client.Bind(remoteEP);
            client.JoinMulticastGroup(multiCastAddress, IPAddress.Parse(Modcommon.GetIp()));

            while (alive)
            {
                byte[] data = client.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(data);
                ProcessNewMessage(message);
            }
        }
        public void ConnectToChat()
        {
            try
            {
                udpClient = new UdpClient();
                udpClient.JoinMulticastGroup(multiCastAddress);
                RemoteEP = new IPEndPoint(multiCastAddress, 2222);
            }
            catch (Exception ex) { WriteLog.Write(ex.Message); }

        }

        public static void DisconnectFromChat()
        {
            try
            {
                Transmit("Desconecto");
                alive = false;
                client.DropMulticastGroup(multiCastAddress);
                client.Close();
            }
            catch (Exception ex) { WriteLog.Write(ex.Message); }
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

            byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());
            udpClient.Send(buffer, buffer.Length, RemoteEP);
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
            udpClient.Send(buffer, buffer.Length, RemoteEP);
        }
    }
}


