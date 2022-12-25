using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat
{
    public class MessengerCell : DataGridViewTextBoxCell
    {
        private Image _imageValue { get; set; }

        //////////////CHAT///////////////////////////////
        public string UserName { get; set; }
        public int AvatarLength { get; set; }
        public string MachineName { get; set; }
        public int ColorId { get; set; }
        public bool FormInactivo { get; set; }
        public string IP { get; set; }
        public string ConnectedTime { get; set; }
        public string UserId { get; set; }

        /////////////////////////////////////////////////
        public bool dblclickrow { get; set; }

        public bool InactivoUser { get; set; }

        public bool User { get; set; }

        public UserStatus Status { get; set; }

        public Image Image
        {
            get
            {
                return this.OwningColumn == null || OwningTextAndImageColumn == null ? _imageValue : (_imageValue ?? OwningTextAndImageColumn.Image);
            }
            set
            {
                try
                {
                    _imageValue = value;
                    Padding padding = InheritedStyle.Padding;
                    this.Style.Padding = new Padding(value.Size.Width, padding.Top, padding.Right, padding.Bottom);
                } catch { }
            }
        }
        public Image ImageFront { get; set; }


        private MessengerColumn OwningTextAndImageColumn
        {
            get
            {
                return this.OwningColumn as MessengerColumn;
            }
        }


        public MessengerCell()
        {
            this.dblclickrow = false;
            ImageFront = (Image)null;
        }

        public override object Clone()
        {
            MessengerCell textAndImageCell = base.Clone() as MessengerCell;
            Image image = this._imageValue;
            textAndImageCell._imageValue = image;
            return (object)textAndImageCell;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, RuntimeHelpers.GetObjectValue(value), RuntimeHelpers.GetObjectValue(formattedValue), errorText, cellStyle, advancedBorderStyle, paintParts);
                GraphicsContainer container = graphics.BeginContainer();
                object tag = this.DataGridView.Tag;
                if (Operators.ConditionalCompareObjectEqual(tag, (object)"N", false))
                {
                    if (this.DataGridView.Rows[rowIndex].Selected)
                    {
                        cellBounds.Width = checked(cellBounds.Width - 5);
                        cellBounds.X = checked(cellBounds.X + 5);
                        graphics.SetClip(cellBounds);
                        //graphics.DrawImage((Image)Resources.bg, cellBounds);    //Quite este por si acaso
                    }
                }
                else if (Operators.ConditionalCompareObjectEqual(tag, (object)"R", false))
                {
                    cellBounds.X = checked(cellBounds.X + 1);
                    cellBounds.Y = checked(cellBounds.Y + 4);
                    graphics.SetClip(cellBounds);
                    graphics.DrawImageUnscaled(this.Image, cellBounds.Location);
                }
                graphics.EndContainer(container);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }
    }
    public sealed class MessengerColumn : DataGridViewTextBoxColumn
    {
        private Image _imageValue;


        public Image Image
        {
            get
            {
                return _imageValue;
            }
            set
            {
                _imageValue = value;
                Padding padding = DefaultCellStyle.Padding;
                DefaultCellStyle.Padding = new Padding(value.Size.Width, padding.Top, padding.Right, padding.Bottom);
            }
        }


        public MessengerColumn()
        {
            CellTemplate = new MessengerCell();
        }

        public override object Clone()
        {
            MessengerColumn obj = base.Clone() as MessengerColumn;
            obj._imageValue = _imageValue;
            return obj;
        }
    }

}