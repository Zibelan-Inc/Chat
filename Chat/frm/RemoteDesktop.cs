using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace Chat
{
    public partial class RemoteDesktop : Form
    {
        bool connected = false;
        Size Remotescreen;
        ScreenCapture obj;
        string URI;
        TcpChannel chan;
        public bool Senderr;
        //Form Styles Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        public RemoteDesktop(bool con,ScreenCapture s,string uz,TcpChannel c)
        {
            InitializeComponent();
            //Menerima data dari constructor
            connected = con;
            obj = s;
            Remotescreen = obj.GetDesktopBitmapSize();
            URI = uz;
            chan = c;
            obj.con_stat = true;
            obj.soundStat = false;
            obj.sendMessage = false;
            textBox1.Visible = false;
            this.ActiveControl = textBox1;
            pictureBox1.MouseWheel += new MouseEventHandler(Form_MouseWheel);
            HomeBox.Parent = pictureBox1;

        }

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(
            uint uCode,     // virtual-key code or scan code
            uint uMapType   // translation to perform
            );

        #region Form Style
        //membuat form bisa didrag / draggable
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //        dataGrid.MouseWheel += new MouseEventHandler(dataGrid_MouseWheel);
        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            /*
            if (e.Delta.Equals(120))
            {
                MinimumSize = new Size(Width++, Height++);
            }
            if (!e.Delta.Equals(120))
            {
                MinimumSize = new Size(Width--, Height--);
            }
            */
        }


        //membuat drop shadow pada form
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        //Main Program
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void sound_Click(object sender, EventArgs e)
        {
            obj.soundStat = true;
        }

        private void warn_Click(object sender, EventArgs e)
        {
            obj.sendMessage = true;
        }

        private void max_Click(object sender, EventArgs e)
        {
            if (max.Text == "Max")
            {
                this.WindowState = FormWindowState.Maximized;
//                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                max.Text = "Min";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
//                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                max.Text = "Max";
            }
        }

        private void keyform(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            obj.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), false, false);
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            obj.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), true, false);
            if (e.KeyCode == Keys.Escape)
               Close();
        }

        private void dc_Click(object sender, EventArgs e)
        {
            try
            {
                ChannelServices.UnregisterChannel(chan);//to Un Register chan Channel
            }
            catch (Exception err)
            {
                MessageBox.Show("Error : " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            obj.con_stat = false;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (obj.con_stat == false)
            {
                try
                {
                    ChannelServices.UnregisterChannel(chan);//to Un Register chan Channel
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error : " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    byte[] buffer = obj.GetDesktopBitmapBytes();
                    MemoryStream ms = new MemoryStream(buffer);
                    pictureBox1.Image = Image.FromStream(ms);
                    if (obj.sendMessage == true)
                        obj.sendMessage = false;
                    if (obj.soundStat == true)
                        obj.soundStat = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                };
            }
        } catch { }
    }

        private void HomeBox_Click(object sender, EventArgs e)
        {
            if (label1.Text == "M")
            {
                dc.Hide();
                max.Hide();
                label1.Text = "H";
            }
            else
            {
                dc.Show();
                max.Show();
                label1.Text = "M";
            }

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (max.Text == "Max")
            {
                this.WindowState = FormWindowState.Maximized;
                //                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                max.Text = "Min";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                //                panel1.Location = new Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                max.Text = "Max";
            }
        }
    }
}
