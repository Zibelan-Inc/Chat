using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Remote
{
    public class Server
    {
        public Server(int port = 9998)
        {
            try
            {
                Console.WriteLine("Remote Server started...");

                TcpChannel tcpChannel = new TcpChannel(port);
                //ChannelServices.RegisterChannel(tcpChannel);
                ChannelServices.RegisterChannel(tcpChannel, true);

                Type commonInterfaceType = Type.GetType("Remote.SharedType");

                RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,
                "RemoteService", WellKnownObjectMode.SingleCall);

                Console.WriteLine("Press ENTER to quitnn");
                Console.ReadLine();
            } catch { }
        }
    }

    
}
