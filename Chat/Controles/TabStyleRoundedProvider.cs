// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleRoundedProvider
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
    public class TabStyleRoundedProvider : TabStyleProvider
    {
        public TabStyleRoundedProvider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._Radius = 10;
            this._ShowTabCloser = true;
            this._CloserColorActive = Color.Black;
            this._CloserColor = Color.FromArgb(117, 99, 61);
            this.Padding = new Point(6, 3);
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X, checked(tabBounds.Y + this._Radius));
                    path.AddArc(tabBounds.X, tabBounds.Y, checked(this._Radius * 2), checked(this._Radius * 2), 180f, 90f);
                    path.AddLine(checked(tabBounds.X + this._Radius), tabBounds.Y, checked(tabBounds.Right - this._Radius), tabBounds.Y);
                    path.AddArc(checked(tabBounds.Right - this._Radius * 2), tabBounds.Y, checked(this._Radius * 2), checked(this._Radius * 2), 270f, 90f);
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + this._Radius), tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, checked(tabBounds.Bottom - this._Radius));
                    path.AddArc(checked(tabBounds.Right - this._Radius * 2), checked(tabBounds.Bottom - this._Radius * 2), checked(this._Radius * 2), checked(this._Radius * 2), 0.0f, 90f);
                    path.AddLine(checked(tabBounds.Right - this._Radius), tabBounds.Bottom, checked(tabBounds.X + this._Radius), tabBounds.Bottom);
                    path.AddArc(tabBounds.X, checked(tabBounds.Bottom - this._Radius * 2), checked(this._Radius * 2), checked(this._Radius * 2), 90f, 90f);
                    path.AddLine(tabBounds.X, checked(tabBounds.Bottom - this._Radius), tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, checked(tabBounds.X + this._Radius), tabBounds.Bottom);
                    path.AddArc(tabBounds.X, checked(tabBounds.Bottom - this._Radius * 2), checked(this._Radius * 2), checked(this._Radius * 2), 90f, 90f);
                    path.AddLine(tabBounds.X, checked(tabBounds.Bottom - this._Radius), tabBounds.X, checked(tabBounds.Y + this._Radius));
                    path.AddArc(tabBounds.X, tabBounds.Y, checked(this._Radius * 2), checked(this._Radius * 2), 180f, 90f);
                    path.AddLine(checked(tabBounds.X + this._Radius), tabBounds.Y, tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, checked(tabBounds.Right - this._Radius), tabBounds.Y);
                    path.AddArc(checked(tabBounds.Right - this._Radius * 2), tabBounds.Y, checked(this._Radius * 2), checked(this._Radius * 2), 270f, 90f);
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + this._Radius), tabBounds.Right, checked(tabBounds.Bottom - this._Radius));
                    path.AddArc(checked(tabBounds.Right - this._Radius * 2), checked(tabBounds.Bottom - this._Radius * 2), checked(this._Radius * 2), checked(this._Radius * 2), 0.0f, 90f);
                    path.AddLine(checked(tabBounds.Right - this._Radius), tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }

        protected override void DrawTabCloser(int index, Graphics graphics)
        {
            if (!this._ShowTabCloser)
                return;
            Rectangle tabCloserRect = this._TabControl.GetTabCloserRect(index);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (tabCloserRect.Contains(this._TabControl.MousePosition))
            {
                using (GraphicsPath closerButtonPath = GetCloserButtonPath(tabCloserRect))
                {
                    graphics.FillPath(Brushes.White, closerButtonPath);
                    using (Pen pen = new Pen(Color.FromArgb(229, 195, 101)))
                        graphics.DrawPath(pen, closerButtonPath);
                }
                using (GraphicsPath closerPath = GetCloserPath(tabCloserRect))
                {
                    using (Pen pen = new Pen(this._CloserColorActive))
                    {
                        pen.Width = 2f;
                        graphics.DrawPath(pen, closerPath);
                    }
                }
            }
            else if (index == this._TabControl.SelectedIndex)
            {
                using (GraphicsPath closerPath = GetCloserPath(tabCloserRect))
                {
                    using (Pen pen = new Pen(this._CloserColor))
                    {
                        pen.Width = 2f;
                        graphics.DrawPath(pen, closerPath);
                    }
                }
            }
            else
            {
                if (index != this._TabControl.ActiveIndex)
                    return;
                using (GraphicsPath closerPath = GetCloserPath(tabCloserRect))
                {
                    using (Pen pen = new Pen(Color.FromArgb(155, 167, 183)))
                    {
                        pen.Width = 2f;
                        graphics.DrawPath(pen, closerPath);
                    }
                }
            }
        }

        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int x1_1 = checked(closerRect.X - 1);
            int y1_1 = checked(closerRect.Y - 2);
            int x2_1 = checked(closerRect.Right + 1);
            int y2_1 = checked(closerRect.Y - 2);
            graphicsPath.AddLine(x1_1, y1_1, x2_1, y2_1);
            int x1_2 = checked(closerRect.Right + 2);
            int y1_2 = checked(closerRect.Y - 1);
            int x2_2 = checked(closerRect.Right + 2);
            int y2_2 = checked(closerRect.Bottom + 1);
            graphicsPath.AddLine(x1_2, y1_2, x2_2, y2_2);
            int x1_3 = checked(closerRect.Right + 1);
            int y1_3 = checked(closerRect.Bottom + 2);
            int x2_3 = checked(closerRect.X - 1);
            int y2_3 = checked(closerRect.Bottom + 2);
            graphicsPath.AddLine(x1_3, y1_3, x2_3, y2_3);
            int x1_4 = checked(closerRect.X - 2);
            int y1_4 = checked(closerRect.Bottom + 1);
            int x2_4 = checked(closerRect.X - 2);
            int y2_4 = checked(closerRect.Y - 1);
            graphicsPath.AddLine(x1_4, y1_4, x2_4, y2_4);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
    }
}

