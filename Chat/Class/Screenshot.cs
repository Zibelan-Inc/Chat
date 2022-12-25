using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public class Screenshot : Variables
    {
        public static void SendScreen(Message m)
        {
            //Prueba

            try
            {
                if (!Directory.Exists(Directorio("Screenshots")))
                {
                    Directory.CreateDirectory(Directorio("Screenshots"));
                }
                DeleteScreen();
                CaptureScreen();
                if (File.Exists(Directorio("Screenshots", imageName, ".jpg")))
                {
                    //FileTransfer fileTransfer = new FileTransfer();
                    //fileTransfer.FileCompleted += DeleteScreen;
                    //fileTransfer.Init(jid, Directorio("Screenshots", imageName, ".jpg"), "", true, "", false, "", "", 1, "", true, "", false, "", attribute, "", "", false, false, false, false, true, false, false, false, new DateTime(599266080000000000L));
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }

        private static void DeleteScreen()
        {
            try
            {
                /*
                string path = Path.Combine(Modcommon.TEMP_PATH, "Screenshots", $"{ExClient.Client().Displayname}.jpg");
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                */
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }

        public static string CaptureScreen()
        {
            Thread.Sleep(3000);
            imageName = "Screenshot_" + DateTime.Now.ToString("dd-MM-yy") + "_" + DateTime.Now.ToString("T");
            imageName = imageName.Replace(":", "");
            Modcommon.SCREENSHOT_LAST = Path.Combine(Modcommon.SCREENSHOT_PATH, imageName + ".jpg");


            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    if (!Directory.Exists(Path.Combine(Modcommon.TEMP_PATH,"Screenshots")))
                    {
                        Directory.CreateDirectory(Path.Combine(Modcommon.TEMP_PATH, "Screenshots"));
                    }
                    Tempvar = Path.Combine(Modcommon.SCREENSHOT_PATH, imageName + ".jpg");
                    bitmap.Save(Tempvar, ImageFormat.Jpeg);
                }

                return Tempvar;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
            return Tempvar;
        }
    }
}
