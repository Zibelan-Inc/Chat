using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Chat.Controles
{
    public class FlatNumericupDown : UserControl
    {
        private IContainer components;

        public NumericUpDown Nbox;

        public  Panel Panel1;

        public FlatNumericupDown()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private Decimal num2;
        private Decimal num4;
        private Decimal num6;
        private Decimal num8;
        private NumericUpDown nbox1;
        private NumericUpDown nbox2;
        private NumericUpDown nbox3;
        private NumericUpDown nbox4;
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            nbox1 = new NumericUpDown();
            nbox2 = new NumericUpDown();
            nbox3 = new NumericUpDown();
            nbox4 = new NumericUpDown();
            Nbox = new NumericUpDown();
            this.Panel1 = new Panel();
            this.Nbox.BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            this.Nbox.BorderStyle = BorderStyle.None;
            this.Nbox.Dock = DockStyle.Fill;
            this.Nbox.Font = new Font("Times New Roman", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            nbox1 = this.Nbox;
            int[] bits1 = new int[4];
            int index1 = 0;
            int num1 = 100;
            bits1[index1] = num1;
            num2 = new Decimal(bits1);
            nbox1.Increment = num2;
            this.Nbox.Location = new Point(2, 2);
            nbox2 = this.Nbox;
            int[] bits2 = new int[4];
            int index2 = 0;
            int num3 = 60000;
            bits2[index2] = num3;
            num4 = new Decimal(bits2);
            nbox2.Maximum = num4;
            nbox3 = this.Nbox;
            int[] bits3 = new int[4];
            int index3 = 0;
            int num5 = 100;
            bits3[index3] = num5;
            num6 = new Decimal(bits3);
            nbox3.Minimum = num6;
            this.Nbox.Name = "Nbox";
            this.Nbox.Size = new Size(145, 16);
            this.Nbox.TabIndex = 0;
            nbox4 = this.Nbox;
            int[] bits4 = new int[4];
            int index4 = 0;
            int num7 = 100;
            bits4[index4] = num7;
            num8 = new Decimal(bits4);
            nbox4.Value = num8;
            this.Panel1.BackColor = Color.White;
            this.Panel1.Controls.Add((Control)this.Nbox);
            this.Panel1.Dock = DockStyle.Fill;
            this.Panel1.Location = new Point(1, 1);
            this.Panel1.Margin = new Padding(0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new Padding(2);
            this.Panel1.Size = new Size(149, 20);
            this.Panel1.TabIndex = 1;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightGray;
            this.Controls.Add((Control)this.Panel1);
            this.Name = "FlatNumericupDown";
            this.Padding = new Padding(1);
            this.Size = new Size(151, 22);
            this.Nbox.EndInit();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }

}
