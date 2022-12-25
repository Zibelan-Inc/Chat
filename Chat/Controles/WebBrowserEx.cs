using System.Windows.Forms;

namespace Chat.Forms
{
    public class WebBrowserEx : WebBrowser
    {
        public WebBrowserEx()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}