using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Chat;

namespace System.Windows.Forms
{
    [ToolboxItem(false)]
    public class TabStyleDefaultProvider : TabStyleProvider
    {
        public TabStyleDefaultProvider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._FocusTrack = true;
            this._Radius = 2;
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X, tabBounds.Y);
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y);
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom);
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X, tabBounds.Y);
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y);
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom);
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }

        public override Rectangle GetTabRect(int index)
        {
            Rectangle rectangle;
            if (index < 0)
            {
                rectangle = new Rectangle();
            }
            else
            {
                Rectangle tabRect = base.GetTabRect(index);
                bool flag = this._TabControl.IsFirstTabInRow(index);
                if (index != this._TabControl.SelectedIndex)
                {
                    switch (this._TabControl.Alignment)
                    {
                        case TabAlignment.Top:
                            tabRect.Y = checked(tabRect.Y + 1);
                            tabRect.Height = checked(tabRect.Height - 1);
                            break;
                        case TabAlignment.Bottom:
                            tabRect.Height = checked(tabRect.Height - 1);
                            break;
                        case TabAlignment.Left:
                            tabRect.X = checked(tabRect.X + 1);
                            tabRect.Width = checked(tabRect.Width - 1);
                            break;
                        case TabAlignment.Right:
                            tabRect.Width = checked(tabRect.Width - 1);
                            break;
                    }
                }
                else
                {
                    switch (this._TabControl.Alignment)
                    {
                        case TabAlignment.Top:
                            if (tabRect.Y > 0)
                            {
                                tabRect.Y = checked(tabRect.Y - 1);
                                tabRect.Height = checked(tabRect.Height + 1);
                            }
                            if (flag)
                            {
                                tabRect.Width = checked(tabRect.Width + 1);
                                break;
                            }
                            tabRect.X = checked(tabRect.X - 1);
                            tabRect.Width = checked(tabRect.Width + 2);
                            break;
                        case TabAlignment.Bottom:
                            if (tabRect.Bottom < this._TabControl.Bottom)
                                tabRect.Height = checked(tabRect.Height + 1);
                            if (flag)
                            {
                                tabRect.Width = checked(tabRect.Width + 1);
                                break;
                            }
                            tabRect.X = checked(tabRect.X - 1);
                            tabRect.Width = checked(tabRect.Width + 2);
                            break;
                        case TabAlignment.Left:
                            if (tabRect.X > 0)
                            {
                                tabRect.X = checked(tabRect.X - 1);
                                tabRect.Width = checked(tabRect.Width + 1);
                            }
                            if (flag)
                            {
                                tabRect.Height = checked(tabRect.Height + 1);
                                break;
                            }
                            tabRect.Y = checked(tabRect.Y - 1);
                            tabRect.Height = checked(tabRect.Height + 2);
                            break;
                        case TabAlignment.Right:
                            if (tabRect.Right < this._TabControl.Right)
                                tabRect.Width = checked(tabRect.Width + 1);
                            if (flag)
                            {
                                tabRect.Height = checked(tabRect.Height + 1);
                                break;
                            }
                            tabRect.Y = checked(tabRect.Y - 1);
                            tabRect.Height = checked(tabRect.Height + 2);
                            break;
                    }
                }
                this.EnsureFirstTabIsInView(ref tabRect, index);
                rectangle = tabRect;
            }
            return rectangle;
        }
    }
}
