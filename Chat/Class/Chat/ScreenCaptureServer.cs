using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Chat.Class
{
    class ScreenCaptureServer
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public ScreenCaptureServer()
        {
            string URI;

            try
            {
                ScreenCapture obj;
                string ipget = "127.0.0.1";
                URI = "Tcp://" + ipget + ":7600/MyCaptureScreenServer";
                TcpChannel chan = new TcpChannel(7600);
                ChannelServices.RegisterChannel(chan, false);
                RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("ScreenCapture, ScreenCapture"), "MyCaptureScreenServer", WellKnownObjectMode.Singleton);
                obj = (ScreenCapture)Activator.GetObject(typeof(ScreenCapture), URI);
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
    }
}
