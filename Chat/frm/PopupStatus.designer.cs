using System.ComponentModel;
using System.Windows.Forms;
using Trestan;

namespace Chat
{
    partial class PopupStatus
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbltitle1 = new System.Windows.Forms.Label();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.Pnlcenters = new System.Windows.Forms.Panel();
            this.foco = new System.Windows.Forms.TextBox();
            this.Message = new Trestan.TRichTextBox();
            this.AvatarIMG = new System.Windows.Forms.PictureBox();
            this.pnlTitlebar.SuspendLayout();
            this.Pnlcenters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 2);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltitle1
            // 
            this.lbltitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lbltitle1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbltitle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle1.ForeColor = System.Drawing.Color.White;
            this.lbltitle1.Location = new System.Drawing.Point(1, 41);
            this.lbltitle1.Name = "lbltitle1";
            this.lbltitle1.Size = new System.Drawing.Size(180, 22);
            this.lbltitle1.TabIndex = 1;
            this.lbltitle1.Text = "KosmoChat";
            this.lbltitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlTitlebar.Controls.Add(this.lblTitle);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(1, 1);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(180, 2);
            this.pnlTitlebar.TabIndex = 10;
            // 
            // Pnlcenters
            // 
            this.Pnlcenters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.Pnlcenters.Controls.Add(this.foco);
            this.Pnlcenters.Controls.Add(this.Message);
            this.Pnlcenters.Controls.Add(this.AvatarIMG);
            this.Pnlcenters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnlcenters.Location = new System.Drawing.Point(1, 3);
            this.Pnlcenters.Name = "Pnlcenters";
            this.Pnlcenters.Size = new System.Drawing.Size(180, 38);
            this.Pnlcenters.TabIndex = 11;
            // 
            // foco
            // 
            this.foco.Location = new System.Drawing.Point(207, 18);
            this.foco.Name = "foco";
            this.foco.Size = new System.Drawing.Size(10, 20);
            this.foco.TabIndex = 2;
            // 
            // Message
            // 
            this.Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Message.Cursor = System.Windows.Forms.Cursors.Default;
            this.Message.DetectUrls = false;
            this.Message.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(41, 4);
            this.Message.Margin = new System.Windows.Forms.Padding(0);
            this.Message.Name = "Message";
            this.Message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Message.Size = new System.Drawing.Size(134, 30);
            this.Message.TabIndex = 122;
            this.Message.Text = "";
            this.Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Message_KeyDown);
            this.Message.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Message_MouseMove);
            // 
            // AvatarIMG
            // 
            this.AvatarIMG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.AvatarIMG.Location = new System.Drawing.Point(3, 3);
            this.AvatarIMG.Name = "AvatarIMG";
            this.AvatarIMG.Size = new System.Drawing.Size(32, 32);
            this.AvatarIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AvatarIMG.TabIndex = 0;
            this.AvatarIMG.TabStop = false;
            // 
            // PopupStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(182, 63);
            this.Controls.Add(this.Pnlcenters);
            this.Controls.Add(this.lbltitle1);
            this.Controls.Add(this.pnlTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupStatus";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowInTaskbar = false;
            this.Text = "PopupStatus";
            this.pnlTitlebar.ResumeLayout(false);
            this.Pnlcenters.ResumeLayout(false);
            this.Pnlcenters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarIMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblTitle;
        private Label lbltitle1;
        private Panel pnlTitlebar;
        private Panel Pnlcenters;
        private PictureBox AvatarIMG;
        private TRichTextBox Message;
        private TextBox foco;
    }
}