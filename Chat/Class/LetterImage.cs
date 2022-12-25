using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public class LetterImage : Variables
    {

        public static Image GetUserImage(string UserKey, string nickName = "")
        {
            if (nickName == "")
            nickName = Modcommon.GetNamefromID(UserKey);

            Image result = default(Image);

            try
            {
                string AvatarDir = Path.Combine(Application.StartupPath + @"\Avatars\", UserKey + ".jpg");
                if (File.Exists(AvatarDir))
                {
                    bitmap = (Bitmap)ImageHandler.ResizeAvatar(new Bitmap(AvatarDir), 38, 38);
                }
                else
                    bitmap = CreateLetterImage(UserKey, nickName);
                result = bitmap;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
                return result;
            }

        }

        public static Image GetBigUserImage(string id)
        {
            Image result = default(Image);
            try
            {
                string AvatarDir = Path.Combine(Application.StartupPath + @"\Avatars\", id + ".jpg");
                if (File.Exists(AvatarDir))
                {
                    bitmap = (Bitmap)ImageFromFile(AvatarDir);
                }
                else
                    bitmap = CreateLetterImage(id);
                result = bitmap;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
                return result;
            }

        }
        public static Image ImageFromFile(string filePath)
        {
            try
            {
                Image original = Image.FromStream((Stream)new MemoryStream(File.ReadAllBytes(filePath)));
                Size size = original.Size;
                image2 = (Image)new Bitmap(original, size);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
                WriteLog.Save(ex);
            }
            return image2;
        }


        private static Bitmap bitmap1;
        private static string Letter { get; set; }
        private static int LetterNum { get; set; }

        public static Bitmap CreateBigLetterImage(string Nick)
        {
            LetterNum = 0;
            directorio = Application.StartupPath + @"\Letter\";
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            foreach (char letter in Nick)
            {
                if (LetterNum == 0) { Letter = letter.ToString(); LetterNum++; }
            }
            string s = Letter.ToUpper();

            char[] chArray = new char[1];
            int index = 0;
            int num1 = 95;
            chArray[index] = (char)num1;
            int num2 = 72;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            Bitmap bitmap2 = new Bitmap((int)PROFILE_SIZE, (int)PROFILE_SIZE);
            Font font1 = new Font("Arial", (float)num2);
            Graphics graphics = Graphics.FromImage((Image)bitmap2);
            Rectangle rectangle = new Rectangle(0, checked((int)Math.Round(unchecked((double)PROFILE_SIZE / 2.0 - (double)font1.Height / 2.0))), (int)PROFILE_SIZE, (int)PROFILE_SIZE);
            Brush brush = (Brush)new SolidBrush(ColorTranslator.FromHtml(GetColorString(s)));
            int x = 0;
            int y = 0;
            int width = (int)PROFILE_SIZE;
            int height = (int)PROFILE_SIZE;

            graphics.FillRectangle(brush, x, y, width, height);
            Font font2 = font1;
            SolidBrush solidBrush = new SolidBrush(Color.White);
            RectangleF layoutRectangle = (RectangleF)rectangle;
            StringFormat format = stringFormat;
            graphics.DrawString(s, font2, (Brush)solidBrush, layoutRectangle, format);
            bitmap2.Save(directorio + Nick + ".jpg");

            bitmap1 = bitmap2;
            return bitmap1;

        }

        public static Bitmap CreateLetterImage(string userID, string nickName = "")
        {
            if (nickName == "")
            nickName = Modcommon.GetNamefromID(userID);

            if (userID == frmMain.UserId && nickName != userID)
                nickName = frmMain.NickName;

                try
                {
                LetterNum = 0;
                foreach (char letter in nickName)
                {
                    Letter = letter.ToString();
                    break;
                }
                string s = Letter.ToUpper();

                int y1 = 3;
                int num2 = 20;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;


                Bitmap bitmap2 = new Bitmap(38, 38);
                Font font1 = new Font("Arial", (float)num2);
                Graphics graphics = Graphics.FromImage((Image)bitmap2);
                Rectangle rectangle = new Rectangle(0, y1, 38, 38);
                Brush brush = (Brush)new SolidBrush(ColorTranslator.FromHtml(GetColorString(s)));
                int x = 0;
                int y2 = 0;
                int width = 38;
                int height = 38;
                graphics.FillRectangle(brush, x, y2, width, height);
                Font font2 = font1;
                SolidBrush solidBrush = new SolidBrush(Color.White);
                RectangleF layoutRectangle = (RectangleF)rectangle;
                StringFormat format = stringFormat;
                graphics.DrawString(s, font2, (Brush)solidBrush, layoutRectangle, format);
                bitmap1 = bitmap2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return bitmap1;
        }

        public static short PROFILE_SIZE = (short)200;
        //
        private static string GetColorString(string letter)
        {
            if (letter == "Q" || letter == "D" || letter == "B")
                return "#5D4037";
            else if (letter == "W" || letter == "F" || letter == "N")
                return "#689F38";
            else if (letter == "E" || letter == "G" || letter == "M")
                return "#00897B";
            else if (letter == "R" || letter == "H" || letter == "1")
                return "#039BE5";
            else if (letter == "T" || letter == "J" || letter == "2")
                return "#F4511E";
            else if (letter == "Y" || letter == "K" || letter == "3")
                return "#78909C";
            else if (letter == "U" || letter == "L" || letter == "4")
                return "#E91E63";
            else if (letter == "I" || letter == "Ñ" || letter == "5")
                return "#EF6C00";
            else if (letter == "O" || letter == "Z" || letter == "6")
                return "#9C27B0";
            else if (letter == "P" || letter == "X" || letter == "7")
                return "#3F51B5";
            else if (letter == "A" || letter == "C" || letter == "8")
                return "#0097A7";
            else if(letter == "S" || letter == "V" || letter == "9" || letter == "0")
                return "#AB47BC";
            else
                return "#AB47BC";
        }
    }

}