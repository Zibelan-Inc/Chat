using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat
{
    public partial class Emoticons : Form
    {
        private frmMain llamante;
        public Emoticons(frmMain remitente) { this.llamante = remitente; }
        public string SmiliE { get; set; }
        public Emoticons()
        {
            InitializeComponent();
        }
        public void location(int X, int Y)
        {
            this.Location = new Point(X + 220, Y + 163);
        }



        private void EnviarLogica(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            SmiliE = ctrl.Name;
            Close();
        }

        private void Emoticons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Emoticons_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
