
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chat
{
    internal class UDPHelper : IDisposable
    {
        private readonly UdpClient _udpClient;

        private IPEndPoint _remoteEP;

        private static Encoding UnifiedEnconding => Encoding.UTF8;

        public UDPHelper(UdpClient udpClient, IPEndPoint remoteEP)
        {
            _udpClient = udpClient;
            _remoteEP = remoteEP;
        }

        public void Dispose()
        {
            _udpClient.Close();
        }

        public void Send(string s)
        {
            SendData(Encoding.ASCII.GetBytes(s));
        }

        public string Receive()
        {
            byte[] array = ReceivedData();
            return UnifiedEnconding.GetString(array, 0, array.Length);
        }

        private void SendData(byte[] packetBytes)
        {
            _udpClient.Send(packetBytes, packetBytes.Length, _remoteEP);
        }

        private byte[] ReceivedData()
        {
            try
            {
                return _udpClient.Receive(ref _remoteEP);
            }
            catch (SocketException ex)
            {

                return UnifiedEnconding.GetBytes(ex.Message);

            }
        }
    }

}