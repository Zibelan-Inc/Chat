// Decompiled with JetBrains decompiler
// Type: OutputMessenger.LabelEx
// Assembly: OutputMessenger, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: ACB4D6A8-252D-43BA-9D59-AF7222307917
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OutputMessenger.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Chat
{
  public class LabelEx : Label
  {
    private Image _orgImage;
    private bool _needOpacity;

    [Category("Appearance")]
    [RefreshProperties(RefreshProperties.All)]
    public Color OpacityColor { get; set; }

    [Category("Appearance")]
    [RefreshProperties(RefreshProperties.All)]
    public Color OrgBackColor { get; set; }

    [Category("Appearance")]
    [RefreshProperties(RefreshProperties.All)]
    public bool NeedOpacity
    {
      get
      {
        return this._needOpacity;
      }
      set
      {
        this._needOpacity = value;
        if (value)
          this.Cursor = Cursors.Hand;
        else
          this.Cursor = Cursors.Default;
      }
    }

    public LabelEx()
    {
      this.MouseMove += new MouseEventHandler(this.LabelEx_MouseMove);
      this.MouseLeave += new EventHandler(this.LabelEx_MouseLeave);
      this.MouseDown += new MouseEventHandler(this.LabelEx_MouseDown);
      this.MouseUp += new MouseEventHandler(this.LabelEx_MouseUp);
      this._needOpacity = true;
    }

    private void LabelEx_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.NeedOpacity)
        return;
      this.BackColor = this.OpacityColor;
    }

    private void LabelEx_MouseLeave(object sender, EventArgs e)
    {
      if (!this.NeedOpacity)
        return;
      this.BackColor = this.OrgBackColor;
    }

    private void LabelEx_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.NeedOpacity)
        return;
      this._orgImage = this.Image;
      this.Image = (Image) Modcommon.ChangeOpacity(this.Image, 0.7f);
    }

    private void LabelEx_MouseUp(object sender, MouseEventArgs e)
    {
      if (!this.NeedOpacity)
        return;
      this.Image = this._orgImage;
    }
  }
}
