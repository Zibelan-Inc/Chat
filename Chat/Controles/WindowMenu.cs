using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    internal sealed class WindowMenu : ContextMenu
    {
        private Form Owner;
        private MenuItem menuRestore;
        private MenuItem menuMove;
        private MenuItem menuSize;
        private MenuItem menuMin;
        private MenuItem menuMax;
        private MenuItem menuSep;
        private MenuItem menuClose;

        public event WindowMenuEventHandler SystemEvent;
        public void HideMinMax()
        {
            menuRestore.Visible = false;
            menuSize.Visible = false;
            menuMin.Visible = false;
            menuMax.Visible = false;
        }
        public WindowMenu(Form owner)
        {
            this.Owner = owner;
            this.menuRestore = this.CreateMenuItem("Restore", Shortcut.None);
            this.menuMove = this.CreateMenuItem("Move", Shortcut.None);
            this.menuSize = this.CreateMenuItem("Size", Shortcut.None);
            this.menuMin = this.CreateMenuItem("Minimize", Shortcut.None);
            this.menuMax = this.CreateMenuItem("Maximize", Shortcut.None);
            this.menuSep = this.CreateMenuItem("-", Shortcut.None);
            this.menuClose = this.CreateMenuItem("Close", Shortcut.AltF4);
            MenuItemCollection menuItems = this.MenuItems;
            MenuItem[] items = new MenuItem[7];
            int index1 = 0;
            MenuItem menuItem1 = this.menuRestore;
            items[index1] = menuItem1;
            int index2 = 1;
            MenuItem menuItem2 = this.menuMove;
            items[index2] = menuItem2;
            int index3 = 2;
            MenuItem menuItem3 = this.menuSize;
            items[index3] = menuItem3;
            int index4 = 3;
            MenuItem menuItem4 = this.menuMin;
            items[index4] = menuItem4;
            int index5 = 4;
            MenuItem menuItem5 = this.menuMax;
            items[index5] = menuItem5;
            int index6 = 5;
            MenuItem menuItem6 = this.menuSep;
            items[index6] = menuItem6;
            int index7 = 6;
            MenuItem menuItem7 = this.menuClose;
            items[index7] = menuItem7;
            menuItems.AddRange(items);
            this.menuClose.DefaultItem = true;
        }

        protected override void OnPopup(EventArgs e)
        {
            switch (this.Owner.WindowState)
            {
                case FormWindowState.Normal:
                    this.menuRestore.Enabled = false;
                    this.menuMax.Enabled = true;
                    this.menuMin.Enabled = true;
                    this.menuMove.Enabled = true;
                    this.menuSize.Enabled = true;
                    break;
                case FormWindowState.Minimized:
                    this.menuRestore.Enabled = true;
                    this.menuMax.Enabled = true;
                    this.menuMin.Enabled = false;
                    this.menuMove.Enabled = false;
                    this.menuSize.Enabled = false;
                    break;
                case FormWindowState.Maximized:
                    this.menuRestore.Enabled = true;
                    this.menuMax.Enabled = false;
                    this.menuMin.Enabled = true;
                    this.menuMove.Enabled = false;
                    this.menuSize.Enabled = false;
                    break;
            }
            base.OnPopup(e);
        }

        private void OnWindowMenuClick(object sender, EventArgs e)
        {
            switch (this.MenuItems.IndexOf((MenuItem)sender))
            {
                case 0:
                    this.SendSysCommand(User32.SysCommand.SC_RESTORE);
                    break;
                case 1:
                    this.SendSysCommand(User32.SysCommand.SC_MOVE);
                    break;
                case 2:
                    this.SendSysCommand(User32.SysCommand.SC_SIZE);
                    break;
                case 3:
                    this.SendSysCommand(User32.SysCommand.SC_MINIMIZE);
                    break;
                case 4:
                    this.SendSysCommand(User32.SysCommand.SC_MAXIMIZE);
                    break;
                case 6:
                    this.SendSysCommand(User32.SysCommand.SC_CLOSE);
                    break;
            }
        }

        private MenuItem CreateMenuItem(string text, Shortcut shortcut)
        {
            MenuItem menuItem = new MenuItem(text, new EventHandler(this.OnWindowMenuClick), shortcut);
            int num = 1;
            menuItem.OwnerDraw = num != 0;
            MeasureItemEventHandler itemEventHandler1 = new MeasureItemEventHandler(this.item_MeasureItem);
            menuItem.MeasureItem += itemEventHandler1;
            DrawItemEventHandler itemEventHandler2 = new DrawItemEventHandler(this.item_DrawItem);
            menuItem.DrawItem += itemEventHandler2;
            return menuItem;
        }

        private void item_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.MenuItems[e.Index].Text + "/tAlt+F4", SystemFonts.MenuFont);
            e.ItemHeight = Conversions.ToInteger(Interaction.IIf(e.Index == 5, (object)8, (object)checked(size.Height + 7)));
            e.ItemWidth = checked(size.Width + size.Height + 23);
        }

        private void item_DrawItem(object sender, DrawItemEventArgs e)
        {
            MenuItem menuItem = base.MenuItems[e.Index];
            if (menuItem.Enabled)
            {
                e.DrawBackground();
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds);
            }
            checked
            {
                if (e.Index == 5)
                {
                    e.Graphics.DrawLine(SystemPens.GrayText, e.Bounds.Left + 2, e.Bounds.Top + 3, e.Bounds.Right - 2, e.Bounds.Top + 3);
                }
                else
                {
                    TextFormatFlags textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;
                    object obj = Interaction.IIf(menuItem.Enabled, SystemColors.MenuText, SystemColors.GrayText);
                    Color foreColor = (obj != null) ? ((Color)obj) : default(Color);
                    using (Font font = new Font("Marlett", 10f))
                    {
                        Rectangle bounds = e.Bounds;
                        bounds.Width = bounds.Height;
                        if (menuItem == menuRestore)
                        {
                            TextRenderer.DrawText(e.Graphics, "2", font, bounds, foreColor, textFormatFlags);
                        }
                        else if (menuItem == menuMin)
                        {
                            TextRenderer.DrawText(e.Graphics, "0", font, bounds, foreColor, textFormatFlags);
                        }
                        else if (menuItem == menuMax)
                        {
                            TextRenderer.DrawText(e.Graphics, "1", font, bounds, foreColor, textFormatFlags);
                        }
                        else if (menuItem == menuClose)
                        {
                            TextRenderer.DrawText(e.Graphics, "r", font, bounds, foreColor, textFormatFlags);
                        }
                    }
                    textFormatFlags &= ~TextFormatFlags.HorizontalCenter;
                    Rectangle bounds2 = new Rectangle(e.Bounds.Left + e.Bounds.Height + 3, e.Bounds.Top, e.Bounds.Width - e.Bounds.Height - 3, e.Bounds.Height);
                    TextRenderer.DrawText(e.Graphics, menuItem.Text, SystemFonts.MenuFont, bounds2, foreColor, textFormatFlags);
                    if (menuItem == menuClose)
                    {
                        string text = "Alt+F4";
                        Size size = TextRenderer.MeasureText(text, SystemFonts.MenuFont);
                        bounds2.X = bounds2.Right - size.Width - 13;
                        TextRenderer.DrawText(e.Graphics, text, SystemFonts.MenuFont, bounds2, foreColor, textFormatFlags);
                    }
                }
            }
        }
        private void SendSysCommand(User32.SysCommand command)
        {
            WindowMenuEventArgs ev = new WindowMenuEventArgs((int)command);
            WindowMenuEventHandler systemEventEvent = this.SystemEvent;
            if (systemEventEvent != null)
            {
                systemEventEvent(this, ev);
            }
        }
    }
    internal sealed class User32
    {
        public const int WM_NULL = 0;
        public const int WM_NCHITTEST = 132;
        public const int WM_NCACTIVATE = 134;
        public const int WM_SYSCOMMAND = 274;
        public const int WM_ENTERMENULOOP = 529;
        public const int WM_EXITMENULOOP = 530;
        public const int WM_GETSYSMENU = 787;
        public const int WS_SYSMENU_ALTSPACE = 262;

        private User32()
        {
        }

        public static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return new IntPtr(HiWord << 16 | LoWord & (int)ushort.MaxValue);
        }

        public enum SysCommand
        {
            SC_SIZE = 61440,
            SC_SEPARATOR = 61455,
            SC_MOVE = 61456,
            SC_MINIMIZE = 61472,
            SC_MAXIMIZE = 61488,
            SC_NEXTWINDOW = 61504,
            SC_PREVWINDOW = 61520,
            SC_CLOSE = 61536,
            SC_VSCROLL = 61552,
            SC_HSCROLL = 61568,
            SC_MOUSEMENU = 61584,
            SC_KEYMENU = 61696,
            SC_ARRANGE = 61712,
            SC_RESTORE = 61728,
            SC_TASKLIST = 61744,
            SC_SCREENSAVE = 61760,
            SC_HOTKEY = 61776,
            SC_DEFAULT = 61792,
            SC_MONITORPOWER = 61808,
            SC_CONTEXTHELP = 61824,
        }

        public enum NCHitTestResult
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }

        public enum NCMouseMessage
        {
            WM_NCMOUSEMOVE = 160,
            WM_NCLBUTTONDOWN = 161,
            WM_NCLBUTTONUP = 162,
            WM_NCLBUTTONDBLCLK = 163,
            WM_NCRBUTTONDOWN = 164,
            WM_NCRBUTTONUP = 165,
            WM_NCRBUTTONDBLCLK = 166,
            WM_NCMBUTTONDOWN = 167,
            WM_NCMBUTTONUP = 168,
            WM_NCMBUTTONDBLCLK = 169,
            WM_NCXBUTTONDOWN = 171,
            WM_NCXBUTTONUP = 172,
            WM_NCXBUTTONDBLCLK = 173,
        }
    }
    public class WindowMenuEventArgs : EventArgs
    {
        private int sysCommand;

        public int SystemCommand
        {
            get
            {
                return this.sysCommand;
            }
        }

        public WindowMenuEventArgs(int command)
        {
            this.sysCommand = command;
        }
    }
    public delegate void WindowMenuEventHandler(object sender, WindowMenuEventArgs ev);

}