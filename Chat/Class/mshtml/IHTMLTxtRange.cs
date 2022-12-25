using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLTxtRange
    {
        [DispId(1003)]
        string htmlText
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        [DispId(1004)]
        string text
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1004)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1004)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1006)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLElement parentElement();

        void _VtblGap1_3();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1012)]
        void scrollIntoView([In] bool fStart = true);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1013)]
        void collapse([In] bool Start = true);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1014)]
        bool expand([In] [MarshalAs(UnmanagedType.BStr)] string Unit);

        void _VtblGap2_1();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1016)]
        int moveStart([In] [MarshalAs(UnmanagedType.BStr)] string Unit, [In] int Count = 1);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1017)]
        int moveEnd([In] [MarshalAs(UnmanagedType.BStr)] string Unit, [In] int Count = 1);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1024)]
        void select();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1026)]
        void pasteHTML([In] [MarshalAs(UnmanagedType.BStr)] string html);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1001)]
        void moveToElementText([In] [MarshalAs(UnmanagedType.Interface)] IHTMLElement element);

        void _VtblGap3_2();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1019)]
        bool findText([In] [MarshalAs(UnmanagedType.BStr)] string String, [In] int Count = 1073741823, [In] int Flags = 0);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1020)]
        void moveToPoint([In] int x, [In] int y);
    }
}
