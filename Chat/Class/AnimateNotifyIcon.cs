using System;
using System.Drawing;
using System.Windows.Forms;
using Chat.Properties;

namespace Chat.Class
{
    class AnimateNotifyIcon
    {
        static Timer AnimationTimer = new Timer();
        static NotifyIcon notifyIcon;
        static Icon[] Icons;
        static int IconCount;
        static int thisIcon;

        public static void Animate(NotifyIcon notify, frmMain frm, Icon[] animation, int interval)
        {
            AnimationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            notifyIcon = notify;
            thisIcon = 0;
            IconCount = animation.Length;
            Icons = animation;
            AnimationTimer.Interval = interval;
            AnimationTimer.Start();
        }

        public static void StopAnimation()
        {
            try { if (AnimationTimer.Enabled) AnimationTimer.Enabled = false; } catch { }

            //notifyIcon.Icon = Resources.SC_ICO;
            frmMain.frm.Icon = Resources.SC_ICO;
        }
        private static void AnimationTimer_Tick(object sender, EventArgs e)
        {
            AnimationTimer.Enabled = true;

            //notifyIcon.Icon = Icons[thisIcon];
            frmMain.frm.Icon = Icons[thisIcon];

            thisIcon++;
            if (thisIcon == IconCount)
                thisIcon = 0;
        }

    }
}

