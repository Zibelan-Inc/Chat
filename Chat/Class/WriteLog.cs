using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Chat;

class WriteLog
{
    private static Mutex mutexFile;
    private static string str;

    public static void Write(string Write, string user = "", string typeMessage = "")
    {
        if (user == "")
            user = frmMain.NickName;
        if (typeMessage == "")
            typeMessage = "Log";
        if (frmMain.NickName == "Hackerprod")
        {
            string json = "{ \"Handle\":\"" + user + "\",\"typeMessage\":\"" + typeMessage + "\",\"content\":\"" + Write + "\",\"UserSelectedColor\":0}";
            frmMain.frm.cliente.OnMessageRecieved(new MessageEventArgs(json));
        }

    }
    public static void Save(Exception ex)
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ex.Message);
            if (ex.InnerException != null)
                stringBuilder.Append("\r\n").Append((object)ex.InnerException);
            if (ex.StackTrace != null)
                stringBuilder.Append("\r\n").Append(ex.StackTrace);
            str = string.Format($"{(object)stringBuilder.ToString()}:");

            AppendFile(str, Path.Combine(Application.StartupPath, "KosmoChat.log"));
        }
        catch { }
    }
    public static void Show(Exception ex)
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ex.Message);
            if (ex.InnerException != null)
                stringBuilder.Append("\r\n").Append((object)ex.InnerException);
            if (ex.StackTrace != null)
                stringBuilder.Append("\r\n").Append(ex.StackTrace);
            str = string.Format($"{(object)stringBuilder.ToString()}:");

            MessageBox.Show(str);
        }
        catch { }
    }
    public static string GetError(Exception ex)
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ex.Message);
            if (ex.InnerException != null)
                stringBuilder.Append("\r\n").Append((object)ex.InnerException);
            if (ex.StackTrace != null)
                stringBuilder.Append("\r\n").Append(ex.StackTrace);
            str = string.Format($"{(object)stringBuilder.ToString()}:");

        }
        catch { }
        return str;
    }

    public static void AppendFile(string s, string fname)
    {
        string path = Path.Combine(Application.StartupPath, fname);
        StreamWriter streamWriter = null;
        try
        {
            mutexFile = LogMutex.mutexFile;
            mutexFile.WaitOne();
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(stream);
            streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
            streamWriter.WriteLine(Conversions.ToString(DateAndTime.Now) + ":" + s);
            streamWriter.Close();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            streamWriter?.Close();
            ProjectData.ClearProjectError();
        }
        finally
        {
            mutexFile.ReleaseMutex();
        }
    }
    internal class LogMutex
    {
        public static Mutex mutexFile = new Mutex(false, "LogMutex");
    }

    static bool one = true;
    internal static void Report(string report)
    {
        if (!Program.Report)
        return;

        string path = Path.Combine(Application.StartupPath, "KosmoChat.log");

        if (one)
        if (File.Exists(path))
            File.Delete(path);

        StreamWriter streamWriter = null;
        try
        {
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(stream);
            streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
            streamWriter.WriteLine(Conversions.ToString(DateAndTime.Now) + ":" + report);
            streamWriter.Close();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            streamWriter?.Close();
            ProjectData.ClearProjectError();
        }
        one = false;
    }
}

