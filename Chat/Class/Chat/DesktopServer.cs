using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chat;

namespace Chat
{
    class DesktopServer
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_KEYDOWN = 0;


        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        const MouseButtons MOUSE_LEFT = MouseButtons.Left;
        const MouseButtons MOUSE_RIGHT = MouseButtons.Right;

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;
        ///////////////////////////////////////////////////////////////////////////


        frmViewScreen viewScreenForm;
        TcpListener server;
        TcpClient remoteServer;
        NetworkStream ns, nsRemoteServer;
        Thread listenForConnectThread, castScreenThread, listenForControlThread;
        Thread connectToRemoteThread, remoteScreenThread, cancelRemoteScreenThread;

        int connectStatus = 2;

        private frmMain llamante;
        public DesktopServer(frmMain remitente) { this.llamante = remitente; }

        
        //private ControlarPC control;
        //public DesktopServer(ControlarPC remit) { this.control = remit; }

        public void Load()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            IPAddress ipaddress = null;
            //int i = 0;
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddress = item;
                    break;
                }
            }

  //          llamante.txtYourPassword.Text = RandomPassword();
  //          llamante.controlPass.Text = RandomPassword();

            Thread listenForConnectThread = new Thread(ListenForConnect);
            listenForConnectThread.IsBackground = true;
            listenForConnectThread.Start();
        }
        public string RandomPassword()
        {
            Random r = new Random();
            return r.Next(1010, 9999).ToString();
        }

        private void ListenForConnect()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 4005);
                server.Start();
                byte[] bytes = new byte[1024];


                TcpClient client = server.AcceptTcpClient();
                ns = client.GetStream();
                int length = ns.Read(bytes, 0, bytes.Length);
                string message = Encoding.ASCII.GetString(bytes, 0, length);


                /*
                if (message != "password:" + llamante.txtYourPassword.Text)
                {
                    //MessageBox.Show(llamante, "Ha introducido una contraseña incorrecta, vuelva a intentarlo", "Solicitud denegada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    sendMessage("Incorrect Password");
                    Thread.Sleep(50);
                    if (ns != null) ns.Close();
                    if (client != null) client.Close();
                    llamante.txtYourPassword.Text = RandomPassword();
                    llamante.controlPass.Text = RandomPassword();
                    ReListenConnect();
                    return;
                }


                */

                IPEndPoint clientInfo = (IPEndPoint)client.Client.RemoteEndPoint;
                DialogResult result = MessageBox.Show(llamante, $"Estan intentando controlar tu PC desde el IP {clientInfo.Address}", "Solicitud de conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);


                if (result == DialogResult.No)
                {
                    //MessageBox.Show(llamante, "Permiso denegado\nNo puedes controlar esa PC", "Solicitud denegada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    String permisstinDenied = "Permission Denied\nCan't connect to this PC";
                    sendMessage(permisstinDenied);
                    Thread.Sleep(50);
                    if (ns != null) ns.Close();
                    if (client != null) client.Close();
                    ReListenConnect();
 //                   llamante.txtYourPassword.Text = RandomPassword();
 //                   llamante.controlPass.Text = RandomPassword();
                    return;
                }

                connectStatus = 1;

                int resolutionWidth = Screen.PrimaryScreen.Bounds.Width;
                int resolutionHeight = Screen.PrimaryScreen.Bounds.Height;
                sendMessage("Resolution:" + resolutionWidth + ":" + resolutionHeight);



                castScreenThread = new Thread(CastScreen);
                castScreenThread.IsBackground = true;
                castScreenThread.Start(client);

                listenForControlThread = new Thread(ListenForControl);
                listenForControlThread.IsBackground = true;
                listenForControlThread.Start();
            }
            catch { return; }
        }

        private void ReListenConnect()
        {
            if (server != null) server.Stop();
            listenForConnectThread = new Thread(ListenForConnect);
            listenForConnectThread.IsBackground = true;
            listenForConnectThread.Start();
        }

        private void CastScreen(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            while (connectStatus == 1)
            {
                try
                {
                    Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                    Graphics gp = Graphics.FromImage(bmp);
                    gp.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(ns, bmp);
                    Thread.Sleep(50);
                    gp.Dispose();
                    bmp.Dispose();
                }
                catch { break; }
            }

            connectStatus = 2;


            ns.Close();
            if (client != null) client.Close();
            if (server != null) server.Stop();
            StopThread(ref listenForControlThread);

            ReListenConnect();
        }

        private void ListenForControl()
        {
            byte[] bytes;
            int length;
            string[] arr;
            int curPosX, curPosY;
            string key = "";
            string message = "";
            while (true)
            {
                try
                {
                    bytes = new byte[1024];
                    length = ns.Read(bytes, 0, bytes.Length);
                    message = Encoding.ASCII.GetString(bytes, 0, length);

                    arr = message.Split(':');


                    switch (arr[1])
                    {
                        case "mouse_move":
                            curPosX = Int32.Parse(arr[2]);
                            curPosY = Int32.Parse(arr[3]);
                            MoveCursor(curPosX, curPosY);
                            break;
                        case "mouse_click":
                            EventMouseClick();
                            break;
                        case "mouse_dbclick":
                            MouseDBClick();
                            break;
                        case "mouse_leftdown":
                            MouseUpDown(MOUSEEVENTF_LEFTDOWN);
                            break;
                        case "mouse_rightdown":
                            MouseUpDown(MOUSEEVENTF_RIGHTDOWN);
                            break;
                        case "mouse_middledown":
                            MouseUpDown(MOUSEEVENTF_MIDDLEDOWN);
                            break;
                        case "mouse_leftup":
                            MouseUpDown(MOUSEEVENTF_LEFTUP);
                            break;
                        case "mouse_rightup":
                            MouseUpDown(MOUSEEVENTF_RIGHTUP);
                            break;
                        case "mouse_middleup":
                            MouseUpDown(MOUSEEVENTF_MIDDLEUP);
                            break;
                        case "key_down":
                            key = arr[2];
                            EventKeyDown(key);
                            break;
                        case "key_up":
                            key = arr[2];
                            EventKeyUp(key);
                            break;
                        default: break;
                    }
                }
                catch { }
            }
        }

        private void EventKeyUp(string key)
        {
            keybd_event(Byte.Parse(key), 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        private void EventKeyDown(string key)
        {

            keybd_event(Byte.Parse(key), 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN, 0);
        }

        private void MouseUpDown(uint action)
        {
            mouse_event(action, 0, 0, 0, 0);
        }

        private void MouseDBClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void EventMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void MoveCursor(int curPosX, int curPosY)
        {
            Cursor.Position = new Point(curPosX, curPosY);
        }
        public string RemoteIP { get; set;}
        public string RemotePass { get; set; }

        private void sendMessage(string message)
        {
            ns.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            ns.Flush();
        }

        private void btnDisconnectRemote_Click(object sender, EventArgs e)
        {
            connectStatus = 2;
        }
        public void Iniciar(string ip, string pass)
        {
            if (connectStatus == 1)
            {
                return;
            }

            connectToRemoteThread = new Thread(ConnectToRemote);
            connectToRemoteThread.IsBackground = true;
            connectToRemoteThread.Start();
            RemoteIP = ip;
            RemotePass = pass;
        }

        private void ConnectToRemote()
        {
            try
            {
                IPAddress remoteIP;
                if (!IPAddress.TryParse(RemoteIP.Trim(), out remoteIP))
                {
                    AlertDanger("Invalid IPAddress");
                    return;
                }


                remoteServer = new TcpClient();
                remoteServer.Connect(RemoteIP, 4005);
                nsRemoteServer = remoteServer.GetStream();

                string remotePassword = "password:" + RemotePass.Trim();

                nsRemoteServer.Write(Encoding.ASCII.GetBytes(remotePassword), 0, remotePassword.Length);
                nsRemoteServer.Flush();

                byte[] bytes = new byte[1024];
                int length = nsRemoteServer.Read(bytes, 0, bytes.Length);
                string message = Encoding.ASCII.GetString(bytes, 0, length);

                if (message.Contains("Incorrect Password") || message.Contains("Permission Denied"))
                {
                    connectStatus = 2;
                    if (nsRemoteServer != null) nsRemoteServer.Close();
                    if (remoteServer != null) remoteServer.Close();
                    AlertDanger(message);
                    return;
                }
                else
                {
                connectStatus = 1;

                remoteScreenThread = new Thread(ViewScreen);
                remoteScreenThread.IsBackground = true;
                remoteScreenThread.Start(message);
                
                cancelRemoteScreenThread = new Thread(CancelRemoteSceen);
                cancelRemoteScreenThread.IsBackground = true;
                cancelRemoteScreenThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(llamante, ex.Message, "KosmoChat", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                connectStatus = 2;
            }
        }

        private void CancelRemoteSceen()
        {
            while (true)
            {
                if (connectStatus == 1 && remoteScreenThread != null && !remoteScreenThread.IsAlive)
                {
                    connectStatus = 2;

                    if (nsRemoteServer != null) nsRemoteServer.Close();
                    if (remoteServer != null) remoteServer.Close();
                    StopThread(ref cancelRemoteScreenThread);
                }
                Thread.Sleep(1000);
            }
        }

        private void ViewScreen(Object obj)
        {
            String resolution = (String)obj;
            viewScreenForm = new frmViewScreen(ref nsRemoteServer, resolution);
            viewScreenForm.ShowDialog();

        }
        ////////////////////////////////////////////////// SANER_CLOSE/////////////////////////////////////////////////////////
        private void StopThread(ref Thread thread)
        {
            if (thread != null && thread.IsAlive) thread.Abort();
        }

        void AlertDanger(string message)
        {
            //MessageBox.Show(control, message, "KosmoChat");
            //MessageBox.Show(message, "KosmoChat", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ns != null) ns.Close();
            if (nsRemoteServer != null) nsRemoteServer.Close();
            if (remoteServer != null) remoteServer.Close();
            if (server != null) server.Stop();
        }

    }



}

