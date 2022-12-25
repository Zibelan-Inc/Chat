using System;
using TcpComm;
using Tools;

namespace Chat.Class.RemoteFileSistem
{
    class FileSystemServer
    {
        //Servidor de Ficheros
        private Server tcpServer;
        private Utilities.LargeArrayTransferHelper lat;
        private RemoteFileSystem.Server rfsServer;
        private Int32 currentSessionId = -1;
        private bool running = false;

        public FileSystemServer()
        {
            try
            {
                String errMsg = "";
                // Initialize the TcpComm server here. Please see my atricle:
                // https://www.codeproject.com/articles/307315/reusable-multithreaded-tcp-client-and-server-class
                // for details on how to use it.
                tcpServer = new Server((Byte[] buffer, Int32 sessionId, Byte dataChannel) =>
                {
                    if (dataChannel == 100)
                    {
                        currentSessionId = sessionId;
                        string request = Utilities.BytesToString(buffer);
                        rfsServer.RequestHandler(request);
                    }
                }, 300000000);

                // We're going to be using LAT (Large Array Transfer Helper)
                lat = new Utilities.LargeArrayTransferHelper(ref tcpServer);

                // Initialize RemoteFileSystem here:
                rfsServer = new RemoteFileSystem.Server((String data) =>
                {

                    // Send data to the client here:
                    lat.SendArray(Utilities.StrToByteArray(data), 100, currentSessionId, ref errMsg);
                }, (String newPath) =>
                {
                    // Handle requests to update the TcpComm server's received files folder here:
                    var session = tcpServer.GetSession(currentSessionId);
                    if (session != null) { session.ReceivedFilesFolder = newPath; }
                });

            }
            catch { }
        }
        public void StartServer()
        {
            try
            {
                if (!running)
                {
                    String errMsg = "";
                    if (tcpServer.Start(int.Parse("22590"), ref errMsg))
                    {
                        running = true;
                    }
                }
            }
            catch { }

        }

        private void StopServer()
        {
            if (running)
            {
                try
                {
                    tcpServer.Close();
                }
                catch { }

                running = false;
            }
        }

    }
}
