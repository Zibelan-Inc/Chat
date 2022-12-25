using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chat
{
    public partial class frmInfo : Form, IEnumerable
    {
        private Rectangle rScreen;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public frmInfo()
        {
            InitializeComponent();
            //FlashWin.Start(this.Handle);
            WinMod.MakeWindowTop((long)this.Handle);

            int yy = checked(this.rScreen.Height - this.Height);


            MoveToTopMost(this.Handle);
            this.TopMost = true;
        }

        public static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static readonly IntPtr HWND_BOTTOM = (IntPtr)1;

        private void MoveToTopMost(IntPtr handle)
        {
            NativeMethods.SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 1043u);
        }
        private void MoveToBottom(IntPtr handle)
        {
            NativeMethods.SetWindowPos(handle, HWND_BOTTOM, 0, 0, 0, 0, 1043u);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Message(string mensage1, string mensage2)
        {

        }
        public void WriteMessage(int actionType, string Mensage, string Titulo = null, int actionColor = 0)
        {
            try
            {
                txtMessages.SelectionStart = txtMessages.TextLength;
                txtMessages.SelectionLength = 0;
                switch (actionType)
                {
                    case 2: // Info

                        this.ClientSize = new Size(393, 444);
                        this.txtMessages.Size = new Size(384, 408);
                        this.Ok.Location = new Point(300, 411);

                        Ok.Text = "Cerrar";
                        string[] Datos = Mensage.Split('/');
                        string To = Datos[0];
                        string IP = Datos[1];
                        string SO = Datos[2];
                        string Bits = Datos[3];
                        string Micro = Datos[4];
                        string RAM = Datos[5];
                        string Drive = Datos[6];
                        string PCname = Datos[7];
                        string USERname = Datos[8];
                        string UserID = Datos[9];
                        string IsAdmin = Datos[10];
                        string GPU = Datos[11];

                        if (File.Exists(Application.StartupPath + "/Avatars/" + UserID + ".jpg"))
                        {
                            Avatar.Image = Image.FromFile(Application.StartupPath + "/Avatars/" + UserID + ".jpg");
                            Avatar.Show();
                        }
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.AppendText("Información del usuario ");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Bold);
                        txtMessages.SelectionColor = getColorFromId(actionColor);
                        txtMessages.AppendText(Modcommon.GetNamefromID(UserID) + " \r\n \r\n");


                        //SO
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Edición de Windows:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(SO + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //Bits
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Tipo de Sistema:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText("Sistema Operativo a " + Bits + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //Micro
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Procesador:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(Micro + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //RAM
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Memoria Instalada (RAM):" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(RAM + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //GPU
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Tarjeta Gráfica:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(GPU + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //Unidades de HDD
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Particiones:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(Drive + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");


                        //PCname
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Nombre de la PC:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(PCname + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //IP
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Número IP:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(IP + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //User
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Nombre de usuario:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText(USERname + " \r\n");
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 1.55F, FontStyle.Bold);
                        txtMessages.AppendText(" \r\n");

                        //TipodeUser
                        txtMessages.SelectionColor = Color.FromArgb(0, 134, 255);
                        txtMessages.SelectionFont = new Font("Segoe UI Emoji", 8.75F, FontStyle.Bold);
                        txtMessages.AppendText("Tipo de usuario:" + " \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText("Usuario " + IsAdmin);

                        Text = "KosmoChat - Información de usuario";
                        break;
                    case 3: // Mensaje privado
                        txtMessages.AppendText("\r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Bold);
                        txtMessages.SelectionColor = Color.FromName("blue");
                        txtMessages.SelectionColor = getColorFromId(actionColor);
                        txtMessages.AppendText(Titulo);
                        txtMessages.SelectionColor = Color.FromName("white");
                        txtMessages.AppendText("\r\n \r\n");
                        txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                        txtMessages.AppendText(Mensage);

                        Text = "KosmoChat - Mensaje privado";
                        break;

                }
                txtMessages.SelectionFont = new Font(txtMessages.Font, FontStyle.Regular);
                txtMessages.SelectionColor = txtMessages.ForeColor;
            }
            catch { }
        }
        public Color getColorFromId(int value)
        {
            Color color;
            switch (value)
            {
                case 0:
                    color = ColorTranslator.FromHtml("#b6deff");
                    break;
                case 1:
                    color = ColorTranslator.FromHtml("#38f873");
                    break;
                case 2:
                    color = ColorTranslator.FromHtml("#ecfb47");
                    break;
                case 3:
                    color = ColorTranslator.FromHtml("#f93eb0");
                    break;
                case 4:
                    color = ColorTranslator.FromHtml("#ff56fd");
                    break;
                case 5:
                    color = ColorTranslator.FromHtml("#0086ff");
                    break;
                case 6:
                    color = ColorTranslator.FromHtml("#ff8c00");
                    break;
                case 7:
                    color = ColorTranslator.FromHtml("#ff0000");
                    break;
                case 8:
                    color = ColorTranslator.FromHtml("#929191");
                    break;
                case 9:
                    color = ColorTranslator.FromHtml("#00c6ff");
                    break;
                default:
                    color = Color.White;
                    break;
            }
            return color;
        }


        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMessages_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Avatar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Avatar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void Avatar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void Avatar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Avatar.Image.Save(Path.Combine(Modcommon.TEMP_PATH, "TempAvatar.jpg"));
                string avatar =  Path.Combine(Modcommon.TEMP_PATH, "TempAvatar.jpg");
                HtmlHelper.OpenFile(avatar);
            } catch (Exception ex){ WriteLog.Save(ex); }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = System.Drawing.Color.FromArgb(26, 32, 47);
        }
    }
}
