using Chat.Properties;
using System.ComponentModel;
using System.Windows.Forms;
using Trestan;

namespace Chat
{
    partial class Monitorear
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
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtChat = new Trestan.TRichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Minimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtChat.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.txtChat.Location = new System.Drawing.Point(-1, 28);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(447, 266);
            this.txtChat.TabIndex = 32;
            this.txtChat.Text = "";
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Resources.close2;
            this.pictureBox1.Location = new System.Drawing.Point(410, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Minimizar
            // 
            this.Minimizar.Image = Resources.mini2;
            this.Minimizar.Location = new System.Drawing.Point(375, 1);
            this.Minimizar.Name = "Minimizar";
            this.Minimizar.Size = new System.Drawing.Size(34, 26);
            this.Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Minimizar.TabIndex = 35;
            this.Minimizar.TabStop = false;
            this.Minimizar.Click += new System.EventHandler(this.Minimizar_Click);
            // 
            // Monitorear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(444, 294);
            this.Controls.Add(this.Minimizar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Monitorear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitorear";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitorear_FormClosing);
            this.Load += new System.EventHandler(this.Monitorear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TRichTextBox txtChat;
        private PictureBox pictureBox1;
        private PictureBox Minimizar;
    }
}