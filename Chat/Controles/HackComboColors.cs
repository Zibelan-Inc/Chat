using System.Drawing;
using System.Windows.Forms;

namespace Chat.Controles
{
    class HackComboColors : ComboBox
    {
        public HackComboColors()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }
    }
    public class ComboBoxItem
    {
        public ComboBoxItem() { }

        public ComboBoxItem(string pText, object pValue)
        {
            text = pText; val = pValue;
        }

        public ComboBoxItem(string pText, object pValue, Color pColor)
        {
            text = pText; val = pValue; foreColor = pColor;
        }

        string text = "";
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        object val;
        public object Value
        {
            get { return val; }
            set { val = value; }
        }

        Color foreColor = Color.Black;
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }

}
