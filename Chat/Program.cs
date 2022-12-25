using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Chat
{
    static class Program
    {
        public static bool Report { get; internal set; } = false;
        public static bool Launched { get; set; } = false;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                    if (args[0].ToLower() == "report")
                        Report = true;
            } catch { }

            int num = 0;
            Process[] processes = Process.GetProcesses();
            Process[] array = processes;
            foreach (Process process in array)
            {
                if (process.ProcessName == Process.GetCurrentProcess().ProcessName) //"KosmoChat"
                {
                    int num2 = num;
                    num = num2 + 1;
                }
            }
            if (num <= 1)
            {
                try
                {
                    if (Launched)
                        return;

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(defaultValue: false);
                    Application.Run(new frmMain());
                    Launched = true;
                }
                catch { }
            }
            else
            {
                PrevApplication();
            }
        }
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);
        public static void PrevApplication()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\KosmoChat\\Windows", writable: true);
                registryKey.GetValue("ChatID", RegistryValueKind.String);
                string value = (string)registryKey.GetValue("ChatID");

                if (string.IsNullOrEmpty(value))
                    value = "0";
                else if (value == "")
                    value = "0";

                int num = Convert.ToInt32(value);
                if (num > 0 && IsWindow((IntPtr)num))
                {
                    ShowWindow((IntPtr)num, 1);
                    SetForegroundWindow((IntPtr)num);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
    }
}
