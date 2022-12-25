using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class WaterMarkRichText : UserControl
{
    private IContainer components;

    [CompilerGenerated]
    [AccessedThroughProperty("RichBox")]
    private RichTextBox _RichBox;

    private string _waterMarkText;

    internal virtual RichTextBox RichBox
    {
        [CompilerGenerated]
        get
        {
            return _RichBox;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            EventHandler value2 = RichBox_GotFocus;
            EventHandler value3 = RichBox_LostFocus;
            RichTextBox richBox = _RichBox;
            if (richBox != null)
            {
                richBox.GotFocus -= value2;
                richBox.LostFocus -= value3;
            }
            _RichBox = value;
            richBox = _RichBox;
            if (richBox != null)
            {
                richBox.GotFocus += value2;
                richBox.LostFocus += value3;
            }
        }
    }

    [Category("Appearance")]
    public string WaterMarkText
    {
        get
        {
            return _waterMarkText;
        }
        set
        {
            var richTextBox = this.RichBox;
            if (richTextBox != null)
            {
                richTextBox.Text = value;
                this._waterMarkText = value;
                if (string.IsNullOrEmpty(value))
                    return;
                richTextBox.ForeColor = Color.Gray;
            }
        }
    }

    public WaterMarkRichText()
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
        RichTextBox RichBox = new RichTextBox();
        SuspendLayout();
        RichBox.BackColor = Color.White;
        RichBox.BorderStyle = BorderStyle.None;
        RichBox.Dock = DockStyle.Fill;
        RichBox.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
        RichBox.Location = new Point(0, 0);
        RichBox.Name = "RichBox";
        RichBox.Size = new Size(356, 212);
        RichBox.TabIndex = 5;
        RichBox.Text = "";
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        base.Controls.Add(RichBox);
        base.Name = "WaterMarkRichText";
        base.Size = new Size(356, 212);
        ResumeLayout(performLayout: false);
    }

    private void RichBox_GotFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WaterMarkText) && RichBox.Text.Equals(WaterMarkText))
        {
            RichBox.Text = string.Empty;
            RichBox.ForeColor = Color.Black;
        }
    }

    private void RichBox_LostFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WaterMarkText) && string.IsNullOrEmpty(RichBox.Text))
        {
            RichBox.Text = WaterMarkText;
            RichBox.ForeColor = Color.Gray;
        }
    }

    public void RichBoxTextChanged()
    {
        try
        {
            if (string.IsNullOrEmpty(RichBox.Text) || Operators.CompareString(RichBox.Text, WaterMarkText, TextCompare: false) == 0)
            {
                RichBox.Text = WaterMarkText;
                RichBox.ForeColor = Color.Gray;
            }
            else
            {
                RichBox.ForeColor = Color.Black;
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
