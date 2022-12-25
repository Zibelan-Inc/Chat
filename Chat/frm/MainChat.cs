using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using MaterialSkin;
using MaterialSkin.Controls;
using SkynetChat.Properties;
using Hook;
using SpellChecker_GUI;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.Management;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using TyroDeveloper;
//using BrightIdeasSoftware;
using FileInfo = System.IO.FileInfo;            // []   |||   &&
using SkynetChat.Controles;
using System.Windows.Forms.Layout;
using RemoteFileSystemTester;
using SkynetChat.Class.RemoteFileSistem;
using SkynetChat.Class;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;

namespace SkynetChat
{

    public partial class MainChat : MaterialForm
    {
        ///////////////////////////////////////////////////////
        //Nuevo Metodo
        ///////////////////////////////////////////////////////
        bool isOui = false;
        string lastMessage { get; set; }
        List<string> RecentMessages;
        string appVersion;
        string appName;
        private readonly MaterialSkinManager materialSkinManager;
        private Client cliente;

        public static MainChat Skynetchat;
        public static Form SettingsForm = null;
        public string nickName;
        public bool saveOnExit;
        List<string> userLista;
        public bool Muted;
        private bool alive;
        public RegistryKey Chat;

        public string IP  {get; set;}
        private string Avatarlength { get; set; }
        public System.Media.SoundPlayer beep;  //Sonido

        //Servidor Ficheros
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public Thread thread = null;

        KeyboardHook kh;

        public ListBox UserLista;

        Message mensage;
        SkynetSettings skynetSetting;
        public bool topNivel;
        public bool escribiendo;
        public UserAndSystemInfo uInfo;

        public MainChat()
        {
            InitializeComponent();

            //skynetSetting = new SkynetSettings(this);
            skynetSetting.CargarSettings();

            Patch = Application.StartupPath;

            if (File.Exists(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg"))
            {
                FileInfo avatarLength = new FileInfo(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");
                Avatarlength = avatarLength.Length.ToString();               //Nickname
            }

            UserLista = new ListBox();
            CargarImageAvatar();

            posicionOriginal();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            //ChatNuevo
            ////////////////////////////////////////////////

            Skynetchat = this;

            userLista = new List<string>();
            RecentMessages = new List<string>();


            mensage = new Message();
            
            cliente = new Client();
            cliente.Loading();

            ConnectToChat();

            alive = true;
            Thread ListenStart = new Thread(new ThreadStart(Listen));
            ListenStart.Start();


            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            appName = fileVersionInfo.FileDescription;
            appVersion = fileVersionInfo.ProductVersion;
            appVersion = appVersion.Remove(appVersion.Length - 2);

            txtChat.AppendText("<SkynetChat> Bienvenidos a SkynetChat (" + appVersion + ") !\n");
            txtChat.AppendText("<SkynetChat> Escriba '/help' para ver lista de comandos.\n");
            txtChat.AppendText("\r\n");

            if (string.IsNullOrEmpty(NickName.Text))
                NickName.Text = Environment.UserName;

            // Guardar valores
            saveOnExit = cliente.SaveOnQuitConfig;


            //Mis cosas
            Muted = false;


            ////////////////////////////////////////////////
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos

            SaveSettings.LoadAllSettings("SkynetChat", this);
            LimpiarControles();
            //Test();

            //Keyboard Hook
            kh = new KeyboardHook();
            kh.KeyDown += Kh_KeyDown;
            kh.HookStart();

            FileReceiver fileReceiver = new FileReceiver(this);
            fileReceiver.Iniciar();

            AvatarReceiver avatarReceiver = new AvatarReceiver(this);
            avatarReceiver.Iniciar();

            DesktopServer desktopServer = new DesktopServer(this);
            desktopServer.Load();
            //Espacio entre lineas

            if (PosicionOriginal.Checked)
            {
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            }
            if (CenterScreen.Checked)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            //Avatar Opciones
            if (File.Exists(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg", FileMode.Open, FileAccess.Read);
                Avatar.Image = Image.FromStream(fs);
                fs.Close();
            }
            SpellChecker();
            topNivel = true;
            getAvatar();
            uInfo = new UserAndSystemInfo();
            uInfo.Read();

            //Server FileSystem
            FileSystemServer fileServer = new FileSystemServer();
            //Server Control
            ScreenCaptureServer screenServer = new ScreenCaptureServer();
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //      CHAT
        ///////////////////////////////////////////////////////////////////////////////////
        private void MainForm_Load(object sender, EventArgs e)
        {
            cliente.Handle = NickName.Text;
            _cerrar = false;
            //Agregar directamente mi usuario
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;
            if (ColorINuserList.Checked)
            lvi.ForeColor = getColorFromId(cliente.UserSelectedColor);

            //Agrego los subItems(Nombre y estado)
            ListViewItem.ListViewSubItem userNameSubItem = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(userNameSubItem);
            ListViewItem.ListViewSubItem estadoSubItem = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(estadoSubItem);
            ListViewItem.ListViewSubItem IDSubItem = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(IDSubItem);
            ListViewItem.ListViewSubItem IPSubItem = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(IPSubItem);

            //Asigno Name y Text a los subItems

            if (File.Exists(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg"))
            {
                FileInfo avatarLength = new FileInfo(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");
                lvi.SubItems[0].Name = avatarLength.Length.ToString();               //Nickname
            }
            lvi.SubItems[1].Text = NickName.Text;               //Nickname
            lvi.SubItems[1].Name = Environment.MachineName;     //PCname
            lvi.SubItems[2].Text = "";
            lvi.SubItems[2].Name = "Activo";                    //Status
            lvi.SubItems[3].Text = cliente.ColorId.ToString();  //ColorID
            lvi.SubItems[3].Name = "FormActivo";                //FormStatus
            lvi.SubItems[4].Text = Client.Ip();
            UserList.Items.Add(lvi);


            // Avisar mi llegada
            Transmit( "Ingreso");

         //   mensage.masterList = new List<Person>();

            txtChat.AppendText("<SkynetChat> Bienvenidos a SkynetChat (" + appVersion + ") !\n");
            txtChat.AppendText("<SkynetChat> Escriba '/help' para ver lista de comandos.\n");
            txtChat.AppendText("\r\n");

            txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
            txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
            txtChat.AppendText("Te uniste al chat como ");
            txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
            txtChat.SelectionColor = Color.FromName(Colores.Text);
            txtChat.AppendText(NickName.Text);
            txtChat.AppendText("\r\n");


            if (string.IsNullOrEmpty(NickName.Text))
                NickName.Text = Environment.UserName;

            if (string.IsNullOrEmpty(DirBox.Text))
                DirBox.Text = Application.StartupPath + @"\Inbox\";

            if (File.Exists(Application.StartupPath + @"\SkynetChat.zip"))
                File.Delete(Application.StartupPath + @"\SkynetChat.zip");

            string acceso = Environment.UserName.ToString();
            HackLabelColor.MouseMoveColor = ColorTranslator.FromHtml("#858C93");
            HackLabelColor.OriginalColor = Color.Black;
            if (acceso != "Hackerprod")
            {
                Updatebtn.Hide();
                Monitor.Hide();
                yesNoCheckBox1.Hide();
                addLabel1.Hide();
                CloseBorgChat();
            }
            else if(acceso == "Hackerprod" && Environment.MachineName == "MUSICALPROD") 
            {
                ToolStripMenuItem FileSystem = new System.Windows.Forms.ToolStripMenuItem();
                FileSystem.Image = global::SkynetChat.Properties.Resources.folder_remote1;
                FileSystem.Name = "FileSystem";
                FileSystem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
                FileSystem.Size = new System.Drawing.Size(203, 22);
                FileSystem.Text = "Explorar HDD";
                FileSystem.Click += new System.EventHandler(FileSystem_Click);

                ToolStripMenuItem ScreenCapture = new System.Windows.Forms.ToolStripMenuItem();
                ScreenCapture.Image = global::SkynetChat.Properties.Resources.folder_remote1;
                ScreenCapture.Name = "ScreenCapture";
                ScreenCapture.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
                ScreenCapture.Size = new System.Drawing.Size(203, 22);
                ScreenCapture.Text = "ScreenCapture";
                ScreenCapture.Click += new System.EventHandler(ScreenCapture_Click);

         //       UserMenu.Items.Add(ScreenCapture);
         //       UserMenu.Items.Add(FileSystem);
            }

            MaterialListView();
            //getMessage

            //Timer para recargar usuarios cada x (Min) 
            RecargarUsuarios();
            UserList.BringToFront();
            Userpanel.BringToFront();

            UpdateAvatar();
            UsuariosEscribiendo.DisplayMember = "Item1";
            /*
            ObjectListView oli = new ObjectListView();
            oli.HotItemStyle.Overlay = new BusinessCardOverlay();
            */
            //UserList.HotItemStyle.Overlay = new MainForm.BusinessCardOverlay();

            Muted = false;
            UserMinCount();


            if (cliente.Handle == "")
            {
                cliente.Handle = Environment.UserName;
                NickName.Text = Environment.UserName;
            }
            /*
            MainForm main = new MainForm();
            main.ShowDialog();
            Application.Exit();
            */
            WindowState = FormWindowState.Normal;
        }

    private void timCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                lblClock.Text = DateTime.Now.ToString("h:mm:ss");
                UserCount.Text = UserList.Items.Count.ToString() + " online";
            }
            catch
            {
                
            }
        }








        private void getAvatar()
        {
            try
            {
                RegistryKey Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SkynetChat", true);

                Chat.GetValue("Patch", RegistryValueKind.String);
                string directorio = (string)Chat.GetValue("Patch");
                try
                {
                    if (!Directory.Exists(directorio + "/avatars/"))
                    Directory.CreateDirectory(directorio + "/avatars/");
                } catch { }

                ListBox fotos = new ListBox();

                DirectoryInfo dir = new DirectoryInfo(directorio + "/avatars/");
                foreach (FileInfo file in dir.GetFiles())
                {
                    string PhotoName = file.Name.Replace(".jpg", "");
                    fotos.Items.Add(PhotoName);
                }

                foreach (ListViewItem user in UserList.Items)
                {
                    if (!fotos.Items.Contains(user.SubItems[1].Text))
                    {
                        Transmit(user.SubItems[1].Text + " " + Client.Ip(), "GetAvatar");
                    }
                }
            }
            catch (Exception ex) { Crearlog("getAvatar(): " + ex.Message); }
        }
        private void Exit()
        {
            if (!alive) return;
            Transmit( "Desconecto");
            _cerrar = true;
            Application.Exit();
        }

        private bool _cerrar;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (_cerrar)
            {
                txtChat.Dispose();
                skynetSetting.GuardarSettings();
                CerrarChat();
            }
            else
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                MinToTry();
                skynetSetting.GuardarSettings();
            }
            
        }
        private void CerrarChat()
        {
            alive = true;
            LimpiarControles();
            skynetSetting.GuardarSettings();
            DisconnectFromChat();
            Exit();
        }

        private void LimpiarControles()
        {
            txtSend.Clear();
            txtChat.Text = "";
        }
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(
        uint uCode,     // virtual-key code or scan code
        uint uMapType   // translation to perform
        );


        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ListUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.SuppressKeyPress = true; //Quitar sonido al enter
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;

                //Para detectar una pulsacion en C# tenemos que controlar el evento keyUp del control correspondiente de la siguiente manera:
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.B))
                {
                    foreach (ListViewItem usuario in UserList.Items)
                    {
                        if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                        {
                            if (usuario.SubItems[2].Name == "Ocupado")
                            {
                                MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                                return;
                            }
                            else
                            {
                                string beepear = UsuarioSeleccionado;
                                Transmit(beepear, "beep");

                                WriteChatMessages(9, mensage.Handle, "Has enviado un beep a ", mensage.UserSelectedColor);
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.E))
                {
                    Process.Start(@"\\" + IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.P))
                {
                    //Mensaje privado
                    txtSend.Text = $"//{UsuarioSeleccionado} ";
                    txtSend.Focus();
                    txtSend.SelectionStart = txtSend.TextLength + 1;

                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.A))
                {
                    //Enviar Archivo
                    FileSender fileSender = new FileSender();
                    fileSender.Iniciar(IPSeleccionado);
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.C))
                {
                    foreach (ListViewItem usuario in UserList.Items)
                    {
                        if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                        {
                            if (usuario.SubItems[2].Name == "Ocupado")
                            {
                                MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                                return;
                            }
                            else
                            {
                                //Llamada
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.V))
                {
                    foreach (ListViewItem usuario in UserList.Items)
                    {
                        if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                        {
                            if (usuario.SubItems[2].Name == "Ocupado")
                            {
                                MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                                return;
                            }
                            else
                            { 
                                //Videollamada
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.D))
                {
                    foreach (ListViewItem usuario in UserList.Items)
                    {
                        if (usuario.SubItems[4].Text.Equals(UsuarioSeleccionado))
                        {
                            if (usuario.SubItems[2].Name == "Ocupado")
                            {
                                MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                                return;
                            }
                            else
                            {
                                //Escritodio Remoto
                                try
                                {
                                    ControlarPC controlar = new ControlarPC(IPSeleccionado);
                                    controlar.ShowDialog();
                                } catch (Exception ex) { Crearlog ("ListUser_KeyDown: " + ": " + ex.Message); }
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.E))
                {
                    //
                }

            } catch (Exception ex) { Crearlog ("ListUser_KeyDown2: " + ex.Message); EnfocarTXTmess(e); }
        }
        //////////////////////////////////////////////////////
        private void UactivO_Click(object sender, EventArgs e)
        {
            Transmit( "Activo");
 //           cliente.State = "Activo";
        }

        private void UocupadO_Click(object sender, EventArgs e)
        {
            Transmit( "Ocupado");
 //           cliente.State = "Ocupado";
        }

        private void UausentE_Click(object sender, EventArgs e)
        {
            Transmit( "Ausente");
  //          cliente.State = "Ausente";
        }



        private void mensajePrivadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                txtSend.Text = "//" + UsuarioSeleccionado + " " + txtSend.Text;
                txtSend.Focus();
                txtSend.SelectionStart = txtSend.TextLength + 1;
            }
            catch { }
        }
        private void FileSystem_Click(object sender, EventArgs e)
        {
            try
            {
                string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;
                frmRfs frm = new frmRfs();
                frm.Start(IPSeleccionado);
                frm.Show();
            }
            catch { }
        }

        ScreenCapture SCobj;
        TcpChannel TCPchan;
        string URL;
        static byte[] buffer { get; set; }
        private void ScreenCapture_Click(object sender, EventArgs e)
        {
            //try {

                // ------------------------------------------------------------
                BinaryServerFormatterSinkProvider serverProv =
                    new BinaryServerFormatterSinkProvider();
                IDictionary propBag = new Hashtable();
                // -----------------------------------------
                bool isSecure = false;
                propBag["typeFilterLevel"] = TypeFilterLevel.Full;
                propBag["name"] = RandomPassword().ToString();  // here enter unique channel name
                if (isSecure)  // if you want remoting comm to be secure and encrypted
                {
                    propBag["secure"] = isSecure;
                    propBag["impersonate"] = false;  // change to true to do impersonation
                }
                // -----------------------------------------
                TcpChannel tcpChan = new TcpChannel(
                    propBag, null, serverProv);
                ChannelServices.RegisterChannel(tcpChan, isSecure);
                // --------------------------------------------
                string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;
                string URI = "Tcp://" + IPSeleccionado + ":6700/MyCaptureScreenServer";
                // ---------------------------------------------

                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(ScreenCapture), URI,
                    WellKnownObjectMode.SingleCall);

                SCobj = (ScreenCapture)Activator.GetObject(typeof(ScreenCapture), URI);

                /*
                // ...........................................................
                IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;
                URL = "Tcp://" + IPSeleccionado + ":6700/MyCaptureScreenServer";
                TCPchan = new TcpChannel();
                ChannelServices.RegisterChannel(TCPchan, false);
                SCobj = (ScreenCapture) Activator.GetObject(typeof (ScreenCapture), URL);
                */
                RemoteDesktop Remotedesktop = new RemoteDesktop(true, SCobj, URI, tcpChan);
                Remotedesktop.Show();
            //} catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void beepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                foreach (ListViewItem usuario in UserList.Items)
                {
                    if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                    {
                        if (usuario.SubItems[2].Name == "Ocupado")
                        {
                            MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                            return;
                        }
                        else 
                        {
                            string beepear = UsuarioSeleccionado;
                            Transmit(beepear, "beep");

                            WriteChatMessages(9, mensage.Handle, "Has enviado un beep a ", mensage.UserSelectedColor);
                        }
                    }
                }
            }
            catch { }
        }

        private void explorarPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;

                Process.Start(@"\\" + IPSeleccionado);
            }
            catch { }

        }

        private void enviarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;

            FileSender fileSender = new FileSender();
            fileSender.Iniciar(IPSeleccionado);
            }
            catch { }

        }
        private void videollamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                foreach (ListViewItem usuario in UserList.Items)
                {
                    if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                    {
                        if (usuario.SubItems[2].Name == "Ocupado")
                        {
                            MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                            return;
                        }
                        else
                        {
                            //Videollamada
                        }
                    }
                }
            }
            catch { }

        }

        private void llamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                foreach (ListViewItem usuario in UserList.Items)
                {
                    if (usuario.SubItems[1].Text.Equals(UsuarioSeleccionado))
                    {
                        if (usuario.SubItems[2].Name == "Ocupado")
                        {
                            MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                            return;
                        }
                        else
                        {
                            //Llamada
                        }
                    }
                }
            }
            catch { }

        }
        public void Manda()
        {
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Environment.UserName == "Hackerprod")
            {
                _cerrar = true;
                Exit();
            }
            //materialTabControl1.SelectTab(tabPage1);
            /*
            UserList.MakeColumnHeaders(
            "Avatar", 50, HorizontalAlignment.Left,
            "Name", 70, HorizontalAlignment.Right,
            "Status", 30, HorizontalAlignment.Right);

            UserList.AddRow("", "Yohel.com", "Ausente");
            UserList.AddRow("", "Hackerprod", "Activo");
            UserList.AddRow("", "Alejandro", "Ocupado");

            for (int r = 0; r < UserList.Items.Count; r++)
            {
                // Set the main item's image index.
                UserList.Items[r].ImageIndex = r;

                // Set the sub-item indices.
                for (int c = 1; c < UserList.Columns.Count; c++)
                {
                    UserList.AddIconToSubitem(r, c, 6 + c);
                }
            }

            // Initially display the sub-item icons if
            // the check box is checked.
            UserList.ShowSubItemIcons();
            */
        }
        public string MPrivado { get; set; }
        public string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            MPrivado = builder.ToString();
            return MPrivado;
        }


        private void UserList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void UserList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                OverlayPanel.Hide();
                Point p = UserList.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                //now get the item.
                ListViewItem item = UserList.GetItemAt(p.X, p.Y);


                string ipSeleccionado = item.SubItems[4].Text;


                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    FileSender fileSender = new FileSender();
                    fileSender.IniciarDrop(ipSeleccionado, file);
                }
            }
            catch { }
        }
        //Variables Untuk Main program
        ScreenCapture obje;
        TcpChannel chanel;
        string URLO;
        System.Drawing.Color defaultcolor;

        private void escritorioRemotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;
                foreach (ListViewItem usuario in UserList.Items)
                {
                    if (usuario.SubItems[4].Text.Equals(UsuarioSeleccionado))
                    {
                        if (usuario.SubItems[2].Name == "Ocupado")
                        {
                            MessageBox.Show(this, "El usuario " + UsuarioSeleccionado + " esta ocupado en estos momentos... inténtelo más tarde.");
                            return;
                        }
                        else
                        {
                            //Escritodio Remoto
                            try
                            {
                                //Activar server de control
                                string ipget = "";
                                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                                {
                                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                                    {
                                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                                        {
                                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                            {
                                                if (!ip.Address.ToString().StartsWith("169"))
                                                    ipget = ip.Address.ToString();
                                            }
                                        }
                                    }
                                }
                                int tcpPort = 52131;
                                // ------------------------------------------------------------
                                BinaryServerFormatterSinkProvider serverProv =
                                    new BinaryServerFormatterSinkProvider();
                                serverProv.TypeFilterLevel = TypeFilterLevel.Full;
                                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;

                                serverProv.TypeFilterLevel = TypeFilterLevel.Full;
                                IDictionary propBag = new Hashtable();
                                // -----------------------------------------
                                bool isSecure = false;
                                propBag["port"] = tcpPort;
                                propBag["typeFilterLevel"] = TypeFilterLevel.Full;
                                propBag["name"] = "UniqueChannelName";  // here enter unique channel name
                                if (isSecure)  // if you want remoting comm to be secure and encrypted
                                {
                                    propBag["secure"] = isSecure;
                                    propBag["impersonate"] = false;  // change to true to do impersonation
                                }
                                // -----------------------------------------
                                TcpChannel tcpChan = new TcpChannel(
                                    propBag, null, serverProv);
                                ChannelServices.RegisterChannel(tcpChan, isSecure);
                                // --------------------------------------------
                                if (ipget == "")
                                ipget = "127.0.0.1";

                                URLO = "Tcp://" + ipget + ":52131/MyCaptureScreenServer";
                                // ---------------------------------------------

                                RemotingConfiguration.RegisterWellKnownServiceType(
                                    typeof(ScreenCapture), URLO,
                                    WellKnownObjectMode.SingleCall);
                                //Enviar solicitud de control
                                Transmit( "Control");

                            } catch (Exception ex) { Crearlog ("escritorioRemotoToolStripMenuItem_Click: " + ex.Message); }
                            try
                            {


                            }
                            catch (Exception ex) { Crearlog("lol: " + ex.Message); }


                        }
                    }
                }
            }
            catch { }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string IPSeleccionado = UserList.SelectedItems[0].SubItems[4].Text;
                Transmit(IPSeleccionado, "Update");
            }
            catch
            {
                Transmit( "Update");
            }

        }


        private void CambiarNick_Click(object sender, EventArgs e)
        {
            try
            {
                string NickUser = NickName.Text;

                Transmit(NickUser, "NickChange");

                // NickName.Text = NickUser;
                cliente.Handle = NickUser;

                skynetSetting.GuardarSettings();
                UpdateAvatar();
            }
            catch { }
        }
        public void ReplaceAll(string word, string replacer)
        {
            int index = 0;

            while (index < txtChat.Text.LastIndexOf(word))
            {
                int location = txtChat.Find(word, index, RichTextBoxFinds.None);
                txtChat.Select(location, word.Length);
                txtChat.SelectedText = replacer;
                index++;
            }
            MessageBox.Show(index.ToString());
        }


        private void ListUser_MouseMove(object sender, MouseEventArgs e)
        {

            try {
                //use cursor points.
                Point p = UserList.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                //now get the item.
                ListViewItem item = UserList.GetItemAt(p.X, p.Y);

                OverlayUser.Text = item.SubItems[1].Text;
                string OPC = item.SubItems[1].Name;
                if (OPC.StartsWith("DESKTOP"))      //DESKTOP-8QR3E7L
                {
                    OverlayPC.Text = "DESKTOP";
                    //WriteChatMessages(10,"", item.SubItems[1].Name);
                }
                else
                    OverlayPC.Text = OPC;
                OverlayIP.Text = item.SubItems[4].Text;
                OverlayStatus.Text = item.SubItems[2].Name;
                if (item.SubItems[2].Name == "Activo")
                    OverlayEstado.Image = Resources._57;
                if (item.SubItems[2].Name == "Ocupado")
                    OverlayEstado.Image = Resources._60;
                if (item.SubItems[2].Name == "Ausente")
                    OverlayEstado.Image = Resources._63;
                OverlayPanel.Location = new Point(item.Position.X + 207 , item.Position.Y);

                try
                {
                    if (File.Exists(Application.StartupPath + "/Avatars/" + item.SubItems[1].Text + ".jpg"))
                    {
                        FileStream fs = new FileStream(Application.StartupPath + "/Avatars/" + item.SubItems[1].Text + ".jpg", FileMode.Open, FileAccess.Read);
                        OverlayAvatar.Image = Image.FromStream(fs);
                        fs.Close();
                    }
                }
                catch { }
                OverlayPanel.BringToFront();
                OverlayPanel.Show();
            }
            catch { }

        }
        private void UserList_MouseLeave(object sender, EventArgs e)
        {
            OverlayPanel.Hide();
        }










        /////////////////////////////////////////////////////////////



        private void txtChat_TextChanged(object sender, EventArgs e)
        {
            Emotions();
            txtChat.ScrollToCaret();
            txtChat.ResumeLayout();
        }

        private void Emotions()
        {
            try { 
                foreach (var smilesINfolder in Directory.GetFiles(Application.StartupPath + @"\smiles\"))
                {
                    FileInfo file = new FileInfo(smilesINfolder);
                    string filename = file.Name.Replace(".gif","");
                        string smile = ":"+filename+":";
                            int index = 0;
                        int location = 0;

                            if (txtChat.Text.Contains(smile))
                            {
                                location = txtChat.Find(smile, index, RichTextBoxFinds.None);
                                txtChat.Select(location, smile.Length);
                                txtChat.SelectedText = "";
                                index++;

                                Image theSmile = Image.FromFile(Application.StartupPath + @"\smiles\" + filename + ".gif");
                                PictureBox thePic = new PictureBox();
                                thePic.Image = theSmile;
                                thePic.Size = theSmile.Size;
                                txtChat.AddControl(thePic);
                                thePic.Location = new Point(location, smile.Length);




                            }

                }
            } catch (Exception ex) { Crearlog ("Emotions: " + ex.Message); }
            /*
            while (txtChat.Text.Contains(emote))
            {
                int ind = txtChat.Text.IndexOf(emote);
                txtChat.Select(ind, emote.Length);
                Clipboard.SetImage((Image)emoticons[emote]);
                txtChat.Paste();
            }
            */
        }

        private void PseudoHeaderLine() //separacion de las lineas
        {
            this.txtChat.AppendText(" " + Environment.NewLine);
            this.txtChat.SelectionColor = Color.FromArgb(255, 0, 64, 64);
            this.txtChat.SelectionFont = new Font("Arial", 9.0F);
            this.txtChat.AppendText("UserName(1001) " + DateTime.Now.ToLongTimeString() + "       ");
        }

        private void sMilEs_Click(object sender, EventArgs e)
        {
            try
            {
                Emoticons emo = new Emoticons();
                emo.location(Location.X, Location.Y);
                emo.ShowDialog();

                Transmit(emo.SmiliE, "Smile");
            }
            catch { }

        }
    
    public void EnviarSmile(string smile)
    {
            MessageBox.Show(smile);
        /*
        SendMessage("_:IoI:_ Smile " + NickName.Text + " " + smile;
        byte[] data = Encoding.Unicode.GetBytes(message);
        client.Send(data, data.Length, remoteEp);
        */
    }

        private void ChangeBox_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog serverloc_patch = new FolderBrowserDialog();
                serverloc_patch.ShowDialog();
                DirBox.Text = serverloc_patch.SelectedPath;
            }
            catch { }
        }

        private void PosicionOriginal_CheckedChanged(object sender, EventArgs e)
        {
            posicionOriginal();
        }
        private void posicionOriginal()
        {
            if (PosicionOriginal.Checked)
            {
                CenterScreen.Enabled = false;
                GuardarPosicion.Enabled = false;
            }
            else
            {
                CenterScreen.Enabled = true;
                GuardarPosicion.Enabled = true;
            }
        }




        private void MainChat_Activated(object sender, EventArgs e)
        {
            try
            {
                Transmit("FormActivo");
            }
            catch (Exception ex) { Crearlog ("MainChat_Activated: " + ex.Message); }
            topNivel = true;
        }

        private void MainChat_Deactivate(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem usuario in UserList.Items)
                {
                    if (usuario.SubItems[1].Text.Equals(NickName.Text))
                    {
                        if (usuario.BackColor != Color.FromArgb(235, 235, 235))
                            Transmit("FormInactivo");
                    }
                        topNivel = false;
                }
            } catch (Exception ex) { Crearlog ("MainChat_Deactivate: " + ex.Message); }
            if (this.WindowState == FormWindowState.Minimized)
            {
                MinToTry();
            }
        }

        private void MinToTry()
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = true;
                    Visible = false;
                    notifyIcon1.Text = "SkynetChat";
                    notifyIcon1.Visible = true;
                    WindowState = FormWindowState.Minimized;
                    notifyIcon1.ContextMenu = new ContextMenu();
                    notifyIcon1.ContextMenu.MenuItems.Add("Abrir", (s, e) => AbrirDesdeTry());
                    notifyIcon1.ContextMenu.MenuItems.Add("Cerrar", (s, e) => Exit());
                }
            }
            catch { }
        }



        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Show();
                WindowState = FormWindowState.Normal;
                //Ocultamos el icono de la bandeja de sistema
                notifyIcon1.Visible = false;
            }
            catch { }
        }

        private void AbrirDesdeTry()
        {
            try
            {
                Show();
                WindowState = FormWindowState.Normal;
                //Ocultamos el icono de la bandeja de sistema
                    notifyIcon1.Visible = false;
                    ShowInTaskbar = true;
            }
            catch { }
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog
                {
                    Filter = "Imagen para Avatar |*.jpg",
                    Multiselect = false,
                };
                var userOK = openDialog.ShowDialog();

                if (userOK != DialogResult.OK)
                {
                    return;
                }
                if (!Directory.Exists(Application.StartupPath + "/Avatars/"))
                    Directory.CreateDirectory(Application.StartupPath + "/Avatars/");

                foreach (var img in ImageAvatar.Images.Keys)
                {
                    if (img == NickName.Text + ".jpg")
                    {
                        ImageAvatar.Images.RemoveByKey(img);
                    }
                }

                try {
                //Borrar Avatar viejo
                if (File.Exists(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg"))
                    File.Delete(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");

                //Copiar Avatar nuevo
                File.Copy(openDialog.FileName, Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");
                } catch (Exception ex) { Crearlog ("//Copiar Avatar nuevo: " + ex.Message); }

                try
                {
                    if (File.Exists(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg"))
                    {
                        FileStream fs = new FileStream(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg", FileMode.Open, FileAccess.Read);
                        Avatar.Image = Image.FromStream(fs);
                        fs.Close();
                        FileInfo avatarLength = new FileInfo(Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");
                        Avatarlength = avatarLength.Length.ToString();               //Nickname

                    }
                } catch (Exception ex) { Crearlog("Avatar_Click: " + ex.Message); }

                CargarImageAvatar();
                UpdateAvatar();

                foreach (ListViewItem user in UserList.Items)
                {
                    AvatarSender fileSender = new AvatarSender();
                    if(user.SubItems[4].Text != Client.Ip())
                    fileSender.Avatar(user.SubItems[4].Text, Application.StartupPath + "/Avatars/" + NickName.Text + ".jpg");
                }
            }
            catch { }
        }
        //ListView/////////////////////////////
        [Browsable(false)]
        public MaterialSkinManager SkinManage => MaterialSkinManager.Instance;
        [Browsable(false)]
        public MouseState MouseStat { get; set; }
        [Browsable(true)]
        public Point MouseLocation { get; set; }
        [Browsable(false)]
        private ListViewItem HoveredItem { get; set; }

        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        private void ListUser_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            try
            {
                e.Graphics.FillRectangle(new SolidBrush(SkinManage.GetApplicationBackgroundColor()), new Rectangle(e.Bounds.X, e.Bounds.Y, Width, e.Bounds.Height));
                e.Graphics.DrawString(e.Header.Text,
                    SkinManage.ROBOTO_MEDIUM_10,
                    SkinManage.GetSecondaryTextBrush(),
                    new Rectangle(e.Bounds.X + ITEM_PADDING, e.Bounds.Y + ITEM_PADDING, e.Bounds.Width - ITEM_PADDING * 2, e.Bounds.Height - ITEM_PADDING * 2),
                    getStringFormat());
            }
            catch { }
        }
        private const int ITEM_PADDING = 12;
        private StringFormat getStringFormat()
        {
            return new StringFormat
            {
                FormatFlags = StringFormatFlags.LineLimit,
                Trimming = StringTrimming.EllipsisCharacter,
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
        }

        public void MaterialListView()
        {
            try
            {
                UserList.GridLines = false;
                UserList.FullRowSelect = true;
                UserList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                //ListUser.View = View.Details;
                //OwnerDraw = true;
                ResizeRedraw = true;
                UserList.BorderStyle = BorderStyle.None;
                SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);

                //Fix for hovers, by default it doesn't redraw
                //TODO: should only redraw when the hovered line changed, this to reduce unnecessary redraws
                MouseStat = MouseState.OUT;
                UserList.MouseEnter += delegate
                {
                    MouseStat = MouseState.HOVER;
                };
                UserList.MouseLeave += delegate
                {
                    MouseStat = MouseState.OUT;
                    Invalidate();
                };
                UserList.MouseDown += delegate { MouseStat = MouseState.DOWN; };
                UserList.MouseUp += delegate { MouseStat = MouseState.HOVER; };
            }
            catch { }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LogFont
        {
            public int lfHeight = 0;
            public int lfWidth = 0;
            public int lfEscapement = 0;
            public int lfOrientation = 0;
            public int lfWeight = 0;
            public byte lfItalic = 0;
            public byte lfUnderline = 0;
            public byte lfStrikeOut = 0;
            public byte lfCharSet = 0;
            public byte lfOutPrecision = 0;
            public byte lfClipPrecision = 0;
            public byte lfQuality = 0;
            public byte lfPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName = string.Empty;
        }

        private void ListUser_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            try
            {
                //We draw the current line of items (= item with subitems) on a temp bitmap, then draw the bitmap at once. This is to reduce flickering.
                var b = new Bitmap(e.Item.Bounds.Width, e.Item.Bounds.Height);
                var g = Graphics.FromImage(b);

                //always draw default background
                g.FillRectangle(new SolidBrush(SkinManage.GetApplicationBackgroundColor()), new Rectangle(new Point(e.Bounds.X, 0), e.Bounds.Size));

                if (e.State.HasFlag(ListViewItemStates.Selected))
                {
                    //selected background
                    g.FillRectangle(SkinManage.GetFlatButtonPressedBackgroundBrush(), new Rectangle(new Point(e.Bounds.X, 0), e.Bounds.Size));
                }
                else if (e.Bounds.Contains(MouseLocation) && MouseState == MouseState.HOVER)
                {
                    //hover background
                    g.FillRectangle(SkinManage.GetFlatButtonHoverBackgroundBrush(), new Rectangle(new Point(e.Bounds.X, 0), e.Bounds.Size));
                }


                //Draw separator
                g.DrawLine(new Pen(SkinManage.GetDividersColor()), e.Bounds.Left, 0, e.Bounds.Right, 0);

                foreach (ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
                {
                    //Draw text
                    g.DrawString(subItem.Text, SkinManage.ROBOTO_MEDIUM_10, SkinManage.GetPrimaryTextBrush(),
                                     new Rectangle(subItem.Bounds.X + ITEM_PADDING, ITEM_PADDING, subItem.Bounds.Width - 2 * ITEM_PADDING, subItem.Bounds.Height - 2 * ITEM_PADDING),
                                     getStringFormat());
                }

                e.Graphics.DrawImage((Image)b.Clone(), new Point(0, e.Item.Bounds.Location.Y));
                g.Dispose();
                b.Dispose();
            }
            catch { }
        }


        public static Thread SinEscribir;
        int i = 0;
        private void txtSend_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
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
                    } catch (Exception ex) { Crearlog ("txtSend_KeyUp: " + ex.Message); }
                }

                if (!UsuariosEscribiendo.Items.Contains(NickName.Text))
                if (!string.IsNullOrEmpty(txtSend.Text))
                {
                        Transmit( "Escribiendo");
                }

                //MessageBox.Show(timer1.GetLifetimeService.ToString());
            }
            catch { }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Message mess = new Message();
                Tuple<string, DateTime>[] elementos = UsuariosEscribiendo.Items.Cast<Tuple<string, DateTime>>().Where(t => (DateTime.Now.Ticks - t.Item2.Ticks) > 50000000).ToArray();
                foreach (var item in elementos)
                {
                    UsuariosEscribiendo.Items.Remove(item);
                    mess.Escribiendo(null, item, false);
                    UserLista.Items.Remove(item.Item1);
                }
                UserCount.Text = UserList.Items.Count.ToString() + " online";
            } catch { }
        }

        private void ReloadList_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem user in UserList.Items)
                {
                    if (user.SubItems[4].Text != Client.Ip())
                        user.Remove();
                }
                Transmit( "RecargarLista");
            }
            catch { }
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
             try
             {
                 if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C) || Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control))
                 {
                    
                 }
                 else
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    EnfocarTXTmess(e);
                }

            }
            catch { }
        }
        private void EnfocarTXTmess(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Q: txtSend.Focus(); break;
                case Keys.W: txtSend.Focus(); break;
                case Keys.E: txtSend.Focus(); break;
                case Keys.R: txtSend.Focus(); break;
                case Keys.T: txtSend.Focus(); break;
                case Keys.Y: txtSend.Focus(); break;
                case Keys.U: txtSend.Focus(); break;
                case Keys.I: txtSend.Focus(); break;
                case Keys.O: txtSend.Focus(); break;
                case Keys.P: txtSend.Focus(); break;
                case Keys.A: txtSend.Focus(); break;
                case Keys.S: txtSend.Focus(); break;
                case Keys.D: txtSend.Focus(); break;
                case Keys.F: txtSend.Focus(); break;
                case Keys.G: txtSend.Focus(); break;
                case Keys.H: txtSend.Focus(); break;
                case Keys.J: txtSend.Focus(); break;
                case Keys.K: txtSend.Focus(); break;
                case Keys.L: txtSend.Focus(); break;
                case Keys.Z: txtSend.Focus(); break;
                case Keys.X: txtSend.Focus(); break;
                case Keys.C: txtSend.Focus(); break;
                case Keys.V: txtSend.Focus(); break;
                case Keys.B: txtSend.Focus(); break;
                case Keys.N: txtSend.Focus(); break;
                case Keys.M: txtSend.Focus(); break;
                case Keys.NumPad0: txtSend.Focus(); break;
                case Keys.NumPad1: txtSend.Focus(); break;
                case Keys.NumPad2: txtSend.Focus(); break;
                case Keys.NumPad3: txtSend.Focus(); break;
                case Keys.NumPad4: txtSend.Focus(); break;
                case Keys.NumPad5: txtSend.Focus(); break;
                case Keys.NumPad6: txtSend.Focus(); break;
                case Keys.NumPad7: txtSend.Focus(); break;
                case Keys.NumPad8: txtSend.Focus(); break;
                case Keys.NumPad9: txtSend.Focus(); break;
            }
        }

        //public KeyEventArgs(txtSend) keypress;
        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblLeftChars.Text = (140 - txtSend.Text.Length).ToString();
                if (txtSend.Text.Length > 49)
                {
                    sMilEs.BackColor = Color.Transparent;
                    sMilEs.Image = SetAlpha(Resources._01, 65);
                }
                if (txtSend.Text.Length < 48)
                    sMilEs.Image = Resources._01;
            }
            catch { }
        }
        public System.Windows.Forms.Timer ReloadUser = new System.Windows.Forms.Timer();
        public void RecargarUsuarios()
        {
            try
            {
            ReloadUser.Tick += new EventHandler(this.RecargarUser_Tick);
            ReloadUser.Enabled = true;
            int Intervalo = Convert.ToInt32(UserMin.Value) * 60000;
            ReloadUser.Interval = Intervalo;
            ReloadUser.Start();
            UpdateAvatar();
            }
            catch { }
        }
        private void RecargarUser_Tick(object sender, EventArgs e)
        {
            try
            {
                Transmit( "MyUser");
                getAvatar();
                EliminarItemDuplicado();
            }
            catch { }
        }

        private void UserMin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int Intervalo = Convert.ToInt32(UserMin.Value) * 60000;
                ReloadUser.Interval = Intervalo;
                UserMinCount();

            }
            catch (Exception)
            {
                UserMin.Value = 1;
            }
        }
        private void UserMinCount()
        {
            try
            {
                if (UserMin.Value == 1)
                    MINcount.Text = UserMin.Value.ToString() + " minuto";
                else
                    MINcount.Text = UserMin.Value.ToString() + " minutos";
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            txtChat.Controls.Clear();
        }

        private void GuardarLogMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savelog = new SaveFileDialog();
                savelog.Filter = ("Log File | *.log");
                if (savelog.ShowDialog() == DialogResult.OK)
                {
                    var fileAddress = savelog.FileName;
                    File.WriteAllLines(fileAddress, txtChat.Lines);
                }
            }
            catch { }
        }

        private void SelectTodoMenuItem3_Click(object sender, EventArgs e)
        {
            txtChat.Focus();
            txtChat.SelectAll();
        }

        private void UserOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WriteChatMessages(10, "", "____________________________________");
                string time = DateTime.Now.ToShortTimeString();
                foreach (ListViewItem user in UserList.Items)
                {
                    WriteChatMessages(10, "", "[" + time + "]" + " " + user.SubItems[1].Text + " esta online", Convert.ToInt32(user.SubItems[3].Text));
                }
                WriteChatMessages(10, "", "____________________________________");
            }
            catch { }
        }

        private void UserList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                if (e.Button == MouseButtons.Right)
                {
                    if (UserList.FocusedItem.Bounds.Contains(e.Location))
                    {
    //                    UserMenu.Show(Cursor.Position);
                    }
                }
            }
            catch { }
        }

        private bool Kh_KeyDown(Keys arg)
        {
            try
            {
                if (arg.ToString() == "F10")
                {
                    if (WindowState == FormWindowState.Minimized)
                    {
                        AbrirDesdeTry();
                        topNivel = true;
                    }
                    else if (WindowState == FormWindowState.Normal && topNivel == false)
                    {
                        Activate();
                        WindowState = FormWindowState.Normal;
                        txtSend.Focus();
                        topNivel = true; 
                    }
                    else if (WindowState == FormWindowState.Normal && topNivel == true)
                    {
                        WindowState = FormWindowState.Minimized;
                        topNivel = false; 
                    }
                }
            }
            catch { }
            return true;
        }















        /////////////////////////////////////////////////////
        //Nuevo metodo de usersOnline
        public void WriteTextBoxOnlineUser(string name)
        {
            try
            {
                //
            }
            catch (Exception ex) { Crearlog ("WriteTextBoxOnlineUser: " + ex.Message); }
        }
        static Bitmap SetAlpha(Image bmpIn, int alpha)
        { //Image transparente
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, a, 0},
            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }



    private void label1_Click(object sender, EventArgs e)
    {
        Notificar("lol");


        //lol.ConnectToServer("Ip a conectar", true, "SenderName", "ToName", "Channel", false, false, true, new IntPtr(), false, 0, false);
        /*
                ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

                foreach (ManagementObject obj in myVideoObject.Get())
                {
                    WriteChatMessages(10, "", "Name  -  " + obj["Name"]);
                    WriteChatMessages(10, "", "Status  -  " + obj["Status"]);
                    WriteChatMessages(10, "", "Caption  -  " + obj["Caption"]);
                    WriteChatMessages(10, "", "DeviceID  -  " + obj["DeviceID"]);
                    WriteChatMessages(10, "", "AdapterRAM  -  " + obj["AdapterRAM"]);
                    WriteChatMessages(10, "", "AdapterDACType  -  " + obj["AdapterDACType"]);
                    WriteChatMessages(10, "", "Monochrome  -  " + obj["Monochrome"]);
                    WriteChatMessages(10, "", "InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"]);
                    WriteChatMessages(10, "", "DriverVersion  -  " + obj["DriverVersion"]);
                    WriteChatMessages(10, "", "VideoProcessor  -  " + obj["VideoProcessor"]);
                    WriteChatMessages(10, "", "VideoArchitecture  -  " + obj["VideoArchitecture"]);
                    WriteChatMessages(10, "", "VideoMemoryType  -  " + obj["VideoMemoryType"]);
                    WriteChatMessages(10, "", "BandWidth  -  " + obj.ToString());
            }
                    */





        /*
                //Agregar todos los colores
                ArrayList ColorList = new ArrayList();
                Type colorType = typeof(System.Drawing.Color);
                PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                              BindingFlags.DeclaredOnly | BindingFlags.Public);
                foreach (PropertyInfo c in propInfoList)
                {
                    this.Colores.Items.Add(c.Name);
                }

                foreach (ListViewItem user in UserList.Items)
                {
                    //WriteChatMessages(5, user.SubItems[1].Text, user.SubItems[0].Name,0);
                }
                */
        /*

                foreach (var img in ImageAvatar.Images.Keys)
                {
                    WriteChatMessages(4, "ImageAvatar.Images.Keys", img, 0);
                }
                */
        //client.DesconectaryReconectar();



        //   MainForm ff = new MainForm();
        //   ff.ShowDialog();
        /*
                dataListView1.SetObjects(haha.GET());
                haha newObject = new haha("memo", "zezo");
                dataListView1.ShowGroups = false;
                dataListView1.AddObject(newObject);
       ////////////////////////////////////////////////////
                    ImageAvatar.Images.Clear();
                    getAvatar();
                    CargarImageAvatar();
                    UpdateAvatar();
                */
    }
        public void EliminarItemDuplicado()
        {
            try
            {
                List<string> usuario = new List<string>();

                foreach (ListViewItem item in UserList.Items)
                {
                    if (usuario.Contains(item.SubItems[1].Text))
                        item.Remove();
                    else
                        usuario.Add(item.SubItems[1].Text);
                }
                usuario.Clear();
            }
            catch { }
        }
        public string Patch { get; set; }
        public void CargarImageAvatar()
        {
            try
            {
                RegistryKey Chat = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SkynetChat", true);

                Chat.GetValue("Patch", RegistryValueKind.String);
                string directorio = (string)Chat.GetValue("Patch");
                if (directorio == null)
                    directorio = Application.StartupPath;

                if (!Directory.Exists(directorio + "/avatars/"))
                    Directory.CreateDirectory(directorio + "/avatars/");

                foreach (var avatars in Directory.GetFiles(directorio + "/avatars/", "*.jpg"))
                {
                    try
                    {
                        FileInfo file = new FileInfo(avatars);
                        Image img = Image.FromFile(file.FullName);
                        img.Tag = file.Name;
                        if (!ImageAvatar.Images.ContainsKey(file.Name))
                            ImageAvatar.Images.Add(file.Name, img);

                    } catch (Exception ex) { Crearlog ("CargarImageAvatar: " + ex.Message); }
                }
            } catch (Exception ex) { Crearlog ("CargarImageAvatar: " + ex.Message); }
        }
        public void UpdateAvatar()
        {
            try
            {
                foreach (ListViewItem user in UserList.Items)
                {
                    int imagesCount = ImageAvatar.Images.Count;
                    int i = 0;

                    while (i < imagesCount)
                    {
                        if (ImageAvatar.Images.Keys[i] == user.SubItems[1].Text + ".jpg")
                        {
                            foreach (ListViewItem usuario in UserList.Items.Cast<ListViewItem>().Where(usuario => usuario.SubItems[1].Text.Equals(user.SubItems[1].Text)))
                            {
                                usuario.ImageIndex = i;
                            }
                        }
                        i++;
                    } 
                }
            } catch (Exception ex) { Crearlog ("UpdateAvatar: " + ex.Message); }
        }
        public void Notificar(string message, string usuario = null)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "PopupStatus").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.Close();
            }
            try
            {
                (new System.Threading.Thread(() => {
                PopupStatus mensages = new PopupStatus(message, usuario);
                mensages.Visible = false;
                mensages.ShowDialog();
                })).Start();
            } catch { }
    }


        //Revizar ortografía

        private void SpellChecker()
        {

        }
        string set{ get; set;}
        private void Settings_Click(object sender, EventArgs e)
        {
            try
            {
                if (set == null)
                {
                    materialTabControl1.SelectTab(tabPage2);
                    set = "Settings";
                    Settings.Image = Resources.Chat;
                }
                else if (set == "Settings")
                {
                    materialTabControl1.SelectTab(tabPage1);
                    set = "Chat";
                    Settings.Image = Resources.tab_bar_button_toolbox_pressed;
                    txtSend.Focus();
                }
                else if (set == "Chat")
                {
                    materialTabControl1.SelectTab(tabPage2);
                    set = "Settings";
                    Settings.Image = Resources.Chat;
                }
            }
            catch { }
        }
        ///////////////////////////////////////////////////////
        //Nuevo Metodo
        ///////////////////////////////////////////////////////

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;
        public static void ScrollToBottom(RichTextBox MyRichTextBox)
        {
            SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        public void WriteChatMessages(int actionType, string actionUser, string actionContent = null, int actionColor = 0)
        {
            try
            {
                txtChat.SelectionStart = txtChat.TextLength;
                txtChat.SelectionLength = 0;

                switch (actionType)
                {
                    case 1: // Rename
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionColor = Color.FromName("blue");
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionUser);
                        txtChat.SelectionColor = Color.FromName("blue");
                        txtChat.AppendText("  ha cambiado su nick... ahora es  ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionContent);
                        txtChat.AppendText("\r\n");
                        break;
                    case 2: // Join
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionUser);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("green");
                        txtChat.AppendText(" ingresó al chat");
                        txtChat.AppendText("\r\n");
                        break;
                    case 3: // Quit
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionUser);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("red");
                        txtChat.AppendText(" se ha desconectado.");
                        txtChat.AppendText("\r\n");
                        break;
                    case 4: // Mensage sin nada
                            txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                            txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                            txtChat.SelectionColor = getColorFromId(actionColor);
                            txtChat.AppendText(actionContent);
                            txtChat.SelectionColor = txtChat.ForeColor;
                            txtChat.AppendText("\r\n");
                            break;
                    case 5: // Message
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionUser);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.AppendText("> ");
                        if (actionContent.StartsWith(">")) txtChat.SelectionColor = Color.FromName("green");
                        else txtChat.SelectionColor = txtChat.ForeColor;
                        txtChat.AppendText(actionContent);
                        txtChat.AppendText("\r\n");

                        beep = new System.Media.SoundPlayer(Resources.beep);
                        if (!Muted)
                            beep.Play();
                        break;
                    case 6: // MP
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.AppendText("> ");
                        if (actionContent.StartsWith(">")) txtChat.SelectionColor = Color.FromName("green");
                        else txtChat.SelectionColor = txtChat.ForeColor;
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionContent + "\n");
                        txtChat.SelectionColor = txtChat.ForeColor;

                        beep = new System.Media.SoundPlayer(Resources.beep);
                        if (!Muted)
                            beep.Play();

                        break;
                    case 7: // Smile
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionUser);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.AppendText("> ");
                        break;
                    case 8: // Beep
                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionContent);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = txtChat.ForeColor;
                        txtChat.AppendText(" te ha enviado un beep." + "\r\n");
                        break;
                    case 9: // Has enviado un beep a
                        string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                        string ColorSeleccionado = UserList.SelectedItems[0].SubItems[3].Text;

                        txtChat.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                        txtChat.AppendText(actionContent);
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = txtChat.ForeColor;
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = getColorFromId(Convert.ToInt32(ColorSeleccionado));
                        txtChat.AppendText(UsuarioSeleccionado + "\r\n");
                        break;
                    case 10: // Mensaje sin Hora
                        txtChat.SelectionColor = getColorFromId(actionColor);
                        txtChat.AppendText(actionContent);
                        txtChat.AppendText("\r\n");
                        break;
                }
                    txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                    txtChat.SelectionColor = txtChat.ForeColor;
            } catch { }
        }



    public Color getColorFromId(int value)
        {
            switch (value)
            {
                case 0:
                    return Color.Black;
                case 1:
                    return Color.Green;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.Purple;
                case 4:
                    return Color.DarkOrange;
                case 5:
                    return Color.HotPink;
                case 6:
                    return Color.Navy;
                case 7:
                    return Color.DodgerBlue;
                default:
                    return Color.Black;
            }
        }

        public int getIdFromColor(Color value)
        {
            try
            {
                string colorName = value.Name;
                switch (colorName)
                {
                    case "Black":
                        return 0;
                    case "Green":
                        return 1;
                    case "Red":
                        return 2;
                    case "Purple":
                        return 3;
                    case "DarkOrange":
                        return 4;
                    case "HotPink":
                        return 5;
                    case "Navy":
                        return 6;
                    case "DodgerBlue":
                        return 7;
                    default:
                        return 0;
                }
            } catch { return 0; }
        }


        delegate void VoidDelegate(Control control);
        public void InsertarSmile(Control thePic)
        {
            try
            {
                if (this.txtChat.InvokeRequired)
                {
                    VoidDelegate d = new VoidDelegate(InsertarSmile);
                    Invoke(d, new object[] { thePic });
                }
                else
                {
                    txtChat.AddSmile(thePic);
                }
            }
            catch { }
        }


        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    if (txtSend.Text == " " || txtSend.Text.Contains(" ") || string.IsNullOrEmpty(txtSend.Text) || txtSend.Text.Length <= 0 || txtSend.Text.Length > 140 || txtSend.Text.Trim().Length == 0)
                    {
                        // nothing
                    }
                    else if (txtSend.Text.Substring(0, 1) == "/")
                    {
                        if (txtSend.Text.Contains("/help"))
                        {
                            if (txtSend.Text.Substring(0, 5) == "/help")
                            {
                                txtChat.AppendText("<SkynetChat> Ayuda del Chat.\n");
                                txtChat.AppendText("\t/bite  -> Guardar los registros y salir del chat.\n");
                                txtChat.AppendText("\t/clear -> Limpiar el Chat.\n");
                                txtChat.AppendText("\t/help  -> Ayuda del Chat.\n");
                                txtChat.AppendText("\t/nick  -> Cambiar el Nick\n");
                                txtChat.AppendText("\t/quit  -> Salir sin guardar.\n");
                                txtChat.AppendText("\t/oui   -> C'est très le oui, oui.\n");
                                txtChat.AppendText("\t/sc    -> Guardar los registros y vaciar el chat.");
                                txtChat.AppendText("\r\n");
                            }
                        }
                        else if (txtSend.Text.Contains("/nick"))
                        {
                            if (txtSend.Text.Substring(0, 5) == "/nick")
                            {
                                string newPseudo = txtSend.Text.Remove(0, 6);
                                txtChat.SelectionStart = txtChat.TextLength;
                                txtChat.SelectionLength = 0;
                                txtChat.SelectionColor = Color.Red;
                                if (newPseudo.Contains(" "))
                                {
                                    txtChat.AppendText("<SkynetChat> Sin espacios en el Nick ...\n");
                                }
                                else if (newPseudo.Length > 10)
                                {
                                    txtChat.AppendText("<SkynetChat> 23/5000 Apodo demasiado largo!(cmb)\n");
                                }
                                else if (newPseudo.Length < 2)
                                {
                                    txtChat.AppendText("<SkynetChat> Apodo demasiado corto! (ctb)\n");
                                }
                                else
                                {
                                    // Noraj de mon renommage
                                    Transmit(newPseudo, "r");
                                    cliente.Handle = newPseudo;
                                    NickName.Text = cliente.Handle;
                                    Skynetchat.Text = appName + " (" + NickName.Text + "@" + appVersion + ")";

                                    //saveConfig();
                                }
                                txtChat.SelectionColor = txtChat.ForeColor;
                            }
                        }
                        else if (txtSend.Text.Contains("/me"))
                        {
                            if (txtSend.Text.Substring(0, 3) == "/me")
                            {
                                string doingSomething = txtSend.Text.Remove(0, 4);
                                Console.WriteLine("send >>" + doingSomething);
                                // Noraj de mon actionnage
                                Transmit(doingSomething, "a");
                            }
                        }
                        else if (txtSend.Text.StartsWith("//"))
                        {
                            Transmit(txtSend.Text, "MP");
                            string[] data = txtSend.Text.Split(' ');
                            string user = data[0];
                            string usuario = user.Replace("//", "");
                            WriteChatMessages(4, "", "El Mensage privado ha sido recibido por " + usuario, 1);
                        }
                        else if (txtSend.Text.Contains("/quit"))
                        {
                            if (txtSend.Text.Substring(0, 5) == "/quit")
                            {
                                // Noraj de mon quittage
                                Application.Exit();
                            }
                        }
                        else if (txtSend.Text.Contains("/clear"))
                        {
                            if (txtSend.Text.Substring(0, 6) == "/clear")
                            {
                                // Noraj de mon vidage
                                txtChat.Text = null;
                            }
                        }
                        else if (txtSend.Text.Contains("/sc"))
                        {
                            if (txtSend.Text.Substring(0, 3) == "/sc")
                            {
                                // Noraj de mon sauvegardage
                                FileStream fs = new FileStream(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_chatling.log", FileMode.Append);
                                StreamWriter sw = new StreamWriter(fs, ASCIIEncoding.UTF8);
                                sw.Write(txtChat.Text + "\r\n");
                                sw.Close();
                                fs.Close();
                                txtChat.Text = null;
                            }
                        }
                        else if (txtSend.Text.Contains("/bite"))
                        {
                            if (txtSend.Text.Substring(0, 5) == "/bite")
                            {
                                // Noraj de mon enfuitage
                                FileStream fs = new FileStream(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_chatling.log", FileMode.Append);
                                StreamWriter sw = new StreamWriter(fs, ASCIIEncoding.UTF8);
                                sw.Write(txtChat.Text + "\r\n");
                                sw.Close();
                                fs.Close();
                                txtChat.Text = null;
                                Application.Exit();
                            }
                        }
                        else if (txtSend.Text.Contains("/oui"))
                        {
                            if (txtSend.Text.Substring(0, 4) == "/oui")
                            {
                                // Oui
                                isOui = !isOui;
                            }
                        }
                        else
                        {
                            if (isOui)
                                Transmit(txtSend.Text + ", si", "m");
                            else
                                Transmit(txtSend.Text, "m");
                        }
                    }
                    else
                    {
                        if (isOui)
                            Transmit(txtSend.Text + ", si", "m");
                        else
                            Transmit(txtSend.Text, "m");
                    }
                    RecentMessages.Add(txtSend.Text);
                    txtSend.Text = string.Empty;
                    e.Handled = true;
                } 
            }
            catch { }
        }

        private void generar_Click(object sender, EventArgs e)
        {
            try
            {
                txtYourPassword.Text = RandomPassword();
                controlPass.Text = RandomPassword();
            }
            catch { }
        }
        public string RandomPassword()
        {
            Random r = new Random();
            return r.Next(1010, 9999).ToString();
        }

        private void txtSend_Click(object sender, EventArgs e)
        {

        }


        private void Monitor_Click(object sender, EventArgs e)
        {
            try
            {
                Monitorear monitorear = new Monitorear();
                monitorear.Show();
            }
            catch { }
        }

        private void Colores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TestLabelColor.ForeColor = Color.FromName(Colores.Text);
                if (cliente != null)
                    cliente.UserSelectedColor = getIdFromColor(Color.FromName(Colores.Text));
                foreach (ListViewItem user in UserList.Items)
                {
                    if (user.SubItems[1].Text == NickName.Text)
                    {
                        user.SubItems[3].Text = getIdFromColor(Color.FromName(Colores.Text)).ToString();
                        if (ColorINuserList.Checked)
                        user.ForeColor = Color.FromName(Colores.Text);
                    }
                }
            } catch (Exception ex) { Crearlog ("Colores_SelectedIndexChanged: " + ex.Message); }
        }

        private void Mute_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Muted)
                {
                    case false:
                        Mute.Image = Resources.settings_app_ring_off;
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("green");
                        txtChat.AppendText("La aplicación tiene ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = Color.FromName("red");
                        txtChat.AppendText("desactivado");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("green");
                        txtChat.AppendText(" el sonido ");
                        txtChat.AppendText("\r\n");
                        Muted = true;
                        Transmit("SonidoActiado", "Mute");
                        break;
                    case true:
                        Mute.Image = Resources.settings_app_ring_on;
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("green");
                        txtChat.AppendText("La aplicación tiene ");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Bold);
                        txtChat.SelectionColor = Color.FromName("red");
                        txtChat.AppendText("activado");
                        txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
                        txtChat.SelectionColor = Color.FromName("green");
                        txtChat.AppendText(" el sonido ");
                        txtChat.AppendText("\r\n");
                        Muted = false;
                        Transmit("SonidoDesactiado", "Mute");
                        break;
                }
            }
            catch { }
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (set == null)
                {
                    Settings.Image = Resources.tab_bar_button_toolbox_normal;
                }
                else if (set == "Settings")
                {

                }
                else if (set == "Chat")
                {
                    Settings.Image = Resources.tab_bar_button_toolbox_normal;
                }
            }
            catch { }
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (set == null)
                {
                    Settings.Image = Resources.tab_bar_button_toolbox_pressed;
                }
                else if (set == "Settings")
                {

                }
                else if (set == "Chat")
                {
                    Settings.Image = Resources.tab_bar_button_toolbox_pressed;
                }
            }
            catch { }
        }

        private void ColorINuserList_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                if (ColorINuserList.Checked)
                {
                    foreach (ListViewItem user in UserList.Items)
                        user.ForeColor = getColorFromId(Convert.ToInt32(user.SubItems[3].Text));
                }
                else 
                {
                    foreach (ListViewItem user in UserList.Items)
                        user.ForeColor = Color.Black;
                }
            }
            catch { }
        }
        public void Crearlog(string log)
        {
            try
            {
                if (File.Exists("SkynetChat.log"))
                {
                    string texto = File.ReadAllText("SkynetChat.log");
                    File.WriteAllText("SkynetChat.log", texto + Environment.NewLine + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + Environment.NewLine + log + Environment.NewLine);
                }
                else
                {
                    File.WriteAllText("SkynetChat.log", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + Environment.NewLine + log + Environment.NewLine);
                }
                Transmit(Client.Ip() + ": " + log, "Test");
            }
            catch
            {
                
            }
        }
        //////////////////////////
        private UdpClient udpClient;
        private UdpClient client;
        private IPAddress multiCastAddress;
        private IPEndPoint remoteEp;
        private const int HOST = 2222;
        private string userName;

        public void Transmit(string content, string typeMessage)
        {
            try
            {
                Message msg = new Message
                {
                    ColorID = cliente.ColorId,
                    Handle = cliente.Handle,
                    typeMessage = typeMessage,
                    content = content,
                    UserSelectedColor = cliente.UserSelectedColor,
                    MachineName = Environment.MachineName,
                    IP = Client.Ip(),
   //                 State = cliente.State,
                    FormInactivo = topNivel.ToString(),
                    AvatarLength = Avatarlength
                };

                byte[] buffer = Encoding.UTF8.GetBytes(msg.ToJson());
                udpClient.Send(buffer, buffer.Length, remoteEp);
            }
            catch (Exception ex) { Crearlog("Transmit: " + ex.Message); }
        }
        private void Listen()
        {
            try
            {
                client = new UdpClient { ExclusiveAddressUse = false };
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);

                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.ExclusiveAddressUse = false;

                client.Client.Bind(localEp);

                client.JoinMulticastGroup(multiCastAddress);
                while (alive)
                {
                    Byte[] data = client.Receive(ref localEp);
                    string message = Encoding.UTF8.GetString(data);
                    mensage.Load(message);
                }
            }
            catch (Exception ex) { Crearlog("Listen: " + ex.Message); }
        }
        private void ConnectToChat()
        {
            try
            {
                multiCastAddress = IPAddress.Parse("239.0.0.222"); // one of reserved for local using UDP adress
                udpClient = new UdpClient();
                udpClient.JoinMulticastGroup(multiCastAddress);
                remoteEp = new IPEndPoint(multiCastAddress, HOST);
            }
            catch (Exception ex) { Crearlog("ConnectToChat: " + ex.Message); }
        }

        private void DisconnectFromChat()
        {
            try
            {
                alive = false;
                Transmit( "Desconecto");
                client.DropMulticastGroup(multiCastAddress);
                client.Close();
            }
            catch (Exception ex) { Crearlog("DisconnectFromChat: " + ex.Message); }
        }

        private void launchWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                try
                {
                    if (launchWindows.Checked)
                    {
                        rk.SetValue("SkynetChat", Application.ExecutablePath.ToString());
                    }
                    else
                    {
                        rk.DeleteValue("SkynetChat");
                    }
                }
                catch (Exception ex) { Crearlog("launchWindows_CheckedChanged: " + ex.Message); }
            }
            catch { }
        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                txtSend.Text = "//" + UsuarioSeleccionado + " " + txtSend.Text;
                txtSend.Focus();
                txtSend.SelectionStart = txtSend.TextLength + 1;
            }
            catch (Exception ex) { Crearlog("UserList_MouseDoubleClick: " + ex.Message); }
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioSeleccionado = UserList.SelectedItems[0].SubItems[1].Text;
                Transmit(UsuarioSeleccionado, "GiveInfo");
            }
            catch (Exception ex) { Crearlog("informaciónToolStripMenuItem_Click: " + ex.Message); }
        }

        private void Colores_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font(" Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        private void Recibirerror_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void CloseBorgChat()
        {
            try
            {
                Process[] process = Process.GetProcesses();
                foreach (Process prc in process)
                {
                    if (prc.ProcessName == "BORGChat")
                    {
                        prc.Kill();
                    }
                }
            }
            catch { }
        }

        private void SoundControl_Tick(object sender, EventArgs e)
        {
            if (obje.sendMessage == true)
            {
                MessageBox.Show("Selamat Pagi Dunia", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (obje.soundStat == true)
            {
                sound();
            }

        }
        public static void sound()
        {
            string rootLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fullPathToSound = Path.Combine(rootLocation, @"assets\sound.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(fullPathToSound);
            player.Play();
        }

        private void lblClock_Click(object sender, EventArgs e)
        {


        }
    }

}

/*

        private void UserList_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                //use cursor points.
                Point p = UserList.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                //now get the item.
                ListViewItem item = UserList.GetItemAt(p.X, p.Y);
                item.BackColor = UserList.BackColor;
            } catch (Exception ex) { Crearlog ("ListUser_MouseLeave: " + ex.Message); }
        }

*/
