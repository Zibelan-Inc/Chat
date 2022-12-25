using System.Reflection;
using System.Windows.Forms;

namespace Chat.Controles
{
    class SplitterBorderlessEx : Splitter
    {
        public SplitterBorderlessEx()
        {
            this.DoubleBuffered = true;
            MethodInfo method = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = new object[] { ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true };
            method.Invoke(this, parameters);
        }


    }
}
