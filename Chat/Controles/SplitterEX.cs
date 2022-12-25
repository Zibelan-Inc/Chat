using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Chat.Controles
{
    public class SplitterEX : Splitter
    {
        public SplitterEX()
        {
            DoubleBuffered = true;
            MethodInfo method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            object[] parameters = new object[2]
            {
            ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
            true
            };
            method.Invoke(this, parameters);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = default(Rectangle);
            Rectangle rectangle2 = default(Rectangle);
            Rectangle clipRectangle = e.ClipRectangle;
            rectangle = new Rectangle(clipRectangle.X, clipRectangle.Y, clipRectangle.Width, base.Height);
            rectangle2 = checked(new Rectangle(clipRectangle.X, clipRectangle.Y + 2, clipRectangle.Width, base.Height - 4));
            using (SolidBrush brush2 = new SolidBrush(BackColor))
            {
                SolidBrush brush = new SolidBrush(Template.BACKGROUND_COLOR);
                e.Graphics.FillRectangle(brush, rectangle);
                e.Graphics.FillRectangle(brush2, rectangle2);
            }
        }
    }
}
