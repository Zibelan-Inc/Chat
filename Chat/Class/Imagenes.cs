using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public class ImageHandler : Variables
    {

        public static bool GetAvgSize(string sourcePath, ref int maxWidth, ref int maxHeight)
        {
            if (!File.Exists(sourcePath))
            {
                return false;
            }
            using (Bitmap image = new Bitmap(sourcePath))
            {
                GetAvgSize(image, ref maxWidth, ref maxHeight);
            }
            return true;
        }

        public static void GetAvgSize(Bitmap image, ref int maxWidth, ref int maxHeight)
        {
            try
            {
                int width = image.Width;
                int height = image.Height;
                GetAvgSize(width, height, ref maxWidth, ref maxHeight);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }
        public static bool IsAudioFile(string filePath)
        {
            bool result = default(bool);
            try
            {
                if (!string.IsNullOrEmpty(filePath) && Path.HasExtension(filePath))
                {
                    result = new string[1]
                    {
                        "mp3"
                    }.Contains(Path.GetExtension(filePath).Substring(1).ToLower());
                    return result;
                }
                result = false;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static void GetAvgSize(int originalWidth, int originalHeight, ref int maxWidth, ref int maxHeight)
        {
            try
            {
                if (originalWidth > maxHeight || originalHeight > maxWidth)
                {
                    float val = (float)maxWidth / (float)originalWidth;
                    float val2 = (float)maxHeight / (float)originalHeight;
                    float num = Math.Min(val, val2);
                    checked
                    {
                        maxWidth = (int)Math.Round((double)unchecked((float)originalWidth * num));
                        maxHeight = (int)Math.Round((double)unchecked((float)originalHeight * num));
                    }
                }
                else
                {
                    maxWidth = originalWidth;
                    maxHeight = originalHeight;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        public static void Resize(string sourcePath, int maxWidth, int maxHeight, string destPath)
        {
            try
            {
                Resize(new Bitmap(sourcePath), maxWidth, maxHeight, destPath);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        public static void Resize(Bitmap image, int maxWidth, int maxHeight, string destPath)
        {
            try
            {
                int width = image.Width;
                int height = image.Height;
                float val = (float)maxWidth / (float)width;
                float val2 = (float)maxHeight / (float)height;
                float num = Math.Min(val, val2);
                checked
                {
                    int width2 = (int)Math.Round((double)unchecked((float)width * num));
                    int height2 = (int)Math.Round((double)unchecked((float)height * num));
                    bitmap = new Bitmap(width2, height2, PixelFormat.Format24bppRgb);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, width2, height2);
                    }
                    ImageCodecInfo encoderInfo = GetEncoderInfo(ImageFormat.Jpeg);
                    Encoder quality = Encoder.Quality;
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(quality, 75L);
                    encoderParameters.Param[0] = encoderParameter;
                    bitmap.Save(destPath, encoderInfo, encoderParameters);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        public static Image ResizeIMGAvatar(Bitmap image, int maxWidth, int maxHeight)
        {
            try
            {

                int width = image.Width;
                int height = image.Height;
                float val = (float)maxWidth / (float)width;
                float val2 = (float)maxHeight / (float)height;
                float num = Math.Min(val, val2);
                checked
                {
                    int width2 = (int)Math.Round((double)unchecked((float)width * num));
                    int height2 = (int)Math.Round((double)unchecked((float)height * num));
                    bitmap = new Bitmap(width2, height2);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, width2, height2);

                    }
                    ImageCodecInfo encoderInfo = GetEncoderInfo(ImageFormat.Png);
                    Encoder quality = Encoder.Quality;
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(quality, 75L);
                    encoderParameters.Param[0] = encoderParameter;

                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
            return bitmap;
        }

        public static string ResizeAndSaveIMGAvatar(Bitmap image, int maxWidth, int maxHeight, string nickName)
        {
            string tempAvatarPath = Path.Combine(Modcommon.TEMP_PATH, nickName + ".png");

            if (File.Exists(tempAvatarPath))
                return tempAvatarPath;
            try
            {

                int width = image.Width;
                int height = image.Height;
                float val = (float)maxWidth / (float)width;
                float val2 = (float)maxHeight / (float)height;
                float num = Math.Min(val, val2);
                checked
                {
                    int width2 = (int)Math.Round((double)unchecked((float)width * num));
                    int height2 = (int)Math.Round((double)unchecked((float)height * num));
                    bitmap = new Bitmap(width2, height2);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, width2, height2);

                    }
                    ImageCodecInfo encoderInfo = GetEncoderInfo(ImageFormat.Png);
                    Encoder quality = Encoder.Quality;
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(quality, 75L);
                    encoderParameters.Param[0] = encoderParameter;
                    bitmap.Save(tempAvatarPath);
                    return tempAvatarPath;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return tempAvatarPath;
        }

        public static Image ResizeAvatar(Bitmap image, int maxWidth, int maxHeight)
        {
            destPath = Application.StartupPath + @"\Avatars\";

            try
            {

                int width = image.Width;
                int height = image.Height;
                float val = (float)maxWidth / (float)width;
                float val2 = (float)maxHeight / (float)height;
                float num = Math.Min(val, val2);
                checked
                {
                    int width2 = (int)Math.Round((double)unchecked((float)width * num));
                    int height2 = (int)Math.Round((double)unchecked((float)height * num));
                    bitmap = new Bitmap(width2, height2);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, width2, height2);
                    }
                    Encoder quality = Encoder.Quality;
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(quality, 75L);
                    encoderParameters.Param[0] = encoderParameter;
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
            return bitmap;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault((ImageCodecInfo c) => c.FormatID == format.Guid);
        }

        public static string GetExtensionImgString(string fullPath)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(fullPath))
                {
                    return "";
                }
                result = GetAssociatedIconPath(fullPath);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private static string GetAssociatedIconPath(string fullPath)
        {
            try
            {
                string text = Path.GetExtension(fullPath).Substring(1);
                string text2 = Path.Combine(Modcommon.TEMP_PATH, $"{text}.png");
                string text3 = Path.Combine(Modcommon.TEMP_PATH, $"{Path.GetFileNameWithoutExtension(fullPath)}.png");
                try
                {
                    if (!File.Exists(text2) || text.Equals("exe"))
                    {
                        Icon fileIcon = IconHelper.GetFileIcon(fullPath, IconHelper.IconSize.Large, linkOverlay: false);
                        if (fileIcon != null)
                        {
                            using (bitmap = new Bitmap(fileIcon.ToBitmap(), new Size(32, 32)))
                            {
                                if (text.Equals("exe"))
                                {
                                    if (!File.Exists(text3))
                                    {
                                        bitmap.Save(text3);
                                    }
                                    text2 = text3;
                                }
                                else
                                {
                                    bitmap.Save(text2);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    text2 = string.Empty;
                    ProjectData.ClearProjectError();
                }
                if (File.Exists(text2))
                {
                    return new Uri(text2).AbsoluteUri;
                }
                return "";
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                string result = "";
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static Image ImageFromStream(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return Image.FromStream(new MemoryStream(File.ReadAllBytes(path)));
        }

        public static string GetSmallImagePath(string photokey)
        {
            string result = string.Empty;
            try
            {
                string text = Path.Combine(Modcommon.PHOTO_PATH, $"{photokey}.jpg");
                if (!File.Exists(text))
                {
                    return result;
                }
                string text2 = Path.Combine(Modcommon.PHOTO_SMALL_PATH, $"{photokey}.jpg");
                if (!File.Exists(text2))
                {
                    Resize(text, 38, 38, text2);
                }
                result = text2;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                //Func.AppendFile("GetSmallImagePath", ex2);
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static bool IsValidImageExtension(string filePath)
        {
            bool result = default(bool);
            try
            {
                if (!string.IsNullOrEmpty(filePath) && Path.HasExtension(filePath))
                {
                    result = new string[5]
                    {
                        "jpg",
                        "jpeg",
                        "gif",
                        "png",
                        "bmp"
                    }.Contains(Path.GetExtension(filePath).Substring(1).ToLower());
                    return result;
                }
                result = false;
                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
                return result;
            }
        }
    }
    public class IconHelper
    {
        public enum IconSize
        {
            Large,
            Small
        }

        public enum FolderType
        {
            Open,
            Closed
        }

        public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            CustomShell32.SHFILEINFO psfi = default(CustomShell32.SHFILEINFO);
            uint num = 272u;
            checked
            {
                if (linkOverlay)
                {
                    num += 32768u;
                }
                CustomShell32.SHGetFileInfo(uFlags: (IconSize.Small != size) ? (num + 0u) : (num + 1u), pszPath: name, dwFileAttributes: 128u, psfi: ref psfi, cbFileInfo: (uint)Marshal.SizeOf(psfi));
            }
            Icon result = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            CustomUser32.DestroyIcon(psfi.hIcon);
            return result;
        }

        public static Icon GetFolderIcon(IconSize size, FolderType folderType__1)
        {
            uint num = 272u;
            CustomShell32.SHFILEINFO psfi;
            checked
            {
                if (folderType__1 == FolderType.Open)
                {
                    num += 2u;
                }
                num = ((IconSize.Small != size) ? (num + 0u) : (num + 1u));
                psfi = default(CustomShell32.SHFILEINFO);
                CustomShell32.SHGetFileInfo(null, 16u, ref psfi, (uint)Marshal.SizeOf(psfi), num);
                Icon.FromHandle(psfi.hIcon);
            }
            Icon result = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            CustomUser32.DestroyIcon(psfi.hIcon);
            return result;
        }
    }
    public class CustomShell32
    {
        public struct SHITEMID
        {
            public ushort cb;

            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;

            public IntPtr pidlRoot;

            public IntPtr pszDisplayName;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;

            public uint ulFlags;

            public IntPtr lpfn;

            public int lParam;

            public IntPtr iImage;
        }

        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;

            public IntPtr hIcon;

            public int iIcon;

            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public const int MAX_PATH = 256;

        public const uint BIF_RETURNONLYFSDIRS = 1u;

        public const uint BIF_DONTGOBELOWDOMAIN = 2u;

        public const uint BIF_STATUSTEXT = 4u;

        public const uint BIF_RETURNFSANCESTORS = 8u;

        public const uint BIF_EDITBOX = 16u;

        public const uint BIF_VALIDATE = 32u;

        public const uint BIF_NEWDIALOGSTYLE = 64u;

        public const uint BIF_USENEWUI = 80u;

        public const uint BIF_BROWSEINCLUDEURLS = 128u;

        public const uint BIF_BROWSEFORCOMPUTER = 4096u;

        public const uint BIF_BROWSEFORPRINTER = 8192u;

        public const uint BIF_BROWSEINCLUDEFILES = 16384u;

        public const uint BIF_SHAREABLE = 32768u;

        public const uint SHGFI_ICON = 256u;

        public const uint SHGFI_DISPLAYNAME = 512u;

        public const uint SHGFI_TYPENAME = 1024u;

        public const uint SHGFI_ATTRIBUTES = 2048u;

        public const uint SHGFI_ICONLOCATION = 4096u;

        public const uint SHGFI_EXETYPE = 8192u;

        public const uint SHGFI_SYSICONINDEX = 16384u;

        public const uint SHGFI_LINKOVERLAY = 32768u;

        public const uint SHGFI_SELECTED = 65536u;

        public const uint SHGFI_ATTR_SPECIFIED = 131072u;

        public const uint SHGFI_LARGEICON = 0u;

        public const uint SHGFI_SMALLICON = 1u;

        public const uint SHGFI_OPENICON = 2u;

        public const uint SHGFI_SHELLICONSIZE = 4u;

        public const uint SHGFI_PIDL = 8u;

        public const uint SHGFI_USEFILEATTRIBUTES = 16u;

        public const uint SHGFI_ADDOVERLAYS = 32u;

        public const uint SHGFI_OVERLAYINDEX = 64u;

        public const uint FILE_ATTRIBUTE_DIRECTORY = 16u;

        public const uint FILE_ATTRIBUTE_NORMAL = 128u;

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
    public class CustomUser32
    {
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }

}
