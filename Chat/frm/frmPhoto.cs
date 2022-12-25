using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

// []   |||   &&

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmPhoto : frmResize
    {
        //Settings
        public static frmPhoto frm;
        private int curX;
        private int curY;
        private bool dragging;
        private bool dragging1;
        private Bitmap m_CroppedBm;
        private Bitmap m_CroppedSmallBm;

        public int PhotoWidth { get; set; }
        public int PhotoHeight { get; set; }
        private static string _OriginalFileName { get; set; }


        /////////////////////////////////////////////////////////////////////////

        public string ActivePluginName => _activePluginName;
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


        public frmPhoto()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            base.KeyDown += frmPhoto_KeyDown;
            base.Load += frmPhoto_Load;
            frm = this;
            _OriginalFileName = string.Empty;
            lblResize.DragLeave += lblResize_DragLeave;
            lblResize.MouseDown += lblResize_MouseDown;
            lblResize.MouseHover += lblResize_MouseHover;
            lblResize.MouseMove += lblResize_MouseMove;
            lblResize.MouseUp += lblResize_MouseUp;
            lblSelector.MouseDown += lblSelector_MouseDown;
            lblSelector.MouseMove += lblSelector_MouseMove;
            lblSelector.MouseUp += lblSelector_MouseUp;

        }
        public void adjustResizePos(int x, int y)
        {
            try
            {
                ResizeControlLocation();
                int width;
                int height;
                using (Image image = Modcommon.ImageFromFile(_OriginalFileName))
                {
                    width = image.Width;
                    height = image.Height;
                }
                int width2;
                int height2;
                using (Bitmap bitmap = new Bitmap(picSelectPhoto.Image))
                {
                    width2 = bitmap.Width;
                    height2 = bitmap.Height;
                }
                decimal d = new decimal((double)width / (double)width2);
                decimal d2 = new decimal((double)height / (double)height2);
                using (Bitmap image2 = new Bitmap(_OriginalFileName))
                {
                    decimal value = decimal.Multiply(new decimal(lblSelector.Location.X), d);
                    decimal value2 = decimal.Multiply(new decimal(lblSelector.Location.Y), d2);
                    decimal value3 = decimal.Multiply(new decimal(lblSelector.Width), d);
                    decimal value4 = decimal.Multiply(new decimal(lblSelector.Height), d2);
                    Rectangle srcRect = new Rectangle(Convert.ToInt32(value), Convert.ToInt32(value2), Convert.ToInt32(value3), Convert.ToInt32(value4));
                    Rectangle destRect = new Rectangle(0, 0, pctPhoto.Width, pctPhoto.Height);
                    m_CroppedBm = new Bitmap(pctPhoto.Width, pctPhoto.Height);
                    using (Graphics graphics = Graphics.FromImage(m_CroppedBm))
                    {
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(image2, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    pctPhoto.Image = m_CroppedBm;
                    destRect = new Rectangle(0, 0, picSmall.Width, picSmall.Height);
                    m_CroppedSmallBm = new Bitmap(picSmall.Width, picSmall.Height);
                    using (Graphics graphics2 = Graphics.FromImage(m_CroppedSmallBm))
                    {
                        graphics2.SmoothingMode = SmoothingMode.HighQuality;
                        graphics2.CompositingQuality = CompositingQuality.HighQuality;
                        graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics2.DrawImage(image2, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    //m_CroppedBm.Save(Path.Combine(Modcommon.FOLDER_PATH, "Avatars", frmMain.NickName + ".jpg"), ImageFormat.Jpeg);
                    picSmall.Image = m_CroppedSmallBm;
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
        private void frmPhoto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        private void frmPhoto_Load(object sender, EventArgs e)
        {
            try
            {
                lblSelector.Size = new Size(Modcommon.PROFILE_SIZE, Modcommon.PROFILE_SIZE);
                lblSelector.Location = new Point(76, 69);
                lblSelector.Parent = picSelectPhoto;
                ResizeControlLocation();
                base.Top = (int)(unchecked(Modcommon.SystemVirtualScreenHeight() / 2) - unchecked(base.Height / 2));
                base.Left = (int)(unchecked(Modcommon.SystemVirtualScreenWidth() / 2) - unchecked(base.Width / 2));
                adjustResizePos(lblSelector.Location.X, lblSelector.Location.Y);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        private void lblOkPhoto_Click(object sender, EventArgs e)
        {
            frmSettings.frm.pctPhoto.Image = m_CroppedBm;
            frmSettings.frm.pctPhoto.Tag = "1";

            string destPath = Application.StartupPath + @"\Avatars\" + frmMain.UserId + ".jpg";
            ImageHandler.Resize((Bitmap)pctPhoto.Image, 1000, 1000, destPath);
            frmMain.Avatarlength = Modcommon.GetAvatarlength();
            Close();
        }
        private void lblCancelPhoto_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblResize_DragLeave(object sender, EventArgs e)
        {
            adjustResizePos(lblSelector.Location.X, lblSelector.Location.Y);
        }
        private void lblResize_MouseDown(object sender, MouseEventArgs e)
        {
            curX = e.X;
            curY = e.Y;
            dragging1 = true;
            lblSelector.SuspendLayout();
            lblResize.Cursor = Cursors.SizeNWSE;
        }
        private void lblResize_MouseHover(object sender, EventArgs e)
        {
            lblResize.Cursor = Cursors.SizeNWSE;
        }
        private void lblResize_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (dragging1)
                {
                    lblSelector.Cursor = Cursors.SizeAll;
                    Control control = (Control)sender;
                    checked
                    {
                        int num = control.Left + e.X - curX - lblSelector.Left;
                        int num2 = control.Top + e.Y - curY - lblSelector.Top;
                        if (num >= 0 && num2 >= 0 && (lblSelector.Height + lblSelector.Top <= picSelectPhoto.Height || num2 <= lblSelector.Height) && (lblSelector.Width + lblSelector.Left <= picSelectPhoto.Width || num <= lblSelector.Width))
                        {
                            lblSelector.Width = control.Left + e.X - curX - lblSelector.Left;
                            lblSelector.Height = lblSelector.Width;
                            if (lblSelector.Height + lblSelector.Top > picSelectPhoto.Height)
                            {
                                lblSelector.Height -= lblSelector.Height + lblSelector.Top - picSelectPhoto.Height;
                            }
                            if (lblSelector.Width + lblSelector.Left > picSelectPhoto.Width)
                            {
                                lblSelector.Width -= lblSelector.Width + lblSelector.Left - picSelectPhoto.Width;
                            }
                            ResizeControlLocation();
                            control.BringToFront();
                            control.Invalidate();
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
        private void lblResize_MouseUp(object sender, MouseEventArgs e)
        {
            dragging1 = false;
            dragging = false;
            lblSelector.BorderStyle = BorderStyle.Fixed3D;
            adjustResizePos(lblSelector.Location.X, lblSelector.Location.Y);

        }
        private void lblSelector_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            lblSelector.BringToFront();
            curX = e.X;
            curY = e.Y;
            lblSelector.Cursor = Cursors.SizeAll;
        }
        private void lblSelector_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                try
                {
                    if (dragging && lblSelector.Left + e.X - curX >= 1 && lblSelector.Top + e.Y - curY >= 1 && lblSelector.Left + e.X - curX + lblSelector.Width <= picSelectPhoto.Width && lblSelector.Top + e.Y - curY + lblSelector.Height <= picSelectPhoto.Height)
                    {
                        lblSelector.Left = lblSelector.Left + e.X - curX;
                        lblSelector.Top = lblSelector.Top + e.Y - curY;
                        ResizeControlLocation();
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
        private void lblSelector_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                dragging = false;
                dragging1 = false;
                adjustResizePos(lblSelector.Location.X, lblSelector.Location.Y);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }
        private void ResizeControlLocation()
        {
            try
            {
                lblResize.Location = checked(new Point(lblSelector.Left + lblSelector.Width + picSelectPhoto.Left - lblResize.Width - 1, lblSelector.Top + lblSelector.Height + picSelectPhoto.Top - lblResize.Height - 1));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }




        public Image ResizeImage(string originalImageFileName, Image image, Size size, bool preserveAspectRatio = true)
        {
            _OriginalFileName = originalImageFileName;
            Image result = default(Image);
            try
            {
                int width2;
                int height2;
                if (preserveAspectRatio)
                {
                    int width = image.Width;
                    int height = image.Height;
                    float num = (float)size.Width / (float)width;
                    float num2 = (float)size.Height / (float)height;
                    float num3 = (num2 < num) ? num2 : num;
                    checked
                    {
                        width2 = (int)Math.Round((double)unchecked((float)width * num3));
                        height2 = (int)Math.Round((double)unchecked((float)height * num3));
                    }
                }
                else
                {
                    width2 = size.Width;
                    height2 = size.Height;
                }
                Image image2 = new Bitmap(width2, height2);
                using (Graphics graphics = Graphics.FromImage(image2))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(image, 0, 0, width2, height2);
                }
                result = image2;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
                return result;
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
                //if (Modcommon.DEFAULTVIEW)
                //    FlashWin.StopWin(this.Handle);
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
            //if (!Modcommon.DEFAULTVIEW)
            //   Modcommon.MAIN_CLOSE = true;
            this.Close();
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            this.lblClose.BackColor = ColorTranslator.FromHtml("#c75050");
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
