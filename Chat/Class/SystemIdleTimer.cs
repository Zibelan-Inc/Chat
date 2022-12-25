using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat.Class
{
    public class SystemIdleTimer
    {
        private static Timer _idleTimer;
        private static bool _RecentlyOpen;
        public static void StartTimer()
        {
            try
            {
                _RecentlyOpen = true;
                _idleTimer = new Timer();
                StopTimer();
                _idleTimer = new Timer();
                _idleTimer.Enabled = true;
                _idleTimer.Interval = 1000;
                _idleTimer.Tick += new EventHandler(_idleTimer_Tick);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private static void _idleTimer_Tick(object sender, EventArgs e)
        {
            if(_RecentlyOpen)
            {
                _RecentlyOpen = false;
                return;
            }
            Modcommon.IDLECOUNT = WinMod.GetInactiveTime();
            if (Modcommon.IDLECOUNT > 600 && (frmMain.MyStatus == UserStatus.Activo || frmMain.MyStatus == UserStatus.Online))
            {
                //frmMain.frm.IdleTime = Modcommon.GetTimeIdle();
                //frmMain.SetIdle();
                frmMain.MyStatus = UserStatus.Idle;
            }
            if (Modcommon.IDLECOUNT < 120 && frmMain.MyStatus == UserStatus.Idle)
            {
                if (frmMain.MyStatus != UserStatus.Idle)
                    return;

                frmMain.frm.lblImgstatus.Image = Resources._57;
                frmMain.MyStatus = UserStatus.Activo;
                frmMain.frm.IdleTime = "";
                frmMain.frm.ChangePersonalMessageAndStatus(frmMain.UserId, UserStatus.Activo);

                frmMain.frm.Transmit("Activo");

            }
        }

        public static void SetIdleInterval(short min)
        {
            _idleTimer.Interval = checked((short)((int)min * 60));
        }

        public static void StopTimer()
        {
            if (_idleTimer == null)
                return;
            _idleTimer.Enabled = false;
            _idleTimer = (Timer)null;
        }

    }
}