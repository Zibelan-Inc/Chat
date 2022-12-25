using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using BearWare;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

// []   |||   &&

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmFileTransfer : frmResize
    {
        //Settings
        public static frmFileTransfer frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        TeamTalk4 ttclient;
        int transferid;
        /////////////////////////////////////////////////////////////////////////

        public IEnumerator enumerator;
        public bool _SExit;
        public bool _Exit;
        public bool deactivatemain;
        public bool _isSplitterMoving;
        public string _searchPluginName;
        public bool _hidesearch;
        public static FlowLayoutPanel pnlAnnouncement = new FlowLayoutPanel();

        public RegistryKey Chat;




        public frmFileTransfer(TeamTalk4 tt, int transferid)
        {
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;
            this.ttclient = tt;
            this.transferid = transferid;
            InitializeComponent();
            ttclient.OnFileTransfer += new TeamTalk4.FileTransferUpdate(ttclient_OnFileTransfer);
            UpdateFileTransfer();

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
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateFileTransfer();
        }

        void UpdateFileTransfer()
        {
            FileTransfer transfer = new FileTransfer();
            if (ttclient.GetFileTransferInfo(transferid, out transfer))
            {
                if (transfer.nTransferred == transfer.nFileSize)
                {
                    timer1.Enabled = false;
                }

                filenameTextBox.Text = transfer.szRemoteFileName;
                filesizeTextBox.Text = Modcommon.LongToMbytes(transfer.nFileSize);

                if (transfer.nFileSize > 0)
                {
                    float percent = (float)transfer.nTransferred / (float)transfer.nFileSize;
                    progressBar1.Value = (int)(percent * 100.0f);
                }
            }
        }
        void ttclient_OnFileTransfer(int transferID, FileTransferStatus filetransfer)
        {
            transferid = transferID;

            switch (filetransfer)
            {
                case FileTransferStatus.FILETRANSFER_STARTED:
                    break;
                case FileTransferStatus.FILETRANSFER_ERROR:
                    timer1.Enabled = false;
                    break;
                case FileTransferStatus.FILETRANSFER_FINISHED:
                    progressBar1.Value = progressBar1.Maximum;
                    timer1.Enabled = false;
                    this.Close();
                    break;
            }
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
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.ChangeDeActiveColor();
                this.deactivatemain = true;
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

        private void pnlCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            lblCancel.ForeColor = Color.WhiteSmoke;
        }
        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {
            lblCancel.ForeColor = Color.White;
        }
        private void lblHide_MouseMove(object sender, MouseEventArgs e)
        {
            lblHide.ForeColor = Color.WhiteSmoke;
        }

        private void btnHide_MouseLeave(object sender, EventArgs e)
        {
            lblHide.ForeColor = Color.White;
        }

        private void lblCancel_MouseClick(object sender, MouseEventArgs e)
        {
            ttclient.CancelFileTranfer(transferid);
            Close();
        }

        private void lblHide_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        /*
        .
        .
        .
        */
    }
}
