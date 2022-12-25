// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleVS2010Provider
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
    public class TabStyleVS2010Provider : TabStyleRoundedProvider
    {
        public TabStyleVS2010Provider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._Radius = 3;
            this._ShowTabCloser = true;
            this._CloserColorActive = Color.Black;
            this._CloserColor = Color.FromArgb(117, 99, 61);
            this._TextColor = Color.White;
            this._TextColorDisabled = Color.WhiteSmoke;
            this._BorderColor = Color.Transparent;
            this._BorderColorHot = Color.FromArgb(155, 167, 183);
            this.Padding = new Point(6, 5);
        }

        protected override Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)null;
            Color color1 = Color.Transparent;
            Color color2 = Color.Transparent;
            if (this._TabControl.SelectedIndex == index)
            {
                color1 = Color.FromArgb(229, 195, 101);
                color2 = SystemColors.Window;
            }
            else if (!this._TabControl.TabPages[index].Enabled)
                color2 = color1;
            else if (this.HotTrack && index == this._TabControl.ActiveIndex)
            {
                color1 = Color.FromArgb(108, 116, 118);
                color2 = color1;
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
                    linearGradientBrush = new LinearGradientBrush(tabRect, color1, color2, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Left:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color2, color1, LinearGradientMode.Horizontal);
                    break;
                case TabAlignment.Right:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color1, color2, LinearGradientMode.Horizontal);
                    break;
            }
            linearGradientBrush.Blend = GetBackgroundBlend();
            return (Brush)linearGradientBrush;
        }

        private static Blend GetBackgroundBlend()
        {
            float[] numArray1 = new float[4]
            {
        0.0f,
        0.5f,
        1f,
        1f
            };
            float[] numArray2 = new float[4]
            {
        0.0f,
        0.5f,
        0.51f,
        1f
            };
            return new Blend()
            {
                Factors = numArray1,
                Positions = numArray2
            };
        }

        public override Brush GetPageBackgroundBrush(int index)
        {
            Color color = Color.Transparent;
            if (this._TabControl.SelectedIndex == index)
                color = Color.FromArgb(229, 195, 101);
            else if (!this._TabControl.TabPages[index].Enabled)
                color = Color.Transparent;
            else if (this._HotTrack && index == this._TabControl.ActiveIndex)
                color = Color.Transparent;
            return (Brush)new SolidBrush(color);
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

