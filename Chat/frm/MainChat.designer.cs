using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Trestan;


namespace SkynetChat
{
    partial class MainChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            try
            {
                base.Dispose(disposing);
            }   catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainChat));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.metroPanel2 = new Panel();
            this.NotifyStatus = new MaterialSkin.Controls.MaterialCheckBox();
            this.addLabel1 = new AddLabel(this.components);
            this.yesNoCheckBox1 = new YesNoCheckBox();
            this.MINcount = new MaterialSkin.Controls.MaterialLabel();
            this.ColorINuserList = new MaterialSkin.Controls.MaterialCheckBox();
            this.Colores = new System.Windows.Forms.ComboBox();
            this.TestLabelColor = new System.Windows.Forms.Label();
            this.mlblConfUserColor = new MaterialSkin.Controls.MaterialLabel();
            this.Monitor = new MaterialSkin.Controls.MaterialFlatButton();
            this.generar = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.UserMin = new System.Windows.Forms.NumericUpDown();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Userl = new MaterialSkin.Controls.MaterialLabel();
            this.AchivoRecibido = new MaterialSkin.Controls.MaterialCheckBox();
            this.NuevoUser = new MaterialSkin.Controls.MaterialCheckBox();
            this.DesconectadoUser = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.launchWindows = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.CenterScreen = new MaterialSkin.Controls.MaterialRadioButton();
            this.metroPanel1 = new Panel();
            this.txtYourPassword = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.NickName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PosicionOriginal = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.CanbiarNick = new MaterialSkin.Controls.MaterialFlatButton();
            this.Updatebtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.DirBox = new System.Windows.Forms.TextBox();
            this.AbrirCarpeta = new MaterialSkin.Controls.MaterialCheckBox();
            this.AbrirArchivo = new MaterialSkin.Controls.MaterialCheckBox();
            this.GuardarPosicion = new MaterialSkin.Controls.MaterialRadioButton();
            this.ChangeBox = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.ImageAvatar = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OverlayPanel = new System.Windows.Forms.Panel();
            this.OverlayStatus = new System.Windows.Forms.Label();
            this.OverlayEstado = new System.Windows.Forms.PictureBox();
            this.OverlayUser = new System.Windows.Forms.Label();
            this.OverlayAvatar = new System.Windows.Forms.PictureBox();
            this.OverlayPC = new System.Windows.Forms.Label();
            this.IPOverlay = new System.Windows.Forms.Label();
            this.OverlayIP = new System.Windows.Forms.Label();
            this.PCOverlay = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.UsuarioEscribiendo = new System.Windows.Forms.Label();
            this.txtChat = new Trestan.TRichTextBox();
            this.ChatMenu = new ContextMenu();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarlogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectTodoMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.UserOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.UactivO = new System.Windows.Forms.PictureBox();
            this.UocupadO = new System.Windows.Forms.PictureBox();
            this.UausentE = new System.Windows.Forms.PictureBox();
            this.UserMenu = new ContextMenu();
            this.mensajePrivadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videollamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escritorioRemotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorarPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sMilEs = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.UsuariosEscribiendo = new System.Windows.Forms.ListBox();
            this.so = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Userpanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.UserCount = new System.Windows.Forms.Label();
            this.ReloadList = new System.Windows.Forms.PictureBox();
            this.controlPass = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.Mute = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.timCheck = new System.Windows.Forms.Timer(this.components);
            this.lblLeftChars = new System.Windows.Forms.Label();
            this.AvatarColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NickColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IPColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserList = new System.Windows.Forms.ListView();
            this.MachineColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FormStateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransferenciaBar = new System.Windows.Forms.ProgressBar();
            this.SoundControl = new System.Windows.Forms.Timer(this.components);
            this.tabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMin)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.panel3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.OverlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayAvatar)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UactivO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UocupadO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UausentE)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMilEs)).BeginInit();
            this.Userpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReloadList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.metroPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(406, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Opciones";
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoScroll = true;
            this.metroPanel2.Controls.Add(this.NotifyStatus);
            this.metroPanel2.Controls.Add(this.addLabel1);
            this.metroPanel2.Controls.Add(this.yesNoCheckBox1);
            this.metroPanel2.Controls.Add(this.MINcount);
            this.metroPanel2.Controls.Add(this.ColorINuserList);
            this.metroPanel2.Controls.Add(this.Colores);
            this.metroPanel2.Controls.Add(this.TestLabelColor);
            this.metroPanel2.Controls.Add(this.mlblConfUserColor);
            this.metroPanel2.Controls.Add(this.Monitor);
            this.metroPanel2.Controls.Add(this.generar);
            this.metroPanel2.Controls.Add(this.materialLabel8);
            this.metroPanel2.Controls.Add(this.UserMin);
            this.metroPanel2.Controls.Add(this.panel8);
            this.metroPanel2.Controls.Add(this.AchivoRecibido);
            this.metroPanel2.Controls.Add(this.NuevoUser);
            this.metroPanel2.Controls.Add(this.DesconectadoUser);
            this.metroPanel2.Controls.Add(this.panel2);
            this.metroPanel2.Controls.Add(this.materialLabel1);
            this.metroPanel2.Controls.Add(this.Avatar);
            this.metroPanel2.Controls.Add(this.launchWindows);
            this.metroPanel2.Controls.Add(this.panel3);
            this.metroPanel2.Controls.Add(this.CenterScreen);
            this.metroPanel2.Controls.Add(this.metroPanel1);
            this.metroPanel2.Controls.Add(this.panel4);
            this.metroPanel2.Controls.Add(this.NickName);
            this.metroPanel2.Controls.Add(this.PosicionOriginal);
            this.metroPanel2.Controls.Add(this.materialLabel5);
            this.metroPanel2.Controls.Add(this.panel5);
            this.metroPanel2.Controls.Add(this.CanbiarNick);
            this.metroPanel2.Controls.Add(this.Updatebtn);
            this.metroPanel2.Controls.Add(this.DirBox);
            this.metroPanel2.Controls.Add(this.AbrirCarpeta);
            this.metroPanel2.Controls.Add(this.AbrirArchivo);
            this.metroPanel2.Controls.Add(this.GuardarPosicion);
            this.metroPanel2.Controls.Add(this.ChangeBox);
            this.metroPanel2.Controls.Add(this.materialLabel6);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.Location = new System.Drawing.Point(3, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(400, 292);
            this.metroPanel2.TabIndex = 42;
            // 
            // NotifyStatus
            // 
            this.NotifyStatus.AutoSize = true;
            this.NotifyStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.NotifyStatus.Depth = 0;
            this.NotifyStatus.Font = new System.Drawing.Font("Roboto", 10F);
            this.NotifyStatus.Location = new System.Drawing.Point(4, 586);
            this.NotifyStatus.Margin = new System.Windows.Forms.Padding(0);
            this.NotifyStatus.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NotifyStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotifyStatus.Name = "NotifyStatus";
            this.NotifyStatus.Ripple = true;
            this.NotifyStatus.Size = new System.Drawing.Size(226, 30);
            this.NotifyStatus.TabIndex = 74;
            this.NotifyStatus.Text = "Notificar estado de los usuarios";
            this.NotifyStatus.UseVisualStyleBackColor = true;
            // 
            // addLabel1
            // 
            this.addLabel1.AutoSize = true;
            this.addLabel1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLabel1.Location = new System.Drawing.Point(276, 109);
            this.addLabel1.Name = "addLabel1";
            this.addLabel1.Size = new System.Drawing.Size(77, 16);
            this.addLabel1.TabIndex = 52;
            this.addLabel1.Text = "Error en Chat";
            // 
            // yesNoCheckBox1
            // 
            this.yesNoCheckBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.yesNoCheckBox1.IsChecked = false;
            this.yesNoCheckBox1.Location = new System.Drawing.Point(279, 128);
            this.yesNoCheckBox1.Name = "yesNoCheckBox1";
            this.yesNoCheckBox1.Padding = new System.Windows.Forms.Padding(2);
            this.yesNoCheckBox1.Size = new System.Drawing.Size(84, 25);
            this.yesNoCheckBox1.TabIndex = 73;
            // 
            // MINcount
            // 
            this.MINcount.AutoSize = true;
            this.MINcount.Depth = 0;
            this.MINcount.Font = new System.Drawing.Font("Roboto", 11F);
            this.MINcount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MINcount.Location = new System.Drawing.Point(276, 654);
            this.MINcount.MouseState = MaterialSkin.MouseState.HOVER;
            this.MINcount.Name = "MINcount";
            this.MINcount.Size = new System.Drawing.Size(64, 19);
            this.MINcount.TabIndex = 70;
            this.MINcount.Text = "minutos";
            // 
            // ColorINuserList
            // 
            this.ColorINuserList.AutoSize = true;
            this.ColorINuserList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ColorINuserList.Depth = 0;
            this.ColorINuserList.Font = new System.Drawing.Font("Roboto", 10F);
            this.ColorINuserList.Location = new System.Drawing.Point(4, 156);
            this.ColorINuserList.Margin = new System.Windows.Forms.Padding(0);
            this.ColorINuserList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ColorINuserList.MouseState = MaterialSkin.MouseState.HOVER;
            this.ColorINuserList.Name = "ColorINuserList";
            this.ColorINuserList.Ripple = true;
            this.ColorINuserList.Size = new System.Drawing.Size(251, 30);
            this.ColorINuserList.TabIndex = 69;
            this.ColorINuserList.Text = "Mostrar lista de usuarios en colores";
            this.ColorINuserList.UseVisualStyleBackColor = true;
            this.ColorINuserList.CheckedChanged += new System.EventHandler(this.ColorINuserList_CheckedChanged);
            // 
            // Colores
            // 
            this.Colores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Colores.FormattingEnabled = true;
            this.Colores.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Navy",
            "DarkOrange",
            "Green",
            "Purple",
            "HotPink",
            "DodgerBlue"});
            this.Colores.Location = new System.Drawing.Point(9, 132);
            this.Colores.Name = "Colores";
            this.Colores.Size = new System.Drawing.Size(121, 21);
            this.Colores.TabIndex = 68;
            this.Colores.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Colores_DrawItem);
            this.Colores.SelectedIndexChanged += new System.EventHandler(this.Colores_SelectedIndexChanged);
            // 
            // TestLabelColor
            // 
            this.TestLabelColor.AutoSize = true;
            this.TestLabelColor.BackColor = System.Drawing.Color.White;
            this.TestLabelColor.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestLabelColor.Location = new System.Drawing.Point(75, 111);
            this.TestLabelColor.Name = "TestLabelColor";
            this.TestLabelColor.Size = new System.Drawing.Size(115, 16);
            this.TestLabelColor.TabIndex = 67;
            this.TestLabelColor.Text = "Texto de ejemplo";
            // 
            // mlblConfUserColor
            // 
            this.mlblConfUserColor.AutoSize = true;
            this.mlblConfUserColor.Depth = 0;
            this.mlblConfUserColor.Font = new System.Drawing.Font("Roboto", 11F);
            this.mlblConfUserColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mlblConfUserColor.Location = new System.Drawing.Point(5, 109);
            this.mlblConfUserColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlblConfUserColor.Name = "mlblConfUserColor";
            this.mlblConfUserColor.Size = new System.Drawing.Size(70, 19);
            this.mlblConfUserColor.TabIndex = 66;
            this.mlblConfUserColor.Text = "Colores :";
            // 
            // Monitor
            // 
            this.Monitor.AutoSize = true;
            this.Monitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Monitor.Depth = 0;
            this.Monitor.Icon = null;
            this.Monitor.Location = new System.Drawing.Point(269, 38);
            this.Monitor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Monitor.MouseState = MaterialSkin.MouseState.HOVER;
            this.Monitor.Name = "Monitor";
            this.Monitor.Primary = false;
            this.Monitor.Size = new System.Drawing.Size(108, 36);
            this.Monitor.TabIndex = 58;
            this.Monitor.Text = "Monitorear";
            this.Monitor.UseVisualStyleBackColor = true;
            this.Monitor.Click += new System.EventHandler(this.Monitor_Click);
            // 
            // generar
            // 
            this.generar.AutoSize = true;
            this.generar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generar.Depth = 0;
            this.generar.Icon = null;
            this.generar.Location = new System.Drawing.Point(276, 686);
            this.generar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.generar.MouseState = MaterialSkin.MouseState.HOVER;
            this.generar.Name = "generar";
            this.generar.Primary = false;
            this.generar.Size = new System.Drawing.Size(82, 36);
            this.generar.TabIndex = 57;
            this.generar.Text = "Generar";
            this.generar.UseVisualStyleBackColor = true;
            this.generar.Click += new System.EventHandler(this.generar_Click);
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(59, 654);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(219, 19);
            this.materialLabel8.TabIndex = 55;
            this.materialLabel8.Text = "Recargar lista de usuarios cada";
            // 
            // UserMin
            // 
            this.UserMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UserMin.Location = new System.Drawing.Point(7, 651);
            this.UserMin.Name = "UserMin";
            this.UserMin.Size = new System.Drawing.Size(46, 23);
            this.UserMin.TabIndex = 54;
            this.UserMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UserMin.ValueChanged += new System.EventHandler(this.UserMin_ValueChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.Userl);
            this.panel8.Location = new System.Drawing.Point(1, 619);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(450, 26);
            this.panel8.TabIndex = 53;
            // 
            // Userl
            // 
            this.Userl.AutoSize = true;
            this.Userl.Depth = 0;
            this.Userl.Font = new System.Drawing.Font("Roboto", 11F);
            this.Userl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Userl.Location = new System.Drawing.Point(5, 3);
            this.Userl.MouseState = MaterialSkin.MouseState.HOVER;
            this.Userl.Name = "Userl";
            this.Userl.Size = new System.Drawing.Size(53, 19);
            this.Userl.TabIndex = 26;
            this.Userl.Text = "Varios";
            // 
            // AchivoRecibido
            // 
            this.AchivoRecibido.AutoSize = true;
            this.AchivoRecibido.Cursor = System.Windows.Forms.Cursors.Default;
            this.AchivoRecibido.Depth = 0;
            this.AchivoRecibido.Font = new System.Drawing.Font("Roboto", 10F);
            this.AchivoRecibido.Location = new System.Drawing.Point(4, 556);
            this.AchivoRecibido.Margin = new System.Windows.Forms.Padding(0);
            this.AchivoRecibido.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AchivoRecibido.MouseState = MaterialSkin.MouseState.HOVER;
            this.AchivoRecibido.Name = "AchivoRecibido";
            this.AchivoRecibido.Ripple = true;
            this.AchivoRecibido.Size = new System.Drawing.Size(130, 30);
            this.AchivoRecibido.TabIndex = 52;
            this.AchivoRecibido.Text = "Archivo recibido";
            this.AchivoRecibido.UseVisualStyleBackColor = true;
            // 
            // NuevoUser
            // 
            this.NuevoUser.AutoSize = true;
            this.NuevoUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.NuevoUser.Depth = 0;
            this.NuevoUser.Font = new System.Drawing.Font("Roboto", 10F);
            this.NuevoUser.Location = new System.Drawing.Point(4, 496);
            this.NuevoUser.Margin = new System.Windows.Forms.Padding(0);
            this.NuevoUser.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NuevoUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.NuevoUser.Name = "NuevoUser";
            this.NuevoUser.Ripple = true;
            this.NuevoUser.Size = new System.Drawing.Size(187, 30);
            this.NuevoUser.TabIndex = 50;
            this.NuevoUser.Text = "Nuevo usuario conectado";
            this.NuevoUser.UseVisualStyleBackColor = true;
            // 
            // DesconectadoUser
            // 
            this.DesconectadoUser.AutoSize = true;
            this.DesconectadoUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.DesconectadoUser.Depth = 0;
            this.DesconectadoUser.Font = new System.Drawing.Font("Roboto", 10F);
            this.DesconectadoUser.Location = new System.Drawing.Point(4, 526);
            this.DesconectadoUser.Margin = new System.Windows.Forms.Padding(0);
            this.DesconectadoUser.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DesconectadoUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.DesconectadoUser.Name = "DesconectadoUser";
            this.DesconectadoUser.Ripple = true;
            this.DesconectadoUser.Size = new System.Drawing.Size(168, 30);
            this.DesconectadoUser.TabIndex = 51;
            this.DesconectadoUser.Text = "Usuario desconectado";
            this.DesconectadoUser.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 26);
            this.panel2.TabIndex = 42;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(5, 3);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(192, 19);
            this.materialLabel2.TabIndex = 25;
            this.materialLabel2.Text = "Actualizar datos de usuario";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(1, 694);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(226, 19);
            this.materialLabel1.TabIndex = 28;
            this.materialLabel1.Text = "Contraseña para Control remoto";
            // 
            // Avatar
            // 
            this.Avatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Avatar.Location = new System.Drawing.Point(8, 31);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(75, 75);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 43;
            this.Avatar.TabStop = false;
            this.Avatar.Click += new System.EventHandler(this.Avatar_Click);
            // 
            // launchWindows
            // 
            this.launchWindows.AutoSize = true;
            this.launchWindows.Cursor = System.Windows.Forms.Cursors.Default;
            this.launchWindows.Depth = 0;
            this.launchWindows.Font = new System.Drawing.Font("Roboto", 10F);
            this.launchWindows.Location = new System.Drawing.Point(4, 216);
            this.launchWindows.Margin = new System.Windows.Forms.Padding(0);
            this.launchWindows.MouseLocation = new System.Drawing.Point(-1, -1);
            this.launchWindows.MouseState = MaterialSkin.MouseState.HOVER;
            this.launchWindows.Name = "launchWindows";
            this.launchWindows.Ripple = true;
            this.launchWindows.Size = new System.Drawing.Size(153, 30);
            this.launchWindows.TabIndex = 4;
            this.launchWindows.Text = "Iniciar con Windows";
            this.launchWindows.UseVisualStyleBackColor = true;
            this.launchWindows.CheckedChanged += new System.EventHandler(this.launchWindows_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.materialLabel3);
            this.panel3.Location = new System.Drawing.Point(-2, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 26);
            this.panel3.TabIndex = 45;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(5, 3);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(108, 19);
            this.materialLabel3.TabIndex = 26;
            this.materialLabel3.Text = "Notificaciones";
            // 
            // CenterScreen
            // 
            this.CenterScreen.AutoSize = true;
            this.CenterScreen.Checked = true;
            this.CenterScreen.Depth = 0;
            this.CenterScreen.Font = new System.Drawing.Font("Roboto", 10F);
            this.CenterScreen.Location = new System.Drawing.Point(3, 269);
            this.CenterScreen.Margin = new System.Windows.Forms.Padding(0);
            this.CenterScreen.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CenterScreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.CenterScreen.Name = "CenterScreen";
            this.CenterScreen.Ripple = true;
            this.CenterScreen.Size = new System.Drawing.Size(228, 30);
            this.CenterScreen.TabIndex = 40;
            this.CenterScreen.TabStop = true;
            this.CenterScreen.Text = "Iniciar en el centro de la pantalla";
            this.CenterScreen.UseVisualStyleBackColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.LightGray;
            this.metroPanel1.Controls.Add(this.txtYourPassword);
            this.metroPanel1.Location = new System.Drawing.Point(228, 691);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(45, 27);
            this.metroPanel1.TabIndex = 32;
            // 
            // txtYourPassword
            // 
            this.txtYourPassword.AutoSize = true;
            this.txtYourPassword.Depth = 0;
            this.txtYourPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtYourPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtYourPassword.Location = new System.Drawing.Point(5, 3);
            this.txtYourPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtYourPassword.Name = "txtYourPassword";
            this.txtYourPassword.Size = new System.Drawing.Size(0, 19);
            this.txtYourPassword.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.materialLabel4);
            this.panel4.Location = new System.Drawing.Point(-2, 190);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 26);
            this.panel4.TabIndex = 46;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(5, 3);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(133, 19);
            this.materialLabel4.TabIndex = 34;
            this.materialLabel4.Text = "Opciones de inicio";
            // 
            // NickName
            // 
            this.NickName.Depth = 0;
            this.NickName.Hint = "";
            this.NickName.Location = new System.Drawing.Point(121, 51);
            this.NickName.MaxLength = 15;
            this.NickName.MouseState = MaterialSkin.MouseState.HOVER;
            this.NickName.Name = "NickName";
            this.NickName.PasswordChar = '\0';
            this.NickName.SelectedText = "";
            this.NickName.SelectionLength = 0;
            this.NickName.SelectionStart = 0;
            this.NickName.Size = new System.Drawing.Size(132, 23);
            this.NickName.TabIndex = 24;
            this.NickName.TabStop = false;
            this.NickName.UseSystemPasswordChar = false;
            // 
            // PosicionOriginal
            // 
            this.PosicionOriginal.AutoSize = true;
            this.PosicionOriginal.Checked = true;
            this.PosicionOriginal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PosicionOriginal.Cursor = System.Windows.Forms.Cursors.Default;
            this.PosicionOriginal.Depth = 0;
            this.PosicionOriginal.Font = new System.Drawing.Font("Roboto", 10F);
            this.PosicionOriginal.Location = new System.Drawing.Point(4, 242);
            this.PosicionOriginal.Margin = new System.Windows.Forms.Padding(0);
            this.PosicionOriginal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PosicionOriginal.MouseState = MaterialSkin.MouseState.HOVER;
            this.PosicionOriginal.Name = "PosicionOriginal";
            this.PosicionOriginal.Ripple = true;
            this.PosicionOriginal.Size = new System.Drawing.Size(206, 30);
            this.PosicionOriginal.TabIndex = 41;
            this.PosicionOriginal.Text = "Iniciar en la posición original";
            this.PosicionOriginal.UseVisualStyleBackColor = true;
            this.PosicionOriginal.CheckedChanged += new System.EventHandler(this.PosicionOriginal_CheckedChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(0, 359);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(208, 19);
            this.materialLabel5.TabIndex = 36;
            this.materialLabel5.Text = "Carpeta de archivos recibidos";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.materialLabel7);
            this.panel5.Location = new System.Drawing.Point(-6, 330);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 26);
            this.panel5.TabIndex = 47;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(6, 3);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(134, 19);
            this.materialLabel7.TabIndex = 34;
            this.materialLabel7.Text = "Archivos recibidos";
            // 
            // CanbiarNick
            // 
            this.CanbiarNick.AutoSize = true;
            this.CanbiarNick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CanbiarNick.Depth = 0;
            this.CanbiarNick.Icon = null;
            this.CanbiarNick.Location = new System.Drawing.Point(113, 75);
            this.CanbiarNick.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CanbiarNick.MouseState = MaterialSkin.MouseState.HOVER;
            this.CanbiarNick.Name = "CanbiarNick";
            this.CanbiarNick.Primary = false;
            this.CanbiarNick.Size = new System.Drawing.Size(103, 36);
            this.CanbiarNick.TabIndex = 31;
            this.CanbiarNick.Text = "Actualizar";
            this.CanbiarNick.UseVisualStyleBackColor = true;
            this.CanbiarNick.Click += new System.EventHandler(this.CambiarNick_Click);
            // 
            // Updatebtn
            // 
            this.Updatebtn.AutoSize = true;
            this.Updatebtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Updatebtn.Depth = 0;
            this.Updatebtn.Icon = null;
            this.Updatebtn.Location = new System.Drawing.Point(269, 75);
            this.Updatebtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Updatebtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Primary = false;
            this.Updatebtn.Size = new System.Drawing.Size(73, 36);
            this.Updatebtn.TabIndex = 30;
            this.Updatebtn.Text = "Update";
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // DirBox
            // 
            this.DirBox.Location = new System.Drawing.Point(4, 383);
            this.DirBox.Name = "DirBox";
            this.DirBox.Size = new System.Drawing.Size(235, 20);
            this.DirBox.TabIndex = 37;
            // 
            // AbrirCarpeta
            // 
            this.AbrirCarpeta.AutoSize = true;
            this.AbrirCarpeta.Cursor = System.Windows.Forms.Cursors.Default;
            this.AbrirCarpeta.Depth = 0;
            this.AbrirCarpeta.Font = new System.Drawing.Font("Roboto", 10F);
            this.AbrirCarpeta.Location = new System.Drawing.Point(3, 406);
            this.AbrirCarpeta.Margin = new System.Windows.Forms.Padding(0);
            this.AbrirCarpeta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AbrirCarpeta.MouseState = MaterialSkin.MouseState.HOVER;
            this.AbrirCarpeta.Name = "AbrirCarpeta";
            this.AbrirCarpeta.Ripple = true;
            this.AbrirCarpeta.Size = new System.Drawing.Size(240, 30);
            this.AbrirCarpeta.TabIndex = 48;
            this.AbrirCarpeta.Text = "Abrir carpeta al terminar descarga";
            this.AbrirCarpeta.UseVisualStyleBackColor = true;
            // 
            // AbrirArchivo
            // 
            this.AbrirArchivo.AutoSize = true;
            this.AbrirArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.AbrirArchivo.Depth = 0;
            this.AbrirArchivo.Font = new System.Drawing.Font("Roboto", 10F);
            this.AbrirArchivo.Location = new System.Drawing.Point(3, 436);
            this.AbrirArchivo.Margin = new System.Windows.Forms.Padding(0);
            this.AbrirArchivo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AbrirArchivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.AbrirArchivo.Name = "AbrirArchivo";
            this.AbrirArchivo.Ripple = true;
            this.AbrirArchivo.Size = new System.Drawing.Size(239, 30);
            this.AbrirArchivo.TabIndex = 49;
            this.AbrirArchivo.Text = "Abrir archivo al terminar descarga";
            this.AbrirArchivo.UseVisualStyleBackColor = true;
            // 
            // GuardarPosicion
            // 
            this.GuardarPosicion.AutoSize = true;
            this.GuardarPosicion.Depth = 0;
            this.GuardarPosicion.Font = new System.Drawing.Font("Roboto", 10F);
            this.GuardarPosicion.Location = new System.Drawing.Point(3, 296);
            this.GuardarPosicion.Margin = new System.Windows.Forms.Padding(0);
            this.GuardarPosicion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.GuardarPosicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.GuardarPosicion.Name = "GuardarPosicion";
            this.GuardarPosicion.Ripple = true;
            this.GuardarPosicion.Size = new System.Drawing.Size(205, 30);
            this.GuardarPosicion.TabIndex = 39;
            this.GuardarPosicion.Text = "Guardar posición de ventana";
            this.GuardarPosicion.UseVisualStyleBackColor = true;
            // 
            // ChangeBox
            // 
            this.ChangeBox.AutoSize = true;
            this.ChangeBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangeBox.Depth = 0;
            this.ChangeBox.Icon = null;
            this.ChangeBox.Location = new System.Drawing.Point(245, 377);
            this.ChangeBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChangeBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeBox.Name = "ChangeBox";
            this.ChangeBox.Primary = false;
            this.ChangeBox.Size = new System.Drawing.Size(81, 36);
            this.ChangeBox.TabIndex = 38;
            this.ChangeBox.Text = "Cambiar";
            this.ChangeBox.UseVisualStyleBackColor = true;
            this.ChangeBox.Click += new System.EventHandler(this.ChangeBox_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(117, 28);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(137, 19);
            this.materialLabel6.TabIndex = 44;
            this.materialLabel6.Text = "Nombre de usuario";
            // 
            // ImageAvatar
            // 
            this.ImageAvatar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageAvatar.ImageStream")));
            this.ImageAvatar.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageAvatar.Images.SetKeyName(0, "Avatar.png");
            this.ImageAvatar.Images.SetKeyName(1, "57.png");
            this.ImageAvatar.Images.SetKeyName(2, "60.png");
            this.ImageAvatar.Images.SetKeyName(3, "63.png");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.OverlayPanel);
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.UsuarioEscribiendo);
            this.tabPage1.Controls.Add(this.txtChat);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat principal";
            // 
            // OverlayPanel
            // 
            this.OverlayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.OverlayPanel.Controls.Add(this.OverlayStatus);
            this.OverlayPanel.Controls.Add(this.OverlayEstado);
            this.OverlayPanel.Controls.Add(this.OverlayUser);
            this.OverlayPanel.Controls.Add(this.OverlayAvatar);
            this.OverlayPanel.Controls.Add(this.OverlayPC);
            this.OverlayPanel.Controls.Add(this.IPOverlay);
            this.OverlayPanel.Controls.Add(this.OverlayIP);
            this.OverlayPanel.Controls.Add(this.PCOverlay);
            this.OverlayPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.OverlayPanel.ForeColor = System.Drawing.Color.White;
            this.OverlayPanel.Location = new System.Drawing.Point(200, 6);
            this.OverlayPanel.Name = "OverlayPanel";
            this.OverlayPanel.Size = new System.Drawing.Size(200, 81);
            this.OverlayPanel.TabIndex = 37;
            this.OverlayPanel.Visible = false;
            // 
            // OverlayStatus
            // 
            this.OverlayStatus.AutoSize = true;
            this.OverlayStatus.Location = new System.Drawing.Point(103, 52);
            this.OverlayStatus.Name = "OverlayStatus";
            this.OverlayStatus.Size = new System.Drawing.Size(0, 17);
            this.OverlayStatus.TabIndex = 8;
            // 
            // OverlayEstado
            // 
            this.OverlayEstado.Location = new System.Drawing.Point(75, 53);
            this.OverlayEstado.Name = "OverlayEstado";
            this.OverlayEstado.Size = new System.Drawing.Size(18, 20);
            this.OverlayEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OverlayEstado.TabIndex = 7;
            this.OverlayEstado.TabStop = false;
            // 
            // OverlayUser
            // 
            this.OverlayUser.AutoSize = true;
            this.OverlayUser.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverlayUser.Location = new System.Drawing.Point(75, 4);
            this.OverlayUser.Name = "OverlayUser";
            this.OverlayUser.Size = new System.Drawing.Size(0, 17);
            this.OverlayUser.TabIndex = 4;
            // 
            // OverlayAvatar
            // 
            this.OverlayAvatar.Location = new System.Drawing.Point(4, 5);
            this.OverlayAvatar.Name = "OverlayAvatar";
            this.OverlayAvatar.Size = new System.Drawing.Size(65, 69);
            this.OverlayAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OverlayAvatar.TabIndex = 0;
            this.OverlayAvatar.TabStop = false;
            // 
            // OverlayPC
            // 
            this.OverlayPC.AutoSize = true;
            this.OverlayPC.Location = new System.Drawing.Point(103, 20);
            this.OverlayPC.Name = "OverlayPC";
            this.OverlayPC.Size = new System.Drawing.Size(0, 17);
            this.OverlayPC.TabIndex = 5;
            // 
            // IPOverlay
            // 
            this.IPOverlay.AutoSize = true;
            this.IPOverlay.Location = new System.Drawing.Point(75, 36);
            this.IPOverlay.Name = "IPOverlay";
            this.IPOverlay.Size = new System.Drawing.Size(21, 17);
            this.IPOverlay.TabIndex = 3;
            this.IPOverlay.Text = "IP:";
            // 
            // OverlayIP
            // 
            this.OverlayIP.AutoSize = true;
            this.OverlayIP.Location = new System.Drawing.Point(103, 36);
            this.OverlayIP.Name = "OverlayIP";
            this.OverlayIP.Size = new System.Drawing.Size(0, 17);
            this.OverlayIP.TabIndex = 6;
            // 
            // PCOverlay
            // 
            this.PCOverlay.AutoSize = true;
            this.PCOverlay.Location = new System.Drawing.Point(75, 20);
            this.PCOverlay.Name = "PCOverlay";
            this.PCOverlay.Size = new System.Drawing.Size(26, 17);
            this.PCOverlay.TabIndex = 2;
            this.PCOverlay.Text = "PC:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel7.Location = new System.Drawing.Point(-33, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(34, 325);
            this.panel7.TabIndex = 35;
            // 
            // UsuarioEscribiendo
            // 
            this.UsuarioEscribiendo.AutoSize = true;
            this.UsuarioEscribiendo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.UsuarioEscribiendo.Location = new System.Drawing.Point(6, 310);
            this.UsuarioEscribiendo.Name = "UsuarioEscribiendo";
            this.UsuarioEscribiendo.Size = new System.Drawing.Size(0, 13);
            this.UsuarioEscribiendo.TabIndex = 33;
            // 
            // txtChat
            // 
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChat.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.txtChat.Location = new System.Drawing.Point(3, 3);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(400, 292);
            this.txtChat.TabIndex = 31;
            this.txtChat.Text = "";
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // ChatMenu
            // 
            this.ChatMenu.Name = "ChatMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem1.Text = "Limpiar Chat";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // GuardarlogMenuItem
            // 
            this.GuardarlogMenuItem.Name = "GuardarlogMenuItem";
            this.GuardarlogMenuItem.Size = new System.Drawing.Size(219, 22);
            this.GuardarlogMenuItem.Text = "Guardar en archivo de texto";
            this.GuardarlogMenuItem.Click += new System.EventHandler(this.GuardarLogMenuItem_Click);
            // 
            // SelectTodoMenuItem3
            // 
            this.SelectTodoMenuItem3.Name = "SelectTodoMenuItem3";
            this.SelectTodoMenuItem3.Size = new System.Drawing.Size(219, 22);
            this.SelectTodoMenuItem3.Text = "Seleccionar todo";
            this.SelectTodoMenuItem3.Click += new System.EventHandler(this.SelectTodoMenuItem3_Click);
            // 
            // UserOnlineToolStripMenuItem
            // 
            this.UserOnlineToolStripMenuItem.Name = "UserOnlineToolStripMenuItem";
            this.UserOnlineToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.UserOnlineToolStripMenuItem.Text = "Usuarios Online";
            this.UserOnlineToolStripMenuItem.Click += new System.EventHandler(this.UserOnlineToolStripMenuItem_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Depth = 0;
            this.txtMessage.Hint = "Introduzca el mensage";
            this.txtMessage.Location = new System.Drawing.Point(7, 403);
            this.txtMessage.MaxLength = 140;
            this.txtMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.Size = new System.Drawing.Size(401, 23);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TabStop = false;
            this.txtMessage.UseSystemPasswordChar = false;
            this.txtMessage.Click += new System.EventHandler(this.txtMessage_Click);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(2, 72);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(414, 324);
            this.materialTabControl1.TabIndex = 18;
            // 
            // UactivO
            // 
            this.UactivO.Image = global::SkynetChat.Properties.Resources._57;
            this.UactivO.Location = new System.Drawing.Point(500, 9);
            this.UactivO.Name = "UactivO";
            this.UactivO.Size = new System.Drawing.Size(23, 23);
            this.UactivO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UactivO.TabIndex = 22;
            this.UactivO.TabStop = false;
            this.UactivO.Click += new System.EventHandler(this.UactivO_Click);
            // 
            // UocupadO
            // 
            this.UocupadO.Image = global::SkynetChat.Properties.Resources._60;
            this.UocupadO.Location = new System.Drawing.Point(526, 9);
            this.UocupadO.Name = "UocupadO";
            this.UocupadO.Size = new System.Drawing.Size(23, 23);
            this.UocupadO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UocupadO.TabIndex = 23;
            this.UocupadO.TabStop = false;
            this.UocupadO.Click += new System.EventHandler(this.UocupadO_Click);
            // 
            // UausentE
            // 
            this.UausentE.Image = global::SkynetChat.Properties.Resources._63;
            this.UausentE.Location = new System.Drawing.Point(552, 10);
            this.UausentE.Name = "UausentE";
            this.UausentE.Size = new System.Drawing.Size(23, 23);
            this.UausentE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UausentE.TabIndex = 24;
            this.UausentE.TabStop = false;
            this.UausentE.Click += new System.EventHandler(this.UausentE_Click);
            // 
            // UserMenu
            // 
            this.UserMenu.Name = "metroContextMenu1";
            // 
            // mensajePrivadoToolStripMenuItem
            // 
            this.mensajePrivadoToolStripMenuItem.Image = global::SkynetChat.Properties.Resources._108;
            this.mensajePrivadoToolStripMenuItem.Name = "mensajePrivadoToolStripMenuItem";
            this.mensajePrivadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mensajePrivadoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.mensajePrivadoToolStripMenuItem.Text = "Mensaje privado";
            this.mensajePrivadoToolStripMenuItem.Click += new System.EventHandler(this.mensajePrivadoToolStripMenuItem_Click);
            // 
            // enviarArchivoToolStripMenuItem
            // 
            this.enviarArchivoToolStripMenuItem.Image = global::SkynetChat.Properties.Resources.Transferir1;
            this.enviarArchivoToolStripMenuItem.Name = "enviarArchivoToolStripMenuItem";
            this.enviarArchivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.enviarArchivoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.enviarArchivoToolStripMenuItem.Text = "Enviar archivo";
            this.enviarArchivoToolStripMenuItem.Click += new System.EventHandler(this.enviarArchivoToolStripMenuItem_Click);
            // 
            // beepToolStripMenuItem
            // 
            this.beepToolStripMenuItem.Image = global::SkynetChat.Properties.Resources.beep1;
            this.beepToolStripMenuItem.Name = "beepToolStripMenuItem";
            this.beepToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.beepToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.beepToolStripMenuItem.Text = "Beep";
            this.beepToolStripMenuItem.Click += new System.EventHandler(this.beepToolStripMenuItem_Click);
            // 
            // llamadaToolStripMenuItem
            // 
            this.llamadaToolStripMenuItem.Image = global::SkynetChat.Properties.Resources.phonehandle;
            this.llamadaToolStripMenuItem.Name = "llamadaToolStripMenuItem";
            this.llamadaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.llamadaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.llamadaToolStripMenuItem.Text = "Llamada";
            this.llamadaToolStripMenuItem.Click += new System.EventHandler(this.llamadaToolStripMenuItem_Click);
            // 
            // videollamadaToolStripMenuItem
            // 
            this.videollamadaToolStripMenuItem.Image = global::SkynetChat.Properties.Resources.webcam;
            this.videollamadaToolStripMenuItem.Name = "videollamadaToolStripMenuItem";
            this.videollamadaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.videollamadaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.videollamadaToolStripMenuItem.Text = "Videollamada";
            this.videollamadaToolStripMenuItem.Click += new System.EventHandler(this.videollamadaToolStripMenuItem_Click);
            // 
            // escritorioRemotoToolStripMenuItem
            // 
            this.escritorioRemotoToolStripMenuItem.Image = global::SkynetChat.Properties.Resources._178;
            this.escritorioRemotoToolStripMenuItem.Name = "escritorioRemotoToolStripMenuItem";
            this.escritorioRemotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.escritorioRemotoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.escritorioRemotoToolStripMenuItem.Text = "Compartir escritorio";
            this.escritorioRemotoToolStripMenuItem.Click += new System.EventHandler(this.escritorioRemotoToolStripMenuItem_Click);
            // 
            // explorarPCToolStripMenuItem
            // 
            this.explorarPCToolStripMenuItem.Image = global::SkynetChat.Properties.Resources._156;
            this.explorarPCToolStripMenuItem.Name = "explorarPCToolStripMenuItem";
            this.explorarPCToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.explorarPCToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.explorarPCToolStripMenuItem.Text = "Explorar PC";
            this.explorarPCToolStripMenuItem.Click += new System.EventHandler(this.explorarPCToolStripMenuItem_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.Image = global::SkynetChat.Properties.Resources.info;
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.informaciónToolStripMenuItem.Text = "Información";
            this.informaciónToolStripMenuItem.Click += new System.EventHandler(this.informaciónToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.UactivO);
            this.panel1.Controls.Add(this.UocupadO);
            this.panel1.Controls.Add(this.UausentE);
            this.panel1.Location = new System.Drawing.Point(-1, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 44);
            this.panel1.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.panel6.Location = new System.Drawing.Point(-9, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(609, 10);
            this.panel6.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "SkynetChat";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SkynetChat.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ToolTip1
            // 
            // 
            // sMilEs
            // 
            this.sMilEs.Image = global::SkynetChat.Properties.Resources._01;
            this.sMilEs.Location = new System.Drawing.Point(382, 402);
            this.sMilEs.Name = "sMilEs";
            this.sMilEs.Size = new System.Drawing.Size(20, 20);
            this.sMilEs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sMilEs.TabIndex = 28;
            this.sMilEs.TabStop = false;
            this.sMilEs.Click += new System.EventHandler(this.sMilEs_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SkynetChat";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // UsuariosEscribiendo
            // 
            this.UsuariosEscribiendo.FormattingEnabled = true;
            this.UsuariosEscribiendo.Location = new System.Drawing.Point(592, 395);
            this.UsuariosEscribiendo.Name = "UsuariosEscribiendo";
            this.UsuariosEscribiendo.Size = new System.Drawing.Size(161, 30);
            this.UsuariosEscribiendo.TabIndex = 33;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Userpanel
            // 
            this.Userpanel.BackColor = System.Drawing.Color.White;
            this.Userpanel.Controls.Add(this.label2);
            this.Userpanel.Controls.Add(this.UserCount);
            this.Userpanel.Controls.Add(this.ReloadList);
            this.Userpanel.Location = new System.Drawing.Point(414, 75);
            this.Userpanel.Name = "Userpanel";
            this.Userpanel.Size = new System.Drawing.Size(200, 23);
            this.Userpanel.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Lista de usuarios";
            // 
            // UserCount
            // 
            this.UserCount.AutoSize = true;
            this.UserCount.BackColor = System.Drawing.Color.Transparent;
            this.UserCount.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.UserCount.Location = new System.Drawing.Point(98, 3);
            this.UserCount.Name = "UserCount";
            this.UserCount.Size = new System.Drawing.Size(35, 13);
            this.UserCount.TabIndex = 32;
            this.UserCount.Text = "online";
            // 
            // ReloadList
            // 
            this.ReloadList.BackColor = System.Drawing.Color.Transparent;
            this.ReloadList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadList.Image = global::SkynetChat.Properties.Resources.reload;
            this.ReloadList.Location = new System.Drawing.Point(143, 1);
            this.ReloadList.Name = "ReloadList";
            this.ReloadList.Size = new System.Drawing.Size(18, 18);
            this.ReloadList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ReloadList.TabIndex = 35;
            this.ReloadList.TabStop = false;
            this.ReloadList.Click += new System.EventHandler(this.ReloadList_Click);
            // 
            // controlPass
            // 
            this.controlPass.BackColor = System.Drawing.Color.Transparent;
            this.controlPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlPass.ForeColor = System.Drawing.Color.White;
            this.controlPass.Location = new System.Drawing.Point(469, -1);
            this.controlPass.Name = "controlPass";
            this.controlPass.Size = new System.Drawing.Size(57, 23);
            this.controlPass.TabIndex = 46;
            this.controlPass.Text = "8904";
            this.controlPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClock
            // 
            this.lblClock.BackColor = System.Drawing.Color.Transparent;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.White;
            this.lblClock.Location = new System.Drawing.Point(2, -1);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(57, 23);
            this.lblClock.TabIndex = 45;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClock.Click += new System.EventHandler(this.lblClock_Click);
            // 
            // Mute
            // 
            this.Mute.BackColor = System.Drawing.Color.Transparent;
            this.Mute.Image = global::SkynetChat.Properties.Resources.settings_app_ring_on;
            this.Mute.Location = new System.Drawing.Point(514, 394);
            this.Mute.Name = "Mute";
            this.Mute.Size = new System.Drawing.Size(26, 26);
            this.Mute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mute.TabIndex = 48;
            this.Mute.TabStop = false;
            this.Mute.Click += new System.EventHandler(this.Mute_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.Image = global::SkynetChat.Properties.Resources.tab_bar_button_toolbox_pressed;
            this.Settings.Location = new System.Drawing.Point(545, 390);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(36, 36);
            this.Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Settings.TabIndex = 47;
            this.Settings.TabStop = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.MouseLeave += new System.EventHandler(this.Settings_MouseLeave);
            this.Settings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseMove);
            // 
            // timCheck
            // 
            this.timCheck.Enabled = true;
            this.timCheck.Tick += new System.EventHandler(this.timCheck_Tick);
            // 
            // lblLeftChars
            // 
            this.lblLeftChars.AutoSize = true;
            this.lblLeftChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftChars.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLeftChars.Location = new System.Drawing.Point(414, 409);
            this.lblLeftChars.Name = "lblLeftChars";
            this.lblLeftChars.Size = new System.Drawing.Size(25, 13);
            this.lblLeftChars.TabIndex = 49;
            this.lblLeftChars.Text = "140";
            this.lblLeftChars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvatarColumn
            // 
            this.AvatarColumn.Text = "Avatar";
            this.AvatarColumn.Width = 35;
            // 
            // NickColumn
            // 
            this.NickColumn.Text = "Usuarios";
            this.NickColumn.Width = 95;
            // 
            // StateColumn
            // 
            this.StateColumn.Text = "Estado";
            // 
            // ColorColumn
            // 
            this.ColorColumn.Text = "ID";
            this.ColorColumn.Width = 0;
            // 
            // IPColumn
            // 
            this.IPColumn.Text = "IP";
            this.IPColumn.Width = 0;
            // 
            // UserList
            // 
            this.UserList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.UserList.AllowDrop = true;
            this.UserList.AutoArrange = false;
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AvatarColumn,
            this.NickColumn,
            this.StateColumn,
            this.ColorColumn,
            this.IPColumn,
            this.MachineColumn,
            this.FormStateColumn});
            this.UserList.FullRowSelect = true;
            this.UserList.GridLines = true;
            this.UserList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.UserList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserList.LabelWrap = false;
            this.UserList.LargeImageList = this.ImageAvatar;
            this.UserList.Location = new System.Drawing.Point(416, 75);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(190, 317);
            this.UserList.SmallImageList = this.ImageAvatar;
            this.UserList.TabIndex = 27;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.Details;
            this.UserList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListUser_DrawColumnHeader);
            this.UserList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListUser_DrawItem);
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            this.UserList.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserList_DragDrop);
            this.UserList.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserList_DragEnter);
            this.UserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListUser_KeyDown);
            this.UserList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserList_MouseClick);
            this.UserList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UserList_MouseDoubleClick);
            this.UserList.MouseLeave += new System.EventHandler(this.UserList_MouseLeave);
            this.UserList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListUser_MouseMove);
            // 
            // MachineColumn
            // 
            this.MachineColumn.Text = "MachineColumn";
            this.MachineColumn.Width = 0;
            // 
            // FormStateColumn
            // 
            this.FormStateColumn.Text = "FormStateColumn";
            this.FormStateColumn.Width = 0;
            // 
            // TransferenciaBar
            // 
            this.TransferenciaBar.Location = new System.Drawing.Point(387, 6);
            this.TransferenciaBar.Name = "TransferenciaBar";
            this.TransferenciaBar.Size = new System.Drawing.Size(100, 10);
            this.TransferenciaBar.TabIndex = 51;
            this.TransferenciaBar.Visible = false;
            // 
            // SoundControl
            // 
            this.SoundControl.Tick += new System.EventHandler(this.SoundControl_Tick);
            // 
            // MainChat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(581, 429);
            this.Controls.Add(this.TransferenciaBar);
            this.Controls.Add(this.lblLeftChars);
            this.Controls.Add(this.Mute);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.controlPass);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.Userpanel);
            this.Controls.Add(this.UsuariosEscribiendo);
            this.Controls.Add(this.sMilEs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.UserList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 429);
            this.MinimumSize = new System.Drawing.Size(581, 429);
            this.Name = "MainChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SkynetChat";
            this.Activated += new System.EventHandler(this.MainChat_Activated);
            this.Deactivate += new System.EventHandler(this.MainChat_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMin)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.OverlayPanel.ResumeLayout(false);
            this.OverlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayAvatar)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UactivO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UocupadO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UausentE)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMilEs)).EndInit();
            this.Userpanel.ResumeLayout(false);
            this.Userpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReloadList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabPage tabPage2;
        private TabPage tabPage1;
        private MaterialSingleLineTextField txtMessage;
        private MaterialTabControl materialTabControl1;
        private MaterialLabel materialLabel3;
        private MaterialLabel materialLabel2;
        private PictureBox UactivO;
        private PictureBox UocupadO;
        private PictureBox UausentE;
        private ContextMenu UserMenu;
        private ToolStripMenuItem mensajePrivadoToolStripMenuItem;
        private ToolStripMenuItem enviarArchivoToolStripMenuItem;
        private ToolStripMenuItem beepToolStripMenuItem;
        private ToolStripMenuItem llamadaToolStripMenuItem;
        private ToolStripMenuItem videollamadaToolStripMenuItem;
        private ToolStripMenuItem escritorioRemotoToolStripMenuItem;
        private ToolStripMenuItem explorarPCToolStripMenuItem;
        private Panel panel1;
        private PictureBox pictureBox1;
        private MaterialLabel materialLabel1;
        private MaterialFlatButton Updatebtn;
        private ToolTip ToolTip1;
        private Panel metroPanel1;
        public MaterialLabel txtYourPassword;
        private MaterialLabel materialLabel4;
        private Trestan.TRichTextBox txtChat;
        private PictureBox sMilEs;
        public Label label1;
        private MaterialFlatButton ChangeBox;
        private MaterialLabel materialLabel5;
        public TextBox DirBox;
        public MaterialRadioButton GuardarPosicion;
        public MaterialRadioButton CenterScreen;
        private Panel metroPanel2;
        private Panel panel2;
        private MaterialLabel materialLabel6;
        private Panel panel3;
        private Panel panel5;
        private MaterialLabel materialLabel7;
        private Panel panel4;
        public MaterialCheckBox AbrirArchivo;
        public MaterialCheckBox AbrirCarpeta;
        private System.ComponentModel.BackgroundWorker so;
        private Panel panel7;
        public Timer timer1;
        public MaterialCheckBox NuevoUser;
        public MaterialCheckBox DesconectadoUser;
        public MaterialCheckBox AchivoRecibido;
        public NotifyIcon notifyIcon1;
        private MaterialLabel materialLabel8;
        private NumericUpDown UserMin;
        private Panel panel8;
        private MaterialLabel Userl;
        private ContextMenu ChatMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem GuardarlogMenuItem;
        private ToolStripMenuItem SelectTodoMenuItem3;
        private ToolStripMenuItem UserOnlineToolStripMenuItem;
        private Panel Userpanel;
        private Label label2;
        private PictureBox ReloadList;
        public Label controlPass;
        public Label lblClock;
        private Panel panel6;
        public PictureBox Mute;
        public PictureBox Settings;
        public MaterialSingleLineTextField NickName;
        public ListBox UsuariosEscribiendo;
        public Label UsuarioEscribiendo;
        private MaterialFlatButton generar;
        public Label UserCount;
        public Timer timCheck;
        public Label lblLeftChars;
        public ColumnHeader AvatarColumn;
        private ColumnHeader NickColumn;
        private ColumnHeader StateColumn;
        private ColumnHeader ColorColumn;
        private ColumnHeader IPColumn;
        public ListView UserList;
        private MaterialFlatButton Monitor;
        private Label TestLabelColor;
        private MaterialLabel mlblConfUserColor;
        public ComboBox Colores;
        public MaterialFlatButton CanbiarNick;
        public MaterialCheckBox launchWindows;
        public MaterialCheckBox PosicionOriginal;
        public MaterialCheckBox ColorINuserList;
        private MaterialLabel MINcount;
        public ImageList ImageAvatar;
        public PictureBox Avatar;
        private ColumnHeader FormStateColumn;
        public ProgressBar TransferenciaBar;
        private Label IPOverlay;
        private Label PCOverlay;
        private PictureBox OverlayAvatar;
        private Label OverlayUser;
        private Label OverlayPC;
        private Label OverlayIP;
        private Panel OverlayPanel;
        private ColumnHeader MachineColumn;
        private PictureBox OverlayEstado;
        private Label OverlayStatus;
        private ToolStripMenuItem informaciónToolStripMenuItem;
        private AddLabel addLabel1;
        public MaterialCheckBox NotifyStatus;
        private Timer SoundControl;
        public YesNoCheckBox yesNoCheckBox1;
    }
}