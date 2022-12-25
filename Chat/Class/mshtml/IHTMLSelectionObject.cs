using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLSelectionObject
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1001)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object createRange();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(1002)]
        void empty();
    }
}
