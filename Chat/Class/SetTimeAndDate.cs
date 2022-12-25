using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Chat.Class
{
    public class SetTimeAndDate
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetLocalTime(ref SYSTEMTIME lpSystemTime);

        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
        }

        public static void SetTime(int wYear, int wMonth, int wDay, int wHour, int wMinute)
        {
            try
            {
                SYSTEMTIME systime = new SYSTEMTIME();
                systime.wYear = (ushort)wYear;
                systime.wMonth = (ushort)wMonth;
                systime.wDay = (ushort)wDay;
                systime.wHour = (ushort)wHour;
                systime.wMinute = (ushort)wMinute;

                SetLocalTime(ref systime);

                if (DateTime.Now.Hour != wHour && DateTime.Now.Minute != wMinute)
                    SetCMDTime(wYear, wMonth, wDay, wHour, wMinute);

            } catch (Exception ex) { WriteLog.Save(ex); }
        }

        public static void SetCMDTime(int wYear, int wMonth, int wDay, int wHour, int wMinute)
        {
            try
            {
                Process CMDDateTime = new Process();
                CMDDateTime.StartInfo.UseShellExecute = false;
                CMDDateTime.StartInfo.FileName = "cmd";
                CMDDateTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                CMDDateTime.StartInfo.RedirectStandardInput = true;
                CMDDateTime.StartInfo.RedirectStandardOutput = true;
                CMDDateTime.StartInfo.CreateNoWindow = true;
                CMDDateTime.Start();
                CMDDateTime.StandardInput.WriteLine("date " + wDay.ToString() + "/" + wMonth.ToString() + "/" + wYear.ToString());
                CMDDateTime.StandardInput.WriteLine("time " + wHour.ToString() + ":" + wMinute.ToString() + ":" + "00");
                CMDDateTime.StandardInput.Flush();
                CMDDateTime.StandardInput.Close();
                CMDDateTime.Close();
            }   catch (Exception ex) { WriteLog.Save(ex); }
        }

    }
}
