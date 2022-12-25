using System.ComponentModel;
using System.Windows.Forms;
using Chat.Forms;
using Chat.Properties;

namespace Chat
{
    partial class frmCP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCP));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TicToc = new System.Windows.Forms.Timer(this.components);
            this.pnlPhotocenter = new System.Windows.Forms.Panel();
            this.pnlPhotoleft = new System.Windows.Forms.Panel();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.webChat = new WebBrowserEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcomeUserPanel = new System.Windows.Forms.Label();
            this.picFrom = new System.Windows.Forms.PictureBox();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOMicon = new System.Windows.Forms.PictureBox();
            this.pnlPhotocenter.SuspendLayout();
            this.pnlPhotoleft.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrom)).BeginInit();
            this.pnlTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).BeginInit();
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
            // pnlPhotocenter
            // 
            this.pnlPhotocenter.Controls.Add(this.pnlPhotoleft);
            this.pnlPhotocenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotocenter.Location = new System.Drawing.Point(0, 25);
            this.pnlPhotocenter.Name = "pnlPhotocenter";
            this.pnlPhotocenter.Size = new System.Drawing.Size(490, 297);
            this.pnlPhotocenter.TabIndex = 95;
            // 
            // pnlPhotoleft
            // 
            this.pnlPhotoleft.Controls.Add(this.pnlPhoto);
            this.pnlPhotoleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotoleft.Location = new System.Drawing.Point(0, 0);
            this.pnlPhotoleft.Name = "pnlPhotoleft";
            this.pnlPhotoleft.Size = new System.Drawing.Size(490, 297);
            this.pnlPhotoleft.TabIndex = 4;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BackColor = System.Drawing.Color.White;
            this.pnlPhoto.Controls.Add(this.panel6);
            this.pnlPhoto.Controls.Add(this.panel2);
            this.pnlPhoto.Controls.Add(this.panel1);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 0);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(490, 297);
            this.pnlPhoto.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtSend);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 247);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 50);
            this.panel6.TabIndex = 2;
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.Location = new System.Drawing.Point(5, 0);
            this.txtSend.MaxLength = 0;
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(480, 50);
            this.txtSend.TabIndex = 0;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(485, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 50);
            this.panel9.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 50);
            this.panel7.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 50);
            this.panel8.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.webChat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 203);
            this.panel2.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(231)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 200);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(490, 3);
            this.panel11.TabIndex = 28;
            // 
            // webChat
            // 
            this.webChat.AllowWebBrowserDrop = false;
            this.webChat.IsWebBrowserContextMenuEnabled = false;
            this.webChat.Location = new System.Drawing.Point(0, 0);
            this.webChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChat.Name = "webChat";
            this.webChat.Size = new System.Drawing.Size(490, 210);
            this.webChat.TabIndex = 27;
            this.webChat.WebBrowserShortcutsEnabled = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.lblWelcomeUserPanel);
            this.panel1.Controls.Add(this.picFrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 44);
            this.panel1.TabIndex = 0;
            // 
            // lblWelcomeUserPanel
            // 
            this.lblWelcomeUserPanel.AutoSize = true;
            this.lblWelcomeUserPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUserPanel.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeUserPanel.Location = new System.Drawing.Point(49, 3);
            this.lblWelcomeUserPanel.Name = "lblWelcomeUserPanel";
            this.lblWelcomeUserPanel.Size = new System.Drawing.Size(122, 16);
            this.lblWelcomeUserPanel.TabIndex = 1;
            this.lblWelcomeUserPanel.Text = "Conversación privada";
            this.lblWelcomeUserPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.lblWelcomeUserPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.lblWelcomeUserPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // picFrom
            // 
            this.picFrom.Location = new System.Drawing.Point(3, 2);
            this.picFrom.Name = "picFrom";
            this.picFrom.Size = new System.Drawing.Size(40, 40);
            this.picFrom.TabIndex = 0;
            this.picFrom.TabStop = false;
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Controls.Add(this.lblOMicon);
            this.pnlTitlebar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(490, 25);
            this.pnlTitlebar.TabIndex = 0;
            this.pnlTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.pnlTitlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.pnlTitlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(452, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(38, 25);
            this.lblClose.TabIndex = 0;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblOMicon
            // 
            this.lblOMicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblOMicon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOMicon.Image = global::Chat.Properties.Resources.Logo_SC;
            this.lblOMicon.Location = new System.Drawing.Point(0, 0);
            this.lblOMicon.Name = "lblOMicon";
            this.lblOMicon.Size = new System.Drawing.Size(30, 25);
            this.lblOMicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblOMicon.TabIndex = 1;
            this.lblOMicon.TabStop = false;
            this.lblOMicon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.lblOMicon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.lblOMicon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // frmCP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(490, 322);
            this.Controls.Add(this.pnlPhotocenter);
            this.Controls.Add(this.pnlTitlebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(490, 322);
            this.MinimumSize = new System.Drawing.Size(490, 322);
            this.Name = "frmCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainfrm";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.pnlPhotocenter.ResumeLayout(false);
            this.pnlPhotoleft.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrom)).EndInit();
            this.pnlTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Panel panel10;
        public Panel pnlTitlebar;
        public TabPage tabPage1;
        public TabPage tabPage2;
        public Label lblClose;
        public PictureBox lblOMicon;
        private IContainer components;
        private Timer TicToc;
        private Panel pnlPhotocenter;
        private Panel pnlPhotoleft;
        public Panel pnlPhoto;
        private Panel panel6;
        private Panel panel2;
        private Panel panel1;
        private PictureBox picFrom;
        public WebBrowserEx webChat;
        private Panel panel9;
        private Panel panel7;
        private Panel panel8;
        public TextBox txtSend;
        private Panel panel11;
        private Label lblWelcomeUserPanel;
    }
}