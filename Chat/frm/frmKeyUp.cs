using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

// []   |||   &&

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmKeyUp : frmResize
    {
        //Settings
        public static frmKeyUp frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        /////////////////////////////////////////////////////////////////////////


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


        public frmKeyUp()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;

            MoveToTopMost(this.Handle);
            txtKey.Focus();

        }
        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

        private void MoveToTopMost(IntPtr handle)
        {
            NativeMethods.SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
        }
        private void ChangeActiveColor()
        {
            this.ChangeControlBGColor(Color.FromArgb(49, 140, 231));
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (this.Location.X < 0 || this.Location.Y < 0)
                    this.BringToFront();
                this.ChangeActiveColor();
                txtKey.Focus();

            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }


        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.ChangeDeActiveColor();
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
            txtKey.Focus();
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

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            string keypressed = e.KeyCode.ToString();
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else
            {
                frmSettings.frm.lblKeyUp.Text = keypressed;
                frmMain.KeyTop = keypressed;
                Close();
            }
        }

        private void frmKeyUp_Load(object sender, EventArgs e)
        {
            txtKey.Focus();
        }

        private void frmKeyUp_Click(object sender, EventArgs e)
        {
            txtKey.Focus();
        }
    }
}
