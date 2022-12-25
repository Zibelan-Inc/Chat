using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Chat.Properties;

namespace Chat
{
    public abstract class Modcommon : Variables
    {

        public static string TEXT_SEPARATOR = ">D>";
        public static bool ENABLED_CREATE_CHATROOM { get; set; } = true;
        public static short PROFILE_SIZE { get; set; } = (short)200;
        public static bool MAIN_CLOSE { get; set; } = false;
        public static int IDLECOUNT { get; set; } = 0;
        public static bool IS_ENABLED_IP_RANGE { get; set; } = true;
        public static string PROFILE_PATH { get; set; }
        public static string SCREENSHOT_PATH { get; set; }
        public static string SCREENSHOT_LAST { get; set; }
        public static Form CURRENTMAIN_FORM{ get; set; }
        public static bool DEFAULTVIEW{ get; set; }
        public static bool DISPLAY_MOBILE_STATUS_ONLINE{ get; set; }
        public static bool DISABLE_SIGNOUT{ get; set; }
        public static WindowViewType WINDOW_VIEW{ get; set; }
        public static bool CHAT_AUTOCOPY{ get; set; }
        public static bool SPELL_CHECK{ get; set; }
        public static string DEFAULT_VIEW_WIDTH{ get; set; }
        public static string MAIN_WIDTH{ get; set; }
        public static string MAIN_HEIGHT{ get; set; }
        public static string MAIN_LOCATIONX{ get; set; }
        public static string MAIN_LOCATIONY{ get; set; }
        public static string FOLDER_PATH { get; set; }
        public static string TEMP_PATH { get; set; }
        public static string TEMP_VAR { get; set; }
        public static string PHOTO_PATH = Application.StartupPath + "/Avatars/";
        public static string PHOTO_SMALL_PATH = Application.StartupPath + "/Avatars/";
        public static short IE_VERSION;
        public static string RECENTEMOJIPATH = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "EmojiImg");
        public static bool PIN_MSGWINDOW = false;
        public static string PRODUCT_EXE_NAME = "KosmoChat";
        private static string str;
        public const int SB_BOTH = 3;
        public const int WM_NCCALCSIZE = 0x83;
        public const string SEP = "^";
        public const string DSEP = "<D<";
        public static string PRODUCT_NAME = "KosmoChat";
        public const string DEFAULT_FONT = "Segoe UI";
        public static string PRODUCT_FOLDER_NAME = GetFolderName();
        public static long ALERTCOUNT;
        public static Hashtable ChatBottomForms = new Hashtable();
        private static Image image1;
        public RemoteDesktop RD;
        public static string AVATARDIR;
        public static Random Rand;

        static Keys Key;
        internal static Keys GetKey(string keyTop)
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                if (key.ToString() == keyTop)
                    Key = key;

            return Key;
        }

        //Ventana
        public static int FormWidth;
        public static int FormHeight;
        public static int FormTop;
        public static int FormLeft;
        public static int SplitterDistance;
        public static Size MinimumSize;
        public static Point Location;
        public static int panel1W;
        public static int panel2W;

        public static string AppDataLocal;

        public static bool IS_WINDOWS_10 = ((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion")?.GetValue("ProductName")).StartsWith("Windows 10");
        public static bool Hackerprod = (Environment.UserName == "Hackerprod" && Environment.MachineName == "MUSICALPROD");

        public static string State(UserStatus state)
        {
            if (state == UserStatus.Online)
                Client.Userstate = "Online";
            if (state == UserStatus.Activo)
                Client.Userstate = "Activo";
            if (state == UserStatus.Ocupado)
                Client.Userstate = "Ocupado";
            if (state == UserStatus.Ausente)
                Client.Userstate = "Ausente";
            if (state == UserStatus.Idle)
                Client.Userstate = "idle";
            return Client.Userstate;
        }

        internal static string ChangeLanguageForText(string v) { return v; }


        public static List<PresetMessage> CHAT_PRESET_MESSAGES;



        public static string Number2String(int number)
        {
            StringBuilder stringBuilder = new StringBuilder(number.ToString());
            int num = checked(stringBuilder.Length - 1);
            int index = 0;
            while (index <= num)
            {
                stringBuilder[index] = Convert.ToChar(checked(65 + Conversion.Val(stringBuilder[index])));
                checked { ++index; }
            }
            return stringBuilder.ToString();
        }

        public static string ToFullString(Enum EnumConstant)
        {
            DescriptionAttribute[] descriptionAttributeArray = (DescriptionAttribute[])EnumConstant.GetType().GetField(EnumConstant.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributeArray.Length <= 0 ? EnumConstant.ToString() : (!EnumConstant.GetType().IsEquivalentTo(typeof(UserStatus)) || Conversions.ToInteger((object)EnumConstant) != 8 || !DISPLAY_MOBILE_STATUS_ONLINE ? descriptionAttributeArray[0].Description : "Online");
        }
        public static string ToShortDateTimeFormat(DateTime dt)
        {
            switch (DateAndTime.DateDiff(DateInterval.Day, dt.Date, DateAndTime.Now.Date))
            {
                case 0L:
                    return dt.ToString("hh:mm tt");
                case 1L:
                    return "Yesterday";
                default:
                    return dt.ToString("dd/MM/yyyy");
            }
        }
        public static string ToStandardDateString(DateTime dt)
        {
            return dt.ToString("s");
        }
        public static Image CropToCircle(Image image)
        {
            try
            {
                if (image == null)
                {
                    image1 = (Image)null;
                }
                else
                {
                    int num = checked(21 * 2);
                    Bitmap bitmap = new Bitmap(image.Width, image.Height);
                    using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    {
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        using (Brush brush = (Brush)new TextureBrush(image))
                        {
                            using (GraphicsPath path = new GraphicsPath())
                            {
                                path.AddArc(-1, -1, num, num, 180f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), -1, num, num, 270f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), checked(0 + bitmap.Height - num), num, num, 0.0f, 90f);
                                path.AddArc(-1, checked(0 + bitmap.Height - num), num, num, 90f, 90f);
                                graphics.FillPath(brush, path);
                            }
                        }
                        image1 = (Image)bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return image1;
        }
        public static Image CropToCircleforChat(Image image, string Nick)
        {
            try
            {
                if (image == null)
                {
                    image1 = (Image)null;
                }
                else
                {
                    int num = checked(21 * 2);
                    bitmap = new Bitmap(image.Width, image.Height);
                    using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    {
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        using (Brush brush = (Brush)new TextureBrush(image))
                        {
                            using (GraphicsPath path = new GraphicsPath())
                            {
                                path.AddArc(-1, -1, num, num, 180f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), -1, num, num, 270f, 90f);
                                path.AddArc(checked(0 + bitmap.Width - num), checked(0 + bitmap.Height - num), num, num, 0.0f, 90f);
                                path.AddArc(-1, checked(0 + bitmap.Height - num), num, num, 90f, 90f);
                                graphics.FillPath(brush, path);
                            }
                        }
                        image1 = (Image)bitmap;
                    }
                    bitmap.Save(Path.Combine(TEMP_PATH, Nick + ".png"), ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return image1;
        }


        public static SizeF GetTextSize(string text)
        {
            return GetTextSize(text, new Font("Segoe UI", 9f, FontStyle.Regular));
        }
        public static long UserID(string ip)
        {
            string partes = ip.Trim('.');
            var id = (long) (partes[2] + partes[0] + partes[1]);
            return id;
        }


        public static SizeF GetTextSize(string text, Font font)
        {
            using (Graphics graphics = Graphics.FromImage((Image)new Bitmap(1, 1)))
                return graphics.MeasureString(text, font);
        }

        private static bool IsRTL()
        {
            return InputLanguage.CurrentInputLanguage.Culture.TextInfo.IsRightToLeft;
        }



        public static bool GetFormInactivo(string formInactivo)
        {
            switch (formInactivo)
            {
                case "FormActivo":
                    Inactivo = false;
                    break;
                case "FormInactivo":
                    Inactivo = true;
                    break;
            }
            return Inactivo;
        }
        public static void AnimateWindow(bool start = true)
        {
            try
            {
                if (start)
                    AnimateWindow(frmMain.frm.Handle, 500, AW_BLEND | AW_CENTER | AW_ACTIVATE);
                else
                    AnimateWindow(frmMain.frm.Handle, 500, AW_CENTER | AW_BLEND | AW_HIDE);
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_SLIDE = 0x00040000;
        static bool res = true;

        public static bool ConvertToBool(string Bool)
        {
            string boolean = Bool.ToLower();
            switch (boolean)
            {
                case "true":
                    res = true;
                    break;
                case "false":
                    res = false;
                    break;
                case "checked":
                    res = true;
                    break;
                case "unchecked":
                    res = false;
                    break;
            }
            return res;
        }

        public static bool IsRTL(string content, bool isReceivedMessage = false)
        {
            if (!isReceivedMessage)
            {
                flag1 = flag2;
            }
            if (!flag1 && !String.IsNullOrEmpty(content))
                flag1 = new Regex("[\\u0600-\\u06ff]|[\\u0750-\\u077f]|[\\ufb50-\\ufc3f]|[\\ufe70-\\ufefc]|[א-ת]").IsMatch(content);
            return flag1;
        }


        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            bitmap4 = default(Bitmap);
            try
            {
                Bitmap bitmap = new Bitmap(img.Width, img.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                ColorMatrix newColorMatrix = new ColorMatrix
                {
                    Matrix33 = opacityvalue
                };
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                graphics.DrawImage(img, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
                graphics.Dispose();
                bitmap4 = bitmap;
                return bitmap4;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return bitmap4;
            }
        }

        public static Size CurrentScreenWorkingAreaSize(int X, int Y, int W, int H)
        {
            Rectangle rect = new Rectangle(X, Y, W, H);
            Screen[] allScreens = Screen.AllScreens;
            int index = 0;
            while (true)
            {
                Size size;
                Screen screen = allScreens[index];
                Rectangle bounds = screen.Bounds;
                if (!bounds.IntersectsWith(rect))
                {
                    index++;
                    continue;
                }
                size = screen.WorkingArea.Size;

                return size;
            }
        }

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();
        public static string GetFolderName()
        {
            try
            {
                return "KosmoChat";
            }
            catch (Exception exception1)
            {
                object obj1 = exception1;
                ProjectData.SetProjectError((Exception)obj1);
                Exception exception = (Exception)obj1;
                ProjectData.ClearProjectError();
            }
            return "KosmoChat";
        }


        public static bool IsValidWindowPosition(Rectangle rect)
        {
            Screen[] allScreens = Screen.AllScreens;
            int index = 0;
            while (true)
            {
                bool flag;
                if (index >= allScreens.Length)
                {
                    flag = false;
                }
                else
                {
                    Rectangle bounds = allScreens[index].Bounds;
                    if (!bounds.IntersectsWith(rect))
                    {
                        index++;
                        continue;
                    }
                    flag = true;
                }
                return flag;
            }
        }
        public static bool IsValidWindowPosition(int X, int Y, int W, int H) => IsValidWindowPosition(new Rectangle(X, Y, W, H));

        public static string GetIPfromPCName(string PCNAME)
        {
            string ip = "";
            IPAddress ipaddress = IPAddrHelper.GetIPAddressFromHostname(PCNAME);
            IPHostEntry iphe = Dns.GetHostEntry(ipaddress);

            for (int i = 0; i < iphe.AddressList.Length; i++)
            {
                IPAddress item = iphe.AddressList[i];
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = (item.ToString());
                }
            }
            return ip;
        }


        public static void ReleaseMemory()
        {
            try
            {
                SetProcessWorkingSetSize(GetCurrentProcess(), -1, -1);
            }
            catch (Exception exception1)
            {
                object obj1 = exception1;
                ProjectData.SetProjectError((Exception)obj1);
                Exception exception = (Exception)obj1;
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        public static long SystemVirtualScreenHeight() =>
            ((long)SystemInformation.VirtualScreen.Height);

        public static long SystemVirtualScreenWidth() =>
            ((long)SystemInformation.VirtualScreen.Width);
        public static Color ToColor(string clr)
        {
            Color result = default(Color);
            try
            {
                result = ColorTranslator.FromHtml(clr);
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }


        public enum FrmType
        {
            Login,
            Notes,
            GroupChat,
            Users,
            Chat,
            Reminder,
            Mail,
            Information,
            LoadingScreen,
            OfficeWall,
            Desk,
        }

        public enum ClientFlag
        {
            CLIENT_CLOSED = 0,
            CLIENT_SNDINPUT_READY = 1,
            CLIENT_SNDOUTPUT_READY = 2,
            CLIENT_VIDEO_READY = 4,
            CLIENT_DESKTOP_ACTIVE = 8,
            CLIENT_SNDINPUT_VOICEACTIVATED = 16,
            CLIENT_SNDINPUT_DENOISING = 32,
            CLIENT_SNDINPUT_AGC = 64,
            CLIENT_SNDOUTPUT_MUTE = 128,
            CLIENT_SNDOUTPUT_AUTO3DPOSITION = 256,
            CLIENT_SNDINPUT_AEC = 512,
            CLIENT_SNDINOUTPUT_DUPLEX = 1024,
            CLIENT_TX_AUDIO = 4096,
            CLIENT_TX_VIDEO = 8192,
            CLIENT_MUX_AUDIOFILE = 16384,
            CLIENT_TX_DESKTOP = 32768,
            CLIENT_CONNECTING = 65536,
            CLIENT_CONNECTED = 131072,
            CLIENT_CONNECTION = 196608,
            CLIENT_AUTHORIZED = 262144,
            CLIENT_P2P_AUDIO = 1048576,
            CLIENT_P2P_VIDEO = 2097152,
            CLIENT_P2P = 3145728,
        }

        public enum RectAngles
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8,
            All = 15,
        }

        public enum WindowViewType
        {
            Tabbed,
            Popup,
            Tiles,
        }

        public enum SortType
        {
            Name,
            Gender,
            Groups,
        }

        public enum DPIType
        {
            DPI_96,
            DPI_120,
            DPI_144,
            DPI_192,
        }

        public enum ChatHistoryType
        {
            None,
            Today,
            FromYesterday,
            Last3Days,
            Last7Days,
            Last1Month,
            Last3Months,
            All,
        }

        public enum ChatDesignEnum
        {
            Default,
            Bubble,
        }

        public enum NetworkType
        {
            Network1 = 1,
            Network2 = 2,
            Network3 = 3,
            Network4 = 4,
            Network5 = 5,
            Network6 = 6,
            Network7 = 7,
            Network8 = 8,
            Network9 = 9,
            Network10 = 10,
            Network11 = 11,
            Network12 = 12,
            Network13 = 13,
            Network14 = 14,
            Network15 = 15,
            Network16 = 16,
            Network17 = 17,
        }



        private static Image Imagen;

        public static void CheckProfileImageAndResize(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return;
                FileInfo fileInfo = new FileInfo(filePath);
                string str = Path.Combine(fileInfo.Directory.FullName, fileInfo.Name + "_copy");
                File.Copy(filePath, str, true);
                int width;
                int height;
                using (Image image = LetterImage.ImageFromFile(str))
                {
                    width = image.Width;
                    height = image.Height;
                }
                if (width > (int)PROFILE_SIZE & height > (int)PROFILE_SIZE)
                    ImageHandler.Resize(str, (int)PROFILE_SIZE, (int)PROFILE_SIZE, filePath);
                if (!File.Exists(str))
                    return;
                File.Delete(str);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }




        public static bool CheckPhotoExists(string photoKey)
        {
            try
            {
                if (photoKey == null)
                    photoKey = String.Empty;
                flag = File.Exists(Path.Combine(PROFILE_PATH, photoKey));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        internal static void OpenReceivedFolder()
        {
            Process.Start("explorer.exe", frmMain.DirBox);
        }
        public static string ProcessMessageLength(string message)
        {
            string[] keys = message.Split(' ');
            message = "";
            foreach (string key in keys)
            {
                if (key.Length >= 30)
                {
                    message = message + " ";

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (i == (frmMain.frm.webChat.Width / 10) || i == (frmMain.frm.webChat.Width / 10) * 2 || i == (frmMain.frm.webChat.Width / 10) * 3 || i == (frmMain.frm.webChat.Width / 10) * 4 || i == (frmMain.frm.webChat.Width / 10) * 5 || i == (frmMain.frm.webChat.Width / 10) * 6)
                            message = message + key[i] + " ";
                        else
                            message = message + key[i];
                    }
                }
                else
                    message = message + " " + key;
            }

            return message;
        }
        public static Image ImageFromFile(string filePath)
        {
            Image result = default(Image);
            try
            {
                Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(filePath)));
                result = new Bitmap(image, image.Size);
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }



        //Mios/////////////////////////////////////////////////////////////////////////////////

        public static bool MyIpRange(string ip)
        {
            try
            {
                if (ip.Split('.')[0] == GetIp().Split('.')[0])
                    if (ip.Split('.')[1] == GetIp().Split('.')[1])
                        if (ip.Split('.')[2] == GetIp().Split('.')[2])
                            return true;
            }
            catch { return false; }

            return false;
        }

        public static string GetLetterPress(object f)
        {
            string letter = "";
            KeyEventArgs e = (KeyEventArgs)f;

            switch (e.KeyData)
            {
                case Keys.Q: letter = "q"; break;
                case Keys.W: letter = "w"; break;
                case Keys.E: letter = "e"; break;
                case Keys.R: letter = "r"; break;
                case Keys.T: letter = "t"; break;
                case Keys.Y: letter = "y"; break;
                case Keys.U: letter = "u"; break;
                case Keys.I: letter = "i"; break;
                case Keys.O: letter = "o"; break;
                case Keys.P: letter = "p"; break;
                case Keys.A: letter = "a"; break;
                case Keys.S: letter = "s"; break;
                case Keys.D: letter = "d"; break;
                case Keys.F: letter = "f"; break;
                case Keys.G: letter = "g"; break;
                case Keys.H: letter = "h"; break;
                case Keys.J: letter = "j"; break;
                case Keys.K: letter = "k"; break;
                case Keys.L: letter = "l"; break;
                case Keys.Z: letter = "z"; break;
                case Keys.X: letter = "x"; break;
                case Keys.C: letter = "c"; break;
                case Keys.V: letter = "v"; break;
                case Keys.B: letter = "b"; break;
                case Keys.N: letter = "n"; break;
                case Keys.M: letter = "m"; break;
                case Keys.NumPad0: letter = "0"; break;
                case Keys.NumPad1: letter = "1"; break;
                case Keys.NumPad2: letter = "2"; break;
                case Keys.NumPad3: letter = "3"; break;
                case Keys.NumPad4: letter = "4"; break;
                case Keys.NumPad5: letter = "5"; break;
                case Keys.NumPad6: letter = "6"; break;
                case Keys.NumPad7: letter = "7"; break;
                case Keys.NumPad8: letter = "8"; break;
                case Keys.NumPad9: letter = "9"; break;
                case Keys.D0: letter = "0"; break;
                case Keys.D1: letter = "1"; break;
                case Keys.D2: letter = "2"; break;
                case Keys.D3: letter = "3"; break;
                case Keys.D4: letter = "4"; break;
                case Keys.D5: letter = "5"; break;
                case Keys.D6: letter = "6"; break;
                case Keys.D7: letter = "7"; break;
                case Keys.D8: letter = "8"; break;
                case Keys.D9: letter = "9"; break;
            }
            return letter;
        }
        public static bool GetPressLetter(object f)
        {
            bool letter = false;
            KeyEventArgs e = (KeyEventArgs)f;

            switch (e.KeyData)
            {
                case Keys.Q: letter = true; break;
                case Keys.W: letter = true; break;
                case Keys.E: letter = true; break;
                case Keys.R: letter = true; break;
                case Keys.T: letter = true; break;
                case Keys.Y: letter = true; break;
                case Keys.U: letter = true; break;
                case Keys.I: letter = true; break;
                case Keys.O: letter = true; break;
                case Keys.P: letter = true; break;
                case Keys.A: letter = true; break;
                case Keys.S: letter = true; break;
                case Keys.D: letter = true; break;
                case Keys.F: letter = true; break;
                case Keys.G: letter = true; break;
                case Keys.H: letter = true; break;
                case Keys.J: letter = true; break;
                case Keys.K: letter = true; break;
                case Keys.L: letter = true; break;
                case Keys.Z: letter = true; break;
                case Keys.X: letter = true; break;
                case Keys.C: letter = true; break;
                case Keys.V: letter = true; break;
                case Keys.B: letter = true; break;
                case Keys.N: letter = true; break;
                case Keys.M: letter = true; break;
                case Keys.NumPad0: letter = true; break;
                case Keys.NumPad1: letter = true; break;
                case Keys.NumPad2: letter = true; break;
                case Keys.NumPad3: letter = true; break;
                case Keys.NumPad4: letter = true; break;
                case Keys.NumPad5: letter = true; break;
                case Keys.NumPad6: letter = true; break;
                case Keys.NumPad7: letter = true; break;
                case Keys.NumPad8: letter = true; break;
                case Keys.NumPad9: letter = true; break;
                case Keys.D0: letter = true; break;
                case Keys.D1: letter = true; break;
                case Keys.D2: letter = true; break;
                case Keys.D3: letter = true; break;
                case Keys.D4: letter = true; break;
                case Keys.D5: letter = true; break;
                case Keys.D6: letter = true; break;
                case Keys.D7: letter = true; break;
                case Keys.D8: letter = true; break;
                case Keys.D9: letter = true; break;
            }
            return letter;
        }
        public static string GetLetterPress2(PreviewKeyDownEventArgs e)
        {
            string letter = "";

            switch (e.KeyData)
            {
                case Keys.Q: letter = "q"; break;
                case Keys.W: letter = "w"; break;
                case Keys.E: letter = "e"; break;
                case Keys.R: letter = "r"; break;
                case Keys.T: letter = "t"; break;
                case Keys.Y: letter = "y"; break;
                case Keys.U: letter = "u"; break;
                case Keys.I: letter = "i"; break;
                case Keys.O: letter = "o"; break;
                case Keys.P: letter = "p"; break;
                case Keys.A: letter = "a"; break;
                case Keys.S: letter = "s"; break;
                case Keys.D: letter = "d"; break;
                case Keys.F: letter = "f"; break;
                case Keys.G: letter = "g"; break;
                case Keys.H: letter = "h"; break;
                case Keys.J: letter = "j"; break;
                case Keys.K: letter = "k"; break;
                case Keys.L: letter = "l"; break;
                case Keys.Z: letter = "z"; break;
                case Keys.X: letter = "x"; break;
                case Keys.C: letter = "c"; break;
                case Keys.V: letter = "v"; break;
                case Keys.B: letter = "b"; break;
                case Keys.N: letter = "n"; break;
                case Keys.M: letter = "m"; break;
                case Keys.NumPad0: letter = "0"; break;
                case Keys.NumPad1: letter = "1"; break;
                case Keys.NumPad2: letter = "2"; break;
                case Keys.NumPad3: letter = "3"; break;
                case Keys.NumPad4: letter = "4"; break;
                case Keys.NumPad5: letter = "5"; break;
                case Keys.NumPad6: letter = "6"; break;
                case Keys.NumPad7: letter = "7"; break;
                case Keys.NumPad8: letter = "8"; break;
                case Keys.NumPad9: letter = "9"; break;
                case Keys.D0: letter = "0"; break;
                case Keys.D1: letter = "1"; break;
                case Keys.D2: letter = "2"; break;
                case Keys.D3: letter = "3"; break;
                case Keys.D4: letter = "4"; break;
                case Keys.D5: letter = "5"; break;
                case Keys.D6: letter = "6"; break;
                case Keys.D7: letter = "7"; break;
                case Keys.D8: letter = "8"; break;
                case Keys.D9: letter = "9"; break;
            }
            return letter;
        }
        public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            byte[] numArray1 = new byte[checked(stringToDecrypt.Length + 1)];
            string str;
            try
            {
                key = Encoding.UTF8.GetBytes(Strings.Left(sEncryptionKey, 8));
                DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] numArray2 = Convert.FromBase64String(stringToDecrypt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoServiceProvider.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                byte[] buffer = numArray2;
                int offset = 0;
                int length = numArray2.Length;
                cryptoStream.Write(buffer, offset, length);
                cryptoStream.FlushFinalBlock();
                str = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                str = ex.Message;
                ProjectData.ClearProjectError();
            }
            return str;
        }
        private static byte[] key = new byte[0];
        private static byte[] IV = new byte[8] { (byte) 18, (byte) 52, (byte) 86, (byte) 120, (byte) 144, (byte) 171, (byte) 205, (byte) 239 };

        public static string Encrypt(string stringToEncrypt, string SEncryptionKey)
        {
            try
            {
                key = Encoding.UTF8.GetBytes(Strings.Left(SEncryptionKey, 8));
                DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoServiceProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                byte[] buffer = bytes;
                int offset = 0;
                int length = bytes.Length;
                cryptoStream.Write(buffer, offset, length);
                cryptoStream.FlushFinalBlock();
                str = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                str = ex.Message;
                ProjectData.ClearProjectError();
            }
            return str;
        }

        

        public static string GetUniqueAlphaNumericID()
        {
            string str1 = "";
            try
            {
                //Random Marcado por mi

                string str2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                short num1 = checked((short)str2.Length);
                Random random = new Random();
                StringBuilder stringBuilder = new StringBuilder();
                int num2 = 1;
                do
                {
                    int startIndex = random.Next(0, (int)num1);
                    stringBuilder.Append(str2.Substring(startIndex, 1));
                    checked { ++num2; }
                }
                while (num2 <= 6);
                stringBuilder.Append(DateAndTime.Now.ToString("HHmmss"));
                str1 = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return str1;
        }
        public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            bool flag;
            try
            {
                using (File.Create(Path.Combine(dirPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose))
                    flag = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                if (throwIfFails)
                {
                    throw;
                }
                else
                {
                    flag = false;
                    ProjectData.ClearProjectError();
                }
            }
            return flag;
        }
        public static bool NetPing(string ip)
        {
            try
            {
                flag = new Ping().Send(IPAddrHelper.GetIPAddress(ip)).Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
        public static string LongToMbytes(long lBytes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str1 = "Bytes";
            if (lBytes > 1024L)
            {
                string str2;
                float num;
                if (lBytes < 1048576L)
                {
                    str2 = "KB";
                    num = Convert.ToSingle(lBytes) / 1024f;
                }
                else
                {
                    str2 = "MB";
                    num = Convert.ToSingle(lBytes) / 1048576f;
                }
                stringBuilder.AppendFormat("{0:0.0} {1}", (object)num, (object)str2);
            }
            else
            {
                float num = Convert.ToSingle(lBytes);
                stringBuilder.AppendFormat("{0:0} {1}", (object)num, (object)str1);
            }
            return stringBuilder.ToString();
        }
        internal static string GetNamefromID(string userID)
        {
            string user = "Un usuario";
            DataGridViewRow dataGridViewRow = (from DataGridViewRow r in frmMain.frm.UserList.Rows
                                               where r.Cells[0].Value.ToString().Contains(userID)
                                               select r).FirstOrDefault();
            if (dataGridViewRow != null)
            {
                MessengerCell textAndImageCell = ((MessengerCell)frmMain.frm.UserList[0, dataGridViewRow.Index]);
                user = textAndImageCell.UserName;

            }
            return user;
        }
        internal static DataGridViewRow GetRowfromID(string ID)
        {

            DataGridViewRow dataGridViewRow = (from DataGridViewRow r in frmMain.frm.UserList.Rows
                                               where r.Cells[0].Value.ToString().Contains(ID)
                                               select r).FirstOrDefault();

            return dataGridViewRow;
        }
        
        public static void ProcessKey(KeyEventArgs e)
        {
            try
            {
                if (frmMain.frm.textAndImageCellMenu == null)
                    return;
                UsuarioSeleccionado = frmMain.frm.textAndImageCellMenu.UserName;
                IPSeleccionado = frmMain.frm.textAndImageCellMenu.IP;
                //Para detectar una pulsacion en C# tenemos que controlar el evento keyUp del control correspondiente de la siguiente manera:
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.B))
                {
                    if (frmMain.frm.textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show("El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        string beepear = UsuarioSeleccionado;
                        frmMain.frm.Transmit("beep", beepear);

                        frmMain.WriteChatMessages(4, "", "Has enviado un beep a " + UsuarioSeleccionado, 0);
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.E))
                {
                    Process.Start(@"\\" + IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.P))
                {
                    //Mensaje privado
                    frmMain.frm.txtSend.Text = $"//{UsuarioSeleccionado} ";
                    frmMain.frm.txtSend.Focus();
                    frmMain.frm.txtSend.SelectionStart = frmMain.frm.txtSend.TextLength + 1;

                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.A))
                {
                    //Enviar Archivo
                    //FileSender fileSender = new FileSender();
                    //fileSender.Iniciar(IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.C))
                {
                    if (frmMain.frm.textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show("El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Llamada
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.V))
                {
                    if (frmMain.frm.textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show("El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Videollamada
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.D))
                {
                    if (frmMain.frm.textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show("El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Escritodio Remoto
                        try
                        {
                            frmMain.frm.Transmit("Control");
                        }
                        catch (Exception ex) { frmMain.frm.Crearlog(ex); }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.N))
                {
                    frmMain.frm.Transmit("buzz", UsuarioSeleccionado);
                }

            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }
        public static string RandomPassword()
        {
            Random r = new Random();
            return r.Next(1010, 9999).ToString();
        }
        public static string ToUpperFirst(string key)
        {
            string Key = string.Empty;
            bool first = true;
            foreach (char letter in key)
            {
                if (first)
                    Key = letter.ToString().ToUpper();
                else
                    Key = Key + letter;
                first = false;
            }
            return Key;
        }
        public static string convertURI(string uri)
        {
            string convert = string.Empty;

            if (uri.Contains("file:///"))
                convert = uri.Replace("file:///", "");
            else
                convert = "file:///" + uri;

            return convert;
        }
        public static void LoadTempFolders()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Temp")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Temp"));

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Screenshots")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Screenshots"));

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Screenshots")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Screenshots"));

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Letter")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Letter"));

            //if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "css")))
            //Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "css"));

            //if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "css", "class.css")))
            //css.Save();

            if (File.Exists(Path.Combine(TEMP_PATH, "KosmoChat.zip")))
                File.Delete(Path.Combine(TEMP_PATH, "KosmoChat.zip"));
            return;
        }
        public static string VerificarCaracteres(string Letter)
        {
            string letter = string.Empty;

            letter = Letter.Replace("ª", "").Replace("!", "").Replace("´", "").Replace("+", "").Replace("[", "(").Replace("]", ")");
            letter = letter.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");

            return letter;
        }
        public static string GetIp()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            IPAddress ipaddress = null;
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddress = item;
                }
            }
            return ipaddress.ToString();
        }
        public static bool IsUserOnline(string ip)
        {
            Ping ping = new Ping();
            int timeout = 5000;
            try
            {
                PingReply pingReply = ping.Send(ip, timeout);
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("La dirección IP no es válida!!!");
                return false;
            }
        }
        public static string GetChatTime(string time)
        {

            time = time.ToLower();
            time = time.Replace("m", "").Replace("p", "").Replace("a", "").Replace(".", "").Replace(" ", "");

            string message = "";
            string[] format = time.Split(':');
            int hora = Convert.ToInt32(format[0]);
            int minutos = Convert.ToInt32(format[1]);

            if (hora > 12)
                hora = (hora - 12);
            string min = minutos.ToString();
            if (min.Length == 1)
                min = "0" + min;

            string resultado = hora.ToString() + ":" + min;

            if (resultado.StartsWith("1:"))
                message = "la " + resultado;
            else
                message = "las " + resultado;

            return message;
        }
        

        public static string GetPatch()
        {
            try
            {
                currentProcess = Process.GetCurrentProcess();
                return new FileInfo(currentProcess.MainModule.FileName).Directory.FullName;
            }
            finally
            {
                currentProcess = null;
            }
        }
        public static int GetAvatarlength()
        {
            avatarLength = 0;
            try
            {
                avatar = Path.Combine(GetPatch(), "Avatars", frmMain.UserId + ".jpg");
                if (File.Exists(avatar))
                {
                    FileInfo info = new FileInfo(avatar);
                    avatarLength = Convert.ToInt32(info.Length);
                }

                return avatarLength;
            }
            catch
            {
                return avatarLength;
            }
        }
        public static void LoadUpdate()
        {
            if (!Directory.Exists(Path.Combine(GetSystemDrive(), "KosmoChat")))
                Directory.CreateDirectory(Path.Combine(GetSystemDrive(), "KosmoChat"));

            if (File.Exists(Path.Combine(GetSystemDrive(), "KosmoChat", "kosmochat.exe")))
                File.Delete(Path.Combine(GetSystemDrive(), "KosmoChat", "kosmochat.exe"));

            if (File.Exists(Path.Combine(GetSystemDrive(), "KosmoChat", "kosmochat.zip")))
                try { File.Delete(Path.Combine(GetSystemDrive(), "KosmoChat", "kosmochat.zip")); } catch { };

            if (File.Exists(Path.Combine(GetPatch(), "kosmochat.exe")))
                File.Copy(Path.Combine(GetPatch(), "kosmochat.exe"), Path.Combine(GetSystemDrive(), "kosmochat", "kosmochat.exe"));

            if (File.Exists(Path.Combine(GetSystemDrive(), "Kosmochat", "kosmochat.exe")))
                try { ZipFile.CreateFromDirectory(Path.Combine(GetSystemDrive(), "kosmochat"), Path.Combine(GetSystemDrive(), "Kosmochat", "kosmochat.zip"));}
                catch { return; }

        }
        public static string GetSystemDrive()
        {
            string systemDrive = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string systemDriveReturn = "";

            for (int i = 0; i <= systemDrive.Length; i++)
            {
                if (i < 3)
                    systemDriveReturn += systemDrive[i].ToString();
                else break;
            }
            return systemDriveReturn;
        }
        public static bool ReadyUpdate()
        {

            if (!Directory.Exists(Path.Combine(TEMP_PATH, "KosmoChat")))
                Directory.CreateDirectory(Path.Combine(TEMP_PATH, "KosmoChat"));

            if (File.Exists(Path.Combine(TEMP_PATH, "KosmoChat", "KosmoChat.exe")))
                File.Delete(Path.Combine(TEMP_PATH, "KosmoChat", "KosmoChat.exe"));

            try
            {
                if (File.Exists(Path.Combine(TEMP_PATH, "KosmoChat", "KosmoChat.zip")))
                    File.Delete(Path.Combine(TEMP_PATH, "KosmoChat", "KosmoChat.zip"));
            } catch { }

            return true;
        }
        public static string GetPersonalMessage(UserStatus status, string userID = "", string IdleTime = "")
        {
            string _pm = "";
            try
            {
                if (status == UserStatus.Online)
                {
                    _pm = "Online";
                }
                if (status == UserStatus.Activo)
                {
                    _pm = "Activo";
                }
                if (status == UserStatus.Ocupado)
                    _pm = "Ocupado";
                if (status == UserStatus.Ausente)
                    _pm = "Ausente";
                if (string.IsNullOrEmpty(_pm))
                    _pm = "Desconocido";

                if (status == UserStatus.Idle)
                {

                    if (userID != frmMain.UserId)
                        _pm = "Inactivo desde " + GetRemoteTimeIdle(IdleTime);
                    else
                        _pm = "Inactivo desde " + PrepareTime(GetTimeIdle());

                }

            }
            catch
            {
                _pm = status.ToString();
            }
            return _pm;
        }
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string BytesToString(byte[] bytes, int index, int count)
        {
            if (bytes.Length < count)
                count = bytes.Length;
            return Encoding.UTF8.GetString(bytes, index, count);
        }
        public static string PrepareTime(string time)
        {
            time = time.ToLower();
            time = time.Replace("m", "").Replace("p", "").Replace("a", "").Replace(".", "").Replace(" ", "");

            string[] format = time.Split(':');

            int hora = Convert.ToInt32(format[0]);
            int minutos = Convert.ToInt32(format[1]);

            if (hora > 12)
                hora = (hora - 12);

            if (hora == 0)
                hora = 12;

            string minute = minutos.ToString();

            if (minute.Length == 1)
                minute = "0" + minute;

            string resultado = hora.ToString() + ":" + minute;

            string message = "";

            if (resultado.StartsWith("1:"))
                message = "la " + resultado;
            else
                message = "las " + resultado;

            return message;
        }
        public static string GetTimeIdle()
        {

            string message = "";

            string time = DateTime.Now.ToShortTimeString();

            string[] format = time.Split(':');
            int hora = Convert.ToInt32(format[0]);
            int minutos = Convert.ToInt32(format[1]);

            if (minutos >= 10)
                minutos = (minutos - 10);
            else
            {

                if (hora > 12)
                    hora = (hora - 12);

                switch (hora)
                {
                    case 1:
                        hora = 12;
                        break;
                    default:
                        hora = hora - 1;
                        break;
                }

                minutos = (60 + (minutos - 10));
            }
            string minute = minutos.ToString();
            if (minute.Length == 1)
                minute = "0" + minute;

            string resultado = hora.ToString() + ":" + minute;
            return resultado;
        }
        public static string GetRemoteTimeIdle(string time)
        {
            if (time == "")
                return "Uf...";

            time = time.ToLower();
            time = time.Replace("m", "").Replace("p", "").Replace("a", "").Replace(".", "").Replace(" ", "");

            string message = "";

            string[] format = time.Split(':');
            int hora = Convert.ToInt32(format[0]);
            int minutos = Convert.ToInt32(format[1]);

            if (hora > 12)
                hora = (hora - 12);
            if (hora == 0)
                hora = 12;

            string minute = minutos.ToString();
            if (minute.Length == 1)
                minute = "0" + minute;

            string resultado = hora.ToString() + ":" + minute;

            if (resultado.StartsWith("1:"))
                message = "la " + resultado;
            else
                message = "las " + resultado;

            return message;
        }

        private class TimeUsers
        {
            public string User;
            public int Time;
            public TimeUsers(string user, int time)
            {
                User = user;
                Time = time;
            }
        }

        private static List<TimeUsers> TimeConectedUser = new List<TimeUsers>();
        public static string GetLastUser()
        {
            int Hora = 999999;
            string usuario = "";
            TimeConectedUser.Clear();

            int rowCount = frmMain.frm.UserList.RowCount;
            int num = checked(rowCount - 1);
            for (int i = 0; i <= num; i = checked(i + 1))
            {
                try
                {
                    MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, i];
                    TimeUsers user = new TimeUsers(textAndImageCell.UserName, Convert.ToInt32(textAndImageCell.ConnectedTime.Replace(":", "").Replace("m", "").Replace("p", "").Replace("a", "").Replace(".", "").Replace(" ", "")));
                    TimeConectedUser.Add(user);
                } catch { }
            }

            foreach(TimeUsers user in TimeConectedUser)
            {
                if (user.Time < Hora)
                    Hora = user.Time;
            }

            foreach (TimeUsers user in TimeConectedUser)
            {
                if (user.Time == Hora)
                    usuario = user.User;
            }

            return usuario;
        }


        public static bool VerifyServiceDir()
        {

            string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat");
            if (File.Exists(Path.Combine(AppData, "VoipServer", "tt4prosvc.exe")))
                return true;

            flag = false;

            if (!Directory.Exists(Path.Combine(AppData, "VoipServer")))
            Directory.CreateDirectory(Path.Combine(AppData, "VoipServer"));

            if (File.Exists(Path.Combine(AppData, "VoipServer", "tt4prosvc.exe")))
                flag = true;
            else
            {
                File.WriteAllBytes(Path.Combine(AppData, "VoipServer.zip"), Resources.VoipServer);
                ZipFile.ExtractToDirectory(Path.Combine(AppData, "VoipServer.zip"), AppData); //extracts it

                if (File.Exists(Path.Combine(AppData, "VoipServer.zip")))
                    File.Delete(Path.Combine(AppData, "VoipServer.zip"));


                flag = true;
            }



            return flag;
        }
        public static void Test()
        {
            frmMain.frm.webChat.Document.Write("lol");
        }
        public static void Open(string path)
        {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "explorer.exe";
            process.StartInfo.Arguments = path;
            process.Start();

        }

        internal static void StopServers()
        {
            //if (ServiceManager.GetServiceIsRunning("KosmoChat"))
            //    Service.StopService("KosmoChat");

        }
        public static void FlushMemory()
        {
            try
            {
                new ReleaseMemory();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        internal static string GetChatId(string From, string To)
        {
            string[] chatID = { From, To };
            Array lista = chatID;
            Array.Sort(lista);

            return chatID[0] + "◄" + chatID[1];
        }

        public static string GetId()
        {
            string MAC = "";
            try
            {
                int n = 0;
                string[] tempstring = new string[6];

                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in allNetworkInterfaces)
                {
                    if (networkInterface.GetPhysicalAddress().ToString().Length == 12)
                    {
                        string curmac = networkInterface.GetPhysicalAddress().ToString();
                        int num3 = curmac.Length - 1;
                        int num4;
                        for (num4 = 0; num4 <= num3; num4++)
                        {
                            tempstring[n] = Conversions.ToString(curmac[num4]) + Conversions.ToString(curmac[num4 + 1]);
                            n++;
                            num4++;
                        }
                        n = 0;
                        MAC = tempstring[0] + "-" + tempstring[1] + "-" + tempstring[2] + "-" + tempstring[3] + "-" + tempstring[4] + "-" + tempstring[5];
                        break;
                    }
                }
            }
            catch { MAC = getId(); }

            if (MAC == "")
                MAC = getId();

            return MAC;
        }
        private static string getId()
        {
            string MAC = "";
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>())
                    {
                        if (managementObject["MACAddress"].ToString().Length == 17)
                        {
                            try { MAC = managementObject["MACAddress"].ToString(); } catch { }
                            break;
                        }
                    }
                }
            }
            MAC = MAC.Replace(":", "-");

            if (MAC == "")
                MAC = GetUniqueAlphaNumericID();

            return MAC;
        }
        public static string GetHostName(string ipAdress)
        {
            string result = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                result = hostEntry.HostName;
            }
            catch
            {
            }
            return result;
        }
        public static bool PingReply(string sIpAdress)
        {
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(sIpAdress, 60);
            if (pingReply.Status.ToString() == "Success")
            {
                return true;
            }
            return false;
        }

















    }

























    /////////////////////////////////////////////////////////////////
    public class PresetMessage
    {
        public long PresetMsgID { get; set; }

        public string PresetMsg { get; set; }

        public string ShortcutKey { get; set; }

        public string InstantSend { get; set; }
    }

    /////////////////////////////////////////////////////////////////
    public class EventHandlers
    {
        public delegate void SearchBoxFocusEventHandler(bool isAlt, bool isControl, bool isShift, Keys keyCode);

        [CompilerGenerated]
        private static SearchBoxFocusEventHandler SearchBoxFocusEvent;

        public static event SearchBoxFocusEventHandler SearchBoxFocus
        {
            [CompilerGenerated]
            add
            {
                SearchBoxFocusEventHandler searchBoxFocusEventHandler = SearchBoxFocusEvent;
                SearchBoxFocusEventHandler searchBoxFocusEventHandler2;
                do
                {
                    searchBoxFocusEventHandler2 = searchBoxFocusEventHandler;
                    SearchBoxFocusEventHandler value2 = (SearchBoxFocusEventHandler)Delegate.Combine(searchBoxFocusEventHandler2, value);
                    searchBoxFocusEventHandler = Interlocked.CompareExchange(ref SearchBoxFocusEvent, value2, searchBoxFocusEventHandler2);
                }
                while ((object)searchBoxFocusEventHandler != searchBoxFocusEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                SearchBoxFocusEventHandler searchBoxFocusEventHandler = SearchBoxFocusEvent;
                SearchBoxFocusEventHandler searchBoxFocusEventHandler2;
                do
                {
                    searchBoxFocusEventHandler2 = searchBoxFocusEventHandler;
                    SearchBoxFocusEventHandler value2 = (SearchBoxFocusEventHandler)Delegate.Remove(searchBoxFocusEventHandler2, value);
                    searchBoxFocusEventHandler = Interlocked.CompareExchange(ref SearchBoxFocusEvent, value2, searchBoxFocusEventHandler2);
                }
                while ((object)searchBoxFocusEventHandler != searchBoxFocusEventHandler2);
            }
        }

        public static void RaiseSearchBoxFocus(bool isAlt, bool isControl, bool isShift, Keys keyCode)
        {
            try
            {
                SearchBoxFocusEvent?.Invoke(isAlt, isControl, isShift, keyCode);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
		public string GetFileName(string direction)
        {
            return direction.Substring(direction.LastIndexOf("\\") + 1);
        }

        public string GetUniqueAlphaNumericID()
        {
            try
            {
                string str2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                short length = (short)str2.Length;
                Random random = new Random();
                StringBuilder builder = new StringBuilder();
                int num2 = 1;
                do
                {
                    int startIndex = random.Next(0, length);
                    builder.Append(str2.Substring(startIndex, 1));
                    num2++;
                }
                while (num2 <= 6);
                Variables.String = builder.ToString();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception ex = exception1;
                ProjectData.ClearProjectError();
            }
            return Variables.String;
        }

    }
    public class SettingsAttribute : Attribute
    {

        public string Type
        {
            get;
            set;
        }

        public bool IsBigValue
        {
            get;
            set;
        }
    }
    public class ValidateEventArgs
    {
        [CompilerGenerated]
        private bool _IsValid;

        [CompilerGenerated]
        private string _ErrorMessage;

        public bool IsValid
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public ValidateEventArgs()
        {
            IsValid = true;
        }
    }

    public class ReleaseMemory
    {
        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern IntPtr GetCurrentProcess();

        public ReleaseMemory()
        {
            SetProcessWorkingSetSize(GetCurrentProcess(), -1, -1);
        }
    }

}