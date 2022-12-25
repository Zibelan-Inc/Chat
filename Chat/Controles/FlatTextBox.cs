using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class FlatTextBox : UserControl
{
    private IContainer components;


    private string _waterMarkText;

    private TextBox TBox;

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
            TBox.Text = _waterMarkText;
            if (!string.IsNullOrEmpty(value))
            {
                TBox.ForeColor = Color.Gray;
            }
        }
    }

    [Category("Appearance")]
    public bool ReadOnly
    {
        get
        {
            return TBox.ReadOnly;
        }
        set
        {
            TBox.ReadOnly = value;
            if (value)
            {
                TPanel.BackColor = TBox.BackColor;
            }
        }
    }

    [Category("Appearance")]
    public string FlatPasswordChar
    {
        get
        {
            return Conversions.ToString(TBox.PasswordChar);
        }
        set
        {
            TBox.PasswordChar = Conversions.ToChar(value);
        }
    }

    public FlatTextBox()
    {
        InitializeComponent();
        TBox.GotFocus += TBox_GotFocus;
        TBox.LostFocus += TBox_LostFocus;

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
            this.TBox = new TextBox();
            this.TPanel = new Panel();
            this.TPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBox
            // 
            this.TBox.BorderStyle = BorderStyle.None;
            this.TBox.Dock = DockStyle.Fill;
            this.TBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.TBox.Location = new Point(5, 3);
            this.TBox.Name = "TBox";
            this.TBox.Size = new Size(217, 16);
            this.TBox.TabIndex = 0;
            this.TBox.Text = "test";
            // 
            // TPanel
            // 
            this.TPanel.BackColor = Color.White;
            this.TPanel.Controls.Add(this.TBox);
            this.TPanel.Dock = DockStyle.Fill;
            this.TPanel.Location = new Point(1, 1);
            this.TPanel.Name = "TPanel";
            this.TPanel.Padding = new Padding(5, 3, 5, 3);
            this.TPanel.Size = new Size(227, 23);
            this.TPanel.TabIndex = 1;
            // 
            // FlatTextBox
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.TPanel);
            this.Name = "FlatTextBox";
            this.Padding = new Padding(1);
            this.Size = new Size(229, 25);
            this.TPanel.ResumeLayout(false);
            this.TPanel.PerformLayout();
            this.ResumeLayout(false);

    }

    private void TBox_GotFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WaterMarkText) && TBox.Text.Equals(WaterMarkText))
        {
            TBox.Text = string.Empty;
            TBox.ForeColor = Color.Black;
        }
    }

    private void TBox_LostFocus(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WaterMarkText) && string.IsNullOrEmpty(TBox.Text))
        {
            TBox.Text = WaterMarkText;
            TBox.ForeColor = Color.Gray;
        }
    }
}
