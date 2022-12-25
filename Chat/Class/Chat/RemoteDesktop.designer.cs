using System.ComponentModel;
using System.Windows.Forms;

namespace TINserverlauncher
{
    partial class RemoteDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktop));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.max = new System.Windows.Forms.Label();
            this.dc = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HomeBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(619, 404);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.BackColor = System.Drawing.Color.Silver;
            this.max.Cursor = System.Windows.Forms.Cursors.Hand;
            this.max.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max.Location = new System.Drawing.Point(110, 4);
            this.max.Name = "max";
            this.max.Padding = new System.Windows.Forms.Padding(3);
            this.max.Size = new System.Drawing.Size(33, 19);
            this.max.TabIndex = 2;
            this.max.Text = "Max";
            this.max.Visible = false;
            this.max.Click += new System.EventHandler(this.max_Click);
            // 
            // dc
            // 
            this.dc.AutoSize = true;
            this.dc.BackColor = System.Drawing.Color.OrangeRed;
            this.dc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dc.Location = new System.Drawing.Point(32, 4);
            this.dc.Name = "dc";
            this.dc.Padding = new System.Windows.Forms.Padding(3);
            this.dc.Size = new System.Drawing.Size(74, 19);
            this.dc.TabIndex = 0;
            this.dc.Text = "Desconectar";
            this.dc.Visible = false;
            this.dc.Click += new System.EventHandler(this.dc_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-11, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyform);
            // 
            // HomeBox
            // 
            this.HomeBox.BackColor = System.Drawing.Color.Transparent;
            this.HomeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBox.Location = new System.Drawing.Point(0, 0);
            this.HomeBox.Name = "HomeBox";
            this.HomeBox.Size = new System.Drawing.Size(28, 26);
            this.HomeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HomeBox.TabIndex = 9;
            this.HomeBox.TabStop = false;
            this.HomeBox.Click += new System.EventHandler(this.HomeBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-33, -22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "H";
            // 
            // RemoteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 404);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.max);
            this.Controls.Add(this.HomeBox);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyform);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label dc;
        private Label max;
        private Timer timer1;
        private TextBox textBox1;
        private PictureBox HomeBox;
        private Label label1;
    }
}