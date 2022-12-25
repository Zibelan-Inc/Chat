using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chat
{
    public class Variables
    {
        public int num3 { get; set; }
        public static int avatarLength { get; set; }
        public static string avatar { get; set; }
        public static string mensaje { get; set; }
        public static string UsuarioSeleccionado { get; set; }
        public static string IPSeleccionado { get; set; }
        public static bool flag { get; set; }
        public static bool flag1 { get; set; }
        public static bool flag2 { get; set; }
        public static string UserName { get; set; }
        public static string smile { get; set; }
        public static string Userstate { get; set; }
        public static string Tempvar { get; set; }
        public static string String { get; set; }
        public static bool result { get; set; }
        public static UserStatus stat { get; set; }
        public static string destPath { get; set; }
        public static Bitmap bitmap { get; set; }
        public static Bitmap bitmap2 { get; set; }
        public static Bitmap bitmap3 { get; set; }
        public static Bitmap bitmap4 { get; set; }
        public static Bitmap bitmap5 { get; set; }
        public static Image image { get; set; }
        public static Image image2 { get; set; }
        public static Image image3 { get; set; }
        public static Image image4 { get; set; }
        public static Image image5 { get; set; }

        public static Process currentProcess;
        public static bool Inactivo { get; set; }
        public static string imageName { get; set; }
        public static string FirstRun { get; set; }
        public static string Directorio(string dire)
        {
            return Path.Combine(Application.StartupPath, dire);
        }
        public static string Directorio(string dire, string archivoName)
        {
            return Path.Combine(Application.StartupPath, dire, archivoName);
        }
        public static string Directorio(string dire, string archivoName, string extencion)
        {
            return Path.Combine(Application.StartupPath, dire, archivoName + extencion);
        }
        public static string directorio { get; set; }



    }
}