using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using SkynetChat.Properties;
using System.Drawing;
using System.Diagnostics;


namespace SkynetChat
{

    class FileReceiver
    {
        const int PORT = 1823;
        public System.Media.SoundPlayer file;  //Sonido

        private frmMain llamante;
        public FileReceiver(frmMain remitente) { this.llamante = remitente; }

        public void Iniciar()
        {
            Remote.Client client = new Remote.Client();
            client.remoteObject.GetRemoteStatus("test");
            Thread server = new Thread(OnShown);
            server.Start();

        }
        Remote.Server Server = new Remote.Server();
        private FileStream fileStream;
        private bool update;
        private bool Screenshots;
        private string Screen;
        private string NickName;

        public async void OnShown()
        {
            Screenshots = false;
            update = false;

            // Listen
            TcpListener listener = TcpListener.Create(PORT);
            listener.Start();
            while (true)
            {

            TcpClient client = await listener.AcceptTcpClientAsync();
            NetworkStream ns = client.GetStream();

            // Get file info
            long fileLength;
            string fileName;
            {
                byte[] fileNameBytes;
                byte[] fileNameLengthBytes = new byte[4]; //int32
                byte[] fileLengthBytes = new byte[8]; //int64


                await ns.ReadAsync(fileLengthBytes, 0, 8); // int64
                await ns.ReadAsync(fileNameLengthBytes, 0, 4); // int32
                fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                await ns.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);

                fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                fileName = Encoding.ASCII.GetString(fileNameBytes);
            }
            string userName;
            {
                byte[] fileNameBytes;
                byte[] fileNameLengthBytes = new byte[4]; //int32
                byte[] fileLengthBytes = new byte[8]; //int64


                await ns.ReadAsync(fileLengthBytes, 0, 8); // int64
                await ns.ReadAsync(fileNameLengthBytes, 0, 4); // int32
                fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                await ns.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);

                //fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                userName = Encoding.ASCII.GetString(fileNameBytes);
            }

            string[] Nombres = fileName.Split('/');
            //NickName = Nombres[0];
            //fileName = Nombres[1];


            // Set save location
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CreatePrompt = false;
            sfd.OverwritePrompt = true;

            if (fileName.ToLower().Contains("screenshot"))
            {
                sfd.FileName = Path.Combine(Modcommon.TEMP_PATH, "Screenshots") + "//" + fileName;
                Screen = Path.Combine(Modcommon.TEMP_PATH, "Screenshots") + "/" + fileName;
                Screenshots = true;
            }
            else if (fileName.ToLower() == "skynetchat.zip")
            {
                sfd.FileName = Modcommon.TEMP_PATH + "//" + fileName;
                update = true;
            }
            else
                sfd.FileName = frmMain.DirBox + "//" + fileName;

            //if (sfd.ShowDialog() != DialogResult.OK)
            //{
            //    ns.WriteByte(0); // Permission denied
            //    return;
            //}
            ns.WriteByte(1); // Permission grantedd
            try
            {
                if (!Directory.Exists(frmMain.DirBox))
                    Directory.CreateDirectory(frmMain.DirBox);
            }
            catch { }
            try
            {
                fileStream = File.Open(sfd.FileName, FileMode.Create);
            }
            catch
            {
                try
                {
                    sfd.FileName = sfd.FileName.Replace("_", "").Replace("*", "").Replace("ª", "").Replace("!", "").Replace("´", "").Replace("+", "").Replace("*", "");
                    fileStream = File.Open(sfd.FileName, FileMode.Create);
                }
                catch
                {
                    (new System.Threading.Thread(() => {
                        Mensages mensages = new Mensages();
                        mensages.WriteMessage(3, "El nombre de archivo contiene caracteres no válidos...\r\nporfavor renómbrelo", "Error al enviar fichero");
                        mensages.ShowDialog();
                    })).Start();

                    return;
                }
            }


            // Receive
            int read;
            int totalRead = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = await ns.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, read);
                totalRead += read;
            }

            fileStream.Dispose();
            client.Close();

            if (update)
            {
                try
                {
                    Process.Start(Path.Combine(Modcommon.GetPatch(), "update.exe"));
                    return;
                }
                catch
                {
                    return;
                }
            }

            if (Screenshots)
            {
                try
                {
                    frmMain.frm.WriteChatMessages(8, userName, Screen, 0);
                    return;
                }
                catch
                {
                    return;
                }
            }
            

            file = new System.Media.SoundPlayer(Resources.message_high);
            file.Play();

            if (frmMain.AbrirArchivo)
                Process.Start(frmMain.DirBox + @"\" + fileName);
            if (frmMain.AbrirCarpeta)
                Process.Start(frmMain.DirBox);

            if (frmMain.AchivoRecibido)
            {
                llamante.Notificar(userName + " te ha enviado un archivo", userName);
            }




            }

        }

    }
}
