using System.ComponentModel;
using System.Windows.Forms;
using Chat.Controles;
using Chat.Properties;

namespace Chat
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.volumnTrackBar = new System.Windows.Forms.TrackBar();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volumeSound = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new HackMusicProgres();
            this.RSound = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.LSound = new System.Windows.Forms.PictureBox();
            this.listaReproduccion = new System.Windows.Forms.ListView();
            this.IconoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.Pannel = new System.Windows.Forms.Panel();
            this.frmClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.movie = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.PictureBox();
            this.progressTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.volumnTrackBar)).BeginInit();
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSound)).BeginInit();
            this.Pannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // volumnTrackBar
            // 
            this.volumnTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.volumnTrackBar.Location = new System.Drawing.Point(198, 17);
            this.volumnTrackBar.Name = "volumnTrackBar";
            this.volumnTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumnTrackBar.Size = new System.Drawing.Size(45, 50);
            this.volumnTrackBar.TabIndex = 4;
            this.volumnTrackBar.Visible = false;
            this.volumnTrackBar.Scroll += new System.EventHandler(this.volumnTrackBar_Scroll);
            this.volumnTrackBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Foco);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(107, 48);
            this.Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_Opening);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.volumeSound);
            this.panel1.Controls.Add(this.volumnTrackBar);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.RSound);
            this.panel1.Controls.Add(this.playButton);
            this.panel1.Controls.Add(this.LSound);
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 67);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Foco);
            // 
            // volumeSound
            // 
            this.volumeSound.Image = global::Chat.Properties.Resources._629;
            this.volumeSound.Location = new System.Drawing.Point(165, 23);
            this.volumeSound.Name = "volumeSound";
            this.volumeSound.Size = new System.Drawing.Size(35, 35);
            this.volumeSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.volumeSound.TabIndex = 16;
            this.volumeSound.TabStop = false;
            this.volumeSound.Click += new System.EventHandler(this.volumeSound_Click);
            this.volumeSound.MouseLeave += new System.EventHandler(this.volumeSound_MouseLeave);
            this.volumeSound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.volumeSound_MouseMove);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.progressBar1.DrawHatch = true;
            this.progressBar1.DrawString = "00";
            this.progressBar1.Location = new System.Drawing.Point(-1, -1);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.MinimumSize = new System.Drawing.Size(58, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.progressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.progressBar1.ShowPercentage = true;
            this.progressBar1.Size = new System.Drawing.Size(221, 20);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Text = "hackProgressBar1";
            this.progressBar1.Value = 0;
            this.progressBar1.ValueAlignment = HackMusicProgres.Alignment.Right;
            this.progressBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Foco);
            // 
            // RSound
            // 
            this.RSound.Image = global::Chat.Properties.Resources._185;
            this.RSound.Location = new System.Drawing.Point(128, 22);
            this.RSound.Name = "RSound";
            this.RSound.Size = new System.Drawing.Size(35, 35);
            this.RSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RSound.TabIndex = 15;
            this.RSound.TabStop = false;
            this.RSound.Click += new System.EventHandler(this.RSound_Click);
            this.RSound.MouseLeave += new System.EventHandler(this.RSound_MouseLeave);
            this.RSound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RSound_MouseMove);
            // 
            // playButton
            // 
            this.playButton.Image = global::Chat.Properties.Resources._202;
            this.playButton.Location = new System.Drawing.Point(92, 22);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(35, 35);
            this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playButton.TabIndex = 14;
            this.playButton.TabStop = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            this.playButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseMove);
            // 
            // LSound
            // 
            this.LSound.Image = global::Chat.Properties.Resources._181;
            this.LSound.Location = new System.Drawing.Point(55, 22);
            this.LSound.Name = "LSound";
            this.LSound.Size = new System.Drawing.Size(35, 35);
            this.LSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LSound.TabIndex = 13;
            this.LSound.TabStop = false;
            this.LSound.Click += new System.EventHandler(this.LSound_Click);
            this.LSound.MouseLeave += new System.EventHandler(this.LSound_MouseLeave);
            this.LSound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LSound_MouseMove);
            // 
            // listaReproduccion
            // 
            this.listaReproduccion.AllowDrop = true;
            this.listaReproduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.listaReproduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaReproduccion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IconoColumn,
            this.SongColumn});
            this.listaReproduccion.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaReproduccion.FullRowSelect = true;
            this.listaReproduccion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listaReproduccion.HideSelection = false;
            this.listaReproduccion.LargeImageList = this.imageList;
            this.listaReproduccion.Location = new System.Drawing.Point(0, 28);
            this.listaReproduccion.Name = "listaReproduccion";
            this.listaReproduccion.Size = new System.Drawing.Size(220, 251);
            this.listaReproduccion.SmallImageList = this.imageList;
            this.listaReproduccion.TabIndex = 19;
            this.listaReproduccion.UseCompatibleStateImageBehavior = false;
            this.listaReproduccion.View = System.Windows.Forms.View.Details;
            this.listaReproduccion.DragDrop += new System.Windows.Forms.DragEventHandler(this.listaReproduccion_DragDrop);
            this.listaReproduccion.DragEnter += new System.Windows.Forms.DragEventHandler(this.listaReproduccion_DragEnter);
            this.listaReproduccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaReproduccion_KeyDown);
            this.listaReproduccion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaReproduccion_MouseDoubleClick);
            this.listaReproduccion.MouseLeave += new System.EventHandler(this.LostFoco);
            this.listaReproduccion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Foco);
            // 
            // IconoColumn
            // 
            this.IconoColumn.Text = "";
            this.IconoColumn.Width = 21;
            // 
            // SongColumn
            // 
            this.SongColumn.Text = "";
            this.SongColumn.Width = 195;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "attn icon 13.png");
            // 
            // Pannel
            // 
            this.Pannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.Pannel.Controls.Add(this.frmClose);
            this.Pannel.Controls.Add(this.label1);
            this.Pannel.Location = new System.Drawing.Point(-26, -6);
            this.Pannel.Name = "Pannel";
            this.Pannel.Size = new System.Drawing.Size(300, 33);
            this.Pannel.TabIndex = 20;
            this.Pannel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseDown);
            this.Pannel.MouseLeave += new System.EventHandler(this.LostFoco);
            this.Pannel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseMove);
            this.Pannel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseUp);
            // 
            // frmClose
            // 
            this.frmClose.Image = global::Chat.Properties.Resources.close_new;
            this.frmClose.Location = new System.Drawing.Point(227, 12);
            this.frmClose.Name = "frmClose";
            this.frmClose.Size = new System.Drawing.Size(16, 15);
            this.frmClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.frmClose.TabIndex = 1;
            this.frmClose.TabStop = false;
            this.frmClose.Click += new System.EventHandler(this.frmClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "KosmoChat player";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pannel_MouseUp);
            // 
            // movie
            // 
            this.movie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(164)))), ((int)(((byte)(245)))));
            this.movie.Location = new System.Drawing.Point(0, 0);
            this.movie.Name = "movie";
            this.movie.Size = new System.Drawing.Size(10, 10);
            this.movie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.movie.TabIndex = 18;
            this.movie.TabStop = false;
            this.movie.DoubleClick += new System.EventHandler(this.movie_DoubleClick);
            this.movie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movie_MouseMove);
            // 
            // stopButton
            // 
            this.stopButton.Image = global::Chat.Properties.Resources._184;
            this.stopButton.Location = new System.Drawing.Point(18, 302);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(35, 35);
            this.stopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stopButton.TabIndex = 12;
            this.stopButton.TabStop = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            this.stopButton.MouseLeave += new System.EventHandler(this.stopButton_MouseLeave);
            this.stopButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.stopButton_MouseMove);
            // 
            // progressTrackBar
            // 
            this.progressTrackBar.Location = new System.Drawing.Point(239, 70);
            this.progressTrackBar.Name = "progressTrackBar";
            this.progressTrackBar.Size = new System.Drawing.Size(221, 45);
            this.progressTrackBar.TabIndex = 18;
            this.progressTrackBar.Scroll += new System.EventHandler(this.progressTrackBar_Scroll);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(220, 345);
            this.ContextMenuStrip = this.Menu;
            this.Controls.Add(this.Pannel);
            this.Controls.Add(this.progressTrackBar);
            this.Controls.Add(this.listaReproduccion);
            this.Controls.Add(this.movie);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Player";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseLeave += new System.EventHandler(this.LostFoco);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Foco);
            ((System.ComponentModel.ISupportInitialize)(this.volumnTrackBar)).EndInit();
            this.Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSound)).EndInit();
            this.Pannel.ResumeLayout(false);
            this.Pannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Timer timer1;
        private TrackBar volumnTrackBar;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private PictureBox stopButton;
        private PictureBox LSound;
        private PictureBox playButton;
        private PictureBox RSound;
        private HackMusicProgres progressBar1;
        private PictureBox movie;
        private ListView listaReproduccion;
        private ColumnHeader IconoColumn;
        private ColumnHeader SongColumn;
        private ImageList imageList;
        private Panel Pannel;
        private Label label1;
        private PictureBox frmClose;
        private TrackBar progressTrackBar;
        private PictureBox volumeSound;
    }
}

