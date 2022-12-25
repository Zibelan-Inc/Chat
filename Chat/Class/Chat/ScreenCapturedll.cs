using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chat.ScreenCap
{
    public class ScreenCapture : MarshalByRefObject
    {
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

        private const int SRCCOPY = 13369376;

        private const int SM_CXSCREEN = 0;

        private const int SM_CYSCREEN = 1;

        private const uint MOUSEEVENTF_MOVE = 1u;

        private const uint MOUSEEVENTF_LEFTDOWN = 2u;

        private const uint MOUSEEVENTF_LEFTUP = 4u;

        private const uint MOUSEEVENTF_RIGHTDOWN = 8u;

        private const uint MOUSEEVENTF_RIGHTUP = 16u;

        private const uint MOUSEEVENTF_MIDDLEDOWN = 32u;

        private const uint MOUSEEVENTF_MIDDLEUP = 64u;

        private const uint MOUSEEVENTF_WHEEL = 2048u;

        private const uint MOUSEEVENTF_ABSOLUTE = 32768u;

        private const uint KEYEVENTF_EXTENDEDKEY = 1u;

        private const uint KEYEVENTF_KEYUP = 2u;

        private const uint INPUT_MOUSE = 0u;

        private const uint INPUT_KEYBOARD = 1u;

        public bool sendMessage
        {
            get;
            set;
        }

        public bool soundStat
        {
            get;
            set;
        }

        public bool con_stat
        {
            get;
            set;
        }

        public string sndmsg
        {
            get;
            set;
        }

        public string sndmsg1
        {
            get;
            set;
        }

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
            INPUT input = default(INPUT);
            input.type = 0u;
            input.mi.dx = (uint)X;
            input.mi.dy = (uint)Y;
            input.mi.mouseData = 0u;
            input.mi.dwFlags = 0u;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = 0u;
            if (Left)
            {
                input.mi.dwFlags = (uint)(Press ? 2 : 4);
            }
            else
            {
                input.mi.dwFlags = (uint)(Press ? 8 : 16);
            }
            SendInput(1u, ref input, Marshal.SizeOf((object)input));
        }

        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);

        public void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public void SendKeystroke(byte VirtualKeyCode, byte ScanCode, bool KeyDown, bool ExtendedKey)
        {
            INPUT input = default(INPUT);
            input.type = 1u;
            input.ki.wVk = VirtualKeyCode;
            input.ki.wScan = ScanCode;
            input.ki.dwExtraInfo = 0u;
            input.ki.time = 0u;
            if (!KeyDown)
            {
                input.ki.dwFlags |= 2u;
            }
            if (ExtendedKey)
            {
                input.ki.dwFlags |= 1u;
            }
            SendInput(1u, ref input, Marshal.SizeOf((object)input));
        }

        public byte[] GetDesktopBitmapBytes()
        {
            Size desktopBitmapSize = GetDesktopBitmapSize();
            Graphics graphics = Graphics.FromHwnd(GetDesktopWindow());
            Bitmap bitmap = new Bitmap(desktopBitmapSize.Width, desktopBitmapSize.Height, graphics);
            Graphics graphics2 = Graphics.FromImage(bitmap);
            IntPtr hdc = graphics.GetHdc();
            IntPtr hdc2 = graphics2.GetHdc();
            BitBlt(hdc2, 0, 0, desktopBitmapSize.Width, desktopBitmapSize.Height, hdc, 0, 0, 13369376);
            graphics.ReleaseHdc(hdc);
            graphics2.ReleaseHdc(hdc2);
            graphics.Dispose();
            graphics2.Dispose();
            Graphics g = Graphics.FromImage(bitmap);
            Cursor arrow = Cursors.Arrow;
            arrow.Draw(g, new Rectangle(Cursor.Position.X - 10, Cursor.Position.Y - 10, arrow.Size.Width, arrow.Size.Height));
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.GetBuffer();
        }
    }
}