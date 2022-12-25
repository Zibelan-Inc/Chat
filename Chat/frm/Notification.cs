using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public partial class Notification : Form
    {
        public string Textt;
        public int WaitTime;
        public int ActualHeight;
        public int ActualWidth;
        public bool Mmail;
        public bool Notes;
        public bool UnReadmails;
        public bool _callrequest;
        public bool AvailableImage;
        private int yy;
        protected Rectangle rDisplay;
        protected Rectangle rScreen;
        protected Timer viewClock;
        public string NotificationKey;
        protected const int WP_CLOSEBUTTON = 18;
        protected const int CBS_NORMAL = 1;
        protected const int CBS_HOT = 2;
        protected const int CBS_PUSHED = 3;
        protected const int HWND_TOPMOST = -1;
        protected const int SWP_NOACTIVATE = 16;
        protected const int SW_SHOWNOACTIVATE = 4;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                int num = createParams.ExStyle | 136;
                createParams.ExStyle = num;
                return createParams;
            }
        }
        protected override bool ShowWithoutActivation => true;
        public Notification(string message) : this()
        {
            this.Textt = message;
        }
        public Notification(string message, int dHeight) : this()
        {
            this.DoubleBuffered = true;
            this.Textt = message;
        }
        public Notification()
        {
            this.FormClosed += new FormClosedEventHandler(this.Notification_FormClosed);
            this.Mmail = false;
            this.Notes = false;
            this.UnReadmails = false;
            this._callrequest = false;
            this.NotificationKey = string.Empty;
            this.InitializeComponent();
            this.lblContent.Tag = (object)"";
            this.lblTest.Tag = (object)"40";
            this.DoubleBuffered = true;
            this.ActualWidth = 130;
            this.ActualHeight = 110;
            this.WaitTime = 2000;
        }
        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Modcommon.PIN_MSGWINDOW && this.Mmail || (this.viewClock == null || !this.viewClock.Enabled))
                    return;
                this.viewClock.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        public enum BackgroundStyles
        {
            BackwardDiagonalGradient,
            ForwardDiagonalGradient,
            HorizontalGradient,
            VerticalGradient,
            Solid,
        }
        [StructLayout(LayoutKind.Explicit)]
        protected struct RECT
        {
            [FieldOffset(0)]
            public int Left;
            [FieldOffset(4)]
            public int Top;
            [FieldOffset(8)]
            public int Right;
            [FieldOffset(12)]
            public int Bottom;

            public RECT(Rectangle bounds)
            {
                this = new RECT();
                this.Left = bounds.Left;
                this.Top = bounds.Top;
                this.Right = bounds.Right;
                this.Bottom = bounds.Bottom;
            }
        }
        public void SetDimensions(int width, int height)
        {
            this.ActualWidth = width;
            this.ActualHeight = height;
            this.ActualHeight = Conversions.ToInteger(this.lblTest.Tag);
        }
        public static short num{ get; set; }
        public void Notify(bool mt = false)
        {
            try
            {
                if (this.Textt == null || this.Textt.Length < 1 && !this._callrequest)
                    throw new Exception("You must set NotifyWindow.Text before calling Notify()");
                this.SuspendLayout();
                ((Control)this).Show();
                SizeF textSize = Modcommon.GetTextSize(this.Textt);
                if ((double)textSize.Width > 200.0)
                    textSize.Width = 200f;
                if ((double)textSize.Width < 100.0)
                    textSize.Width = 100f;
                if ((double)textSize.Height > 200.0)
                    textSize.Height = 200f;
                if ((double)textSize.Height < 40.0)
                    textSize.Height = 40f;
                if (this.AvailableImage)
                    num = (short)40;
                if (this._callrequest)
                    num = (short)50;
                this.SetDimensions(checked((int)Math.Round(unchecked((double)textSize.Width + 20.0 + 15.0 + (double)num))), checked((int)Math.Round((double)textSize.Height)));
                this.lblContent.Text = this.Textt;
                if (Operators.ConditionalCompareObjectEqual(this.lblContent.Tag, (object)"M", false))
                {
                    this.ActualHeight = Conversions.ToInteger(this.lblTest.Tag);
                    if (this.ActualWidth < 170)
                        this.ActualWidth = 170;
                    if (this.ActualHeight > 150)
                        this.ActualHeight = 150;
                }
                this.Width = this.ActualWidth;
                this.rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
                this.Height = this.ActualHeight;
                this.Left = checked(this.rScreen.Width - this.Width);
                this.rDisplay = new Rectangle(0, 0, this.Width, this.ActualHeight);
                checked
                {
                    var alertcount = Modcommon.ALERTCOUNT;
                }
                if (mt)
                {
                    this.yy = checked(this.rScreen.Height - this.ActualHeight);
                    try
                    {
                        int index = checked((int)(short)Modcommon.ChatBottomForms.Count - 1);
                        while (index >= 0)
                        {
                            string str = Conversions.ToString(Enumerable.ElementAtOrDefault<object>(Enumerable.Cast<object>((IEnumerable)Modcommon.ChatBottomForms.Keys), index));
                            Notification notification = (Notification)Modcommon.ChatBottomForms[(object)str];
                            if (notification.Visible)
                                this.yy = checked(this.yy - notification.ActualHeight);
                            else
                                Modcommon.ChatBottomForms.Remove((object)str);
                            checked { index += -1; }
                        }
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                    }
                    if (this.yy < 0)
                        this.yy = checked(this.rScreen.Height - this.ActualHeight);
                    this.WaitTime = 8000;
                }
                /*
                else
                    this.yy = checked(this.rScreen.Height - this.ActualHeight);
                if (MyProject.Forms.frmMain.frmPopupStatus != null)
                    this.yy = checked(this.yy - MyProject.Forms.frmMain.frmPopupStatus.Height);
                if (Modcommon.VIDEOCALL)
                {
                    ChatMaster chatForm;
                    if (OutputMessenger.Modcommon.ICHAT_TABS.IsChatFormExsits(OutputMessenger.Modcommon.VOICECALL_KEY))
                        chatForm = OutputMessenger.Modcommon.ICHAT_TABS.GetChatForm(OutputMessenger.Modcommon.VOICECALL_KEY);
                    if (chatForm == null && OutputMessenger.Modcommon.ICHAT_TABS.IsGroupChatFormExsits(OutputMessenger.Modcommon.VOICECALL_KEY))
                        OutputMessenger.Modcommon.ICHAT_TABS.GetGroupChatForm(OutputMessenger.Modcommon.VOICECALL_KEY);
                    ExtendsChatArgs extendsArg = OutputMessenger.Modcommon.ICHAT_TABS.GetExtendsArg(OutputMessenger.Modcommon.VOICECALL_KEY);
                    if (extendsArg != null && extendsArg.RDV != null && extendsArg.RDV.CheckVideoIconPopup())
                        this.yy = checked(this.yy - 55);
                }
                this.Width = this.ActualWidth;
                this.Height = this.ActualHeight;
                this.Left = checked(this.rScreen.Width - this.ActualWidth);
                this.Top = this.yy;
                if (!Modcommon.ChatBottomForms.ContainsKey((object)Conversions.ToString(OutputMessenger.Modcommon.ALERTCOUNT)))
                    Modcommon.ChatBottomForms.Add((object)Conversions.ToString(OutputMessenger.Modcommon.ALERTCOUNT), (object)this);
                if (!this._callrequest)
                {
                    if (OutputMessenger.Modcommon.PIN_MSGWINDOW)
                    {
                        if (this.Mmail)
                            goto label_48;
                    }
                    this.viewClock = new Timer();
                    this.viewClock.Tick += new EventHandler(this.viewTimer);
                    this.viewClock.Interval = this.WaitTime;
                    this.viewClock.Start();
                }
                */
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            label_48:
            this.ResumeLayout();
        }

        protected void viewTimer(object sender, EventArgs e)
        {
            try
            {
                this.viewClock.Stop();
                this.viewClock.Dispose();
                Modcommon.ChatBottomForms.Remove((object)Conversions.ToString(Modcommon.ALERTCOUNT));
                this.Close();
                base.Dispose();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        public void ResetTimer()
        {
            try
            {
                if (this.viewClock == null)
                    return;
                this.viewClock.Stop();
                this.viewClock.Start();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        [DllImport("UxTheme.dll")]
        protected static extern int IsThemeActive();

        [DllImport("UxTheme.dll")]
        protected static extern IntPtr OpenThemeData(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] string classList);

        [DllImport("UxTheme.dll")]
        protected static extern void CloseThemeData(IntPtr hTheme);

        [DllImport("UxTheme.dll")]
        protected static extern void DrawThemeBackground(IntPtr hTheme, IntPtr hDC, int partId, int stateId, ref RECT rect, ref RECT clipRect);

        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);








    }
}
