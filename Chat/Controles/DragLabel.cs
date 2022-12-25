using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat;
using Chat.Forms;
using Message = System.Windows.Forms.Message;

public class DragLabel : Label
{
    public delegate void OnDefWndProcEventHandler(Message msg);

    private const int WM_NCLBUTTONDOWN = 161;

    private const int HTBORDER = 18;

    private const int HTBOTTOM = 15;

    private const int HTBOTTOMLEFT = 16;

    private const int HTBOTTOMRIGHT = 17;

    private const int HTCAPTION = 2;

    private const int HTCLOSE = 20;

    private const int HTGROWBOX = 4;

    private const int HTLEFT = 10;

    private const int HTMAXBUTTON = 9;

    private const int HTMINBUTTON = 8;

    private const int HTRIGHT = 11;

    private const int HTSYSMENU = 3;

    private const int HTTOP = 12;

    private const int HTTOPLEFT = 13;

    private const int HTTOPRIGHT = 14;

    private const int WS_MINIMIZEBOX = 131072;

    private const int CS_DBLCLKS = 8;

    private string clipboardText { get; set; }

    public bool CopyTextOnDoubleClick { get; set; }

    private frmResize _form;
    private frmBorder form;

    [CompilerGenerated]
    private OnDefWndProcEventHandler OnDefWndProcEvent;

    [Category("Appearance")]
    [RefreshProperties(RefreshProperties.All)]
    public frmResize ContainerForm
    {
        get
        {
            return _form;
        }
        set
        {
            _form = value;
        }
    }
    public frmBorder ContainerFrm
    {
        get
        {
            return form;
        }
        set
        {
            form = value;
        }
    }


    public event OnDefWndProcEventHandler OnDefWndProc
    {
        [CompilerGenerated]
        add
        {
            OnDefWndProcEventHandler onDefWndProcEventHandler = OnDefWndProcEvent;
            OnDefWndProcEventHandler onDefWndProcEventHandler2;
            do
            {
                onDefWndProcEventHandler2 = onDefWndProcEventHandler;
                OnDefWndProcEventHandler value2 = (OnDefWndProcEventHandler)Delegate.Combine(onDefWndProcEventHandler2, value);
                onDefWndProcEventHandler = Interlocked.CompareExchange(ref OnDefWndProcEvent, value2, onDefWndProcEventHandler2);
            }
            while ((object)onDefWndProcEventHandler != onDefWndProcEventHandler2);
        }
        [CompilerGenerated]
        remove
        {
            OnDefWndProcEventHandler onDefWndProcEventHandler = OnDefWndProcEvent;
            OnDefWndProcEventHandler onDefWndProcEventHandler2;
            do
            {
                onDefWndProcEventHandler2 = onDefWndProcEventHandler;
                OnDefWndProcEventHandler value2 = (OnDefWndProcEventHandler)Delegate.Remove(onDefWndProcEventHandler2, value);
                onDefWndProcEventHandler = Interlocked.CompareExchange(ref OnDefWndProcEvent, value2, onDefWndProcEventHandler2);
            }
            while ((object)onDefWndProcEventHandler != onDefWndProcEventHandler2);
        }
    }

    public DragLabel()
    {
        base.MouseDown += DragLabel_MouseDown;
        base.MouseMove += DragLabel_MouseMove;
    }

    private void DragLabel_MouseDown(object sender, MouseEventArgs e)
    {
        Cursor = Cursors.SizeAll;
    }

    private void DragLabel_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (e.Button == MouseButtons.Left)
            {
                base.Capture = false;
                Application.DoEvents();
                Message msg = Message.Create(_form.Handle, 161, new IntPtr(2), IntPtr.Zero);
            }
            if (Cursor != Cursors.SizeAll)
            {
                Cursor = Cursors.SizeAll;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            ProjectData.ClearProjectError();
        }
    }
    protected override void WndProc(ref Message m)
    {
        if (!this.CopyTextOnDoubleClick && m.Msg == 515)
        {
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.Text))
                this.clipboardText = Conversions.ToString(dataObject.GetData(DataFormats.Text));
        }
        base.WndProc(ref m);
    }
}