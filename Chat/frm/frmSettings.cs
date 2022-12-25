using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Chat.Controles;
using Chat.frm;

// []   |||   &&

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmSettings : Form
    {
        //Settings

        public Image userImage { get; set; }
        public string _nickTMP { get; set; }
        public bool DateTimeZincBool { get; set; }


        /////////////////////////////////////////////////////////////////////////
        internal virtual Panel pnldisplayoptions
        {
            get;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set;
        }
        public string ActivePluginName => _activePluginName;
        public static frmSettings frm;
        public IEnumerator enumerator;
        public bool _SExit;
        public bool _Exit;
        public bool deactivatemain;
        public bool _isSplitterMoving;
        public string _searchPluginName;
        public bool _hidesearch;
        private bool flag;
        private bool flag2;
        private bool flag3;
        private float opacityvalue;
        private bool val;
        public static FlowLayoutPanel pnlAnnouncement = new FlowLayoutPanel();
        //private UserHost _userHost;
        private string[] _args;
        public Panel pnlChatDetail;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        private bool _bubbledash;
        private bool _ctrlkeyheld;
        public string Selrowkey;
        public static frmSettings _settingsFrm;
        public MessengerColumn Dc;
        public static Image userPhoto;


        //Servidor Ficheros
        Settings kosmoSettings;
        public bool topNivel;




        public string _activePluginName { get; set; }
        public WebBrowser WBrowser { get; set; }
        public bool ChangeDisplay { get; set; }
        private UserStatus userStatus { get; set; }
        string lastMessage { get; set; }
        public string IP { get; set; }


        public frmSettings()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            //this.MaximumSize = new Size(550, 500);
            frm = this;
            pnldisplayoptions = new Panel();
            //pnlAceptar.BringToFront();
            //pnlCancelar.BringToFront();
            HackLabelColor.OriginalColor = Color.White;
            HackLabelColor.MouseMoveColor = Color.Gainsboro;


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _nickTMP = frmMain.NickName;

            if (frmMain.NickName == Environment.MachineName)
            {
                machineN.Checked = true;
                NickName.Enabled = false;
            }
            else if (frmMain.NickName == Environment.UserName)
            {
                NickSystem.Checked = true;
                NickName.Enabled = false;
            }
            else
            {
                NickName.Enabled = true;
                CustomNick.Checked = true;
            }

            //Color = frmMain.Color;
            NickName.Text = frmMain.NickName;


            launchWindows.Checked = frmMain.LaunchWindows;
            PosicionOriginal.Checked = frmMain.PosicionOriginal;
            IniciarCentro.Checked = frmMain.CenterScreen;
            GuardarPosicion.Checked = frmMain.GuardarPosicion;
            DirBox.Text = frmMain.DirBox;
            AbrirCarpeta.Checked = frmMain.AbrirCarpeta;
            AbrirArchivo.Checked = frmMain.AbrirArchivo;
            NuevoUser.Checked = frmMain.NuevoUser;
            DesconectadoUser.Checked = frmMain.DesconectadoUser;
            AchivoRecibido.Checked = frmMain.AchivoRecibido;
            NotifyStatus.Checked = frmMain.NotifyStatus;
            UserMin.Value = frmMain.UserMin;
            UserMin.Text = frmMain.UserMin.ToString();
            CleanWhenClose.Checked = frmMain.CleanWhenClose;
            DateTimeZinc.Checked = frmMain.DateTimeZinc;
            DateTimeZincBool = frmMain.DateTimeZinc;
            lblKeyUp.Text = frmMain.KeyTop;

            if (frmMain.UserDateTimeZinc != "" && frmMain.DateTimeZinc)
            labelEx14.Text = "Sincronizando hora con el usuario " + Modcommon.GetNamefromID(frmMain.UserDateTimeZinc);

            if (frmMain.PosicionOriginal)
            {
                GuardarPosicion.Enabled = false;
                IniciarCentro.Enabled = false;
            }

            PcName.Text = Environment.MachineName;
            UserName.Text = Environment.UserName;
            pctPhoto.Image = LetterImage.GetBigUserImage(frmMain.UserId);

            ChangedSelector();

            if (PosicionOriginal.Checked)
            {
                IniciarCentro.Enabled = false;
                GuardarPosicion.Enabled = false;
                //IniciarCentro.Customization = "AAAAAMDAwP/AwMD/";
                //GuardarPosicion.Customization = "AAAAAMDAwP/AwMD/";
                //labelEx18.ForeColor = Color.Silver;
                //labelEx19.ForeColor = Color.Silver;
            }

            if (UserMin.Value == decimal.One)
            {
                MINcount.Text = UserMin.Value.ToString() + " minuto";
            }
            else
            {
                MINcount.Text = UserMin.Value.ToString() + " minutos";
            }



        }


        private int num;




































        private void ChangeActiveColor()
        {
            this.ChangeControlBGColor(Color.FromArgb(49, 140, 231));
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Modcommon.DEFAULTVIEW)
                    FlashWin.StopWin(this.Handle);
                if (this.Location.X < 0 || this.Location.Y < 0)
                    this.BringToFront();
                this.ChangeActiveColor();
                this.deactivatemain = false;
                /*
                if (Modcommon.ICHAT_TABS != null)
                {
                    if (Modcommon.WINDOW_VIEW == Modcommon.WindowViewType.Popup || !Modcommon.ICHAT_TABS.IsTabExists())
                    {
                        if (Modcommon.CURRENTMAIN_FORM == null || !Modcommon.CURRENTMAIN_FORM.GetType().Equals(typeof(//FrmUsers)))
                            return;
                        ((//FrmUsers)Modcommon.CURRENTMAIN_FORM).FocusUserGrid("");
                        return;
                    }
                    else
                    {
                        Modcommon.FCHAT_KEY = string.Empty;
                        if (!this.CheckActiveTab() && Modcommon.CURRENTMAIN_FORM != null && Modcommon.CURRENTMAIN_FORM.GetType().Equals(typeof(//FrmUsers)))
                            ((//FrmUsers)Modcommon.CURRENTMAIN_FORM).FocusUserGrid("");
                        if (TitlebarChatCount.CheckUserExists(Modcommon.ICHAT_TABS.GetActiveChatKey()) & this.WindowState != FormWindowState.Minimized)
                        {
                            TitlebarChatCount.ReplaceUser(Modcommon.ICHAT_TABS.GetActiveChatKey());
                            this.ChangeTitleInTaskBar(true);
                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            topNivel = true;


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


        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.ChangeDeActiveColor();
                this.DisableToolTips();
                this.deactivatemain = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void DisableToolTips()
        {
            try
            {
                /*
                if (this._pluginList == null)
                {
                    if (Modcommon.CURRENTMAIN_FORM == null || !Modcommon.CURRENTMAIN_FORM.GetType().Equals(typeof(//FrmUsers)))
                        return;
                    MyProject.Forms.//FrmUsers.DisableToolTip();
                }
                else
                    this._pluginList.RaiseEvent_DisableToolTip();
                */
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void ChangeDeActiveColor()
        {
            this.ChangeControlBGColor(ColorTranslator.FromHtml("#AAAAAA"));
        }

        private void ChangeControlBGColor(Color clr)
        {
            try
            {
                this.SuspendLayout();
                this.BackColor = clr;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            this.ResumeLayout();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //kosmosettings.GuardarSettings();
        }
        private void ChangeCloseMinMaxBg()
        {
            try
            {
                Color color;
                color = Template.LEFT_HEADER_COLOR;
                this.lblClose.BackColor = color;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }



        public void SetCurrentUserName(string name)
        {
            try
            {
                Modcommon.UserName = name;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }


        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                if (this._args == null || this._args.Length <= 1 || !this._args[1].Equals("/m"))
                    return;
                this._args = (string[])null;
                this.Hide();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {

        }
        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.Visible)
                    return;
                this.CheckWindowLocation();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(1, 1, checked(this.Width - 2), checked(this.Height - 2));
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

        private void ChangeCloseMinMaxBg(Label lbl)
        {
            try
            {
                lbl.BackColor = Color.White;
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
            this.WindowState = FormWindowState.Minimized;
        }
        private void SetMaxSize()
        {
            try
            {
                Point location = this.Location;
                int x = location.X;
                location = this.Location;
                int y = location.Y;
                int width = this.Width;
                int height = this.Height;
                Size size = Modcommon.CurrentScreenWorkingAreaSize(x, y, width, height);
                if (!(this.MaximumSize != size))
                    return;
                this.MaximumSize = size;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            if (!Modcommon.DEFAULTVIEW)
                Modcommon.MAIN_CLOSE = true;
            //this.Close();
            if ((string)pctPhoto.Tag == "1")
                Avatar = true;
            else
                Avatar = false;

            if (NickName.Text != _nickTMP)
            {
                nick = true;
            }
            else
            {
                nick = false;
            }

            frmMain.LaunchWindows = launchWindows.Checked;
            frmMain.PosicionOriginal = PosicionOriginal.Checked;
            frmMain.CenterScreen = IniciarCentro.Checked;
            frmMain.GuardarPosicion = GuardarPosicion.Checked;
            frmMain.DirBox = DirBox.Text;
            frmMain.AbrirCarpeta = AbrirCarpeta.Checked;
            frmMain.AbrirArchivo = AbrirArchivo.Checked;
            frmMain.NuevoUser = NuevoUser.Checked;
            frmMain.DesconectadoUser = DesconectadoUser.Checked;
            frmMain.AchivoRecibido = AchivoRecibido.Checked;
            frmMain.NotifyStatus = NotifyStatus.Checked;
            frmMain.UserMin = Convert.ToInt32(UserMin.Value);
            frmMain.Avatarlength = Modcommon.GetAvatarlength();
            frmMain.CleanWhenClose = CleanWhenClose.Checked;
            frmMain.frm.colorbar();
            frmMain.ApplySettings(Avatar, nick, NickName.Text);
            frmMain.frm.CloseChildForm();
            frmMain.frm.PanelChat.Visible = true;
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            this.lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(26, 32, 47);
            //this.ChangeCloseMinMaxBg(this.lblClose);
        }



        private string GetRect2(string status, Point p, DataGridView dgv, SizeF sz, Font fp)
        {
            new Rectangle(p.X, p.Y, checked(dgv.Width - 40), 40);
            string text = Strings.StrDup(status.Length, " ");
            while ((float)TextRenderer.MeasureText(text, fp).Width <= sz.Width)
            {
                text += Strings.StrDup(1, " ");
            }
            return text;
        }
        
        public void Crearlog(Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            WriteLog.Save(ex2);
            ProjectData.ClearProjectError();

        }

        private void CambiarNick(object sender)
        {
            try
            {
                if (machineN.Checked)
                {
                    NickName.Enabled = false;
                    NickName.Text = Environment.MachineName;
                }
                else if (NickSystem.Checked)
                {
                    NickName.Enabled = false;
                    NickName.Text = Environment.UserName;
                }
                else if (CustomNick.Checked)
                {
                    NickName.Text = _nickTMP;
                    NickName.Enabled = true;
                    CustomNick.Checked = true;
                }
            } catch { }
        }

        private void pctPhoto_Click(object sender, EventArgs e)
        {
            frmPhoto FrmPhoto = new frmPhoto();
            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.FileName = string.Empty;
            ofdPhoto.Filter = "Picture files|*.jpg;*.bmp;*.gif|All Files|*.*";
            ofdPhoto.Title = "Select Photo";
            ofdPhoto.RestoreDirectory = true;
            DialogResult num = ofdPhoto.ShowDialog();
            pctPhoto.Tag = string.Empty;
            if (num == DialogResult.OK)
            {
                pctPhoto.Tag = "1";
                int width = 413;
                int height = 423;
                Image image = Modcommon.ImageFromFile(ofdPhoto.FileName);
                Image image2 = FrmPhoto.ResizeImage(ofdPhoto.FileName, image, new Size(width, height));
                FrmPhoto.picSelectPhoto.Width = width;
                FrmPhoto.picSelectPhoto.Height = height;
                FrmPhoto.picSelectPhoto.Image = image2;
                FrmPhoto.picSelectPhoto.Location = new Point((int)Math.Round(unchecked((double)checked(frmPhoto.frm.pnlPhoto.Width - frmPhoto.frm.picSelectPhoto.Width) / 2.0)), (int)Math.Round(unchecked((double)checked(frmPhoto.frm.pnlPhoto.Height - frmPhoto.frm.picSelectPhoto.Height) / 2.0)));
                FrmPhoto.ShowDialog();
                FrmPhoto.BringToFront();
            }
            ofdPhoto = null;

        }

        private void PosicionOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (PosicionOriginal.Checked)
            {
                IniciarCentro.Enabled = false;
                GuardarPosicion.Enabled = false;
                //IniciarCentro.Customization = "AAAAAMDAwP/AwMD/";
                //GuardarPosicion.Customization = "AAAAAMDAwP/AwMD/";
                //labelEx18.ForeColor = Color.Silver;
                //labelEx19.ForeColor = Color.Silver;
            }
            else
            {
                IniciarCentro.Enabled = true;
                GuardarPosicion.Enabled = true;

                if (!IniciarCentro.Checked && !GuardarPosicion.Checked)
                    GuardarPosicion.Checked = true;

                //IniciarCentro.Customization = "AAAAAPWkB//1pAf/";
                //GuardarPosicion.Customization = "AAAAAPWkB//1pAf/";
                //labelEx18.ForeColor = Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //labelEx19.ForeColor = Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

            }
        }

        private void CancelSettings(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeBox_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog serverloc_patch = new FolderBrowserDialog();
                if (serverloc_patch.ShowDialog() == DialogResult.OK)
                {
                    DirBox.Text = serverloc_patch.SelectedPath;
                    TeamTalk.Utils.TeamTalk.ChangeServerTransferDir(serverloc_patch.SelectedPath);
                }
            }
            catch { }
        }

        private bool Avatar = false;
        private bool nick = false;
        private void pnlAceptar_Click(object sender, EventArgs e)
        {
            if ((string)pctPhoto.Tag == "1")
                Avatar = true;
            else
                Avatar = false;

            if (NickName.Text != _nickTMP)
            {
                nick = true;
            }
            else
            {
                nick = false;
            }

            frmMain.LaunchWindows = launchWindows.Checked;
            frmMain.PosicionOriginal = PosicionOriginal.Checked;
            frmMain.CenterScreen = IniciarCentro.Checked;
            frmMain.GuardarPosicion = GuardarPosicion.Checked;
            frmMain.DirBox = DirBox.Text;
            frmMain.AbrirCarpeta = AbrirCarpeta.Checked;
            frmMain.AbrirArchivo = AbrirArchivo.Checked;
            frmMain.NuevoUser = NuevoUser.Checked;
            frmMain.DesconectadoUser = DesconectadoUser.Checked;
            frmMain.AchivoRecibido = AchivoRecibido.Checked;
            frmMain.NotifyStatus = NotifyStatus.Checked;
            frmMain.UserMin = Convert.ToInt32(UserMin.Value);
            frmMain.Avatarlength = Modcommon.GetAvatarlength();
            frmMain.CleanWhenClose = CleanWhenClose.Checked;
            frmMain.frm.colorbar();
            frmMain.ApplySettings(Avatar, nick, NickName.Text);

            Close();
        }

        private void frmSettings_Resize(object sender, EventArgs e)
        {
            //this.Size = new Size(550, 500);
        }

        private void NickName_TextChanged(object sender, EventArgs e)
        {
            NickName.Tag = 1;
        }
        private void CambiarNick(object sender, EventArgs e)
        {
            try
            {
                if (machineN.Checked)
                {
                    NickName.Enabled = false;
                    NickName.Text = Environment.MachineName;
                }
                else if (NickSystem.Checked)
                {
                    NickName.Enabled = false;
                    NickName.Text = Environment.UserName;
                }
                else if (CustomNick.Checked)
                {
                    NickName.Text = _nickTMP;
                    NickName.Enabled = true;
                    CustomNick.Checked = true;
                }
            }
            catch { }
        }
        #region Pack
        private void PackDefault_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 0;
            ChangedSelector();
        }
        private void PackBlue_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 1;
            ChangedSelector();
        }
        private void PackBlueViolet_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 2;
            ChangedSelector();
        }
        private void PackCrimson_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 3;
            ChangedSelector();
        }
        private void PackDarkOrange_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 4;
            ChangedSelector();
        }
        private void PackDeepPink_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 5;
            ChangedSelector();
        }
        private void PackDeepSkyBlue_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 6;
            ChangedSelector();
        }
        private void PackGold_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 7;
            ChangedSelector();
        }
        private void PackLightSalmon_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 8;
            ChangedSelector();
        }
        private void PackLimeGreen_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 9;
            ChangedSelector();
        }
        private void PackOrangeRed_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 10;
            ChangedSelector();
        }
        private void PackPink_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 11;
            ChangedSelector();
        }
        private void PackPlum_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 12;
            ChangedSelector();
        }
        private void PackPurple_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 13;
            ChangedSelector();
        }
        private void PackRed_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 14;
            ChangedSelector();
        }
        private void PackSkyBlue_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 15;
            ChangedSelector();
        }
        private void PackTurquoise_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 16;
            ChangedSelector();
        }
        private void PackYellow_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 17;
            ChangedSelector();
        }
        private void PackMediumSeaGreen_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 18;
            ChangedSelector();
        }
        private void PackAquamarine_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 19;
            ChangedSelector();
        }
        private void PackSlateBlue_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 20;
            ChangedSelector();
        }
        private void PackGreenYellow_Click(object sender, EventArgs e)
        {
            frmMain.UserSelectedColor = 21;
            ChangedSelector();
        }
        #endregion
        private void ChangedSelector()
        {
            if (frmMain.UserSelectedColor == 0)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackDefault.Location.X,PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                launchWindows.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                machineN.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                machineN.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                NickSystem.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                CustomNick.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.FromArgb(182, 222, 255);
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);

                PackSelector1.FillColor = System.Drawing.Color.FromArgb(182, 222, 255);
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 1)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackBlue.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Blue;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Blue;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Blue;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Blue;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Blue;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Blue;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Blue;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Blue;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Blue;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Blue;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Blue;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Blue;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Blue;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Blue;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Blue;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Blue;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Blue;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Blue;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Blue;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Blue;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Blue;
                machineN.CheckedState.FillColor = System.Drawing.Color.Blue;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Blue;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Blue;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Blue;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Blue;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Blue;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Blue;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Blue;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Blue;

                PackSelector1.FillColor = System.Drawing.Color.Blue;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 2)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackBlueViolet.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                machineN.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                machineN.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.BlueViolet;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.BlueViolet;

                PackSelector1.FillColor = System.Drawing.Color.BlueViolet;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 3)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackCrimson.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Crimson;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Crimson;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Crimson;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Crimson;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Crimson;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Crimson;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Crimson;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Crimson;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Crimson;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Crimson;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                machineN.CheckedState.FillColor = System.Drawing.Color.Crimson;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Crimson;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Crimson;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Crimson;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Crimson;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Crimson;

                PackSelector1.FillColor = System.Drawing.Color.Crimson;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 4)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackDarkOrange.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                machineN.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                machineN.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.DarkOrange;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.DarkOrange;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.DarkOrange;

                PackSelector1.FillColor = System.Drawing.Color.DarkOrange;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 5)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackDeepPink.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                machineN.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                machineN.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.DeepPink;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.DeepPink;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.DeepPink;

                PackSelector1.FillColor = System.Drawing.Color.DeepPink;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 6)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackDeepSkyBlue.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                machineN.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                machineN.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;

                PackSelector1.FillColor = System.Drawing.Color.DeepSkyBlue;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 7)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackGold.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Gold;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Gold;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Gold;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Gold;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Gold;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Gold;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Gold;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Gold;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Gold;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Gold;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Gold;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Gold;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Gold;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Gold;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Gold;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Gold;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Gold;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Gold;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Gold;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Gold;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Gold;
                machineN.CheckedState.FillColor = System.Drawing.Color.Gold;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Gold;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Gold;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Gold;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Gold;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Gold;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Gold;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Gold;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Gold;

                PackSelector1.FillColor = System.Drawing.Color.Gold;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 8)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackLightSalmon.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                machineN.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                machineN.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.LightSalmon;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.LightSalmon;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.LightSalmon;

                PackSelector1.FillColor = System.Drawing.Color.LightSalmon;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 9)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackLimeGreen.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                machineN.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                machineN.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.LimeGreen;

                PackSelector1.FillColor = System.Drawing.Color.LimeGreen;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 10)
            {
                PackSelector1.Visible = true;
                PackSelector2.Visible = false;
                PackSelector1.Location = new Point(PackOrangeRed.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                machineN.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                machineN.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.OrangeRed;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.OrangeRed;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.OrangeRed;

                PackSelector1.FillColor = System.Drawing.Color.OrangeRed;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 11)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackPink.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Pink;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Pink;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Pink;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Pink;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Pink;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Pink;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Pink;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Pink;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Pink;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Pink;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Pink;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Pink;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Pink;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Pink;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Pink;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Pink;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Pink;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Pink;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Pink;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Pink;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Pink;
                machineN.CheckedState.FillColor = System.Drawing.Color.Pink;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Pink;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Pink;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Pink;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Pink;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Pink;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Pink;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Pink;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Pink;

                PackSelector2.FillColor = System.Drawing.Color.Pink;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 12)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackPlum.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Plum;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Plum;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Plum;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Plum;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Plum;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Plum;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Plum;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Plum;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Plum;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Plum;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Plum;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Plum;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Plum;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Plum;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Plum;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Plum;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Plum;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Plum;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Plum;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Plum;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Plum;
                machineN.CheckedState.FillColor = System.Drawing.Color.Plum;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Plum;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Plum;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Plum;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Plum;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Plum;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Plum;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Plum;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Plum;

                PackSelector2.FillColor = System.Drawing.Color.Plum;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 13)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackPurple.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Purple;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Purple;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Purple;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Purple;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Purple;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Purple;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Purple;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Purple;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Purple;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Purple;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Purple;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Purple;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Purple;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Purple;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Purple;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Purple;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Purple;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Purple;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Purple;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Purple;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Purple;
                machineN.CheckedState.FillColor = System.Drawing.Color.Purple;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Purple;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Purple;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Purple;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Purple;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Purple;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Purple;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Purple;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Purple;

                PackSelector2.FillColor = System.Drawing.Color.Purple;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 14)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackRed.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Red;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Red;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Red;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Red;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Red;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Red;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Red;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Red;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Red;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Red;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Red;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Red;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Red;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Red;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Red;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Red;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Red;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Red;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Red;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Red;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Red;
                machineN.CheckedState.FillColor = System.Drawing.Color.Red;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Red;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Red;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Red;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Red;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Red;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Red;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Red;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Red;

                PackSelector2.FillColor = System.Drawing.Color.Red;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 15)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackSkyBlue.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                machineN.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                machineN.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.SkyBlue;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.SkyBlue;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.SkyBlue;

                PackSelector2.FillColor = System.Drawing.Color.SkyBlue;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 16)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackTurquoise.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                machineN.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Turquoise;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Turquoise;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Turquoise;

                PackSelector2.FillColor = System.Drawing.Color.Turquoise;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 17)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackYellow.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Yellow;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Yellow;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Yellow;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Yellow;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Yellow;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Yellow;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Yellow;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Yellow;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Yellow;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Yellow;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                machineN.CheckedState.FillColor = System.Drawing.Color.Yellow;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Yellow;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Yellow;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Yellow;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Yellow;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Yellow;

                PackSelector2.FillColor = System.Drawing.Color.Yellow;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 18)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackMediumSeaGreen.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                machineN.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                machineN.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.MediumSeaGreen;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.MediumSeaGreen;

                PackSelector2.FillColor = System.Drawing.Color.MediumSeaGreen;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 19)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackAquamarine.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                machineN.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                machineN.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.Aquamarine;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.Aquamarine;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.Aquamarine;

                PackSelector2.FillColor = System.Drawing.Color.Aquamarine;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 20)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackSlateBlue.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                machineN.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                machineN.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.SlateBlue;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.SlateBlue;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.SlateBlue;

                PackSelector2.FillColor = System.Drawing.Color.SlateBlue;
                frmMain.frm.colorbar();
            }
            else if (frmMain.UserSelectedColor == 21)
            {
                PackSelector1.Visible = false;
                PackSelector2.Visible = true;
                PackSelector2.Location = new Point(PackGreenYellow.Location.X, PackSelector1.Location.Y);
                launchWindows.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                launchWindows.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                PosicionOriginal.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                PosicionOriginal.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                DateTimeZinc.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                DateTimeZinc.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                AbrirCarpeta.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                AbrirCarpeta.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                AbrirArchivo.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                AbrirArchivo.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                NuevoUser.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                NuevoUser.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                DesconectadoUser.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                DesconectadoUser.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                AchivoRecibido.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                AchivoRecibido.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                NotifyStatus.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                NotifyStatus.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                CleanWhenClose.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                CleanWhenClose.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                machineN.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                machineN.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                NickSystem.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                NickSystem.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                CustomNick.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                CustomNick.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                IniciarCentro.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                IniciarCentro.CheckedState.FillColor = System.Drawing.Color.GreenYellow;
                GuardarPosicion.CheckedState.BorderColor = System.Drawing.Color.GreenYellow;
                GuardarPosicion.CheckedState.FillColor = System.Drawing.Color.GreenYellow;

                PackSelector2.FillColor = System.Drawing.Color.GreenYellow;
                frmMain.frm.colorbar();
            }
        }
        private void UserMin_TextChanged(object sender, EventArgs e)
        {
            UserMin.Value = Convert.ToInt32(UserMin.Text);
            frmMain.UserMin = (int)UserMin.Value;


            if (UserMin.Value == decimal.One)
            {
                MINcount.Text = UserMin.Value.ToString() + " minuto";
            }
            else
            {
                MINcount.Text = UserMin.Value.ToString() + " minutos";
            }


        }

        private void launchWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
                try
                {
                    if (launchWindows.Checked)
                    {
                        registryKey.SetValue("KosmoChat.exe", Application.ExecutablePath.ToString());
                    }
                    else
                    {
                        registryKey.DeleteValue("KosmoChat.exe");
                    }
                }
                catch { }
            }
            catch { }
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DirBox.Text);
        }

        private void UserMin_Click(object sender, EventArgs e)
        {
            if (UserMin.Value == 1)
            {
                MINcount.Text = UserMin.Value.ToString() + " minuto";
            }
            else
            {
                MINcount.Text = UserMin.Value.ToString() + " minutos";
            }

        }

        private void DateTimeZinc_CheckedChanged(object sender, EventArgs e)
        {
            if (DateTimeZinc.Checked)
            {
                //DateTimeZinc.Checked = true;
                frmMain.DateTimeZinc = true;
                frmUserZinc frm = new frmUserZinc();
                frm.ShowDialog();

                if (DateTimeZincBool == false)
                {
                    //DateTimeZinc.Checked = false;
                    frmMain.DateTimeZinc = false;
                }
                else
                {
                    labelEx14.Text = "Sincronizando hora con el usuario " + Modcommon.GetNamefromID(frmMain.UserDateTimeZinc);
                    frmMain.frm.Transmit("GiveDateTime", frmMain.UserDateTimeZinc);
                }
            }
            else
            {
                frmMain.UserDateTimeZinc = "";
                frmMain.DateTimeZinc = false;
                //DateTimeZinc.Checked = false;
                labelEx14.Text = "Sincronizar hora con usuario";
            }
        }

        private void pnlKeyUp_Click(object sender, EventArgs e)
        {
            frmKeyUp keyUp = new frmKeyUp();
            keyUp.ShowDialog();

            frmMain.frm.keyTopMost = Modcommon.GetKey(frmMain.KeyTop);
        }

        private void NickLogic()
        {
            try
            {
                if (machineN.Checked)
                {
                    NickName.Text = Environment.MachineName;
                    NickName.Enabled = false;
                }
                else if (NickSystem.Checked)
                {
                    NickName.Text = Environment.UserName;
                    NickName.Enabled = false;
                }
                else if (CustomNick.Checked)
                {
                    NickName.Text = _nickTMP;
                    NickName.Enabled = true;
                    NickName.Focus();
                }
            }
            catch { }
        }
        private void labelEx16_Click(object sender, EventArgs e)
        {
            machineN.Checked = true;
            NickLogic();     
        }
        private void labelEx15_Click(object sender, EventArgs e)
        {
            NickSystem.Checked = true;
            NickLogic();
        }

        private void labelEx17_Click(object sender, EventArgs e)
        {
            CustomNick.Checked = true;
            NickLogic();
        }
    }
    /*
    .
    .
    .
    */
}

