using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chat
{
    class UpdateManager
    {
        private static ArrayList nSockets;
        private static UpdateManager updateManager = new UpdateManager();
        private static Socket handlerSocket;
        private static string Directorio;



        public static void RunServer()
        {
            nSockets = new ArrayList();
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();

        }

        public static void Update(string ip)
        {
            string filename = string.Empty;

            if (!File.Exists(Path.Combine(Modcommon.GetSystemDrive(), "KosmoChat", "kosmochat.zip")))
                return;

            filename = Path.Combine(Modcommon.GetSystemDrive(), "KosmoChat", "kosmochat.zip");

            Send(filename, ip);
        }

        private static TcpClient clientSocket;
        static Stream fileStream;
        private static int thisRead;

        public static async void Send(string filename, string ip)
        {
            //El nombre va filename*typemessage*user
            try
            {
                // Open a TCP/IP Connection and send the data
                clientSocket = new TcpClient(ip, 8580);
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
                return;
            }

            FileInfo file = new FileInfo(filename);
            try
            {
                fileStream = File.OpenRead(filename);
            }
            catch { return; }

            // Alocate memory space for the file
            byte[] fileBuffer = new byte[fileStream.Length];
            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);


            NetworkStream networkStream = clientSocket.GetStream();
            { // This syntax sugar is awesome
                byte[] fileName = Encoding.ASCII.GetBytes(Modcommon.VerificarCaracteres(file.Name));
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await networkStream.WriteAsync(fileLength, 0, fileLength.Length);
                await networkStream.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await networkStream.WriteAsync(fileName, 0, fileName.Length);
            }

            networkStream.Write(fileBuffer, 0, fileBuffer.GetLength(0));

            networkStream.Close();

            //if (Directory.Exists(Path.Combine(Modcommon.GetSystemDrive(), "KosmoChat")))
            //    Directory.Delete(Path.Combine(Modcommon.GetSystemDrive(), "KosmoChat"), true);

            return;
        }


        static TcpListener tcpListener;
        private static void listenerThread()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            IPAddress ipaddress = null;
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddress = item;
                }
            }

            tcpListener = new TcpListener(ipaddress, 8580);
            tcpListener.Start();
            while (true)
            {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lock (updateManager)
                    {
                        nSockets.Add(handlerSocket);
                    }
                    ThreadStart thdstHandler = new
                    ThreadStart(handlerThread);
                    Thread thdHandler = new Thread(thdstHandler);
                    thdHandler.Start();
                }
            }
        }
        private static async void handlerThread()
        {
            handlerSocket = (Socket)nSockets[nSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);

            int blockSize = 1024;
            Byte[] dataByte = new Byte[blockSize];

            string fileName = "";
            try
            {
                {
                    byte[] fileNameBytes;
                    byte[] fileNameLengthBytes = new byte[4]; //int32
                    byte[] fileLengthBytes = new byte[8]; //int64


                    await networkStream.ReadAsync(fileLengthBytes, 0, 8); // int64
                    await networkStream.ReadAsync(fileNameLengthBytes, 0, 4); // int32
                    fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                    await networkStream.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);

                    fileName = Encoding.ASCII.GetString(fileNameBytes);
                }
            }
            catch { return; }

            Directorio = Modcommon.GetSystemDrive();

            lock (updateManager)
            {
                // Only one process can access
                // the same file at any given time
                try
                {
                    fileStream = File.OpenWrite(Directorio + "//" + fileName);
                }
                catch (Exception ex)
                {
                    WriteLog.Show(ex);             
                }
                while (true)
                {
                    thisRead = networkStream.Read(dataByte, 0, blockSize);
                    fileStream.Write(dataByte, 0, thisRead);
                    if (thisRead == 0) break;

                }
                fileStream.Close();
                fileStream.Dispose();
            }
            handlerSocket = null;

            try
            {
                Process.Start(Path.Combine(Modcommon.GetPatch(), "update.exe"));
                Process.GetCurrentProcess().Kill();
            }
            catch
            {
                return;
            }



        }

        internal static void StopServer()
        {
            tcpListener.Stop();
        }
    }
}
