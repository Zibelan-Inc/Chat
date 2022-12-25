using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mshtml
{
    public interface HTMLDocumentEvents2_Event
    {
        event HTMLDocumentEvents2_onclickEventHandler onclick;

        event HTMLDocumentEvents2_ondblclickEventHandler ondblclick;

        event HTMLDocumentEvents2_onkeyupEventHandler onkeyup;

        event HTMLDocumentEvents2_onkeypressEventHandler onkeypress;

        event HTMLDocumentEvents2_onmousedownEventHandler onmousedown;

        event HTMLDocumentEvents2_ondragstartEventHandler ondragstart;

        event HTMLDocumentEvents2_onselectionchangeEventHandler onselectionchange;

        void _VtblGap1_2();

        void _VtblGap2_2();

        void _VtblGap3_18();

        void _VtblGap4_24();
    }
    public delegate bool HTMLDocumentEvents2_onclickEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate bool HTMLDocumentEvents2_ondblclickEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate bool HTMLDocumentEvents2_ondragstartEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate bool HTMLDocumentEvents2_onkeypressEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate void HTMLDocumentEvents2_onkeyupEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate void HTMLDocumentEvents2_onmousedownEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    public delegate void HTMLDocumentEvents2_onselectionchangeEventHandler([In] [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

}
