using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class YesNoCheckBox : UserControl
{
    public delegate void OnCheckedEventHandler(bool val);

    private IContainer components;

    [CompilerGenerated]
    [AccessedThroughProperty("lblNo")]
    private Label _lblNo;

    [CompilerGenerated]
    [AccessedThroughProperty("lblYes")]
    private Label _lblYes;

    private bool _isChecked;

    [CompilerGenerated]
    private OnCheckedEventHandler OnCheckedEvent;

    internal virtual Label lblNo
    {
        [CompilerGenerated]
        get
        {
            return _lblNo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            EventHandler value2 = lblYes_Click;
            Label lblNo = _lblNo;
            if (lblNo != null)
            {
                lblNo.Click -= value2;
            }
            _lblNo = value;
            lblNo = _lblNo;
            if (lblNo != null)
            {
                lblNo.Click += value2;
            }
        }
    }

    internal virtual Label lblYes
    {
        [CompilerGenerated]
        get
        {
            return _lblYes;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            EventHandler value2 = lblYes_Click;
            Label lblYes = _lblYes;
            if (lblYes != null)
            {
                lblYes.Click -= value2;
            }
            _lblYes = value;
            lblYes = _lblYes;
            if (lblYes != null)
            {
                lblYes.Click += value2;
            }
        }
    }

    public bool IsChecked
    {
        get
        {
            return _isChecked;
        }
        set
        {
            _isChecked = value;
            ToggleBox();
        }
    }

    public event OnCheckedEventHandler OnChecked
    {
        [CompilerGenerated]
        add
        {
            OnCheckedEventHandler onCheckedEventHandler = OnCheckedEvent;
            OnCheckedEventHandler onCheckedEventHandler2;
            do
            {
                onCheckedEventHandler2 = onCheckedEventHandler;
                OnCheckedEventHandler value2 = (OnCheckedEventHandler)Delegate.Combine(onCheckedEventHandler2, value);
                onCheckedEventHandler = Interlocked.CompareExchange(ref OnCheckedEvent, value2, onCheckedEventHandler2);
            }
            while ((object)onCheckedEventHandler != onCheckedEventHandler2);
        }
        [CompilerGenerated]
        remove
        {
            OnCheckedEventHandler onCheckedEventHandler = OnCheckedEvent;
            OnCheckedEventHandler onCheckedEventHandler2;
            do
            {
                onCheckedEventHandler2 = onCheckedEventHandler;
                OnCheckedEventHandler value2 = (OnCheckedEventHandler)Delegate.Remove(onCheckedEventHandler2, value);
                onCheckedEventHandler = Interlocked.CompareExchange(ref OnCheckedEvent, value2, onCheckedEventHandler2);
            }
            while ((object)onCheckedEventHandler != onCheckedEventHandler2);
        }
    }

    public YesNoCheckBox()
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
        lblNo = new Label();
        lblYes = new Label();
        SuspendLayout();
        lblNo.BackColor = Color.White;
        lblNo.Cursor = Cursors.Hand;
        lblNo.Dock = DockStyle.Right;
        lblNo.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNo.Location = new Point(42, 2);
        lblNo.Name = "lblNo";
        lblNo.Size = new Size(40, 21);
        lblNo.TabIndex = 13;
        lblNo.Text = "NO";
        lblNo.TextAlign = ContentAlignment.MiddleCenter;
        lblYes.BackColor = Color.FromArgb(7, 164, 245);
        lblYes.Cursor = Cursors.Hand;
        lblYes.Dock = DockStyle.Left;
        lblYes.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblYes.ForeColor = Color.White;
        lblYes.Location = new Point(2, 2);
        lblYes.Name = "lblYes";
        lblYes.Padding = new Padding(2);
        lblYes.Size = new Size(40, 21);
        lblYes.TabIndex = 12;
        lblYes.Text = "SI";
        lblYes.TextAlign = ContentAlignment.MiddleCenter;
        base.AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(7, 164, 245);
        base.Controls.Add(lblNo);
        base.Controls.Add(lblYes);
        base.Name = "YesNoCheckBox";
        base.Padding = new Padding(2);
        base.Size = new Size(84, 25);
        ResumeLayout(performLayout: false);
    }

    private void lblYes_Click(object sender, EventArgs e)
    {
        IsChecked = !IsChecked;
        RainseOnChecked();
    }

    private void ToggleBox()
    {
        try
        {
            lblYes.Text = string.Empty;
            lblNo.Text = string.Empty;
            lblYes.BackColor = Color.White;
            lblNo.BackColor = Color.White;
            if (IsChecked)
            {
                lblYes.BackColor = ColorTranslator.FromHtml("#07A4F5");
                lblYes.Text = "SI";
                BackColor = lblYes.BackColor;
            }
            else
            {
                lblNo.Text = "No";
                lblNo.BackColor = ColorTranslator.FromHtml("#CACACA");
                BackColor = lblNo.BackColor;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            //Func.AppendFile(ex2);
            ProjectData.ClearProjectError();
        }
    }

    private void RainseOnChecked()
    {
        try
        {
            OnCheckedEvent?.Invoke(IsChecked);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            //Func.AppendFile(ex2);
            ProjectData.ClearProjectError();
        }
    }
}
