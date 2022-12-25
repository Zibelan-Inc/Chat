using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hook;
using LanChat;
using mshtml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NHunspellExtender;
using RemoteFileSystemTester;
using Chat.Chat;
using Chat.Class;
using Chat.Properties;
using Sockets.Server;
using Transfer;

// []   |||   &&
//ver SingleApplication
//En OM.Client aparece FileListener

namespace Chat
{
    public partial class frmMain : Form
    {
        private Form currentChildForm;
        private bool buttonnew = true;
		//Assert using Microsoft.VisualStudio.TestTools.UnitTesting;

        //Ver para agregar y quitar controles (Agregar un Datagrid para la busqueda de usuarios)
        public Control GetControlFromPluginTools(string name)
        {

            Control result = default(Control);
            try
            {
                result = pnlTools.Controls.Find(name, searchAllChildren: false).FirstOrDefault();
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
        private void RemoveControlInPluginTools(string name)
        {
            try
            {
                Control control = pnlTools.Controls.Find(name, searchAllChildren: false).FirstOrDefault();
                if (control != null)
                {
                    pnlTools.Controls.Remove(control);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        //Settings
        public static string NickName { get; set; }
        public static int UserSelectedColor { get; set; }
        public static bool colorINChat { get; set; }
        public static bool LaunchWindows { get; set; }
        public static bool PosicionOriginal { get; set; }
        public static bool CenterScreen { get; set; }
        public static bool GuardarPosicion { get; set; }
        public static string DirBox { get; set; }
        public static bool AbrirCarpeta { get; set; }
        public static bool AbrirArchivo { get; set; }
        public static bool NuevoUser { get; set; }
        public static bool DesconectadoUser { get; set; }
        public static bool AchivoRecibido { get; set; }
        public static bool NotifyStatus { get; set; }
        public static int UserMin { get; set; }
        public static string Patch { get; set; }
        public static int Avatarlength { get; set; }
        public static bool UserPanel { get; set; }
        public static bool DateTimeZinc { get; set; }
        public static string UserDateTimeZinc { get; set; }
        public static string KeyTop { get; set; }
        public static string UserId { get; set; }
        public static UserStatus MyStatus { get; set; }


        /////////////////////////////////////////////////////////////////////////
        public static bool DateTimeChanged { get; set; }
        public static bool CleanWhenClose;
        public Keys keyTopMost;
        public static frmMain frm;
        public bool deactivatemain;
        public bool _hidesearch;
        private bool flag;
        private bool val;
        private bool songPlaying = false;
        private Form Mplayer;
        public string Selrowkey;
        public MessengerColumn Dc;
        public MessengerCell textAndImageCellMenu;
        public MessengerCell textAndImageCell_MouseMove;
        //Chat
        public Client cliente { get; set; }
        private List<string> RecentMessages;
        public static bool Muted;
        public bool alive = true;
        public SoundPlayer beep; //Sonido
        private Message mensage;
        Settings settings;
        public UserAndSystemInfo uInfo;
        public StringBuilder HtmlString;
        public bool ChangeDisplay;
        private string screenCaptured = null;
        private Messages messages;
        public string ConnectedTime;
        public string IdleTime;
        TeamTalk.Local.TeamTalk Local_TeamTalk;
        TeamTalk.Remote.TeamTalk Remote_TeamTalk;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        //Icon[] notifyIcons = new Icon[2];
        readonly P2PHelper _p2PHelper;
        readonly ChatView viewModel;
        public frmMain()
        {
            //Local_TeamTalk = new TeamTalk.Local.TeamTalk();
            //Remote_TeamTalk = new TeamTalk.Remote.TeamTalk();

            InitializeComponent();
            frm = this;

            Settings.GuardarID((object)Handle.ToInt64());
            settings = new Settings(this);
            settings.CargarSettings();
            LoadSettings();

            if (string.IsNullOrEmpty(UserId))
            UserId = Modcommon.GetId();

            InitializeUserGrid();

            ConnectedTime = DateTime.Now.ToShortTimeString().ToLower();
            ConnectedTime = ConnectedTime.Replace("m", "").Replace("p", "").Replace("a", "").Replace(".", "").Replace(" ", "");

            MyStatus = UserStatus.Online;

            LoadDefaultUser();

            //FirewallHelper firewall = new FirewallHelper();
            //if (firewall.IsFirewallInstalled && firewall.IsFirewallEnabled)
            //    MessageBox.Show("firewall activado");
            //FirewallHelper.CreatePolice(Path.Combine(Modcommon.GetPatch(), "kosmoChat.exe"), "kosmoChat", "8904");

            InternetExplorerBrowserEmulation.SetBrowserEmulationVersion(); //WebBrowser Emulation

            CargarModcommon();

            Modcommon.LoadTempFolders();

            PicRetryIcon.Hide();
            //SetStyleSheet += new SetStyleSheetEventHandler(AssignStyleSheet);
            //WriteLog.Report("SetStyleSheetEventHandler(AssignStyleSheet)");

            /*
            if (TeamTalk.Utils.TeamTalk.GetServerInbox() != frmMain.DirBox)
            {
                Service.StopService("kosmoChat");
            }
            */

            cliente = new Client();
            cliente.MessageReceived += new EventHandler<MessageEventArgs>(client_MessageReceived);

            MessageEventArgs.ListMessage.Add("Texto para no este vacia la lista");
            _p2PHelper = new P2PHelper(2574);
            //viewModel = new LanChat.ChatView();
            //Multicast_UDP udp = new Multicast_UDP();
            //udp.ConnectToChat();

            mensage = new Message();

            //Borrar por prueba
            messages = new Messages();
            messages.MessageQueued += new EventHandler(Messages_MessageQueued);

            SetpanelToolsLocation();

            Muted = false;

            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos

            RecentMessages = new List<string>();
            uInfo = new UserAndSystemInfo();
            uInfo.Read();

            //FileTransfer.RunServer();
            //WriteLog.Report("Transfer.FileTransfer.RunServer()");

            //AvatarManager.Initialize();

            //AsynchronousSocketListener.StartListening();
            //Sockets.Client.AsynchronousClient.StartClient();

            //DesktopServer desktopServer = new DesktopServer(this);
            //desktopServer.Load();
            //WriteLog.Report("desktopServer.Load()");

            //Server FileSystem
            //FileSystemServer fileServer = new FileSystemServer();
            //fileServer.StartServer();

            //Server Control
            //ScreenCaptureServer screenServer = new ScreenCaptureServer();

            Patch = Modcommon.GetPatch();
            val = true;


            //ttMain tt = new ttMain();
            //tt.ShowDialog();

            //           HideShowUserPanel();


            //Animar SysTry
            //Icon[] iconos = new Icon[2];
            //iconos[0] = Resources.SC_ICO;
            //iconos[1] = Resources.SC_ICOoffline;
            //AnimateNotifyIcon animate = new AnimateNotifyIcon();
            //animate.Animate(NotifyIcon1, iconos, 200);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Application.CurrentCulture = new System.Globalization.CultureInfo("es");
            UserList.MouseWheel += new MouseEventHandler(UserList_MouseWheel);

            Modcommon.AnimateWindow();

            RecargarLista.Interval = Convert.ToInt32(UserMin) * 60000;
            PingManager.Start();

            ChangeDisplay = false;
            deactivatemain = false;
            _hidesearch = true;
            Muted = false;

            ChangeSpellCheckLanguage();

            ModuleCommon.OM_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat");
            ModuleCommon.PRODUCT_FOLDER_NAME = "KosmoChat";
            ModuleCommon.PRODUCT_NAME = "KosmoChat";
            ModuleCommon.DEFAULT_LANGUAGE = "Spanish";

            IniciarChat();

            IdleTime = "";
            DateTimeChanged = false;

            TransmitFull("Ingreso");

            HttpServer server = new HttpServer(4000);
            server.StartHTTPListener();

            //KeyHook
            if (string.IsNullOrEmpty(KeyTop))
                KeyTop = "F10";

            keyTopMost = Modcommon.GetKey(KeyTop);

            //KeyboardHook kh = new KeyboardHook();
            //kh.KeyDown += Kh_KeyDown;
            //kh.HookStart();
        }


        public void CargarModcommon()
        {
            Modcommon.MAIN_WIDTH = Width.ToString();
            Modcommon.MAIN_HEIGHT = Height.ToString();
            Modcommon.DEFAULT_VIEW_WIDTH = Width.ToString();
            Modcommon.WINDOW_VIEW = Modcommon.WindowViewType.Tabbed;
            Modcommon.FOLDER_PATH = Modcommon.GetPatch();
            Modcommon.TEMP_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Temp");
            Modcommon.SCREENSHOT_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "Screenshots");
            Modcommon.DEFAULTVIEW = true;
            Modcommon.PRODUCT_NAME = "KosmoChat";
            Modcommon.MAIN_CLOSE = true;
            Modcommon.DISABLE_SIGNOUT = true;
            Modcommon.SPELL_CHECK = true;
            Modcommon.CURRENTMAIN_FORM = frm;
            Modcommon.MAIN_LOCATIONX = Location.X.ToString();
            Modcommon.MAIN_LOCATIONY = Location.Y.ToString();
            Modcommon.CHAT_AUTOCOPY = true;
            Modcommon.AVATARDIR = Path.Combine(Modcommon.GetPatch(), "Avatars");
            Modcommon.AppDataLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "kosmoChat");

        }

        public void colorbar()
        {
            if (UserSelectedColor == 0)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(182, 222, 255);
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(182, 222, 255);
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_0;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_0;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_0;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_0;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_0;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_0;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_0;
            }
            else if (UserSelectedColor == 1)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Blue;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Blue;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_1;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_1;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_1;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_1;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_1;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_1;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_1;
            }
            else if (UserSelectedColor == 2)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.BlueViolet;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.BlueViolet;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_2;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_2;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_2;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_2;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_2;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_2;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_2;
            }
            else if (UserSelectedColor == 3)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Crimson;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Crimson;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_3;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_3;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_3;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_3;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_3;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_3;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_3;
            }
            else if (UserSelectedColor == 4)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.DarkOrange;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.DarkOrange;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_4;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_4;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_4;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_4;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_4;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_4;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_4;
            }
            else if (UserSelectedColor == 5)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.DeepPink;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.DeepPink;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_5;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_5;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_5;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_5;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_5;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_5;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_5;
            }
            else if (UserSelectedColor == 6)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.DeepSkyBlue;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.DeepSkyBlue;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_6;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_6;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_6;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_6;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_6;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_6;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_6;
            }
            else if (UserSelectedColor == 7)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Gold;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Gold;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_7;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_7;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_7;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_7;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_7;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_7;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_7;
            }
            else if (UserSelectedColor == 8)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.LightSalmon;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.LightSalmon;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_8;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_8;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_8;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_8;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_8;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_8;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_8;
            }
            else if (UserSelectedColor == 9)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.LimeGreen;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.LimeGreen;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_9;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_9;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_9;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_9;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_9;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_9;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_9;
            }
            else if (UserSelectedColor == 10)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.OrangeRed;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.OrangeRed;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_10;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_10;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_10;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_10;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_10;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_10;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_10;
            }
            else if (UserSelectedColor == 11)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Pink;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Pink;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_11;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_11;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_11;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_11;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_11;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_11;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_11;
            }
            else if (UserSelectedColor == 12)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Plum;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Plum;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_12;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_12;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_12;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_12;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_12;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_12;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_12;
            }
            else if (UserSelectedColor == 13)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Purple;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Purple;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_13;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_13;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_13;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_13;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_13;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_13;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_13;
            }
            else if (UserSelectedColor == 14)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Red;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Red;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_14;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_14;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_14;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_14;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_14;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_14;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_14;
            }
            else if (UserSelectedColor == 15)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.SkyBlue;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.SkyBlue;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_15;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_15;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_15;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_15;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_15;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_15;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_15;
            }
            else if (UserSelectedColor == 16)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Turquoise;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Turquoise;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_16;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_16;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_16;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_16;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_16;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_16;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_16;
            }
            else if (UserSelectedColor == 17)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Yellow;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Yellow;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_17;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_17;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_17;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_17;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_17;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_17;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_17;
            }
            else if (UserSelectedColor == 18)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.MediumSeaGreen;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.MediumSeaGreen;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_18;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_18;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_18;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_18;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_18;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_18;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_18;
            }
            else if (UserSelectedColor == 19)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.Aquamarine;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Aquamarine;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_19;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_19;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_19;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_19;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_19;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_19;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_19;
            }
            else if (UserSelectedColor == 20)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.SlateBlue;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.SlateBlue;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_20;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_20;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_20;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_20;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_20;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_20;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_20;
            }
            else if (UserSelectedColor == 21)
            {
                guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.GreenYellow;
                guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.GreenYellow;
                ButtonSend.Image = global::Chat.Properties.Resources.email_send_21;
                ButtonSmile.Image = global::Chat.Properties.Resources.smile_21;
                if (buttonnew == false)
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.back_21;
                }
                else
                {
                    ButtonArrow.Image = global::Chat.Properties.Resources.forward_21;
                }
                ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_21;
                ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_21;
                ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_21;
            }
        }
    


        public void IniciarChat()
        {
            //Cargar panel de usuario
            //AvatarUserPanel.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(UserId, NickName));
            pictureBox1.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(UserId, NickName));
            colorbar();
            lblWelcomeUserPanel.Text = $"Bienvenido {NickName} a la red";
            lblWelcome2UserPanel.Text = $"Actualmente tenemos {UserList.Rows.Count} usuarios conectados";

            ChangeOpacitypanelTools();
            webChat.AllowWebBrowserDrop = true; //Picha pero me carga lo que suelto

            //string clases = "GetMainCSS:\n" + HtmlHelper.GetMainCSS() + "\n\n\n\n" + "GetFileCSS:\n" + HtmlHelper.GetFileCSS() + "\n\n\n\n";
            //string clases = HtmlHelper.GetJavascript();
            //File.WriteAllText(@"D:\Instaladores\Programación\Projects\KosmoChat\KosmoChat\bin\Debug\script.ini", clases);

            UpdateManager.RunServer();

            HtmlString = new StringBuilder();
            webChat.Navigate("about:blank");
            while (webChat.Document == null || webChat.Document.Body == null)
                Application.DoEvents();

            webChat.Document.OpenNew(true).Write($"<html><body style='background-color: rgb(26,32,47)'></body><head>" +
                                           $"{HtmlHelper.GetHtmlIEVersion()}" +
                                           $"<title name = 'head'>KosmoChat</title>" +
                                           $"</head><body class='body'><br>");
            //panel1.Visible = false;
            webChat.Visible = true;
            //webChat.ScriptErrorsSuppressed = true; //Evitar mensaje de error por script
            webChat.Navigating += new WebBrowserNavigatingEventHandler(webChat_Navigating);
            webChat.ContextMenuStrip = webChatMenu;    //! Set our ContextMenuStrip
            webChat.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(OnDocumentCompleted);

            //MasterInitiate();
            AssignStyleSheet(webChat);

            //Mandar a cerrar
            Muted = false;

            //            LoadForms(3);
            //lblImgstatus.Image = Resources._57;
            Avatarlength = Modcommon.GetAvatarlength();

//            ChangeForm(chatMaster);
            //NotifyIcon1.Icon = Resources.SC_ICO;
            //NotifyIcon1.Text = "KosmoChat";

            if (Modcommon.Hackerprod)
            {
                frm.UpdateUser.Visible = true;
                frm.Visible = true;
                toolStripSeparator2.Visible = true;
                toolStripSeparator3.Visible = true;
                UPdate.Visible = true;
                Monitor.Visible = true;
                CloseChat.Visible = true;
                //H.Menu(UserMenu);
                //H.ShowOtherMenus();
            }


            //Archivo de Audio
            string test = HtmlHelper.GetVoiceMessage("Enamorarme de ti 2(La melodía).mp3", DateTime.Now);
            //webChat.Document.Write(test);
            //HtmlString.Append(test);

            //Nombre y hora

            //Poner en lo ultimo
            //Capturar inactividad
            MyStatus = UserStatus.Online;
            SystemIdleTimer.StartTimer();
            //AdjustCompanyNameSize();

            //LoadTestUser();
            UserList.AllowDrop = true;
            WindowState = FormWindowState.Normal;

            /*
            if (Environment.UserName == "Yohel")
            {
                stcMain.Panel1MinSize = 280;
                stcMain.Panel2MinSize = 150;
                MinimumSize = new Size(450, 300);
                lblWelcomeUserPanel.Text = $"Bienvenido {NickName}";
            }
            */
        }



        public void client_MessageReceived(object sender, MessageEventArgs e)
        {
            try { messages.Add(e.ReceivedMessage); } catch { }
        }

        public void DisconnectFromChat()
        {
            try
            {
                alive = false;
                Transmit("Desconecto");
            }
            catch (Exception ex) { frm.Crearlog(ex); }
        }
        public void Transmit(string typeMessage, string content = "")
        {
            SmallMessage msg = new SmallMessage();                  
            msg.Handle = NickName;                                  
            msg.typeMessage = typeMessage;                           
            msg.ColorID = UserSelectedColor;                        
            msg.content = content;                                  
            msg.ID = UserId;
            if (typeMessage == "RecargarLista")                     
                msg.content = Avatarlength.ToString();

            _p2PHelper?.Send(msg.ToJson());

            //viewModel.Say(msg.ToJson());
            //Multicast_UDP.Transmit(typeMessage, content);
            /*
            byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());   
            udpClient.Send(buffer, buffer.Length, remoteEp);        
            */
        }
        public void TransmitFull(string typeMessage, string content = "")
        {
            Message msg = new Message();
            msg.Handle = NickName;
            msg.typeMessage = typeMessage;
            msg.content = content;
            msg.ColorID = UserSelectedColor;
            msg.MachineName = Environment.MachineName;
            msg.IP = Modcommon.GetIp();
            msg.State = Modcommon.State(MyStatus);
            msg.FormActivo = WinMod.IsActiveMainWindow().ToString();
            msg.AvatarLength = Avatarlength;
            msg.ConnectedTime = frm.ConnectedTime;
            msg.ID = UserId;
            msg.IdleTime = frm.IdleTime;

            if (typeMessage == "Idle")
                msg.content = frm.IdleTime;

            _p2PHelper?.Send(msg.ToJson());
            //viewModel.Say(msg.ToJson());
            //Multicast_UDP.TransmitFull(typeMessage, content);

            /*
            byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());
            udpClient.Send(buffer, buffer.Length, remoteEp);
            */
        }
        public static void ProcessNewMessage(string Message)
        {
            frm.cliente.OnMessageRecieved(new MessageEventArgs(Message));
        }

        public void Messages_MessageQueued(object sender, EventArgs e)
        {
            UpdateChat();
        }
        public void LoadDefaultUser()
        {
            try
            {
                string userKey = UserId;

                Image userPhoto = LetterImage.GetUserImage(userKey, NickName);
                int num = frm.UserList.RowCount;
                string[] Content = new string[1]
                {
                    NickName + Modcommon.TEXT_SEPARATOR + MyStatus + Modcommon.TEXT_SEPARATOR +
                    (Status.ToString(MyStatus)) + Modcommon.TEXT_SEPARATOR + userKey + Modcommon.TEXT_SEPARATOR
                };
                frm.UserList.Rows.Add(Content);
                frm.UserList.Rows[num].Height = 54;
                frm.UserList.RowTemplate.Height = 54;
                frm.UserList[0, num].ReadOnly = true;
                MessengerCell textAndImageCell = (MessengerCell)frm.UserList[0, num];
                textAndImageCell.Image = Modcommon.CropToCircle(userPhoto);
                textAndImageCell.Tag = "U";
                textAndImageCell.User = true;
                textAndImageCell.UserName = NickName;
                textAndImageCell.UserId = userKey;
                textAndImageCell.Status = MyStatus;

                textAndImageCell.ToolTipText = "Apodo:  " + NickName + Environment.NewLine +
                "PC:         " + Environment.MachineName + Environment.NewLine +
                "IP:           " + Modcommon.GetIp() + Environment.NewLine +
                "Estado:   " + "Online" + Environment.NewLine +
                "Conectado desde " + Modcommon.PrepareTime(ConnectedTime);


                textAndImageCell.AvatarLength = Avatarlength;
                textAndImageCell.MachineName = Environment.MachineName;
                textAndImageCell.ColorId = 5;
                textAndImageCell.IP = Modcommon.GetIp();
                textAndImageCell.ConnectedTime = ConnectedTime;

            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }

        public void InitializeUserGrid()
        {
            try
            {
                UserList.CellBorderStyle = DataGridViewCellBorderStyle.None;
                UserList.ShowCellToolTips = true;

                UserList.AllowUserToAddRows = false;
                Dc = new MessengerColumn();
                Dc.Image = Resources.arrow_new_down2;
                Dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                Dc.ReadOnly = true;
                Dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                UserList.Columns.Insert(0, Dc);
                UserList.Sort(UserList.Columns[0], ListSortDirection.Ascending);
                UserList.AllowDrop = true;

                UserSearch.Dock = DockStyle.Fill;
                UserSearch.CellBorderStyle = DataGridViewCellBorderStyle.None;
                UserSearch.ShowCellToolTips = true;
                MessengerColumn DC = new MessengerColumn();
                DC.Image = Resources.arrow_new_down2;
                DC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                DC.ReadOnly = true;
                DC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                UserSearch.AllowUserToAddRows = false;
                UserSearch.Columns.Insert(0, DC);
                UserSearch.Sort(UserSearch.Columns[0], ListSortDirection.Ascending);
                UserSearch.AllowDrop = true;
                UserSearch.Visible = false;

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }






































        private void ChangeActiveColor()
        {
            ChangeControlBGColor(Color.FromArgb(49, 140, 231));
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Location.X < 0 || Location.Y < 0)
                    BringToFront();
                ChangeActiveColor();
                deactivatemain = false;
                ChangeMinimizedWindowState();
                FlashWin.StopWin(this.Handle);
                Modcommon.ReleaseMemory();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            try
            {
                Transmit("FormStatus", "true");
                //NotifyIcon1.Icon = Resources.SC_ICO;
            }
            catch { }
            //AnimateNotifyIcon.StopAnimation();

        }
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            try
            {
                ChangeDeActiveColor();
                deactivatemain = true;
                Modcommon.ReleaseMemory();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            try
            {
                Transmit("FormStatus", "false");
            } catch { }

        }
        public void ChangeMinimizedWindowState()
        {
            try
            {
                if (WindowState != FormWindowState.Minimized)
                    return;
                if (Operators.ConditionalCompareObjectEqual(lblMax.Tag, (object)"Max", false))
                    WindowState = FormWindowState.Maximized;
                else
                    WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }


        private void CheckWindowLocation()
        {
            checked
            {
                try
                {
                    Point location = new Point(Conversions.ToInteger(Modcommon.MAIN_LOCATIONX), Conversions.ToInteger(Modcommon.MAIN_LOCATIONY));
                    short num = (short)Modcommon.SystemVirtualScreenWidth();
                    short num2 = (short)Modcommon.SystemVirtualScreenHeight();
                    num = (short)SystemInformation.VirtualScreen.Width;
                    num2 = (short)SystemInformation.VirtualScreen.Height;
                    bool flag = default(bool);
                    if (location.X + base.Width > num)
                    {
                        location.X = num - base.Width;
                        flag = true;
                    }
                    if (location.Y + base.Height > num2)
                    {
                        location.Y = num2 - base.Height;
                        flag = true;
                    }
                    if (!Modcommon.IsValidWindowPosition(location.X, location.Y, base.Width, base.Height))
                    {
                        if (location.X < 0)
                        {
                            location.X = 0;
                            flag = true;
                        }
                        if (location.Y < 0)
                        {
                            location.Y = 0;
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        base.Location = location;
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    WriteLog.Save(ex2);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void ChangeDeActiveColor()
        {
            ChangeControlBGColor(ColorTranslator.FromHtml("#AAAAAA"));
        }

        private void ChangeControlBGColor(Color clr)
        {
            try
            {
                SuspendLayout();
                BackColor = clr;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            ResumeLayout();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Transmit("Desconecto"); } catch { }
            try { settings.GuardarSettings(); } catch { }
            //e.Cancel = true;

            //NotifyIcon1.Visible = false;

            Process.GetCurrentProcess().Kill();
        }

        public void HideSearch(bool hide = false, bool focusPluginList = true)
        {
            try
            {
                if (!_hidesearch && !hide)
                {
                    _hidesearch = true;
                    txtSearch.Focus();
                }
                else
                {
                    lblSearch.Tag = (object)"F";
                    txtSearch.SendToBack();
                    txtSearch.Clear();
                    txtSearch.Visible = false;
                    lblSearch.BringToFront();
                    txtSearch.Tag = (object)"0";
                    UserSearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim().Equals("Buscar usuario"))
                    return;

                if (txtSearch.Text.Trim().Equals(""))
                {
                    UserList.Visible = true;
                    UserSearch.Visible = false;
                    UserSearch.Rows.Clear();
                }
                else
                {
                    UserList.Visible = false;
                    UserSearch.Visible = true;
                    UserSearch.Rows.Clear();

                    int rowCount = frm.UserList.RowCount;
                    int num = checked(rowCount - 1);
                    for (int i = 0; i <= num; i = checked(i + 1))
                    {
                        MessengerCell textAndImageCell = (MessengerCell)frm.UserList[0, i];
                        string username = textAndImageCell.UserName;
                        if (username.ToLower().StartsWith(txtSearch.Text.ToLower()))
                            AddUser(textAndImageCell);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void AddUser(MessengerCell User)
        {
            int num = UserSearch.RowCount;
            string[] content = new string[1]
            {
                User.UserName + Modcommon.TEXT_SEPARATOR + Status.ToStatus(User.Status.ToString()).ToString() +
                Modcommon.TEXT_SEPARATOR + (Modcommon.GetPersonalMessage(Status.ToStatus(User.Status.ToString()), User.UserId, IdleTime)) + Modcommon.TEXT_SEPARATOR + User.UserName +
                Modcommon.TEXT_SEPARATOR
            };
            UserSearch.Rows.Add(content);
            UserSearch.Rows[num].Height = 54;
            UserSearch.RowTemplate.Height = 54;
            UserSearch[0, num].ReadOnly = true;
            MessengerCell textAndImageCell = (MessengerCell)UserSearch[0, num];
            textAndImageCell.Image = User.Image;
            textAndImageCell.Tag = "U";
            textAndImageCell.User = true;
            textAndImageCell.UserName = User.UserName;
            textAndImageCell.Status = User.Status;

            textAndImageCell.MachineName = User.MachineName;
            textAndImageCell.ColorId = User.ColorId;
            textAndImageCell.IP = User.IP;
            textAndImageCell.ConnectedTime = User.ConnectedTime;
            textAndImageCell.ToolTipText = User.ToolTipText;

        }

        private void CleanTempFiles()
        {
            try
            {
                foreach (string file in Directory.GetFiles(Modcommon.TEMP_PATH))
                {
                    try { File.Delete(file); } catch { }
                }
                foreach (string file in Directory.GetFiles(Modcommon.SCREENSHOT_PATH))
                {
                    try { File.Delete(file); } catch { }
                }
                if (Directory.Exists(Path.Combine(Modcommon.TEMP_PATH, "Screenshots")))
                    foreach (string file in Directory.GetFiles(Path.Combine(Modcommon.TEMP_PATH, "Screenshots")))
                    {
                        try { File.Delete(file); } catch { }
                    }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        
        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Visible)
                    return;
                CheckWindowLocation();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(1, 1, checked(Width - 2), checked(Height - 2));
                using (SolidBrush solidBrush = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle((Brush)solidBrush, rect);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void lblMax_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMax.Tag.Equals((object)"Max"))
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    //SetMaxSize();
                    Rectangle workingArea1 = Screen.FromHandle(Handle).WorkingArea;
                    Rectangle workingArea2 = Screen.PrimaryScreen.WorkingArea;
                    int left = workingArea2.Left;
                    workingArea2 = Screen.PrimaryScreen.WorkingArea;
                    int top = workingArea2.Top;
                    int width = workingArea1.Width;
                    int height = workingArea1.Height;
                    MaximizedBounds = new Rectangle(left, top, width, height);
                    WindowState = FormWindowState.Maximized;
                }
                ChangeResizeImage();
                SetpanelToolsLocation(picMore.Visible);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }

        }
        private void lblMax_MouseEnter(object sender, EventArgs e)
        {
            lblMax.BackColor = Color.FromArgb(7, 164, 245);
        }
        private void lblMax_MouseLeave(object sender, EventArgs e)
        {
           // ChangeCloseMinMaxBg(lblMax);
        }
        private void lblMin_MouseEnter(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.FromArgb(7, 164, 245);
        }
        private void lblMin_MouseLeave(object sender, EventArgs e)
        {
            //ChangeCloseMinMaxBg(lblMin);
        }
        private void ChangeCloseMinMaxBg(Label lbl)
        {
            try
            {
                lbl.BackColor = System.Drawing.Color.Transparent;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void lblMin_Click(object sender, EventArgs e)
        {
            Modcommon.AnimateWindow(false);
            WindowState = FormWindowState.Minimized;
        }
        private void pnlTitlebar_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lblMax.Tag.Equals((object)"Max"))
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    //SetMaxSize();
                    Rectangle workingArea1 = Screen.FromHandle(Handle).WorkingArea;
                    Rectangle workingArea2 = Screen.PrimaryScreen.WorkingArea;
                    int left = workingArea2.Left;
                    workingArea2 = Screen.PrimaryScreen.WorkingArea;
                    int top = workingArea2.Top;
                    int width = workingArea1.Width;
                    int height = workingArea1.Height;
                    MaximizedBounds = new Rectangle(left, top, width, height);
                    WindowState = FormWindowState.Maximized;
                }
                ChangeResizeImage();
                SetpanelToolsLocation(picMore.Visible);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void ChangeResizeImage()
        {
            try
            {
                if (WindowState == FormWindowState.Normal)
                {
                    lblMax.Image = (Image)Resources.max1;
                    lblMax.Tag = (object)"Restore";
                }
                else
                {
                    lblMax.Image = (Image)Resources.restore;
                    lblMax.Tag = (object)"Max";
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            if (!Modcommon.DEFAULTVIEW)
                Modcommon.MAIN_CLOSE = true;

            settings.GuardarSettings();
            Modcommon.AnimateWindow(false);
            Visible = false;
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            ChangeCloseMinMaxBg(lblClose);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainWindow();
        }
        public void ShowMainWindow()
        {
            try
            {
                Modcommon.AnimateWindow();

                if (WindowState == FormWindowState.Minimized || !Visible)
                {
                    Visible = true;
                    if (WindowState != FormWindowState.Maximized)
                    {
                        if (Operators.ConditionalCompareObjectEqual(lblMax.Tag, (object)"Max", false))
                            WindowState = FormWindowState.Maximized;
                        else
                            WindowState = FormWindowState.Normal;
                    }
                    Point location = Location;
                    if (location.X >= 0)
                    {
                        location = Location;
                        if (location.Y >= 0)
                            goto label_8;
                    }
                    label_8:
                    ((Control)this).Show();
                    Activate();
                    BringToFront();
                    WinMod.MakeWindowTop((long)Handle);
                }
                else
                {
                    Visible = true;

                    Point location = Location;
                    if (location.X >= 0)
                    {
                        location = Location;
                        if (location.Y >= 0)
                            goto label_12;
                    }
                    label_12:
                    Activate();
                    BringToFront();
                    WinMod.MakeWindowTop((long)Handle);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            
            mnuStatus.Show((Control)lblStatus, new Point(0, 20));
        }
        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml("#aacbe8")))
                    e.Graphics.DrawLine(pen, 0, 0, pnlStatus.Width, 0);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }

        }

        public void ChangePersonalMessageAndStatus(string userId, UserStatus status, bool nickChange = false, string newNick = "", string idleTime = "")
        {
            try
            {
                string user = Modcommon.GetNamefromID(userId);

                DataGridViewRow dataGridViewRow = (from DataGridViewRow r in UserList.Rows
                                                   where r.Cells[0].Value.ToString().Contains(userId)
                                                   select r).FirstOrDefault();
                if (dataGridViewRow != null)
                {
                    MessengerCell textAndImageCell = ((MessengerCell)UserList[0, dataGridViewRow.Index]);

                    if (textAndImageCell.UserId == userId)
                    {
                        //Cambiar Imagen en la celda
                        textAndImageCell.Status = status;

                        if (status == UserStatus.Ausente)
                            textAndImageCell.Image = Modcommon.CropToCircle(Modcommon.ChangeOpacity(LetterImage.GetUserImage(userId), 0.7f));
                        else
                            textAndImageCell.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(userId));

                        textAndImageCell.ToolTipText = textAndImageCell.ToolTipText.Replace("Online", status.ToString()).Replace("Activo", status.ToString()).Replace("Ocupado", status.ToString()).Replace("Ausente", status.ToString()).Replace("Inactivo", status.ToString());


                        //Cambiar texto en la celda
                        if (nickChange)
                            user = newNick;

                        DataGridViewCell dataGridCell = dataGridViewRow.Cells[0];
                        string[] obj = new string[8]
                        {
                        user, Modcommon.TEXT_SEPARATOR, null, null, null, null, null, null
                        };
                        obj[2] = status.ToString();
                        obj[3] = Modcommon.TEXT_SEPARATOR;
                        obj[4] = Modcommon.GetPersonalMessage(status, userId, idleTime);
                        obj[5] = Modcommon.TEXT_SEPARATOR;
                        obj[6] = userId;
                        obj[7] = Modcommon.TEXT_SEPARATOR;
                        dataGridCell.Value = string.Concat(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

       
        private void ShowHideToolsIcons(bool valor)
        {
            try { pnlTools.Visible = valor; } catch { }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) != 13)
                return;
            e.Handled = true;
        }
        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
            try
            {
                HideSearch(false, true);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            ShowSearch("");
        }
        public void ShowSearch(string searchText = "")
        {
            try
            {
                lblSearch.SendToBack();
                lblSearch.Tag = (object)"B";
                txtSearch.Visible = true;
                txtSearch.BringToFront();
                if (!string.IsNullOrEmpty(searchText))
                {
                    txtSearch.Text = Conversions.ToString(char.ToLower(Conversions.ToChar(searchText)));
                    txtSearch.Select(txtSearch.Text.Length, 0);
                }
                else
                    txtSearch.Clear();
                txtSearch.Focus();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }


       
        private void UserList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                Guna.UI2.WinForms.Guna2GradientPanel b = new Guna.UI2.WinForms.Guna2GradientPanel();
                b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
                b.Size = new System.Drawing.Size(200, 54);
                b.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
                b.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
                
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
                if (UserList.Visible)
                    RenderCellText(Color.Silver, Color.Gray, e, (DataGridView)sender, true);
                else
                    RenderCellText(Color.Silver, Color.Gray, e, (DataGridView)sender, false);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }

        }

        private void FrontPhotoLogic(DataGridViewCellPaintingEventArgs e, MessengerCell textImageCell, bool show)
        {
            checked
            {
                try
                {
                    if (textImageCell.ImageFront != null)
                    {
                        e.Graphics.DrawImage(Resources.network15_10, e.CellBounds.X + 130, e.CellBounds.Y + 30, 10, 10);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    WriteLog.Save(ex2);
                    ProjectData.ClearProjectError();
                }
            }
        }
        private void HideNetworkIconWithPhoto(DataGridViewCellPaintingEventArgs e, MessengerCell textImageCell, DataGridView dgv, bool search, bool topalign, SizeF stringSize, int scrollwidth)
        {
            try
            {
                switch (textImageCell.Status)
                {
                    case UserStatus.Activo:
                        e.Graphics.DrawImage(Resources._57, e.CellBounds.X + 58, e.CellBounds.Y + 27, 12, 12);
                        break;
                    case UserStatus.Ocupado:
                        e.Graphics.DrawImage(Resources._60, e.CellBounds.X + 58, e.CellBounds.Y + 27, 12, 12);
                        break;
                    case UserStatus.Ausente:
                        e.Graphics.DrawImage(Resources._63, e.CellBounds.X + 58, e.CellBounds.Y + 27, 12, 12);
                        break;
                    case UserStatus.Online:
                        e.Graphics.DrawImageUnscaled(Resources.user_online_new, e.CellBounds.X + 61, e.CellBounds.Y + 30);
                        break;
                    case UserStatus.Idle:
                        e.Graphics.DrawImageUnscaled(Resources.useridle4, e.CellBounds.X + 61, e.CellBounds.Y + 30);
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }


        private void RenderCellText(Color color1, Color color2, DataGridViewCellPaintingEventArgs e, DataGridView dgv, bool search)
        {
            try
            {
                string text = e.FormattedValue.ToString();
                string text2 = "";
                int num = 55;
                Point point = new Point(e.CellBounds.X + num, (int)Math.Round(unchecked((double)e.CellBounds.Y + (double)e.CellBounds.Height / 4.0 - 8.0)));

                Font font2 = new Font("Segoe UI", 10f, FontStyle.Regular);
                new Font("Segoe UI", 10f, FontStyle.Bold);
                Font font3 = new Font("Segoe UI", 8f, FontStyle.Regular);
                string text3 = "";
                MessengerCell textAndImageCell = unchecked((MessengerCell)dgv[e.ColumnIndex, e.RowIndex]);
                if (textAndImageCell.User)
                {
                    dgv.Rows[e.RowIndex].Height = 54;
                    string[] array = Strings.Split(text, Modcommon.TEXT_SEPARATOR);
                    if (array.Length > 2)
                    {
                        text2 = array[2];
                    }

                    string text4 = Uri.UnescapeDataString(text2.Trim());
                    SizeF sizeF = default(SizeF);
                    sizeF = e.Graphics.MeasureString(text2, font3, dgv.Width - 75);
                    int num2 = ((dgv.Height >= dgv.Rows.GetRowsHeight(DataGridViewElementStates.Visible)) ? 85 : 70);
                    if (!search)
                    {
                        sizeF.Width = 0f;
                        sizeF.Height = 0f;
                    }
                    if (string.IsNullOrEmpty(text4))
                    {
                        text2 = text3;
                    }
                    bool selected = dgv[e.ColumnIndex, e.RowIndex].Selected;
                    Color foreColor2 = (selected && textAndImageCell.dblclickrow) ? Color.White : ((!textAndImageCell.dblclickrow) ? color2 : Color.White);
                    if (selected && !textAndImageCell.dblclickrow)
                    {
                        using (Pen pen = new Pen(ColorTranslator.FromHtml("#a6c2e4"))) //Aqui se remplaza este color por el azul "#319AFF" para cuando seleccionas 
                        {
                            pen.DashStyle = DashStyle.Dot;
                            using (Brush brush = new LinearGradientBrush(e.CellBounds, ColorTranslator.FromHtml("#e5f1fe"), ColorTranslator.FromHtml(" #e5f1fe"), LinearGradientMode.Vertical))
                            {
                                e.Graphics.DrawRectangle(pen, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                e.Graphics.FillRectangle(brush, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                            }
                        }
                    }

                    if (textAndImageCell.dblclickrow) //Aqui se pone blanco el nombre de usuario (remplazando por (textAndImageCell.mrow || selected) && !textAndImageCell.dblclickrow)
                    {
                        using (Pen pen3 = new Pen(ColorTranslator.FromHtml("#319AFF")))
                        {
                            using (Brush brush3 = new SolidBrush(ColorTranslator.FromHtml("#319AFF")))
                            {
                                e.Graphics.DrawRectangle(pen3, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                e.Graphics.FillRectangle(brush3, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                            }
                        }
                    }
                    /*
                    if (textAndImageCell.InactivoUser)
                    {
                        using (Pen pen3 = new Pen(Color.FromArgb(245, 245, 245)))
                        {
                            using (Brush brush3 = new SolidBrush(Color.FromArgb(245, 245, 245)))
                            {
                                e.Graphics.DrawRectangle(pen3, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                e.Graphics.FillRectangle(brush3, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                            }
                        }
                    }
                    */
                    //Avatar
                    e.Graphics.DrawImage(textAndImageCell.Image, e.CellBounds.X + 10, e.CellBounds.Y + 7, 38, 38);
                    //Imagen del estado
                    HideNetworkIconWithPhoto(e, textAndImageCell, dgv, search, false, sizeF, num2);

                    if (textAndImageCell.dblclickrow) //Remplazar por (textAndImageCell.mrow || selected) && !textAndImageCell.dblclickrow pa que te salga blanco cuando des clic en el cell
                    {
                        TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.White);
                    }
                    else
                    {
                        //Nombre de usuario
                        TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.Black);
                    }

                    //Posicion del Online
                    Point point2 = new Point(point.X + 13, point.Y + 20);
                    TextRenderer.DrawText(e.Graphics, text2, font3, point2, foreColor2);

                }



                //Prueba
                if (textAndImageCell.ImageFront != null)
                {
                    FrontPhotoLogic(e, textAndImageCell, true);
                }
                else
                {
                    FrontPhotoLogic(e, textAndImageCell, false);
                }

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }

        }

        //////////////////////////////////////////////////////////////////////


        private void lblSettings_MouseMove(object sender, MouseEventArgs e)
        {
            lblSettings.Image = Resources.settings_sel;
        }

        private void lblSettings_MouseLeave(object sender, EventArgs e)
        {
            lblSettings.Image = Resources.settings_unsel;
        }

        public ArrayList TabButtons;
        private bool _selrow;
        private string LastRow;

        public void ChangeUserSelection(string userId, bool Activo = false, bool MP = false, bool select = false)
        {
            try
            {
                if (userId != null)
                {
                    DataGridViewRow dataGridViewRow = (from DataGridViewRow r in UserList.Rows
                                                       where r.Cells[0].Value.ToString().Contains(userId)
                                                       select r).FirstOrDefault();
                    if (dataGridViewRow != null)
                    {
                        if (MP == false)
                        if (Activo)
                        {
                            ((MessengerCell)UserList[0, dataGridViewRow.Index]).InactivoUser = false;
                            UserList.Refresh();
                        }
                        else
                        {
                            ((MessengerCell)UserList[0, dataGridViewRow.Index]).InactivoUser = true;
                            UserList.Refresh();
                        }

                        if (MP)
                        {
                            if (select)
                            {
                                ((MessengerCell)UserList[0, dataGridViewRow.Index]).dblclickrow = true;
                                UserList.Refresh();
                            }
                            else
                            {
                                ((MessengerCell)UserList[0, dataGridViewRow.Index]).dblclickrow = false;
                                UserList.Refresh();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }

        private void lblServer_Click(object sender, EventArgs e)
        {
            PicRetryIcon.Show();
            UserList.Rows.Clear();
            LoadDefaultUser();
            Transmit("RecargarLista");
            PicRetryIcon.Hide();

        }

        private void UserList_MouseWheel(object sender, MouseEventArgs e)
        {
            return;
            UserList.EndEdit();
            if (e.Delta.Equals(120) && UserList.CurrentRow.Index != 0)
            {
                SendKeys.Send("{Up}");
            }
            else if (!e.Delta.Equals(120) && UserList.CurrentRow.Index != UserList.Rows.Count - 1)
                SendKeys.Send("{Down}");
        }
        public void RemoveUserFromGrid(string userID)
        {
            try
            {
                DataGridViewRow dataGridViewRow;
                if (UserList.Visible)
                {
                    dataGridViewRow = (from DataGridViewRow r in UserList.Rows
                                       where r.Cells[0].Value.ToString().Contains(userID)
                                       select r).FirstOrDefault();
                    if (dataGridViewRow != null)
                    {
                       UserList.Rows.Remove(dataGridViewRow);  
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        private void ActivoMenuItem_Click(object sender, EventArgs e)
        {
            lblImgstatus.Image = Resources._57;

            MyStatus = UserStatus.Activo;

            ChangePersonalMessageAndStatus(UserId, UserStatus.Activo);
            mnuOnlineT.Checked = true;
            mnuOcupadoT.Checked = false;
            mnuAusenteT.Checked = false;

            Transmit("Activo");

        }

        private void OcupadoMenuItem_Click(object sender, EventArgs e)
        {
            lblImgstatus.Image = Resources._60;

            MyStatus = UserStatus.Ocupado;

            ChangePersonalMessageAndStatus(UserId, UserStatus.Ocupado);
            mnuOnlineT.Checked = false;
            mnuOcupadoT.Checked = true;
            mnuAusenteT.Checked = false;

            Transmit("Ocupado");
        }
        private void AusenteMenuItem_Click(object sender, EventArgs e)
        {
            lblImgstatus.Image = Resources._63;

            MyStatus = UserStatus.Ausente;

            ChangePersonalMessageAndStatus(UserId, UserStatus.Ausente);
            mnuOnlineT.Checked = false;
            mnuOcupadoT.Checked = false;
            mnuAusenteT.Checked = true;

            Transmit("Ausente");
        }
        public static void SetIdle()
        {
            frm.lblImgstatus.Image = Resources.idlechat;
            MyStatus = UserStatus.Idle;
            frm.ChangePersonalMessageAndStatus(UserId, UserStatus.Idle);
            frm.TransmitFull("Idle");
        }


        private bool ChangeSpellCheckLanguage()
        {
            bool result = default(bool);
            try
            {
                ChangeImeMode(InputLanguage.CurrentInputLanguage.Culture);
                if (Modcommon.SPELL_CHECK)
                {
                    string text = InputLanguage.CurrentInputLanguage.Culture.ToString().Split('-')[0];
                    if (!text.Equals(_defaultlang))
                    {
                        _defaultlang = text;
                        string text2 = (Operators.CompareString(text, "es", TextCompare: false) == 0) ? "Spanish" : ((Operators.CompareString(text, "pl", TextCompare: false) == 0) ? "Polish" : ((Operators.CompareString(text, "de", TextCompare: false) == 0) ? "German" : ((Operators.CompareString(text, "fr", TextCompare: false) != 0) ? "English" : "French")));
                        if (!string.IsNullOrEmpty(text2))
                        {
                            Guna.UI2.WinForms.Guna2TextBox textBoxToDisable = txtSend;
                            txtSend = (Guna.UI2.WinForms.Guna2TextBox)textBoxToDisable;
                        }
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
                return false;
            }
        }
        private void ChangeImeMode(CultureInfo lang)
        {
            try
            {
                string left = lang.ToString();
                if (Operators.CompareString(left, "zh-CN", TextCompare: false) == 0)
                {
                    txtSend.ImeMode = ImeMode.On;
                }
                else
                {
                    txtSend.ImeMode = ImeMode.NoControl;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        public void Notificar(string message, string key)
        {
            Form existe = Application.OpenForms.OfType<Form>().SingleOrDefault(pre => pre.Name == "PopupStatus");
            if (existe != null)
            {
                existe.Close();
            }
            try
            {
                (new Thread(() => {
                    PopupStatus mensages = new PopupStatus(message, key);
                    mensages.Visible = false;
                    mensages.ShowDialog();
                })).Start();
            }
            catch { }
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            WriteChat(HtmlHelper.GetInfoMessage());
        }

        public void Crearlog(Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            WriteLog.Save(ex2);
            ProjectData.ClearProjectError();

        }

        public static void WriteChatMessages(int actionType, string userKey, string content, int userSelectedColor, string nickName = "")
        {
            string handle = nickName;

            if (string.IsNullOrEmpty(handle))
                handle = Modcommon.GetNamefromID(userKey);

            //        try
            //         {
            switch (actionType)
                {
                    case 1: // Rename
                    frm.WriteChat(HtmlHelper.GetRenameHtml(handle, content, DateTime.Now));
                    break;
                    case 2: // Join
                    frm.WriteChat(HtmlHelper.GetIngresoHtml(handle, DateTime.Now));
                    break;
                    case 3: // Quit
                    frm.WriteChat(HtmlHelper.GetDesconectoHtml(handle, DateTime.Now));
                    break;
                    case 4: // Mensage sin nada
                    frm.WriteChat(HtmlHelper.GetAlertHtml(content, handle));
                    break;
                    case 5: // Message
                    Application.DoEvents();

                    if (!WinMod.IsActiveMainWindow())
                    {
                        //frm.notifyIcons[0] = Resources.SC_Clean;
                        //frm.notifyIcons[1] = Resources.SC_Message;
                        //AnimateNotifyIcon.Animate(frm.NotifyIcon1, frm, frm.notifyIcons, 400);
                        FlashWin.Start(frm.Handle);
                    }
                    //Bubble Message 
                    frm.WriteChat(HtmlHelper.GetNameHtml(userKey, DateTime.Now, userName: nickName) + HtmlHelper.GetMessage(userKey, Modcommon.ProcessMessageLength(content), userSelectedColor.ToString()));

                    frm.beep = new SoundPlayer(Resources.beep1);
                        if (!Muted)
                        frm.beep.Play();
                        break;
                    case 6: // MP

                    frm.beep = new SoundPlayer(Resources.beep1);
                        if (!Muted)
                        frm.beep.Play();

                        break;
                    case 7: // Ficheros drag
                    frm.WriteChat(HtmlHelper.GetNameHtml(userKey, DateTime.Now, userName: nickName) + HtmlHelper.GetMessage(userKey, content, userSelectedColor.ToString()));

                    break;
                    case 8: // ScreenShot

                    frm.WriteChat(HtmlHelper.GetNameHtml(userKey, DateTime.Now, userName: nickName));
                    frm.WriteChat(HtmlHelper.GetMessage(userKey, HtmlHelper.GetScreenshot(content), userSelectedColor.ToString()));
                    break;
                    case 9: // Nada... probando
                    break;
                    case 10: // Mensaje sin Hora
                        break;
                }
        }
        public void WriteChat(string content)
        {
            HtmlString.Append(content);
            webChat.Document.Write(content);
            webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
            WireUpButtonEvents();

        }






        private void lblOMicon_Click(object sender, EventArgs e)
        {
            if (Modcommon.Hackerprod)
            {
                //NotifyIcon1.Visible = false;
                Process.GetCurrentProcess().Kill();
            }


        }
        public static int back = 2;
        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (UserMPContainer.Visible)
                {
                    string message = txtSend.Text;
                    if (!string.IsNullOrEmpty(txtSend.Text) && txtSend.Text != "")
                    {
                        Transmit("MP", UserMP.Tag + "◄" + message);
                        txtSend.Text = string.Empty;
                        e.SuppressKeyPress = true;

                        WriteChatMessages(4, "Aviso", "El Mensage privado ha sido recibido por " + Modcommon.GetNamefromID((string)UserMP.Tag) + ": <br><span Class='privatemessage-data'>" + message + "</span>", 0);
                        UserMPContainer.Hide();
                        ButtonArrow.Visible = true;
                        //txtSend.Size = new Size(305, 36);
                        //txtSend.Location = new Point(45, 14);
                        ChangeUserSelection((string)UserMP.Tag, MP: true);
                    }
                    else
                    {
                        txtSend.Text = string.Empty;
                        e.SuppressKeyPress = true;
                    }
                }
                else
                {

                    //Con esto se arregla
                    if (!string.IsNullOrEmpty(txtSend.Text) && txtSend.Text != "")
                    {
                        string message = txtSend.Text;
                        Transmit("m", message);
                        RecentMessages.Add(txtSend.Text);
                    }
                    txtSend.Text = string.Empty;
                    e.SuppressKeyPress = true;

                }
                //txtSend.Controls.Clear();
                return;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (txtSend.Text == "")
                {
                    back--;
                    if (back == 0)
                    {
                        UserMPContainer.Hide();
                        ButtonArrow.Visible = true;
                        //txtSend.Size = new Size(305, 36);
                        //txtSend.Location = new Point(45, 14);
                        ChangeUserSelection((string)UserMP.Tag, MP: true);
                        back = 2;
                    }
                }
            }
            else
                back = 2;

            Modcommon.ProcessKey(e);
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text) && txtSend.Text != "")
            {
                string message = txtSend.Text;
                Transmit("m", message);
                RecentMessages.Add(txtSend.Text);
            }
            txtSend.Text = string.Empty;
            //e.SuppressKeyPress = true;
        }

        private void TicToc_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTicToc.Text = DateTime.Now.ToString("h:mm:ss");
                int userCount = UserList.Rows.Count;
                if (userCount == 1)
                {
                    lblWelcome2UserPanel.Text = $"Actualmente tenemos {UserList.Rows.Count} usuario conectado";
                    //NotifyIcon1.Icon = Resources.SC_ICOoffline1;
                    lblServer.Image = Resources.ls_disconnect_1;
                }
                else
                {
                    lblWelcome2UserPanel.Text = $"Actualmente tenemos {UserList.Rows.Count} usuarios conectados";
                    //NotifyIcon1.Icon = Resources.SC_ICO;
                    lblServer.Image = Resources.ls_connect_1;
                }
                if (Environment.UserName == "Yohel")
                {
                    lblWelcome2UserPanel.Text = ($"Tenemos {UserList.Rows.Count} usuarios");
                }

            }
            catch { }

        }

        private void lblMuteUserPanel_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Muted)
                {
                    case false:

                        lblMuteUserPanel.Image = Resources.Notifyoff2;

                        WriteChat(HtmlHelper.GetMuteHtml(DateTime.Now, "", false));

                        Muted = true;
                        Transmit("Mute", "SonidoActiado");
                        break;
                    case true:
                        lblMuteUserPanel.Image = Resources.Notifyon2;

                        WriteChat(HtmlHelper.GetMuteHtml(DateTime.Now, "", true)); 

                        Muted = false;
                        Transmit("Mute", "SonidoDesactiado");
                        break;
                }
            }
            catch { }

        }
        public void CloseChildForm()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelContainer.Controls.Add(childForm);
            PanelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }

        private void lblSettingsUserPanel_Click(object sender, EventArgs e)
        {
            PanelChat.Visible = false;
            OpenChildForm(new frmSettings());
            //frmSettings settings = new frmSettings();
            //settings.BringToFront();
            //settings.ShowDialog();
        }
        private void timerEscribiendo_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < usersWriting.Items.Count; i++)
            {
                ListViewItem item = usersWriting.Items[i];
                switch (item.Name)
                {
                    case "5":
                        item.Name = "4";
                        break;
                    case "4":
                        item.Name = "3";
                        break;
                    case "3":
                        item.Name = "2";
                        break;
                    case "2":
                        item.Name = "1";
                        break;
                    case "1":
                        usersWriting.Items.Remove(item);
                        break;
                }
            }
            int escribiendo = usersWriting.Items.Count;
            if (escribiendo == 0)
            {
                UsuarioEscribiendo.Text = "";
            }
        }
        private int i { get; set; } = 0;
        private int writeCount { get; set; } = 0;
        private object _defaultlang;

        private void txtSend_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                    return;
                if (e.KeyCode == Keys.Down)
                {
                    try
                    {
                        txtSend.Text = RecentMessages[i];
                        txtSend.SelectionStart = txtSend.Text.Length;
                        if (i < RecentMessages.Count - 1)
                            i++;
                        else
                            i = 0;
                    }
                    catch (Exception ex) { Crearlog(ex); }
                }
                switch (writeCount)
                {
                    case 0:
                        Transmit("Escribiendo");
                        writeCount = 1;
                        break;
                    case 1:
                        writeCount = 2;
                        break;
                    case 2:
                        writeCount = 0;
                        break;
                }

                

            }
            catch { }

        }
        public static void ApplySettings(bool changeImage, bool nick, string newNick = "")
        {
            if (changeImage)
            {
                int rowCount = frm.UserList.RowCount;
                int num = checked(rowCount - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    MessengerCell textAndImageCell = (MessengerCell)frm.UserList[0, i];
                    if (textAndImageCell.UserId == UserId)
                        textAndImageCell.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(UserId, NickName));
                }
                //frm.AvatarUserPanel.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(UserId, NickName));
                frm.pictureBox1.Image = Modcommon.CropToCircle(LetterImage.GetUserImage(UserId, NickName));
            }
            if (nick)
            {
                try
                {
                    string name = frm.lblWelcomeUserPanel.Text;
                    string[] Datos = name.Split(' ');
                    string userName = Datos[1];

                    frm.TransmitFull("NickChange", newNick);
                    NickName = newNick;
                }
                catch { }

                frm.lblWelcomeUserPanel.Text = $"Bienvenido {NickName} a la red";
            }


            frm.settings.GuardarSettings();

        }

        private void pnlUserPanel_Click(object sender, EventArgs e)
        {
            HideShowUserPanel();
        }
        public void HideShowUserPanel()
        {
            if (!UserPanel)
            {
                //HideChatPanel(true);
                //pnlUserPanel.Image = Resources.user_sel;
                UserPanel = true;
            }
            else if (UserPanel)
            {
                //HideChatPanel(false);
                //pnlUserPanel.Image = Resources.user_unsel;
                UserPanel = false;
            }
        }
        private void pnlUserPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (UserPanel)
            {
                //pnlUserPanel.Image = Resources.user_unsel;
            }
            else
            {
                //pnlUserPanel.Image = Resources.user_sel;
            }
        }

        private void pnlUserPanel_MouseLeave(object sender, EventArgs e)
        {
            if (UserPanel)
            {
                //pnlUserPanel.Image = Resources.user_sel;
            }
            else
            {
                //pnlUserPanel.Image = Resources.user_unsel;
            }
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);
                MessageBox.Show($"Socket connected to {((IPEndPoint)client.RemoteEndPoint).Address.ToString()}");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void AvatarUserPanel_Click(object sender, EventArgs e)
        {
            if (!Modcommon.Hackerprod)
                return;

            Modcommon.ReleaseMemory();
            MessageBox.Show(Modcommon.GetIPfromPCName("Musicalprod"));




            // 0-0-0-0-0-0-0-0-0-0-0-0

            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;

            //Agrego los subItems(Nombre y estado)
            ListViewItem.ListViewSubItem user = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(user);

            //Asigno Name y Text a los subItems
            lvi.SubItems[0].Text = DateTime.Now.ToShortTimeString();
            lvi.SubItems[0].Name = "5";
            lvi.SubItems[0].Tag = "Popello";                   //Borrar si algo
            usersWriting.Items.Add(lvi);


            return;
            int tt = 0;
            DataGridViewRow dataGridViewRow = Modcommon.GetRowfromID(UserId);
            MessengerCell textAndImageCell = ((MessengerCell)UserList[0, dataGridViewRow.Index]);
            switch (tt)
            {
                case 0:
                    textAndImageCell.ImageFront = Resources.network15_10;
                    tt = 1;
                    break;

                case 1:
                    textAndImageCell.ImageFront = null;
                    tt = 0;
                    break;
            }
            UserList.Refresh();

            return;





            /*

            int rowCount = UserList.RowCount;
            int num = checked(rowCount - 1);
            for (int i = 0; i <= num; i = checked(i + 1))
            {
                TextAndImageCell textAndImageCell = (TextAndImageCell)UserList[0, i];
                if (textAndImageCell.UserName == "Hackerprod")
                    textAndImageCell.Image = Modcommon.CropToCircle(LetterImage.GetUserImage("Lol"));
            }


/*
            HtmlString.AppendFormat( $"<div id='{"Hackerprod"}' class='message my-message-{"0"}'>");


            //!!Codigos para el chat!!//------------------------------------------------------

            //Tranferencia (Recibiendo)
            HtmlHelper.GetMessageReceiving("Hackerprod", filePath, 0);
            //Tranferencia (Enviando)
            HtmlHelper.GetMessageSending("Hackerprod", filePath, 0);

            //Cartel con raya diciendo la fecha
            HtmlHelper.GetDateHeaderBox(DateTime.Now)

            //Letras a la derecha sin bubble "sensillo pero tocao"
            string msg = "<div class='sep'></div><div class=\"msg_leftgc\" >" + "Aqui va el mensaje" + "</div><div class='sep'></div>";

            //Pone el titulo de una cancion o un mensaje de voz
            HtmlHelper.GetVoiceMessage("Enamorarme de ti 2 (la melodía).mp3", DateTime.Now)




            //!!--------------------!!//------------------------------------------------------

            string str4 = new Uri(@"D:\01. Mientes.mp3").AbsoluteUri;
            string str5 = new Uri(@"D:\01. Mientes.mp3", true).AbsoluteUri;
            bool Expression = true;
            string fileName = "fileName";
            string fileName1 = "Este es el fichero.zip";
            string fromName = "fromName";



            //webChat.Document.Write(HtmlString.ToString());




            */
            /*

            //Pruebas con javascript 
            HtmlElement headElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptElement = webChat.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptElement.DomElement;
            element.text = @"function test(name, address) { window.alert('Name is ' + name + '; address is ' + address); }  ";
            element.text = @"function mess() {  return('This is a test.'); } ";
            headElement.AppendChild(scriptElement);

            string name = "Daimel";
            string address = "San Luis";
            Object[] objArray = new Object[2];
            objArray[0] = (Object)name;
            objArray[1] = (Object)address;
            webChat.Document.InvokeScript("test", objArray);

            string mess = webChat.Document.InvokeScript("mess").ToString();
            MessageBox.Show(mess);

            */


            string Name = @"D:\Instaladores\Programación\Projects\KosmoChat\KosmoChat\bin\Debug";
            Object[] objArray = new Object[2];
            objArray[0] = (Object)Name;
            objArray[1] = (Object)"";


            webChat.Document.InvokeScript("scrolltobottom");


            //string mess = webChat.Document.InvokeScript("getSelectionText").ToString();

            string url = new Uri(@"D:\Regueros\Compartido\outputmessengers").AbsoluteUri;
            string url2 = @"D:\Regueros\Compartido\outputmessengers";
            string str2 = string.Format($"<a onclick='javascript:openurl(\"{url2}\")' >{url2}</a>");


            BearWare.FileTransfer file = new BearWare.FileTransfer();
            file.szLocalFilePath = "";

        }









        ////////////////////////////////////////////////////////////////////////////////////////
        /// Chat nuevo
        ////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        public void UpdateChat()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(UpdateChat));
                }
                else
                {
                   // messages = new Messages();
                    messages.Dequeue().ToMessageString();
                    FlashWindow(Handle, false);
                }
            }
            catch
            {
                Console.WriteLine("lol, fail");
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        private void TmrAutoCopy_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!webChat.IsDisposed)
                {
                    webChat.Document.Body.SetAttribute("title", "");
                }
                TmrAutoCopy.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        public void AssignStyleSheet(WebBrowser wBrowser)
        {
            string name = webChat.Name;
            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)webChat.Document.DomDocument).createStyleSheet("", 0);

            NewLateBinding.LateSet(instance, null, "cssText", new object[1]
            {
                HtmlHelper.GetStyles() + "\r\n" + css.GetMyCSS()
            }, null, null);

            HtmlElement htmlElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = webChat.Document.CreateElement("script");
            IHTMLScriptElement iHTMLScriptElement = (IHTMLScriptElement)htmlElement2.DomElement;

            iHTMLScriptElement.text = HtmlHelper.GetJavascript();

            htmlElement.AppendChild(htmlElement2);
        }

        private void picViewDesktop_Click(object sender, EventArgs e)
        {
            var task = Task.Factory.StartNew(() => screenCaptured = HtmlHelper.GetScreenshot());

            task.ContinueWith(
            t =>
            {
                
                if (screenCaptured != null)
                {
                    //Nombre y hora
                    WriteChat(HtmlHelper.GetNameHtml(UserId, DateTime.Now, userName: NickName));
                    //Bubble Message 
                    WriteChat(HtmlHelper.GetMessage(UserId, screenCaptured, UserSelectedColor.ToString()));

                    if (!WinMod.IsActiveMainWindow())
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                    }
                    screenCaptured = null;

                    SendScreenShot();
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnRanToCompletion,
            TaskScheduler.FromCurrentSynchronizationContext());


        }
        public void SendScreenShot()
        {
            //Enviar captura
            try
            {
                //Change Icon Status
                int rowCount = UserList.RowCount;
                int num = checked(rowCount - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    MessengerCell textAndImageCell = (MessengerCell)UserList[0, i];
                    //if (textAndImageCell.UserName != NickName)
                    //FileTransfer.Send(Modcommon.SCREENSHOT_LAST, "*ScreenShot*" + NickName, textAndImageCell.IP);
                }
            }
            catch { }
        }


        public void SetpanelToolsLocation(bool open = true)
        {
            try
            {
                if (open)
                    panelTools.Location = new Point(panelTools.Location.X +140, panelTools.Location.Y);
                else
                    panelTools.Location = new Point(panelTools.Location.X -140, panelTools.Location.Y);
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }

        public void ScrollpanelTools()
        {
            panelTools.Location = new Point(panelTools.Location.X -140, panelTools.Location.Y);
            picMore.Hide();
        }



        private void picMore_MouseHover(object sender, EventArgs e)
        {
            ScrollpanelTools();
           trance.Start();
        }


        private void picVideoChat_MouseLeave(object sender, EventArgs e)
        {
            picVideoChat.Image = (Image)Modcommon.ChangeOpacity(Resources.video, 0.7f);
            Hidepanel.Enabled = true;
        }

        private void picViewDesktop_MouseLeave(object sender, EventArgs e)
        {
            picViewDesktop.Image = Modcommon.ChangeOpacity((Image)Resources.remote_desktop_grey, 0.7f);
            Hidepanel.Enabled = true;
        }

        private void picFileSend_MouseLeave(object sender, EventArgs e)
        {
            picFileSend.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.file_send_s, 0.7f);
            Hidepanel.Enabled = true;
        }

        private void picBuzz_MouseLeave(object sender, EventArgs e)
        {
            Hidepanel.Enabled = true;
            picBuzz.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.buzz4, 0.7f);
        }

        private void picPresetMessage_MouseLeave(object sender, EventArgs e)
        {
            Hidepanel.Enabled = true;
            picPresetMessage.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.preset_message1, 0.7f);
        }

        private void picVoiceChat_MouseLeave(object sender, EventArgs e)
        {
            picVoiceChat.Image = Modcommon.ChangeOpacity(Resources.voice_chat, 0.7f);
            Hidepanel.Enabled = true;
        }

        private void picSmiley_MouseLeave(object sender, EventArgs e)
        {
            picSmiley.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.Emotion, 0.7f);
            Hidepanel.Enabled = true;
        }


        private void picSmiley_MouseEnter(object sender, EventArgs e)
        {
            Hidepanel.Enabled = false;
            picSmiley.Image = (Image)Resources.Emotion;
        }

        private void picVoiceChat_MouseEnter(object sender, EventArgs e)
        {
            Hidepanel.Enabled = false;
            picVoiceChat.Image = Resources.voice_chat;
        }

        private void picPresetMessage_MouseEnter(object sender, EventArgs e)
        {
            Hidepanel.Enabled = false;
            picPresetMessage.Image = (Image)Resources.preset_message1;
        }

        private void picBuzz_MouseEnter(object sender, EventArgs e)
        {
            Hidepanel.Enabled = false;
            picBuzz.Image = (Image)Resources.buzz4;
        }

        private void picFileSend_MouseEnter(object sender, EventArgs e)
        {
            Hidepanel.Enabled = false;
            picFileSend.Image = (Image)Resources.file_send_s;
        }

        private void picViewDesktop_MouseEnter(object sender, EventArgs e)
        {
            picViewDesktop.Image = Resources.remote_desktop_grey;
            Hidepanel.Enabled = false;

        }

        private void picVideoChat_MouseEnter(object sender, EventArgs e)
        {
            picVideoChat.Image = Resources.video;
            Hidepanel.Enabled = false;
        }

       
        private void Buzz_Tick(object sender, EventArgs e)
        {
            if (MyStatus == UserStatus.Ocupado)
                return;

            Point pointO = Location;
            Point pointL = new Point(pointO.X - 10, pointO.Y);
            Point pointR = new Point(pointO.X + 10, pointO.Y);

            FormWindowState state = WindowState;
            if (state == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            beep = new SoundPlayer(Resources.Buzz);
            if (!Muted)
                beep.Play();

            Location = pointL;
            Thread.Sleep(50);
            Location = pointR;
            Thread.Sleep(50);

            Location = pointL;
            Thread.Sleep(50);
            Location = pointR;
            Thread.Sleep(50);

            Location = pointL;
            Thread.Sleep(50);
            Location = pointR;
            Thread.Sleep(50);

            Location = pointO;
            WindowState = state;
            Buzz.Enabled = false;
        }

        private void picBuzz_Click(object sender, EventArgs e)
        {
            Transmit("buzz");
        }
        public void ChangeOpacitypanelTools()
        {
            picVideoChat.Image = (Image)Modcommon.ChangeOpacity(Resources.video, 0.7f);
            picViewDesktop.Image = Modcommon.ChangeOpacity((Image)Resources.remote_desktop_grey, 0.7f);
            picFileSend.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.file_send_s, 0.7f);
            picBuzz.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.buzz4, 0.7f);
            picPresetMessage.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.preset_message1, 0.7f);
            picVoiceChat.Image = Modcommon.ChangeOpacity(Resources.voice_chat, 0.7f);
            picSmiley.Image = (Image)Modcommon.ChangeOpacity((Image)Resources.Emotion, 0.7f);
        }

        private void picPresetMessage_Click(object sender, EventArgs e)
        {
            mnuPresetMsg.Show((Control)picPresetMessage, new Point(0, 20));
        }

        private void Hola_PresetMsg_Click(object sender, EventArgs e)
        {
            Transmit("m", "Hola!");
        }

        private void dime_PresetMsg_Click(object sender, EventArgs e)
        {
            Transmit("m", "Dime");
        }

        private void salir_PresetMsg_Click(object sender, EventArgs e)
        {
            Transmit("m", "Voy a salir");
        }

        private void ocupado_PresetMsg_Click(object sender, EventArgs e)
        {
            Transmit("m", "Estoy ocupado");
        }

        private void noPuedo_PresetMsg_Click(object sender, EventArgs e)
        {
            Transmit("m", "No puedo");
        }

        private void picSmiley_Click(object sender, EventArgs e)
        {
            try
            {
                Emoticons emo = new Emoticons();
                emo.location(Location.X, Location.Y);
                emo.ShowDialog();

                Transmit("Smile", emo.SmiliE);
            }
            catch { }
        }
        public int SelIndex;
        public int SeloldIndex;

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                textAndImageCellMenu = (MessengerCell)UserList[0, e.RowIndex];

                if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    ((MessengerCell)NewLateBinding.LateGet(sender, null, "Item", new object[2]
                    {
                    0,
                    e.RowIndex
                    }, null, null, null)).Selected = false;
                }

                if (e.Button == MouseButtons.Right)
                {
                    ShowMenuInUserlist((DataGridView)sender, e.RowIndex, e.X, e.Y);
                }

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        private void ShowMenuInUserlist(DataGridView dgv, int rowd, int xx, int yy)
        {
            try
            {

                //El mensage me muestra el nombre del usuario al que di click
                //MessageBox.Show(((TextAndImageCell)NewLateBinding.LateGet(dgv, null, "Item", new object[2]{0, rowd }, null, null, null)).UserName);

                Rectangle cellDisplayRectangle = dgv.GetCellDisplayRectangle(0, rowd, cutOverflow: true);
                textAndImageCellMenu = (MessengerCell)dgv[0, rowd];

                UserMenu.Show(dgv, cellDisplayRectangle.Left + xx, cellDisplayRectangle.Top + yy);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }


        //Menus///////////////////////////////////////////////////////////////////////////////
        private string UsuarioSeleccionado;
        private string IPSeleccionado;
        private string URLO;
        private void mensajePrivadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)UserMP.Tag))
                ChangeUserSelection((string)UserMP.Tag, MP: true);

            UserMP.Tag = textAndImageCellMenu.UserId;
            try
            {
                UserMPContainer.Visible = true;
                ButtonArrow.Visible = false;
                //txtSend.Location = new Point(53, 14);
                //txtSend.Size = new Size(296, 36);
                UserMP.Image = ImageHandler.ResizeIMGAvatar((Bitmap)textAndImageCellMenu.Image, 34, 34);
                lblMP.Text = "Mensaje" + Environment.NewLine + "privado";
                txtSend.Focus();
                txtSend.SelectionStart = txtSend.TextLength;
                ChangeUserSelection((string)UserMP.Tag, MP: true, select: true);
            }
            catch { }
        }
        private void beepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserId;
                if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                {
                    MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    return;
                }
                string beepear = UsuarioSeleccionado;
                Transmit("beep", beepear);

                WriteChatMessages(4, UsuarioSeleccionado, "Has enviado un beep a " + Modcommon.GetNamefromID(UsuarioSeleccionado), mensage.ColorID);
            }
            catch { }
        }

        private void explorarPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IPSeleccionado = textAndImageCellMenu.IP;

                Process.Start(@"\\" + IPSeleccionado);
            }
            catch { }

        }

        private void enviarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //TeamTalk.Remote.TeamTalk.SendFile(textAndImageCell_MouseMove.IP, textAndImageCell_MouseMove.UserName);
            }
            catch { }

        }
        private void videollamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserName;
                if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                {
                    MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    return;
                }
                else
                {
                    //Videollamada
                }
            }
            catch { }

        }

        private void llamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserName;
                if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                {
                    MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    return;
                }
                    //Videollamada
            }
            catch { }

        }
        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserId;
                Transmit("GiveInfo", UsuarioSeleccionado);
            }
            catch (Exception ex) { Crearlog(ex); }
        }
        private void escritorioRemotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserName;
                if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                {
                    MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                }
                else
                {
                    //Escritodio Remoto
                    //ScreenCaptureInit.Connect(UsuarioSeleccionado);                
                }
            }
            catch { }
        }

        private void buzzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioSeleccionado = textAndImageCellMenu.UserId;

            Transmit("buzz", UsuarioSeleccionado);
        }

        private void UserList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UsuarioSeleccionado = textAndImageCellMenu.UserName;
                IPSeleccionado = textAndImageCellMenu.IP;
                //Para detectar una pulsacion en C# tenemos que controlar el evento keyUp del control correspondiente de la siguiente manera:
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.B))
                {
                    if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        Transmit("beep", textAndImageCellMenu.UserId);

                        WriteChatMessages(4, UserId, "Has enviado un beep a " + UsuarioSeleccionado, mensage.ColorID);
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.E))
                {
                    Process.Start(@"\\" + IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.P))
                {
                    if (!string.IsNullOrEmpty((string)UserMP.Tag))
                        ChangeUserSelection((string)UserMP.Tag, MP: true);

                    UserMP.Tag = textAndImageCell_MouseMove.UserId;
                    try
                    {
                        UserMPContainer.Visible = true;
                        ButtonArrow.Visible = false;
                        //txtSend.Location = new Point(53, 14);
                        //txtSend.Size = new Size(296, 36);
                        UserMP.Image = ImageHandler.ResizeIMGAvatar((Bitmap)textAndImageCell_MouseMove.Image, 34, 34);
                        lblMP.Text = "Mensaje" + Environment.NewLine + "privado";
                        txtSend.Focus();
                        txtSend.SelectionStart = txtSend.TextLength;
                        ChangeUserSelection((string)UserMP.Tag, MP: true, select: true);
                    }
                    catch { }

                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.A))
                {
                    //Enviar Archivo
                    FileTransfer.Iniciar(IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.C))
                {
                    if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Llamada
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.V))
                {
                    if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Videollamada
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.D))
                {
                    if (textAndImageCellMenu.Status == UserStatus.Ocupado)
                    {
                        MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                    }
                    else
                    {
                        //Escritodio Remoto
                        try
                        {
                            Transmit("Control");
                        }
                        catch (Exception ex) { Crearlog(ex); }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.N))
                {
                    UsuarioSeleccionado = textAndImageCellMenu.UserName;

                    Transmit("buzz", UsuarioSeleccionado);
                }
                else if (Modcommon.GetPressLetter(e))
                {
                    txtSend.Text += Modcommon.GetLetterPress(e);
                    txtSend.Focus();
                    txtSend.SelectionStart = txtSend.TextLength + 1;
                }
                e.SuppressKeyPress = true; //Quitar sonido al enter

            }
            catch (Exception ex) { Crearlog(ex);  }

        }


        private void UserList_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyData.ToString());

        }

        private void UserList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string ip = textAndImageCell_MouseMove.IP;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {
                    string file = files[i];
                    //Transfer.FileTransfer.Send(file, "*FileTransfer*" + NickName, ip);
                    //TeamTalk.Remote.TeamTalk.SendFile(ip, textAndImageCell_MouseMove.UserName, file);
                }
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }
        private void UserList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void UserList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try { textAndImageCell_MouseMove = (MessengerCell)UserList[0, e.RowIndex]; } catch { }
        }



        ////////////////////////////////////////////////////////////////////////////////////////

      
        private void Upd_Click(object sender, EventArgs e)
        {
            try { Modcommon.LoadUpdate(); } catch { }

            UpdateManager.Update(txtSend.Text);

            return;
            try
            {
                if (!string.IsNullOrEmpty(txtSend.Text))
                    IPSeleccionado = txtSend.Text;
                else
                {
                    try
                    {
                        int rowCount = UserList.RowCount;
                        int num = checked(rowCount - 1);
                        for (int i = 0; i <= num; i = checked(i + 1))
                        {
                            MessengerCell textAndImageCell = (MessengerCell)UserList[0, i];
                            FileTransfer.Update(textAndImageCell.IP);
                        }
                    } catch { }
                }
            }
            catch { }
        }
        private void webChatMenu_Opening(object sender, CancelEventArgs e)
        {
            //! Screen coordinates
            Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);
            //! Browser coordinates
            Point BrowserCoord = webChat.PointToClient(ScreenCoord);
            HtmlElement elem = webChat.Document.GetElementFromPoint(BrowserCoord);

            //! Hide all menu items
            for (int i = 0; i < webChatMenu.Items.Count; i++)
            {
                webChatMenu.Items[i].Visible = false;
            }

            //! Show what we want to see.
            switch (elem.TagName)
            {
                case "A":
                    //! This is a link.. display the appropriate menu items
                    AbrirMenuItem.Visible = true;
                    break;
                case "IMG":
                    //! This is an image.. show our image menu items
                    Modcommon.TEMP_VAR = elem.Id;
                    AbrirMenuItem.Visible = true;
                    GuardarMenuItem.Visible = true;
                    SubirMenuItem.Visible = true;
                    BajarMenuItem.Visible = true;
                    break;
                default:
                    //! This is anywhere else
                    SubirMenuItem.Visible = true;
                    BajarMenuItem.Visible = true;
                    limpiarChatMenuItem.Visible = true;
                    HistorialMenuItem.Visible = true;
                    break;
            }

        }

        private void SubirMenuItem_Click(object sender, EventArgs e)
        {
            webChat.Document.Window.ScrollTo(0, 0);
        }

        private void BajarMenuItem_Click(object sender, EventArgs e)
        {
            webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
        }

        private void GuardarMenuItem_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(Modcommon.TEMP_VAR.ToLower());

            string extSinPunto = ext.Replace(".","");
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = $"Archivo {Modcommon.ToUpperFirst(extSinPunto)}(*{ext})|*{ext}|" + "All Files(*.*)|*.*";

            save.FileName = Path.GetFileName(Modcommon.TEMP_VAR.ToLower());
            if (save.ShowDialog() == DialogResult.OK)
                File.Copy(Modcommon.TEMP_VAR, save.FileName);
        }

        private void AbrirMenuItem_Click(object sender, EventArgs e)
        {
            HtmlHelper.OpenFile(Modcommon.TEMP_VAR);
        }
        private void webChat_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            DoDragDrop(e.Url.ToString(), DragDropEffects.Copy);
            e.Cancel = true;
            TransmitFile(Modcommon.convertURI(e.Url.ToString()));
        }
        protected void TransmitFile(string file, string ip = null)
        {

            if (ip == null)
            {
                int rowCount = UserList.RowCount;
                int num = checked(rowCount - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    MessengerCell textAndImageCell = (MessengerCell)UserList[0, i];
                    //FileTransfer.Send(file, "*drag*" + NickName, textAndImageCell.IP);
                }
            }
            else
            {
                //FileTransfer.Send(file, "*drag*" + NickName, ip);
            }

        }

        protected void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WireUpButtonEvents();
        }
        public void WireUpButtonEvents()
        {
            
            HtmlElementCollection elements = webChat.Document.GetElementsByTagName("IMG");
            for (int i = 0; i < elements.Count; i++)
            {
                HtmlElement el = elements[i];
                el.AttachEventHandler("ondblclick", (sender, args) => OnElementClicked(el, EventArgs.Empty));
            }
            HtmlElementCollection body = webChat.Document.GetElementsByTagName("BODY");
            for (int i = 0; i < body.Count; i++)
            {
                HtmlElement el = body[i];
                el.AttachEventHandler("onclick", (sender, args) => OnElementSelect(el, EventArgs.Empty));
            }

        }
        protected void OnElementSelect(object sender, EventArgs args)
        {
            //Hecho por mi
            string selection =  webChat.Document.InvokeScript("getSelectionText").ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                Clipboard.Clear();
                Clipboard.SetText(selection, TextDataFormat.UnicodeText);
            }
        }

        protected void OnElementClicked(object sender, EventArgs args)
        {
            HtmlElement el = sender as HtmlElement;
            string elType = el.GetAttribute("type");
            string elName = el.GetAttribute("name");
            string elValue = el.GetAttribute("value");

            HtmlHelper.OpenFile(Modcommon.convertURI(el.Id));

        }

        private void webChat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (txtSend.Focused)
                return;

            string key = Modcommon.GetLetterPress2(e);
            txtSend.Text += key;
            txtSend.Focus();
            txtSend.SelectionStart = txtSend.TextLength + 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Monitorear monitor = new Monitorear();
            monitor.Show();
        }
        private void songPlayer_Click(object sender, EventArgs e)
        {
            if (songPlaying)
                goto Label_1;

            Mplayer = Application.OpenForms.OfType<Form>().SingleOrDefault(pre => pre.Name == "Player");
            if (Mplayer != null)
            {
                Mplayer.ShowInTaskbar = true;
                Mplayer.Visible = true;
                Mplayer.WindowState = FormWindowState.Normal;
                Mplayer.Activate();
                songPlaying = true;
            }
            else
            {
                if (Mplayer == null)
                {
                    Player mPlayer = new Player();
                    mPlayer.Show();
                }
            }
            return;

            Label_1:
            
            Mplayer.ShowInTaskbar = true;
            Mplayer.Visible = true;
            Mplayer.WindowState = FormWindowState.Normal;
            Mplayer.Activate();

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (CleanWhenClose)
                CleanTempFiles();

            DisconnectFromChat();
            //Modcommon.StopServers();
            //TeamTalk.Remote.TeamTalk.Disconnect();
            //TeamTalk.Local.TeamTalk.Disconnect();
            Settings.ResetId();
            settings.GuardarSettings();

            //NotifyIcon1.Visible = false;

            Process.GetCurrentProcess().Kill();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void mnuSettingsT_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
            PanelChat.Visible = false;
            OpenChildForm(new frmSettings());
            //frmSettings settings = new frmSettings();
            //settings.BringToFront();
            //settings.ShowDialog();
        }

        private void picVideoChat_Click(object sender, EventArgs e)
        {
            //Modcommon.Test();
        }


        private void UserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)UserMP.Tag))
                ChangeUserSelection((string)UserMP.Tag, MP: true);

            UserMP.Tag = textAndImageCellMenu.UserId;
            try
            {
                UserMPContainer.Visible = true;
                ButtonArrow.Visible = false;
                //txtSend.Location = new Point(53, 14);
                //txtSend.Size = new Size(296, 36);
                UserMP.Image = ImageHandler.ResizeIMGAvatar((Bitmap)textAndImageCellMenu.Image, 34, 34);
                lblMP.Text = "Mensaje" + Environment.NewLine + "privado";
                txtSend.Focus();
                txtSend.SelectionStart = txtSend.TextLength;
                ChangeUserSelection((string)UserMP.Tag, MP: true, select: true);
            }
            catch { }
        }

        protected const int HWND_TOPMOST = -1;
        protected const int SWP_NOACTIVATE = 16;
        protected const int SW_SHOWNOACTIVATE = 4;

        private void LoadSettings()
        {

            //Width = Modcommon.FormWidth;
            //Height = Modcommon.FormHeight;
            //stcMain.SplitterDistance = Modcommon.SplitterDistance;

            if (CenterScreen && !PosicionOriginal)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            else if (GuardarPosicion && !PosicionOriginal)
            {
                Left = Modcommon.FormLeft;
                Top = Modcommon.FormTop;
            }
            else
            {
                Rectangle workingArea = Screen.GetWorkingArea(this);
                base.Location = new Point(workingArea.Right - base.Size.Width, workingArea.Bottom - base.Size.Height);
            }

        }

        private void lblTicToc_Click(object sender, EventArgs e)
        {
        }

        private void limpiarChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webChat.Document.OpenNew(true).Write($"<html><head>" + $"{HtmlHelper.GetHtmlIEVersion()}" + $"<title name = 'head'>KosmoChat</title>" + $"</head><body class='body'>");

        }

        private void solicitarHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SolicitarMensages();
        }

        private void solicitarHistorialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UsuarioSeleccionado = textAndImageCellMenu.UserId;

            Transmit("GiveChat", UsuarioSeleccionado);
        }

        private void sincronizarFechaToolStrip_Click(object sender, EventArgs e)
        {
            UsuarioSeleccionado = textAndImageCellMenu.UserId;

            Transmit("GiveDateTime", UsuarioSeleccionado);
        }

        private void pnlTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlTitlebar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void pnlTitlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void lblSettingsUserPanel_MouseMove(object sender, MouseEventArgs e)
        {
            lblSettingsUserPanel.Image = Resources.settings_sel;
        }

        private void lblSettingsUserPanel_MouseLeave(object sender, EventArgs e)
        {
            lblSettingsUserPanel.Image = Resources.settings_unsel;
        }


        private void lblMP_Click(object sender, EventArgs e)
        {
            UserMPContainer.Hide();
            ButtonArrow.Visible = true;
            txtSend.Size = new Size(305, 36);
            txtSend.Location = new Point(45, 14);
            ChangeUserSelection((string)UserMP.Tag, MP: true);
        }

        public void Update_Click(object sender, EventArgs e)
        {
            Modcommon.LoadUpdate(); 

            try
            {
                if (frm.textAndImageCellMenu != null)
                    IPSeleccionado = frm.textAndImageCell_MouseMove.IP;

                if (string.IsNullOrEmpty(IPSeleccionado))
                    IPSeleccionado = frm.txtSend.Text;

                UpdateManager.Update(IPSeleccionado);
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }
        }

        private void CloseChat_Click(object sender, EventArgs e)
        {
            try
            {
                if (frm.textAndImageCellMenu != null)
                    frm.Transmit("Exit", frm.textAndImageCellMenu.UserName);
            }
            catch { }
        }
        private void FileSystem_Click(object sender, EventArgs e)
        {
            try
            {
                IPSeleccionado = textAndImageCellMenu.IP;
                frmRfs frm = new frmRfs();
                frm.Start(IPSeleccionado);
                frm.Show();
            }
            catch { }
        }
        private bool Kh_KeyDown(Keys arg)
        {
            try
            {
                if (arg.ToString() == KeyTop)
                {
                    if (WindowState == FormWindowState.Minimized)
                    {
                        ShowMainWindow();
                    }
                    else if (WindowState == FormWindowState.Normal && !WinMod.IsActiveMainWindow())
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                    }
                    else if (WindowState == FormWindowState.Normal && WinMod.IsActiveMainWindow())
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                    else if (!Visible)
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                    }
                }
            }
            catch (Exception ex) { WriteLog.Show(ex); }
            return true;
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.ToString());
            try
            {
                if (e.ToString() == KeyTop)
                {
                    if (WindowState == FormWindowState.Minimized)
                    {
                        ShowMainWindow();
                    }
                    else if (WindowState == FormWindowState.Normal && !WinMod.IsActiveMainWindow())
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                    }
                    else if (WindowState == FormWindowState.Normal && WinMod.IsActiveMainWindow())
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                    else if (!Visible)
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                    }
                }
            }
            catch (Exception ex) { WriteLog.Show(ex); }

        }

        private void RecargarLista_Tick(object sender, EventArgs e)
        {
            if (PingManager.NetPing.IsBusy)
            {
                PingManager.NetPing.CancelAsync();

                if (!PingManager.NetPing.IsBusy)
                    PingManager.NetPing.RunWorkerAsync();
            }
            else
            {
                PingManager.NetPing.RunWorkerAsync();
            }

        }

        private void chatPrivadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UsuarioSeleccionado = textAndImageCell_MouseMove.UserId;

            frmCP privateChat = Application.OpenForms.OfType<frmCP>().SingleOrDefault(pre => ((string)pre.Tag == Modcommon.GetChatId(UserId, UsuarioSeleccionado)));
            if (privateChat != null)
            {
                privateChat.ShowInTaskbar = true;
                privateChat.Visible = true;
                privateChat.WindowState = FormWindowState.Normal;
                privateChat.Activate();
            }
            else
            {
                privateChat = new frmCP(Modcommon.GetChatId(UserId, UsuarioSeleccionado));
                privateChat.Show();
            }
        }

       

        private void trance_Tick(object sender, EventArgs e)
        {
            //panelTools.Location = new Point(panelTools.Location.X +140, panelTools.Location.Y);
            SetpanelToolsLocation();
            picMore.Show();
            trance.Stop();
        }

        private void UserList_CellMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Upd_Click(object sender, MouseEventArgs e)
        {

        }

        private void ButtonArrow_Click(object sender, EventArgs e)
        {
            if(txtSend.Width == 305)
            {
                buttonnew = false;
                colorbar();
                this.tmExpandirtxt.Start();
            }
            else if(txtSend.Width == 175)
            {
                buttonnew = true;
                colorbar();
                this.tmContraertxt.Start();
            }
        }

        private void tmExpandirtxt_Tick(object sender, EventArgs e)
        {
            if (txtSend.Width <= 175)
            { 
                ButtonScreen.Visible = true;
                this.tmExpandirtxt.Stop();
            }
            else
            { 
                if (txtSend.Width >= 270)
                {
                    ButtonMessage.Visible = true;
                }
                else if (txtSend.Width >= 221)
                {
                    ButtonBuzz.Visible = true;
                }
                txtSend.Width = txtSend.Width - 10;
            if (txtSend.Location.X >= 170)
                txtSend.Location = new Point(175, txtSend.Location.Y);
            else
            txtSend.Location = new Point(txtSend.Location.X + 10, txtSend.Location.Y);
            }
        }

        private void tmContraertxt_Tick(object sender, EventArgs e)
        {
            if (txtSend.Width >= 305)
            { 
                txtSend.Size = new Size(305, txtSend.Size.Height);
                this.tmContraertxt.Stop();
                ButtonMessage.Visible = false;
                
                
            }
            else
            { 
                if (txtSend.Width <= 221)
                {
                    ButtonScreen.Visible = false;
                }
                else if (txtSend.Width <= 270)
                {
                    ButtonBuzz.Visible = false;
                }
                    txtSend.Location = new Point(txtSend.Location.X - 10, txtSend.Location.Y);
            txtSend.Width = txtSend.Width + 10;
            }
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            int palabra = txtSend.Text.Length;
            if (buttonnew == false)
            {
                if (palabra >= 20)
                {
                    ButtonSmile.Visible = false;
                }
                else if (palabra <= 20)
                {
                    ButtonSmile.Visible = true;
                }
            }
            else
            {
                if (palabra >= 42)
                {
                    ButtonSmile.Visible = false;
                }
                else if (palabra <= 42)
                {
                    ButtonSmile.Visible = true;
                }
            }
        }

        private void Jellyfin_Click(object sender, EventArgs e)
        {
            Process.Start("http://192.168.88.28:8096/web/index.html#!/login.html");
        }




        /*
.
.
.
*/
    }
}




//Ver
//StringHelper.GetClassnameFromHTML(    //Obtiene nombre de la clase (ver para la direccion de una imagen)
//StringHelper.GetSrcInImgTag(
// 
//
// 
//
// 
//
// 
// 
//
// 
//
// 
//
// 