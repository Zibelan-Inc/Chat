using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat.Forms
{
    public partial class frmBorder : Form
    {
        public bool _defaultView;
        public void showborder(bool defaultview, string title)
        {
            try
            {
                _defaultView = defaultview;
                if (defaultview)
                {
                    ChangeWindowMenuHandler(str: false);
                    base.Padding = new Padding(0);
                    pnlTitlebar.Visible = false;
                    lblTitle.Text = title;
                }
                else
                {
                    ChangeWindowMenuHandler(str: true);
                    if (!lblMax.Tag.Equals("Max"))
                    {
                        lblMax.Tag = "Restore";
                    }
                    pnlTitlebar.Visible = true;
                    base.Padding = new Padding(4);
                    lblTitle.Text = title;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }
        protected void SystemMenu_SystemEvent(object sender, WindowMenuEventArgs ev)
        {
            SendNCWinMessage(274, new IntPtr(ev.SystemCommand), IntPtr.Zero);
        }
        private void SendNCWinMessage(int msg, IntPtr wParam, IntPtr lParam)
        {
            System.Windows.Forms.Message m = System.Windows.Forms.Message.Create(base.Handle, msg, wParam, lParam);
            WndProc(ref m);
            int num = wParam.ToInt32();
            if (num == 61488 || num == 61728)
            {
                ChangeResizeImage();
            }
        }
        private void ChangeResizeImage()
        {
            if (base.WindowState == FormWindowState.Normal)
            {
                lblMax.Image = Resources.max1;
                lblMax.Tag = "Restore";
            }
            else
            {
                lblMax.Image = Resources.restore;
                lblMax.Tag = "Max";
            }
        }
        private void ChangeWindowMenuHandler(bool str)
        {
            try
            {
                if (str)
                {
                    SystemMenu = new WindowMenu(this);
                    SystemMenu.SystemEvent += SystemMenu_SystemEvent;
                }
                else
                {
                    SystemMenu = null;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }



        ///////////////////////////////////////////////////////////////////////

        public delegate void OnFormActivatedEventHandler();

        public delegate void OnFormDeactivatedEventHandler();

        private WindowMenu SystemMenu;

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

        private const int WM_ACTIVATE = 6;

        private const int WA_ACTIVE = 1;

        private const int WA_CLICKACTIVE = 2;

        private const int WA_INACTIVE = 0;

        public bool ENABLE_RESIZE;

        [CompilerGenerated]
        private OnFormActivatedEventHandler OnFormActivatedEvent;

        [CompilerGenerated]
        private OnFormDeactivatedEventHandler OnFormDeactivatedEvent;

        private Color _bgColor;

        private const int WS_CLIPCHILDREN = 33554432;

        private const int WS_MINIMIZEBOX = 131072;

        private const int WS_MAXIMIZEBOX = 65536;

        private const int WS_SYSMENU = 524288;

        private const int CS_DBLCLKS = 8;









        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style = (createParams.Style | 0x2000000 | 0x20000);
                createParams.ClassStyle |= 8;
                return createParams;
            }
        }

        public event OnFormActivatedEventHandler OnFormActivated
        {
            [CompilerGenerated]
            add
            {
                OnFormActivatedEventHandler onFormActivatedEventHandler = OnFormActivatedEvent;
                OnFormActivatedEventHandler onFormActivatedEventHandler2;
                do
                {
                    onFormActivatedEventHandler2 = onFormActivatedEventHandler;
                    OnFormActivatedEventHandler value2 = (OnFormActivatedEventHandler)Delegate.Combine(onFormActivatedEventHandler2, value);
                    onFormActivatedEventHandler = Interlocked.CompareExchange(ref OnFormActivatedEvent, value2, onFormActivatedEventHandler2);
                }
                while ((object)onFormActivatedEventHandler != onFormActivatedEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnFormActivatedEventHandler onFormActivatedEventHandler = OnFormActivatedEvent;
                OnFormActivatedEventHandler onFormActivatedEventHandler2;
                do
                {
                    onFormActivatedEventHandler2 = onFormActivatedEventHandler;
                    OnFormActivatedEventHandler value2 = (OnFormActivatedEventHandler)Delegate.Remove(onFormActivatedEventHandler2, value);
                    onFormActivatedEventHandler = Interlocked.CompareExchange(ref OnFormActivatedEvent, value2, onFormActivatedEventHandler2);
                }
                while ((object)onFormActivatedEventHandler != onFormActivatedEventHandler2);
            }
        }

        public event OnFormDeactivatedEventHandler OnFormDeactivated
        {
            [CompilerGenerated]
            add
            {
                OnFormDeactivatedEventHandler onFormDeactivatedEventHandler = OnFormDeactivatedEvent;
                OnFormDeactivatedEventHandler onFormDeactivatedEventHandler2;
                do
                {
                    onFormDeactivatedEventHandler2 = onFormDeactivatedEventHandler;
                    OnFormDeactivatedEventHandler value2 = (OnFormDeactivatedEventHandler)Delegate.Combine(onFormDeactivatedEventHandler2, value);
                    onFormDeactivatedEventHandler = Interlocked.CompareExchange(ref OnFormDeactivatedEvent, value2, onFormDeactivatedEventHandler2);
                }
                while ((object)onFormDeactivatedEventHandler != onFormDeactivatedEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                OnFormDeactivatedEventHandler onFormDeactivatedEventHandler = OnFormDeactivatedEvent;
                OnFormDeactivatedEventHandler onFormDeactivatedEventHandler2;
                do
                {
                    onFormDeactivatedEventHandler2 = onFormDeactivatedEventHandler;
                    OnFormDeactivatedEventHandler value2 = (OnFormDeactivatedEventHandler)Delegate.Remove(onFormDeactivatedEventHandler2, value);
                    onFormDeactivatedEventHandler = Interlocked.CompareExchange(ref OnFormDeactivatedEvent, value2, onFormDeactivatedEventHandler2);
                }
                while ((object)onFormDeactivatedEventHandler != onFormDeactivatedEventHandler2);
            }
        }








        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = ColorTranslator.FromHtml("#c75050");
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblMax_MouseEnter(object sender, EventArgs e)
        {
            if (lblMax.Image != null)
            {
                lblMax.BackColor = ColorTranslator.FromHtml("#3665b3");
            }
        }

        private void lblMax_MouseLeave(object sender, EventArgs e)
        {
            lblMax.BackColor = Color.Transparent;
        }

        private void lblMin_MouseEnter(object sender, EventArgs e)
        {
            if (lblMin.Image != null)
            {
                lblMin.BackColor = ColorTranslator.FromHtml("#3665b3");
            }
        }

        private void lblMin_MouseLeave(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.Transparent;
        }

        private void frmBorder_Activated(object sender, EventArgs e)
        {
            BackColor = _bgColor;
        }

        private void frmBorder_Deactivate(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#609ED5");
        }

        private void frmBorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SystemMenu != null)
            {
                SystemMenu.SystemEvent -= SystemMenu_SystemEvent;
            }
            //Modcommon.FlushMemory();
        }

        private void frmBorder_Load(object sender, EventArgs e)
        {
            //Modcommon.FlushMemory();
        }

        public void HideMinMaxButton()
        {
            lblMax.Image = null;
            lblMin.Image = null;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            SystemMenu.HideMinMax();
        }

        private void frmBorder_MouseDown(object sender, MouseEventArgs e)
        {
            checked
            {
                if ((ENABLE_RESIZE || (lblMin.Image != null && lblMin.Visible)) && !Conversions.ToBoolean((!ENABLE_RESIZE && Conversions.ToBoolean(Operators.CompareObjectEqual(lblMax.Tag, "Max", TextCompare: false))) || Operators.ConditionalCompareObjectEqual(lblMax.Tag, "Max", TextCompare: false)) && (ENABLE_RESIZE || !Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false)) && e.Button == MouseButtons.Left)
                {
                    base.Capture = false;
                    Cursor cursor = Cursors.Arrow;
                    IntPtr wparam = new IntPtr(base.Bottom);
                    if (e.X == 0 || e.X == 1 || e.X == 2 || e.X == 3 || e.X == base.Width - 1 || e.X == base.Width - 2 || e.X == base.Width - 3 || e.X == base.Width - 4 || e.Y == 0 || e.Y == 1 || e.Y == 2 || e.Y == 3 || e.Y == base.Height - 1 || e.Y == base.Height - 2 || e.Y == base.Height - 3 || e.Y == base.Height - 4)
                    {
                        int x = e.X;
                        if (x >= 0 && x <= 3)
                        {
                            int y = e.Y;
                            if (y >= 0 && y <= 3)
                            {
                                wparam = (IntPtr)13;
                                cursor = Cursors.SizeNWSE;
                            }
                            else if (y >= base.Height - 4 && y <= base.Height - 1)
                            {
                                wparam = (IntPtr)16;
                                cursor = Cursors.SizeNESW;
                            }
                            else
                            {
                                wparam = (IntPtr)10;
                                cursor = Cursors.SizeWE;
                            }
                        }
                        else if (x >= base.Width - 4 && x <= base.Width - 1)
                        {
                            int y2 = e.Y;
                            if (y2 >= 0 && y2 <= 3)
                            {
                                wparam = (IntPtr)14;
                                cursor = Cursors.SizeNESW;
                            }
                            else if (y2 >= base.Height - 4 && y2 <= base.Height - 1)
                            {
                                wparam = (IntPtr)17;
                                cursor = Cursors.SizeNWSE;
                            }
                            else
                            {
                                wparam = (IntPtr)11;
                                cursor = Cursors.SizeWE;
                            }
                        }
                        else
                        {
                            int y3 = e.Y;
                            if (y3 >= 0 && y3 <= 3)
                            {
                                wparam = (IntPtr)12;
                                cursor = Cursors.SizeNS;
                            }
                            else if (y3 >= base.Height - 4 && y3 <= base.Height - 1)
                            {
                                wparam = (IntPtr)15;
                                cursor = Cursors.SizeNS;
                            }
                        }
                        Cursor = cursor;
                        System.Windows.Forms.Message m = System.Windows.Forms.Message.Create(base.Handle, 161, wparam, IntPtr.Zero);
                        DefWndProc(ref m);
                    }
                    else
                    {
                        Cursor = Cursors.SizeAll;
                        Application.DoEvents();
                        System.Windows.Forms.Message m2 = System.Windows.Forms.Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
                        DefWndProc(ref m2);
                    }
                }
            }
        }

        private void frmBorder_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void frmBorder_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if ((ENABLE_RESIZE || (lblMin.Image != null && lblMin.Visible)) && !Conversions.ToBoolean((!ENABLE_RESIZE && Conversions.ToBoolean(Operators.CompareObjectEqual(lblMax.Tag, "Max", TextCompare: false))) || Operators.ConditionalCompareObjectEqual(lblMax.Tag, "Max", TextCompare: false)))
                {
                    if (e.X == 0 || e.X == 1 || e.X == 2 || e.X == 3 || e.X == base.Width - 1 || e.X == base.Width - 2 || e.X == base.Width - 3 || e.X == base.Width - 4 || e.Y == 0 || e.Y == 1 || e.Y == 2 || e.Y == 3 || e.Y == base.Height - 1 || e.Y == base.Height - 2 || e.Y == base.Height - 3 || e.Y == base.Height - 4)
                    {
                        Cursor cursor = Cursors.Arrow;
                        int x = e.X;
                        if (x >= 0 && x <= 3)
                        {
                            int y = e.Y;
                            if (y >= 0 && y <= 3)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNWSE;
                            }
                            else if (y >= base.Height - 4 && y <= base.Height - 1)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNESW;
                            }
                            else
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeWE;
                            }
                        }
                        else if (x >= base.Width - 4 && x <= base.Width - 1)
                        {
                            int y2 = e.Y;
                            if (y2 >= 0 && y2 <= 3)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNESW;
                            }
                            else if (y2 >= base.Height - 4 && y2 <= base.Height - 1)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNWSE;
                            }
                            else
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeWE;
                            }
                        }
                        else
                        {
                            int y3 = e.Y;
                            if (y3 >= 0 && y3 <= 3)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNS;
                            }
                            else if (y3 >= base.Height - 4 && y3 <= base.Height - 1)
                            {
                                if (!ENABLE_RESIZE && Operators.ConditionalCompareObjectEqual(lblTitle.Tag, "M", TextCompare: false))
                                {
                                    ENABLE_RESIZE = true;
                                }
                                cursor = Cursors.SizeNS;
                            }
                        }
                        Cursor = cursor;
                    }
                    else if (unchecked((object)Cursor) != Cursors.SizeAll)
                    {
                        Cursor = Cursors.Arrow;
                    }
                }
            }
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            if (lblMin.Image != null && lblMin.Visible)
            {
                base.WindowState = FormWindowState.Minimized;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lblMax.Image != null && lblMin.Visible)
            {
                if (lblMax.Tag.Equals("Max"))
                {
                    base.WindowState = FormWindowState.Normal;
                }
                else
                {
                    SetMaxSize();
                    base.WindowState = FormWindowState.Maximized;
                }
                ChangeResizeImage();
            }
        }

        private void SetMaxSize()
        {
            try
            {
                Size size = Modcommon.CurrentScreenWorkingAreaSize(base.Location.X, base.Location.Y, base.Width, base.Height);
                if (MaximumSize != size)
                {
                    MaximumSize = size;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }


        public void OnDefWndProc(System.Windows.Forms.Message msg)
        {
            DefWndProc(ref msg);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            checked
            {
                try
                {
                    if (base.WindowState == FormWindowState.Maximized)
                    {
                        int num = m.WParam.ToInt32() & 0xFFF0;
                        if ((m.Msg == 274 && (num == 61456 || m.WParam.ToInt32() == 61456)) || (m.Msg == 161 && m.WParam.ToInt32() == 2))
                        {
                            m.Msg = 0;
                        }
                    }
                    if (m.Msg == 6)
                    {
                        switch (m.WParam.ToInt32())
                        {
                            case 1:
                            case 2:
                                OnFormActivatedEvent?.Invoke();
                                break;
                            case 0:
                                OnFormDeactivatedEvent?.Invoke();
                                break;
                        }
                    }
                    base.WndProc(ref m);
                    if (!base.IsDisposed && base.Visible && SystemMenu != null)
                    {
                        switch (m.Msg)
                        {
                            case 787:
                                Application.DoEvents();
                                SystemMenu.Show(this, PointToClient(new Point(m.LParam.ToInt32())));
                                break;
                            case 262:
                                if (m.WParam.ToInt32() == 32 && base.WindowState != FormWindowState.Minimized)
                                {
                                    short num2 = (short)base.Left;
                                    short num3 = (short)base.Top;
                                    if (num2 < 0)
                                    {
                                        num2 = 0;
                                    }
                                    if (num3 < 0)
                                    {
                                        num3 = 0;
                                    }
                                    SystemMenu.Show(this, PointToClient(new Point(num2, num3)));
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    ProjectData.ClearProjectError();
                }
            }
        }


        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }
        public frmBorder()
        {
            base.Activated += frmBorder_Activated;
            base.Deactivate += frmBorder_Deactivate;
            base.FormClosed += frmBorder_FormClosed;
            base.Load += frmBorder_Load;
            base.MouseDown += frmBorder_MouseDown;
            base.MouseLeave += frmBorder_MouseLeave;
            base.MouseMove += frmBorder_MouseMove;
            ENABLE_RESIZE = false;
            _bgColor = Color.FromArgb(49, 140, 231);
            InitializeComponent();
            DoubleBuffered = true;
            SystemMenu = new WindowMenu(this);
            SystemMenu.SystemEvent += SystemMenu_SystemEvent;
            //
            lblTitle.MouseClick += lblTitle_MouseDoubleClick;
            lblMin.MouseEnter += lblMin_MouseEnter;
            lblMin.MouseLeave += lblMin_MouseLeave;
            lblMin.Click += lblMin_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;
            lblClose.Click += lblClose_Click;
            lblClose.MouseDown += lblClose_MouseDown;
            EventHandler lblMaxClick = delegate (object a0, EventArgs a1)
            {
                lblTitle_MouseDoubleClick(RuntimeHelpers.GetObjectValue(a0), (MouseEventArgs)a1);
            };
            lblMax.MouseEnter += lblMax_MouseEnter;
            lblMax.MouseLeave += lblMax_MouseLeave;
            lblMax.Click += lblMaxClick;
        }
    }
}
