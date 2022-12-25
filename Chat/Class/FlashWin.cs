using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    //Hace que parpadee la ventana cuando esta inactiva
    internal class FlashWin
    {
        public static short FlashCount = (short)5;
        public const uint FlashwStop = 0U;
        public const uint FlashwCaption = 1U;
        public const uint FlashwTray = 2U;
        public const uint FlashwAll = 3U;
        public const uint FlashwTimer = 4U;
        public const uint FlashwTimernofg = 12U;
        public static bool Flag;

        private static bool Win2000OrLater
        {
            get
            {
                return Environment.OSVersion.Version.Major >= 5;
            }
        }

        private FlashWin()
        {
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public static bool Flash(IntPtr handle)
        {
            if (Win2000OrLater)
            {
                if (Modcommon.DEFAULTVIEW)
                    handle = frmMain.frm.Handle;
                FLASHWINFO flashwinfo = Create_FLASHWINFO(handle, 15U, uint.MaxValue, 0U);
                Flag = FlashWindowEx(ref flashwinfo);
            }
            else
                Flag = false;
            return Flag;
        }

        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO flashwinfo = new FLASHWINFO();
            flashwinfo.cbSize = Convert.ToUInt32(Marshal.SizeOf((object)flashwinfo));
            flashwinfo.hwnd = handle;
            flashwinfo.dwFlags = flags;
            flashwinfo.uCount = count;
            flashwinfo.dwTimeout = timeout;
            return flashwinfo;
        }

        public static bool Flash(IntPtr handle, uint count)
        {
            Start(handle);
            return true;
        }

        public static bool Start(IntPtr handle)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO flashwinfo = Create_FLASHWINFO(handle, 3U, uint.MaxValue, 0U);
                Flag = FlashWindowEx(ref flashwinfo);
            }
            else
                Flag = false;
            return Flag;
        }

        public static bool StopWin(IntPtr handle)
        {
            try
            {
                if (Modcommon.DEFAULTVIEW)
                    handle = frmMain.frm.Handle;
                Flag = Stop(handle);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return Flag;
        }

        public static bool Stop(IntPtr handle)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO flashwinfo = Create_FLASHWINFO(handle, 0U, 0U, 0U);
                Flag = FlashWindowEx(ref flashwinfo);
            }
            else
                Flag = false;
            return Flag;
        }

        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }
    }

}