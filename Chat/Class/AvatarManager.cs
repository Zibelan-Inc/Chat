using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chat
{
    public class AvatarManager
    {
        public static void Initialize()
        {
            IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
            nSockets = new ArrayList();
            Thread thdListener = new Thread(ListenerThread);
            thdListener.Start();
        }

        public static void AnaliceAvatar(string Id, long AvatarLength)
        {
            if (AvatarLength == 0)
                return;

            if (!File.Exists(Path.Combine(Modcommon.AVATARDIR, Id) + ".jpg"))
            {
                frmMain.frm.Transmit("GetAvatar", Id + "◄" + Modcommon.GetIp());
                return;
            }
            else
            {
                string avatar = Path.Combine(Modcommon.AVATARDIR, Id) + ".jpg";
                FileInfo file = new FileInfo(avatar);

                if (AvatarLength != file.Length)
                    frmMain.frm.Transmit("GetAvatar", Id + "◄" + Modcommon.GetIp());
            }
        }






        private static ArrayList nSockets;
        private static AvatarManager avatarManager = new AvatarManager();
        private static Socket handlerSocket;
        private static TcpClient clientSocket;


        public static async void Send(string filename, string ip)
        {
            if (!Modcommon.MyIpRange(ip))
            return;

            return;
            try
            {
                // Open a TCP/IP Connection and send the data
                clientSocket = new TcpClient(ip, 28525);
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
                return;
            }

            FileInfo file = new FileInfo(filename);
            Stream fileStream = File.OpenRead(filename);

            // Alocate memory space for the file
            byte[] fileBuffer = new byte[fileStream.Length];
            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            try
            {
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
            }
            catch { return; }
        }


        static TcpListener tcpListener;
        private static void ListenerThread()
        {

            tcpListener = new TcpListener(28525);
            tcpListener.Start();
            while (true)
            {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lock (avatarManager)
                    {
                        nSockets.Add(handlerSocket);
                    }
                    ThreadStart thdstHandler = HandlerThread;
                    Thread thdHandler = new Thread(thdstHandler);
                    thdHandler.Start();
                }
            }
        }
        private static async void HandlerThread()
        {
            handlerSocket = (Socket)nSockets[nSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            int thisRead = 0;
            int blockSize = 1024;
            Byte[] dataByte = new Byte[blockSize];

            string fileName;
            {
                try
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
                catch { return; }
            }

            try
            {
                if (!Directory.Exists(Modcommon.AVATARDIR))
                    Directory.CreateDirectory(Modcommon.AVATARDIR);
            }
            catch { }

            lock (avatarManager)
            {
                // Only one process can access
                // the same file at any given time
                Stream fileStream = null;
                try
                {
                    fileStream = File.OpenWrite(Modcommon.AVATARDIR + "//" + Modcommon.VerificarCaracteres(fileName));
                }
                catch { return; }

                while (true)
                {
                    thisRead = networkStream.Read(dataByte, 0, blockSize);
                    fileStream.Write(dataByte, 0, thisRead);
                    if (thisRead == 0) break;

                }
                fileStream.Close();
            }
            handlerSocket = null;

            int rowCount = frmMain.frm.UserList.RowCount;
            int num = checked(rowCount - 1);
            for (int i = 0; i <= num; i = checked(i + 1))
            {
                MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, i];
                if (textAndImageCell.UserName == fileName.Replace(".jpg",""))
                    textAndImageCell.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(fileName.Replace(".jpg", "")));
            }
            frmMain.frm.UserList.Refresh();
        }


        internal static void Stop()
        {
            tcpListener.Stop();
        }
    }
}
