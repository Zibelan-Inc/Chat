using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Chat.Controles
{
    class UserPanel : UserControl
    {
        private PictureBox pictureBox1;
        private Label Nick;
        private Label _machine;
        private Label _ip;
        private Label _state;
        private PictureBox imgState;

        public string nick { get; set; }
        public string ip { get; set; }
        public string machine { get; set; }
        public string state { get; set; }

        private void InitializeComponent()
        {
            this.pictureBox1 = new PictureBox();
            this.Nick = new Label();
            this._machine = new Label();
            this._ip = new Label();
            this._state = new Label();
            this.imgState = new PictureBox();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((ISupportInitialize)(this.imgState)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(68, 68);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Nick.Location = new Point(76, 3);
            this.Nick.Name = "Nick";
            this.Nick.Size = new Size(33, 17);
            this.Nick.TabIndex = 1;
            this.Nick.Text = "Nick";
            // 
            // _machine
            // 
            this._machine.AutoSize = true;
            this._machine.Location = new Point(76, 22);
            this._machine.Name = "_machine";
            this._machine.Size = new Size(38, 15);
            this._machine.TabIndex = 2;
            this._machine.Text = "label1";
            // 
            // _ip
            // 
            this._ip.AutoSize = true;
            this._ip.Location = new Point(76, 37);
            this._ip.Name = "_ip";
            this._ip.Size = new Size(38, 15);
            this._ip.TabIndex = 3;
            this._ip.Text = "label2";
            // 
            // _state
            // 
            this._state.AutoSize = true;
            this._state.Location = new Point(98, 52);
            this._state.Name = "_state";
            this._state.Size = new Size(38, 15);
            this._state.TabIndex = 4;
            this._state.Text = "label3";
            // 
            // imgState
            // 
            this.imgState.Location = new Point(79, 52);
            this.imgState.Name = "imgState";
            this.imgState.Size = new Size(16, 16);
            this.imgState.TabIndex = 5;
            this.imgState.TabStop = false;
            // 
            // UserPanel
            // 
            this.Controls.Add(this.imgState);
            this.Controls.Add(this._state);
            this.Controls.Add(this._ip);
            this.Controls.Add(this._machine);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.pictureBox1);
            this.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserPanel";
            this.Size = new Size(226, 84);
            this.Load += new EventHandler(this.UserPanel_Load);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            ((ISupportInitialize)(this.imgState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            Nick.Text = nick;
            _ip.Text = ip;
            _machine.Text = machine;
            Nick.Text = state;
        }

    }
}
