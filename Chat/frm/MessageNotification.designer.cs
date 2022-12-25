using System.ComponentModel;
using System.Windows.Forms;

namespace Chat
{
    partial class MessageNotification
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
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lbltitle1 = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblChat = new System.Windows.Forms.Label();
            this.lblpin = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlcall = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlbot = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlTop);
            this.pnlContent.Controls.Add(this.pnlcall);
            this.pnlContent.Controls.Add(this.lblpin);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.lblChat);
            this.pnlContent.Controls.Add(this.lblDisplayName);
            this.pnlContent.Controls.Add(this.lbltitle1);
            this.pnlContent.Controls.Add(this.lblPhoto);
            this.pnlContent.Controls.SetChildIndex(this.lblContent, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblTest, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblPhoto, 0);
            this.pnlContent.Controls.SetChildIndex(this.lbltitle1, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblDisplayName, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblChat, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblTitle, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblpin, 0);
            this.pnlContent.Controls.SetChildIndex(this.pnlcall, 0);
            this.pnlContent.Controls.SetChildIndex(this.pnlTop, 0);
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(12, 30);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(35, 13);
            this.lblPhoto.TabIndex = 2;
            this.lblPhoto.Text = "label1";
            // 
            // lbltitle1
            // 
            this.lbltitle1.AutoSize = true;
            this.lbltitle1.Location = new System.Drawing.Point(12, 43);
            this.lbltitle1.Name = "lbltitle1";
            this.lbltitle1.Size = new System.Drawing.Size(35, 13);
            this.lbltitle1.TabIndex = 3;
            this.lbltitle1.Text = "label2";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(12, 69);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(35, 13);
            this.lblDisplayName.TabIndex = 4;
            this.lblDisplayName.Text = "label3";
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Location = new System.Drawing.Point(12, 56);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(35, 13);
            this.lblChat.TabIndex = 5;
            this.lblChat.Text = "label4";
            // 
            // lblpin
            // 
            this.lblpin.AutoSize = true;
            this.lblpin.Location = new System.Drawing.Point(12, 95);
            this.lblpin.Name = "lblpin";
            this.lblpin.Size = new System.Drawing.Size(35, 13);
            this.lblpin.TabIndex = 7;
            this.lblpin.Text = "label2";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 82);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "label1";
            // 
            // pnlcall
            // 
            this.pnlcall.Location = new System.Drawing.Point(0, 0);
            this.pnlcall.Name = "pnlcall";
            this.pnlcall.Size = new System.Drawing.Size(200, 100);
            this.pnlcall.TabIndex = 8;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlbot);
            this.pnlTop.Location = new System.Drawing.Point(35, 49);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(200, 100);
            this.pnlTop.TabIndex = 9;
            // 
            // pnlbot
            // 
            this.pnlbot.Location = new System.Drawing.Point(8, 8);
            this.pnlbot.Name = "pnlbot";
            this.pnlbot.Size = new System.Drawing.Size(200, 100);
            this.pnlbot.TabIndex = 10;
            // 
            // MessageNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(270, 198);
            this.Name = "MessageNotification";
            this.Text = "MessageNotification";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblPhoto;
        private Label lblChat;
        private Label lblDisplayName;
        private Label lbltitle1;
        private Label lblpin;
        private Label lblTitle;
        private Panel pnlTop;
        private Panel pnlcall;
        private Panel pnlbot;
    }
}