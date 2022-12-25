using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Remote
{
   public class Client
    {
        public SharedTypeInterface remoteObject;
        public Client(string host = "localhost",int port =9998)
        {
            TcpChannel tcpChannel = new TcpChannel();
            bool needreg = true;
            foreach (var item in ChannelServices.RegisteredChannels )
            {
                if (item.ChannelName==tcpChannel.ChannelName )
                {
                    needreg = false;
                }
            }
            if (needreg )
            {
                //ChannelServices.RegisterChannel(tcpChannel);
                ChannelServices.RegisterChannel(tcpChannel, true);

            }


            Type requiredType = typeof(SharedTypeInterface);

            remoteObject = (SharedTypeInterface)Activator.GetObject(requiredType,
            "tcp://"+ host+":"+port.ToString()+"/RemoteService");
            Console.WriteLine(remoteObject.GetRemoteStatus("Ticket No: 3344"));
        }
    }
}
