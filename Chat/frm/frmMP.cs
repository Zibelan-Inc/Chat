using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

// []   |||   &&

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmMP : frmResize
    {
        //Settings
        public static frmMP frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        /////////////////////////////////////////////////////////////////////////

        public IEnumerator enumerator;
        public bool _SExit;
        public bool _Exit;
        public bool deactivatemain;
        public bool _isSplitterMoving;
        public string _searchPluginName;
        public bool _hidesearch;
        public static FlowLayoutPanel pnlAnnouncement = new FlowLayoutPanel();
        //private UserHost _userHost;
        private string[] _args;
        public Panel pnlChatDetail;
        public string Selrowkey;
        public MessengerColumn Dc;
        public static Image userPhoto;
        //Chat
        public static Form SettingsForm = null;
        public bool saveOnExit;
        public bool Muted;
        public bool alive = true;
        public RegistryKey Chat;

        //Servidor Ficheros
        public bool topNivel;
        public string _activePluginName { get; set; }


        public frmMP()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            base.KeyDown += frmPhoto_KeyDown;
            base.Load += frmPhoto_Load;
            frm = this;

            WinMod.MakeWindowTop((long)this.Handle);
            MoveToTopMost(this.Handle);

        }
        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

        private void MoveToTopMost(IntPtr handle)
        {
            NativeMethods.SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
        }

        private void frmPhoto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
        public void WriteMessage(string Mensage, string userID = null, int actionColor = 0)
        {
           string Nick = Modcommon.GetNamefromID(userID);
            try
            {
                userPhoto = LetterImage.GetBigUserImage(userID);
                AvatarUserPanel.Image = Modcommon.CropToCircle(userPhoto);
                lblWelcomeUserPanel.Text = Nick + " te ha enviado un Mensaje privado";
                txtMessages.SelectionStart = txtMessages.TextLength;
                txtMessages.SelectionLength = 0;

                MoveToTopMost(this.Handle);
                txtMessages.AppendText(Mensage);
                Text = "KosmoChat - Mensaje privado";

                txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                txtMessages.SelectionColor = txtMessages.ForeColor;
            }
            catch { }
        }


        private void frmPhoto_Load(object sender, EventArgs e)
        {
            try
            {
                base.Top = (int)(unchecked(Modcommon.SystemVirtualScreenHeight() / 2) - unchecked(base.Height / 2));
                base.Left = (int)(unchecked(Modcommon.SystemVirtualScreenWidth() / 2) - unchecked(base.Width / 2));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }

        private void MP_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MP_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void MP_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }



















        private void frmMain_Load(object sender, EventArgs e)
        {

        }






































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
            //KosmoSettings.GuardarSettings();
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
            try
            {

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
                Color color = Template.RIGHT_HEADER_COLOR;
                lbl.BackColor = color;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
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
            this.Close();
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            this.lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            this.ChangeCloseMinMaxBg(this.lblClose);
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
            }
            catch { return 0; }
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


        private void btnCancel(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlAceptar_Paint(object sender, PaintEventArgs e)
        {

        }








        /*
        .
        .
        .
        */
    }
}
