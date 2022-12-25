using Chat.Properties;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chat.Forms
{
    partial class frmBorder
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
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblTitle = new DragLabel();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOMicon = new System.Windows.Forms.PictureBox();
            this.pnlTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitlebar.Controls.Add(this.lblOMicon);
            this.pnlTitlebar.Controls.Add(this.lblTitle);
            this.pnlTitlebar.Controls.Add(this.lblMin);
            this.pnlTitlebar.Controls.Add(this.lblMax);
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(284, 25);
            this.pnlTitlebar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ContainerForm = null;
            this.lblTitle.ContainerFrm = null;
            this.lblTitle.CopyTextOnDoubleClick = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMin
            // 
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMin.Image = global::Chat.Properties.Resources.min;
            this.lblMin.Location = new System.Drawing.Point(184, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(25, 25);
            this.lblMin.TabIndex = 2;
            // 
            // lblMax
            // 
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMax.Image = global::Chat.Properties.Resources.max1;
            this.lblMax.Location = new System.Drawing.Point(209, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(25, 25);
            this.lblMax.TabIndex = 1;
            this.lblMax.Tag = "Restore";
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = global::Chat.Properties.Resources.close_new;
            this.lblClose.Location = new System.Drawing.Point(234, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(50, 25);
            this.lblClose.TabIndex = 0;
            // 
            // lblOMicon
            // 
            this.lblOMicon.BackColor = System.Drawing.Color.Transparent;
            this.lblOMicon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOMicon.Image = global::Chat.Properties.Resources.Logo_SC;
            this.lblOMicon.Location = new System.Drawing.Point(0, 0);
            this.lblOMicon.Name = "lblOMicon";
            this.lblOMicon.Size = new System.Drawing.Size(30, 25);
            this.lblOMicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblOMicon.TabIndex = 3;
            this.lblOMicon.TabStop = false;
            // 
            // frmBorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnlTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBorder";
            this.Text = "frmBorder";
            this.pnlTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOMicon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Label lblMin;
        public Label lblMax;
        public Label lblClose;
        public Panel panel1;
        public Panel pnlTitlebar;
        public DragLabel lblTitle;
        public PictureBox lblOMicon;
    }
}