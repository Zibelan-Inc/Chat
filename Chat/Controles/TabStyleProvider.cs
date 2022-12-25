// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleProvider
// Assembly: OM.Tab, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: C7A83F57-9985-40B8-B1FF-D32876037FE5
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OM.Tab.DLL

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Chat;

namespace System.Windows.Forms
{
    [ToolboxItem(false)]
    public abstract class TabStyleProvider : Component
    {
        protected CustomTabControl _TabControl;
        protected Point _Padding;
        protected bool _HotTrack;
        protected CustomTabControl.TabStyle _Style;
        protected ContentAlignment _ImageAlign;
        protected int _Radius;
        protected int _Overlap;
        protected bool _FocusTrack;
        protected float _Opacity;
        protected bool _ShowTabCloser;
        protected Color _BorderColorSelected;
        protected Color _BorderColor;
        protected Color _BorderColorHot;
        protected Color _CloserColorActive;
        protected Color _CloserColor;
        protected Color _FocusColor;
        protected Color _TextColor;
        protected Color _TextColorSelected;
        protected Color _TextColorDisabled;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CustomTabControl.TabStyle DisplayStyle
        {
            get
            {
                return this._Style;
            }
            set
            {
                this._Style = value;
            }
        }

        [Category("Appearance")]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this._ImageAlign;
            }
            set
            {
                this._ImageAlign = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public Point Padding
        {
            get
            {
                return this._Padding;
            }
            set
            {
                this._Padding = value;
                if (this._ShowTabCloser)
                {
                    if (checked(value.X + unchecked(this._Radius / 2)) < -6)
                        ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                    else
                        ((TabControl)this._TabControl).Padding = new Point(checked(value.X + unchecked(this._Radius / 2) + 6), value.Y);
                }
                else if (checked(value.X + unchecked(this._Radius / 2)) < 1)
                    ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                else
                    ((TabControl)this._TabControl).Padding = new Point(checked(value.X + unchecked(this._Radius / 2) - 1), value.Y);
            }
        }

        [Category("Appearance")]
        [DefaultValue(1)]
        [Browsable(true)]
        public int Radius
        {
            get
            {
                return this._Radius;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentException("The radius must be greater than 1", "value");
                this._Radius = value;
                this.Padding = this._Padding;
            }
        }

        [Category("Appearance")]
        public int Overlap
        {
            get
            {
                return this._Overlap;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The tabs cannot have a negative overlap", "value");
                this._Overlap = value;
            }
        }

        [Category("Appearance")]
        public bool FocusTrack
        {
            get
            {
                return this._FocusTrack;
            }
            set
            {
                this._FocusTrack = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public bool HotTrack
        {
            get
            {
                return this._HotTrack;
            }
            set
            {
                this._HotTrack = value;
                ((TabControl)this._TabControl).HotTrack = value;
            }
        }

        [Category("Appearance")]
        public bool ShowTabCloser
        {
            get
            {
                return this._ShowTabCloser;
            }
            set
            {
                this._ShowTabCloser = value;
                this.Padding = this._Padding;
            }
        }

        [Category("Appearance")]
        public float Opacity
        {
            get
            {
                return this._Opacity;
            }
            set
            {
                if ((double)value < 0.0)
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                if ((double)value > 1.0)
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                this._Opacity = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color BorderColorSelected
        {
            get
            {
                return !this._BorderColorSelected.IsEmpty ? this._BorderColorSelected : ThemedColors.ToolBorder;
            }
            set
            {
                this._BorderColorSelected = !value.Equals((object)ThemedColors.ToolBorder) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color BorderColorHot
        {
            get
            {
                return !this._BorderColorHot.IsEmpty ? this._BorderColorHot : SystemColors.ControlDark;
            }
            set
            {
                this._BorderColorHot = !value.Equals((object)SystemColors.ControlDark) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color BorderColor
        {
            get
            {
                return !this._BorderColor.IsEmpty ? this._BorderColor : SystemColors.ControlDark;
            }
            set
            {
                this._BorderColor = !value.Equals((object)SystemColors.ControlDark) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color TextColor
        {
            get
            {
                return !this._TextColor.IsEmpty ? this._TextColor : SystemColors.ControlText;
            }
            set
            {
                this._TextColor = !value.Equals((object)SystemColors.ControlText) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color TextColorSelected
        {
            get
            {
                return !this._TextColorSelected.IsEmpty ? this._TextColorSelected : SystemColors.ControlText;
            }
            set
            {
                this._TextColorSelected = !value.Equals((object)SystemColors.ControlText) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "")]
        public Color TextColorDisabled
        {
            get
            {
                return !this._TextColor.IsEmpty ? this._TextColorDisabled : SystemColors.ControlDark;
            }
            set
            {
                this._TextColorDisabled = !value.Equals((object)SystemColors.ControlDark) ? value : Color.Empty;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Orange")]
        public Color FocusColor
        {
            get
            {
                return this._FocusColor;
            }
            set
            {
                this._FocusColor = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CloserColorActive
        {
            get
            {
                return this._CloserColorActive;
            }
            set
            {
                this._CloserColorActive = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "DarkGrey")]
        public Color CloserColor
        {
            get
            {
                return this._CloserColor;
            }
            set
            {
                this._CloserColor = value;
                this._TabControl.Invalidate();
            }
        }

        protected TabStyleProvider(CustomTabControl tabControl)
        {
            this._Style = CustomTabControl.TabStyle.Default;
            this._Radius = 1;
            this._Opacity = 1f;
            this._BorderColorSelected = Color.Empty;
            this._BorderColor = Color.Empty;
            this._BorderColorHot = Color.Empty;
            this._CloserColorActive = Color.Black;
            this._CloserColor = Color.DarkGray;
            this._FocusColor = Color.Empty;
            this._TextColor = Color.Empty;
            this._TextColorSelected = Color.Empty;
            this._TextColorDisabled = Color.Empty;
            this._TabControl = tabControl;
            this._BorderColor = Color.Empty;
            this._BorderColorSelected = Color.Empty;
            this._FocusColor = Color.Orange;
            this._ImageAlign = !this._TabControl.RightToLeftLayout ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleRight;
            this.HotTrack = true;
            this.Padding = new Point(6, 3);
        }
        public class TabStyleNoneProvider : TabStyleProvider
        {
            public TabStyleNoneProvider(CustomTabControl tabControl)
              : base(tabControl)
            {
            }

            public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
            {
            }
        }

        public static TabStyleProvider CreateProvider(CustomTabControl tabControl)
        {
            TabStyleProvider tabStyleProvider;
            switch (tabControl.DisplayStyle)
            {
                case CustomTabControl.TabStyle.None:
                    tabStyleProvider = (TabStyleProvider)new TabStyleNoneProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.Default:
                    tabStyleProvider = (TabStyleProvider)new TabStyleDefaultProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.VisualStudio:
                    tabStyleProvider = (TabStyleProvider)new TabStyleVisualStudioProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.Rounded:
                    tabStyleProvider = (TabStyleProvider)new TabStyleRoundedProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.Angled:
                    tabStyleProvider = (TabStyleProvider)new TabStyleAngledProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.Chrome:
                    tabStyleProvider = (TabStyleProvider)new TabStyleChromeProvider(tabControl);
                    break;
                case CustomTabControl.TabStyle.Chrome2:
                    tabStyleProvider = (TabStyleProvider)new TabStyleChrome2Provider(tabControl);
                    break;
                case CustomTabControl.TabStyle.IE8:
                    tabStyleProvider = (TabStyleProvider)new TabStyleIE8Provider(tabControl);
                    break;
                case CustomTabControl.TabStyle.VS2010:
                    tabStyleProvider = (TabStyleProvider)new TabStyleVS2010Provider(tabControl);
                    break;
                default:
                    tabStyleProvider = (TabStyleProvider)new TabStyleDefaultProvider(tabControl);
                    break;
            }
            tabStyleProvider._Style = tabControl.DisplayStyle;
            return tabStyleProvider;
        }

        public abstract void AddTabBorder(GraphicsPath path, Rectangle tabBounds);

        public virtual Rectangle GetTabRect(int index)
        {
            Rectangle rectangle;
            if (index < 0)
            {
                rectangle = new Rectangle();
            }
            else
            {
                Rectangle tabRect = this._TabControl.GetTabRect(index);
                if (this._TabControl.RightToLeftLayout)
                    tabRect.X = checked(this._TabControl.Width - tabRect.Right);
                bool flag = this._TabControl.IsFirstTabInRow(index);
                switch (this._TabControl.Alignment)
                {
                    case TabAlignment.Top:
                        tabRect.Height = checked(tabRect.Height + 2);
                        break;
                    case TabAlignment.Bottom:
                        tabRect.Height = checked(tabRect.Height + 2);
                        tabRect.Y = checked(tabRect.Y - 2);
                        break;
                    case TabAlignment.Left:
                        tabRect.Width = checked(tabRect.Width + 2);
                        break;
                    case TabAlignment.Right:
                        tabRect.X = checked(tabRect.X - 2);
                        tabRect.Width = checked(tabRect.Width + 2);
                        break;
                }
                if ((!flag || this._TabControl.RightToLeftLayout) && this._Overlap > 0)
                {
                    if (this._TabControl.Alignment <= TabAlignment.Bottom)
                    {
                        tabRect.X = checked(tabRect.X - this._Overlap);
                        tabRect.Width = checked(tabRect.Width + this._Overlap);
                    }
                    else
                    {
                        tabRect.Y = checked(tabRect.Y - this._Overlap);
                        tabRect.Height = checked(tabRect.Height + this._Overlap);
                    }
                }
                this.EnsureFirstTabIsInView(ref tabRect, index);
                rectangle = tabRect;
            }
            return rectangle;
        }

        protected virtual void EnsureFirstTabIsInView(ref Rectangle tabBounds, int index)
        {
            if (!this._TabControl.IsFirstTabInRow(index))
                return;
            if (this._TabControl.Alignment <= TabAlignment.Bottom)
            {
                if (this._TabControl.RightToLeftLayout)
                {
                    if (tabBounds.Left >= this._TabControl.Right)
                        return;
                    int right = this._TabControl.GetPageBounds(index).Right;
                    if (tabBounds.Right <= right)
                        return;
                    tabBounds.Width = checked(tabBounds.Width - tabBounds.Right - right);
                }
                else
                {
                    if (tabBounds.Right <= 0)
                        return;
                    int x = this._TabControl.GetPageBounds(index).X;
                    if (tabBounds.X >= x)
                        return;
                    tabBounds.Width = checked(tabBounds.Width - x - tabBounds.X);
                    tabBounds.X = x;
                }
            }
            else if (this._TabControl.RightToLeftLayout)
            {
                if (tabBounds.Top >= this._TabControl.Bottom)
                    return;
                int bottom = this._TabControl.GetPageBounds(index).Bottom;
                if (tabBounds.Bottom <= bottom)
                    return;
                tabBounds.Height = checked(tabBounds.Height - tabBounds.Bottom - bottom);
            }
            else
            {
                if (tabBounds.Bottom <= 0)
                    return;
                int y = this._TabControl.GetPageBounds(index).Location.Y;
                if (tabBounds.Y >= y)
                    return;
                tabBounds.Height = checked(tabBounds.Height - y - tabBounds.Y);
                tabBounds.Y = y;
            }
        }

        protected virtual Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)null;
            Color.FromArgb(207, 207, 207);
            Color.FromArgb(242, 242, 242);
            Color color1 = Color.FromArgb(50, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            Color color2 = Color.FromArgb(50, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            if (this._TabControl.SelectedIndex == index)
            {
                color1 = Color.Transparent;
                color2 = Color.Transparent;
            }
            else if (this._TabControl.TabPages[index].Enabled && this._HotTrack)
            {
                int activeIndex = this._TabControl.ActiveIndex;
            }
            Rectangle tabRect = this.GetTabRect(index);
            tabRect.Inflate(3, 3);
            tabRect.X = checked(tabRect.X - 1);
            tabRect.Y = checked(tabRect.Y - 1);
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color2, color1, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Bottom:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color2, color1, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Left:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color1, color2, LinearGradientMode.Horizontal);
                    break;
                case TabAlignment.Right:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color2, color1, LinearGradientMode.Horizontal);
                    break;
            }
            linearGradientBrush.Blend = this.GetBackgroundBlend();
            return (Brush)linearGradientBrush;
        }

        public void PaintTab(int index, Graphics graphics)
        {
            using (GraphicsPath tabBorder = this.GetTabBorder(index))
            {
                using (Brush tabBackgroundBrush = this.GetTabBackgroundBrush(index))
                {
                    graphics.FillPath(tabBackgroundBrush, tabBorder);
                    this.DrawTabCloser(index, graphics);
                }
            }
        }

        protected virtual void DrawTabCloser(int index, Graphics graphics)
        {
            if (!this._ShowTabCloser)
                return;
            Rectangle tabCloserRect = this._TabControl.GetTabCloserRect(index);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath closerPath = GetCloserPath(tabCloserRect))
            {
                if (tabCloserRect.Contains(this._TabControl.MousePosition))
                {
                    using (Pen pen = new Pen(this._CloserColorActive))
                        graphics.DrawPath(pen, closerPath);
                }
                else
                {
                    using (Pen pen = new Pen(this._CloserColor))
                        graphics.DrawPath(pen, closerPath);
                }
            }
        }

        protected static GraphicsPath GetCloserPath(Rectangle closerRect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int x1 = closerRect.X;
            int y1 = closerRect.Y;
            int right1 = closerRect.Right;
            int bottom1 = closerRect.Bottom;
            graphicsPath.AddLine(x1, y1, right1, bottom1);
            graphicsPath.CloseFigure();
            int right2 = closerRect.Right;
            int y2 = closerRect.Y;
            int x2 = closerRect.X;
            int bottom2 = closerRect.Bottom;
            graphicsPath.AddLine(right2, y2, x2, bottom2);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        private void DrawTabFocusIndicator(GraphicsPath tabpath, int index, Graphics graphics)
        {
            if (!this._FocusTrack || !this._TabControl.Focused || index != this._TabControl.SelectedIndex)
                return;
            Brush brush = (Brush)null;
            RectangleF bounds = tabpath.GetBounds();
            Rectangle rect = Rectangle.Empty;
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    rect = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X))), checked((int)Math.Round(Math.Truncate((double)bounds.Y))), checked((int)Math.Round(Math.Truncate((double)bounds.Width))), 4);
                    brush = (Brush)new LinearGradientBrush(rect, this._FocusColor, SystemColors.Window, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Bottom:
                    rect = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X))), checked((int)Math.Round(Math.Truncate((double)bounds.Bottom)) - 4), checked((int)Math.Round(Math.Truncate((double)bounds.Width))), 4);
                    brush = (Brush)new LinearGradientBrush(rect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Left:
                    rect = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.X))), checked((int)Math.Round(Math.Truncate((double)bounds.Y))), 4, checked((int)Math.Round(Math.Truncate((double)bounds.Height))));
                    brush = (Brush)new LinearGradientBrush(rect, this._FocusColor, SystemColors.ControlLight, LinearGradientMode.Horizontal);
                    break;
                case TabAlignment.Right:
                    rect = new Rectangle(checked((int)Math.Round(Math.Truncate((double)bounds.Right)) - 4), checked((int)Math.Round(Math.Truncate((double)bounds.Y))), 4, checked((int)Math.Round(Math.Truncate((double)bounds.Height))));
                    brush = (Brush)new LinearGradientBrush(rect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Horizontal);
                    break;
            }
            Region region = new Region(rect);
            region.Intersect(tabpath);
            graphics.FillRegion(brush, region);
            region.Dispose();
            brush.Dispose();
        }

        private Blend GetBackgroundBlend()
        {
            float[] numArray1 = new float[3];
            int index1 = 1;
            double num1 = 0.699999988079071;
            numArray1[index1] = (float)num1;
            int index2 = 2;
            double num2 = 1.0;
            numArray1[index2] = (float)num2;
            float[] numArray2 = numArray1;
            float[] numArray3 = new float[3];
            int index3 = 1;
            double num3 = 0.600000023841858;
            numArray3[index3] = (float)num3;
            int index4 = 2;
            double num4 = 1.0;
            numArray3[index4] = (float)num4;
            float[] numArray4 = numArray3;
            if (this._TabControl.Alignment == TabAlignment.Top)
            {
                numArray2 = new float[4]
                {
          0.0f,
          0.5f,
          1f,
          1f
                };
                numArray4 = new float[4]
                {
          0.0f,
          0.5f,
          0.51f,
          1f
                };
            }
            return new Blend()
            {
                Factors = numArray2,
                Positions = numArray4
            };
        }

        public virtual Brush GetPageBackgroundBrush(int index)
        {
            Color.FromArgb(242, 242, 242);
            Color transparent1 = Color.Transparent;
            Color transparent2 = Color.Transparent;
            Brush brush;
            if (this._TabControl.SelectedIndex == index)
            {
                Color color1 = Color.FromArgb(150, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                Color color2 = Color.FromArgb(250, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                brush = (Brush)new LinearGradientBrush(this.GetTabRect(index), color1, color2, LinearGradientMode.Vertical);
            }
            else
            {
                if (this._TabControl.TabPages[index].Enabled && this._HotTrack)
                {
                    int activeIndex = this._TabControl.ActiveIndex;
                }
                brush = (Brush)new SolidBrush(transparent2);
            }
            return brush;
        }

        public virtual Brush GetNewAlertBackgroundBrush(int index)
        {
            Color orange1 = Color.Orange;
            Color orange2 = Color.Orange;
            return this._TabControl.TabPages[index] == null ? this.GetPageBackgroundBrush(index) : (Brush)new LinearGradientBrush(this.GetTabRect(index), orange1, orange2, LinearGradientMode.Vertical);
        }

        public GraphicsPath GetTabBorder(int index)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle tabRect = this.GetTabRect(index);
            this.AddTabBorder(path, tabRect);
            path.CloseFigure();
            return path;
        }
    }
}
