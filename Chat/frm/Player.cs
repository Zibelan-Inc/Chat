using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Chat.Properties;

// Modified April 16, 2016

namespace Chat
{
    public partial class Player : Form
    {
        public Media newMedia = new Media();
        OpenFileDialog file;
        public static Player frm;
        private bool flag;
        private bool _ctrlkeyheld;

        private bool Repeat { get; set; }
        public string Song { get; private set; }

        [DllImport("user32.dll")]
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_SLIDE = 0x00040000;
        public Player()
        {
            InitializeComponent();
            MoveToTopMost(this.Handle);
            frm = this;
            Repeat = false;
            Thread tarea = new Thread(thread);
            tarea.IsBackground = true;
            tarea.Start();

            AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER | AW_ACTIVATE);


            string uno = "String";
            string dos = "string";
            //if (Operators.CompareString(uno, dos, true) == 0)
            //    MessageBox.Show(Operators.CompareString(uno, dos, true).ToString());
            volumnTrackBar.Value = 5;
            volume = volumnTrackBar.Value*100;
        }



        private void thread()
        {
            while (true)
            {
            }
        }
        private void fsButton_Click(object sender, EventArgs e)
        {
            newMedia.FullScreen();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = newMedia.Position;
            progressTrackBar.Value = newMedia.Position;
            //  progressLabel.Text = newMedia.Position.ToString();
            //progressLabel.Text = (newMedia.Position / Convert.ToDecimal(newMedia.Duration())).ToString("P0");
            if (newMedia.Repeat)
            {
                return;
            }
            if (progressTrackBar.Value == newMedia.Duration())
            {
                for (int i = 0; i < listaReproduccion.Items.Count; i++)
                {
                    ListViewItem item = listaReproduccion.Items[i];
                    if (item.SubItems[1].Text == playing)
                    {
                        try
                        {
                            ListViewItem siguiente = listaReproduccion.Items[i + 1];
                            newMedia.Stop();
                            Song = siguiente.SubItems[1].Name;
                            newMedia.Open(Song, movie);
                            progressBar1.Value = 0;
                            progressTrackBar.Value = 0;
                            progressBar1.Maximum = newMedia.Duration();
                            progressTrackBar.Maximum = newMedia.Duration();
                            newMedia.Stop();
                            Play();
                            return;
                        }
                        catch { }
                    }
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void volumnTrackBar_Scroll(object sender, EventArgs e)
        {
            newMedia.Volume = volumnTrackBar.Value * 100;
            volume = volumnTrackBar.Value*100;
            if (volumnTrackBar.Value == 0)
                volumeSound.Image = Resources._406;
            else
                volumeSound.Image = Resources._629;

        }

        private void progressTrackBar_Scroll(object sender, EventArgs e)
        {
            newMedia.Position = progressTrackBar.Value;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Play()
        {
            if (!newMedia.FileIsOpen)
            {
                string song = listaReproduccion.SelectedItems[0].SubItems[1].Name;
                if (!string.IsNullOrEmpty(song))
                {
                    Song = song;
                    newMedia.Open(Song, movie);
                    volumnTrackBar.Value = volume / 100;
                    progressBar1.Maximum = newMedia.Duration();
                    progressTrackBar.Maximum = newMedia.Duration();
                    newMedia.Stop();
                    AddSong(Song);

                }
                else if (!openFile())
                 goto Label_1;
            }

            newMedia.Close();
            newMedia.Open(Song, movie);
            newMedia.Play();
            timer1.Enabled = true;
            newMedia.Volume = volume;
            newMedia.Position = progressTrackBar.Value;

            this.playButton.Image = Resources._262;
            playing = Path.GetFileName(Song);
            SelectInList();

            Label_1:
            ;
        }
        private void SelectInList()
        {
            for (int i = 0; i < listaReproduccion.Items.Count; i++)
            {
                ListViewItem item = listaReproduccion.Items[i];
                if (item.SubItems[1].Text == playing)
                {
                    item.BackColor = Color.FromArgb(235, 235, 235); ;
                }
                else
                    item.BackColor = Color.White;
            }
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            if (newMedia.Status() == "stopped")
            {
                Play();
            }
            else if (newMedia.Status() == "paused")
            {
                Play();
            }
            else if (newMedia.Status() == "playing")
            {
                newMedia.Pause = !newMedia.Pause;
                timer1.Enabled = !timer1.Enabled;
                this.playButton.Image = Resources._262;
            }

        }
        private bool openFile()
        {
            bool opened = false;
            file = new OpenFileDialog();

            file.Filter = "Video Files | *.avi; *.mpg; *.wmv; *.mkv; *.mpeg; *.mp4; *.wav; *.mp3";
            file.InitialDirectory = Directory.GetCurrentDirectory();
            DialogResult res = file.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo modal

            if (res == DialogResult.OK)
            {
                if (file.FileName != "")
                {
                    Song = file.FileName;
                    newMedia.Open(Song, movie);
                    progressBar1.Maximum = newMedia.Duration();
                    progressTrackBar.Maximum = newMedia.Duration();
                    newMedia.Stop();
                    AddSong(Song);
                    Play();
                    opened = true;
                }
            }
            return opened;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            newMedia.Stop();
            timer1.Enabled = false;
            progressBar1.Value = 0;
            progressTrackBar.Value = 0;

        }

        private void stopButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.stopButton.Image = Resources._201;

        }

        private void stopButton_MouseLeave(object sender, EventArgs e)
        {
            this.stopButton.Image = Resources._184;

        }

        private void LSound_MouseMove(object sender, MouseEventArgs e)
        {
            this.LSound.Image = Resources._279;

        }

        private void LSound_MouseLeave(object sender, EventArgs e)
        {
            this.LSound.Image = Resources._181;

        }

        private void playButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (newMedia.Status() == "stopped")
                this.playButton.Image = Resources._243;
            else if (newMedia.Status() == "paused")
                this.playButton.Image = Resources._243;
            else if (newMedia.Status() == "playing")
                this.playButton.Image = Resources._261;
            else
                this.playButton.Image = Resources._243;

        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            if (newMedia.Status() == "stopped")
                this.playButton.Image = Resources._202;
            else if (newMedia.Status() == "paused")
                this.playButton.Image = Resources._202;
            else if (newMedia.Status() == "playing")
                this.playButton.Image = Resources._262;
            else
                this.playButton.Image = Resources._202;


        }

        private void RSound_MouseMove(object sender, MouseEventArgs e)
        {
            this.RSound.Image = Resources._281;

        }

        private void RSound_MouseLeave(object sender, EventArgs e)
        {
            this.RSound.Image = Resources._185;

        }


        private void RSound_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaReproduccion.Items.Count; i++)
            {
                ListViewItem item = listaReproduccion.Items[i];
                if (item.SubItems[1].Text == playing)
                {
                    try
                    {
                        ListViewItem siguiente = listaReproduccion.Items[i + 1];
                        newMedia.Stop();
                        Song = siguiente.SubItems[1].Name;
                        newMedia.Open(Song, movie);
                        progressBar1.Value = 0;
                        progressTrackBar.Value = 0;
                        progressBar1.Maximum = newMedia.Duration();
                        progressTrackBar.Maximum = newMedia.Duration();
                        newMedia.Stop();
                        Play();
                        return;
                    }
                    catch { }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void LSound_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaReproduccion.Items.Count; i++)
            {
                ListViewItem item = listaReproduccion.Items[i];
                if (item.SubItems[1].Text == playing)
                {
                    try
                    {
                        ListViewItem siguiente = listaReproduccion.Items[i - 1];
                        newMedia.Stop();
                        Song = siguiente.SubItems[1].Name;
                        newMedia.Open(Song, movie);
                        progressBar1.Value = 0;
                        progressTrackBar.Value = 0;
                        progressBar1.Maximum = newMedia.Duration();
                        progressTrackBar.Maximum = newMedia.Duration();
                        newMedia.Stop();
                        Play();
                        return;
                    }
                    catch { }
                }
            }
        }


        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;
        private void MoveToTopMost(IntPtr handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
        }
        private void MoveToBottom(IntPtr handle)
        {
            NativeMethods.SetWindowPos(handle, HWND_BOTTOM, 0, 0, 0, 0, 1043u);
        }

        private void movie_DoubleClick(object sender, EventArgs e)
        {
            newMedia.FullScreen();
        }

        private void listaReproduccion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listaReproduccion_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                AddSong(file);
            }
        }
        private void AddSong(string file)
        {
            string ext = Path.GetExtension(file);
            if (ext.ToLower() != ".avi" && ext.ToLower() != ".mpg" && ext.ToLower() != ".wmv" && ext.ToLower() != ".mkv" &&
                ext.ToLower() != ".mp4" && ext.ToLower() != ".wav" && ext.ToLower() != ".mp3")
                return;

            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;

            //Agrego los subItems(Nombre y estado)
            ListViewItem.ListViewSubItem userNameSubItem = new ListViewItem.ListViewSubItem();
            lvi.SubItems.Add(userNameSubItem);

            //Asigno Name y Text a los subItems
            lvi.SubItems[1].Text = Path.GetFileName(file);
            lvi.SubItems[1].Name = file;
            ListViewItem item = listaReproduccion.FindItemWithText(Path.GetFileName(file));
            if (item == null)
                listaReproduccion.Items.Add(lvi);
        }

        private void listaReproduccion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string song = listaReproduccion.SelectedItems[0].SubItems[1].Name;
            if (e.Button == MouseButtons.Right)
            {
                if (listaReproduccion.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    //UserMenu.Show(Cursor.Position);
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (listaReproduccion.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    newMedia.Stop();
                    Song = song;
                    newMedia.Open(Song, movie);
                    progressBar1.Value = 0;
                    progressTrackBar.Value = 0;
                    progressBar1.Maximum = newMedia.Duration();
                    progressTrackBar.Maximum = newMedia.Duration();
                    newMedia.Stop();
                    Play();

                }
            }

        }

        private void movie_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("pincha");
        }

        private void frmClose_Click(object sender, EventArgs e)
        {
            //AnimateWindow(this.Handle, 500, AW_CENTER | AW_BLEND | AW_HIDE);
            Visible = false;
        }


        private void LostFoco(object sender, EventArgs e)
        {

        }
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        private string playing;
        private int volume;

        private void Pannel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        private void Pannel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Pannel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
    
            }
        }

        private void Foco(object sender, MouseEventArgs e)
        {

        }

        private Image imagen;
        private void volumeSound_Click(object sender, EventArgs e)
        {
            volumnTrackBar.Visible = !volumnTrackBar.Visible;
            if (volumnTrackBar.Visible)
                volumeSound.Image = Resources._762;
            else
                volumeSound.Image = Resources._629;
            imagen = volumeSound.Image;
        }

        private void volumeSound_MouseMove(object sender, MouseEventArgs e)
        {
            if (volumnTrackBar.Value == 0)
                volumeSound.Image = Resources._810;
            else
            {
                volumeSound.Image = Resources._761;
            }
        }

        private void volumeSound_MouseLeave(object sender, EventArgs e)
        {
            if (volumnTrackBar.Value == 0)
                volumeSound.Image = Resources._406;
            else
                volumeSound.Image = Resources._629;

        }

        private void listaReproduccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                string song = listaReproduccion.SelectedItems[0].SubItems[1].Name;

                newMedia.Stop();
                Song = song;
                newMedia.Open(Song, movie);
                progressBar1.Value = 0;
                progressTrackBar.Value = 0;
                progressBar1.Maximum = newMedia.Duration();
                progressTrackBar.Maximum = newMedia.Duration();
                newMedia.Stop();
                Play();
            }
            if (e.KeyData == Keys.Delete)
            {
                string song = listaReproduccion.SelectedItems[0].SubItems[1].Text;

                ListViewItem item = listaReproduccion.FindItemWithText(song);
                if (item != null)
                    listaReproduccion.Items.Remove(item);
            }
        }

    }
}


