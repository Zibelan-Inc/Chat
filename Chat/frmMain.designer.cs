using System.ComponentModel;
using System.Windows.Forms;
using Chat.Controles;
using Chat.Forms;
using Chat.Properties;

namespace Chat
{
    partial class frmMain
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOnlineT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOcupadoT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAusenteT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ActivoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OcupadoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AusenteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UserMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mensajePrivadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatPrivadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buzzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videollamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escritorioRemotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorarPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizarFechaToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UPdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseChat = new System.Windows.Forms.ToolStripMenuItem();
            this.TicToc = new System.Windows.Forms.Timer(this.components);
            this.timerEscribiendo = new System.Windows.Forms.Timer(this.components);
            this.TmrAutoCopy = new System.Windows.Forms.Timer(this.components);
            this.Buzz = new System.Windows.Forms.Timer(this.components);
            this.mnuPresetMsg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Hola_PresetMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.dime_PresetMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.salir_PresetMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupado_PresetMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.noPuedo_PresetMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.usersWriting = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.webChatMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AbrirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BajarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistorialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecargarLista = new System.Windows.Forms.Timer(this.components);
            this.pnlTools = new System.Windows.Forms.Panel();
            this.Jellyfin = new Guna.UI2.WinForms.Guna2Button();
            this.logout = new Guna.UI2.WinForms.Guna2Button();
            this.lblSettings = new Guna.UI2.WinForms.Guna2Button();
            this.lblInfo = new Guna.UI2.WinForms.Guna2Button();
            this.Monitor = new Guna.UI2.WinForms.Guna2Button();
            this.songPlayer = new Guna.UI2.WinForms.Guna2Button();
            this.UpdateUser = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblImgstatus = new System.Windows.Forms.PictureBox();
            this.PicRetryIcon = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblTittle = new System.Windows.Forms.Label();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CircleProgressBar2 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.pictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.trance = new System.Windows.Forms.Timer(this.components);
            this.Hidepanel = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.PanelContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.PanelChat = new Guna.UI2.WinForms.Guna2Panel();
            this.webChat = new WebBrowserEx();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panelTools = new System.Windows.Forms.Panel();
            this.picSmiley = new System.Windows.Forms.PictureBox();
            this.picMore = new System.Windows.Forms.PictureBox();
            this.picVoiceChat = new System.Windows.Forms.PictureBox();
            this.picPresetMessage = new System.Windows.Forms.PictureBox();
            this.picBuzz = new System.Windows.Forms.PictureBox();
            this.picFileSend = new System.Windows.Forms.PictureBox();
            this.picViewDesktop = new System.Windows.Forms.PictureBox();
            this.picVideoChat = new System.Windows.Forms.PictureBox();
            this.UsuarioEscribiendo = new System.Windows.Forms.Label();
            this.pnlSendContainer = new System.Windows.Forms.Panel();
            this.ButtonScreen = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonBuzz = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonMessage = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonArrow = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonSmile = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonSend = new Guna.UI2.WinForms.Guna2Button();
            this.txtSend = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserMPContainer = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.UserMP = new System.Windows.Forms.PictureBox();
            this.UserMPDown = new System.Windows.Forms.Panel();
            this.lblMP = new System.Windows.Forms.Label();
            this.lblSendRestBottom = new System.Windows.Forms.Label();
            this.lblSendRestRight = new System.Windows.Forms.Label();
            this.lblSendRestLeft = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.UserSearch = new System.Windows.Forms.DataGridView();
            this.UserList = new System.Windows.Forms.DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSearchContainer = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.picSearchL = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.lblMuteUserPanel = new System.Windows.Forms.Label();
            this.lblSettingsUserPanel = new System.Windows.Forms.Label();
            this.lblTicToc = new System.Windows.Forms.Label();
            this.lblWelcome2UserPanel = new System.Windows.Forms.Label();
            this.lblWelcomeUserPanel = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse6 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tmExpandirtxt = new System.Windows.Forms.Timer(this.components);
            this.tmContraertxt = new System.Windows.Forms.Timer(this.components);
            this.mnuTray.SuspendLayout();
            this.mnuStatus.SuspendLayout();
            this.UserMenu.SuspendLayout();
            this.mnuPresetMsg.SuspendLayout();
            this.webChatMenu.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImgstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRetryIcon)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2CircleProgressBar2.SuspendLayout();
            this.guna2CircleProgressBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.PanelContainer.SuspendLayout();
            this.PanelChat.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVoiceChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPresetMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViewDesktop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoChat)).BeginInit();
            this.pnlSendContainer.SuspendLayout();
            this.UserMPContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMP)).BeginInit();
            this.UserMPDown.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.pnlSearchContainer.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchL)).BeginInit();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(572, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 24);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(542, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(24, 24);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(514, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(24, 24);
            this.panel5.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(28, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(24, 24);
            this.panel10.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(200, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mnuTray
            // 
            this.mnuTray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.mnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuOnlineT,
            this.mnuOcupadoT,
            this.mnuAusenteT,
            this.mnuSettingsT,
            this.mnuExit});
            this.mnuTray.Name = "mnuTray";
            this.mnuTray.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuTray.Size = new System.Drawing.Size(160, 136);
            this.mnuTray.Click += new System.EventHandler(this.ActivoMenuItem_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.ForeColor = System.Drawing.Color.White;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(159, 22);
            this.mnuOpen.Text = "Abrir Chat";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuOnlineT
            // 
            this.mnuOnlineT.Checked = true;
            this.mnuOnlineT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuOnlineT.ForeColor = System.Drawing.Color.White;
            this.mnuOnlineT.Name = "mnuOnlineT";
            this.mnuOnlineT.Size = new System.Drawing.Size(159, 22);
            this.mnuOnlineT.Text = "Activo";
            // 
            // mnuOcupadoT
            // 
            this.mnuOcupadoT.ForeColor = System.Drawing.Color.White;
            this.mnuOcupadoT.Name = "mnuOcupadoT";
            this.mnuOcupadoT.Size = new System.Drawing.Size(159, 22);
            this.mnuOcupadoT.Tag = "away";
            this.mnuOcupadoT.Text = "Ocupado";
            this.mnuOcupadoT.Click += new System.EventHandler(this.OcupadoMenuItem_Click);
            // 
            // mnuAusenteT
            // 
            this.mnuAusenteT.ForeColor = System.Drawing.Color.White;
            this.mnuAusenteT.Name = "mnuAusenteT";
            this.mnuAusenteT.Size = new System.Drawing.Size(159, 22);
            this.mnuAusenteT.Tag = "lunch";
            this.mnuAusenteT.Text = "Ausente";
            this.mnuAusenteT.Click += new System.EventHandler(this.AusenteMenuItem_Click);
            // 
            // mnuSettingsT
            // 
            this.mnuSettingsT.ForeColor = System.Drawing.Color.White;
            this.mnuSettingsT.Name = "mnuSettingsT";
            this.mnuSettingsT.Size = new System.Drawing.Size(159, 22);
            this.mnuSettingsT.Text = "Configurar Chat";
            this.mnuSettingsT.Click += new System.EventHandler(this.mnuSettingsT_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.ForeColor = System.Drawing.Color.White;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "Cerrar Chat";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuStatus
            // 
            this.mnuStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.mnuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActivoMenuItem,
            this.OcupadoMenuItem,
            this.AusenteMenuItem});
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuStatus.Size = new System.Drawing.Size(124, 70);
            // 
            // ActivoMenuItem
            // 
            this.ActivoMenuItem.ForeColor = System.Drawing.Color.White;
            this.ActivoMenuItem.Image = global::Chat.Properties.Resources._57;
            this.ActivoMenuItem.Name = "ActivoMenuItem";
            this.ActivoMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ActivoMenuItem.Text = "Activo";
            this.ActivoMenuItem.Click += new System.EventHandler(this.ActivoMenuItem_Click);
            // 
            // OcupadoMenuItem
            // 
            this.OcupadoMenuItem.ForeColor = System.Drawing.Color.White;
            this.OcupadoMenuItem.Image = global::Chat.Properties.Resources._60;
            this.OcupadoMenuItem.Name = "OcupadoMenuItem";
            this.OcupadoMenuItem.Size = new System.Drawing.Size(123, 22);
            this.OcupadoMenuItem.Text = "Ocupado";
            this.OcupadoMenuItem.Click += new System.EventHandler(this.OcupadoMenuItem_Click);
            // 
            // AusenteMenuItem
            // 
            this.AusenteMenuItem.ForeColor = System.Drawing.Color.White;
            this.AusenteMenuItem.Image = global::Chat.Properties.Resources._63;
            this.AusenteMenuItem.Name = "AusenteMenuItem";
            this.AusenteMenuItem.Size = new System.Drawing.Size(123, 22);
            this.AusenteMenuItem.Text = "Ausente";
            this.AusenteMenuItem.Click += new System.EventHandler(this.AusenteMenuItem_Click);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ToolTip1.ForeColor = System.Drawing.Color.White;
            this.ToolTip1.InitialDelay = 100;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // UserMenu
            // 
            this.UserMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.UserMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UserMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensajePrivadoToolStripMenuItem,
            this.chatPrivadoToolStripMenuItem,
            this.enviarArchivoToolStripMenuItem,
            this.beepToolStripMenuItem,
            this.buzzToolStripMenuItem,
            this.llamadaToolStripMenuItem,
            this.videollamadaToolStripMenuItem,
            this.escritorioRemotoToolStripMenuItem,
            this.explorarPCToolStripMenuItem,
            this.solicitarHistorialToolStripMenuItem,
            this.sincronizarFechaToolStrip,
            this.informaciónToolStripMenuItem,
            this.toolStripSeparator3,
            this.UPdate,
            this.toolStripSeparator2,
            this.CloseChat});
            this.UserMenu.Name = "metroContextMenu1";
            this.UserMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.UserMenu.Size = new System.Drawing.Size(219, 324);
            // 
            // mensajePrivadoToolStripMenuItem
            // 
            this.mensajePrivadoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.mensajePrivadoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mensajePrivadoToolStripMenuItem.Image = global::Chat.Properties.Resources.bbm_messenger;
            this.mensajePrivadoToolStripMenuItem.Name = "mensajePrivadoToolStripMenuItem";
            this.mensajePrivadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mensajePrivadoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.mensajePrivadoToolStripMenuItem.Text = "Mensaje privado";
            this.mensajePrivadoToolStripMenuItem.Click += new System.EventHandler(this.mensajePrivadoToolStripMenuItem_Click);
            // 
            // chatPrivadoToolStripMenuItem
            // 
            this.chatPrivadoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.chatPrivadoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.chatPrivadoToolStripMenuItem.Image = global::Chat.Properties.Resources.messages_Chat;
            this.chatPrivadoToolStripMenuItem.Name = "chatPrivadoToolStripMenuItem";
            this.chatPrivadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.chatPrivadoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.chatPrivadoToolStripMenuItem.Text = "Chat privado";
            this.chatPrivadoToolStripMenuItem.Click += new System.EventHandler(this.chatPrivadoToolStripMenuItem_Click);
            // 
            // enviarArchivoToolStripMenuItem
            // 
            this.enviarArchivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.enviarArchivoToolStripMenuItem.Image = global::Chat.Properties.Resources.copy_file;
            this.enviarArchivoToolStripMenuItem.Name = "enviarArchivoToolStripMenuItem";
            this.enviarArchivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.enviarArchivoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.enviarArchivoToolStripMenuItem.Text = "Enviar archivo";
            this.enviarArchivoToolStripMenuItem.Click += new System.EventHandler(this.enviarArchivoToolStripMenuItem_Click);
            // 
            // beepToolStripMenuItem
            // 
            this.beepToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.beepToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.beepToolStripMenuItem.Image = global::Chat.Properties.Resources.speaker;
            this.beepToolStripMenuItem.Name = "beepToolStripMenuItem";
            this.beepToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.beepToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.beepToolStripMenuItem.Text = "Beep";
            this.beepToolStripMenuItem.Click += new System.EventHandler(this.beepToolStripMenuItem_Click);
            // 
            // buzzToolStripMenuItem
            // 
            this.buzzToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.buzzToolStripMenuItem.Image = global::Chat.Properties.Resources.whistle;
            this.buzzToolStripMenuItem.Name = "buzzToolStripMenuItem";
            this.buzzToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.buzzToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.buzzToolStripMenuItem.Text = "Buzz";
            this.buzzToolStripMenuItem.Click += new System.EventHandler(this.buzzToolStripMenuItem_Click);
            // 
            // llamadaToolStripMenuItem
            // 
            this.llamadaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.llamadaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.llamadaToolStripMenuItem.Image = global::Chat.Properties.Resources.phone_call;
            this.llamadaToolStripMenuItem.Name = "llamadaToolStripMenuItem";
            this.llamadaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.llamadaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.llamadaToolStripMenuItem.Text = "Llamada";
            this.llamadaToolStripMenuItem.Click += new System.EventHandler(this.llamadaToolStripMenuItem_Click);
            // 
            // videollamadaToolStripMenuItem
            // 
            this.videollamadaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.videollamadaToolStripMenuItem.Image = global::Chat.Properties.Resources.webcam_call;
            this.videollamadaToolStripMenuItem.Name = "videollamadaToolStripMenuItem";
            this.videollamadaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.videollamadaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.videollamadaToolStripMenuItem.Text = "Videollamada";
            this.videollamadaToolStripMenuItem.Click += new System.EventHandler(this.videollamadaToolStripMenuItem_Click);
            // 
            // escritorioRemotoToolStripMenuItem
            // 
            this.escritorioRemotoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.escritorioRemotoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.escritorioRemotoToolStripMenuItem.Image = global::Chat.Properties.Resources.imac_desktop;
            this.escritorioRemotoToolStripMenuItem.Name = "escritorioRemotoToolStripMenuItem";
            this.escritorioRemotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.escritorioRemotoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.escritorioRemotoToolStripMenuItem.Text = "Compartir escritorio";
            this.escritorioRemotoToolStripMenuItem.Click += new System.EventHandler(this.escritorioRemotoToolStripMenuItem_Click);
            // 
            // explorarPCToolStripMenuItem
            // 
            this.explorarPCToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.explorarPCToolStripMenuItem.Image = global::Chat.Properties.Resources.file_explorer;
            this.explorarPCToolStripMenuItem.Name = "explorarPCToolStripMenuItem";
            this.explorarPCToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.explorarPCToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.explorarPCToolStripMenuItem.Text = "Explorar PC";
            this.explorarPCToolStripMenuItem.Click += new System.EventHandler(this.explorarPCToolStripMenuItem_Click);
            // 
            // solicitarHistorialToolStripMenuItem
            // 
            this.solicitarHistorialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.solicitarHistorialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.solicitarHistorialToolStripMenuItem.Image = global::Chat.Properties.Resources.order_history;
            this.solicitarHistorialToolStripMenuItem.Name = "solicitarHistorialToolStripMenuItem";
            this.solicitarHistorialToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.solicitarHistorialToolStripMenuItem.Text = "Solicitar historial";
            this.solicitarHistorialToolStripMenuItem.Click += new System.EventHandler(this.solicitarHistorialToolStripMenuItem_Click_1);
            // 
            // sincronizarFechaToolStrip
            // 
            this.sincronizarFechaToolStrip.ForeColor = System.Drawing.Color.White;
            this.sincronizarFechaToolStrip.Image = global::Chat.Properties.Resources.delivery_time;
            this.sincronizarFechaToolStrip.Name = "sincronizarFechaToolStrip";
            this.sincronizarFechaToolStrip.Size = new System.Drawing.Size(218, 22);
            this.sincronizarFechaToolStrip.Text = "Sincronizar hora";
            this.sincronizarFechaToolStrip.Click += new System.EventHandler(this.sincronizarFechaToolStrip_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.informaciónToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.informaciónToolStripMenuItem.Image = global::Chat.Properties.Resources.infopng;
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.informaciónToolStripMenuItem.Text = "Información";
            this.informaciónToolStripMenuItem.Click += new System.EventHandler(this.informaciónToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // UPdate
            // 
            this.UPdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.UPdate.ForeColor = System.Drawing.Color.White;
            this.UPdate.Name = "UPdate";
            this.UPdate.Size = new System.Drawing.Size(218, 22);
            this.UPdate.Text = "Update User Chat";
            this.UPdate.Visible = false;
            this.UPdate.Click += new System.EventHandler(this.Update_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // CloseChat
            // 
            this.CloseChat.ForeColor = System.Drawing.Color.White;
            this.CloseChat.Name = "CloseChat";
            this.CloseChat.Size = new System.Drawing.Size(218, 22);
            this.CloseChat.Text = "Close User Chat";
            this.CloseChat.Visible = false;
            this.CloseChat.Click += new System.EventHandler(this.CloseChat_Click);
            // 
            // TicToc
            // 
            this.TicToc.Enabled = true;
            this.TicToc.Tick += new System.EventHandler(this.TicToc_Tick);
            // 
            // timerEscribiendo
            // 
            this.timerEscribiendo.Enabled = true;
            this.timerEscribiendo.Interval = 1000;
            this.timerEscribiendo.Tick += new System.EventHandler(this.timerEscribiendo_Tick);
            // 
            // TmrAutoCopy
            // 
            this.TmrAutoCopy.Tick += new System.EventHandler(this.TmrAutoCopy_Tick);
            // 
            // Buzz
            // 
            this.Buzz.Interval = 300;
            this.Buzz.Tick += new System.EventHandler(this.Buzz_Tick);
            // 
            // mnuPresetMsg
            // 
            this.mnuPresetMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.mnuPresetMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Hola_PresetMsg,
            this.dime_PresetMsg,
            this.salir_PresetMsg,
            this.ocupado_PresetMsg,
            this.noPuedo_PresetMsg});
            this.mnuPresetMsg.Name = "mnuTray";
            this.mnuPresetMsg.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuPresetMsg.Size = new System.Drawing.Size(172, 114);
            // 
            // Hola_PresetMsg
            // 
            this.Hola_PresetMsg.ForeColor = System.Drawing.Color.White;
            this.Hola_PresetMsg.Name = "Hola_PresetMsg";
            this.Hola_PresetMsg.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Hola_PresetMsg.Size = new System.Drawing.Size(171, 22);
            this.Hola_PresetMsg.Text = "Hola!";
            this.Hola_PresetMsg.Click += new System.EventHandler(this.Hola_PresetMsg_Click);
            // 
            // dime_PresetMsg
            // 
            this.dime_PresetMsg.ForeColor = System.Drawing.Color.White;
            this.dime_PresetMsg.Name = "dime_PresetMsg";
            this.dime_PresetMsg.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.dime_PresetMsg.Size = new System.Drawing.Size(171, 22);
            this.dime_PresetMsg.Text = "Dime";
            this.dime_PresetMsg.Visible = false;
            this.dime_PresetMsg.Click += new System.EventHandler(this.dime_PresetMsg_Click);
            // 
            // salir_PresetMsg
            // 
            this.salir_PresetMsg.ForeColor = System.Drawing.Color.White;
            this.salir_PresetMsg.Name = "salir_PresetMsg";
            this.salir_PresetMsg.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.salir_PresetMsg.Size = new System.Drawing.Size(171, 22);
            this.salir_PresetMsg.Text = "Voy a salir";
            this.salir_PresetMsg.Visible = false;
            this.salir_PresetMsg.Click += new System.EventHandler(this.salir_PresetMsg_Click);
            // 
            // ocupado_PresetMsg
            // 
            this.ocupado_PresetMsg.ForeColor = System.Drawing.Color.White;
            this.ocupado_PresetMsg.Name = "ocupado_PresetMsg";
            this.ocupado_PresetMsg.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ocupado_PresetMsg.Size = new System.Drawing.Size(171, 22);
            this.ocupado_PresetMsg.Tag = "dnd";
            this.ocupado_PresetMsg.Text = "Estoy ocupado";
            this.ocupado_PresetMsg.Click += new System.EventHandler(this.ocupado_PresetMsg_Click);
            // 
            // noPuedo_PresetMsg
            // 
            this.noPuedo_PresetMsg.ForeColor = System.Drawing.Color.White;
            this.noPuedo_PresetMsg.Name = "noPuedo_PresetMsg";
            this.noPuedo_PresetMsg.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.noPuedo_PresetMsg.Size = new System.Drawing.Size(171, 22);
            this.noPuedo_PresetMsg.Tag = "away";
            this.noPuedo_PresetMsg.Text = "No puedo";
            this.noPuedo_PresetMsg.Click += new System.EventHandler(this.noPuedo_PresetMsg_Click);
            // 
            // usersWriting
            // 
            this.usersWriting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.usersWriting.FullRowSelect = true;
            this.usersWriting.GridLines = true;
            this.usersWriting.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.usersWriting.HideSelection = false;
            this.usersWriting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usersWriting.LabelWrap = false;
            this.usersWriting.Location = new System.Drawing.Point(0, 0);
            this.usersWriting.Name = "usersWriting";
            this.usersWriting.Size = new System.Drawing.Size(157, 97);
            this.usersWriting.TabIndex = 6;
            this.usersWriting.UseCompatibleStateImageBehavior = false;
            this.usersWriting.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 133;
            // 
            // webChatMenu
            // 
            this.webChatMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.webChatMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AbrirMenuItem,
            this.GuardarMenuItem,
            this.SubirMenuItem,
            this.BajarMenuItem,
            this.limpiarChatMenuItem,
            this.HistorialMenuItem});
            this.webChatMenu.Name = "mnuStatus";
            this.webChatMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.webChatMenu.Size = new System.Drawing.Size(164, 136);
            this.webChatMenu.Opening += new System.ComponentModel.CancelEventHandler(this.webChatMenu_Opening);
            // 
            // AbrirMenuItem
            // 
            this.AbrirMenuItem.ForeColor = System.Drawing.Color.White;
            this.AbrirMenuItem.Name = "AbrirMenuItem";
            this.AbrirMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AbrirMenuItem.Text = "Abrir";
            this.AbrirMenuItem.Click += new System.EventHandler(this.AbrirMenuItem_Click);
            // 
            // GuardarMenuItem
            // 
            this.GuardarMenuItem.ForeColor = System.Drawing.Color.White;
            this.GuardarMenuItem.Name = "GuardarMenuItem";
            this.GuardarMenuItem.Size = new System.Drawing.Size(163, 22);
            this.GuardarMenuItem.Text = "Guardar";
            this.GuardarMenuItem.Click += new System.EventHandler(this.GuardarMenuItem_Click);
            // 
            // SubirMenuItem
            // 
            this.SubirMenuItem.ForeColor = System.Drawing.Color.White;
            this.SubirMenuItem.Name = "SubirMenuItem";
            this.SubirMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SubirMenuItem.Text = "Subir";
            this.SubirMenuItem.Click += new System.EventHandler(this.SubirMenuItem_Click);
            // 
            // BajarMenuItem
            // 
            this.BajarMenuItem.ForeColor = System.Drawing.Color.White;
            this.BajarMenuItem.Name = "BajarMenuItem";
            this.BajarMenuItem.Size = new System.Drawing.Size(163, 22);
            this.BajarMenuItem.Text = "Bajar";
            this.BajarMenuItem.Click += new System.EventHandler(this.BajarMenuItem_Click);
            // 
            // limpiarChatMenuItem
            // 
            this.limpiarChatMenuItem.ForeColor = System.Drawing.Color.White;
            this.limpiarChatMenuItem.Name = "limpiarChatMenuItem";
            this.limpiarChatMenuItem.Size = new System.Drawing.Size(163, 22);
            this.limpiarChatMenuItem.Text = "Limpiar Chat";
            this.limpiarChatMenuItem.Click += new System.EventHandler(this.limpiarChatToolStripMenuItem_Click);
            // 
            // HistorialMenuItem
            // 
            this.HistorialMenuItem.ForeColor = System.Drawing.Color.White;
            this.HistorialMenuItem.Name = "HistorialMenuItem";
            this.HistorialMenuItem.Size = new System.Drawing.Size(163, 22);
            this.HistorialMenuItem.Text = "Solicitar Historial";
            this.HistorialMenuItem.Click += new System.EventHandler(this.solicitarHistorialToolStripMenuItem_Click);
            // 
            // RecargarLista
            // 
            this.RecargarLista.Enabled = true;
            this.RecargarLista.Tick += new System.EventHandler(this.RecargarLista_Tick);
            // 
            // pnlTools
            // 
            this.pnlTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.pnlTools.Controls.Add(this.Jellyfin);
            this.pnlTools.Controls.Add(this.logout);
            this.pnlTools.Controls.Add(this.lblSettings);
            this.pnlTools.Controls.Add(this.lblInfo);
            this.pnlTools.Controls.Add(this.Monitor);
            this.pnlTools.Controls.Add(this.songPlayer);
            this.pnlTools.Controls.Add(this.UpdateUser);
            this.pnlTools.Controls.Add(this.guna2Panel5);
            this.pnlTools.Controls.Add(this.guna2Panel4);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(75, 560);
            this.pnlTools.TabIndex = 5;
            // 
            // Jellyfin
            // 
            this.Jellyfin.CheckedState.Parent = this.Jellyfin;
            this.Jellyfin.CustomImages.Parent = this.Jellyfin;
            this.Jellyfin.Dock = System.Windows.Forms.DockStyle.Top;
            this.Jellyfin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.Jellyfin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Jellyfin.ForeColor = System.Drawing.Color.White;
            this.Jellyfin.HoverState.Parent = this.Jellyfin;
            this.Jellyfin.Image = global::Chat.Properties.Resources.ic_launcher;
            this.Jellyfin.ImageSize = new System.Drawing.Size(40, 40);
            this.Jellyfin.Location = new System.Drawing.Point(0, 399);
            this.Jellyfin.Name = "Jellyfin";
            this.Jellyfin.ShadowDecoration.Parent = this.Jellyfin;
            this.Jellyfin.Size = new System.Drawing.Size(75, 45);
            this.Jellyfin.TabIndex = 17;
            this.Jellyfin.Click += new System.EventHandler(this.Jellyfin_Click);
            // 
            // logout
            // 
            this.logout.CheckedState.Parent = this.logout;
            this.logout.CustomImages.Parent = this.logout;
            this.logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.logout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.HoverState.Parent = this.logout;
            this.logout.Image = global::Chat.Properties.Resources.exitpng;
            this.logout.ImageSize = new System.Drawing.Size(40, 40);
            this.logout.Location = new System.Drawing.Point(0, 515);
            this.logout.Name = "logout";
            this.logout.ShadowDecoration.Parent = this.logout;
            this.logout.Size = new System.Drawing.Size(75, 45);
            this.logout.TabIndex = 16;
            this.logout.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // lblSettings
            // 
            this.lblSettings.CheckedState.Parent = this.lblSettings;
            this.lblSettings.CustomImages.Parent = this.lblSettings;
            this.lblSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.lblSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSettings.ForeColor = System.Drawing.Color.White;
            this.lblSettings.HoverState.Parent = this.lblSettings;
            this.lblSettings.Image = global::Chat.Properties.Resources.settingspng;
            this.lblSettings.ImageSize = new System.Drawing.Size(40, 40);
            this.lblSettings.Location = new System.Drawing.Point(0, 354);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.ShadowDecoration.Parent = this.lblSettings;
            this.lblSettings.Size = new System.Drawing.Size(75, 45);
            this.lblSettings.TabIndex = 15;
            this.lblSettings.Click += new System.EventHandler(this.lblSettingsUserPanel_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.CheckedState.Parent = this.lblInfo;
            this.lblInfo.CustomImages.Parent = this.lblInfo;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.HoverState.Parent = this.lblInfo;
            this.lblInfo.Image = global::Chat.Properties.Resources.infopng;
            this.lblInfo.ImageSize = new System.Drawing.Size(40, 40);
            this.lblInfo.Location = new System.Drawing.Point(0, 309);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.ShadowDecoration.Parent = this.lblInfo;
            this.lblInfo.Size = new System.Drawing.Size(75, 45);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // Monitor
            // 
            this.Monitor.CheckedState.Parent = this.Monitor;
            this.Monitor.CustomImages.Parent = this.Monitor;
            this.Monitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.Monitor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.Monitor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Monitor.ForeColor = System.Drawing.Color.White;
            this.Monitor.HoverState.Parent = this.Monitor;
            this.Monitor.Image = global::Chat.Properties.Resources.monitor;
            this.Monitor.ImageSize = new System.Drawing.Size(40, 40);
            this.Monitor.Location = new System.Drawing.Point(0, 264);
            this.Monitor.Name = "Monitor";
            this.Monitor.ShadowDecoration.Parent = this.Monitor;
            this.Monitor.Size = new System.Drawing.Size(75, 45);
            this.Monitor.TabIndex = 13;
            this.Monitor.Visible = false;
            this.Monitor.Click += new System.EventHandler(this.label1_Click);
            // 
            // songPlayer
            // 
            this.songPlayer.CheckedState.Parent = this.songPlayer;
            this.songPlayer.CustomImages.Parent = this.songPlayer;
            this.songPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.songPlayer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.songPlayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.songPlayer.ForeColor = System.Drawing.Color.White;
            this.songPlayer.HoverState.Parent = this.songPlayer;
            this.songPlayer.Image = global::Chat.Properties.Resources.music;
            this.songPlayer.ImageSize = new System.Drawing.Size(40, 40);
            this.songPlayer.Location = new System.Drawing.Point(0, 219);
            this.songPlayer.Name = "songPlayer";
            this.songPlayer.ShadowDecoration.Parent = this.songPlayer;
            this.songPlayer.Size = new System.Drawing.Size(75, 45);
            this.songPlayer.TabIndex = 12;
            this.songPlayer.Click += new System.EventHandler(this.songPlayer_Click);
            // 
            // UpdateUser
            // 
            this.UpdateUser.CheckedState.Parent = this.UpdateUser;
            this.UpdateUser.CustomImages.Parent = this.UpdateUser;
            this.UpdateUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdateUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.UpdateUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UpdateUser.ForeColor = System.Drawing.Color.White;
            this.UpdateUser.HoverState.Parent = this.UpdateUser;
            this.UpdateUser.Image = global::Chat.Properties.Resources.updatepng;
            this.UpdateUser.ImageSize = new System.Drawing.Size(40, 40);
            this.UpdateUser.Location = new System.Drawing.Point(0, 174);
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.ShadowDecoration.Parent = this.UpdateUser;
            this.UpdateUser.Size = new System.Drawing.Size(75, 45);
            this.UpdateUser.TabIndex = 11;
            this.UpdateUser.Visible = false;
            this.UpdateUser.Click += new System.EventHandler(this.Upd_Click);
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel5.Location = new System.Drawing.Point(0, 74);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            this.guna2Panel5.Size = new System.Drawing.Size(75, 100);
            this.guna2Panel5.TabIndex = 10;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(75, 74);
            this.guna2Panel4.TabIndex = 9;
            this.guna2Panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.guna2Panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.guna2Panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Chat.Properties.Resources.Logo_SC1;
            this.guna2PictureBox1.Location = new System.Drawing.Point(15, 14);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(46, 45);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 8;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.guna2PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.guna2PictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClose.Image = global::Chat.Properties.Resources.close;
            this.lblClose.Location = new System.Drawing.Point(155, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(45, 29);
            this.lblClose.TabIndex = 32;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblImgstatus
            // 
            this.lblImgstatus.Image = ((System.Drawing.Image)(resources.GetObject("lblImgstatus.Image")));
            this.lblImgstatus.Location = new System.Drawing.Point(3, 6);
            this.lblImgstatus.Name = "lblImgstatus";
            this.lblImgstatus.Size = new System.Drawing.Size(15, 18);
            this.lblImgstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblImgstatus.TabIndex = 8;
            this.lblImgstatus.TabStop = false;
            // 
            // PicRetryIcon
            // 
            this.PicRetryIcon.BackColor = System.Drawing.Color.Transparent;
            this.PicRetryIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.PicRetryIcon.Image = ((System.Drawing.Image)(resources.GetObject("PicRetryIcon.Image")));
            this.PicRetryIcon.Location = new System.Drawing.Point(141, 0);
            this.PicRetryIcon.Name = "PicRetryIcon";
            this.PicRetryIcon.Padding = new System.Windows.Forms.Padding(5);
            this.PicRetryIcon.Size = new System.Drawing.Size(27, 28);
            this.PicRetryIcon.TabIndex = 7;
            this.PicRetryIcon.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(20, 5);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(87, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Cambiar estado";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblServer
            // 
            this.lblServer.BackColor = System.Drawing.Color.Transparent;
            this.lblServer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblServer.Image = ((System.Drawing.Image)(resources.GetObject("lblServer.Image")));
            this.lblServer.Location = new System.Drawing.Point(168, 0);
            this.lblServer.Margin = new System.Windows.Forms.Padding(3);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(32, 28);
            this.lblServer.TabIndex = 1;
            this.lblServer.Tag = "SS";
            this.lblServer.Click += new System.EventHandler(this.lblServer_Click);
            // 
            // lblTittle
            // 
            this.lblTittle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTittle.AutoSize = true;
            this.lblTittle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.lblTittle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTittle.ForeColor = System.Drawing.Color.White;
            this.lblTittle.Location = new System.Drawing.Point(6, 7);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(69, 15);
            this.lblTittle.TabIndex = 23;
            this.lblTittle.Text = "KosmoChat";
            this.lblTittle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.lblTittle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.lblTittle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(110, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 31;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.guna2Panel1.Controls.Add(this.guna2CircleProgressBar2);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel1.Controls.Add(this.lblTittle);
            this.guna2Panel1.Controls.Add(this.lblClose);
            this.guna2Panel1.Controls.Add(this.pnlStatus);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(680, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(200, 560);
            this.guna2Panel1.TabIndex = 6;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.guna2Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.guna2Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // guna2CircleProgressBar2
            // 
            this.guna2CircleProgressBar2.Animated = true;
            this.guna2CircleProgressBar2.AnimationSpeed = 0.4F;
            this.guna2CircleProgressBar2.Controls.Add(this.guna2CircleProgressBar1);
            this.guna2CircleProgressBar2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar2.FillThickness = 3;
            this.guna2CircleProgressBar2.Location = new System.Drawing.Point(38, 35);
            this.guna2CircleProgressBar2.Name = "guna2CircleProgressBar2";
            this.guna2CircleProgressBar2.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.guna2CircleProgressBar2.ProgressThickness = 3;
            this.guna2CircleProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar2.ShadowDecoration.Parent = this.guna2CircleProgressBar2;
            this.guna2CircleProgressBar2.Size = new System.Drawing.Size(130, 130);
            this.guna2CircleProgressBar2.TabIndex = 35;
            this.guna2CircleProgressBar2.Value = 33;
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Animated = true;
            this.guna2CircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.Controls.Add(this.pictureBox1);
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.FillThickness = 3;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(5, 5);
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2CircleProgressBar1.ProgressThickness = 3;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.ShadowDecoration.Parent = this.guna2CircleProgressBar1;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(120, 120);
            this.guna2CircleProgressBar1.TabIndex = 34;
            this.guna2CircleProgressBar1.Value = 33;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBox1.ShadowDecoration.Parent = this.pictureBox1;
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.pnlStatus.Controls.Add(this.lblImgstatus);
            this.pnlStatus.Controls.Add(this.PicRetryIcon);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.lblServer);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.ForeColor = System.Drawing.Color.Transparent;
            this.pnlStatus.Location = new System.Drawing.Point(0, 532);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlStatus.Size = new System.Drawing.Size(200, 28);
            this.pnlStatus.TabIndex = 4;
            // 
            // trance
            // 
            this.trance.Interval = 5000;
            this.trance.Tick += new System.EventHandler(this.trance_Tick);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.ContextMenuStrip = this.mnuTray;
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "KosmoChat";
            this.notifyIcon2.Visible = true;
            this.notifyIcon2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.PanelChat);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(75, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.ShadowDecoration.Parent = this.PanelContainer;
            this.PanelContainer.Size = new System.Drawing.Size(605, 560);
            this.PanelContainer.TabIndex = 7;
            // 
            // PanelChat
            // 
            this.PanelChat.Controls.Add(this.webChat);
            this.PanelChat.Controls.Add(this.pnlMenu);
            this.PanelChat.Controls.Add(this.pnlSendContainer);
            this.PanelChat.Controls.Add(this.guna2Panel3);
            this.PanelChat.Controls.Add(this.guna2Panel2);
            this.PanelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelChat.Location = new System.Drawing.Point(0, 0);
            this.PanelChat.Name = "PanelChat";
            this.PanelChat.ShadowDecoration.Parent = this.PanelChat;
            this.PanelChat.Size = new System.Drawing.Size(605, 560);
            this.PanelChat.TabIndex = 0;
            // 
            // webChat
            // 
            this.webChat.AllowWebBrowserDrop = false;
            this.webChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webChat.IsWebBrowserContextMenuEnabled = false;
            this.webChat.Location = new System.Drawing.Point(200, 55);
            this.webChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChat.Name = "webChat";
            this.webChat.Size = new System.Drawing.Size(405, 422);
            this.webChat.TabIndex = 32;
            this.webChat.Visible = false;
            this.webChat.WebBrowserShortcutsEnabled = false;
            this.webChat.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webChat_PreviewKeyDown);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.pnlMenu.Controls.Add(this.panelTools);
            this.pnlMenu.Controls.Add(this.UsuarioEscribiendo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenu.Location = new System.Drawing.Point(200, 477);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(405, 21);
            this.pnlMenu.TabIndex = 31;
            // 
            // panelTools
            // 
            this.panelTools.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelTools.Controls.Add(this.picSmiley);
            this.panelTools.Controls.Add(this.picMore);
            this.panelTools.Controls.Add(this.picVoiceChat);
            this.panelTools.Controls.Add(this.picPresetMessage);
            this.panelTools.Controls.Add(this.picBuzz);
            this.panelTools.Controls.Add(this.picFileSend);
            this.panelTools.Controls.Add(this.picViewDesktop);
            this.panelTools.Controls.Add(this.picVideoChat);
            this.panelTools.Location = new System.Drawing.Point(208, -1);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(202, 21);
            this.panelTools.TabIndex = 23;
            this.panelTools.Visible = false;
            // 
            // picSmiley
            // 
            this.picSmiley.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSmiley.Dock = System.Windows.Forms.DockStyle.Right;
            this.picSmiley.Image = ((System.Drawing.Image)(resources.GetObject("picSmiley.Image")));
            this.picSmiley.ImageLocation = "";
            this.picSmiley.Location = new System.Drawing.Point(18, 0);
            this.picSmiley.Name = "picSmiley";
            this.picSmiley.Size = new System.Drawing.Size(23, 21);
            this.picSmiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSmiley.TabIndex = 30;
            this.picSmiley.TabStop = false;
            this.picSmiley.Tag = "";
            this.picSmiley.Click += new System.EventHandler(this.picSmiley_Click);
            this.picSmiley.MouseEnter += new System.EventHandler(this.picSmiley_MouseEnter);
            this.picSmiley.MouseLeave += new System.EventHandler(this.picSmiley_MouseLeave);
            // 
            // picMore
            // 
            this.picMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.picMore.Image = ((System.Drawing.Image)(resources.GetObject("picMore.Image")));
            this.picMore.ImageLocation = "";
            this.picMore.Location = new System.Drawing.Point(41, 0);
            this.picMore.Name = "picMore";
            this.picMore.Size = new System.Drawing.Size(23, 21);
            this.picMore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMore.TabIndex = 29;
            this.picMore.TabStop = false;
            this.picMore.Tag = "";
            this.picMore.MouseHover += new System.EventHandler(this.picMore_MouseHover);
            // 
            // picVoiceChat
            // 
            this.picVoiceChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picVoiceChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.picVoiceChat.Image = ((System.Drawing.Image)(resources.GetObject("picVoiceChat.Image")));
            this.picVoiceChat.ImageLocation = "";
            this.picVoiceChat.Location = new System.Drawing.Point(64, 0);
            this.picVoiceChat.Name = "picVoiceChat";
            this.picVoiceChat.Size = new System.Drawing.Size(23, 21);
            this.picVoiceChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picVoiceChat.TabIndex = 28;
            this.picVoiceChat.TabStop = false;
            this.picVoiceChat.Tag = "";
            this.picVoiceChat.MouseEnter += new System.EventHandler(this.picVoiceChat_MouseEnter);
            this.picVoiceChat.MouseLeave += new System.EventHandler(this.picVoiceChat_MouseLeave);
            // 
            // picPresetMessage
            // 
            this.picPresetMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPresetMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.picPresetMessage.Image = ((System.Drawing.Image)(resources.GetObject("picPresetMessage.Image")));
            this.picPresetMessage.ImageLocation = "";
            this.picPresetMessage.Location = new System.Drawing.Point(87, 0);
            this.picPresetMessage.Name = "picPresetMessage";
            this.picPresetMessage.Size = new System.Drawing.Size(23, 21);
            this.picPresetMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPresetMessage.TabIndex = 27;
            this.picPresetMessage.TabStop = false;
            this.picPresetMessage.Tag = "";
            this.picPresetMessage.Click += new System.EventHandler(this.picPresetMessage_Click);
            this.picPresetMessage.MouseEnter += new System.EventHandler(this.picPresetMessage_MouseEnter);
            this.picPresetMessage.MouseLeave += new System.EventHandler(this.picPresetMessage_MouseLeave);
            // 
            // picBuzz
            // 
            this.picBuzz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBuzz.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBuzz.Image = ((System.Drawing.Image)(resources.GetObject("picBuzz.Image")));
            this.picBuzz.ImageLocation = "";
            this.picBuzz.Location = new System.Drawing.Point(110, 0);
            this.picBuzz.Name = "picBuzz";
            this.picBuzz.Size = new System.Drawing.Size(23, 21);
            this.picBuzz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBuzz.TabIndex = 26;
            this.picBuzz.TabStop = false;
            this.picBuzz.Tag = "";
            this.picBuzz.Click += new System.EventHandler(this.picBuzz_Click);
            this.picBuzz.MouseEnter += new System.EventHandler(this.picBuzz_MouseEnter);
            this.picBuzz.MouseLeave += new System.EventHandler(this.picBuzz_MouseLeave);
            // 
            // picFileSend
            // 
            this.picFileSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picFileSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.picFileSend.Image = ((System.Drawing.Image)(resources.GetObject("picFileSend.Image")));
            this.picFileSend.ImageLocation = "";
            this.picFileSend.Location = new System.Drawing.Point(133, 0);
            this.picFileSend.Name = "picFileSend";
            this.picFileSend.Size = new System.Drawing.Size(23, 21);
            this.picFileSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFileSend.TabIndex = 25;
            this.picFileSend.TabStop = false;
            this.picFileSend.Tag = "";
            this.picFileSend.MouseEnter += new System.EventHandler(this.picFileSend_MouseEnter);
            this.picFileSend.MouseLeave += new System.EventHandler(this.picFileSend_MouseLeave);
            // 
            // picViewDesktop
            // 
            this.picViewDesktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picViewDesktop.Dock = System.Windows.Forms.DockStyle.Right;
            this.picViewDesktop.Image = ((System.Drawing.Image)(resources.GetObject("picViewDesktop.Image")));
            this.picViewDesktop.ImageLocation = "";
            this.picViewDesktop.Location = new System.Drawing.Point(156, 0);
            this.picViewDesktop.Name = "picViewDesktop";
            this.picViewDesktop.Size = new System.Drawing.Size(23, 21);
            this.picViewDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picViewDesktop.TabIndex = 24;
            this.picViewDesktop.TabStop = false;
            this.picViewDesktop.Tag = "";
            this.picViewDesktop.Click += new System.EventHandler(this.picViewDesktop_Click);
            this.picViewDesktop.MouseEnter += new System.EventHandler(this.picViewDesktop_MouseEnter);
            this.picViewDesktop.MouseLeave += new System.EventHandler(this.picViewDesktop_MouseLeave);
            // 
            // picVideoChat
            // 
            this.picVideoChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picVideoChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.picVideoChat.Image = ((System.Drawing.Image)(resources.GetObject("picVideoChat.Image")));
            this.picVideoChat.ImageLocation = "";
            this.picVideoChat.Location = new System.Drawing.Point(179, 0);
            this.picVideoChat.Name = "picVideoChat";
            this.picVideoChat.Size = new System.Drawing.Size(23, 21);
            this.picVideoChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picVideoChat.TabIndex = 15;
            this.picVideoChat.TabStop = false;
            this.picVideoChat.Tag = "";
            // 
            // UsuarioEscribiendo
            // 
            this.UsuarioEscribiendo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UsuarioEscribiendo.AutoSize = true;
            this.UsuarioEscribiendo.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioEscribiendo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UsuarioEscribiendo.Location = new System.Drawing.Point(3, 2);
            this.UsuarioEscribiendo.Name = "UsuarioEscribiendo";
            this.UsuarioEscribiendo.Size = new System.Drawing.Size(0, 15);
            this.UsuarioEscribiendo.TabIndex = 0;
            // 
            // pnlSendContainer
            // 
            this.pnlSendContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.pnlSendContainer.Controls.Add(this.ButtonScreen);
            this.pnlSendContainer.Controls.Add(this.ButtonBuzz);
            this.pnlSendContainer.Controls.Add(this.ButtonMessage);
            this.pnlSendContainer.Controls.Add(this.ButtonArrow);
            this.pnlSendContainer.Controls.Add(this.ButtonSmile);
            this.pnlSendContainer.Controls.Add(this.ButtonSend);
            this.pnlSendContainer.Controls.Add(this.txtSend);
            this.pnlSendContainer.Controls.Add(this.UserMPContainer);
            this.pnlSendContainer.Controls.Add(this.lblSendRestBottom);
            this.pnlSendContainer.Controls.Add(this.lblSendRestRight);
            this.pnlSendContainer.Controls.Add(this.lblSendRestLeft);
            this.pnlSendContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSendContainer.Location = new System.Drawing.Point(200, 498);
            this.pnlSendContainer.MinimumSize = new System.Drawing.Size(25, 60);
            this.pnlSendContainer.Name = "pnlSendContainer";
            this.pnlSendContainer.Size = new System.Drawing.Size(405, 62);
            this.pnlSendContainer.TabIndex = 30;
            // 
            // ButtonScreen
            // 
            this.ButtonScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.ButtonScreen.BorderRadius = 13;
            this.ButtonScreen.CheckedState.Parent = this.ButtonScreen;
            this.ButtonScreen.CustomImages.Parent = this.ButtonScreen;
            this.ButtonScreen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonScreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonScreen.ForeColor = System.Drawing.Color.White;
            this.ButtonScreen.HoverState.Parent = this.ButtonScreen;
            this.ButtonScreen.Image = global::Chat.Properties.Resources.widescreen_0;
            this.ButtonScreen.Location = new System.Drawing.Point(129, 14);
            this.ButtonScreen.Name = "ButtonScreen";
            this.ButtonScreen.ShadowDecoration.Parent = this.ButtonScreen;
            this.ButtonScreen.Size = new System.Drawing.Size(36, 36);
            this.ButtonScreen.TabIndex = 39;
            this.ButtonScreen.Visible = false;
            this.ButtonScreen.Click += new System.EventHandler(this.picViewDesktop_Click);
            // 
            // ButtonBuzz
            // 
            this.ButtonBuzz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.ButtonBuzz.BorderRadius = 13;
            this.ButtonBuzz.CheckedState.Parent = this.ButtonBuzz;
            this.ButtonBuzz.CustomImages.Parent = this.ButtonBuzz;
            this.ButtonBuzz.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonBuzz.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonBuzz.ForeColor = System.Drawing.Color.White;
            this.ButtonBuzz.HoverState.Parent = this.ButtonBuzz;
            this.ButtonBuzz.Image = global::Chat.Properties.Resources.doorbell_0;
            this.ButtonBuzz.Location = new System.Drawing.Point(87, 14);
            this.ButtonBuzz.Name = "ButtonBuzz";
            this.ButtonBuzz.ShadowDecoration.Parent = this.ButtonBuzz;
            this.ButtonBuzz.Size = new System.Drawing.Size(36, 36);
            this.ButtonBuzz.TabIndex = 38;
            this.ButtonBuzz.Visible = false;
            this.ButtonBuzz.Click += new System.EventHandler(this.picBuzz_Click);
            // 
            // ButtonMessage
            // 
            this.ButtonMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.ButtonMessage.BorderRadius = 13;
            this.ButtonMessage.CheckedState.Parent = this.ButtonMessage;
            this.ButtonMessage.CustomImages.Parent = this.ButtonMessage;
            this.ButtonMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonMessage.ForeColor = System.Drawing.Color.White;
            this.ButtonMessage.HoverState.Parent = this.ButtonMessage;
            this.ButtonMessage.Image = global::Chat.Properties.Resources.chat_bubble_0;
            this.ButtonMessage.Location = new System.Drawing.Point(45, 14);
            this.ButtonMessage.Name = "ButtonMessage";
            this.ButtonMessage.ShadowDecoration.Parent = this.ButtonMessage;
            this.ButtonMessage.Size = new System.Drawing.Size(36, 36);
            this.ButtonMessage.TabIndex = 37;
            this.ButtonMessage.Visible = false;
            this.ButtonMessage.Click += new System.EventHandler(this.picPresetMessage_Click);
            // 
            // ButtonArrow
            // 
            this.ButtonArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.ButtonArrow.BorderRadius = 13;
            this.ButtonArrow.CheckedState.Parent = this.ButtonArrow;
            this.ButtonArrow.CustomImages.Parent = this.ButtonArrow;
            this.ButtonArrow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonArrow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonArrow.ForeColor = System.Drawing.Color.White;
            this.ButtonArrow.HoverState.Parent = this.ButtonArrow;
            this.ButtonArrow.Image = global::Chat.Properties.Resources.forward_0;
            this.ButtonArrow.Location = new System.Drawing.Point(5, 14);
            this.ButtonArrow.Name = "ButtonArrow";
            this.ButtonArrow.ShadowDecoration.Parent = this.ButtonArrow;
            this.ButtonArrow.Size = new System.Drawing.Size(36, 36);
            this.ButtonArrow.TabIndex = 36;
            this.ButtonArrow.Click += new System.EventHandler(this.ButtonArrow_Click);
            // 
            // ButtonSmile
            // 
            this.ButtonSmile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonSmile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonSmile.BorderRadius = 13;
            this.ButtonSmile.CheckedState.Parent = this.ButtonSmile;
            this.ButtonSmile.CustomImages.Parent = this.ButtonSmile;
            this.ButtonSmile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonSmile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonSmile.ForeColor = System.Drawing.Color.White;
            this.ButtonSmile.HoverState.Parent = this.ButtonSmile;
            this.ButtonSmile.Image = global::Chat.Properties.Resources.smile_0;
            this.ButtonSmile.Location = new System.Drawing.Point(312, 16);
            this.ButtonSmile.Name = "ButtonSmile";
            this.ButtonSmile.ShadowDecoration.Parent = this.ButtonSmile;
            this.ButtonSmile.Size = new System.Drawing.Size(30, 30);
            this.ButtonSmile.TabIndex = 35;
            this.ButtonSmile.Click += new System.EventHandler(this.picSmiley_Click);
            // 
            // ButtonSend
            // 
            this.ButtonSend.BorderRadius = 13;
            this.ButtonSend.CheckedState.Parent = this.ButtonSend;
            this.ButtonSend.CustomImages.Parent = this.ButtonSend;
            this.ButtonSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ButtonSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonSend.ForeColor = System.Drawing.Color.White;
            this.ButtonSend.HoverState.Parent = this.ButtonSend;
            this.ButtonSend.Image = global::Chat.Properties.Resources.email_send_0;
            this.ButtonSend.Location = new System.Drawing.Point(358, 14);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.ShadowDecoration.Parent = this.ButtonSend;
            this.ButtonSend.Size = new System.Drawing.Size(36, 36);
            this.ButtonSend.TabIndex = 34;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.txtSend.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.txtSend.BorderRadius = 13;
            this.txtSend.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSend.DefaultText = "";
            this.txtSend.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSend.DisabledState.Parent = this.txtSend;
            this.txtSend.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.txtSend.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSend.FocusedState.Parent = this.txtSend;
            this.txtSend.ForeColor = System.Drawing.Color.White;
            this.txtSend.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSend.HoverState.Parent = this.txtSend;
            this.txtSend.Location = new System.Drawing.Point(45, 14);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.PasswordChar = '\0';
            this.txtSend.PlaceholderText = "";
            this.txtSend.SelectedText = "";
            this.txtSend.ShadowDecoration.Parent = this.txtSend;
            this.txtSend.Size = new System.Drawing.Size(305, 36);
            this.txtSend.TabIndex = 33;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            this.txtSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyUp);
            // 
            // UserMPContainer
            // 
            this.UserMPContainer.Controls.Add(this.label4);
            this.UserMPContainer.Controls.Add(this.UserMP);
            this.UserMPContainer.Controls.Add(this.UserMPDown);
            this.UserMPContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserMPContainer.Location = new System.Drawing.Point(5, 0);
            this.UserMPContainer.Name = "UserMPContainer";
            this.UserMPContainer.Size = new System.Drawing.Size(42, 57);
            this.UserMPContainer.TabIndex = 23;
            this.UserMPContainer.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(37, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(5, 34);
            this.label4.TabIndex = 25;
            this.label4.Visible = false;
            // 
            // UserMP
            // 
            this.UserMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.UserMP.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserMP.Location = new System.Drawing.Point(0, 0);
            this.UserMP.Name = "UserMP";
            this.UserMP.Size = new System.Drawing.Size(37, 34);
            this.UserMP.TabIndex = 22;
            this.UserMP.TabStop = false;
            // 
            // UserMPDown
            // 
            this.UserMPDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.UserMPDown.Controls.Add(this.lblMP);
            this.UserMPDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserMPDown.Location = new System.Drawing.Point(0, 34);
            this.UserMPDown.Name = "UserMPDown";
            this.UserMPDown.Size = new System.Drawing.Size(42, 23);
            this.UserMPDown.TabIndex = 24;
            this.UserMPDown.Click += new System.EventHandler(this.lblMP_Click);
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblMP.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMP.ForeColor = System.Drawing.Color.White;
            this.lblMP.Location = new System.Drawing.Point(1, 2);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(34, 11);
            this.lblMP.TabIndex = 23;
            this.lblMP.Text = "Mensaje";
            // 
            // lblSendRestBottom
            // 
            this.lblSendRestBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.lblSendRestBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSendRestBottom.Location = new System.Drawing.Point(5, 57);
            this.lblSendRestBottom.Name = "lblSendRestBottom";
            this.lblSendRestBottom.Size = new System.Drawing.Size(395, 5);
            this.lblSendRestBottom.TabIndex = 19;
            // 
            // lblSendRestRight
            // 
            this.lblSendRestRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.lblSendRestRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSendRestRight.Location = new System.Drawing.Point(400, 0);
            this.lblSendRestRight.Name = "lblSendRestRight";
            this.lblSendRestRight.Size = new System.Drawing.Size(5, 62);
            this.lblSendRestRight.TabIndex = 20;
            // 
            // lblSendRestLeft
            // 
            this.lblSendRestLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblSendRestLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSendRestLeft.Location = new System.Drawing.Point(0, 0);
            this.lblSendRestLeft.Name = "lblSendRestLeft";
            this.lblSendRestLeft.Size = new System.Drawing.Size(5, 62);
            this.lblSendRestLeft.TabIndex = 21;
            this.lblSendRestLeft.Visible = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.UserSearch);
            this.guna2Panel3.Controls.Add(this.UserList);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 55);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(200, 505);
            this.guna2Panel3.TabIndex = 29;
            // 
            // UserSearch
            // 
            this.UserSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.UserSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserSearch.DefaultCellStyle = dataGridViewCellStyle8;
            this.UserSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.UserSearch.Location = new System.Drawing.Point(47, 131);
            this.UserSearch.MultiSelect = false;
            this.UserSearch.Name = "UserSearch";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.UserSearch.RowHeadersVisible = false;
            this.UserSearch.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserSearch.ShowCellToolTips = false;
            this.UserSearch.Size = new System.Drawing.Size(93, 65);
            this.UserSearch.TabIndex = 33;
            this.UserSearch.Tag = "U";
            this.UserSearch.Visible = false;
            this.UserSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserList_CellDoubleClick);
            this.UserSearch.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_CellMouseClick);
            this.UserSearch.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UserList_CellMouseMove);
            this.UserSearch.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.UserList_CellPainting);
            this.UserSearch.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserList_DragDrop);
            this.UserSearch.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserList_DragEnter);
            this.UserSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyDown);
            this.UserSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyUp);
            // 
            // UserList
            // 
            this.UserList.AllowDrop = true;
            this.UserList.AllowUserToDeleteRows = false;
            this.UserList.AllowUserToResizeColumns = false;
            this.UserList.AllowUserToResizeRows = false;
            this.UserList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UserList.ColumnHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.DefaultCellStyle = dataGridViewCellStyle11;
            this.UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.UserList.Location = new System.Drawing.Point(0, 0);
            this.UserList.MultiSelect = false;
            this.UserList.Name = "UserList";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.UserList.RowHeadersVisible = false;
            this.UserList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserList.ShowCellToolTips = false;
            this.UserList.Size = new System.Drawing.Size(200, 505);
            this.UserList.TabIndex = 32;
            this.UserList.Tag = "U";
            this.UserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserList_CellDoubleClick);
            this.UserList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_CellMouseClick);
            this.UserList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.UserList_CellPainting);
            this.UserList.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserList_DragDrop);
            this.UserList.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserList_DragEnter);
            this.UserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyDown);
            this.UserList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyUp);
            this.UserList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserList_CellMouseMove);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.guna2Panel2.Controls.Add(this.pnlSearchContainer);
            this.guna2Panel2.Controls.Add(this.userPanel);
            this.guna2Panel2.Controls.Add(this.lblMin);
            this.guna2Panel2.Controls.Add(this.lblMax);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(605, 55);
            this.guna2Panel2.TabIndex = 8;
            // 
            // pnlSearchContainer
            // 
            this.pnlSearchContainer.Controls.Add(this.pnlSearch);
            this.pnlSearchContainer.Location = new System.Drawing.Point(0, 5);
            this.pnlSearchContainer.Name = "pnlSearchContainer";
            this.pnlSearchContainer.Size = new System.Drawing.Size(200, 44);
            this.pnlSearchContainer.TabIndex = 37;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlSearch.Controls.Add(this.panelSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.ForeColor = System.Drawing.Color.White;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSearch.Size = new System.Drawing.Size(200, 44);
            this.pnlSearch.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Controls.Add(this.picSearchL);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.ForeColor = System.Drawing.Color.White;
            this.panelSearch.Location = new System.Drawing.Point(10, 8);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(181, 30);
            this.panelSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(34, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(144, 19);
            this.lblSearch.TabIndex = 28;
            this.lblSearch.Tag = "F";
            this.lblSearch.Text = "Buscar usuario";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // picSearchL
            // 
            this.picSearchL.Dock = System.Windows.Forms.DockStyle.Left;
            this.picSearchL.Location = new System.Drawing.Point(0, 0);
            this.picSearchL.Name = "picSearchL";
            this.picSearchL.Size = new System.Drawing.Size(33, 30);
            this.picSearchL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSearchL.TabIndex = 4;
            this.picSearchL.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(35, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearch.Size = new System.Drawing.Size(122, 13);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_LostFocus);
            // 
            // userPanel
            // 
            this.userPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.userPanel.Controls.Add(this.lblMuteUserPanel);
            this.userPanel.Controls.Add(this.lblSettingsUserPanel);
            this.userPanel.Controls.Add(this.lblTicToc);
            this.userPanel.Controls.Add(this.lblWelcome2UserPanel);
            this.userPanel.Controls.Add(this.lblWelcomeUserPanel);
            this.userPanel.ForeColor = System.Drawing.Color.White;
            this.userPanel.Location = new System.Drawing.Point(203, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(405, 55);
            this.userPanel.TabIndex = 36;
            this.userPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseDown);
            this.userPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseMove);
            this.userPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitlebar_MouseUp);
            // 
            // lblMuteUserPanel
            // 
            this.lblMuteUserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMuteUserPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMuteUserPanel.Image = ((System.Drawing.Image)(resources.GetObject("lblMuteUserPanel.Image")));
            this.lblMuteUserPanel.Location = new System.Drawing.Point(339, 23);
            this.lblMuteUserPanel.Name = "lblMuteUserPanel";
            this.lblMuteUserPanel.Size = new System.Drawing.Size(35, 29);
            this.lblMuteUserPanel.TabIndex = 5;
            this.lblMuteUserPanel.Tag = "SS";
            this.lblMuteUserPanel.Click += new System.EventHandler(this.lblMuteUserPanel_Click);
            // 
            // lblSettingsUserPanel
            // 
            this.lblSettingsUserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSettingsUserPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblSettingsUserPanel.Image = ((System.Drawing.Image)(resources.GetObject("lblSettingsUserPanel.Image")));
            this.lblSettingsUserPanel.Location = new System.Drawing.Point(369, 23);
            this.lblSettingsUserPanel.Name = "lblSettingsUserPanel";
            this.lblSettingsUserPanel.Size = new System.Drawing.Size(35, 29);
            this.lblSettingsUserPanel.TabIndex = 4;
            this.lblSettingsUserPanel.Tag = "SS";
            this.lblSettingsUserPanel.Click += new System.EventHandler(this.lblSettingsUserPanel_Click);
            this.lblSettingsUserPanel.MouseLeave += new System.EventHandler(this.lblSettingsUserPanel_MouseLeave);
            this.lblSettingsUserPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSettingsUserPanel_MouseMove);
            // 
            // lblTicToc
            // 
            this.lblTicToc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTicToc.AutoSize = true;
            this.lblTicToc.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.lblTicToc.Location = new System.Drawing.Point(341, 3);
            this.lblTicToc.Name = "lblTicToc";
            this.lblTicToc.Size = new System.Drawing.Size(0, 17);
            this.lblTicToc.TabIndex = 3;
            // 
            // lblWelcome2UserPanel
            // 
            this.lblWelcome2UserPanel.AutoSize = true;
            this.lblWelcome2UserPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 7.75F);
            this.lblWelcome2UserPanel.Location = new System.Drawing.Point(53, 22);
            this.lblWelcome2UserPanel.Name = "lblWelcome2UserPanel";
            this.lblWelcome2UserPanel.Size = new System.Drawing.Size(0, 15);
            this.lblWelcome2UserPanel.TabIndex = 2;
            // 
            // lblWelcomeUserPanel
            // 
            this.lblWelcomeUserPanel.AutoSize = true;
            this.lblWelcomeUserPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUserPanel.Location = new System.Drawing.Point(53, 5);
            this.lblWelcomeUserPanel.Name = "lblWelcomeUserPanel";
            this.lblWelcomeUserPanel.Size = new System.Drawing.Size(0, 17);
            this.lblWelcomeUserPanel.TabIndex = 1;
            // 
            // lblMin
            // 
            this.lblMin.BackColor = System.Drawing.Color.White;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMin.Location = new System.Drawing.Point(400, 13);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(25, 25);
            this.lblMin.TabIndex = 34;
            this.lblMin.Visible = false;
            // 
            // lblMax
            // 
            this.lblMax.BackColor = System.Drawing.Color.White;
            this.lblMax.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMax.Location = new System.Drawing.Point(425, 13);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(25, 25);
            this.lblMax.TabIndex = 33;
            this.lblMax.Tag = "Restore";
            this.lblMax.Visible = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 23;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 23;
            this.guna2Elipse2.TargetControl = this.mnuTray;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 23;
            this.guna2Elipse3.TargetControl = this.UserMenu;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 23;
            this.guna2Elipse4.TargetControl = this.mnuPresetMsg;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.BorderRadius = 23;
            this.guna2Elipse5.TargetControl = this.webChatMenu;
            // 
            // guna2Elipse6
            // 
            this.guna2Elipse6.BorderRadius = 23;
            this.guna2Elipse6.TargetControl = this.mnuStatus;
            // 
            // tmExpandirtxt
            // 
            this.tmExpandirtxt.Interval = 15;
            this.tmExpandirtxt.Tick += new System.EventHandler(this.tmExpandirtxt_Tick);
            // 
            // tmContraertxt
            // 
            this.tmContraertxt.Interval = 15;
            this.tmContraertxt.Tick += new System.EventHandler(this.tmContraertxt_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(880, 560);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pnlTools);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(540, 350);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KosmoChat";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.mnuTray.ResumeLayout(false);
            this.mnuStatus.ResumeLayout(false);
            this.UserMenu.ResumeLayout(false);
            this.mnuPresetMsg.ResumeLayout(false);
            this.webChatMenu.ResumeLayout(false);
            this.pnlTools.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImgstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRetryIcon)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2CircleProgressBar2.ResumeLayout(false);
            this.guna2CircleProgressBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.PanelContainer.ResumeLayout(false);
            this.PanelChat.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.panelTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVoiceChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPresetMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViewDesktop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoChat)).EndInit();
            this.pnlSendContainer.ResumeLayout(false);
            this.UserMPContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserMP)).EndInit();
            this.UserMPDown.ResumeLayout(false);
            this.UserMPDown.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.pnlSearchContainer.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchL)).EndInit();
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public ContextMenuStrip mnuTray;
        public ToolStripMenuItem mnuOcupadoT;
        public ToolStripMenuItem mnuAusenteT;
        public ToolStripMenuItem mnuOnlineT;
        public ToolStripMenuItem mnuExit;
        public ToolStripMenuItem mnuOpen;
        public ToolStripMenuItem mnuSettingsT;

        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Panel panel10;
        public TabPage tabPage1;
        public TabPage tabPage2;
        public ContextMenuStrip mnuStatus;
        public ToolStripMenuItem ActivoMenuItem;
        public ToolTip ToolTip1;
        public ToolStripMenuItem OcupadoMenuItem;
        public ToolStripMenuItem AusenteMenuItem;
        private IContainer components;
        private ToolStripMenuItem mensajePrivadoToolStripMenuItem;
        private ToolStripMenuItem enviarArchivoToolStripMenuItem;
        private ToolStripMenuItem beepToolStripMenuItem;
        private ToolStripMenuItem llamadaToolStripMenuItem;
        private ToolStripMenuItem videollamadaToolStripMenuItem;
        private ToolStripMenuItem escritorioRemotoToolStripMenuItem;
        private ToolStripMenuItem explorarPCToolStripMenuItem;
        private ToolStripMenuItem informaciónToolStripMenuItem;
        private Timer TicToc;
        private Timer timerEscribiendo;
        private Timer TmrAutoCopy;
        public Timer Buzz;
        public ContextMenuStrip mnuPresetMsg;
        public ToolStripMenuItem Hola_PresetMsg;
        public ToolStripMenuItem dime_PresetMsg;
        public ToolStripMenuItem salir_PresetMsg;
        public ToolStripMenuItem ocupado_PresetMsg;
        public ToolStripMenuItem noPuedo_PresetMsg;
        public ListView usersWriting;
        private ColumnHeader columnHeader1;
        private ToolStripMenuItem buzzToolStripMenuItem;
        public ContextMenuStrip webChatMenu;
        public ToolStripMenuItem AbrirMenuItem;
        public ToolStripMenuItem GuardarMenuItem;
        public ToolStripMenuItem SubirMenuItem;
        private ToolStripMenuItem BajarMenuItem;
        private ToolStripMenuItem limpiarChatMenuItem;
        private ToolStripMenuItem HistorialMenuItem;
        private ToolStripMenuItem solicitarHistorialToolStripMenuItem;
        private ToolStripMenuItem sincronizarFechaToolStrip;
        private ToolStripMenuItem UPdate;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem CloseChat;
        private Timer RecargarLista;
        private ToolStripMenuItem chatPrivadoToolStripMenuItem;
        public Panel pnlTools;
        public Label lblClose;
        public PictureBox lblImgstatus;
        public PictureBox PicRetryIcon;
        internal Label lblStatus;
        public Label lblServer;
        private Label lblTittle;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Timer trance;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar2;
        private Timer Hidepanel;
        private NotifyIcon notifyIcon2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel PanelContainer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Panel pnlSearchContainer;
        public Panel pnlSearch;
        private Panel panelSearch;
        public Label lblSearch;
        public PictureBox picSearchL;
        public TextBox txtSearch;
        private Panel userPanel;
        public Label lblMuteUserPanel;
        public Label lblSettingsUserPanel;
        private Label lblTicToc;
        private Label lblWelcome2UserPanel;
        private Label lblWelcomeUserPanel;
        public Label lblMin;
        public Label lblMax;
        public DataGridView UserSearch;
        public DataGridView UserList;
        public WebBrowserEx webChat;
        public Panel pnlSendContainer;
        public Guna.UI2.WinForms.Guna2TextBox txtSend;
        private Panel UserMPContainer;
        public Label label4;
        private PictureBox UserMP;
        private Panel UserMPDown;
        private Label lblMP;
        public Label lblSendRestBottom;
        public Label lblSendRestRight;
        public Label lblSendRestLeft;
        public Guna.UI2.WinForms.Guna2Panel PanelChat;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Button UpdateUser;
        private Guna.UI2.WinForms.Guna2Button songPlayer;
        private Guna.UI2.WinForms.Guna2Button Monitor;
        private Guna.UI2.WinForms.Guna2Button lblInfo;
        private Guna.UI2.WinForms.Guna2Button lblSettings;
        private Guna.UI2.WinForms.Guna2Button logout;
        private Guna.UI2.WinForms.Guna2Button ButtonSend;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse6;
        public Panel pnlStatus;
        private ContextMenuStrip UserMenu;
        private Guna.UI2.WinForms.Guna2Button ButtonSmile;
        private Guna.UI2.WinForms.Guna2Button ButtonArrow;
        private Guna.UI2.WinForms.Guna2Button ButtonScreen;
        private Guna.UI2.WinForms.Guna2Button ButtonBuzz;
        private Guna.UI2.WinForms.Guna2Button ButtonMessage;
        private Timer tmExpandirtxt;
        private Timer tmContraertxt;
        public Panel pnlMenu;
        private Panel panelTools;
        public PictureBox picSmiley;
        public PictureBox picMore;
        public PictureBox picVoiceChat;
        public PictureBox picPresetMessage;
        public PictureBox picBuzz;
        public PictureBox picFileSend;
        public PictureBox picViewDesktop;
        public PictureBox picVideoChat;
        public Label UsuarioEscribiendo;
        private Guna.UI2.WinForms.Guna2Button Jellyfin;
    }
}