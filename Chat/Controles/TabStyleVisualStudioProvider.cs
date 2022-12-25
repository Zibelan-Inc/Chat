// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.TabStyleVisualStudioProvider
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
    public class TabStyleVisualStudioProvider : TabStyleProvider
    {
        public TabStyleVisualStudioProvider(CustomTabControl tabControl)
          : base(tabControl)
        {
            this._ImageAlign = ContentAlignment.MiddleRight;
            this._Overlap = 7;
            this.Padding = new Point(14, 1);
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, checked(tabBounds.X + tabBounds.Height - 4), checked(tabBounds.Y + 2));
                    path.AddLine(checked(tabBounds.X + tabBounds.Height), tabBounds.Y, checked(tabBounds.Right - 3), tabBounds.Y);
                    path.AddArc(checked(tabBounds.Right - 6), tabBounds.Y, 6, 6, 270f, 90f);
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + 3), tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, checked(tabBounds.Bottom - 3));
                    path.AddArc(checked(tabBounds.Right - 6), checked(tabBounds.Bottom - 6), 6, 6, 0.0f, 90f);
                    path.AddLine(checked(tabBounds.Right - 3), tabBounds.Bottom, checked(tabBounds.X + tabBounds.Height), tabBounds.Bottom);
                    path.AddLine(checked(tabBounds.X + tabBounds.Height - 4), checked(tabBounds.Bottom - 2), tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, checked(tabBounds.X + 3), tabBounds.Bottom);
                    path.AddArc(tabBounds.X, checked(tabBounds.Bottom - 6), 6, 6, 90f, 90f);
                    path.AddLine(tabBounds.X, checked(tabBounds.Bottom - 3), tabBounds.X, checked(tabBounds.Y + tabBounds.Width));
                    path.AddLine(checked(tabBounds.X + 2), checked(tabBounds.Y + tabBounds.Width - 4), tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, checked(tabBounds.Right - 2), checked(tabBounds.Y + tabBounds.Width - 4));
                    path.AddLine(tabBounds.Right, checked(tabBounds.Y + tabBounds.Width), tabBounds.Right, checked(tabBounds.Bottom - 3));
                    path.AddArc(checked(tabBounds.Right - 6), checked(tabBounds.Bottom - 6), 6, 6, 0.0f, 90f);
                    path.AddLine(checked(tabBounds.Right - 3), tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }
    }
}
