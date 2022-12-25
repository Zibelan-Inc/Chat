// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleIE8Provider
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
    public class TabStyleIE8Provider : TabStyleRoundedProvider
    {
        public TabStyleIE8Provider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._Radius = 3;
            this._ShowTabCloser = true;
            this._CloserColorActive = Color.Red;
            this.Padding = new Point(6, 5);
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
                            tabRect.Y = checked(tabRect.Y - 1);
                            tabRect.Height = checked(tabRect.Height + 1);
                            if (flag)
                            {
                                tabRect.Width = checked(tabRect.Width + 1);
                                break;
                            }
                            tabRect.X = checked(tabRect.X - 1);
                            tabRect.Width = checked(tabRect.Width + 2);
                            break;
                        case TabAlignment.Bottom:
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
                            tabRect.X = checked(tabRect.X - 1);
                            tabRect.Width = checked(tabRect.Width + 1);
                            if (flag)
                            {
                                tabRect.Height = checked(tabRect.Height + 1);
                                break;
                            }
                            tabRect.Y = checked(tabRect.Y - 1);
                            tabRect.Height = checked(tabRect.Height + 2);
                            break;
                        case TabAlignment.Right:
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

        protected override Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)null;
            Color color1 = Color.FromArgb(227, 238, 251);
            Color color2 = Color.FromArgb(227, 238, 251);
            if (this._TabControl.SelectedIndex == index)
            {
                color1 = Color.FromArgb(196, 222, 251);
                color2 = SystemColors.Window;
            }
            else if (!this._TabControl.TabPages[index].Enabled)
                color2 = color1;
            else if (this.HotTrack && index == this._TabControl.ActiveIndex)
            {
                color2 = SystemColors.Window;
                color1 = Color.FromArgb(166, 203, 248);
            }
            Rectangle tabRect = this.GetTabRect(index);
            tabRect.Inflate(3, 3);
            tabRect.X = checked(tabRect.X - 1);
            tabRect.Y = checked(tabRect.Y - 1);
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    linearGradientBrush = new LinearGradientBrush(tabRect, color1, color2, LinearGradientMode.Vertical);
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
            linearGradientBrush.Blend = this.GetBackgroundBlend(index);
            return (Brush)linearGradientBrush;
        }

        private Blend GetBackgroundBlend(int index)
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
            double num3 = 0.800000011920929;
            numArray3[index3] = (float)num3;
            int index4 = 2;
            double num4 = 1.0;
            numArray3[index4] = (float)num4;
            float[] numArray4 = numArray3;
            if (this._TabControl.SelectedIndex != index)
            {
                float[] numArray5 = new float[3];
                int index5 = 1;
                double num5 = 0.300000011920929;
                numArray5[index5] = (float)num5;
                int index6 = 2;
                double num6 = 1.0;
                numArray5[index6] = (float)num6;
                numArray2 = numArray5;
                float[] numArray6 = new float[3];
                int index7 = 1;
                double num7 = 0.200000002980232;
                numArray6[index7] = (float)num7;
                int index8 = 2;
                double num8 = 1.0;
                numArray6[index8] = (float)num8;
                numArray4 = numArray6;
            }
            return new Blend()
            {
                Factors = numArray2,
                Positions = numArray4
            };
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
                    using (Pen pen = new Pen(this.BorderColor))
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
            else
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

        public override Brush GetPageBackgroundBrush(int index)
        {
            Color color = Color.FromArgb(227, 238, 251);
            if (this._TabControl.SelectedIndex == index)
                color = SystemColors.Window;
            else if (!this._TabControl.TabPages[index].Enabled)
                color = Color.FromArgb(207, 207, 207);
            else if (this._HotTrack && index == this._TabControl.ActiveIndex)
                color = Color.FromArgb(234, 246, 253);
            return (Brush)new SolidBrush(color);
        }
    }
}
