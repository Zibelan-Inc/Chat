using Chat;
using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteFileSystemTester
{
    partial class frmTransferProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferProgress));
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.pbCurrentFile = new System.Windows.Forms.ProgressBar();
            this.pbOverAll = new System.Windows.Forms.ProgressBar();
            this.lblOverAllMsg = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btCancel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCurrentFile.Location = new System.Drawing.Point(12, 63);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(377, 23);
            this.lblCurrentFile.TabIndex = 0;
            this.lblCurrentFile.Text = "Idle.";
            this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbCurrentFile
            // 
            this.pbCurrentFile.Location = new System.Drawing.Point(12, 89);
            this.pbCurrentFile.Name = "pbCurrentFile";
            this.pbCurrentFile.Size = new System.Drawing.Size(377, 15);
            this.pbCurrentFile.TabIndex = 1;
            // 
            // pbOverAll
            // 
            this.pbOverAll.Location = new System.Drawing.Point(12, 131);
            this.pbOverAll.Name = "pbOverAll";
            this.pbOverAll.Size = new System.Drawing.Size(377, 15);
            this.pbOverAll.TabIndex = 2;
            // 
            // lblOverAllMsg
            // 
            this.lblOverAllMsg.AutoSize = true;
            this.lblOverAllMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverAllMsg.Location = new System.Drawing.Point(12, 114);
            this.lblOverAllMsg.Name = "lblOverAllMsg";
            this.lblOverAllMsg.Size = new System.Drawing.Size(107, 13);
            this.lblOverAllMsg.TabIndex = 3;
            this.lblOverAllMsg.Text = "Overall Progress:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 160);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(401, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btCancel
            // 
            this.btCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(36, 36);
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 61);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = Resources.folder_remote1;
            this.pictureBox1.Location = new System.Drawing.Point(339, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(321, 56);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Transfering your files...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTransferProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(401, 199);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblOverAllMsg);
            this.Controls.Add(this.pbOverAll);
            this.Controls.Add(this.pbCurrentFile);
            this.Controls.Add(this.lblCurrentFile);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTransferProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfering files";
            this.Load += new System.EventHandler(this.frmTransferProgress_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCurrentFile;
        private ProgressBar pbCurrentFile;
        private ProgressBar pbOverAll;
        private Label lblOverAllMsg;
        private ToolStrip toolStrip1;
        private ToolStripButton btCancel;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblMessage;
    }
}