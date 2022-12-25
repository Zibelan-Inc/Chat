using Chat.Properties;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chat
{
    partial class frmPhoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhoto));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblCmpname = new DragLabel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOMicon = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TicToc = new System.Windows.Forms.Timer(this.components);
            this.pnlCancelar = new System.Windows.Forms.Panel();
            this.lblCancelar = new HackLabel(this.components);
            this.pnlAceptar = new System.Windows.Forms.Panel();
            this.lblAceptar = new HackLabel(this.components);
            this.pnlPhotocenter = new System.Windows.Forms.Panel();
            this.pnlPhotoleft = new System.Windows.Forms.Panel();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.lblResize = new System.Windows.Forms.Label();
            this.lblSelector = new System.Windows.Forms.Label();
            this.picSelectPhoto = new System.Windows.Forms.PictureBox();
            this.pnlPhotoright = new System.Windows.Forms.Panel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picSmall = new System.Windows.Forms.PictureBox();
            this.lblPreView = new System.Windows.Forms.Label();
            this.pctPhoto = new System.Windows.Forms.PictureBox();
            this.pnlTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).BeginInit();
            this.pnlCancelar.SuspendLayout();
            this.pnlAceptar.SuspendLayout();
            this.pnlPhotocenter.SuspendLayout();
            this.pnlPhotoleft.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectPhoto)).BeginInit();
            this.pnlPhotoright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).BeginInit();
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
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.pnlTitlebar.Controls.Add(this.lblCmpname);
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Controls.Add(this.lblOMicon);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(4, 4);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(652, 25);
            this.pnlTitlebar.TabIndex = 0;
            // 
            // lblCmpname
            // 
            this.lblCmpname.AutoEllipsis = true;
            this.lblCmpname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblCmpname.ContainerForm = this;
            this.lblCmpname.ContainerFrm = null;
            this.lblCmpname.CopyTextOnDoubleClick = false;
            this.lblCmpname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCmpname.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmpname.ForeColor = System.Drawing.Color.Black;
            this.lblCmpname.Location = new System.Drawing.Point(30, 0);
            this.lblCmpname.Name = "lblCmpname";
            this.lblCmpname.Size = new System.Drawing.Size(572, 25);
            this.lblCmpname.TabIndex = 18;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(602, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(50, 25);
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
            // pnlCancelar
            // 
            this.pnlCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.pnlCancelar.Controls.Add(this.lblCancelar);
            this.pnlCancelar.Location = new System.Drawing.Point(141, 390);
            this.pnlCancelar.Name = "pnlCancelar";
            this.pnlCancelar.Size = new System.Drawing.Size(88, 31);
            this.pnlCancelar.TabIndex = 94;
            this.pnlCancelar.Click += new System.EventHandler(this.btnCancel);
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
            this.lblCancelar.Click += new System.EventHandler(this.btnCancel);
            // 
            // pnlAceptar
            // 
            this.pnlAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.pnlAceptar.Controls.Add(this.lblAceptar);
            this.pnlAceptar.Location = new System.Drawing.Point(47, 390);
            this.pnlAceptar.Name = "pnlAceptar";
            this.pnlAceptar.Size = new System.Drawing.Size(88, 31);
            this.pnlAceptar.TabIndex = 93;
            this.pnlAceptar.Click += new System.EventHandler(this.lblOkPhoto_Click);
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
            this.lblAceptar.Click += new System.EventHandler(this.lblOkPhoto_Click);
            // 
            // pnlPhotocenter
            // 
            this.pnlPhotocenter.Controls.Add(this.pnlPhotoleft);
            this.pnlPhotocenter.Controls.Add(this.pnlPhotoright);
            this.pnlPhotocenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotocenter.Location = new System.Drawing.Point(4, 29);
            this.pnlPhotocenter.Name = "pnlPhotocenter";
            this.pnlPhotocenter.Size = new System.Drawing.Size(652, 425);
            this.pnlPhotocenter.TabIndex = 95;
            // 
            // pnlPhotoleft
            // 
            this.pnlPhotoleft.Controls.Add(this.pnlPhoto);
            this.pnlPhotoleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotoleft.Location = new System.Drawing.Point(0, 0);
            this.pnlPhotoleft.Name = "pnlPhotoleft";
            this.pnlPhotoleft.Size = new System.Drawing.Size(415, 425);
            this.pnlPhotoleft.TabIndex = 4;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhoto.Controls.Add(this.lblResize);
            this.pnlPhoto.Controls.Add(this.lblSelector);
            this.pnlPhoto.Controls.Add(this.picSelectPhoto);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 0);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(415, 425);
            this.pnlPhoto.TabIndex = 3;
            // 
            // lblResize
            // 
            this.lblResize.AllowDrop = true;
            this.lblResize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblResize.Location = new System.Drawing.Point(186, 176);
            this.lblResize.Name = "lblResize";
            this.lblResize.Size = new System.Drawing.Size(9, 9);
            this.lblResize.TabIndex = 7;
            // 
            // lblSelector
            // 
            this.lblSelector.AllowDrop = true;
            this.lblSelector.BackColor = System.Drawing.Color.Transparent;
            this.lblSelector.Location = new System.Drawing.Point(76, 69);
            this.lblSelector.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelector.MinimumSize = new System.Drawing.Size(38, 38);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(200, 200);
            this.lblSelector.TabIndex = 5;
            // 
            // picSelectPhoto
            // 
            this.picSelectPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectPhoto.Image = global::Chat.Properties.Resources.male;
            this.picSelectPhoto.Location = new System.Drawing.Point(0, 0);
            this.picSelectPhoto.Name = "picSelectPhoto";
            this.picSelectPhoto.Size = new System.Drawing.Size(18, 18);
            this.picSelectPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSelectPhoto.TabIndex = 4;
            this.picSelectPhoto.TabStop = false;
            // 
            // pnlPhotoright
            // 
            this.pnlPhotoright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhotoright.Controls.Add(this.TableLayoutPanel1);
            this.pnlPhotoright.Controls.Add(this.picSmall);
            this.pnlPhotoright.Controls.Add(this.pnlCancelar);
            this.pnlPhotoright.Controls.Add(this.pnlAceptar);
            this.pnlPhotoright.Controls.Add(this.lblPreView);
            this.pnlPhotoright.Controls.Add(this.pctPhoto);
            this.pnlPhotoright.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPhotoright.Location = new System.Drawing.Point(415, 0);
            this.pnlPhotoright.Name = "pnlPhotoright";
            this.pnlPhotoright.Size = new System.Drawing.Size(237, 425);
            this.pnlPhotoright.TabIndex = 3;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.AutoSize = true;
            this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.Location = new System.Drawing.Point(233, 421);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.TableLayoutPanel1.TabIndex = 44;
            // 
            // picSmall
            // 
            this.picSmall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.picSmall.Location = new System.Drawing.Point(20, 246);
            this.picSmall.Name = "picSmall";
            this.picSmall.Size = new System.Drawing.Size(38, 38);
            this.picSmall.TabIndex = 42;
            this.picSmall.TabStop = false;
            this.picSmall.Visible = false;
            // 
            // lblPreView
            // 
            this.lblPreView.AutoSize = true;
            this.lblPreView.BackColor = System.Drawing.Color.White;
            this.lblPreView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreView.Location = new System.Drawing.Point(4, 4);
            this.lblPreView.Name = "lblPreView";
            this.lblPreView.Size = new System.Drawing.Size(67, 15);
            this.lblPreView.TabIndex = 13;
            this.lblPreView.Text = "Vista previa";
            this.lblPreView.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pctPhoto
            // 
            this.pctPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pctPhoto.Location = new System.Drawing.Point(9, 21);
            this.pctPhoto.Name = "pctPhoto";
            this.pctPhoto.Size = new System.Drawing.Size(220, 220);
            this.pctPhoto.TabIndex = 12;
            this.pctPhoto.TabStop = false;
            // 
            // frmPhoto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(660, 458);
            this.Controls.Add(this.pnlPhotocenter);
            this.Controls.Add(this.pnlTitlebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(660, 458);
            this.MinimumSize = new System.Drawing.Size(660, 458);
            this.Name = "frmPhoto";
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
            this.pnlTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).EndInit();
            this.pnlCancelar.ResumeLayout(false);
            this.pnlCancelar.PerformLayout();
            this.pnlAceptar.ResumeLayout(false);
            this.pnlAceptar.PerformLayout();
            this.pnlPhotocenter.ResumeLayout(false);
            this.pnlPhotoleft.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectPhoto)).EndInit();
            this.pnlPhotoright.ResumeLayout(false);
            this.pnlPhotoright.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).EndInit();
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
        public DragLabel lblCmpname;
        private IContainer components;
        private Timer TicToc;
        private Panel pnlCancelar;
        private HackLabel lblCancelar;
        private Panel pnlAceptar;
        private HackLabel lblAceptar;
        private Panel pnlPhotocenter;
        private Panel pnlPhotoleft;
        public Panel pnlPhoto;
        private Label lblResize;
        private Label lblSelector;
        public PictureBox picSelectPhoto;
        public Panel pnlPhotoright;
        private TableLayoutPanel TableLayoutPanel1;
        private PictureBox picSmall;
        private Label lblPreView;
        private PictureBox pctPhoto;
    }
}