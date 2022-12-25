using System.ComponentModel;
using System.Windows.Forms;
using Chat.Controles;

namespace Chat
{
    partial class frmFileTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileTransfer));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TicToc = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlPhotocenter = new System.Windows.Forms.Panel();
            this.pnlPhotoleft = new System.Windows.Forms.Panel();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Panel();
            this.lblHide = new HackLabel(this.components);
            this.pnlCancelar = new System.Windows.Forms.Panel();
            this.lblCancel = new HackLabel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesizeTextBox = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.Label();
            this.progressBar1 = new HackProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPhotocenter.SuspendLayout();
            this.pnlPhotoleft.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.btnHide.SuspendLayout();
            this.pnlCancelar.SuspendLayout();
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlPhotocenter
            // 
            this.pnlPhotocenter.Controls.Add(this.pnlPhotoleft);
            this.pnlPhotocenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotocenter.Location = new System.Drawing.Point(0, 0);
            this.pnlPhotocenter.Name = "pnlPhotocenter";
            this.pnlPhotocenter.Size = new System.Drawing.Size(346, 104);
            this.pnlPhotocenter.TabIndex = 95;
            // 
            // pnlPhotoleft
            // 
            this.pnlPhotoleft.Controls.Add(this.pnlPhoto);
            this.pnlPhotoleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhotoleft.Location = new System.Drawing.Point(0, 0);
            this.pnlPhotoleft.Name = "pnlPhotoleft";
            this.pnlPhotoleft.Size = new System.Drawing.Size(346, 104);
            this.pnlPhotoleft.TabIndex = 4;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlPhoto.Controls.Add(this.btnHide);
            this.pnlPhoto.Controls.Add(this.pnlCancelar);
            this.pnlPhoto.Controls.Add(this.panel1);
            this.pnlPhoto.Controls.Add(this.filesizeTextBox);
            this.pnlPhoto.Controls.Add(this.filenameTextBox);
            this.pnlPhoto.Controls.Add(this.progressBar1);
            this.pnlPhoto.Controls.Add(this.label2);
            this.pnlPhoto.Controls.Add(this.label1);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 0);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(346, 104);
            this.pnlPhoto.TabIndex = 3;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.btnHide.Controls.Add(this.lblHide);
            this.btnHide.Location = new System.Drawing.Point(242, 56);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(88, 31);
            this.btnHide.TabIndex = 103;
            this.btnHide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblHide_MouseClick);
            this.btnHide.MouseLeave += new System.EventHandler(this.btnHide_MouseLeave);
            this.btnHide.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblHide_MouseMove);
            // 
            // lblHide
            // 
            this.lblHide.AutoSize = true;
            this.lblHide.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHide.ForeColor = System.Drawing.Color.White;
            this.lblHide.Location = new System.Drawing.Point(15, 6);
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size(57, 17);
            this.lblHide.TabIndex = 0;
            this.lblHide.Text = "Ocultar";
            this.lblHide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblHide_MouseClick);
            this.lblHide.MouseLeave += new System.EventHandler(this.btnHide_MouseLeave);
            this.lblHide.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblHide_MouseMove);
            // 
            // pnlCancelar
            // 
            this.pnlCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.pnlCancelar.Controls.Add(this.lblCancel);
            this.pnlCancelar.Location = new System.Drawing.Point(148, 56);
            this.pnlCancelar.Name = "pnlCancelar";
            this.pnlCancelar.Size = new System.Drawing.Size(88, 31);
            this.pnlCancelar.TabIndex = 102;
            this.pnlCancelar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseClick);
            this.pnlCancelar.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            this.pnlCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCancelar_MouseMove);
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(12, 6);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(66, 17);
            this.lblCancel.TabIndex = 0;
            this.lblCancel.Text = "Cancelar";
            this.lblCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseClick);
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            this.lblCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCancelar_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(332, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 24);
            this.panel1.TabIndex = 101;
            // 
            // filesizeTextBox
            // 
            this.filesizeTextBox.AutoSize = true;
            this.filesizeTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesizeTextBox.Location = new System.Drawing.Point(56, 46);
            this.filesizeTextBox.Name = "filesizeTextBox";
            this.filesizeTextBox.Size = new System.Drawing.Size(0, 15);
            this.filesizeTextBox.TabIndex = 100;
            this.filesizeTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.filesizeTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.filesizeTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.AutoSize = true;
            this.filenameTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameTextBox.Location = new System.Drawing.Point(56, 27);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(0, 15);
            this.filenameTextBox.TabIndex = 99;
            this.filenameTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.filenameTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.filenameTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.DrawHatch = true;
            this.progressBar1.Location = new System.Drawing.Point(7, 6);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.MinimumSize = new System.Drawing.Size(58, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.progressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.progressBar1.ShowPercentage = true;
            this.progressBar1.Size = new System.Drawing.Size(323, 20);
            this.progressBar1.TabIndex = 98;
            this.progressBar1.Text = "hackProgressBar1";
            this.progressBar1.Value = 0;
            this.progressBar1.ValueAlignment = HackProgressBar.Alignment.Right;
            this.progressBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.progressBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.progressBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 97;
            this.label2.Text = "Tamaño:";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Archivo:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MP_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MP_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MP_MouseUp);
            // 
            // frmFileTransfer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(346, 104);
            this.Controls.Add(this.pnlPhotocenter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(346, 104);
            this.MinimumSize = new System.Drawing.Size(346, 104);
            this.Name = "frmFileTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainfrm";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.pnlPhotocenter.ResumeLayout(false);
            this.pnlPhotoleft.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            this.btnHide.ResumeLayout(false);
            this.btnHide.PerformLayout();
            this.pnlCancelar.ResumeLayout(false);
            this.pnlCancelar.PerformLayout();
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
        private Panel pnlPhotocenter;
        private Panel pnlPhotoleft;
        public Panel pnlPhoto;
        private Panel btnHide;
        private HackLabel lblHide;
        private Panel pnlCancelar;
        private HackLabel lblCancel;
        private Panel panel1;
        private Label filesizeTextBox;
        private Label filenameTextBox;
        private HackProgressBar progressBar1;
        private Label label2;
        private Label label1;
        private Timer timer1;
    }
}