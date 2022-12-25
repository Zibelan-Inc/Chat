using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mshtml;

namespace mshtml
{
    public interface IHTMLDocument2 : IHTMLDocument
    {
        [DispId(1004)]
        IHTMLElement body
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1004)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        [DispId(1012)]
        string title
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1012)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1012)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(1017)]
        IHTMLSelectionObject selection
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1017)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        void _VtblGap1_2();

        void _VtblGap2_6();

        void _VtblGap3_3();

        void _VtblGap4_48();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1065)]
        bool execCommand([In] [MarshalAs(UnmanagedType.BStr)] string cmdID, [In] bool showUI, [Optional] [In] [MarshalAs(UnmanagedType.Struct)] object value);

        void _VtblGap5_44();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1071)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLStyleSheet createStyleSheet([In] [MarshalAs(UnmanagedType.BStr)] string bstrHref = "", [In] int lIndex = -1);
    }
}
