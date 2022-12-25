using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public partial class frmResize : Form
    {
        public frmResize()
        {
            base.MouseDown += frmResize_MouseDown;
            base.MouseLeave += frmResize_MouseLeave;
            base.MouseMove += frmResize_MouseMove;
            base.MouseUp += frmResize_MouseUp;
            base.ResizeEnd += frmResize_ResizeEnd;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        }
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
        private void frmResize_MouseDown(object sender, MouseEventArgs e)
        {
            checked
            {
                if (!Operators.ConditionalCompareObjectEqual(frmMain.frm.lblMax.Tag, "Max", TextCompare: false) && e.Button == MouseButtons.Left)
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
        private void frmResize_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void frmResize_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if (!Operators.ConditionalCompareObjectEqual(frmMain.frm.lblMax.Tag, "Max", TextCompare: false))
                {
                    if (e.X == 0 || e.X == 1 || e.X == 2 || e.X == 3 || e.X == base.Width - 1 || e.X == base.Width - 2 || e.X == base.Width - 3 || e.X == base.Width - 4 || e.Y == 0 || e.Y == 1 || e.Y == 2 || e.Y == 3 || e.Y == base.Height - 1 || e.Y == base.Height - 2 || e.Y == base.Height - 3 || e.Y == base.Height - 4)
                    {
                        Cursor cursor = Cursors.Arrow;
                        int x = e.X;
                        if (x >= 0 && x <= 3)
                        {
                            int y = e.Y;
                            cursor = ((y >= 0 && y <= 3) ? Cursors.SizeNWSE : ((y < base.Height - 4 || y > base.Height - 1) ? Cursors.SizeWE : Cursors.SizeNESW));
                        }
                        else if (x >= base.Width - 4 && x <= base.Width - 1)
                        {
                            int y2 = e.Y;
                            cursor = ((y2 >= 0 && y2 <= 3) ? Cursors.SizeNESW : ((y2 < base.Height - 4 || y2 > base.Height - 1) ? Cursors.SizeWE : Cursors.SizeNWSE));
                        }
                        else
                        {
                            int y3 = e.Y;
                            if (y3 >= 0 && y3 <= 3)
                            {
                                cursor = Cursors.SizeNS;
                            }
                            else if (y3 >= base.Height - 4 && y3 <= base.Height - 1)
                            {
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
        private void frmResize_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void frmResize_ResizeEnd(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
