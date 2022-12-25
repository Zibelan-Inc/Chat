using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class FlatDropDown : UserControl
{
    private IContainer components;

    [CompilerGenerated]
    [AccessedThroughProperty("CBox")]
    private ComboBox _CBox;

    internal virtual ComboBox CBox
    {
        [CompilerGenerated]
        get
        {
            return _CBox;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            EventHandler value2 = CBox_EnabledChanged;
            ComboBox cBox = _CBox;
            if (cBox != null)
            {
                cBox.EnabledChanged -= value2;
            }
            _CBox = value;
            cBox = _CBox;
            if (cBox != null)
            {
                cBox.EnabledChanged += value2;
            }
        }
    }

    [Category("Appearance")]
    public ComboBoxStyle DropDownStyle
    {
        get
        {
            return CBox.DropDownStyle;
        }
        set
        {
            CBox.DropDownStyle = value;
        }
    }

    [Category("Appearance")]
    public bool ComboBoxEnabled
    {
        get
        {
            return CBox.Enabled;
        }
        set
        {
            CBox.Enabled = value;
        }
    }

    [Category("Appearance")]
    public Color FlatBackColor
    {
        get
        {
            return BackColor;
        }
        set
        {
            BackColor = value;
        }
    }

    public FlatDropDown()
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
        CBox = new ComboBox();
        SuspendLayout();
        CBox.Dock = DockStyle.Fill;
        CBox.DropDownStyle = ComboBoxStyle.DropDownList;
        CBox.FlatStyle = FlatStyle.Flat;
        CBox.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        CBox.FormattingEnabled = true;
        CBox.Location = new Point(1, 1);
        CBox.Name = "CBox";
        CBox.Size = new Size(393, 23);
        CBox.TabIndex = 0;
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        base.Controls.Add(CBox);
        base.Name = "FlatDropDown";
        base.Padding = new Padding(1);
        base.Size = new Size(395, 25);
        ResumeLayout(performLayout: false);
    }

    private void CBox_EnabledChanged(object sender, EventArgs e)
    {
        if (!CBox.Enabled)
        {
            BackColor = Color.White;
        }
        else
        {
            BackColor = Color.LightGray;
        }
    }
}
