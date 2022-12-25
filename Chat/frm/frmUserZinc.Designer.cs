using System.ComponentModel;
using System.Windows.Forms;

namespace Chat.frm
{
    partial class frmUserZinc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserZinc));
            this.UserList = new System.Windows.Forms.DataGridView();
            this.pnlTitlebar = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).BeginInit();
            this.pnlTitlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.AllowDrop = true;
            this.UserList.AllowUserToDeleteRows = false;
            this.UserList.AllowUserToResizeColumns = false;
            this.UserList.AllowUserToResizeRows = false;
            this.UserList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UserList.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.DefaultCellStyle = dataGridViewCellStyle1;
            this.UserList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserList.GridColor = System.Drawing.Color.White;
            this.UserList.Location = new System.Drawing.Point(0, 31);
            this.UserList.MultiSelect = false;
            this.UserList.Name = "UserList";
            this.UserList.RowHeadersVisible = false;
            this.UserList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserList.ShowCellToolTips = false;
            this.UserList.Size = new System.Drawing.Size(249, 283);
            this.UserList.TabIndex = 4;
            this.UserList.Tag = "U";
            this.UserList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UserList_CellMouseDoubleClick);
            this.UserList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UserList_CellMouseMove);
            this.UserList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.UserList_CellPainting);
            this.UserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyDown);
            // 
            // pnlTitlebar
            // 
            this.pnlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlTitlebar.Controls.Add(this.lblClose);
            this.pnlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitlebar.Name = "pnlTitlebar";
            this.pnlTitlebar.Size = new System.Drawing.Size(249, 25);
            this.pnlTitlebar.TabIndex = 5;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(211, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(38, 25);
            this.lblClose.TabIndex = 0;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmUserZinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(249, 314);
            this.Controls.Add(this.pnlTitlebar);
            this.Controls.Add(this.UserList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserZinc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserZinc";
            this.Load += new System.EventHandler(this.frmUserZinc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserZinc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).EndInit();
            this.pnlTitlebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridView UserList;
        public Panel pnlTitlebar;
        public Label lblClose;
    }
}