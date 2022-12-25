using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;
using Chat;

[DesignerGenerated]
public class HackTextBox : UserControl
{
    private IContainer components;

    //
    private Label lblPersonalmsg;
    private TextBox txtPersonalmsg;
    public Panel pnltxtPersonalMsg;
    public Label lblPersonalMsgBottom;
    public Label lblPMArrow;
    //



    private string _waterMarkText;


    private Panel TPanel;

    [Category("Appearance")]
    public string WaterMarkText
    {
        get
        {
            return _waterMarkText;
        }
        set
        {
            _waterMarkText = value;
            txtPersonalmsg.Text = _waterMarkText;
            if (!string.IsNullOrEmpty(value))
            {
                txtPersonalmsg.ForeColor = Color.Gray;
            }
        }
    }

    [Category("Appearance")]
    public bool ReadOnly
    {
        get
        {
            return txtPersonalmsg.ReadOnly;
        }
        set
        {
            txtPersonalmsg.ReadOnly = value;
            if (value)
            {
                TPanel.BackColor = txtPersonalmsg.BackColor;
            }
        }
    }

    [Category("Appearance")]
    public string FlatPasswordChar
    {
        get
        {
            return Conversions.ToString(txtPersonalmsg.PasswordChar);
        }
        set
        {
            txtPersonalmsg.PasswordChar = Conversions.ToChar(value);
        }
    }

    public HackTextBox()
    {
        InitializeComponent();

    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
        lblPersonalmsg = new Label();
        this.lblPMArrow = new Label();
        this.lblPersonalMsgBottom = new Label();
        this.txtPersonalmsg = new TextBox();
        this.pnltxtPersonalMsg = new Panel();
        this.pnltxtPersonalMsg.SuspendLayout();
        this.SuspendLayout();

        this.pnltxtPersonalMsg.BackColor = Color.White;
        this.pnltxtPersonalMsg.Controls.Add(this.lblPersonalMsgBottom);
        this.pnltxtPersonalMsg.Controls.Add(this.lblPMArrow);
        this.pnltxtPersonalMsg.Controls.Add(this.lblPersonalmsg);
        this.pnltxtPersonalMsg.Controls.Add(this.txtPersonalmsg);
        this.pnltxtPersonalMsg.Dock = DockStyle.Fill;
        this.pnltxtPersonalMsg.Location = new Point(91, 0);
        this.pnltxtPersonalMsg.Name = "pnltxtPersonalMsg";
        this.pnltxtPersonalMsg.Padding = new Padding(2, 3, 2, 2);
        this.pnltxtPersonalMsg.Size = new Size(180, 22);
        this.pnltxtPersonalMsg.TabIndex = 18;
        this.pnltxtPersonalMsg.MouseLeave += new EventHandler(this.pnltxtPersonalMsg_MouseLeave);
        this.pnltxtPersonalMsg.MouseMove += new MouseEventHandler(this.pnltxtPersonalMsg_MouseMove);
        // 
        // lblPersonalMsgBottom
        // 
        this.lblPersonalMsgBottom.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
        | AnchorStyles.Right)));
        this.lblPersonalMsgBottom.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
        this.lblPersonalMsgBottom.Location = new Point(2, 21);
        this.lblPersonalMsgBottom.Name = "lblPersonalMsgBottom";
        this.lblPersonalMsgBottom.Size = new Size(167, 1);
        this.lblPersonalMsgBottom.TabIndex = 25;
        this.lblPersonalMsgBottom.Visible = false;
        // 
        // lblPMArrow
        // 
        this.lblPMArrow.BackColor = Color.White;
        this.lblPMArrow.Dock = DockStyle.Right;
        this.lblPMArrow.Image = Resources.arrow2s;
        this.lblPMArrow.Location = new Point(156, 3);
        this.lblPMArrow.Name = "lblPMArrow";
        this.lblPMArrow.Size = new Size(22, 17);
        this.lblPMArrow.TabIndex = 6;
        this.lblPMArrow.Click += new EventHandler(this.lblPMArrow_Click);
        // 
        // lblPersonalmsg
        // 
        this.lblPersonalmsg.AutoEllipsis = true;
        this.lblPersonalmsg.BackColor = Color.White;
        this.lblPersonalmsg.Dock = DockStyle.Fill;
        this.lblPersonalmsg.ForeColor = Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
        this.lblPersonalmsg.Location = new Point(2, 3);
        this.lblPersonalmsg.Margin = new Padding(0);
        this.lblPersonalmsg.Name = "lblPersonalmsg";
        this.lblPersonalmsg.Size = new Size(176, 17);
        this.lblPersonalmsg.TabIndex = 24;
        this.lblPersonalmsg.Text = "Personalizar estado";
        this.lblPersonalmsg.TextAlign = ContentAlignment.MiddleLeft;
        this.lblPersonalmsg.Click += new EventHandler(this.lblPersonalmsg_Click);
        this.lblPersonalmsg.MouseLeave += new EventHandler(this.lblPersonalmsg_MouseLeave);
        this.lblPersonalmsg.MouseMove += new MouseEventHandler(this.lblPersonalmsg_MouseMove);
        // 
        // txtPersonalmsg
        // 
        this.txtPersonalmsg.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
        | AnchorStyles.Right)));
        this.txtPersonalmsg.BackColor = Color.White;
        this.txtPersonalmsg.BorderStyle = BorderStyle.None;
        this.txtPersonalmsg.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        this.txtPersonalmsg.Location = new Point(5, 4);
        this.txtPersonalmsg.Name = "txtPersonalmsg";
        this.txtPersonalmsg.Size = new Size(165, 16);
        this.txtPersonalmsg.TabIndex = 23;
        this.txtPersonalmsg.TabStop = false;
        this.txtPersonalmsg.Visible = false;
        this.txtPersonalmsg.TextChanged += new EventHandler(this.txtPersonalmsg_TextChanged);
        this.txtPersonalmsg.KeyDown += new KeyEventHandler(this.txtPersonalmsg_KeyDown);
        this.txtPersonalmsg.LostFocus += new EventHandler(this.txtPersonalmsg_LostFocus);
        // 
        // FlatTextBox
        // 
        this.AutoScaleDimensions = new SizeF(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.Controls.Add(this.pnltxtPersonalMsg);
        this.Name = "FlatTextBox";
        this.Padding = new Padding(1);
        this.Size = new Size(229, 25);
        this.pnltxtPersonalMsg.ResumeLayout(false);
        this.pnltxtPersonalMsg.PerformLayout();
        this.ResumeLayout(false);
    }
    private void lblPMArrow_Click(object sender, EventArgs e)
    {
        try
        {
            /*
            frmUsers.frm.LoadCustomStatus();
            frmUsers.frm.mnuCustomStatus.Show((Control)this.lblPMArrow, new Point(0, 20));
            */
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
        }

    }
    private void pnltxtPersonalMsg_MouseLeave(object sender, EventArgs e)
    {
        this.ShowPersonalMessageBottomBorder(false);
    }

    private void pnltxtPersonalMsg_MouseMove(object sender, MouseEventArgs e)
    {
        this.ShowPersonalMessageBottomBorder(true);
    }
    private void txtPersonalmsg_KeyDown(object sender, KeyEventArgs e)
    {
        try
        {
            if (e.KeyCode == Keys.Return)
            {
                ShowPersonalMessageBottomBorder(false);
                this.HidePersonalMsg();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ShowPersonalMessageBottomBorder(false);
                e.SuppressKeyPress = true;
            }
            else
            {
                if (e.KeyCode != Keys.Tab)
                    return;
                e.SuppressKeyPress = true;
            }

        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
        }

    }
    private void txtPersonalmsg_LostFocus(object sender, EventArgs e)
    {
        this.HidePersonalMsg();
    }
    private void HidePersonalMsg()
    {
        try
        {
            txtPersonalmsg.SendToBack();
            pnltxtPersonalMsg.BorderStyle = BorderStyle.None;
            pnltxtPersonalMsg.BackColor = Color.Transparent;
            txtPersonalmsg.Visible = false;
            lblPersonalmsg.BringToFront();
            lblPersonalmsg.Visible = true;
            lblPMArrow.Visible = true;
            if (string.IsNullOrEmpty(txtPersonalmsg.Text))
            {
                lblPersonalmsg.Text = "Personalizar estado";
                ShowPersonalMessageBottomBorder(false);
            }
            else
            {
                lblPersonalmsg.Text = txtPersonalmsg.Text;
                ShowPersonalMessageBottomBorder(false);
            }
            ShowPersonalMessageBottomBorder(false);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            ProjectData.ClearProjectError();
        }
    }

    private void txtPersonalmsg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPersonalmsg.Equals("") || txtPersonalmsg.Text.Length == 1)
            {
                
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            WriteLog.Save(ex2);
            ProjectData.ClearProjectError();
        }
    }

    private void lblPersonalmsg_Click(object sender, EventArgs e)
    {
        try
        {
            this.HideSearch(false, true);
            this.ShowPersonalMsg();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
        }
    }
    private void ShowPersonalMessageBottomBorder(bool val)
    {
        try
        {
            if (this.txtPersonalmsg.Focused && !val)
                return;
            this.lblPersonalMsgBottom.Visible = val;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            WriteLog.Save(ex);
            ProjectData.ClearProjectError();
        }
    }
    private void lblPersonalmsg_MouseLeave(object sender, EventArgs e)
    {
        this.ShowPersonalMessageBottomBorder(false);
    }

    private void lblPersonalmsg_MouseMove(object sender, MouseEventArgs e)
    {
        this.ShowPersonalMessageBottomBorder(true);
    }
    public bool _hidesearch;
    public void HideSearch(bool hide = false, bool focusPluginList = true)
    {
        try
        {
            if (!this._hidesearch && !hide)
            {
                this._hidesearch = true;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            WriteLog.Save(ex);
            ProjectData.ClearProjectError();
        }
    }
    private void ShowPersonalMsg()
    {
        try
        {
            this.lblPersonalmsg.SendToBack();
            this.lblPersonalmsg.Visible = false;
            this.lblPMArrow.Visible = false;
            this.txtPersonalmsg.Visible = true;
            this.pnltxtPersonalMsg.BackColor = Color.White;
            this.txtPersonalmsg.BringToFront();
            this.txtPersonalmsg.Focus();
            this.ShowPersonalMessageBottomBorder(true);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
        }
    }


}
