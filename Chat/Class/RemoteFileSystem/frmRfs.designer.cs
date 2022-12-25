using Chat;
using Chat.Properties;
using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteFileSystemTester
{
    partial class frmRfs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRfs));
            this.tvPaths = new System.Windows.Forms.TreeView();
            this.ilGlobal = new System.Windows.Forms.ImageList(this.components);
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastModDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.currentPath = new System.Windows.Forms.ToolStripTextBox();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.btConnect = new System.Windows.Forms.ToolStripButton();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.pbFileTransfer = new System.Windows.Forms.ToolStripProgressBar();
            this.btTransferCancel = new System.Windows.Forms.ToolStripButton();
            this.lvRemoteSystemHeader = new System.Windows.Forms.ListView();
            this.colRemoteSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SteamBox = new System.Windows.Forms.PictureBox();
            this.CerrarBox = new System.Windows.Forms.PictureBox();
            this.MiniBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SteamBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CerrarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiniBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tvPaths
            // 
            this.tvPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPaths.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvPaths.FullRowSelect = true;
            this.tvPaths.ImageIndex = 0;
            this.tvPaths.ImageList = this.ilGlobal;
            this.tvPaths.Location = new System.Drawing.Point(0, 57);
            this.tvPaths.Name = "tvPaths";
            this.tvPaths.SelectedImageIndex = 0;
            this.tvPaths.ShowLines = false;
            this.tvPaths.ShowRootLines = false;
            this.tvPaths.Size = new System.Drawing.Size(194, 456);
            this.tvPaths.TabIndex = 0;
            this.tvPaths.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPaths_BeforeCollapse);
            this.tvPaths.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPaths_BeforeExpand);
            this.tvPaths.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvPaths_AfterExpand);
            this.tvPaths.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPaths_AfterSelect);
            this.tvPaths.DoubleClick += new System.EventHandler(this.tvPaths_DoubleClick);
            this.tvPaths.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvPaths_MouseDown);
            // 
            // ilGlobal
            // 
            this.ilGlobal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilGlobal.ImageStream")));
            this.ilGlobal.TransparentColor = System.Drawing.Color.Transparent;
            this.ilGlobal.Images.SetKeyName(0, "drive-harddisk-8.png");
            this.ilGlobal.Images.SetKeyName(1, "text-x-generic-template.png");
            this.ilGlobal.Images.SetKeyName(2, "folder-open-5.png");
            this.ilGlobal.Images.SetKeyName(3, "computer-4.png");
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItemName,
            this.chLastModDate,
            this.chType,
            this.chFileSize});
            this.lvFiles.LargeImageList = this.ilGlobal;
            this.lvFiles.Location = new System.Drawing.Point(194, 33);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(446, 480);
            this.lvFiles.SmallImageList = this.ilGlobal;
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            this.lvFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvFiles_MouseDown);
            this.lvFiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvFiles_MouseMove);
            this.lvFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvFiles_MouseUp);
            // 
            // chItemName
            // 
            this.chItemName.Text = "Name";
            this.chItemName.Width = 175;
            // 
            // chLastModDate
            // 
            this.chLastModDate.Text = "Last Modified";
            this.chLastModDate.Width = 75;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            // 
            // chFileSize
            // 
            this.chFileSize.Text = "Size";
            this.chFileSize.Width = 75;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentPath,
            this.tsbBack,
            this.btConnect});
            this.toolStrip1.Location = new System.Drawing.Point(-100, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(51, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // currentPath
            // 
            this.currentPath.AutoSize = false;
            this.currentPath.Name = "currentPath";
            this.currentPath.Size = new System.Drawing.Size(0, 23);
            // 
            // tsbBack
            // 
            this.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(23, 22);
            this.tsbBack.Text = "Back";
            this.tsbBack.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btConnect
            // 
            this.btConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btConnect.Image = ((System.Drawing.Image)(resources.GetObject("btConnect.Image")));
            this.btConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(23, 22);
            this.btConnect.Text = "Connect to the server.";
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbFileTransfer,
            this.btTransferCancel});
            this.tsMain.Location = new System.Drawing.Point(0, 511);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsMain.Size = new System.Drawing.Size(640, 25);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip2";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 22);
            this.lblStatus.Text = "Idle.";
            // 
            // pbFileTransfer
            // 
            this.pbFileTransfer.Name = "pbFileTransfer";
            this.pbFileTransfer.Size = new System.Drawing.Size(100, 22);
            this.pbFileTransfer.Visible = false;
            // 
            // btTransferCancel
            // 
            this.btTransferCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btTransferCancel.Image = ((System.Drawing.Image)(resources.GetObject("btTransferCancel.Image")));
            this.btTransferCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTransferCancel.Name = "btTransferCancel";
            this.btTransferCancel.Size = new System.Drawing.Size(23, 22);
            this.btTransferCancel.Text = "Cancel";
            this.btTransferCancel.Visible = false;
            this.btTransferCancel.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // lvRemoteSystemHeader
            // 
            this.lvRemoteSystemHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRemoteSystemHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRemoteSystemHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRemoteSystem});
            this.lvRemoteSystemHeader.Location = new System.Drawing.Point(0, 33);
            this.lvRemoteSystemHeader.Name = "lvRemoteSystemHeader";
            this.lvRemoteSystemHeader.Size = new System.Drawing.Size(203, 38);
            this.lvRemoteSystemHeader.TabIndex = 5;
            this.lvRemoteSystemHeader.UseCompatibleStateImageBehavior = false;
            this.lvRemoteSystemHeader.View = System.Windows.Forms.View.Details;
            // 
            // colRemoteSystem
            // 
            this.colRemoteSystem.Text = "Remote System";
            this.colRemoteSystem.Width = 177;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.panel3.Controls.Add(this.SteamBox);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 32);
            this.panel3.TabIndex = 53;
            // 
            // SteamBox
            // 
            //this.SteamBox.Image = Resources.folder_remote1;
            this.SteamBox.Location = new System.Drawing.Point(3, 1);
            this.SteamBox.Name = "SteamBox";
            this.SteamBox.Size = new System.Drawing.Size(37, 28);
            this.SteamBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SteamBox.TabIndex = 0;
            this.SteamBox.TabStop = false;
            this.SteamBox.Click += new System.EventHandler(this.SteamBox_Click);
            // 
            // CerrarBox
            // 
            this.CerrarBox.Image = Resources.CerrarOscuro_1;
            this.CerrarBox.Location = new System.Drawing.Point(593, 0);
            this.CerrarBox.Name = "CerrarBox";
            this.CerrarBox.Size = new System.Drawing.Size(46, 32);
            this.CerrarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CerrarBox.TabIndex = 54;
            this.CerrarBox.TabStop = false;
            this.CerrarBox.Click += new System.EventHandler(this.CerrarBox_Click);
            this.CerrarBox.MouseLeave += new System.EventHandler(this.CerrarBox_MouseLeave);
            this.CerrarBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CerrarBox_MouseMove);
            // 
            // MiniBox
            // 
            this.MiniBox.BackColor = System.Drawing.Color.Transparent;
            this.MiniBox.Image = Resources.MinimizeOscuro_1;
            this.MiniBox.Location = new System.Drawing.Point(545, 0);
            this.MiniBox.Name = "MiniBox";
            this.MiniBox.Size = new System.Drawing.Size(46, 32);
            this.MiniBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MiniBox.TabIndex = 55;
            this.MiniBox.TabStop = false;
            this.MiniBox.Click += new System.EventHandler(this.MiniBox_Click);
            this.MiniBox.MouseLeave += new System.EventHandler(this.MiniBox_MouseLeave);
            this.MiniBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MiniBox_MouseMove);
            // 
            // frmRfs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(640, 536);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.MiniBox);
            this.Controls.Add(this.CerrarBox);
            this.Controls.Add(this.tvPaths);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.lvRemoteSystemHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmRfs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote File System view and file copy utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.frmRfs_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmRfs_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmRfs_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmRfs_MouseUp);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SteamBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CerrarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiniBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public ImageList ilGlobal;
        public ColumnHeader chItemName;
        public ColumnHeader chLastModDate;
        public ColumnHeader chType;
        public ColumnHeader chFileSize;
        public ToolStrip toolStrip1;
        public ToolStripTextBox currentPath;
        public ToolStrip tsMain;
        public ToolStripLabel lblStatus;
        public ListView lvRemoteSystemHeader;
        public ColumnHeader colRemoteSystem;
        public ToolStripButton btConnect;
        public ToolStripProgressBar pbFileTransfer;
        public ToolStripButton btTransferCancel;
        public FolderBrowserDialog folderBrowserDialog1;
        public ToolStripButton tsbBack;
        public Panel panel3;
        public PictureBox SteamBox;
        public PictureBox CerrarBox;
        public PictureBox MiniBox;
        public ListView lvFiles;
        public TreeView tvPaths;
        private IContainer components;
    }
}

