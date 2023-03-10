using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class AddLabel : Label
{
    private IContainer components;

    [DebuggerNonUserCode]
    public AddLabel(IContainer container)
        : this()
    {
        container?.Add(this);
    }

    [DebuggerNonUserCode]
    public AddLabel()
    {
        base.MouseLeave += AddLabel_MouseLeave;
        base.MouseMove += AddLabel_MouseMove;
        base.MouseDown += AddLabel_MouseDown;
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
        components = new Container();
    }

    private void AddLabel_MouseLeave(object sender, EventArgs e)
    {
        ForeColor = ColorTranslator.FromHtml("#BCBCBC");
    }

    private void AddLabel_MouseMove(object sender, MouseEventArgs e)
    {
        ForeColor = ColorTranslator.FromHtml("#858C93");
    }

    private void AddLabel_MouseDown(object sender, MouseEventArgs e)
    {
        ForeColor = ColorTranslator.FromHtml("#525252");
    }
}

