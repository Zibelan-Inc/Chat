using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLEventObj
    {
        [DispId(1001)]
        IHTMLElement srcElement
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1001)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        [DispId(1003)]
        bool ctrlKey
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1003)]
            get;
        }

        [DispId(1011)]
        int keyCode
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1011)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1011)]
            [param: In]
            set;
        }

        [DispId(1012)]
        int button
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1012)]
            get;
        }

        [DispId(1005)]
        int x
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1005)]
            get;
        }

        [DispId(1006)]
        int y
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1006)]
            get;
        }

        [DispId(1020)]
        int clientX
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1020)]
            get;
        }

        [DispId(1021)]
        int clientY
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1021)]
            get;
        }

        void _VtblGap1_1();

        void _VtblGap2_7();

        void _VtblGap3_3();
    }
}
