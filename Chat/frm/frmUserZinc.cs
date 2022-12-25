using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat.frm
{
    public partial class frmUserZinc : Form
    {
        public frmUserZinc()
        {
            InitializeComponent();
            InitializeUserGrid();
        }


        public void InitializeUserGrid()
        {
            try
            {
                UserList.AllowUserToAddRows = false;
                MessengerColumn Dc = new MessengerColumn();
                Dc.Image = Resources.arrow_new_down2;
                Dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                Dc.ReadOnly = true;
                Dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                UserList.Columns.Insert(0, Dc);
                UserList.Sort(UserList.Columns[0], ListSortDirection.Ascending);
                UserList.AllowDrop = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }

        private void frmUserZinc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmSettings.frm.DateTimeZinc.Checked = false;
                this.Close();
            }
        }



        private void frmUserZinc_Load(object sender, EventArgs e)
        {
            try
            {
                int rowCount = frmMain.frm.UserList.RowCount;
                int num = checked(rowCount - 1);
                for (int i = 0; i <= num; i = checked(i + 1))
                {
                    MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, i];
                    AddUser(textAndImageCell);
                }
            } catch (Exception ex) { WriteLog.Save(ex); }
        }
        private void AddUser(MessengerCell User)
        {
            if (User.UserId == frmMain.UserId)
                return;

            Image userPhoto = User.Image;
            string userKey = User.UserId;
            int num = UserList.RowCount;
            string[] content = new string[1]
            {
                User.UserName + Modcommon.TEXT_SEPARATOR + UserStatus.Online.ToString() +
                Modcommon.TEXT_SEPARATOR + ("Doble click para sincronizar") + Modcommon.TEXT_SEPARATOR + User.UserId +
                Modcommon.TEXT_SEPARATOR
            };
            UserList.Rows.Add(content);
            UserList.Rows[num].Height = 54;
            UserList.RowTemplate.Height = 54;
            UserList[0, num].ReadOnly = true;
            MessengerCell textAndImageCell = (MessengerCell)UserList[0, num];
            textAndImageCell.Image = Modcommon.CropToCircle(userPhoto);
            textAndImageCell.Tag = "U";
            textAndImageCell.User = true;
            textAndImageCell.UserName = User.UserName;
            textAndImageCell.UserId = userKey;
            textAndImageCell.Status = UserStatus.Online;

        }


        private void UserList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmSettings.frm.DateTimeZincBool = true;
            frmMain.UserDateTimeZinc = textAndImageCell_MouseMove.UserId;
            this.Close();
        }
        MessengerCell textAndImageCell_MouseMove;
        private bool _ctrlkeyheld;
        private bool _bubbledash;
        private float opacityvalue;

        private void UserList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            textAndImageCell_MouseMove = (MessengerCell)UserList[0, e.RowIndex];
        }

        private void UserList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
                if (UserList.Visible)
                    RenderCellText(Color.Black, Color.Gray, e, (DataGridView)sender, true);
                else
                    RenderCellText(Color.Black, Color.Gray, e, (DataGridView)sender, false);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                WriteLog.Save(ex);
            }

        }












        private void RenderCellText(Color color1, Color color2, DataGridViewCellPaintingEventArgs e, DataGridView dgv, bool search)
        {
            bool flag;
            checked
            {
                try
                {
                    string text = e.FormattedValue.ToString();
                    int length = text.Length;
                    string text2 = "";
                    int num = default(int);
                    Point point = new Point(e.CellBounds.X + num, (int)Math.Round(unchecked((double)e.CellBounds.Y + (double)e.CellBounds.Height / 4.0 - 8.0)));
                    flag = false;
                    if (!search)
                    {
                        num = 35;
                        point = new Point(e.CellBounds.X + num, (int)Math.Round(unchecked((double)e.CellBounds.Y + (double)e.CellBounds.Height / 4.0 - 6.0)));
                        dgv.Rows[e.RowIndex].Height = 20;
                    }
                    else
                    {
                        num = 55;
                        point = new Point(e.CellBounds.X + num, (int)Math.Round(unchecked((double)e.CellBounds.Y + (double)e.CellBounds.Height / 4.0 - 8.0)));
                    }
                    Font font = new Font("Segoe UI", 10f, FontStyle.Regular);
                    Font font2 = new Font("Segoe UI", 10f, FontStyle.Regular);
                    new Font("Segoe UI", 10f, FontStyle.Bold);
                    Font font3 = new Font("Segoe UI", 8f, FontStyle.Regular);
                    string text3 = "";
                    int num2 = 0;
                    bool flag2 = false;
                    Color orange = Color.Orange;
                    Color foreColor = Color.FromArgb(105, 70, 2);
                    MessengerCell textAndImageCell = unchecked((MessengerCell)dgv[e.ColumnIndex, e.RowIndex]);
                    if (textAndImageCell.User)
                    {
                        if (!search)
                        {
                            dgv.Rows[e.RowIndex].Height = 20;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].Height = 54;
                        }
                        string[] array = Strings.Split(text, Modcommon.TEXT_SEPARATOR);
                        if (array.Length > 2)
                        {
                            text2 = array[2];
                        }
                        string text4 = Uri.UnescapeDataString(text2.Trim());
                        Bitmap chatBullet = default(Bitmap);
                        SizeF sizeF = default(SizeF);
                        sizeF = e.Graphics.MeasureString(text2, font3, dgv.Width - 75);
                        num2 = ((dgv.Height >= dgv.Rows.GetRowsHeight(DataGridViewElementStates.Visible)) ? 85 : 70);
                        if (!search)
                        {
                            flag = false;
                            sizeF.Width = 0f;
                            sizeF.Height = 0f;
                        }
                        if (string.IsNullOrEmpty(text4))
                        {
                            text2 = text3;
                        }
                        bool selected = dgv[e.ColumnIndex, e.RowIndex].Selected;
                        Color foreColor2 = (selected && textAndImageCell.dblclickrow && !_ctrlkeyheld) ? Color.White : ((!textAndImageCell.dblclickrow) ? color2 : Color.White);
                        if ((selected) && !textAndImageCell.dblclickrow)
                        {
                            using (Pen pen = new Pen(ColorTranslator.FromHtml("#a6c2e4"))) //Aqui se remplaza este color por el azul "#319AFF" para cuando seleccionas 
                            {
                                pen.DashStyle = DashStyle.Dot;
                                using (Brush brush = new LinearGradientBrush(e.CellBounds, ColorTranslator.FromHtml("#e5f1fe"), ColorTranslator.FromHtml(" #e5f1fe"), LinearGradientMode.Vertical))
                                {
                                    e.Graphics.DrawRectangle(pen, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                    e.Graphics.FillRectangle(brush, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                                }
                            }
                        }
                        else if (selected && !_ctrlkeyheld)
                        {
                            using (Pen pen2 = new Pen(ColorTranslator.FromHtml("#319AFF")))
                            {
                                pen2.DashStyle = DashStyle.Dot;
                                using (Brush brush2 = new SolidBrush(ColorTranslator.FromHtml("#319AFF")))
                                {
                                    e.Graphics.DrawRectangle(pen2, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                    e.Graphics.FillRectangle(brush2, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                                }
                            }
                        }
                        else if (textAndImageCell.dblclickrow) //Aqui se pone blanco el nombre de usuario (remplazando por (textAndImageCell.mrow || selected) && !textAndImageCell.dblclickrow)
                        {
                            using (Pen pen3 = new Pen(ColorTranslator.FromHtml("#319AFF")))
                            {
                                using (Brush brush3 = new SolidBrush(ColorTranslator.FromHtml("#319AFF")))
                                {
                                    e.Graphics.DrawRectangle(pen3, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                    e.Graphics.FillRectangle(brush3, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                                }
                            }
                        }
                        else if (textAndImageCell.InactivoUser)
                        {
                            using (Pen pen3 = new Pen(Color.FromArgb(245, 245, 245)))
                            {
                                using (Brush brush3 = new SolidBrush(Color.FromArgb(245, 245, 245)))
                                {
                                    e.Graphics.DrawRectangle(pen3, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                    e.Graphics.FillRectangle(brush3, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                                }
                            }
                        }
                        if (!search)
                        {
                            if (Operators.ConditionalCompareObjectEqual(textAndImageCell.Tag, "CU", TextCompare: false))
                            {
                                e.Graphics.DrawImageUnscaled(Resources.hash_10, e.CellBounds.X + 25, e.CellBounds.Y + 4);
                            }
                            else if (Operators.ConditionalCompareObjectEqual(textAndImageCell.Tag, "GC", TextCompare: false))
                            {
                                e.Graphics.DrawImage(Resources.c_gc, e.CellBounds.X + 22, e.CellBounds.Y + 4, 14, 14);
                            }
                            else if (Operators.ConditionalCompareObjectEqual(textAndImageCell.Tag, "A", TextCompare: false))
                            {
                                e.Graphics.DrawImage(Resources.announcementrecent, e.CellBounds.X + 25, e.CellBounds.Y + 4, 14, 14);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawImage(textAndImageCell.Image, e.CellBounds.X + 10, e.CellBounds.Y + 7, 38, 38);
                        }
                        if (!search)
                        {
                            point.X += 7;
                        }
                        if (sizeF.Height < 28f && Convert.ToInt32(decimal.Truncate(new decimal(sizeF.Width))) == 134 && dgv.Width < 250)
                        {
                            point = new Point(point.X, point.Y - 4);
                        }
                        if (Operators.ConditionalCompareObjectNotEqual(textAndImageCell.Tag, "U", TextCompare: false))
                        {
                            point.X += 10;
                        }
                        if (selected && textAndImageCell.dblclickrow && !_ctrlkeyheld)
                        {
                            TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.White);
                        }
                        else if (textAndImageCell.dblclickrow) //Remplazar por (textAndImageCell.mrow || selected) && !textAndImageCell.dblclickrow pa que te salga blanco cuando des clic en el cell
                        {
                            TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.White);
                        }
                        else if (flag2 || text3.Equals("Ausente"))
                        {
                            TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.Gray);
                        }
                        else
                        {
                            TextRenderer.DrawText(e.Graphics, array[0], font2, point, Color.Black);
                        }
                        Size size = TextRenderer.MeasureText(array[0], font2);
                        if (!search)
                        {
                            Point pt2 = new Point(point.X + size.Width, point.Y + 4);
                            if (text3.Equals("Online") && !text3.Equals("Ausente"))
                            {
                                TextRenderer.DrawText(e.Graphics, "(" + text3 + ")", font3, pt2, foreColor);
                                Size size2 = TextRenderer.MeasureText(text3, font3);
                                pt2 = new Point(point.X + size.Width + size2.Width + 2, point.Y + 4);
                            }
                            if (!text4.Trim().Equals(""))
                            {
                                {
                                    TextRenderer.DrawText(e.Graphics, " " + text2, font3, pt2, foreColor2);
                                }
                            }
                        }
                        else
                        {
                            TextFormatFlags textFormatFlags = TextFormatFlags.NoPrefix | TextFormatFlags.WordEllipsis;
                            if (Modcommon.IsRTL(text4))
                            {
                                textFormatFlags |= TextFormatFlags.RightToLeft;
                            }
                            Rectangle bounds = new Rectangle(point.X + 12, point.Y + 22, dgv.Width - 70, 28);
                            if (Modcommon.IS_ENABLED_IP_RANGE)
                            {
                                bounds = new Rectangle(point.X + 28, point.Y + 22, dgv.Width - 70, 28);
                            }
                            Point point2 = new Point(point.X + 13, point.Y + 20);
                            if (text3.Equals("Online") || text3.Equals("Ausente"))
                            {
                                if (Convert.ToInt32(decimal.Truncate(new decimal(sizeF.Width))) == 134 || (Convert.ToInt32(decimal.Truncate(new decimal(sizeF.Width))) == 145 && dgv.Width > 255 && sizeF.Height < 25f))
                                {
                                    if (dgv.Width < 216)
                                    {
                                        bounds = new Rectangle(point.X + 13, point.Y + 17, dgv.Width - 70, 28);
                                    }
                                    else if (dgv.Height < dgv.Rows.GetRowsHeight(DataGridViewElementStates.Visible) && Convert.ToInt32(decimal.Truncate(new decimal(sizeF.Width))) == 145)
                                    {
                                        bounds = new Rectangle(point.X + 13, point.Y + 23, dgv.Width - 70, 28);
                                    }

                                    {
                                        TextRenderer.DrawText(e.Graphics, text2, font3, bounds, foreColor2, textFormatFlags);
                                    }
                                }
                                else
                                {
                                    TextRenderer.DrawText(e.Graphics, text2, font3, bounds, foreColor2, textFormatFlags);
                                }
                            }
                            else if (string.IsNullOrEmpty(text4))
                            {
                                point2 = new Point(point.X + 27, point.Y + 22);
                                {
                                    TextRenderer.DrawText(e.Graphics, text2, font3, point2, foreColor);
                                }
                            }

                            else if (!string.IsNullOrEmpty(text4))
                            {
                                Point pt4 = new Point(point2.X, point2.Y);
                                TextRenderer.DrawText(e.Graphics, text2, font3, pt4, foreColor2);
                            }
                        }
                    }
                    else
                    {
                        if (dgv[e.ColumnIndex, e.RowIndex].Selected)
                        {
                            using (Pen pen4 = new Pen(ColorTranslator.FromHtml("#a6c2e4")))
                            {
                                pen4.DashStyle = DashStyle.Dot;
                                using (Brush brush4 = new LinearGradientBrush(e.CellBounds, ColorTranslator.FromHtml("#e5f1fe"), ColorTranslator.FromHtml(" #e5f1fe"), LinearGradientMode.Vertical))
                                {
                                    e.Graphics.DrawRectangle(pen4, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                                    e.Graphics.FillRectangle(brush4, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2));
                                }
                            }
                        }
                        {
                            e.Graphics.DrawImage(textAndImageCell.Image, e.CellBounds.X + 5, e.CellBounds.Y + 3, 12, 12);
                        }
                        if (Operators.ConditionalCompareObjectEqual(textAndImageCell.Tag, "C", TextCompare: false) && Modcommon.ENABLED_CREATE_CHATROOM)
                        {
                            e.Graphics.DrawImageUnscaled(Modcommon.ChangeOpacity(Resources.add1, opacityvalue), e.CellBounds.Left + e.CellBounds.Width - 25, e.CellBounds.Top + 1, 16, 16);
                        }
                        text = "  " + text.Trim();
                        int num4 = (search) ? 10 : 10;
                        point = new Point(e.CellBounds.X + num4, (int)Math.Round(unchecked((double)e.CellBounds.Y + (double)e.CellBounds.Height / 4.0 - 5.0)));
                        if (Operators.ConditionalCompareObjectEqual(dgv[e.ColumnIndex, e.RowIndex].Tag, "O", TextCompare: false))
                        {
                            TextRenderer.DrawText(e.Graphics, text, font, point, Color.FromArgb(105, 103, 101), TextFormatFlags.NoPrefix);
                        }
                        else
                        {
                            TextRenderer.DrawText(e.Graphics, text, font, point, Color.FromArgb(3, 50, 204), TextFormatFlags.NoPrefix);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    WriteLog.Save(ex2);
                }
            }
        }
        private void UserList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmSettings.frm.DateTimeZincBool = false;
                this.Close();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
