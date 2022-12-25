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

    class AvatarReceiver
    {
        const int PORT = 1925;

        private frmMain llamante;
        public AvatarReceiver(frmMain remitente) { this.llamante = remitente; }

        public void Iniciar()
        {
            try
            {
                Remote.Client client = new Remote.Client();
                client.remoteObject.GetRemoteStatus("test");
                Thread server = new Thread(OnShown);
                server.Start();

            }
            catch { }

        }
        Remote.Server Server = new Remote.Server();
        private FileStream fileStream;
        public async void OnShown()
        {
            try
            {
                // Listen
                TcpListener listener = TcpListener.Create(PORT);
                listener.Start();
                ret1: TcpClient client = await listener.AcceptTcpClientAsync();
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

                //// Get permission
                //if (MessageBox.Show(String.Format("Requesting permission to receive file:\r\n\r\n{0}\r\n{1} bytes long", fileName, fileLength), "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                //{
                //    return;
                //}

                // Set save location
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.CreatePrompt = false;
                sfd.OverwritePrompt = true;
                sfd.FileName = Application.StartupPath + "/avatars" + "//" + fileName;

                //if (sfd.ShowDialog() != DialogResult.OK)
                //{
                //    ns.WriteByte(0); // Permission denied
                //    return;
                //}
                ns.WriteByte(1); // Permission grantedd
                try
                {
                    if (!Directory.Exists(Application.StartupPath + "/avatars"))
                        Directory.CreateDirectory(Application.StartupPath + "/avatars");
                }
                catch { }

                /*
                //Preparar carpeta para nuevo archivo
                foreach (var img in MainChat.Skynetchat.ImageAvatar.Images.Keys)
                {
                    if (img == fileName)
                    {
                        MainChat.Skynetchat.ImageAvatar.Images.RemoveByKey(img);
                        //Agregar aqui pa liberar el picturebox
                        File.Delete(sfd.FileName);
                    }
                }
                */
                try
                {
                    fileStream = File.Open(sfd.FileName, FileMode.Create);
                }
                catch
                {
                    return;
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

      //          MainChat.Skynetchat.CargarImageAvatar();
      //          MainChat.Skynetchat.UpdateAvatar();

                goto ret1;
            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }
        }


    }
}
