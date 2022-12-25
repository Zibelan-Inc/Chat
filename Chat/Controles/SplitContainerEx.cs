// Decompiled with JetBrains decompiler
// Type: OutputMessenger.SplitContainerEx
// Assembly: OutputMessenger, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: ACB4D6A8-252D-43BA-9D59-AF7222307917
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OutputMessenger.exe

using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Chat
{
  public class SplitContainerEx : SplitContainer
  {
        public SplitContainerEx()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            MethodInfo method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            object[] parameters = new object[2]
            {
            ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
            true
            };
            method.Invoke(base.Panel1, parameters);
            method.Invoke(base.Panel2, parameters);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = default(Rectangle);
            base.SplitterWidth = 5;
            rectangle = new Rectangle(base.SplitterDistance, 0, checked(base.SplitterWidth - 4), base.Height);
            using (SolidBrush brush = new SolidBrush(Template.PANEL_SPLIT_COLOR))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }
        }
    }
}
