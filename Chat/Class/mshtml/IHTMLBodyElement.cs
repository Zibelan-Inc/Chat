using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface IHTMLBodyElement
    {
        void _VtblGap1_34();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(2013)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLTxtRange createTextRange();
    }
}
