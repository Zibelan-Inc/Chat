// Decompiled with JetBrains decompiler
// Type: OutputMessenger.PanelEx
// Assembly: OutputMessenger, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: ACB4D6A8-252D-43BA-9D59-AF7222307917
// Assembly location: D:\Regueros\Compartido\outputmessengers\OutputMessenger.exe

using System.Windows.Forms;

namespace OutputMessenger
{
  public class PanelEx : Panel
  {
    public PanelEx()
    {
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
  }
}
