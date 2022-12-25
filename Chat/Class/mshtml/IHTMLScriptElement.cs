using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLScriptElement
    {
        [DispId(1006)]
        string text
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1006)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            [DispId(1006)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        void _VtblGap1_6();
    }
}
