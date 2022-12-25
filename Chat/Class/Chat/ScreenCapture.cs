// Decompiled with JetBrains decompiler
// Type: ScreenCapture
// Assembly: ScreenCapture, Version=1.0.5951.27584, Culture=neutral, PublicKeyToken=null
// MVID: FB0D1CD2-E90D-406B-936F-7E741BBC9C6B
// Assembly location: D:\Instaladores\Programación\Projects\TINserverlauncher\TINserverlauncher\bin\x86\Debug\ScreenCapture.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace Chat
{
    public class ScreenCapture : MarshalByRefObject
    {
        private const int SRCCOPY = 13369376;
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const uint MOUSEEVENTF_MOVE = 1U;
        private const uint MOUSEEVENTF_LEFTDOWN = 2U;
        private const uint MOUSEEVENTF_LEFTUP = 4U;
        private const uint MOUSEEVENTF_RIGHTDOWN = 8U;
        private const uint MOUSEEVENTF_RIGHTUP = 16U;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 32U;
        private const uint MOUSEEVENTF_MIDDLEUP = 64U;
        private const uint MOUSEEVENTF_WHEEL = 2048U;
        private const uint MOUSEEVENTF_ABSOLUTE = 32768U;
        private const uint KEYEVENTF_EXTENDEDKEY = 1U;
        private const uint KEYEVENTF_KEYUP = 2U;
        private const uint INPUT_MOUSE = 0U;
        private const uint INPUT_KEYBOARD = 1U;

        public bool sendMessage { get; set; }

        public bool soundStat { get; set; }

        public bool con_stat { get; set; }

        public string sndmsg { get; set; }

        public string sndmsg1 { get; set; }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        public Size GetDesktopBitmapSize()
        {
            return new Size(GetSystemMetrics(0), GetSystemMetrics(1));
        }

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, ref INPUT input, int cbSize);

        public void PressOrReleaseMouseButton(bool Press, bool Left, int X, int Y)
        {
            INPUT input = new INPUT();
            input.type = 0U;
            input.mi.dx = (uint)X;
            input.mi.dy = (uint)Y;
            input.mi.mouseData = 0U;
            input.mi.dwFlags = 0U;
            input.mi.time = 0U;
            input.mi.dwExtraInfo = 0U;
            input.mi.dwFlags = !Left ? (Press ? 8U : 16U) : (Press ? 2U : 4U);
            int num = (int)SendInput(1U, ref input, Marshal.SizeOf((object)input));
        }

        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);

        public void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public void SendKeystroke(byte VirtualKeyCode, byte ScanCode, bool KeyDown, bool ExtendedKey)
        {
            INPUT input = new INPUT();
            input.type = 1U;
            input.ki.wVk = (ushort)VirtualKeyCode;
            input.ki.wScan = (ushort)ScanCode;
            input.ki.dwExtraInfo = 0U;
            input.ki.time = 0U;
            if (!KeyDown)
                input.ki.dwFlags |= 2U;
            if (ExtendedKey)
                input.ki.dwFlags |= 1U;
            int num = (int)SendInput(1U, ref input, Marshal.SizeOf((object)input));
        }

        public byte[] GetDesktopBitmapBytes()
        {
            Size desktopBitmapSize = this.GetDesktopBitmapSize();
            Graphics g1 = Graphics.FromHwnd(GetDesktopWindow());
            Bitmap bitmap = new Bitmap(desktopBitmapSize.Width, desktopBitmapSize.Height, g1);
            Graphics graphics1 = Graphics.FromImage((Image)bitmap);
            IntPtr hdc1 = g1.GetHdc();
            IntPtr hdc2 = graphics1.GetHdc();
            BitBlt(hdc2, 0, 0, desktopBitmapSize.Width, desktopBitmapSize.Height, hdc1, 0, 0, 13369376);
            g1.ReleaseHdc(hdc1);
            graphics1.ReleaseHdc(hdc2);
            g1.Dispose();
            graphics1.Dispose();
            Graphics graphics2 = Graphics.FromImage((Image)bitmap);
            Cursor arrow = Cursors.Arrow;
            Cursor cursor = arrow;
            Graphics g2 = graphics2;
            Point position = Cursor.Position;
            int x = position.X - 10;
            position = Cursor.Position;
            int y = position.Y - 10;
            Size size = arrow.Size;
            int width = size.Width;
            size = arrow.Size;
            int height = size.Height;
            Rectangle targetRect = new Rectangle(x, y, width, height);
            cursor.Draw(g2, targetRect);
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save((Stream)memoryStream, ImageFormat.Jpeg);
            return memoryStream.GetBuffer();
        }

        private struct MOUSE_INPUT
        {
            public uint dx;
            public uint dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public uint dwExtraInfo;
        }

        private struct KEYBD_INPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public uint dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public uint type;
            [FieldOffset(4)]
            public MOUSE_INPUT mi;
            [FieldOffset(4)]
            public KEYBD_INPUT ki;
        }
    }
    public class ScreenCaptureInit
    {
        static ScreenCapture obj;
        static TcpChannel chan;
        static string URI;
        static byte[] buffer { get; set; }
        //Form Styles Variables
        public static void Connect(string ip)
        {
            try
            {
                URI = "Tcp://" + ip + ":7600/MyCaptureScreenServer";
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan, false);
                obj = (ScreenCapture)Activator.GetObject(typeof(ScreenCapture), URI);

                RemoteDesktop Remotedesktop = new RemoteDesktop(true, obj, URI, chan);
                Remotedesktop.Show();
                Remotedesktop.Closed += delegate
                {
                    //ShowInTaskbar = true;
                    //WindowState = FormWindowState.Normal;
                };
                //WindowState = FormWindowState.Minimized;
                //ShowInTaskbar = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}


