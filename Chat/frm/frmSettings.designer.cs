using System.ComponentModel;
using System.Windows.Forms;
using Chat.Controles;
using Chat.Controles;
using Chat.Controles;
using Chat.Properties;

namespace Chat
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TicToc = new System.Windows.Forms.Timer(this.components);
            this.panelBack = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CleanWhenClose = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.pnlKeyUp = new System.Windows.Forms.Panel();
            this.lblKeyUp = new LabelEx();
            this.labelEx20 = new LabelEx();
            this.labelEx3 = new LabelEx();
            this.UserMin = new HackNUD();
            this.MINcount = new LabelEx();
            this.labelEx13 = new LabelEx();
            this.panelTitulo5 = new System.Windows.Forms.Panel();
            this.guna2Separator5 = new Guna.UI2.WinForms.Guna2Separator();
            this.Varios = new LabelEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NotifyStatus = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.AchivoRecibido = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.DesconectadoUser = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.NuevoUser = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.labelEx11 = new LabelEx();
            this.labelEx12 = new LabelEx();
            this.labelEx9 = new LabelEx();
            this.labelEx10 = new LabelEx();
            this.panelTitulo4 = new System.Windows.Forms.Panel();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.Notificaciones = new LabelEx();
            this.panel7 = new System.Windows.Forms.Panel();
            this.AbrirArchivo = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.AbrirCarpeta = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.openFolder = new System.Windows.Forms.Button();
            this.labelEx7 = new LabelEx();
            this.labelEx8 = new LabelEx();
            this.ChangeBox = new System.Windows.Forms.Button();
            this.DirBox = new System.Windows.Forms.TextBox();
            this.labelEx6 = new LabelEx();
            this.panelTitulo3 = new System.Windows.Forms.Panel();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.Archivosrecibidos = new LabelEx();
            this.panel8 = new System.Windows.Forms.Panel();
            this.GuardarPosicion = new Guna.UI2.WinForms.Guna2RadioButton();
            this.IniciarCentro = new Guna.UI2.WinForms.Guna2RadioButton();
            this.DateTimeZinc = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.PosicionOriginal = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.launchWindows = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.labelEx14 = new LabelEx();
            this.labelEx5 = new LabelEx();
            this.labelEx4 = new LabelEx();
            this.panelTitulo2 = new System.Windows.Forms.Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.OpcionesInicio = new LabelEx();
            this.panel9 = new System.Windows.Forms.Panel();
            this.CustomNick = new Guna.UI2.WinForms.Guna2RadioButton();
            this.NickSystem = new Guna.UI2.WinForms.Guna2RadioButton();
            this.machineN = new Guna.UI2.WinForms.Guna2RadioButton();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackSelector1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackSelector2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackGreenYellow = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator21 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackSlateBlue = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator20 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackAquamarine = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator19 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackMediumSeaGreen = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator18 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackYellow = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator17 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackTurquoise = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator16 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackSkyBlue = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator15 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackRed = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator14 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackPurple = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator13 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackPlum = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator12 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackPink = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator11 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackOrangeRed = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator10 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackLimeGreen = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator9 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackLightSalmon = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator8 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackGold = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator7 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackDeepSkyBlue = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator6 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackDeepPink = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator5 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackDarkOrange = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator4 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackCrimson = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator3 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackBlueViolet = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator2 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackBlue = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator1 = new Guna.UI2.WinForms.Guna2Panel();
            this.PackDefault = new Guna.UI2.WinForms.Guna2CircleButton();
            this.PackSeparator0 = new Guna.UI2.WinForms.Guna2Panel();
            this.NickName = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserName = new LabelEx();
            this.PcName = new LabelEx();
            this.labelEx1 = new LabelEx();
            this.panelTitulo1 = new System.Windows.Forms.Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.Actualizarusuario = new LabelEx();
            this.pnlAceptar = new System.Windows.Forms.Panel();
            this.lblAceptar = new HackLabel(this.components);
            this.pnlCancelar = new System.Windows.Forms.Panel();
            this.lblCancelar = new HackLabel(this.components);
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.pctPhoto = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.guna2Separator6 = new Guna.UI2.WinForms.Guna2Separator();
            this.labelEx15 = new LabelEx();
            this.panelBack.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlKeyUp.SuspendLayout();
            this.panelTitulo5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTitulo4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelTitulo3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelTitulo2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.panelTitulo1.SuspendLayout();
            this.pnlAceptar.SuspendLayout();
            this.pnlCancelar.SuspendLayout();
            this.pnlTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).BeginInit();
            this.panel6.SuspendLayout();
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
            // TicToc
            // 
            this.TicToc.Enabled = true;
            // 
            // panelBack
            // 
            this.panelBack.AutoScroll = true;
            this.panelBack.BackColor = System.Drawing.Color.White;
            this.panelBack.Controls.Add(this.panel1);
            this.panelBack.Controls.Add(this.panelTitulo5);
            this.panelBack.Controls.Add(this.panel2);
            this.panelBack.Controls.Add(this.panelTitulo4);
            this.panelBack.Controls.Add(this.panel7);
            this.panelBack.Controls.Add(this.panelTitulo3);
            this.panelBack.Controls.Add(this.panel8);
            this.panelBack.Controls.Add(this.panelTitulo2);
            this.panelBack.Controls.Add(this.panel9);
            this.panelBack.Controls.Add(this.panelTitulo1);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 25);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(605, 535);
            this.panelBack.TabIndex = 82;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.CleanWhenClose);
            this.panel1.Controls.Add(this.pnlKeyUp);
            this.panel1.Controls.Add(this.labelEx20);
            this.panel1.Controls.Add(this.labelEx3);
            this.panel1.Controls.Add(this.UserMin);
            this.panel1.Controls.Add(this.MINcount);
            this.panel1.Controls.Add(this.labelEx13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 784);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 131);
            this.panel1.TabIndex = 90;
            // 
            // CleanWhenClose
            // 
            this.CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CleanWhenClose.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.CleanWhenClose.CheckedState.InnerColor = System.Drawing.Color.White;
            this.CleanWhenClose.CheckedState.Parent = this.CleanWhenClose;
            this.CleanWhenClose.Location = new System.Drawing.Point(8, 45);
            this.CleanWhenClose.Name = "CleanWhenClose";
            this.CleanWhenClose.ShadowDecoration.Parent = this.CleanWhenClose;
            this.CleanWhenClose.Size = new System.Drawing.Size(35, 20);
            this.CleanWhenClose.TabIndex = 96;
            this.CleanWhenClose.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CleanWhenClose.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CleanWhenClose.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.CleanWhenClose.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.CleanWhenClose.UncheckedState.Parent = this.CleanWhenClose;
            // 
            // pnlKeyUp
            // 
            this.pnlKeyUp.BackColor = System.Drawing.Color.Transparent;
            this.pnlKeyUp.Controls.Add(this.lblKeyUp);
            this.pnlKeyUp.Location = new System.Drawing.Point(190, 74);
            this.pnlKeyUp.Name = "pnlKeyUp";
            this.pnlKeyUp.Size = new System.Drawing.Size(65, 25);
            this.pnlKeyUp.TabIndex = 87;
            this.pnlKeyUp.Click += new System.EventHandler(this.pnlKeyUp_Click);
            // 
            // lblKeyUp
            // 
            this.lblKeyUp.AutoSize = true;
            this.lblKeyUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKeyUp.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKeyUp.ForeColor = System.Drawing.Color.White;
            this.lblKeyUp.Location = new System.Drawing.Point(21, 3);
            this.lblKeyUp.Name = "lblKeyUp";
            this.lblKeyUp.NeedOpacity = true;
            this.lblKeyUp.OpacityColor = System.Drawing.Color.Empty;
            this.lblKeyUp.OrgBackColor = System.Drawing.Color.Empty;
            this.lblKeyUp.Size = new System.Drawing.Size(31, 17);
            this.lblKeyUp.TabIndex = 26;
            this.lblKeyUp.Text = "F10";
            this.lblKeyUp.Click += new System.EventHandler(this.pnlKeyUp_Click);
            // 
            // labelEx20
            // 
            this.labelEx20.AutoSize = true;
            this.labelEx20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx20.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx20.ForeColor = System.Drawing.Color.White;
            this.labelEx20.Location = new System.Drawing.Point(5, 75);
            this.labelEx20.Name = "labelEx20";
            this.labelEx20.NeedOpacity = true;
            this.labelEx20.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx20.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx20.Size = new System.Drawing.Size(184, 20);
            this.labelEx20.TabIndex = 86;
            this.labelEx20.Text = "Traer al frente al presionar";
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx3.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx3.ForeColor = System.Drawing.Color.White;
            this.labelEx3.Location = new System.Drawing.Point(46, 45);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.NeedOpacity = true;
            this.labelEx3.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx3.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx3.Size = new System.Drawing.Size(245, 20);
            this.labelEx3.TabIndex = 85;
            this.labelEx3.Text = "Borrar archivos temporales al cerrar";
            // 
            // UserMin
            // 
            this.UserMin.BackColor = System.Drawing.Color.Transparent;
            this.UserMin.Font = new System.Drawing.Font("Tahoma", 11F);
            this.UserMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.UserMin.Location = new System.Drawing.Point(9, 9);
            this.UserMin.Maximum = ((long)(10));
            this.UserMin.Minimum = ((long)(1));
            this.UserMin.MinimumSize = new System.Drawing.Size(62, 28);
            this.UserMin.Name = "UserMin";
            this.UserMin.Size = new System.Drawing.Size(93, 28);
            this.UserMin.TabIndex = 0;
            this.UserMin.TextAlignment = HackNUD._TextAlignment.Near;
            this.UserMin.Value = ((long)(5));
            this.UserMin.TextChanged += new System.EventHandler(this.UserMin_TextChanged);
            this.UserMin.Click += new System.EventHandler(this.UserMin_Click);
            // 
            // MINcount
            // 
            this.MINcount.AutoSize = true;
            this.MINcount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MINcount.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.MINcount.ForeColor = System.Drawing.Color.White;
            this.MINcount.Location = new System.Drawing.Point(319, 13);
            this.MINcount.Name = "MINcount";
            this.MINcount.NeedOpacity = true;
            this.MINcount.OpacityColor = System.Drawing.Color.Empty;
            this.MINcount.OrgBackColor = System.Drawing.Color.Empty;
            this.MINcount.Size = new System.Drawing.Size(62, 20);
            this.MINcount.TabIndex = 82;
            this.MINcount.Text = "minutos";
            // 
            // labelEx13
            // 
            this.labelEx13.AutoSize = true;
            this.labelEx13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx13.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx13.ForeColor = System.Drawing.Color.White;
            this.labelEx13.Location = new System.Drawing.Point(108, 13);
            this.labelEx13.Name = "labelEx13";
            this.labelEx13.NeedOpacity = true;
            this.labelEx13.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx13.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx13.Size = new System.Drawing.Size(214, 20);
            this.labelEx13.TabIndex = 80;
            this.labelEx13.Text = "Recargar lista de usuarios cada";
            // 
            // panelTitulo5
            // 
            this.panelTitulo5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTitulo5.Controls.Add(this.guna2Separator5);
            this.panelTitulo5.Controls.Add(this.Varios);
            this.panelTitulo5.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTitulo5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.panelTitulo5.Location = new System.Drawing.Point(0, 754);
            this.panelTitulo5.Name = "panelTitulo5";
            this.panelTitulo5.Size = new System.Drawing.Size(588, 30);
            this.panelTitulo5.TabIndex = 89;
            // 
            // guna2Separator5
            // 
            this.guna2Separator5.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator5.Name = "guna2Separator5";
            this.guna2Separator5.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator5.TabIndex = 27;
            // 
            // Varios
            // 
            this.Varios.AutoSize = true;
            this.Varios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Varios.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.Varios.ForeColor = System.Drawing.Color.White;
            this.Varios.Location = new System.Drawing.Point(5, 3);
            this.Varios.Name = "Varios";
            this.Varios.NeedOpacity = true;
            this.Varios.OpacityColor = System.Drawing.Color.Empty;
            this.Varios.OrgBackColor = System.Drawing.Color.Empty;
            this.Varios.Size = new System.Drawing.Size(51, 17);
            this.Varios.TabIndex = 25;
            this.Varios.Text = "Varios";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel2.Controls.Add(this.NotifyStatus);
            this.panel2.Controls.Add(this.AchivoRecibido);
            this.panel2.Controls.Add(this.DesconectadoUser);
            this.panel2.Controls.Add(this.NuevoUser);
            this.panel2.Controls.Add(this.labelEx11);
            this.panel2.Controls.Add(this.labelEx12);
            this.panel2.Controls.Add(this.labelEx9);
            this.panel2.Controls.Add(this.labelEx10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 634);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 120);
            this.panel2.TabIndex = 88;
            // 
            // NotifyStatus
            // 
            this.NotifyStatus.Checked = true;
            this.NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NotifyStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NotifyStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.NotifyStatus.CheckedState.InnerColor = System.Drawing.Color.White;
            this.NotifyStatus.CheckedState.Parent = this.NotifyStatus;
            this.NotifyStatus.Location = new System.Drawing.Point(8, 89);
            this.NotifyStatus.Name = "NotifyStatus";
            this.NotifyStatus.ShadowDecoration.Parent = this.NotifyStatus;
            this.NotifyStatus.Size = new System.Drawing.Size(35, 20);
            this.NotifyStatus.TabIndex = 95;
            this.NotifyStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.NotifyStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.NotifyStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.NotifyStatus.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.NotifyStatus.UncheckedState.Parent = this.NotifyStatus;
            // 
            // AchivoRecibido
            // 
            this.AchivoRecibido.Checked = true;
            this.AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AchivoRecibido.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AchivoRecibido.CheckedState.InnerColor = System.Drawing.Color.White;
            this.AchivoRecibido.CheckedState.Parent = this.AchivoRecibido;
            this.AchivoRecibido.Location = new System.Drawing.Point(8, 63);
            this.AchivoRecibido.Name = "AchivoRecibido";
            this.AchivoRecibido.ShadowDecoration.Parent = this.AchivoRecibido;
            this.AchivoRecibido.Size = new System.Drawing.Size(35, 20);
            this.AchivoRecibido.TabIndex = 94;
            this.AchivoRecibido.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AchivoRecibido.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AchivoRecibido.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AchivoRecibido.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.AchivoRecibido.UncheckedState.Parent = this.AchivoRecibido;
            // 
            // DesconectadoUser
            // 
            this.DesconectadoUser.Checked = true;
            this.DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DesconectadoUser.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.DesconectadoUser.CheckedState.InnerColor = System.Drawing.Color.White;
            this.DesconectadoUser.CheckedState.Parent = this.DesconectadoUser;
            this.DesconectadoUser.Location = new System.Drawing.Point(8, 37);
            this.DesconectadoUser.Name = "DesconectadoUser";
            this.DesconectadoUser.ShadowDecoration.Parent = this.DesconectadoUser;
            this.DesconectadoUser.Size = new System.Drawing.Size(35, 20);
            this.DesconectadoUser.TabIndex = 93;
            this.DesconectadoUser.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DesconectadoUser.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DesconectadoUser.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.DesconectadoUser.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.DesconectadoUser.UncheckedState.Parent = this.DesconectadoUser;
            // 
            // NuevoUser
            // 
            this.NuevoUser.Checked = true;
            this.NuevoUser.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NuevoUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NuevoUser.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.NuevoUser.CheckedState.InnerColor = System.Drawing.Color.White;
            this.NuevoUser.CheckedState.Parent = this.NuevoUser;
            this.NuevoUser.Location = new System.Drawing.Point(8, 11);
            this.NuevoUser.Name = "NuevoUser";
            this.NuevoUser.ShadowDecoration.Parent = this.NuevoUser;
            this.NuevoUser.Size = new System.Drawing.Size(35, 20);
            this.NuevoUser.TabIndex = 92;
            this.NuevoUser.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.NuevoUser.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.NuevoUser.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.NuevoUser.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.NuevoUser.UncheckedState.Parent = this.NuevoUser;
            // 
            // labelEx11
            // 
            this.labelEx11.AutoSize = true;
            this.labelEx11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx11.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx11.ForeColor = System.Drawing.Color.White;
            this.labelEx11.Location = new System.Drawing.Point(46, 89);
            this.labelEx11.Name = "labelEx11";
            this.labelEx11.NeedOpacity = true;
            this.labelEx11.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx11.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx11.Size = new System.Drawing.Size(218, 20);
            this.labelEx11.TabIndex = 88;
            this.labelEx11.Text = "Notificar estado de los usuarios";
            // 
            // labelEx12
            // 
            this.labelEx12.AutoSize = true;
            this.labelEx12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx12.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx12.ForeColor = System.Drawing.Color.White;
            this.labelEx12.Location = new System.Drawing.Point(46, 63);
            this.labelEx12.Name = "labelEx12";
            this.labelEx12.NeedOpacity = true;
            this.labelEx12.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx12.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx12.Size = new System.Drawing.Size(118, 20);
            this.labelEx12.TabIndex = 87;
            this.labelEx12.Text = "Archivo recibido";
            // 
            // labelEx9
            // 
            this.labelEx9.AutoSize = true;
            this.labelEx9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx9.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx9.ForeColor = System.Drawing.Color.White;
            this.labelEx9.Location = new System.Drawing.Point(46, 37);
            this.labelEx9.Name = "labelEx9";
            this.labelEx9.NeedOpacity = true;
            this.labelEx9.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx9.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx9.Size = new System.Drawing.Size(156, 20);
            this.labelEx9.TabIndex = 84;
            this.labelEx9.Text = "Usuario desconectado";
            // 
            // labelEx10
            // 
            this.labelEx10.AutoSize = true;
            this.labelEx10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx10.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx10.ForeColor = System.Drawing.Color.White;
            this.labelEx10.Location = new System.Drawing.Point(46, 11);
            this.labelEx10.Name = "labelEx10";
            this.labelEx10.NeedOpacity = true;
            this.labelEx10.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx10.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx10.Size = new System.Drawing.Size(178, 20);
            this.labelEx10.TabIndex = 83;
            this.labelEx10.Text = "Nuevo usuario conectado";
            // 
            // panelTitulo4
            // 
            this.panelTitulo4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTitulo4.Controls.Add(this.guna2Separator4);
            this.panelTitulo4.Controls.Add(this.Notificaciones);
            this.panelTitulo4.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTitulo4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo4.Location = new System.Drawing.Point(0, 604);
            this.panelTitulo4.Name = "panelTitulo4";
            this.panelTitulo4.Size = new System.Drawing.Size(588, 30);
            this.panelTitulo4.TabIndex = 87;
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator4.TabIndex = 27;
            // 
            // Notificaciones
            // 
            this.Notificaciones.AutoSize = true;
            this.Notificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Notificaciones.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.Notificaciones.ForeColor = System.Drawing.Color.White;
            this.Notificaciones.Location = new System.Drawing.Point(5, 3);
            this.Notificaciones.Name = "Notificaciones";
            this.Notificaciones.NeedOpacity = true;
            this.Notificaciones.OpacityColor = System.Drawing.Color.Empty;
            this.Notificaciones.OrgBackColor = System.Drawing.Color.Empty;
            this.Notificaciones.Size = new System.Drawing.Size(104, 17);
            this.Notificaciones.TabIndex = 25;
            this.Notificaciones.Text = "Notificaciones";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel7.Controls.Add(this.AbrirArchivo);
            this.panel7.Controls.Add(this.AbrirCarpeta);
            this.panel7.Controls.Add(this.openFolder);
            this.panel7.Controls.Add(this.labelEx7);
            this.panel7.Controls.Add(this.labelEx8);
            this.panel7.Controls.Add(this.ChangeBox);
            this.panel7.Controls.Add(this.DirBox);
            this.panel7.Controls.Add(this.labelEx6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 484);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(588, 120);
            this.panel7.TabIndex = 86;
            // 
            // AbrirArchivo
            // 
            this.AbrirArchivo.Checked = true;
            this.AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AbrirArchivo.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AbrirArchivo.CheckedState.InnerColor = System.Drawing.Color.White;
            this.AbrirArchivo.CheckedState.Parent = this.AbrirArchivo;
            this.AbrirArchivo.Location = new System.Drawing.Point(8, 86);
            this.AbrirArchivo.Name = "AbrirArchivo";
            this.AbrirArchivo.ShadowDecoration.Parent = this.AbrirArchivo;
            this.AbrirArchivo.Size = new System.Drawing.Size(35, 20);
            this.AbrirArchivo.TabIndex = 91;
            this.AbrirArchivo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AbrirArchivo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AbrirArchivo.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AbrirArchivo.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.AbrirArchivo.UncheckedState.Parent = this.AbrirArchivo;
            // 
            // AbrirCarpeta
            // 
            this.AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AbrirCarpeta.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AbrirCarpeta.CheckedState.InnerColor = System.Drawing.Color.White;
            this.AbrirCarpeta.CheckedState.Parent = this.AbrirCarpeta;
            this.AbrirCarpeta.Location = new System.Drawing.Point(8, 60);
            this.AbrirCarpeta.Name = "AbrirCarpeta";
            this.AbrirCarpeta.ShadowDecoration.Parent = this.AbrirCarpeta;
            this.AbrirCarpeta.Size = new System.Drawing.Size(35, 20);
            this.AbrirCarpeta.TabIndex = 90;
            this.AbrirCarpeta.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AbrirCarpeta.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AbrirCarpeta.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.AbrirCarpeta.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.AbrirCarpeta.UncheckedState.Parent = this.AbrirCarpeta;
            // 
            // openFolder
            // 
            this.openFolder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openFolder.Location = new System.Drawing.Point(399, 24);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(90, 23);
            this.openFolder.TabIndex = 81;
            this.openFolder.Text = "Abrir carpeta";
            this.openFolder.UseVisualStyleBackColor = true;
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // labelEx7
            // 
            this.labelEx7.AutoSize = true;
            this.labelEx7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx7.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx7.ForeColor = System.Drawing.Color.White;
            this.labelEx7.Location = new System.Drawing.Point(46, 86);
            this.labelEx7.Name = "labelEx7";
            this.labelEx7.NeedOpacity = true;
            this.labelEx7.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx7.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx7.Size = new System.Drawing.Size(234, 20);
            this.labelEx7.TabIndex = 80;
            this.labelEx7.Text = "Abrir archivo al terminar descarga";
            // 
            // labelEx8
            // 
            this.labelEx8.AutoSize = true;
            this.labelEx8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx8.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx8.ForeColor = System.Drawing.Color.White;
            this.labelEx8.Location = new System.Drawing.Point(46, 60);
            this.labelEx8.Name = "labelEx8";
            this.labelEx8.NeedOpacity = true;
            this.labelEx8.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx8.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx8.Size = new System.Drawing.Size(236, 20);
            this.labelEx8.TabIndex = 79;
            this.labelEx8.Text = "Abrir carpeta al terminar descarga";
            // 
            // ChangeBox
            // 
            this.ChangeBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ChangeBox.Location = new System.Drawing.Point(303, 24);
            this.ChangeBox.Name = "ChangeBox";
            this.ChangeBox.Size = new System.Drawing.Size(90, 23);
            this.ChangeBox.TabIndex = 76;
            this.ChangeBox.Text = "Cambiar";
            this.ChangeBox.UseVisualStyleBackColor = true;
            this.ChangeBox.Click += new System.EventHandler(this.ChangeBox_Click);
            // 
            // DirBox
            // 
            this.DirBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DirBox.Location = new System.Drawing.Point(8, 26);
            this.DirBox.Name = "DirBox";
            this.DirBox.Size = new System.Drawing.Size(290, 20);
            this.DirBox.TabIndex = 75;
            // 
            // labelEx6
            // 
            this.labelEx6.AutoSize = true;
            this.labelEx6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx6.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx6.ForeColor = System.Drawing.Color.White;
            this.labelEx6.Location = new System.Drawing.Point(5, 3);
            this.labelEx6.Name = "labelEx6";
            this.labelEx6.NeedOpacity = true;
            this.labelEx6.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx6.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx6.Size = new System.Drawing.Size(205, 20);
            this.labelEx6.TabIndex = 73;
            this.labelEx6.Text = "Carpeta de archivos recibidos";
            // 
            // panelTitulo3
            // 
            this.panelTitulo3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTitulo3.Controls.Add(this.guna2Separator3);
            this.panelTitulo3.Controls.Add(this.Archivosrecibidos);
            this.panelTitulo3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTitulo3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo3.Location = new System.Drawing.Point(0, 454);
            this.panelTitulo3.Name = "panelTitulo3";
            this.panelTitulo3.Size = new System.Drawing.Size(588, 30);
            this.panelTitulo3.TabIndex = 85;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator3.TabIndex = 27;
            // 
            // Archivosrecibidos
            // 
            this.Archivosrecibidos.AutoSize = true;
            this.Archivosrecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Archivosrecibidos.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.Archivosrecibidos.ForeColor = System.Drawing.Color.White;
            this.Archivosrecibidos.Location = new System.Drawing.Point(5, 3);
            this.Archivosrecibidos.Name = "Archivosrecibidos";
            this.Archivosrecibidos.NeedOpacity = true;
            this.Archivosrecibidos.OpacityColor = System.Drawing.Color.Empty;
            this.Archivosrecibidos.OrgBackColor = System.Drawing.Color.Empty;
            this.Archivosrecibidos.Size = new System.Drawing.Size(133, 17);
            this.Archivosrecibidos.TabIndex = 25;
            this.Archivosrecibidos.Text = "Archivos recibidos";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel8.Controls.Add(this.GuardarPosicion);
            this.panel8.Controls.Add(this.IniciarCentro);
            this.panel8.Controls.Add(this.DateTimeZinc);
            this.panel8.Controls.Add(this.PosicionOriginal);
            this.panel8.Controls.Add(this.launchWindows);
            this.panel8.Controls.Add(this.labelEx14);
            this.panel8.Controls.Add(this.labelEx5);
            this.panel8.Controls.Add(this.labelEx4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.panel8.Location = new System.Drawing.Point(0, 318);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(588, 136);
            this.panel8.TabIndex = 84;
            // 
            // GuardarPosicion
            // 
            this.GuardarPosicion.AutoSize = true;
            this.GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.GuardarPosicion.CheckedState.BorderThickness = 0;
            this.GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.GuardarPosicion.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.GuardarPosicion.CheckedState.InnerOffset = -4;
            this.GuardarPosicion.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.GuardarPosicion.ForeColor = System.Drawing.Color.White;
            this.GuardarPosicion.Location = new System.Drawing.Point(8, 82);
            this.GuardarPosicion.Name = "GuardarPosicion";
            this.GuardarPosicion.Size = new System.Drawing.Size(233, 24);
            this.GuardarPosicion.TabIndex = 95;
            this.GuardarPosicion.Text = "Guardar posición de la ventana";
            this.GuardarPosicion.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GuardarPosicion.UncheckedState.BorderThickness = 2;
            this.GuardarPosicion.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.GuardarPosicion.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.GuardarPosicion.UseVisualStyleBackColor = true;
            // 
            // IniciarCentro
            // 
            this.IniciarCentro.AutoSize = true;
            this.IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.IniciarCentro.CheckedState.BorderThickness = 0;
            this.IniciarCentro.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.IniciarCentro.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.IniciarCentro.CheckedState.InnerOffset = -4;
            this.IniciarCentro.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.IniciarCentro.ForeColor = System.Drawing.Color.White;
            this.IniciarCentro.Location = new System.Drawing.Point(8, 60);
            this.IniciarCentro.Name = "IniciarCentro";
            this.IniciarCentro.Size = new System.Drawing.Size(244, 24);
            this.IniciarCentro.TabIndex = 94;
            this.IniciarCentro.Text = "Iniciar en el centro de la pantalla";
            this.IniciarCentro.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.IniciarCentro.UncheckedState.BorderThickness = 2;
            this.IniciarCentro.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.IniciarCentro.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.IniciarCentro.UseVisualStyleBackColor = true;
            // 
            // DateTimeZinc
            // 
            this.DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DateTimeZinc.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.DateTimeZinc.CheckedState.InnerColor = System.Drawing.Color.White;
            this.DateTimeZinc.CheckedState.Parent = this.DateTimeZinc;
            this.DateTimeZinc.Location = new System.Drawing.Point(8, 109);
            this.DateTimeZinc.Name = "DateTimeZinc";
            this.DateTimeZinc.ShadowDecoration.Parent = this.DateTimeZinc;
            this.DateTimeZinc.Size = new System.Drawing.Size(35, 20);
            this.DateTimeZinc.TabIndex = 89;
            this.DateTimeZinc.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DateTimeZinc.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DateTimeZinc.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.DateTimeZinc.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.DateTimeZinc.UncheckedState.Parent = this.DateTimeZinc;
            this.DateTimeZinc.CheckedChanged += new System.EventHandler(this.DateTimeZinc_CheckedChanged);
            // 
            // PosicionOriginal
            // 
            this.PosicionOriginal.Checked = true;
            this.PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PosicionOriginal.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.PosicionOriginal.CheckedState.InnerColor = System.Drawing.Color.White;
            this.PosicionOriginal.CheckedState.Parent = this.PosicionOriginal;
            this.PosicionOriginal.Location = new System.Drawing.Point(8, 34);
            this.PosicionOriginal.Name = "PosicionOriginal";
            this.PosicionOriginal.ShadowDecoration.Parent = this.PosicionOriginal;
            this.PosicionOriginal.Size = new System.Drawing.Size(35, 20);
            this.PosicionOriginal.TabIndex = 88;
            this.PosicionOriginal.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.PosicionOriginal.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.PosicionOriginal.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.PosicionOriginal.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.PosicionOriginal.UncheckedState.Parent = this.PosicionOriginal;
            this.PosicionOriginal.CheckedChanged += new System.EventHandler(this.PosicionOriginal_CheckedChanged);
            // 
            // launchWindows
            // 
            this.launchWindows.Checked = true;
            this.launchWindows.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.launchWindows.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.launchWindows.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.launchWindows.CheckedState.InnerColor = System.Drawing.Color.White;
            this.launchWindows.CheckedState.Parent = this.launchWindows;
            this.launchWindows.Location = new System.Drawing.Point(8, 6);
            this.launchWindows.Name = "launchWindows";
            this.launchWindows.ShadowDecoration.Parent = this.launchWindows;
            this.launchWindows.Size = new System.Drawing.Size(35, 20);
            this.launchWindows.TabIndex = 87;
            this.launchWindows.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.launchWindows.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.launchWindows.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.launchWindows.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.launchWindows.UncheckedState.Parent = this.launchWindows;
            this.launchWindows.CheckedChanged += new System.EventHandler(this.launchWindows_CheckedChanged);
            // 
            // labelEx14
            // 
            this.labelEx14.AutoSize = true;
            this.labelEx14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx14.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx14.ForeColor = System.Drawing.Color.White;
            this.labelEx14.Location = new System.Drawing.Point(46, 109);
            this.labelEx14.Name = "labelEx14";
            this.labelEx14.NeedOpacity = true;
            this.labelEx14.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx14.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx14.Size = new System.Drawing.Size(196, 20);
            this.labelEx14.TabIndex = 78;
            this.labelEx14.Text = "Sincronizar hora con usuario";
            // 
            // labelEx5
            // 
            this.labelEx5.AutoSize = true;
            this.labelEx5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx5.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx5.ForeColor = System.Drawing.Color.White;
            this.labelEx5.Location = new System.Drawing.Point(46, 34);
            this.labelEx5.Name = "labelEx5";
            this.labelEx5.NeedOpacity = true;
            this.labelEx5.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx5.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx5.Size = new System.Drawing.Size(200, 20);
            this.labelEx5.TabIndex = 72;
            this.labelEx5.Text = "Iniciar en la posición original";
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx4.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx4.ForeColor = System.Drawing.Color.White;
            this.labelEx4.Location = new System.Drawing.Point(46, 6);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.NeedOpacity = true;
            this.labelEx4.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx4.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx4.Size = new System.Drawing.Size(142, 20);
            this.labelEx4.TabIndex = 71;
            this.labelEx4.Text = "Iniciar con Windows";
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTitulo2.Controls.Add(this.guna2Separator2);
            this.panelTitulo2.Controls.Add(this.OpcionesInicio);
            this.panelTitulo2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 288);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(588, 30);
            this.panelTitulo2.TabIndex = 83;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator2.TabIndex = 27;
            // 
            // OpcionesInicio
            // 
            this.OpcionesInicio.AutoSize = true;
            this.OpcionesInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpcionesInicio.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.OpcionesInicio.ForeColor = System.Drawing.Color.White;
            this.OpcionesInicio.Location = new System.Drawing.Point(5, 3);
            this.OpcionesInicio.Name = "OpcionesInicio";
            this.OpcionesInicio.NeedOpacity = true;
            this.OpcionesInicio.OpacityColor = System.Drawing.Color.Empty;
            this.OpcionesInicio.OrgBackColor = System.Drawing.Color.Empty;
            this.OpcionesInicio.Size = new System.Drawing.Size(134, 17);
            this.OpcionesInicio.TabIndex = 25;
            this.OpcionesInicio.Text = "Opciones de inicio";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel9.Controls.Add(this.panel6);
            this.panel9.Controls.Add(this.pctPhoto);
            this.panel9.Controls.Add(this.CustomNick);
            this.panel9.Controls.Add(this.NickSystem);
            this.panel9.Controls.Add(this.machineN);
            this.panel9.Controls.Add(this.guna2Panel4);
            this.panel9.Controls.Add(this.guna2Panel1);
            this.panel9.Controls.Add(this.NickName);
            this.panel9.Controls.Add(this.UserName);
            this.panel9.Controls.Add(this.PcName);
            this.panel9.Controls.Add(this.labelEx1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.panel9.Location = new System.Drawing.Point(0, 30);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(588, 258);
            this.panel9.TabIndex = 82;
            // 
            // CustomNick
            // 
            this.CustomNick.AutoSize = true;
            this.CustomNick.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.CustomNick.CheckedState.BorderThickness = 0;
            this.CustomNick.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.CustomNick.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.CustomNick.CheckedState.InnerOffset = -4;
            this.CustomNick.ForeColor = System.Drawing.Color.White;
            this.CustomNick.Location = new System.Drawing.Point(121, 74);
            this.CustomNick.Name = "CustomNick";
            this.CustomNick.Size = new System.Drawing.Size(120, 24);
            this.CustomNick.TabIndex = 93;
            this.CustomNick.Text = "Personalizado";
            this.CustomNick.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CustomNick.UncheckedState.BorderThickness = 2;
            this.CustomNick.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.CustomNick.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.CustomNick.UseVisualStyleBackColor = true;
            this.CustomNick.CheckedChanged += new System.EventHandler(this.CambiarNick);
            // 
            // NickSystem
            // 
            this.NickSystem.AutoSize = true;
            this.NickSystem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.NickSystem.CheckedState.BorderThickness = 0;
            this.NickSystem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.NickSystem.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.NickSystem.CheckedState.InnerOffset = -4;
            this.NickSystem.ForeColor = System.Drawing.Color.White;
            this.NickSystem.Location = new System.Drawing.Point(121, 49);
            this.NickSystem.Name = "NickSystem";
            this.NickSystem.Size = new System.Drawing.Size(157, 24);
            this.NickSystem.TabIndex = 92;
            this.NickSystem.Text = "Nombre de Usuario";
            this.NickSystem.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.NickSystem.UncheckedState.BorderThickness = 2;
            this.NickSystem.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.NickSystem.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.NickSystem.UseVisualStyleBackColor = true;
            this.NickSystem.CheckedChanged += new System.EventHandler(this.CambiarNick);
            // 
            // machineN
            // 
            this.machineN.AutoSize = true;
            this.machineN.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.machineN.CheckedState.BorderThickness = 0;
            this.machineN.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.machineN.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.machineN.CheckedState.InnerOffset = -4;
            this.machineN.ForeColor = System.Drawing.Color.White;
            this.machineN.Location = new System.Drawing.Point(121, 24);
            this.machineN.Name = "machineN";
            this.machineN.Size = new System.Drawing.Size(140, 24);
            this.machineN.TabIndex = 91;
            this.machineN.Text = "Nombre de la PC";
            this.machineN.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.machineN.UncheckedState.BorderThickness = 2;
            this.machineN.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.machineN.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.machineN.UseVisualStyleBackColor = true;
            this.machineN.CheckedChanged += new System.EventHandler(this.CambiarNick);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.PackSelector1);
            this.guna2Panel4.Location = new System.Drawing.Point(0, 150);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(588, 3);
            this.guna2Panel4.TabIndex = 90;
            // 
            // PackSelector1
            // 
            this.PackSelector1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.PackSelector1.Location = new System.Drawing.Point(12, 0);
            this.PackSelector1.Name = "PackSelector1";
            this.PackSelector1.ShadowDecoration.Parent = this.PackSelector1;
            this.PackSelector1.Size = new System.Drawing.Size(38, 3);
            this.PackSelector1.TabIndex = 89;
            this.PackSelector1.Visible = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Panel5);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 157);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(588, 94);
            this.guna2Panel1.TabIndex = 88;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.PackSelector2);
            this.guna2Panel5.Location = new System.Drawing.Point(0, 45);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            this.guna2Panel5.Size = new System.Drawing.Size(588, 3);
            this.guna2Panel5.TabIndex = 91;
            // 
            // PackSelector2
            // 
            this.PackSelector2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.PackSelector2.Location = new System.Drawing.Point(12, 0);
            this.PackSelector2.Name = "PackSelector2";
            this.PackSelector2.ShadowDecoration.Parent = this.PackSelector2;
            this.PackSelector2.Size = new System.Drawing.Size(38, 3);
            this.PackSelector2.TabIndex = 90;
            this.PackSelector2.Visible = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.PackGreenYellow);
            this.guna2Panel3.Controls.Add(this.PackSeparator21);
            this.guna2Panel3.Controls.Add(this.PackSlateBlue);
            this.guna2Panel3.Controls.Add(this.PackSeparator20);
            this.guna2Panel3.Controls.Add(this.PackAquamarine);
            this.guna2Panel3.Controls.Add(this.PackSeparator19);
            this.guna2Panel3.Controls.Add(this.PackMediumSeaGreen);
            this.guna2Panel3.Controls.Add(this.PackSeparator18);
            this.guna2Panel3.Controls.Add(this.PackYellow);
            this.guna2Panel3.Controls.Add(this.PackSeparator17);
            this.guna2Panel3.Controls.Add(this.PackTurquoise);
            this.guna2Panel3.Controls.Add(this.PackSeparator16);
            this.guna2Panel3.Controls.Add(this.PackSkyBlue);
            this.guna2Panel3.Controls.Add(this.PackSeparator15);
            this.guna2Panel3.Controls.Add(this.PackRed);
            this.guna2Panel3.Controls.Add(this.PackSeparator14);
            this.guna2Panel3.Controls.Add(this.PackPurple);
            this.guna2Panel3.Controls.Add(this.PackSeparator13);
            this.guna2Panel3.Controls.Add(this.PackPlum);
            this.guna2Panel3.Controls.Add(this.PackSeparator12);
            this.guna2Panel3.Controls.Add(this.PackPink);
            this.guna2Panel3.Controls.Add(this.PackSeparator11);
            this.guna2Panel3.Location = new System.Drawing.Point(0, 53);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(588, 40);
            this.guna2Panel3.TabIndex = 1;
            // 
            // PackGreenYellow
            // 
            this.PackGreenYellow.CheckedState.Parent = this.PackGreenYellow;
            this.PackGreenYellow.CustomImages.Parent = this.PackGreenYellow;
            this.PackGreenYellow.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackGreenYellow.FillColor = System.Drawing.Color.GreenYellow;
            this.PackGreenYellow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackGreenYellow.ForeColor = System.Drawing.Color.White;
            this.PackGreenYellow.HoverState.Parent = this.PackGreenYellow;
            this.PackGreenYellow.Location = new System.Drawing.Point(532, 0);
            this.PackGreenYellow.Name = "PackGreenYellow";
            this.PackGreenYellow.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackGreenYellow.ShadowDecoration.Parent = this.PackGreenYellow;
            this.PackGreenYellow.Size = new System.Drawing.Size(40, 40);
            this.PackGreenYellow.TabIndex = 112;
            this.PackGreenYellow.Click += new System.EventHandler(this.PackGreenYellow_Click);
            // 
            // PackSeparator21
            // 
            this.PackSeparator21.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator21.Location = new System.Drawing.Point(520, 0);
            this.PackSeparator21.Name = "PackSeparator21";
            this.PackSeparator21.ShadowDecoration.Parent = this.PackSeparator21;
            this.PackSeparator21.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator21.TabIndex = 111;
            // 
            // PackSlateBlue
            // 
            this.PackSlateBlue.CheckedState.Parent = this.PackSlateBlue;
            this.PackSlateBlue.CustomImages.Parent = this.PackSlateBlue;
            this.PackSlateBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSlateBlue.FillColor = System.Drawing.Color.SlateBlue;
            this.PackSlateBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackSlateBlue.ForeColor = System.Drawing.Color.White;
            this.PackSlateBlue.HoverState.Parent = this.PackSlateBlue;
            this.PackSlateBlue.Location = new System.Drawing.Point(480, 0);
            this.PackSlateBlue.Name = "PackSlateBlue";
            this.PackSlateBlue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackSlateBlue.ShadowDecoration.Parent = this.PackSlateBlue;
            this.PackSlateBlue.Size = new System.Drawing.Size(40, 40);
            this.PackSlateBlue.TabIndex = 110;
            this.PackSlateBlue.Click += new System.EventHandler(this.PackSlateBlue_Click);
            // 
            // PackSeparator20
            // 
            this.PackSeparator20.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator20.Location = new System.Drawing.Point(468, 0);
            this.PackSeparator20.Name = "PackSeparator20";
            this.PackSeparator20.ShadowDecoration.Parent = this.PackSeparator20;
            this.PackSeparator20.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator20.TabIndex = 109;
            // 
            // PackAquamarine
            // 
            this.PackAquamarine.CheckedState.Parent = this.PackAquamarine;
            this.PackAquamarine.CustomImages.Parent = this.PackAquamarine;
            this.PackAquamarine.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackAquamarine.FillColor = System.Drawing.Color.Aquamarine;
            this.PackAquamarine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackAquamarine.ForeColor = System.Drawing.Color.White;
            this.PackAquamarine.HoverState.Parent = this.PackAquamarine;
            this.PackAquamarine.Location = new System.Drawing.Point(428, 0);
            this.PackAquamarine.Name = "PackAquamarine";
            this.PackAquamarine.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackAquamarine.ShadowDecoration.Parent = this.PackAquamarine;
            this.PackAquamarine.Size = new System.Drawing.Size(40, 40);
            this.PackAquamarine.TabIndex = 108;
            this.PackAquamarine.Click += new System.EventHandler(this.PackAquamarine_Click);
            // 
            // PackSeparator19
            // 
            this.PackSeparator19.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator19.Location = new System.Drawing.Point(416, 0);
            this.PackSeparator19.Name = "PackSeparator19";
            this.PackSeparator19.ShadowDecoration.Parent = this.PackSeparator19;
            this.PackSeparator19.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator19.TabIndex = 107;
            // 
            // PackMediumSeaGreen
            // 
            this.PackMediumSeaGreen.CheckedState.Parent = this.PackMediumSeaGreen;
            this.PackMediumSeaGreen.CustomImages.Parent = this.PackMediumSeaGreen;
            this.PackMediumSeaGreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackMediumSeaGreen.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.PackMediumSeaGreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackMediumSeaGreen.ForeColor = System.Drawing.Color.White;
            this.PackMediumSeaGreen.HoverState.Parent = this.PackMediumSeaGreen;
            this.PackMediumSeaGreen.Location = new System.Drawing.Point(376, 0);
            this.PackMediumSeaGreen.Name = "PackMediumSeaGreen";
            this.PackMediumSeaGreen.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackMediumSeaGreen.ShadowDecoration.Parent = this.PackMediumSeaGreen;
            this.PackMediumSeaGreen.Size = new System.Drawing.Size(40, 40);
            this.PackMediumSeaGreen.TabIndex = 106;
            this.PackMediumSeaGreen.Click += new System.EventHandler(this.PackMediumSeaGreen_Click);
            // 
            // PackSeparator18
            // 
            this.PackSeparator18.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator18.Location = new System.Drawing.Point(364, 0);
            this.PackSeparator18.Name = "PackSeparator18";
            this.PackSeparator18.ShadowDecoration.Parent = this.PackSeparator18;
            this.PackSeparator18.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator18.TabIndex = 105;
            // 
            // PackYellow
            // 
            this.PackYellow.CheckedState.Parent = this.PackYellow;
            this.PackYellow.CustomImages.Parent = this.PackYellow;
            this.PackYellow.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackYellow.FillColor = System.Drawing.Color.Yellow;
            this.PackYellow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackYellow.ForeColor = System.Drawing.Color.White;
            this.PackYellow.HoverState.Parent = this.PackYellow;
            this.PackYellow.Location = new System.Drawing.Point(324, 0);
            this.PackYellow.Name = "PackYellow";
            this.PackYellow.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackYellow.ShadowDecoration.Parent = this.PackYellow;
            this.PackYellow.Size = new System.Drawing.Size(40, 40);
            this.PackYellow.TabIndex = 104;
            this.PackYellow.Click += new System.EventHandler(this.PackYellow_Click);
            // 
            // PackSeparator17
            // 
            this.PackSeparator17.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator17.Location = new System.Drawing.Point(312, 0);
            this.PackSeparator17.Name = "PackSeparator17";
            this.PackSeparator17.ShadowDecoration.Parent = this.PackSeparator17;
            this.PackSeparator17.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator17.TabIndex = 103;
            // 
            // PackTurquoise
            // 
            this.PackTurquoise.CheckedState.Parent = this.PackTurquoise;
            this.PackTurquoise.CustomImages.Parent = this.PackTurquoise;
            this.PackTurquoise.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackTurquoise.FillColor = System.Drawing.Color.Turquoise;
            this.PackTurquoise.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackTurquoise.ForeColor = System.Drawing.Color.White;
            this.PackTurquoise.HoverState.Parent = this.PackTurquoise;
            this.PackTurquoise.Location = new System.Drawing.Point(272, 0);
            this.PackTurquoise.Name = "PackTurquoise";
            this.PackTurquoise.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackTurquoise.ShadowDecoration.Parent = this.PackTurquoise;
            this.PackTurquoise.Size = new System.Drawing.Size(40, 40);
            this.PackTurquoise.TabIndex = 102;
            this.PackTurquoise.Click += new System.EventHandler(this.PackTurquoise_Click);
            // 
            // PackSeparator16
            // 
            this.PackSeparator16.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator16.Location = new System.Drawing.Point(260, 0);
            this.PackSeparator16.Name = "PackSeparator16";
            this.PackSeparator16.ShadowDecoration.Parent = this.PackSeparator16;
            this.PackSeparator16.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator16.TabIndex = 101;
            // 
            // PackSkyBlue
            // 
            this.PackSkyBlue.CheckedState.Parent = this.PackSkyBlue;
            this.PackSkyBlue.CustomImages.Parent = this.PackSkyBlue;
            this.PackSkyBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSkyBlue.FillColor = System.Drawing.Color.SkyBlue;
            this.PackSkyBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackSkyBlue.ForeColor = System.Drawing.Color.White;
            this.PackSkyBlue.HoverState.Parent = this.PackSkyBlue;
            this.PackSkyBlue.Location = new System.Drawing.Point(220, 0);
            this.PackSkyBlue.Name = "PackSkyBlue";
            this.PackSkyBlue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackSkyBlue.ShadowDecoration.Parent = this.PackSkyBlue;
            this.PackSkyBlue.Size = new System.Drawing.Size(40, 40);
            this.PackSkyBlue.TabIndex = 100;
            this.PackSkyBlue.Click += new System.EventHandler(this.PackSkyBlue_Click);
            // 
            // PackSeparator15
            // 
            this.PackSeparator15.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator15.Location = new System.Drawing.Point(208, 0);
            this.PackSeparator15.Name = "PackSeparator15";
            this.PackSeparator15.ShadowDecoration.Parent = this.PackSeparator15;
            this.PackSeparator15.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator15.TabIndex = 99;
            // 
            // PackRed
            // 
            this.PackRed.CheckedState.Parent = this.PackRed;
            this.PackRed.CustomImages.Parent = this.PackRed;
            this.PackRed.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackRed.FillColor = System.Drawing.Color.Red;
            this.PackRed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackRed.ForeColor = System.Drawing.Color.White;
            this.PackRed.HoverState.Parent = this.PackRed;
            this.PackRed.Location = new System.Drawing.Point(168, 0);
            this.PackRed.Name = "PackRed";
            this.PackRed.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackRed.ShadowDecoration.Parent = this.PackRed;
            this.PackRed.Size = new System.Drawing.Size(40, 40);
            this.PackRed.TabIndex = 98;
            this.PackRed.Click += new System.EventHandler(this.PackRed_Click);
            // 
            // PackSeparator14
            // 
            this.PackSeparator14.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator14.Location = new System.Drawing.Point(156, 0);
            this.PackSeparator14.Name = "PackSeparator14";
            this.PackSeparator14.ShadowDecoration.Parent = this.PackSeparator14;
            this.PackSeparator14.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator14.TabIndex = 97;
            // 
            // PackPurple
            // 
            this.PackPurple.CheckedState.Parent = this.PackPurple;
            this.PackPurple.CustomImages.Parent = this.PackPurple;
            this.PackPurple.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackPurple.FillColor = System.Drawing.Color.Purple;
            this.PackPurple.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackPurple.ForeColor = System.Drawing.Color.White;
            this.PackPurple.HoverState.Parent = this.PackPurple;
            this.PackPurple.Location = new System.Drawing.Point(116, 0);
            this.PackPurple.Name = "PackPurple";
            this.PackPurple.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackPurple.ShadowDecoration.Parent = this.PackPurple;
            this.PackPurple.Size = new System.Drawing.Size(40, 40);
            this.PackPurple.TabIndex = 96;
            this.PackPurple.Click += new System.EventHandler(this.PackPurple_Click);
            // 
            // PackSeparator13
            // 
            this.PackSeparator13.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator13.Location = new System.Drawing.Point(104, 0);
            this.PackSeparator13.Name = "PackSeparator13";
            this.PackSeparator13.ShadowDecoration.Parent = this.PackSeparator13;
            this.PackSeparator13.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator13.TabIndex = 95;
            // 
            // PackPlum
            // 
            this.PackPlum.CheckedState.Parent = this.PackPlum;
            this.PackPlum.CustomImages.Parent = this.PackPlum;
            this.PackPlum.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackPlum.FillColor = System.Drawing.Color.Plum;
            this.PackPlum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackPlum.ForeColor = System.Drawing.Color.White;
            this.PackPlum.HoverState.Parent = this.PackPlum;
            this.PackPlum.Location = new System.Drawing.Point(64, 0);
            this.PackPlum.Name = "PackPlum";
            this.PackPlum.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackPlum.ShadowDecoration.Parent = this.PackPlum;
            this.PackPlum.Size = new System.Drawing.Size(40, 40);
            this.PackPlum.TabIndex = 94;
            this.PackPlum.Click += new System.EventHandler(this.PackPlum_Click);
            // 
            // PackSeparator12
            // 
            this.PackSeparator12.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator12.Location = new System.Drawing.Point(52, 0);
            this.PackSeparator12.Name = "PackSeparator12";
            this.PackSeparator12.ShadowDecoration.Parent = this.PackSeparator12;
            this.PackSeparator12.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator12.TabIndex = 93;
            // 
            // PackPink
            // 
            this.PackPink.CheckedState.Parent = this.PackPink;
            this.PackPink.CustomImages.Parent = this.PackPink;
            this.PackPink.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackPink.FillColor = System.Drawing.Color.Pink;
            this.PackPink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackPink.ForeColor = System.Drawing.Color.White;
            this.PackPink.HoverState.Parent = this.PackPink;
            this.PackPink.Location = new System.Drawing.Point(12, 0);
            this.PackPink.Name = "PackPink";
            this.PackPink.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackPink.ShadowDecoration.Parent = this.PackPink;
            this.PackPink.Size = new System.Drawing.Size(40, 40);
            this.PackPink.TabIndex = 92;
            this.PackPink.Click += new System.EventHandler(this.PackPink_Click);
            // 
            // PackSeparator11
            // 
            this.PackSeparator11.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator11.Location = new System.Drawing.Point(0, 0);
            this.PackSeparator11.Name = "PackSeparator11";
            this.PackSeparator11.ShadowDecoration.Parent = this.PackSeparator11;
            this.PackSeparator11.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator11.TabIndex = 91;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.PackOrangeRed);
            this.guna2Panel2.Controls.Add(this.PackSeparator10);
            this.guna2Panel2.Controls.Add(this.PackLimeGreen);
            this.guna2Panel2.Controls.Add(this.PackSeparator9);
            this.guna2Panel2.Controls.Add(this.PackLightSalmon);
            this.guna2Panel2.Controls.Add(this.PackSeparator8);
            this.guna2Panel2.Controls.Add(this.PackGold);
            this.guna2Panel2.Controls.Add(this.PackSeparator7);
            this.guna2Panel2.Controls.Add(this.PackDeepSkyBlue);
            this.guna2Panel2.Controls.Add(this.PackSeparator6);
            this.guna2Panel2.Controls.Add(this.PackDeepPink);
            this.guna2Panel2.Controls.Add(this.PackSeparator5);
            this.guna2Panel2.Controls.Add(this.PackDarkOrange);
            this.guna2Panel2.Controls.Add(this.PackSeparator4);
            this.guna2Panel2.Controls.Add(this.PackCrimson);
            this.guna2Panel2.Controls.Add(this.PackSeparator3);
            this.guna2Panel2.Controls.Add(this.PackBlueViolet);
            this.guna2Panel2.Controls.Add(this.PackSeparator2);
            this.guna2Panel2.Controls.Add(this.PackBlue);
            this.guna2Panel2.Controls.Add(this.PackSeparator1);
            this.guna2Panel2.Controls.Add(this.PackDefault);
            this.guna2Panel2.Controls.Add(this.PackSeparator0);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(588, 40);
            this.guna2Panel2.TabIndex = 0;
            // 
            // PackOrangeRed
            // 
            this.PackOrangeRed.CheckedState.Parent = this.PackOrangeRed;
            this.PackOrangeRed.CustomImages.Parent = this.PackOrangeRed;
            this.PackOrangeRed.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackOrangeRed.FillColor = System.Drawing.Color.OrangeRed;
            this.PackOrangeRed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackOrangeRed.ForeColor = System.Drawing.Color.White;
            this.PackOrangeRed.HoverState.Parent = this.PackOrangeRed;
            this.PackOrangeRed.Location = new System.Drawing.Point(532, 0);
            this.PackOrangeRed.Name = "PackOrangeRed";
            this.PackOrangeRed.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackOrangeRed.ShadowDecoration.Parent = this.PackOrangeRed;
            this.PackOrangeRed.Size = new System.Drawing.Size(40, 40);
            this.PackOrangeRed.TabIndex = 112;
            this.PackOrangeRed.Click += new System.EventHandler(this.PackOrangeRed_Click);
            // 
            // PackSeparator10
            // 
            this.PackSeparator10.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator10.Location = new System.Drawing.Point(520, 0);
            this.PackSeparator10.Name = "PackSeparator10";
            this.PackSeparator10.ShadowDecoration.Parent = this.PackSeparator10;
            this.PackSeparator10.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator10.TabIndex = 111;
            // 
            // PackLimeGreen
            // 
            this.PackLimeGreen.CheckedState.Parent = this.PackLimeGreen;
            this.PackLimeGreen.CustomImages.Parent = this.PackLimeGreen;
            this.PackLimeGreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackLimeGreen.FillColor = System.Drawing.Color.LimeGreen;
            this.PackLimeGreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackLimeGreen.ForeColor = System.Drawing.Color.White;
            this.PackLimeGreen.HoverState.Parent = this.PackLimeGreen;
            this.PackLimeGreen.Location = new System.Drawing.Point(480, 0);
            this.PackLimeGreen.Name = "PackLimeGreen";
            this.PackLimeGreen.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackLimeGreen.ShadowDecoration.Parent = this.PackLimeGreen;
            this.PackLimeGreen.Size = new System.Drawing.Size(40, 40);
            this.PackLimeGreen.TabIndex = 110;
            this.PackLimeGreen.Click += new System.EventHandler(this.PackLimeGreen_Click);
            // 
            // PackSeparator9
            // 
            this.PackSeparator9.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator9.Location = new System.Drawing.Point(468, 0);
            this.PackSeparator9.Name = "PackSeparator9";
            this.PackSeparator9.ShadowDecoration.Parent = this.PackSeparator9;
            this.PackSeparator9.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator9.TabIndex = 109;
            // 
            // PackLightSalmon
            // 
            this.PackLightSalmon.CheckedState.Parent = this.PackLightSalmon;
            this.PackLightSalmon.CustomImages.Parent = this.PackLightSalmon;
            this.PackLightSalmon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackLightSalmon.FillColor = System.Drawing.Color.LightSalmon;
            this.PackLightSalmon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackLightSalmon.ForeColor = System.Drawing.Color.White;
            this.PackLightSalmon.HoverState.Parent = this.PackLightSalmon;
            this.PackLightSalmon.Location = new System.Drawing.Point(428, 0);
            this.PackLightSalmon.Name = "PackLightSalmon";
            this.PackLightSalmon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackLightSalmon.ShadowDecoration.Parent = this.PackLightSalmon;
            this.PackLightSalmon.Size = new System.Drawing.Size(40, 40);
            this.PackLightSalmon.TabIndex = 108;
            this.PackLightSalmon.Click += new System.EventHandler(this.PackLightSalmon_Click);
            // 
            // PackSeparator8
            // 
            this.PackSeparator8.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator8.Location = new System.Drawing.Point(416, 0);
            this.PackSeparator8.Name = "PackSeparator8";
            this.PackSeparator8.ShadowDecoration.Parent = this.PackSeparator8;
            this.PackSeparator8.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator8.TabIndex = 107;
            // 
            // PackGold
            // 
            this.PackGold.CheckedState.Parent = this.PackGold;
            this.PackGold.CustomImages.Parent = this.PackGold;
            this.PackGold.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackGold.FillColor = System.Drawing.Color.Gold;
            this.PackGold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackGold.ForeColor = System.Drawing.Color.White;
            this.PackGold.HoverState.Parent = this.PackGold;
            this.PackGold.Location = new System.Drawing.Point(376, 0);
            this.PackGold.Name = "PackGold";
            this.PackGold.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackGold.ShadowDecoration.Parent = this.PackGold;
            this.PackGold.Size = new System.Drawing.Size(40, 40);
            this.PackGold.TabIndex = 106;
            this.PackGold.Click += new System.EventHandler(this.PackGold_Click);
            // 
            // PackSeparator7
            // 
            this.PackSeparator7.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator7.Location = new System.Drawing.Point(364, 0);
            this.PackSeparator7.Name = "PackSeparator7";
            this.PackSeparator7.ShadowDecoration.Parent = this.PackSeparator7;
            this.PackSeparator7.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator7.TabIndex = 105;
            // 
            // PackDeepSkyBlue
            // 
            this.PackDeepSkyBlue.CheckedState.Parent = this.PackDeepSkyBlue;
            this.PackDeepSkyBlue.CustomImages.Parent = this.PackDeepSkyBlue;
            this.PackDeepSkyBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackDeepSkyBlue.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.PackDeepSkyBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackDeepSkyBlue.ForeColor = System.Drawing.Color.White;
            this.PackDeepSkyBlue.HoverState.Parent = this.PackDeepSkyBlue;
            this.PackDeepSkyBlue.Location = new System.Drawing.Point(324, 0);
            this.PackDeepSkyBlue.Name = "PackDeepSkyBlue";
            this.PackDeepSkyBlue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackDeepSkyBlue.ShadowDecoration.Parent = this.PackDeepSkyBlue;
            this.PackDeepSkyBlue.Size = new System.Drawing.Size(40, 40);
            this.PackDeepSkyBlue.TabIndex = 104;
            this.PackDeepSkyBlue.Click += new System.EventHandler(this.PackDeepSkyBlue_Click);
            // 
            // PackSeparator6
            // 
            this.PackSeparator6.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator6.Location = new System.Drawing.Point(312, 0);
            this.PackSeparator6.Name = "PackSeparator6";
            this.PackSeparator6.ShadowDecoration.Parent = this.PackSeparator6;
            this.PackSeparator6.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator6.TabIndex = 103;
            // 
            // PackDeepPink
            // 
            this.PackDeepPink.CheckedState.Parent = this.PackDeepPink;
            this.PackDeepPink.CustomImages.Parent = this.PackDeepPink;
            this.PackDeepPink.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackDeepPink.FillColor = System.Drawing.Color.DeepPink;
            this.PackDeepPink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackDeepPink.ForeColor = System.Drawing.Color.White;
            this.PackDeepPink.HoverState.Parent = this.PackDeepPink;
            this.PackDeepPink.Location = new System.Drawing.Point(272, 0);
            this.PackDeepPink.Name = "PackDeepPink";
            this.PackDeepPink.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackDeepPink.ShadowDecoration.Parent = this.PackDeepPink;
            this.PackDeepPink.Size = new System.Drawing.Size(40, 40);
            this.PackDeepPink.TabIndex = 102;
            this.PackDeepPink.Click += new System.EventHandler(this.PackDeepPink_Click);
            // 
            // PackSeparator5
            // 
            this.PackSeparator5.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator5.Location = new System.Drawing.Point(260, 0);
            this.PackSeparator5.Name = "PackSeparator5";
            this.PackSeparator5.ShadowDecoration.Parent = this.PackSeparator5;
            this.PackSeparator5.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator5.TabIndex = 101;
            // 
            // PackDarkOrange
            // 
            this.PackDarkOrange.CheckedState.Parent = this.PackDarkOrange;
            this.PackDarkOrange.CustomImages.Parent = this.PackDarkOrange;
            this.PackDarkOrange.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackDarkOrange.FillColor = System.Drawing.Color.DarkOrange;
            this.PackDarkOrange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackDarkOrange.ForeColor = System.Drawing.Color.White;
            this.PackDarkOrange.HoverState.Parent = this.PackDarkOrange;
            this.PackDarkOrange.Location = new System.Drawing.Point(220, 0);
            this.PackDarkOrange.Name = "PackDarkOrange";
            this.PackDarkOrange.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackDarkOrange.ShadowDecoration.Parent = this.PackDarkOrange;
            this.PackDarkOrange.Size = new System.Drawing.Size(40, 40);
            this.PackDarkOrange.TabIndex = 100;
            this.PackDarkOrange.Click += new System.EventHandler(this.PackDarkOrange_Click);
            // 
            // PackSeparator4
            // 
            this.PackSeparator4.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator4.Location = new System.Drawing.Point(208, 0);
            this.PackSeparator4.Name = "PackSeparator4";
            this.PackSeparator4.ShadowDecoration.Parent = this.PackSeparator4;
            this.PackSeparator4.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator4.TabIndex = 99;
            // 
            // PackCrimson
            // 
            this.PackCrimson.CheckedState.Parent = this.PackCrimson;
            this.PackCrimson.CustomImages.Parent = this.PackCrimson;
            this.PackCrimson.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackCrimson.FillColor = System.Drawing.Color.Crimson;
            this.PackCrimson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackCrimson.ForeColor = System.Drawing.Color.White;
            this.PackCrimson.HoverState.Parent = this.PackCrimson;
            this.PackCrimson.Location = new System.Drawing.Point(168, 0);
            this.PackCrimson.Name = "PackCrimson";
            this.PackCrimson.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackCrimson.ShadowDecoration.Parent = this.PackCrimson;
            this.PackCrimson.Size = new System.Drawing.Size(40, 40);
            this.PackCrimson.TabIndex = 98;
            this.PackCrimson.Click += new System.EventHandler(this.PackCrimson_Click);
            // 
            // PackSeparator3
            // 
            this.PackSeparator3.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator3.Location = new System.Drawing.Point(156, 0);
            this.PackSeparator3.Name = "PackSeparator3";
            this.PackSeparator3.ShadowDecoration.Parent = this.PackSeparator3;
            this.PackSeparator3.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator3.TabIndex = 97;
            // 
            // PackBlueViolet
            // 
            this.PackBlueViolet.CheckedState.Parent = this.PackBlueViolet;
            this.PackBlueViolet.CustomImages.Parent = this.PackBlueViolet;
            this.PackBlueViolet.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackBlueViolet.FillColor = System.Drawing.Color.BlueViolet;
            this.PackBlueViolet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackBlueViolet.ForeColor = System.Drawing.Color.White;
            this.PackBlueViolet.HoverState.Parent = this.PackBlueViolet;
            this.PackBlueViolet.Location = new System.Drawing.Point(116, 0);
            this.PackBlueViolet.Name = "PackBlueViolet";
            this.PackBlueViolet.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackBlueViolet.ShadowDecoration.Parent = this.PackBlueViolet;
            this.PackBlueViolet.Size = new System.Drawing.Size(40, 40);
            this.PackBlueViolet.TabIndex = 96;
            this.PackBlueViolet.Click += new System.EventHandler(this.PackBlueViolet_Click);
            // 
            // PackSeparator2
            // 
            this.PackSeparator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator2.Location = new System.Drawing.Point(104, 0);
            this.PackSeparator2.Name = "PackSeparator2";
            this.PackSeparator2.ShadowDecoration.Parent = this.PackSeparator2;
            this.PackSeparator2.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator2.TabIndex = 95;
            // 
            // PackBlue
            // 
            this.PackBlue.CheckedState.Parent = this.PackBlue;
            this.PackBlue.CustomImages.Parent = this.PackBlue;
            this.PackBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackBlue.FillColor = System.Drawing.Color.Blue;
            this.PackBlue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackBlue.ForeColor = System.Drawing.Color.White;
            this.PackBlue.HoverState.Parent = this.PackBlue;
            this.PackBlue.Location = new System.Drawing.Point(64, 0);
            this.PackBlue.Name = "PackBlue";
            this.PackBlue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackBlue.ShadowDecoration.Parent = this.PackBlue;
            this.PackBlue.Size = new System.Drawing.Size(40, 40);
            this.PackBlue.TabIndex = 94;
            this.PackBlue.Click += new System.EventHandler(this.PackBlue_Click);
            // 
            // PackSeparator1
            // 
            this.PackSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator1.Location = new System.Drawing.Point(52, 0);
            this.PackSeparator1.Name = "PackSeparator1";
            this.PackSeparator1.ShadowDecoration.Parent = this.PackSeparator1;
            this.PackSeparator1.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator1.TabIndex = 93;
            // 
            // PackDefault
            // 
            this.PackDefault.CheckedState.Parent = this.PackDefault;
            this.PackDefault.CustomImages.Parent = this.PackDefault;
            this.PackDefault.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackDefault.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.PackDefault.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PackDefault.ForeColor = System.Drawing.Color.White;
            this.PackDefault.HoverState.Parent = this.PackDefault;
            this.PackDefault.Location = new System.Drawing.Point(12, 0);
            this.PackDefault.Name = "PackDefault";
            this.PackDefault.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PackDefault.ShadowDecoration.Parent = this.PackDefault;
            this.PackDefault.Size = new System.Drawing.Size(40, 40);
            this.PackDefault.TabIndex = 92;
            this.PackDefault.Click += new System.EventHandler(this.PackDefault_Click);
            // 
            // PackSeparator0
            // 
            this.PackSeparator0.Dock = System.Windows.Forms.DockStyle.Left;
            this.PackSeparator0.Location = new System.Drawing.Point(0, 0);
            this.PackSeparator0.Name = "PackSeparator0";
            this.PackSeparator0.ShadowDecoration.Parent = this.PackSeparator0;
            this.PackSeparator0.Size = new System.Drawing.Size(12, 40);
            this.PackSeparator0.TabIndex = 91;
            // 
            // NickName
            // 
            this.NickName.BorderRadius = 13;
            this.NickName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NickName.DefaultText = "";
            this.NickName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NickName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NickName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NickName.DisabledState.Parent = this.NickName;
            this.NickName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NickName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NickName.FocusedState.Parent = this.NickName;
            this.NickName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NickName.HoverState.Parent = this.NickName;
            this.NickName.Location = new System.Drawing.Point(284, 74);
            this.NickName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NickName.Name = "NickName";
            this.NickName.PasswordChar = '\0';
            this.NickName.PlaceholderText = "";
            this.NickName.SelectedText = "";
            this.NickName.ShadowDecoration.Parent = this.NickName;
            this.NickName.Size = new System.Drawing.Size(211, 28);
            this.NickName.TabIndex = 85;
            this.NickName.TextChanged += new System.EventHandler(this.NickName_TextChanged);
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserName.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(281, 51);
            this.UserName.Name = "UserName";
            this.UserName.NeedOpacity = true;
            this.UserName.OpacityColor = System.Drawing.Color.Empty;
            this.UserName.OrgBackColor = System.Drawing.Color.Empty;
            this.UserName.Size = new System.Drawing.Size(59, 20);
            this.UserName.TabIndex = 49;
            this.UserName.Text = "Usuario";
            // 
            // PcName
            // 
            this.PcName.AutoSize = true;
            this.PcName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PcName.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PcName.ForeColor = System.Drawing.Color.White;
            this.PcName.Location = new System.Drawing.Point(281, 26);
            this.PcName.Name = "PcName";
            this.PcName.NeedOpacity = true;
            this.PcName.OpacityColor = System.Drawing.Color.Empty;
            this.PcName.OrgBackColor = System.Drawing.Color.Empty;
            this.PcName.Size = new System.Drawing.Size(64, 20);
            this.PcName.TabIndex = 48;
            this.PcName.Text = "PcName";
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx1.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.labelEx1.ForeColor = System.Drawing.Color.White;
            this.labelEx1.Location = new System.Drawing.Point(118, 4);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.NeedOpacity = true;
            this.labelEx1.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx1.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx1.Size = new System.Drawing.Size(137, 20);
            this.labelEx1.TabIndex = 47;
            this.labelEx1.Text = "Nombre de usuario";
            // 
            // panelTitulo1
            // 
            this.panelTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTitulo1.Controls.Add(this.guna2Separator1);
            this.panelTitulo1.Controls.Add(this.Actualizarusuario);
            this.panelTitulo1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo1.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo1.Name = "panelTitulo1";
            this.panelTitulo1.Size = new System.Drawing.Size(588, 30);
            this.panelTitulo1.TabIndex = 81;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator1.TabIndex = 26;
            // 
            // Actualizarusuario
            // 
            this.Actualizarusuario.AutoSize = true;
            this.Actualizarusuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Actualizarusuario.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actualizarusuario.ForeColor = System.Drawing.Color.White;
            this.Actualizarusuario.Location = new System.Drawing.Point(5, 3);
            this.Actualizarusuario.Name = "Actualizarusuario";
            this.Actualizarusuario.NeedOpacity = true;
            this.Actualizarusuario.OpacityColor = System.Drawing.Color.Empty;
            this.Actualizarusuario.OrgBackColor = System.Drawing.Color.Empty;
            this.Actualizarusuario.Size = new System.Drawing.Size(194, 17);
            this.Actualizarusuario.TabIndex = 25;
            this.Actualizarusuario.Text = "Actualizar datos de usuario";
            // 
            // pnlAceptar
            // 
            this.pnlAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.pnlAceptar.Controls.Add(this.lblAceptar);
            this.pnlAceptar.Location = new System.Drawing.Point(337, 455);
            this.pnlAceptar.Name = "pnlAceptar";
            this.pnlAceptar.Size = new System.Drawing.Size(88, 31);
            this.pnlAceptar.TabIndex = 93;
            this.pnlAceptar.Click += new System.EventHandler(this.pnlAceptar_Click);
            // 
            // lblAceptar
            // 
            this.lblAceptar.AutoSize = true;
            this.lblAceptar.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAceptar.ForeColor = System.Drawing.Color.White;
            this.lblAceptar.Location = new System.Drawing.Point(15, 6);
            this.lblAceptar.Name = "lblAceptar";
            this.lblAceptar.Size = new System.Drawing.Size(60, 17);
            this.lblAceptar.TabIndex = 0;
            this.lblAceptar.Text = "Aceptar";
            this.lblAceptar.Click += new System.EventHandler(this.pnlAceptar_Click);
            // 
            // pnlCancelar
            // 
            this.pnlCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.pnlCancelar.Controls.Add(this.lblCancelar);
            this.pnlCancelar.Location = new System.Drawing.Point(431, 455);
            this.pnlCancelar.Name = "pnlCancelar";
            this.pnlCancelar.Size = new System.Drawing.Size(88, 31);
            this.pnlCancelar.TabIndex = 94;
            this.pnlCancelar.Click += new System.EventHandler(this.CancelSettings);
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCancelar.ForeColor = System.Drawing.Color.White;
            this.lblCancelar.Location = new System.Drawing.Point(11, 6);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(66, 17);
            this.lblCancelar.TabIndex = 1;
            this.lblCancelar.Text = "Cancelar";
            this.lblCancelar.Click += new System.EventHandler(this.CancelSettings);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(567, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(38, 25);
            this.lblClose.TabIndex = 0;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(605, 25);
            this.pnlTitlebar.TabIndex = 0;
            // 
            // pctPhoto
            // 
            this.pctPhoto.Location = new System.Drawing.Point(8, 4);
            this.pctPhoto.Name = "pctPhoto";
            this.pctPhoto.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pctPhoto.ShadowDecoration.Parent = this.pctPhoto;
            this.pctPhoto.Size = new System.Drawing.Size(100, 100);
            this.pctPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPhoto.TabIndex = 94;
            this.pctPhoto.TabStop = false;
            this.pctPhoto.Click += new System.EventHandler(this.pctPhoto_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel6.Controls.Add(this.guna2Separator6);
            this.panel6.Controls.Add(this.labelEx15);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel6.Location = new System.Drawing.Point(0, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(588, 30);
            this.panel6.TabIndex = 95;
            // 
            // guna2Separator6
            // 
            this.guna2Separator6.Location = new System.Drawing.Point(0, 20);
            this.guna2Separator6.Name = "guna2Separator6";
            this.guna2Separator6.Size = new System.Drawing.Size(585, 10);
            this.guna2Separator6.TabIndex = 26;
            // 
            // labelEx15
            // 
            this.labelEx15.AutoSize = true;
            this.labelEx15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEx15.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEx15.ForeColor = System.Drawing.Color.White;
            this.labelEx15.Location = new System.Drawing.Point(5, 3);
            this.labelEx15.Name = "labelEx15";
            this.labelEx15.NeedOpacity = true;
            this.labelEx15.OpacityColor = System.Drawing.Color.Empty;
            this.labelEx15.OrgBackColor = System.Drawing.Color.Empty;
            this.labelEx15.Size = new System.Drawing.Size(147, 17);
            this.labelEx15.TabIndex = 25;
            this.labelEx15.Text = "Mensajes en colores";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(605, 560);
            this.Controls.Add(this.panelBack);
            this.Controls.Add(this.pnlTitlebar);
            this.Controls.Add(this.pnlAceptar);
            this.Controls.Add(this.pnlCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = " ";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.panelBack.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlKeyUp.ResumeLayout(false);
            this.pnlKeyUp.PerformLayout();
            this.panelTitulo5.ResumeLayout(false);
            this.panelTitulo5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelTitulo4.ResumeLayout(false);
            this.panelTitulo4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelTitulo3.ResumeLayout(false);
            this.panelTitulo3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelTitulo2.ResumeLayout(false);
            this.panelTitulo2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.panelTitulo1.ResumeLayout(false);
            this.panelTitulo1.PerformLayout();
            this.pnlAceptar.ResumeLayout(false);
            this.pnlAceptar.PerformLayout();
            this.pnlCancelar.ResumeLayout(false);
            this.pnlCancelar.PerformLayout();
            this.pnlTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Panel panel10;
        public TabPage tabPage1;
        public TabPage tabPage2;
        private IContainer components;
        private Timer TicToc;
        private Panel panelBack;
        private Panel panel1;
        private LabelEx MINcount;
        private LabelEx labelEx13;
        private Panel panelTitulo5;
        private LabelEx Varios;
        private Panel panel2;
        private LabelEx labelEx11;
        private LabelEx labelEx12;
        private LabelEx labelEx9;
        private LabelEx labelEx10;
        private Panel panelTitulo4;
        private LabelEx Notificaciones;
        private Panel panel7;
        private LabelEx labelEx7;
        private LabelEx labelEx8;
        private Button ChangeBox;
        private TextBox DirBox;
        private LabelEx labelEx6;
        private Panel panelTitulo3;
        private LabelEx Archivosrecibidos;
        private Panel panel8;
        private LabelEx labelEx5;
        private LabelEx labelEx4;
        private Panel panelTitulo2;
        private LabelEx OpcionesInicio;
        private Panel panel9;
        private LabelEx UserName;
        private LabelEx PcName;
        public LabelEx labelEx1;
        private Panel panelTitulo1;
        private LabelEx Actualizarusuario;
        private Panel pnlCancelar;
        private HackLabel lblCancelar;
        private Panel pnlAceptar;
        private HackLabel lblAceptar;
        private HackNUD UserMin;
        private Button openFolder;
        private LabelEx labelEx3;
        private LabelEx labelEx14;
        private LabelEx labelEx20;
        private Panel pnlKeyUp;
        public LabelEx lblKeyUp;
        private Guna.UI2.WinForms.Guna2TextBox NickName;
        private Guna.UI2.WinForms.Guna2ToggleSwitch launchWindows;
        private Guna.UI2.WinForms.Guna2ToggleSwitch PosicionOriginal;
        private Guna.UI2.WinForms.Guna2ToggleSwitch AbrirArchivo;
        private Guna.UI2.WinForms.Guna2ToggleSwitch AbrirCarpeta;
        private Guna.UI2.WinForms.Guna2ToggleSwitch NotifyStatus;
        private Guna.UI2.WinForms.Guna2ToggleSwitch AchivoRecibido;
        private Guna.UI2.WinForms.Guna2ToggleSwitch DesconectadoUser;
        private Guna.UI2.WinForms.Guna2ToggleSwitch NuevoUser;
        private Guna.UI2.WinForms.Guna2ToggleSwitch CleanWhenClose;
        public Guna.UI2.WinForms.Guna2ToggleSwitch DateTimeZinc;
        public Label lblClose;
        public Panel pnlTitlebar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2CircleButton PackCrimson;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator3;
        private Guna.UI2.WinForms.Guna2CircleButton PackBlueViolet;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator2;
        private Guna.UI2.WinForms.Guna2CircleButton PackBlue;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator1;
        private Guna.UI2.WinForms.Guna2CircleButton PackDefault;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator0;
        private Guna.UI2.WinForms.Guna2CircleButton PackDarkOrange;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator4;
        private Guna.UI2.WinForms.Guna2CircleButton PackDeepPink;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator5;
        private Guna.UI2.WinForms.Guna2CircleButton PackDeepSkyBlue;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator6;
        private Guna.UI2.WinForms.Guna2CircleButton PackGold;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator7;
        private Guna.UI2.WinForms.Guna2CircleButton PackLightSalmon;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator8;
        private Guna.UI2.WinForms.Guna2CircleButton PackLimeGreen;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator9;
        private Guna.UI2.WinForms.Guna2CircleButton PackOrangeRed;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator10;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2CircleButton PackGreenYellow;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator21;
        private Guna.UI2.WinForms.Guna2CircleButton PackSlateBlue;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator20;
        private Guna.UI2.WinForms.Guna2CircleButton PackAquamarine;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator19;
        private Guna.UI2.WinForms.Guna2CircleButton PackMediumSeaGreen;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator18;
        private Guna.UI2.WinForms.Guna2CircleButton PackYellow;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator17;
        private Guna.UI2.WinForms.Guna2CircleButton PackTurquoise;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator16;
        private Guna.UI2.WinForms.Guna2CircleButton PackSkyBlue;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator15;
        private Guna.UI2.WinForms.Guna2CircleButton PackRed;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator14;
        private Guna.UI2.WinForms.Guna2CircleButton PackPurple;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator13;
        private Guna.UI2.WinForms.Guna2CircleButton PackPlum;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator12;
        private Guna.UI2.WinForms.Guna2CircleButton PackPink;
        private Guna.UI2.WinForms.Guna2Panel PackSeparator11;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel PackSelector1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel PackSelector2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator5;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2RadioButton machineN;
        private Guna.UI2.WinForms.Guna2RadioButton CustomNick;
        private Guna.UI2.WinForms.Guna2RadioButton NickSystem;
        private Guna.UI2.WinForms.Guna2RadioButton GuardarPosicion;
        private Guna.UI2.WinForms.Guna2RadioButton IniciarCentro;
        public Guna.UI2.WinForms.Guna2CirclePictureBox pctPhoto;
        private Panel panel6;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator6;
        private LabelEx labelEx15;
    }
}