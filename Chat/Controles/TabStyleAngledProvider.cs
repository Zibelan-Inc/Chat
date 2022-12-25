// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleAngledProvider
// Assembly: OM.Tab, Version=1.9.8.0, Culture=neutral, PublicKeyToken=null
// MVID: C7A83F57-9985-40B8-B1FF-D32876037FE5
// Assembly location: C:\Users\Administrador\Desktop\LUNESSSSSSS\outputmessengers\OM.Tab.DLL

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Chat;

namespace System.Windows.Forms
{
    [ToolboxItem(false)]
    public class TabStyleAngledProvider : TabStyleProvider
    {
        public TabStyleAngledProvider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._ImageAlign = ContentAlignment.MiddleRight;
            this._Overlap = 7;
            this._Radius = 10;
            this.Padding = new Point(10, 3);
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, checked(tabBounds.X + this._Radius - 2), checked(tabBounds.Y + 2));
                    path.AddLine(checked(tabBounds.X + this._Radius), tabBounds.Y, checked(tabBounds.Right - this._Radius), tabBounds.Y);
                    path.AddLine(checked(tabBounds.Right - this._Radius + 2), checked(tabBounds.Y + 2), tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, checked(tabBounds.Right - this._Radius + 2), checked(tabBounds.Bottom - 2));
                    path.AddLine(checked(tabBounds.Right - this._Radius), tabBounds.Bottom, checked(tabBounds.X + this._Radius), tabBounds.Bottom);
                    path.AddLine(checked(tabBounds.X + this._Radius - 2), checked(tabBounds.Bottom - 2), tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, checked(tabBounds.X + 2), checked(tabBounds.Bottom - this._Radius + 2));
                    path.AddLine(tabBounds.X, checked(tabBounds.Bottom - this._Radius), tabBounds.X, checked(tabBounds.Y + this._Radius));
                    path.AddLine(checked(tabBounds.X + 2), checked(tabBounds.Y + this._Radius - 2), tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, checked(tabBounds.Right - 2), checked(tabBounds.Y + this._Radius - 2));
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + this._Radius), tabBounds.Right, checked(tabBounds.Bottom - this._Radius));
                    path.AddLine(checked(tabBounds.Right - 2), checked(tabBounds.Bottom - this._Radius + 2), tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }
    }
}

