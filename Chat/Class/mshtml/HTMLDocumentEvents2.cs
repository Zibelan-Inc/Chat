using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface HTMLDocumentEvents2
    {
        void _VtblGap1_1();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-600)]
        bool onclick([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-601)]
        bool ondblclick([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        void _VtblGap2_1();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-604)]
        void onkeyup([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-603)]
        bool onkeypress([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-605)]
        void onmousedown([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        void _VtblGap3_9();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(-2147418101)]
        bool ondragstart([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        void _VtblGap4_12();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1037)]
        void onselectionchange([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }
}
