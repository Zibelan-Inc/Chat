// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleChromeProvider
// Assembly: OM.Tab, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: C7A83F57-9985-40B8-B1FF-D32876037FE5
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OM.Tab.DLL

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Chat;
using Chat.Properties;

namespace System.Windows.Forms
{
    [ToolboxItem(false)]
    public class TabStyleChromeProvider : TabStyleProvider
    {
        public TabStyleChromeProvider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._Overlap = 16;
            this._Radius = 16;
            this._ShowTabCloser = true;
            this._CloserColorActive = Color.White;
            this._BorderColor = Color.FromArgb(40, 153, 153, 153);
            this._BorderColorHot = Color.FromArgb(40, 153, 153, 153);
            this._TextColor = ColorTranslator.FromHtml("#373738");
            this._TextColorSelected = this._TextColor;
            this.Padding = new Point(5, 5);
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            if (this._TabControl.Alignment <= TabAlignment.Bottom)
            {
                num1 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Height), new Decimal(2L)), new Decimal(3L)))));
                num2 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Height), Decimal.One), new Decimal(8L)))));
                num3 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Height), Decimal.One), new Decimal(6L)))));
                num4 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Height), Decimal.One), new Decimal(4L)))));
            }
            else
            {
                num1 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Width), new Decimal(2L)), new Decimal(3L)))));
                num2 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Width), Decimal.One), new Decimal(8L)))));
                num3 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Width), Decimal.One), new Decimal(6L)))));
                num4 = Convert.ToInt32(Math.Truncate(Math.Floor(Decimal.Divide(Decimal.Multiply(new Decimal(tabBounds.Width), Decimal.One), new Decimal(4L)))));
            }
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    GraphicsPath graphicsPath1 = path;
                    Point[] points1 = new Point[4];
                    int index1 = 0;
                    Point point1 = new Point(checked(tabBounds.X - num4), tabBounds.Bottom);
                    points1[index1] = point1;
                    int index2 = 1;
                    Point point2 = new Point(checked(tabBounds.X + num3), checked(tabBounds.Bottom - num2));
                    points1[index2] = point2;
                    int index3 = 2;
                    Point point3 = new Point(checked(tabBounds.X + num1 - num4), checked(tabBounds.Y + num2));
                    points1[index3] = point3;
                    int index4 = 3;
                    Point point4 = new Point(checked(tabBounds.X + num1), tabBounds.Y);
                    points1[index4] = point4;
                    graphicsPath1.AddCurve(points1);
                    path.AddLine(checked(tabBounds.X + num1), tabBounds.Y, checked(tabBounds.Right - num1), tabBounds.Y);
                    GraphicsPath graphicsPath2 = path;
                    Point[] points2 = new Point[4];
                    int index5 = 0;
                    Point point5 = new Point(checked(tabBounds.Right - num1), tabBounds.Y);
                    points2[index5] = point5;
                    int index6 = 1;
                    Point point6 = new Point(checked(tabBounds.Right - num1 + num4), checked(tabBounds.Y + num2));
                    points2[index6] = point6;
                    int index7 = 2;
                    Point point7 = new Point(checked(tabBounds.Right - num3), checked(tabBounds.Bottom - num2));
                    points2[index7] = point7;
                    int index8 = 3;
                    Point point8 = new Point(checked(tabBounds.Right + num4), tabBounds.Bottom);
                    points2[index8] = point8;
                    graphicsPath2.AddCurve(points2);
                    break;
                case TabAlignment.Bottom:
                    GraphicsPath graphicsPath3 = path;
                    Point[] points3 = new Point[4];
                    int index9 = 0;
                    Point point9 = new Point(tabBounds.Right, tabBounds.Y);
                    points3[index9] = point9;
                    int index10 = 1;
                    Point point10 = new Point(checked(tabBounds.Right - num3), checked(tabBounds.Y + num2));
                    points3[index10] = point10;
                    int index11 = 2;
                    Point point11 = new Point(checked(tabBounds.Right - num1 + num4), checked(tabBounds.Bottom - num2));
                    points3[index11] = point11;
                    int index12 = 3;
                    Point point12 = new Point(checked(tabBounds.Right - num1), tabBounds.Bottom);
                    points3[index12] = point12;
                    graphicsPath3.AddCurve(points3);
                    path.AddLine(checked(tabBounds.Right - num1), tabBounds.Bottom, checked(tabBounds.X + num1), tabBounds.Bottom);
                    GraphicsPath graphicsPath4 = path;
                    Point[] points4 = new Point[4];
                    int index13 = 0;
                    Point point13 = new Point(checked(tabBounds.X + num1), tabBounds.Bottom);
                    points4[index13] = point13;
                    int index14 = 1;
                    Point point14 = new Point(checked(tabBounds.X + num1 - num4), checked(tabBounds.Bottom - num2));
                    points4[index14] = point14;
                    int index15 = 2;
                    Point point15 = new Point(checked(tabBounds.X + num3), checked(tabBounds.Y + num2));
                    points4[index15] = point15;
                    int index16 = 3;
                    Point point16 = new Point(tabBounds.X, tabBounds.Y);
                    points4[index16] = point16;
                    graphicsPath4.AddCurve(points4);
                    break;
                case TabAlignment.Left:
                    GraphicsPath graphicsPath5 = path;
                    Point[] points5 = new Point[4];
                    int index17 = 0;
                    Point point17 = new Point(tabBounds.Right, tabBounds.Bottom);
                    points5[index17] = point17;
                    int index18 = 1;
                    Point point18 = new Point(checked(tabBounds.Right - num2), checked(tabBounds.Bottom - num3));
                    points5[index18] = point18;
                    int index19 = 2;
                    Point point19 = new Point(checked(tabBounds.X + num2), checked(tabBounds.Bottom - num1 + num4));
                    points5[index19] = point19;
                    int index20 = 3;
                    Point point20 = new Point(tabBounds.X, checked(tabBounds.Bottom - num1));
                    points5[index20] = point20;
                    graphicsPath5.AddCurve(points5);
                    path.AddLine(tabBounds.X, checked(tabBounds.Bottom - num1), tabBounds.X, checked(tabBounds.Y + num1));
                    GraphicsPath graphicsPath6 = path;
                    Point[] points6 = new Point[4];
                    int index21 = 0;
                    Point point21 = new Point(tabBounds.X, checked(tabBounds.Y + num1));
                    points6[index21] = point21;
                    int index22 = 1;
                    Point point22 = new Point(checked(tabBounds.X + num2), checked(tabBounds.Y + num1 - num4));
                    points6[index22] = point22;
                    int index23 = 2;
                    Point point23 = new Point(checked(tabBounds.Right - num2), checked(tabBounds.Y + num3));
                    points6[index23] = point23;
                    int index24 = 3;
                    Point point24 = new Point(tabBounds.Right, tabBounds.Y);
                    points6[index24] = point24;
                    graphicsPath6.AddCurve(points6);
                    break;
                case TabAlignment.Right:
                    GraphicsPath graphicsPath7 = path;
                    Point[] points7 = new Point[4];
                    int index25 = 0;
                    Point point25 = new Point(tabBounds.X, tabBounds.Y);
                    points7[index25] = point25;
                    int index26 = 1;
                    Point point26 = new Point(checked(tabBounds.X + num2), checked(tabBounds.Y + num3));
                    points7[index26] = point26;
                    int index27 = 2;
                    Point point27 = new Point(checked(tabBounds.Right - num2), checked(tabBounds.Y + num1 - num4));
                    points7[index27] = point27;
                    int index28 = 3;
                    Point point28 = new Point(tabBounds.Right, checked(tabBounds.Y + num1));
                    points7[index28] = point28;
                    graphicsPath7.AddCurve(points7);
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + num1), tabBounds.Right, checked(tabBounds.Bottom - num1));
                    GraphicsPath graphicsPath8 = path;
                    Point[] points8 = new Point[4];
                    int index29 = 0;
                    Point point29 = new Point(tabBounds.Right, checked(tabBounds.Bottom - num1));
                    points8[index29] = point29;
                    int index30 = 1;
                    Point point30 = new Point(checked(tabBounds.Right - num2), checked(tabBounds.Bottom - num1 + num4));
                    points8[index30] = point30;
                    int index31 = 2;
                    Point point31 = new Point(checked(tabBounds.X + num2), checked(tabBounds.Bottom - num3));
                    points8[index31] = point31;
                    int index32 = 3;
                    Point point32 = new Point(tabBounds.X, tabBounds.Bottom);
                    points8[index32] = point32;
                    graphicsPath8.AddCurve(points8);
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
                graphics.DrawImage(Chat.Properties.Resources.closegc1, tabCloserRect);
            else
                graphics.DrawImage(Chat.Properties.Resources.closegc, tabCloserRect);
        }

        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Rectangle rect = new Rectangle(checked(closerRect.X - 2), checked(closerRect.Y - 2), checked(closerRect.Width + 4), checked(closerRect.Height + 4));
            graphicsPath.AddEllipse(rect);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
    }
}

