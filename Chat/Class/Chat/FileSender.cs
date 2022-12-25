using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace SkynetChat
{
    class FileSender
    {
        const int PORT = 1823;
        public string FileNam { get; set; }


        public void Iniciar(string ip)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileNam = ofd.FileName;
            }
            Enviar(ip);
        }
        public void SendScreen(string ip, string FileName)
        {
            FileNam = FileName;
            Enviar(ip);
        }

        public void Update(string ip)
        {
            if (File.Exists(Path.Combine(Modcommon.TEMP_PATH, "SkynetChat", "SkynetChat.exe")))
                File.Delete(Path.Combine(Modcommon.TEMP_PATH, "SkynetChat", "SkynetChat.exe"));

            if (File.Exists(Path.Combine(Modcommon.TEMP_PATH, "SkynetChat", "SkynetChat.zip")))
                FileNam = Path.Combine(Modcommon.TEMP_PATH, "SkynetChat", "SkynetChat.zip");


            Enviar(ip);
        }
        public void Avatar(string ip, string foto)
        {
            FileNam = foto;
            Enviar(ip);
        }
        public void IniciarDrop(string ip, string file)
        {
            FileNam = file;
            Enviar(ip);

        }

        private FileStream fileStream;
        private TcpClient client;

        public void CancelDrop()
        {
           // MessageBox.Show("lol");
        }


        private async void Enviar(string ip)
        {
            IPAddress address;
            FileInfo file;
            if (!IPAddress.TryParse(ip, out address))
            {
                MessageBox.Show("Error with IP Address");
                return;
            }
            try
            {
                file = new FileInfo(FileNam);
                fileStream = file.OpenRead();
            }
            catch (Exception ex)
            {
                frmMain.frm.Crearlog(ex);
                return;
            }

            // Connecting
            client = new TcpClient();
            try
            {
                await client.ConnectAsync(ip, PORT);
            }
            catch { }

            NetworkStream ns = client.GetStream();

            string FileName = file.Name;

            // Send file info
            { // This syntax sugar is awesome
                byte[] fileName = Encoding.ASCII.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName, 0, fileName.Length);
            }
            // Send userName
            { 
                byte[] fileName = Encoding.ASCII.GetBytes(frmMain.NickName);
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName, 0, fileName.Length);
            }

            // Get permissions
            {
                byte[] permission = new byte[1];
                await ns.ReadAsync(permission, 0, 1);
                if (permission[0] != 1)
                {
                    MessageBox.Show("Permission denied");
                    return;
                }
            }

            // Sending
            int read;
            int totalWritten = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await ns.WriteAsync(buffer, 0, read);
                totalWritten += read;
                /*
                    frmMain.frm.TransferenciaBar.Show();
                    try{
                    frmMain.frm.TransferenciaBar.Minimum = 0;
                    frmMain.frm.TransferenciaBar.Maximum = Convert.ToInt32(file.Length);
                    frmMain.frm.TransferenciaBar.Value = totalWritten;
                    } catch { }
                */
            }

            //fileStream.Dispose();
            //client.Close();
            //              frmMain.frm.TransferenciaBar.Hide();
        }
    }
}
