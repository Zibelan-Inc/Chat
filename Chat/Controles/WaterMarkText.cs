using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class WaterMarkText : UserControl
{
    private IContainer components;

    [CompilerGenerated]
    [AccessedThroughProperty("TBox")]
    private TextBox _TBox;

    private string _waterMarkText;

    internal virtual TextBox TBox
    {
        [CompilerGenerated]
        get
        {
            return _TBox;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            EventHandler value2 = TBox_GotFocus;
            EventHandler value3 = TBox_LostFocus;
            TextBox tBox = _TBox;
            if (tBox != null)
            {
                tBox.GotFocus -= value2;
                tBox.LostFocus -= value3;
            }
            _TBox = value;
            tBox = _TBox;
            if (tBox != null)
            {
                tBox.GotFocus += value2;
                tBox.LostFocus += value3;
            }
        }
    }

    [Category("Appearance")]
    public string WatermarkText
    {
        get
        {
            return _waterMarkText;
        }
        set
        {
            if (TBox != null)
            {
                TBox.Text = value;
                _waterMarkText = value;
                if (!string.IsNullOrEmpty(value))
                {
                    TBox.ForeColor = Color.Gray;
                }
            }
        }
    }

    public WaterMarkText()
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
        TextBox TBox = new TextBox();
        SuspendLayout();
        TBox.BorderStyle = BorderStyle.None;
        TBox.Dock = DockStyle.Fill;
        TBox.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        TBox.Location = new Point(0, 0);
        TBox.Name = "TBox";
        TBox.Size = new Size(229, 16);
        TBox.TabIndex = 0;
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        base.Controls.Add(TBox);
        base.Name = "WaterMarkText";
        base.Size = new Size(229, 16);
        ResumeLayout(performLayout: false);
        PerformLayout();
    }

    private void TBox_GotFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WatermarkText) && TBox.Text.Equals(WatermarkText))
        {
            TBox.Text = string.Empty;
            TBox.ForeColor = Color.Black;
        }
    }

    private void TBox_LostFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WatermarkText) && string.IsNullOrEmpty(TBox.Text))
        {
            TBox.Text = WatermarkText;
            TBox.ForeColor = Color.Gray;
        }
    }

    public void TBoxTextChanged()
    {
        try
        {
            if (string.IsNullOrEmpty(TBox.Text) || Operators.CompareString(TBox.Text, WatermarkText, TextCompare: false) == 0)
            {
                TBox.ForeColor = Color.Gray;
            }
            else
            {
                TBox.ForeColor = Color.Black;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            ProjectData.ClearProjectError();
        }
    }
}
