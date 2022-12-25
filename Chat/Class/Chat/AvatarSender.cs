using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SkynetChat
{
    class AvatarSender
    {
        const int PORT = 1925;
        public string FileNam { get; set; }


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

        private async void Enviar(string ip)
        {
            try
            {
                IPAddress address;
                FileInfo file;
                if (!IPAddress.TryParse(ip, out address))
                {
                    //MessageBox.Show("Error with IP Address");
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
                TcpClient client = new TcpClient();
                try
                {
                    await client.ConnectAsync(ip, PORT);
                }
                catch (Exception ex)
                {
                    frmMain.frm.Crearlog(ex);
                    return;
                }
                NetworkStream ns = client.GetStream();

                // Send file info
                { // This syntax sugar is awesome
                    byte[] fileName = Encoding.ASCII.GetBytes(file.Name);
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

                }


                fileStream.Dispose();
                client.Close();

            }
            catch (Exception ex) { frmMain.frm.Crearlog(ex); }

        }


    }
}
