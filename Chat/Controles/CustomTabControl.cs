// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.CustomTabControl
// Assembly: OM.Tab, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: C7A83F57-9985-40B8-B1FF-D32876037FE5
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OM.Tab.DLL

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Security.Permissions;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    [ToolboxBitmap(typeof(TabControl))]
    public class CustomTabControl : TabControl
    {
        private Bitmap _BackImage;
        private Bitmap _BackBuffer;
        private Graphics _BackBufferGraphics;
        private Bitmap _TabBuffer;
        private Graphics _TabBufferGraphics;
        private int _oldValue;
        private Point _dragStartPosition;
        private TabStyle _Style;
        private TabStyleProvider _StyleProvider;
        private List<TabPage> _TabPages;
        private Rectangle _ScreenSize;
        private Form _ParentForm;

        public enum TabStyle
        {
            None,
            Default,
            VisualStudio,
            Rounded,
            Angled,
            Chrome,
            Chrome2,
            IE8,
            VS2010,
        }
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams createParams = base.CreateParams;
                if (this.RightToLeftLayout)
                    createParams.ExStyle = createParams.ExStyle | 4194304 | 1048576;
                return createParams;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabStyleProvider DisplayStyleProvider
        {
            get
            {
                if (this._StyleProvider == null)
                    this.DisplayStyle = TabStyle.Default;
                return this._StyleProvider;
            }
            set
            {
                this._StyleProvider = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(TabStyle), "Default")]
        [RefreshProperties(RefreshProperties.All)]
        public TabStyle DisplayStyle
        {
            get
            {
                return this._Style;
            }
            set
            {
                if (this._Style == value)
                    return;
                this._Style = value;
                this._StyleProvider = TabStyleProvider.CreateProvider(this);
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                base.Multiline = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Point Padding
        {
            get
            {
                return this.DisplayStyleProvider.Padding;
            }
            set
            {
                this.DisplayStyleProvider.Padding = value;
            }
        }

        public override bool RightToLeftLayout
        {
            get
            {
                return base.RightToLeftLayout;
            }
            set
            {
                base.RightToLeftLayout = value;
                this.UpdateStyles();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool HotTrack
        {
            get
            {
                return this.DisplayStyleProvider.HotTrack;
            }
            set
            {
                this.DisplayStyleProvider.HotTrack = value;
            }
        }

        [Category("Appearance")]
        public new TabAlignment Alignment
        {
            get
            {
                return base.Alignment;
            }
            set
            {
                base.Alignment = value;
                switch (value)
                {
                    case TabAlignment.Top:
                    case TabAlignment.Bottom:
                        this.Multiline = false;
                        break;
                    case TabAlignment.Left:
                    case TabAlignment.Right:
                        this.Multiline = true;
                        break;
                }
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new TabAppearance Appearance
        {
            get
            {
                return base.Appearance;
            }
            set
            {
                base.Appearance = TabAppearance.Normal;
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rectangle1;
                if (this._Style == TabStyle.None)
                {
                    rectangle1 = new Rectangle(0, 0, this.Width, this.Height);
                }
                else
                {
                    int num = checked(5 + (unchecked(this.Alignment > TabAlignment.Bottom) ? this.ItemSize.Width : this.ItemSize.Height) * this.RowCount);
                    Rectangle rectangle2 = new Rectangle(4, num, checked(this.Width - 8), checked(this.Height - num - 4));
                    switch (this.Alignment)
                    {
                        case TabAlignment.Top:
                            rectangle2 = new Rectangle(0, checked(num - 1), this.Width, checked(this.Height - num + 1));
                            break;
                        case TabAlignment.Bottom:
                            rectangle2 = new Rectangle(4, 4, checked(this.Width - 8), checked(this.Height - num - 4));
                            break;
                        case TabAlignment.Left:
                            rectangle2 = new Rectangle(num, 4, checked(this.Width - num - 4), checked(this.Height - 8));
                            break;
                        case TabAlignment.Right:
                            rectangle2 = new Rectangle(4, 4, checked(this.Width - num - 4), checked(this.Height - 8));
                            break;
                    }
                    rectangle1 = rectangle2;
                }
                return rectangle1;
            }
        }

        [Browsable(false)]
        public int ActiveIndex
        {
            get
            {
                NativeMethods.TCHITTESTINFO tchittestinfo = new NativeMethods.TCHITTESTINFO(this.PointToClient(Control.MousePosition));
                int index = NativeMethods.SendMessage(this.Handle, 4877, IntPtr.Zero, NativeMethods.ToIntPtr((object)tchittestinfo)).ToInt32();
                return index != -1 ? (!this.TabPages[index].Enabled ? -1 : index) : -1;
            }
        }

        [Browsable(false)]
        public TabPage ActiveTab
        {
            get
            {
                int activeIndex = this.ActiveIndex;
                return activeIndex <= -1 ? (TabPage)null : this.TabPages[activeIndex];
            }
        }

        public int IsNewAlertTabIndex { get; set; }

        public new Point MousePosition
        {
            get
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.RightToLeftLayout)
                    point.X = checked(this.Width - point.X);
                return point;
            }
        }

        public event OnTabRemovedEventHandler OnTabRemoved;

        public event OnTabDoubleClickEventHandler OnTabDoubleClick;

        [Category("Action")]
        public event ScrollEventHandler HScroll;

        [Category("Action")]
        public event EventHandler<TabControlEventArgs> TabImageClick;

        [Category("Action")]
        public event EventHandler<TabControlCancelEventArgs> TabClosing;

        public CustomTabControl()
        {
            this._dragStartPosition = Point.Empty;
            this.IsNewAlertTabIndex = -1;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                if (!disposing)
                    return;
                if (this._BackImage != null)
                    this._BackImage.Dispose();
                if (this._BackBufferGraphics != null)
                    this._BackBufferGraphics.Dispose();
                if (this._BackBuffer != null)
                    this._BackBuffer.Dispose();
                if (this._TabBufferGraphics != null)
                    this._TabBufferGraphics.Dispose();
                if (this._TabBuffer != null)
                    this._TabBuffer.Dispose();
                if (this._StyleProvider == null)
                    return;
                this._StyleProvider.Dispose();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        public void HideTab(TabPage page)
        {
            if (page == null || !this.TabPages.Contains(page))
                return;
            this.BackupTabPages();
            this.TabPages.Remove(page);
        }

        public void HideTab(int index)
        {
            if (!this.IsValidTabIndex(index))
                return;
            this.HideTab(this._TabPages[index]);
        }

        public void HideTab(string key)
        {
            if (!this.TabPages.ContainsKey(key))
                return;
            this.HideTab(this.TabPages[key]);
        }

        public void ShowTab(TabPage page)
        {
            if (page == null)
                return;
            if (this._TabPages != null)
            {
                if (this.TabPages.Contains(page) || !this._TabPages.Contains(page))
                    return;
                int index1 = this._TabPages.IndexOf(page);
                if (index1 > 0)
                {
                    int index2 = checked(index1 - 1);
                    while (index2 >= 0)
                    {
                        if (this.TabPages.Contains(this._TabPages[index2]))
                        {
                            index1 = checked(this.TabPages.IndexOf(this._TabPages[index2]) + 1);
                            break;
                        }
                        checked { index2 += -1; }
                    }
                }
                if (index1 >= 0 && index1 < this.TabPages.Count)
                    this.TabPages.Insert(index1, page);
                else
                    this.TabPages.Add(page);
            }
            else
            {
                if (this.TabPages.Contains(page))
                    return;
                this.TabPages.Add(page);
            }
        }

        public void ShowTab(int index)
        {
            if (!this.IsValidTabIndex(index))
                return;
            this.ShowTab(this._TabPages[index]);
        }

        public void ShowTab(string key)
        {
            if (_TabPages != null)
            {
                TabPage page2 = _TabPages.Find((TabPage page) => page.Name.Equals(key, StringComparison.OrdinalIgnoreCase));
                ShowTab(page2);
            }
        }
        private bool IsValidTabIndex(int index)
        {
            this.BackupTabPages();
            if (index >= 0)
                return index < this._TabPages.Count;
            return false;
        }
        private IEnumerator enumerator;

        private void BackupTabPages()
        {
            if (this._TabPages != null)
                return;
            this._TabPages = new List<TabPage>();
            try
            {
                foreach (TabPage tabPage in this.TabPages)
                    this._TabPages.Add(tabPage);
            }
            finally
            {
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.AllowDrop)
                return;
            this._dragStartPosition = new Point(e.X, e.Y);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!this.AllowDrop)
                return;
            this._dragStartPosition = Point.Empty;
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            if (drgevent.Data.GetDataPresent(typeof(TabPage)))
                drgevent.Effect = DragDropEffects.Move;
            else
                drgevent.Effect = DragDropEffects.None;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (!drgevent.Data.GetDataPresent(typeof(TabPage)))
                return;
            drgevent.Effect = DragDropEffects.Move;
            TabPage tabPage = (TabPage)drgevent.Data.GetData(typeof(TabPage));
            if (this.ActiveTab == tabPage)
                return;
            int index = this.ActiveIndex;
            if (tabPage.Parent.Equals((object)this) && this.TabPages.IndexOf(tabPage) < index)
                checked { --index; }
            if (index < 0)
                index = 0;
            ((TabControl)tabPage.Parent).TabPages.Remove(tabPage);
            this.TabPages.Insert(index, tabPage);
            this.SelectedTab = tabPage;
        }

        private void StartDragDrop()
        {
            if (this._dragStartPosition.IsEmpty)
                return;
            TabPage selectedTab = this.SelectedTab;
            if (selectedTab == null)
                return;
            Rectangle rectangle = new Rectangle(this._dragStartPosition, Size.Empty);
            rectangle.Inflate(SystemInformation.DragSize);
            Point pt = this.PointToClient(Control.MousePosition);
            if (rectangle.Contains(pt))
                return;
            int num = (int)this.DoDragDrop((object)selectedTab, DragDropEffects.All);
            this._dragStartPosition = Point.Empty;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            IntPtr wParam = Font.ToHfont();
            NativeMethods.SendMessage(base.Handle, 48, wParam, (IntPtr)(-1));
            NativeMethods.SendMessage(base.Handle, 29, IntPtr.Zero, IntPtr.Zero);
            UpdateStyles();
            if (base.Visible)
            {
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                if (this._BackImage != null)
                {
                    this._BackImage.Dispose();
                    this._BackImage = (Bitmap)null;
                }
                if (this._BackBufferGraphics != null)
                    this._BackBufferGraphics.Dispose();
                if (this._BackBuffer != null)
                    this._BackBuffer.Dispose();
                this._BackBuffer = new Bitmap(this.Width, this.Height);
                this._BackBufferGraphics = Graphics.FromImage((Image)this._BackBuffer);
                if (this._TabBufferGraphics != null)
                    this._TabBufferGraphics.Dispose();
                if (this._TabBuffer != null)
                    this._TabBuffer.Dispose();
                this._TabBuffer = new Bitmap(this.Width, this.Height);
                this._TabBufferGraphics = Graphics.FromImage((Image)this._TabBuffer);
                if (this._BackImage != null)
                {
                    this._BackImage.Dispose();
                    this._BackImage = (Bitmap)null;
                }
            }
            base.OnResize(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            if (this._BackImage != null)
            {
                this._BackImage.Dispose();
                this._BackImage = (Bitmap)null;
            }
            base.OnParentBackColorChanged(e);
        }

        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            if (this._BackImage != null)
            {
                this._BackImage.Dispose();
                this._BackImage = (Bitmap)null;
            }
            base.OnParentBackgroundImageChanged(e);
        }

        private void OnParentResize(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;
            this.Invalidate();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent == null)
                return;
            this.Parent.Resize += new EventHandler(this.OnParentResize);
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if (e.Action != TabControlAction.Selecting || e.TabPage == null || e.TabPage.Enabled)
                return;
            e.Cancel = true;
        }

        protected override void OnMove(EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0 && this._BackImage != null)
            {
                this._BackImage.Dispose();
                this._BackImage = (Bitmap)null;
            }
            base.OnMove(e);
            this.Invalidate();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!this.Visible)
                return;
            this.Invalidate();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (!this.Visible)
                return;
            this.Invalidate();
        }

        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessMnemonic(char charCode)
        {
            bool flag;
            try
            {
                foreach (TabPage tabPage in this.TabPages)
                {
                    if (IsMnemonic(charCode, tabPage.Text))
                    {
                        this.SelectedTab = tabPage;
                        flag = true;
                        goto label_8;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            flag = base.ProcessMnemonic(charCode);
            label_8:
            return flag;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnSelected(TabControlEventArgs e)
        {
            base.OnSelected(e);
            if (this.SelectedTab != null && Operators.CompareString(this.SelectedTab.Name, "Chat", false) == 0)
                this.IsNewAlertTabIndex = -1;
            if (!this.Visible)
                return;
            this.Invalidate();
        }

        [DebuggerStepThrough]
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            try
            {
                if (m.Msg == 276)
                {
                    base.WndProc(ref m);
                    this.OnHScroll(new ScrollEventArgs((ScrollEventType)NativeMethods.LoWord(m.WParam), this._oldValue, NativeMethods.HiWord(m.WParam), ScrollOrientation.HorizontalScroll));
                }
                else
                    base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        private EventHandler<TabControlEventArgs> TabImageClickEvent;
        private OnTabRemovedEventHandler OnTabRemovedEvent;
        protected override void OnMouseClick(MouseEventArgs e)
        {
            try
            {
                int activeIndex = ActiveIndex;
                if (activeIndex > -1 && TabImageClickEvent != null && (base.TabPages[activeIndex].ImageIndex > -1 || !string.IsNullOrEmpty(base.TabPages[activeIndex].ImageKey)) && GetTabImageRect(activeIndex).Contains(MousePosition))
                {
                    OnTabImageClick(new TabControlEventArgs(base.TabPages[activeIndex], activeIndex, TabControlAction.Selected));
                    base.OnMouseClick(e);
                }
                else if (!base.DesignMode && activeIndex > -1 && _StyleProvider.ShowTabCloser && GetTabCloserRect(activeIndex).Contains(MousePosition))
                {
                    TabPage activeTab = ActiveTab;
                    TabControlCancelEventArgs tabControlCancelEventArgs = new TabControlCancelEventArgs(activeTab, activeIndex, false, TabControlAction.Deselecting);
                    OnTabClosing(tabControlCancelEventArgs);
                    if (!tabControlCancelEventArgs.Cancel)
                    {
                        if (base.TabPages.Count > 1)
                        {
                            base.SelectedIndex = checked(base.TabPages.Count - 2);
                        }
                        base.TabPages.Remove(activeTab);
                        OnTabRemovedEvent?.Invoke(activeTab);
                        activeTab.Dispose();
                    }
                }
                else
                {
                    base.OnMouseClick(e);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        protected virtual void OnTabImageClick(TabControlEventArgs e)
        {
            // ISSUE: reference to a compiler-generated field
            EventHandler<TabControlEventArgs> eventHandler = this.TabImageClickEvent;
            if (eventHandler == null)
                return;
            eventHandler((object)this, e);
        }

        protected virtual void OnTabClosing(TabControlCancelEventArgs e)
        {
            // ISSUE: reference to a compiler-generated field
            EventHandler<TabControlCancelEventArgs> eventHandler = this.TabClosing;
            if (eventHandler == null)
                return;
            eventHandler((object)this, e);
        }
        private ScrollEventHandler HScrollEvent;
        protected virtual void OnHScroll(ScrollEventArgs e)
        {
            Invalidate();
            HScrollEvent?.Invoke(this, e);
            if (e.Type == ScrollEventType.EndScroll)
            {
                _oldValue = e.NewValue;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this._StyleProvider.ShowTabCloser && this._StyleProvider.GetTabRect(this.ActiveIndex).Contains(this.MousePosition))
                this.Invalidate();
            if (!this.AllowDrop || e.Button != MouseButtons.Left)
                return;
            this.StartDragDrop();
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            // ISSUE: reference to a compiler-generated field
            OnTabDoubleClickEventHandler clickEventHandler = this.OnTabDoubleClick;
            if (clickEventHandler == null)
                return;
            clickEventHandler(this.SelectedTab);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.CustomPaint(e.Graphics);
        }

        private void CustomPaint(Graphics screenGraphics)
        {
            if (this.Width <= 0 || this.Height <= 0)
                return;
            Color color = ColorTranslator.FromHtml("#F6F5FD");
            using (Brush brush1 = (Brush)new SolidBrush(color))
            {
                using (Brush brush2 = (Brush)new SolidBrush(color))
                {
                    Rectangle clientRectangle = this.ClientRectangle;
                    Rectangle displayRectangle = this.DisplayRectangle;
                    screenGraphics.FillRectangle(brush1, clientRectangle);
                    screenGraphics.FillRectangle(brush2, displayRectangle);
                }
            }
            if (this.TabCount <= 0)
                return;
            if (this.Multiline)
            {
                int num1 = checked(this.RowCount - 1);
                int num2 = 0;
                while (num2 <= num1)
                {
                    int index = checked(this.TabCount - 1);
                    while (index >= 0)
                    {
                        if (index != this.SelectedIndex && (this.RowCount == 1 || this.GetTabRow(index) == num2))
                            this.DrawTabPage(index, screenGraphics);
                        checked { index += -1; }
                    }
                    checked { ++num2; }
                }
            }
            else
            {
                int index = checked(this.TabCount - 1);
                while (index >= 0)
                {
                    if (index != this.SelectedIndex)
                        this.DrawTabPage(index, screenGraphics);
                    checked { index += -1; }
                }
            }
            if (this.SelectedIndex <= -1)
                return;
            this.DrawTabPage(this.SelectedIndex, screenGraphics);
        }

        protected void PaintTransparentBackground(Graphics graphics, Rectangle clipRect)
        {
            if (this.Parent == null)
                return;
            clipRect.Offset(this.Location);
            GraphicsState gstate = graphics.Save();
            graphics.TranslateTransform((float)checked(-this.Location.X), (float)checked(-this.Location.Y));
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            PaintEventArgs e = new PaintEventArgs(graphics, clipRect);
            try
            {
                this.InvokePaintBackground(this.Parent, e);
                this.InvokePaint(this.Parent, e);
            }
            finally
            {
                graphics.Restore(gstate);
                clipRect.Offset(checked(-this.Location.X), checked(-this.Location.Y));
            }
        }

        private void DrawTabPage(int index, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            using (GraphicsPath tabPageBorder = this.GetTabPageBorder(index))
            {
                Brush brush = !(this.IsNewAlertTabIndex > -1 & this.IsNewAlertTabIndex == index) ? this._StyleProvider.GetPageBackgroundBrush(index) : this._StyleProvider.GetNewAlertBackgroundBrush(this.IsNewAlertTabIndex);
                using (brush)
                    graphics.FillPath(brush, tabPageBorder);
                if (this._Style != TabStyle.None)
                {
                    this._StyleProvider.PaintTab(index, graphics);
                    this.DrawTabImage(index, graphics);
                    this.DrawTabText(index, graphics);
                }
                this.DrawTabBorder(tabPageBorder, index, graphics);
            }
        }

        private void DrawTabBorder(GraphicsPath path, int index, Graphics graphics)
        {
            short num = (short)1;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Color color = ColorTranslator.FromHtml("#F8F7FD");
            if (index != this.SelectedIndex)
                color = !this._StyleProvider.HotTrack || index != this.ActiveIndex ? Color.FromArgb(50, color) : Color.FromArgb(50, color);
            using (Pen pen = new Pen(color, (float)num))
                graphics.DrawPath(pen, path);
        }

        private void DrawTabText(int index, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            Rectangle tabTextRect = this.GetTabTextRect(index);
            if (this.SelectedIndex == index)
            {
                using (Brush brush = (Brush)new SolidBrush(this._StyleProvider.TextColorSelected))
                    graphics.DrawString(this.TabPages[index].Text, this.Font, brush, (RectangleF)tabTextRect, this.GetStringFormat());
            }
            else if (this.TabPages[index].Enabled)
            {
                using (Brush brush = (Brush)new SolidBrush(this._StyleProvider.TextColor))
                    graphics.DrawString(this.TabPages[index].Text, this.Font, brush, (RectangleF)tabTextRect, this.GetStringFormat());
            }
            else
            {
                using (Brush brush = (Brush)new SolidBrush(this._StyleProvider.TextColorDisabled))
                    graphics.DrawString(this.TabPages[index].Text, this.Font, brush, (RectangleF)tabTextRect, this.GetStringFormat());
            }
        }

        private void DrawTabImage(int index, Graphics graphics)
        {
            Image image = (Image)null;
            if (this.TabPages[index].ImageIndex > -1 && this.ImageList != null && this.ImageList.Images.Count > this.TabPages[index].ImageIndex)
                image = this.ImageList.Images[this.TabPages[index].ImageIndex];
            else if (!string.IsNullOrEmpty(this.TabPages[index].ImageKey) && !this.TabPages[index].ImageKey.Equals("(none)", StringComparison.OrdinalIgnoreCase) && (this.ImageList != null && this.ImageList.Images.ContainsKey(this.TabPages[index].ImageKey)))
                image = this.ImageList.Images[this.TabPages[index].ImageKey];
            if (image == null)
                return;
            if (this.RightToLeftLayout)
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Rectangle tabImageRect = this.GetTabImageRect(index);
            if (this.TabPages[index].Enabled)
                graphics.DrawImage(image, tabImageRect);
            else
                ControlPaint.DrawImageDisabled(graphics, image, tabImageRect.X, tabImageRect.Y, Color.Transparent);
        }

        private StringFormat GetStringFormat()
        {
            StringFormat stringFormat = (StringFormat)null;
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    stringFormat = new StringFormat();
                    break;
                case TabAlignment.Left:
                case TabAlignment.Right:
                    stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                    break;
            }
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.HotkeyPrefix = this.FindForm() == null || !this.FindForm().KeyPreview ? HotkeyPrefix.Hide : HotkeyPrefix.Show;
            if (this.RightToLeft == RightToLeft.Yes)
                stringFormat.FormatFlags = stringFormat.FormatFlags | StringFormatFlags.DirectionRightToLeft;
            return stringFormat;
        }

        private GraphicsPath GetTabPageBorder(int index)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle pageBounds = this.GetPageBounds(index);
            Rectangle tabRect = this._StyleProvider.GetTabRect(index);
            this._StyleProvider.AddTabBorder(path, tabRect);
            this.AddPageBorder(path, pageBounds, tabRect);
            path.CloseFigure();
            return path;
        }
       private Rectangle rectangle;

        public Rectangle GetPageBounds(int index)
        {
            try
            {
                Rectangle bounds = this.TabPages[index].Bounds;
                bounds.Width = checked(bounds.Width + 1);
                bounds.Height = checked(bounds.Height + 1);
                bounds.X = checked(bounds.X - 1);
                bounds.Y = checked(bounds.Y - 1);
                if (bounds.Bottom > checked(this.Height - 4))
                    bounds.Height = checked(bounds.Height - bounds.Bottom - this.Height + 4);
                rectangle = bounds;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return rectangle;
        }

        private Rectangle GetTabTextRect(int index)
        {
            
            Rectangle rectangle = new Rectangle();
            using (GraphicsPath tabBorder = this._StyleProvider.GetTabBorder(index))
            {
                RectangleF bounds = tabBorder.GetBounds();
                rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X))), checked((int)Math.Round(Math.Truncate((double)bounds.Y))), checked((int)Math.Round(Math.Truncate((double)bounds.Width))), checked((int)Math.Round(Math.Truncate((double)bounds.Height))));
                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        rectangle.Y = checked(rectangle.Y + 4);
                        rectangle.Height = checked(rectangle.Height - 6);
                        break;
                    case TabAlignment.Bottom:
                        rectangle.Y = checked(rectangle.Y + 2);
                        rectangle.Height = checked(rectangle.Height - 6);
                        break;
                    case TabAlignment.Left:
                        rectangle.X = checked(rectangle.X + 4);
                        rectangle.Width = checked(rectangle.Width - 6);
                        break;
                    case TabAlignment.Right:
                        rectangle.X = checked(rectangle.X + 2);
                        rectangle.Width = checked(rectangle.Width - 6);
                        break;
                }
                if (this.ImageList != null && (this.TabPages[index].ImageIndex > -1 || !string.IsNullOrEmpty(this.TabPages[index].ImageKey) && !this.TabPages[index].ImageKey.Equals("(none)", StringComparison.OrdinalIgnoreCase)))
                {
                    Rectangle tabImageRect = this.GetTabImageRect(index);
                    if ((this._StyleProvider.ImageAlign & NativeMethods.AnyLeftAlign) != (ContentAlignment)0)
                    {
                        if (this.Alignment <= TabAlignment.Bottom)
                        {
                            rectangle.Width = checked(rectangle.Width - rectangle.Right - (int)Math.Round(Math.Truncate((double)bounds.Right)));
                            rectangle.Y = checked(tabImageRect.Height - 7);
                        }
                        else
                        {
                            rectangle.Y = checked(tabImageRect.Y + 4);
                            rectangle.Height = checked(rectangle.Height - rectangle.Bottom - (int)Math.Round(Math.Truncate((double)bounds.Bottom)));
                        }
                        if (this._StyleProvider.ShowTabCloser)
                        {
                            Rectangle tabCloserRect = this.GetTabCloserRect(index);
                            if (this.Alignment <= TabAlignment.Bottom)
                            {
                                if (this.RightToLeftLayout)
                                {
                                    rectangle.Width = checked(rectangle.Width - tabCloserRect.Right + 4 - rectangle.X);
                                    rectangle.X = checked(tabCloserRect.Right + 4);
                                }
                            }
                            else if (this.RightToLeftLayout)
                            {
                                rectangle.Height = checked(rectangle.Height - tabCloserRect.Bottom + 4 - rectangle.Y);
                                rectangle.Y = checked(tabCloserRect.Bottom + 4);
                            }
                            else
                                rectangle.Height = checked(rectangle.Height - (int)Math.Round(Math.Truncate((double)bounds.Bottom)) - tabCloserRect.Y + 4);
                        }
                    }
                    else if ((this._StyleProvider.ImageAlign & NativeMethods.AnyCenterAlign) != (ContentAlignment)0)
                    {
                        if (this._StyleProvider.ShowTabCloser)
                        {
                            Rectangle tabCloserRect = this.GetTabCloserRect(index);
                            if (this.Alignment <= TabAlignment.Bottom)
                            {
                                if (this.RightToLeftLayout)
                                {
                                    rectangle.Width = checked(rectangle.Width - tabCloserRect.Right + 4 - rectangle.X);
                                    rectangle.X = checked(tabCloserRect.Right + 4);
                                }
                                else
                                    rectangle.Width = checked(rectangle.Width - (int)Math.Round(Math.Truncate((double)bounds.Right)) - tabCloserRect.X + 4);
                            }
                            else if (this.RightToLeftLayout)
                            {
                                rectangle.Height = checked(rectangle.Height - tabCloserRect.Bottom + 4 - rectangle.Y);
                                rectangle.Y = checked(tabCloserRect.Bottom + 4);
                            }
                            else
                                rectangle.Height = checked(rectangle.Height - (int)Math.Round(Math.Truncate((double)bounds.Bottom)) - tabCloserRect.Y + 4);
                        }
                    }
                    else
                    {
                        if (this.Alignment <= TabAlignment.Bottom)
                            rectangle.Width = checked(rectangle.Width - (int)Math.Round(Math.Truncate((double)bounds.Right)) - tabImageRect.X + 4);
                        else
                            rectangle.Height = checked(rectangle.Height - (int)Math.Round(Math.Truncate((double)bounds.Bottom)) - tabImageRect.Y + 4);
                        if (this._StyleProvider.ShowTabCloser)
                        {
                            Rectangle tabCloserRect = this.GetTabCloserRect(index);
                            if (this.Alignment <= TabAlignment.Bottom)
                            {
                                if (this.RightToLeftLayout)
                                {
                                    rectangle.Width = checked(rectangle.Width - tabCloserRect.Right + 4 - rectangle.X);
                                    rectangle.X = checked(tabCloserRect.Right + 4);
                                }
                                else
                                    rectangle.Width = checked(rectangle.Width - (int)Math.Round(Math.Truncate((double)bounds.Right)) - tabCloserRect.X + 4);
                            }
                            else if (this.RightToLeftLayout)
                            {
                                rectangle.Height = checked(rectangle.Height - tabCloserRect.Bottom + 4 - rectangle.Y);
                                rectangle.Y = checked(tabCloserRect.Bottom + 4);
                            }
                            else
                                rectangle.Height = checked(rectangle.Height - (int)Math.Round(Math.Truncate((double)bounds.Bottom)) - tabCloserRect.Y + 4);
                        }
                    }
                }
                else if (this._StyleProvider.ShowTabCloser)
                {
                    Rectangle tabCloserRect = this.GetTabCloserRect(index);
                    if (this.Alignment <= TabAlignment.Bottom)
                    {
                        if (this.RightToLeftLayout)
                        {
                            rectangle.Width = checked(rectangle.Width - tabCloserRect.Right + 4 - rectangle.X);
                            rectangle.X = checked(tabCloserRect.Right + 4);
                        }
                        else
                            rectangle.Width = checked(rectangle.Width - (int)Math.Round(Math.Truncate((double)bounds.Right)) - tabCloserRect.X + 4);
                    }
                    else if (this.RightToLeftLayout)
                    {
                        rectangle.Height = checked(rectangle.Height - tabCloserRect.Bottom + 4 - rectangle.Y);
                        rectangle.Y = checked(tabCloserRect.Bottom + 4);
                    }
                    else
                        rectangle.Height = checked(rectangle.Height - (int)Math.Round(Math.Truncate((double)bounds.Bottom)) - tabCloserRect.Y + 4);
                }
                if (this.Alignment <= TabAlignment.Bottom)
                {
                    while (!tabBorder.IsVisible(rectangle.Right, rectangle.Y) && rectangle.Width > 0)
                        rectangle.Width = checked(rectangle.Width - 1);
                    while (!tabBorder.IsVisible(rectangle.X, rectangle.Y))
                    {
                        if (rectangle.Width > 0)
                        {
                            rectangle.X = checked(rectangle.X + 1);
                            rectangle.Width = checked(rectangle.Width - 1);
                        }
                        else
                            break;
                    }
                }
                else
                {
                    while (!tabBorder.IsVisible(rectangle.X, rectangle.Bottom) && rectangle.Height > 0)
                        rectangle.Height = checked(rectangle.Height - 1);
                    while (!tabBorder.IsVisible(rectangle.X, rectangle.Y))
                    {
                        if (rectangle.Height > 0)
                        {
                            rectangle.Y = checked(rectangle.Y + 1);
                            rectangle.Height = checked(rectangle.Height - 1);
                        }
                        else
                            break;
                    }
                }
            }
            return rectangle;
        }

        public int GetTabRow(int index)
        {
            Rectangle tabRect = this.GetTabRect(index);
            int num = -1;
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    num = checked(tabRect.Y - 2) / tabRect.Height;
                    break;
                case TabAlignment.Bottom:
                    num = checked(unchecked(checked(this.Height - tabRect.Y - 2) / tabRect.Height) - 1);
                    break;
                case TabAlignment.Left:
                    num = checked(tabRect.X - 2) / tabRect.Width;
                    break;
                case TabAlignment.Right:
                    num = checked(unchecked(checked(this.Width - tabRect.X - 2) / tabRect.Width) - 1);
                    break;
            }
            return num;
        }

        public Point GetTabPosition(int index)
        {
            Point point;
            if (!this.Multiline)
                point = new Point(0, index);
            else if (this.RowCount == 1)
            {
                point = new Point(0, index);
            }
            else
            {
                int tabRow = this.GetTabRow(index);
                Rectangle tabRect1 = this.GetTabRect(index);
                int y = -1;
                int num = checked(this.TabCount - 1);
                int index1 = 0;
                while (index1 <= num)
                {
                    Rectangle tabRect2 = this.GetTabRect(index1);
                    if (this.Alignment <= TabAlignment.Bottom)
                    {
                        if (tabRect2.Y == tabRect1.Y)
                            checked { ++y; }
                    }
                    else if (tabRect2.X == tabRect1.X)
                        checked { ++y; }
                    if (tabRect2.Location.Equals((object)tabRect1.Location))
                    {
                        point = new Point(tabRow, y);
                        goto label_15;
                    }
                    else
                        checked { ++index1; }
                }
                point = new Point(0, 0);
            }
            label_15:
            return point;
        }

        public bool IsFirstTabInRow(int index)
        {
            bool flag1;
            if (index < 0)
            {
                flag1 = false;
            }
            else
            {
                bool flag2 = index == 0;
                if (!flag2)
                {
                    if (this.Alignment <= TabAlignment.Bottom)
                    {
                        if (this.GetTabRect(index).X == 2)
                            flag2 = true;
                    }
                    else if (this.GetTabRect(index).Y == 2)
                        flag2 = true;
                }
                flag1 = flag2;
            }
            return flag1;
        }

        private void AddPageBorder(GraphicsPath path, Rectangle pageBounds, Rectangle tabBounds)
        {
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, tabBounds.X, pageBounds.Y);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, tabBounds.Right, pageBounds.Bottom);
                    break;
                case TabAlignment.Left:
                    path.AddLine(pageBounds.X, tabBounds.Y, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, tabBounds.Bottom);
                    break;
                case TabAlignment.Right:
                    path.AddLine(pageBounds.Right, tabBounds.Bottom, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, tabBounds.Y);
                    break;
            }
        }

        private Rectangle GetTabImageRect(int index)
        {
            using (GraphicsPath tabBorder = this._StyleProvider.GetTabBorder(index))
                return this.GetTabImageRect(tabBorder);
        }

        private Rectangle GetTabImageRect(GraphicsPath tabBorderPath)
        {
            Rectangle rectangle = new Rectangle();
            RectangleF bounds = tabBorderPath.GetBounds();
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    bounds.Y = bounds.Y + 4f;
                    bounds.Height = bounds.Height - 6f;
                    break;
                case TabAlignment.Bottom:
                    bounds.Y = bounds.Y + 2f;
                    bounds.Height = bounds.Height - 6f;
                    break;
                case TabAlignment.Left:
                    bounds.X = bounds.X + 4f;
                    bounds.Width = bounds.Width - 6f;
                    break;
                case TabAlignment.Right:
                    bounds.X = bounds.X + 2f;
                    bounds.Width = bounds.Width - 6f;
                    break;
            }
            if (this.Alignment <= TabAlignment.Bottom)
            {
                rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)(checked((int)Math.Round(Math.Truncate((double)bounds.Right)) - (int)Math.Round(Math.Truncate((double)bounds.X)) - (int)Math.Round(Math.Truncate((double)bounds.Height)) + 2) / 2)))))), checked((int)Math.Round(Math.Truncate((double)bounds.Y)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Height)) - 28) / 2.0))))), 28, 28);
                rectangle.Y = checked(rectangle.Y - 5);
                rectangle.X = checked(rectangle.X + 4);
            }
            else if ((this._StyleProvider.ImageAlign & NativeMethods.AnyLeftAlign) != (ContentAlignment)0)
            {
                rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Width)) - 16) / 2.0))))), checked((int)Math.Round(Math.Truncate((double)bounds.Y))), 16, 16);
                while (!tabBorderPath.IsVisible(rectangle.X, rectangle.Y))
                    rectangle.Y = checked(rectangle.Y + 1);
                rectangle.Y = checked(rectangle.Y + 4);
            }
            else if ((this._StyleProvider.ImageAlign & NativeMethods.AnyCenterAlign) != (ContentAlignment)0)
            {
                rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Width)) - 16) / 2.0))))), checked((int)Math.Round(Math.Truncate((double)bounds.Y)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)(checked((int)Math.Round(Math.Truncate((double)bounds.Bottom)) - (int)Math.Round(Math.Truncate((double)bounds.Y)) - (int)Math.Round(Math.Truncate((double)bounds.Width)) + 2) / 2)))))), 16, 16);
            }
            else
            {
                rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Width)) - 16) / 2.0))))), checked((int)Math.Round(Math.Truncate((double)bounds.Bottom))), 16, 16);
                while (!tabBorderPath.IsVisible(rectangle.X, rectangle.Bottom))
                    rectangle.Y = checked(rectangle.Y - 1);
                rectangle.Y = checked(rectangle.Y - 4);
                if (this._StyleProvider.ShowTabCloser && !this.RightToLeftLayout)
                    rectangle.Y = checked(rectangle.Y - 10);
            }
            return rectangle;
        }

        public Rectangle GetTabCloserRect(int index)
        {
            Rectangle rectangle = new Rectangle();
            using (GraphicsPath tabBorder = this._StyleProvider.GetTabBorder(index))
            {
                RectangleF bounds = tabBorder.GetBounds();
                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        bounds.Y = bounds.Y + 4f;
                        bounds.Height = bounds.Height - 6f;
                        break;
                    case TabAlignment.Bottom:
                        bounds.Y = bounds.Y + 2f;
                        bounds.Height = bounds.Height - 6f;
                        break;
                    case TabAlignment.Left:
                        bounds.X = bounds.X + 4f;
                        bounds.Width = bounds.Width - 6f;
                        break;
                    case TabAlignment.Right:
                        bounds.X = bounds.X + 2f;
                        bounds.Width = bounds.Width - 6f;
                        break;
                }
                if (this.Alignment <= TabAlignment.Bottom)
                {
                    if (this.RightToLeftLayout)
                    {
                        rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.Left))), checked((int)Math.Round(Math.Truncate((double)bounds.Y)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Height)) - 6) / 2.0))))), 6, 6);
                        while (!tabBorder.IsVisible(rectangle.Left, rectangle.Y) && rectangle.Right < this.Width)
                            rectangle.X = checked(rectangle.X + 1);
                        rectangle.X = checked(rectangle.X + 4);
                    }
                    else
                    {
                        rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.Right))), checked((int)Math.Round(Math.Truncate((double)bounds.Y)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Height)) - 6) / 2.0))))), 6, 6);
                        while (!tabBorder.IsVisible(rectangle.Right, rectangle.Y) && rectangle.Right > -6)
                            rectangle.X = checked(rectangle.X - 1);
                        rectangle.X = checked(rectangle.X - 6);
                        rectangle.Width = 9;
                        rectangle.Height = 7;
                    }
                }
                else if (this.RightToLeftLayout)
                {
                    rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Width)) - 6) / 2.0))))), checked((int)Math.Round(Math.Truncate((double)bounds.Top))), 6, 6);
                    while (!tabBorder.IsVisible(rectangle.X, rectangle.Top) && rectangle.Bottom < this.Height)
                        rectangle.Y = checked(rectangle.Y + 1);
                    rectangle.Y = checked(rectangle.Y + 4);
                }
                else
                {
                    rectangle = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X)) + (int)Math.Round(Math.Truncate(Math.Floor(unchecked((double)checked((int)Math.Round(Math.Truncate((double)bounds.Width)) - 6) / 2.0))))), checked((int)Math.Round(Math.Truncate((double)bounds.Bottom))), 6, 6);
                    while (!tabBorder.IsVisible(rectangle.X, rectangle.Bottom) && rectangle.Top > -6)
                        rectangle.Y = checked(rectangle.Y - 1);
                    rectangle.Y = checked(rectangle.Y - 4);
                }
            }
            return rectangle;
        }

        private static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }

        public delegate void OnTabRemovedEventHandler(TabPage deletedTab);

        public delegate void OnTabDoubleClickEventHandler(TabPage deletedTab);
    }
}
