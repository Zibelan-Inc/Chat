using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLElement
    {
        [DispId(-2147417108)]
        string tagName
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417108)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        [DispId(-2147418104)]
        IHTMLElement parentElement
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147418104)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        [DispId(-2147417086)]
        string innerHTML
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417086)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417086)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(-2147417085)]
        string innerText
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417085)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417085)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(-2147417084)]
        string outerHTML
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417084)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(-2147417084)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        void _VtblGap1_1();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(-2147417610)]
        [return: MarshalAs(UnmanagedType.Struct)]
        object getAttribute([In] [MarshalAs(UnmanagedType.BStr)] string strAttributeName, [In] int lFlags = 0);

        void _VtblGap2_5();

        void _VtblGap3_41();
    }
}
