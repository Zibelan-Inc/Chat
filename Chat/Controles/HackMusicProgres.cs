using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chat.Controles
{

    public class HackMusicProgres : Control
    {

        #region Enums 

        public enum Alignment
        {
            Right,
            Center
        }

        #endregion
        #region Variables 

        public static HackMusicProgres frm;
        private int _Minimum;
        private int _Maximum = 100;
        private int _Value = 0;
        private Alignment ALN;
        private bool _DrawHatch;

        private bool _ShowPercentage;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private Rectangle R1;
        private Rectangle R2;
        private LinearGradientBrush GB1;
        private LinearGradientBrush GB2;
        private int I1;

        #endregion
        #region Properties 

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }

        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;

                if (value > _Maximum)
                    _Maximum = value;
                if (value > _Value)
                    _Value = value;

                Invalidate();
            }
        }

        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public Alignment ValueAlignment
        {
            get { return ALN; }
            set
            {
                ALN = value;
                Invalidate();
            }
        }

        public bool DrawHatch
        {
            get { return _DrawHatch; }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }

        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        #endregion
        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 20;
            Size minimumSize = new Size(58, 20);
            this.MinimumSize = minimumSize;
        }

        #endregion

        public HackMusicProgres()
        {
            frm = this;
            _Maximum = 100;
            _ShowPercentage = true;
            _DrawHatch = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        public void Increment(int value)
        {
            this._Value += value;
            Invalidate();
        }

        public void Deincrement(int value)
        {
            this._Value -= value;
            Invalidate();
        }
        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }
        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public Color _ProgressColor1 = Color.FromArgb(0, 0, 255);
        public Color _ProgressColor2 = Color.FromArgb(0, 0, 200);
        public string DrawString { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            GP1 = RoundRectangle.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 4);
            GP2 = RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, _ProgressColor1, _ProgressColor2, 90f);

            // Draw inside background
            G.FillRectangle(new SolidBrush(Color.FromArgb(27, 37, 49)), R1); // Parte del fondo
            G.SetClip(GP1);
            G.FillPath(new SolidBrush(Color.FromArgb(27, 37, 49)), RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));


            I1 = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 3));
            if (I1 > 1)
            {
                GP3 = RoundRectangle.RoundRect(new Rectangle(1, 1, I1, Height - 3), 4);

                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(7, 164, 245), Color.FromArgb(7, 150, 245), 90f);

                // Fill the value with its gradient
                G.FillPath(GB2, GP3);

                // Draw diagonal lines
                if (_DrawHatch == true)
                {
                    for (var i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
                    {
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10.0F), new Point(Convert.ToInt32(i), 0), new Point((int)(i - 10), Height));
                    }
                }

                G.SetClip(GP3);
                G.SmoothingMode = SmoothingMode.None;
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.ResetClip();
            }

            // Draw value as a string
            DrawString = GetTime(Value);

            int textX = (int)(this.Width - G.MeasureString(DrawString, Font).Width - 1);
            int textY = (int)((this.Height / 2) - (Convert.ToInt32(G.MeasureString(DrawString, Font).Height / 2) - 2));

            if (_ShowPercentage == true)
            {
                switch (ValueAlignment)
                {
                    case Alignment.Right:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.White, new Point(textX, textY));
                        break;
                    case Alignment.Center:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.White, new Rectangle(0, 0, Width, Height + 2), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            // Draw border
            G.DrawPath(new Pen(Color.FromArgb(27, 37, 49)), GP2);

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
        string Return;
        string Return2;
        private int i = 1;
        private string GetTime(int value)
        {
            if (Convert.ToInt32(value) < 60)
            {
                Return = GetNumberLengh(value);
                goto Label_1;
            }

            switch (value)
            {
                case 60:
                    i = 1;
                    break;
                case 120:
                    i = 2;
                    break;
                case 180:
                    i = 3;
                    break;
                case 240:
                    i = 4;
                    break;
                case 300:
                    i = 5;
                    break;
                case 360:
                    i = 6;
                    break;
                case 420:
                    i = 7;
                    break;
                case 480:
                    i = 8;
                    break;
                case 560:
                    i = 9;
                    break;
                case 600:
                    i = 10;
                    break;
            }
            Return = "0" + i +":"+ GetNumberLengh(value - (60 * i));
            Label_1:
            ;
            return Return;
        }
        private string GetNumberLengh(int Value)
        {
            if (Value < 10)
                Return2 = "0" + (Value).ToString();
            else
                Return2 = Value.ToString();
            return Return2;
        }

    }

}
