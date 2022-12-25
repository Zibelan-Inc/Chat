using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chat;
using Chat.Properties;

namespace Transfer
{
    public class FileTransfer
    {
        private static ArrayList nSockets;
        private static FileTransfer fileTransfer = new FileTransfer();
        private static Socket handlerSocket;
        private static string Directorio;
        private static bool update;
        private static string screen;
        public static Client cliente { get; set; }
        private static Messages messages;


        public static bool Screenshots { get; private set; }
        private static string lastScreen { get; set; } = "last";
        public static void RunServer()
        {
            nSockets = new ArrayList();
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();
            cliente = new Client();
            cliente.MessageReceived += new EventHandler<MessageEventArgs>(frmMain.frm.client_MessageReceived);
            messages = new Messages();
            messages.MessageQueued += new EventHandler(frmMain.frm.Messages_MessageQueued);

        }

        public static void Iniciar(string ip)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Send(ofd.FileName, "*FileTransfer*" + frmMain.NickName, ip);
            }
        }
        public static bool Dragging { get; private set; }

        public static void Update(string ip)
        {
            string filename = string.Empty;

            if (File.Exists(Path.Combine(Modcommon.TEMP_PATH, "KosmoChat", "KosmoChat.exe")))
                File.Delete(Path.Combine(Modcommon.TEMP_PATH, "KosmoChat", "KosmoChat.exe"));

            if (!File.Exists(Path.Combine(Modcommon.TEMP_PATH, "KosmoChat", "KosmoChat.zip")))
                return;

            filename = Path.Combine(Modcommon.TEMP_PATH, "KosmoChat", "KosmoChat.zip");

            Send(filename, "*Update*" + frmMain.NickName, ip);
        }

        private static TcpClient clientSocket;
        static Stream fileStream;
        public static async void Send(string filename, string user = "", string ip = "")
        {
            //El nombre va filename*typemessage*user
            try
            {
                // Open a TCP/IP Connection and send the data
                clientSocket = new TcpClient(ip, 8282);
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
                byte[] fileName = Encoding.ASCII.GetBytes(Modcommon.VerificarCaracteres(file.Name + user));
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await networkStream.WriteAsync(fileLength, 0, fileLength.Length);
                await networkStream.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await networkStream.WriteAsync(fileName, 0, fileName.Length);
            }

            networkStream.Write(fileBuffer, 0, fileBuffer.GetLength(0));

            networkStream.Close();

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

            tcpListener = new TcpListener(ipaddress, 8282);
            tcpListener.Start();
            while (true)
            {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lock (fileTransfer)
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
            Screenshots = false;
            update = false;
            Dragging = false;

            handlerSocket = (Socket)nSockets[nSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            int thisRead = 0;
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
            } catch { return; }

            string[] stringData = fileName.Split('*');
            fileName = stringData[0];
            string TypeMessage = stringData[1];
            string NickName = stringData[2];


            if (TypeMessage.ToLower() == "screenshot")
            {
                Directorio = Path.Combine(Modcommon.TEMP_PATH, "Screenshots");
                screen = Path.Combine(Modcommon.TEMP_PATH, "Screenshots", fileName);
                Screenshots = true;
            }
            else if (TypeMessage.ToLower() == "update")
            {
                if (Modcommon.ReadyUpdate())
                {
                    Directorio = Path.Combine(Modcommon.TEMP_PATH, "KosmoChat");
                    update = true;
                }
                
            }
            else if (TypeMessage.ToLower().Contains("drag"))
            {
                Directorio = Modcommon.TEMP_PATH;
                screen = Path.Combine(Modcommon.TEMP_PATH, fileName);
                Dragging = true;
            }
            else
                Directorio = frmMain.DirBox;


            try
            {
                if (!Directory.Exists(frmMain.DirBox))
                    Directory.CreateDirectory(frmMain.DirBox);
            }
            catch { }

            lock (fileTransfer)
            {
                // Only one process can access
                // the same file at any given time
                try
                {
                    fileName = Modcommon.VerificarCaracteres(fileName);

                    fileStream = File.OpenWrite(Directorio + "//" + fileName);
                }
                catch (Exception ex)
                {
                    frmMain.frm.Transmit("log", ex.Message);
                    fileName = "File_" + Modcommon.GetUniqueAlphaNumericID() + Path.GetExtension(fileName);
                    fileStream = File.OpenWrite(Directorio + "//" + fileName);
                }
                while (true)
                {
                    thisRead = networkStream.Read(dataByte, 0, blockSize);
                    fileStream.Write(dataByte, 0, thisRead);
                    if (thisRead == 0) break;

                }
                fileStream.Close();
            }
            handlerSocket = null;

            if (update)
            {
                try
                {
                    Process.Start(Path.Combine(Modcommon.GetPatch(), "update.exe"));
                }
                catch
                {
                    update = false;
                    return;
                }
                update = false;
                return;

            }

            if (Screenshots)
            {
                try
                {
                    string json = ("{'Handle':'" + NickName + "','typeMessage':'ScreenShot','content':'" + fileName + "','UserSelectedColor':" + HtmlHelper.GetSelectedColorThroughName(NickName) + "}").Replace("'", "\"");
                    cliente.OnMessageRecieved(new MessageEventArgs(json));
                }
                catch
                {
                    Screenshots = false;
                    return;
                }
                Screenshots = false;
                return;
            }

            if (Dragging)
            {
                try
                {

                    string json = ("{'Handle':'" + NickName + "','typeMessage':'Drag','content':'" + fileName + "','UserSelectedColor':" + HtmlHelper.GetSelectedColorThroughName(NickName) + "}").Replace("'", "\"");
                    cliente.OnMessageRecieved(new MessageEventArgs(json));


                }
                catch
                {
                    Dragging = false;
                    return;
                }
                Dragging = false;
                return;
            }


            SoundPlayer file = new SoundPlayer(Resources.message_high);
            file.Play();

            if (frmMain.AbrirArchivo)
                Process.Start(frmMain.DirBox + @"\" + fileName);
            if (frmMain.AbrirCarpeta)
                Process.Start(frmMain.DirBox);

            if (frmMain.AchivoRecibido)
            {
                frmMain.frm.Notificar(NickName + " te ha enviado un archivo", NickName);
            }

        }

        public static void SendMessage(string message)
        {
            string json = ("{'Handle':'" + "Hackerprod" + "','typeMessage':'Test','content':'" + message + "','UserSelectedColor':" + "0");
            cliente.OnMessageRecieved(new MessageEventArgs(json));

        }

        internal static void StopServer()
        {
            tcpListener.Stop();
        }
    }
}
