using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat
{
    public partial class PopupStatus : Form
    {
        private Rectangle rScreen;
        protected const int HWND_TOPMOST = -1;
        protected const int SWP_NOACTIVATE = 16;
        protected const int SW_SHOWNOACTIVATE = 4;
        private string _status;

        IEnumerator enumerator;
        private Label _lblStatusOrange;

        public PopupStatus(string status, string key, int yy = 0)
        {
            this.InitializeComponent();
            ChangeWindowTop();
            //FlashWin.Start(this.Handle);
            WinMod.MakeWindowTop((long)this.Handle);

            WindowState = FormWindowState.Normal;
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                this.lbltitle1.Text = "KosmoChat";
                this._status = status;
                this.rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);
                yy = checked(this.rScreen.Height - this.Height - yy);

                Message.Text += status;
                if (key == "Alert")
                    AvatarIMG.Image = Resources.Logo_SC;
                else
                    AvatarIMG.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(key));

                if (Modcommon.PIN_MSGWINDOW)
                {
                    try
                    {
                        foreach (object obj in (IEnumerable)Modcommon.ChatBottomForms.Keys)
                        {
                            object objectValue = RuntimeHelpers.GetObjectValue(obj);
                            Notification notification = (Notification)Modcommon.ChatBottomForms[RuntimeHelpers.GetObjectValue(objectValue)];
                            checked { yy -= notification.ActualHeight; }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                            (enumerator as IDisposable).Dispose();
                    }
                    if (yy < 0)
                        yy = checked(this.rScreen.Height - this.Height);
                    }
                SetWindowPos(this.Handle, -1, checked(this.rScreen.Width - this.Width), yy, this.Width, this.Height, 16U);
                ShowWindow(this.Handle, 4);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            Thread sleep = new Thread(Sleep);
            sleep.IsBackground = true;
            sleep.Start();
            foco.Focus();
            this.TopMost = true;

        }
        public void Sleep()
        {
            
            Thread.Sleep(5000);
            Close();
        }

        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public void Changestatus(string status)
        {
            try
            {
                this._status = status;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        public void ChangeWindowTop()
        {
            try
            {
                SetWindowPos(this.Handle, -1, checked(this.rScreen.Width - this.Width), checked(this.rScreen.Height - this.Height), this.Width, this.Height, 16U);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void Message_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Message_MouseMove(object sender, MouseEventArgs e)
        {
            foco.Focus();
        }
    }
}
