using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using static Chat.frmMain;


namespace Chat
{
    //Donde dice NickName va RegistryValueKind.String
    class Settings : Variables
    {
        private frmMain frmMain;

        public Settings(frmMain remitente)
        {
            this.frmMain = remitente;
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\", true);
            if (Chat == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\");
            }
            Windows = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            if (Windows == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\Windows");
            }
            User = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\User", true);
            if (User == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\User");
            }
        }
        private frmSettings frmSettings;

        public void CreateKeys()
        {
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\", true);
            if (Chat == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\");
            }
            Windows = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            if (Windows == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\Windows");
            }
            User = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\User", true);
            if (User == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\User");
            }
        }
        public static string GetDirBox()
        {
            string dirBox = "";
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\", true);
            if (Chat == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\");
            }

            try { dirBox = (string)Chat.GetValue("DirBox", RegistryValueKind.String); } catch (Exception ex) { WriteLog.Save(ex); }
            return dirBox;
        }
        private Rectangle rScreen;
        protected const int HWND_TOPMOST = -1;
        protected const int SWP_NOACTIVATE = 16;
        protected const int SW_SHOWNOACTIVATE = 4;
        private string _status;
        private int yy;
        IEnumerator enumerator;

        public static RegistryKey Chat;
        public static RegistryKey Windows;
        public static RegistryKey User;



        public static void GuardarID(object ID)
        {
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            if (Chat == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KosmoChat\Windows");
                Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            }
            Chat.SetValue("ChatID", ID);

        }
        public static void ResetId()
        {
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            if (Chat != null)
            {
                Chat.SetValue("ChatID", 0);
            }
        }




        public void GuardarSettings()
        {
            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat", true);

            CreateKeys();

            try
            {
                if (Environment.CurrentDirectory != @"C:\Windows\system32")
                    Chat.SetValue("Patch", Application.StartupPath);
            }
            catch (Exception ex) { WriteLog.Save(ex); }

            try { Chat.SetValue("DirBox", DirBox); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("LaunchWindowsStart", LaunchWindows); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("OpenFolder", AbrirCarpeta.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("OpenFile", AbrirArchivo); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("NewUser", NuevoUser.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("OfflineUser", DesconectadoUser.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("FileReceived", AchivoRecibido.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("NotifyStatus", NotifyStatus.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("UserMin", UserMin.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("CleanWhenClose", CleanWhenClose.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("UserDateTimeZinc", UserDateTimeZinc.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("DateTimeZinc", DateTimeZinc.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Chat.SetValue("KeyTop", KeyTop); } catch (Exception ex) { WriteLog.Save(ex); }


            try { Windows = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true); } catch (Exception ex) { WriteLog.Save(ex); }

            try { Windows.SetValue("OriginalPosition", PosicionOriginal.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("CenterScreen", CenterScreen.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("GuardarPosicion", GuardarPosicion.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("FormWidth", frmMain.Width.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("FormHeight", frmMain.Height.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("FormLeft", frmMain.Left.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("FormTop", frmMain.Top.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { Windows.SetValue("UserPanel", UserPanel.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            //try { Windows.SetValue("SplitterDistance", frmMain.stcMain.SplitterDistance.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }

            try { User = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\User", true); } catch (Exception ex) { WriteLog.Save(ex); }
            try { User.SetValue("NickName", NickName); } catch (Exception ex) { WriteLog.Save(ex); }
            try { User.SetValue("UserID", UserId); } catch (Exception ex) { WriteLog.Save(ex); }
            try { User.SetValue("UserSelectedColor", UserSelectedColor.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            try { User.SetValue("colorINChat", colorINChat.ToString()); } catch (Exception ex) { WriteLog.Save(ex); }
            
        }
        public void CargarSettings()
        {
            //        SaveSettings.LoadAllSettings("KosmoChat", frmMain);

            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat", true);
            Windows = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\Windows", true);
            User = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat\User", true);


            //Chat
            try
            {
                string FirstRun = (string) Chat.GetValue("FirstRun", RegistryValueKind.String);
                if (FirstRun == null)
                {
                    ResetearConfiguracion();
                    goto Label_1;
                }
            }
            catch
            {
                ResetearConfiguracion();
                goto Label_1;
            }


            try
            {
                string LaunchWindowsStart = (string)Chat.GetValue("LaunchWindowsStart", RegistryValueKind.String);
                LaunchWindows = Modcommon.ConvertToBool(LaunchWindowsStart);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                DirBox = (string)Chat.GetValue("DirBox", RegistryValueKind.String);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string OpenFolder = (string)Chat.GetValue("OpenFolder", RegistryValueKind.String);
                AbrirCarpeta = Modcommon.ConvertToBool(OpenFolder);

            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string OpenFile = (string)Chat.GetValue("OpenFile", RegistryValueKind.String);
                AbrirArchivo = Modcommon.ConvertToBool(OpenFile);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string NewUser = (string)Chat.GetValue("NewUser", RegistryValueKind.String);
                NuevoUser = Modcommon.ConvertToBool(NewUser);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string OfflineUser = (string)Chat.GetValue("OfflineUser", RegistryValueKind.String);
                DesconectadoUser = Modcommon.ConvertToBool(OfflineUser);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string FileReceived = (string)Chat.GetValue("FileReceived", RegistryValueKind.String);
                AchivoRecibido = Modcommon.ConvertToBool(FileReceived);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string notifystatus = (string)Chat.GetValue("NotifyStatus", RegistryValueKind.String);
                NotifyStatus = Modcommon.ConvertToBool(notifystatus);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                UserMin = Convert.ToInt32(Chat.GetValue("UserMin", RegistryValueKind.String));
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                Patch = (string)Chat.GetValue("Patch", RegistryValueKind.String);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            try
            {
                string cleanWhenClose = (string)Chat.GetValue("CleanWhenClose", RegistryValueKind.String);
                CleanWhenClose = Modcommon.ConvertToBool(cleanWhenClose);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            try
            {
                UserDateTimeZinc = (string)Chat.GetValue("UserDateTimeZinc", RegistryValueKind.String);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            try
            {
                string dateTimeZinc = (string)Chat.GetValue("DateTimeZinc", RegistryValueKind.String);
                DateTimeZinc = Modcommon.ConvertToBool(dateTimeZinc);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            try
            {
                KeyTop = (string)Chat.GetValue("KeyTop", RegistryValueKind.String);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            


            //Windows
            try
            {
                string OriginalPosition = (string)Windows.GetValue("OriginalPosition", RegistryValueKind.String);
                PosicionOriginal = Modcommon.ConvertToBool(OriginalPosition);

            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string centerScreen = (string)Windows.GetValue("CenterScreen", RegistryValueKind.String);
                CenterScreen = Modcommon.ConvertToBool(centerScreen);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string userPanel = (string)Windows.GetValue("UserPanel", RegistryValueKind.String);
                UserPanel = Modcommon.ConvertToBool(userPanel);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                string guardarPosicion = (string)Windows.GetValue("GuardarPosicion", RegistryValueKind.String);
                GuardarPosicion = Modcommon.ConvertToBool(guardarPosicion);
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                Modcommon.FormHeight = Convert.ToInt32((string)Windows.GetValue("FormHeight", RegistryValueKind.String));

                if (GuardarPosicion && !PosicionOriginal)
                {
                    frmMain.frm.Height = Modcommon.FormHeight;
                }
            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                Modcommon.FormWidth = Convert.ToInt32((string)Windows.GetValue("FormWidth", RegistryValueKind.String));
                Modcommon.DEFAULT_VIEW_WIDTH = (string)Windows.GetValue("FormWidth", RegistryValueKind.String);

                if (GuardarPosicion && !PosicionOriginal)
                {
                    frmMain.frm.Width = Modcommon.FormWidth;
                }


            }
            catch (Exception ex){ WriteLog.Save(ex); }
            try
            {
                Modcommon.FormLeft = Convert.ToInt32((string)Windows.GetValue("FormLeft", RegistryValueKind.String));

                if (GuardarPosicion && !PosicionOriginal)
                {
                    frmMain.frm.Left = Modcommon.FormLeft;
                }
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            try
            {
                Modcommon.FormTop = Convert.ToInt32((string)Windows.GetValue("FormTop", RegistryValueKind.String));

                if (GuardarPosicion && !PosicionOriginal)
                {
                    frmMain.frm.Top = Modcommon.FormTop;
                }
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            





            if (UserPanel)
            {
                /*
                if (MinSize)
                    frmMain.HideChatPanelWithMinSize(true);
                else
                    frmMain.HideChatPanel(true);
                frmMain.pnlUserPanel.Image = Resources.user_sel;
                */
            }

            

            //User
            try
            {
                string colores = (string) User.GetValue("UserSelectedColor", RegistryValueKind.String);
                if (colores != null)
                    UserSelectedColor = (Convert.ToInt32(colores));
            }
            catch (Exception ex)
            {
                UserSelectedColor = 0;
                WriteLog.Save(ex);
            }
            try
            {
                string nickName = (string) User.GetValue("NickName", NickName); //Donde dice NickName va RegistryValueKind.String
                if (nickName != null)
                    NickName = nickName;
            }
            catch (Exception ex)
            {
                NickName = Environment.UserName;
                WriteLog.Save(ex);
            }
            try
            {
                string userID = (string)User.GetValue("UserID", UserId); //Donde dice NickName va RegistryValueKind.String
                if (userID != null)
                    UserId = userID;
            }
            catch (Exception ex)
            {
                UserId = Modcommon.GetId();
                WriteLog.Save(ex);
            }
            
            try
            {
                string colorInChat = (string)User.GetValue("colorINChat", RegistryValueKind.String);
                colorINChat = Modcommon.ConvertToBool(colorInChat);
            }
            catch (Exception ex) { WriteLog.Save(ex); }
            
            try
            {
                directorio = Path.Combine(Patch, "Avatars", NickName + ".jpg");
                if (File.Exists(directorio))
                {
                    FileInfo info = new FileInfo(directorio);
                    Avatarlength = (int)info.Length;
                }
                else
                {
                    Avatarlength = 0;
                }
            }
            catch (Exception ex){ WriteLog.Save(ex); }

            VerifiLaunchWindowsDir();

            Label_1:
            ;

        }

        private void VerifiLaunchWindowsDir()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
                try
                {
                    if (LaunchWindows)
                    {
                        registryKey.SetValue("KosmoChat.exe", Application.ExecutablePath.ToString());
                    }
                }
                catch { }
            }
            catch { }

        }

        public void ResetearConfiguracion()
        {
            NickName = Environment.UserName;
            UserSelectedColor = 0;
            colorINChat = false;
            LaunchWindows = true;
            PosicionOriginal = true;
            CenterScreen = false;
            GuardarPosicion = false;
            DirBox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            AbrirCarpeta = false;
            AbrirArchivo = false;
            NuevoUser = true;
            DesconectadoUser = true;
            AchivoRecibido = true;
            NotifyStatus = true;
            UserMin = 5;
            UserPanel = false;
            Patch = Modcommon.GetPatch();
            Avatarlength = Modcommon.GetAvatarlength();
            UserPanel = false;
            MyStatus = UserStatus.Activo;
            CleanWhenClose = false;
            DateTimeZinc = false;
            UserDateTimeZinc = string.Empty;
            KeyTop = "F10";
            UserId = Modcommon.GetId();

            Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KosmoChat", true);
            Chat.SetValue("FirstRun", DateTime.Now);
            GuardarSettings();

            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
                registryKey.SetValue("KosmoChat.exe", Application.ExecutablePath.ToString());
            }
            catch { }

        }
        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


    }
}
