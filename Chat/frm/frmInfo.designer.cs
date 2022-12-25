using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Trestan;

namespace Chat
{
    partial class frmInfo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfo));
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.txtMessages = new Trestan.TRichTextBox();
            this.Ok = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(261, 46);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(128, 117);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 4;
            this.Avatar.TabStop = false;
            this.Avatar.Visible = false;
            this.Avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Avatar_MouseDoubleClick);
            this.Avatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Avatar_MouseDown);
            this.Avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Avatar_MouseMove);
            this.Avatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Avatar_MouseUp);
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMessages.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.ForeColor = System.Drawing.Color.White;
            this.txtMessages.Location = new System.Drawing.Point(5, 46);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(384, 118);
            this.txtMessages.TabIndex = 20;
            this.txtMessages.Text = "";
            this.txtMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessages_KeyDown);
            // 
            // Ok
            // 
            this.Ok.CheckedState.Parent = this.Ok;
            this.Ok.CustomImages.Parent = this.Ok;
            this.Ok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ok.ForeColor = System.Drawing.Color.White;
            this.Ok.HoverState.Parent = this.Ok;
            this.Ok.Location = new System.Drawing.Point(305, 171);
            this.Ok.Name = "Ok";
            this.Ok.ShadowDecoration.Parent = this.Ok;
            this.Ok.Size = new System.Drawing.Size(84, 23);
            this.Ok.TabIndex = 21;
            this.Ok.Text = "Aceptar";
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblClose);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(393, 29);
            this.guna2Panel1.TabIndex = 22;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClose.Image = global::Chat.Properties.Resources.close;
            this.lblClose.Location = new System.Drawing.Point(344, -1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(45, 29);
            this.lblClose.TabIndex = 33;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(393, 203);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.txtMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TRichTextBox txtMessages;
        private PictureBox Avatar;
        private Guna.UI2.WinForms.Guna2Button Ok;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Label lblClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}

