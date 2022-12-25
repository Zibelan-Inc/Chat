using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat
{
    public partial class Monitorear : Form
    {
        public static Monitorear monitorear;

        public Monitorear()
        {
            InitializeComponent();
            monitorear = this;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Left, workingArea.Top);

        }

        private void Monitorear_Load(object sender, EventArgs e)
        {

        }
        public void WriteChatMessages(string content)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionLength = 0;

            txtChat.AppendText("- " + content + "\n" + "\n");

            txtChat.SelectionFont = new Font(txtChat.Font, FontStyle.Regular);
            txtChat.SelectionColor = txtChat.ForeColor;
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {
            txtChat.ScrollToCaret();
        }

        private void Monitorear_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
