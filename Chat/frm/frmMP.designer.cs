using Chat.Properties;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chat
{
    partial class frmMP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMP));
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
            this.userPanel = new System.Windows.Forms.Panel();
            this.txtMessages = new System.Windows.Forms.RichTextBox();
            this.AvatarUserPanel = new System.Windows.Forms.PictureBox();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblWelcomeUserPanel = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOMicon = new System.Windows.Forms.PictureBox();
            this.pnlPhotocenter.SuspendLayout();
            this.pnlPhotoleft.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarUserPanel)).BeginInit();
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
            this.pnlPhotocenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhotocenter.Controls.Add(this.pnlPhotoleft);
            this.pnlPhotocenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotocenter.Location = new System.Drawing.Point(4, 29);
            this.pnlPhotocenter.Name = "pnlPhotocenter";
            this.pnlPhotocenter.Size = new System.Drawing.Size(369, 96);
            this.pnlPhotocenter.TabIndex = 95;
            // 
            // pnlPhotoleft
            // 
            this.pnlPhotoleft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhotoleft.Controls.Add(this.pnlPhoto);
            this.pnlPhotoleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotoleft.Location = new System.Drawing.Point(0, 0);
            this.pnlPhotoleft.Name = "pnlPhotoleft";
            this.pnlPhotoleft.Size = new System.Drawing.Size(369, 96);
            this.pnlPhotoleft.TabIndex = 4;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhoto.Controls.Add(this.userPanel);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 0);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(369, 96);
            this.pnlPhoto.TabIndex = 3;
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.userPanel.Controls.Add(this.txtMessages);
            this.userPanel.Controls.Add(this.AvatarUserPanel);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(369, 93);
            this.userPanel.TabIndex = 26;
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.Location = new System.Drawing.Point(94, 6);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(270, 79);
            this.txtMessages.TabIndex = 2;
            this.txtMessages.Text = "";
            // 
            // AvatarUserPanel
            // 
            this.AvatarUserPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.AvatarUserPanel.Location = new System.Drawing.Point(5, 5);
            this.AvatarUserPanel.Name = "AvatarUserPanel";
            this.AvatarUserPanel.Size = new System.Drawing.Size(83, 83);
            this.AvatarUserPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AvatarUserPanel.TabIndex = 0;
            this.AvatarUserPanel.TabStop = false;
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlTitlebar.Controls.Add(this.lblWelcomeUserPanel);
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Controls.Add(this.lblOMicon);
            this.pnlTitlebar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(4, 4);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(369, 25);
            this.pnlTitlebar.TabIndex = 0;
            this.pnlTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            // 
            // lblWelcomeUserPanel
            // 
            this.lblWelcomeUserPanel.AutoSize = true;
            this.lblWelcomeUserPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUserPanel.Location = new System.Drawing.Point(34, 4);
            this.lblWelcomeUserPanel.Name = "lblWelcomeUserPanel";
            this.lblWelcomeUserPanel.Size = new System.Drawing.Size(0, 16);
            this.lblWelcomeUserPanel.TabIndex = 1;
            this.lblWelcomeUserPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.lblWelcomeUserPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.lblWelcomeUserPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(331, 0);
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
            // frmMP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(377, 129);
            this.Controls.Add(this.pnlPhotocenter);
            this.Controls.Add(this.pnlTitlebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(377, 129);
            this.MinimumSize = new System.Drawing.Size(377, 129);
            this.Name = "frmMP";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainfrm";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.pnlPhotocenter.ResumeLayout(false);
            this.pnlPhotoleft.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.userPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarUserPanel)).EndInit();
            this.pnlTitlebar.ResumeLayout(false);
            this.pnlTitlebar.PerformLayout();
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
        private Panel userPanel;
        private Label lblWelcomeUserPanel;
        private PictureBox AvatarUserPanel;
        private RichTextBox txtMessages;
    }
}