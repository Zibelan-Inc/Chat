using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic.CompilerServices;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Chat
{
    public sealed class NativeMethods
    {
        public static readonly ContentAlignment AnyRightAlign = (ContentAlignment)1092;
        public static readonly ContentAlignment AnyLeftAlign = (ContentAlignment)273;
        public static readonly ContentAlignment AnyTopAlign = (ContentAlignment)7;
        public static readonly ContentAlignment AnyBottomAlign = (ContentAlignment)1792;
        public static readonly ContentAlignment AnyMiddleAlign = (ContentAlignment)112;
        public static readonly ContentAlignment AnyCenterAlign = (ContentAlignment)546;
        public const int WM_GETTABRECT = 4874;
        public const int WS_EX_TRANSPARENT = 32;
        public const int WM_SETFONT = 48;
        public const int WM_FONTCHANGE = 29;
        public const int WM_HSCROLL = 276;
        public const int TCM_HITTEST = 4877;
        public const int WM_PAINT = 15;
        public const int WS_EX_LAYOUTRTL = 4194304;
        public const int WS_EX_NOINHERITLAYOUT = 1048576;
        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

        private const string USER = "user32.dll";

        private const string GDI = "gdi32.dll";

        public const string DWMAPI = "dwmapi.dll";

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, IntPtr pptDst, ref Size psize, IntPtr hdcSrc, IntPtr pprSrc, int crKey, IntPtr pblend, int dwFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool TrackPopupMenuEx(IntPtr hMenu, uint uFlags, int x, int y, IntPtr hWnd, IntPtr tpmParams);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);



        private NativeMethods()
        {
        }

        public static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            Control control = Control.FromHandle(hWnd);
            if (control == null)
            {
                return IntPtr.Zero;
            }
            System.Windows.Forms.Message message = default(System.Windows.Forms.Message);
            message.HWnd = hWnd;
            message.LParam = lParam;
            message.WParam = wParam;
            message.Msg = msg;
            MethodInfo method = control.GetType().GetMethod("WndProc", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod);
            object[] array = new object[1]
            {
            message
            };
            method.Invoke(control, array);
            object obj = array[0];
            return ((obj != null) ? ((System.Windows.Forms.Message)obj) : default(System.Windows.Forms.Message)).Result;

        }

        public static int LoWord(IntPtr dWord)
        {
            return dWord.ToInt32() & (int)ushort.MaxValue;
        }

        public static int HiWord(IntPtr dWord)
        {
            return ((long)dWord.ToInt32() & 2147483648L) != 2147483648L ? dWord.ToInt32() >> 16 & (int)ushort.MaxValue : dWord.ToInt32() >> 16;
        }

        public static IntPtr ToIntPtr(object structure)
        {
            IntPtr num = IntPtr.Zero;
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(RuntimeHelpers.GetObjectValue(structure)));
            Marshal.StructureToPtr(RuntimeHelpers.GetObjectValue(structure), ptr, false);
            return ptr;
        }

        [Flags]
        public enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMLABEL | TCHT_ONITEMICON,
        }

        public struct TCHITTESTINFO
        {
            public Point pt;
            public TCHITTESTFLAGS flags;

            public TCHITTESTINFO(Point location)
            {
                this = new TCHITTESTINFO();
                this.pt = location;
                this.flags = TCHITTESTFLAGS.TCHT_ONITEM;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public int fErase;
            public RECT rcPaint;
            public int fRestore;
            public int fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public Size Size
            {
                get
                {
                    return new Size(checked(this.right - this.left), checked(this.bottom - this.top));
                }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this = new RECT();
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(Rectangle r)
            {
                this = new RECT();
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, checked(x + width), checked(y + height));
            }

            public static RECT FromIntPtr(IntPtr ptr)
            {
                object obj = Marshal.PtrToStructure(ptr, typeof(RECT));
                if (obj == null)
                    return new RECT();
                return (RECT)obj;
            }
        }
    }
    internal sealed class ThemedColors
    {
        private const string NormalColor = "NormalColor";
        private const string HomeStead = "HomeStead";
        private const string Metallic = "Metallic";
        private const string NoTheme = "NoTheme";
        private static Color[] _toolBorder;

        public static ColorScheme CurrentThemeIndex
        {
            get
            {
                return GetCurrentThemeIndex();
            }
        }

        public static Color ToolBorder
        {
            get
            {
                return _toolBorder[(int)CurrentThemeIndex];
            }
        }

        static ThemedColors()
        {
            Color[] colorArray = new Color[4];
            int index1 = 0;
            Color color1 = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            colorArray[index1] = color1;
            int index2 = 1;
            Color color2 = Color.FromArgb(164, 185, (int)sbyte.MaxValue);
            colorArray[index2] = color2;
            int index3 = 2;
            Color color3 = Color.FromArgb(165, 172, 178);
            colorArray[index3] = color3;
            int index4 = 3;
            Color color4 = Color.FromArgb(132, 130, 132);
            colorArray[index4] = color4;
            _toolBorder = colorArray;
        }

        private ThemedColors()
        {
        }

        private static ColorScheme GetCurrentThemeIndex()
        {
            ColorScheme colorScheme1 = ColorScheme.NoTheme;
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
            {
                string colorScheme2 = VisualStyleInformation.ColorScheme;
                colorScheme1 = Operators.CompareString(colorScheme2, "NormalColor", false) == 0 ? ColorScheme.NormalColor : (Operators.CompareString(colorScheme2, "HomeStead", false) == 0 ? ColorScheme.HomeStead : (Operators.CompareString(colorScheme2, "Metallic", false) == 0 ? ColorScheme.Metallic : ColorScheme.NoTheme));
            }
            return colorScheme1;
        }

        public enum ColorScheme
        {
            NormalColor,
            HomeStead,
            Metallic,
            NoTheme,
        }
    }

}
