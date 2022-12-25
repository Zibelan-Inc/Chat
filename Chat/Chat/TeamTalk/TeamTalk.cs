using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using BearWare;
using Chat;
using FileInfo = BearWare.FileInfo;

namespace TeamTalk.Local
{
    public class TeamTalk
    {
        public static TeamTalk4 ttclient;
        int login_cmdid = 0;
        List<Files> fileList = new List<Files>();
        private static TextMessage lpTextMessage;
        static int ChannelID;
        private BackgroundWorker InitializeTeamTalk;

        public TeamTalk()
        {
            Modcommon.AppDataLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat");

            ServiceManager.Load();
            if (Utils.TeamTalk.GetServerInbox() != Settings.GetDirBox())
            {
                string Directorio = Settings.GetDirBox();
                string DirectorioAlt = Path.Combine(Modcommon.AppDataLocal, "VoipServer", "TempFiles");

                if (Directorio.Contains("á") || Directorio.Contains("é") || Directorio.Contains("í") || Directorio.Contains("ó") || Directorio.Contains("ú"))
                    Utils.TeamTalk.ChangeServerTransferDir(DirectorioAlt);
                else
                    Utils.TeamTalk.ChangeServerTransferDir(Directorio);
            }

            InitializeTeamTalk = new BackgroundWorker();
            InitializeTeamTalk.WorkerSupportsCancellation = true;
            InitializeTeamTalk.DoWork += new DoWorkEventHandler(InitializeTeamTalk_DoWork);
            InitializeTeamTalk.RunWorkerAsync();

        }
        private void InitializeTeamTalk_DoWork(object sender, DoWorkEventArgs e)
        {
            TeamTalk4.SetLicenseInformation("Srimax", 15237601593L);

            ttclient = new TeamTalk4(false);

            ttclient.OnCmdProcessing += new TeamTalk4.CommandProcessing(ttclient_OnCmdProcessing);
            ttclient.OnCmdError += new TeamTalk4.CommandError(ttclient_OnCmdError);
            ttclient.OnConnectSuccess += new TeamTalk4.Connection(OnConnectSuccess);
            ttclient.OnCmdUserJoinedChannel += new TeamTalk4.UserUpdate(OnUserUpdate);
            ttclient.OnCmdUserLoggedIn += new TeamTalk4.UserAuth(ttclient_OnCmdUserLoggedIn);
            ttclient.OnConnectFailed += new TeamTalk4.Connection(ttclient_OnConnectFailed);
            ttclient.OnFileTransfer += new TeamTalk4.FileTransferUpdate(ttclient_OnFileTransfer);
            ttclient.OnCmdFileNew += new TeamTalk4.FileUpdate(ttclient_OnCmdFileNew);
            ttclient.OnCmdMyselfJoinedChannel += new TeamTalk4.MyselfJoinedChannel(ttclient_MyselfJoinedChannel);
            ttclient.OnUserTalking += new TeamTalk4.UserTalking(OnUserTalking);
            ttclient.OnUserVideoFrame += new TeamTalk4.UserVideoFrame(ttclient_OnUserVideoFrame);
            ttclient.OnCmdUserTextMessage += new TeamTalk4.UserTextMessage(OnCmdUserTextMessage);
            ttclient.OnCmdUserJoinedChannel += new TeamTalk4.UserUpdate(ttclient_OnCmdUserJoinedChannel);
            ttclient.OnCmdUserLeftChannel += new TeamTalk4.UserUpdate(ttclient_OnCmdUserLeftChannel);
            ttclient.OnCmdFileRemove += new TeamTalk4.FileUpdate(ttclient_OnCmdFileRemove);

            ttclient.EnablePeerToPeer(TransmitType.TRANSMIT_AUDIO, bEnable: true);
            ttclient.EnablePeerToPeer(TransmitType.TRANSMIT_VIDEO, bEnable: true);
            ttclient.SetKeepAliveInterval(10, 10);
            ttclient.SetServerTimeout(500);

            if (!ServiceManager.GetServiceIsRunning("KosmoChat"))
                ServiceManager.StartService("KosmoChat");

            if (!ttclient.ConnectEx("127.0.0.1", 14225, 14225, "", 0, 0))
                WriteLoger("No se puede conectar");


            e.Cancel = true;
            return;
        }

        public static void DownloadFile(ListViewItem fileMouseMove)
        {
            string ext = Path.GetExtension(fileMouseMove.SubItems[0].Text);
            string extSinPunto = ext.Replace(".", "");

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = fileMouseMove.SubItems[0].Text;
            saveFileDialog1.Filter = $"Archivo {Modcommon.ToUpperFirst(extSinPunto)}(*{ext})|*{ext}|" + "All Files(*.*)|*.*";

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo[] lpfileInfo;
                ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
                foreach (FileInfo file in lpfileInfo)
                {
                    if (file.szFileName == fileMouseMove.SubItems[0].Text)
                        ttclient.DoRecvFile(ttclient.GetMyChannelID(), file.nFileID, saveFileDialog1.FileName);
                }

            }
        }
        public static void DeleteFile(ListViewItem fileMouseMove)
        {
            FileInfo[] lpfileInfo;
            ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
            foreach (FileInfo file in lpfileInfo)
            {
                if (file.nFileID == Convert.ToInt32(fileMouseMove.SubItems[0].Tag))
                    ttclient.DoDeleteFile(ttclient.GetMyChannelID(), file.nFileID);
            }
        }

        public static void SendMessage(string message)
        {
            lpTextMessage = default(TextMessage);
            lpTextMessage.nMsgType = TextMsgType.MSGTYPE_CHANNEL;
            lpTextMessage.nChannelID = ttclient.GetMyChannelID();
            lpTextMessage.nFromUserID = ttclient.GetMyUserID();
            lpTextMessage.szFromUsername = "";
            //lpTextMessage.nToUserID = lpUser.nUserID;
            lpTextMessage.szMessage = message;
            ttclient.DoTextMessage(lpTextMessage);
        }
        public static void Transmit(TransmitType type)
        {
            ttclient.EnableTransmission(type, true);
        }
        public static void Disconnect()
        {
            try
            {
                ttclient.DoLeaveChannel();
                ttclient.DoLogout();
                ttclient.Disconnect();
            }   catch { }
        }

        public static void Test()
        {
            FileInfo[] lpfileInfo;
            ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
            foreach (FileInfo file in lpfileInfo)
                ttclient.DoDeleteFile(ttclient.GetMyChannelID(), file.nFileID);
        }






        ///////////////////////////////////////////////////////////////////////////////////////////
        private void ttclient_OnCmdUserJoinedChannel(int nUserID, int nChannelID)
        {
            Channel chan;
            ttclient.GetChannel(nChannelID, out chan);

            ttclient.GetUser(nUserID, out lpUser);
            WriteLoger("El usuario " + lpUser.szNickname + " ingreso al canal " + chan.szName);

            ListViewItem item = new ListViewItem();
            item.Tag = nUserID;
            item.Text = lpUser.szNickname;
            //frmMain.frm.userList.Items.Add(item);
        }
        private void ttclient_OnCmdUserLeftChannel(int nUserID, int nChannelID)
        {
            Channel chan;
            ttclient.GetChannel(nChannelID, out chan);

            ttclient.GetUser(nUserID, out lpUser);
            WriteLoger("El usuario " + lpUser.szNickname + " abandonó el canal " + chan.szName);
        }
        private void OnCmdUserTextMessage(int nUserID, int nMsgID)
        {
            ttclient.GetUser(nUserID, out lpUser);

            if (ttclient.GetTextMessage(nMsgID, true, out lpTextMessage))
            {
                WriteLoger(lpUser.szNickname + ": " + lpTextMessage.szMessage);
            }
        }
        void OnUserTalking(int nUserID, bool bTalking)
        {
            User user;
            if (!ttclient.GetUser(nUserID, out user)) return;
            if (bTalking)
                WriteLoger(user.szNickname + " is talking...");
            else
                WriteLoger(user.szNickname + " stopped talking...");
        }

        private void ttclient_OnFileTransfer(int transferId, FileTransferStatus status)
        {
            switch (status)
            {
                case FileTransferStatus.FILETRANSFER_STARTED:
                    WriteLoger("Carga iniciada");

                    frmFileTransfer transfer = new frmFileTransfer(ttclient, transferId);
                    transfer.Tag = transferId.ToString();
                    transfer.Show();

                    try
                    {
                        FileTransfer fileTransfer = new FileTransfer();
                        if (ttclient.GetFileTransferInfo(transferId, out fileTransfer))
                        {
                            ChannelID = fileTransfer.nChannelID;
                        }
                    }
                    catch { }

                    break;
                case FileTransferStatus.FILETRANSFER_ERROR:
                    WriteLoger("Error al subir archivo");
                    break;
                case FileTransferStatus.FILETRANSFER_FINISHED:
                    {

                        WriteLoger("Archivo subido");

                        //if (fileInfo.szUsername != frmMain.NickName)
                        //ttclient.DoRecvFile(ChannelID, transferId, Path.Combine(frmMain.DirBox, fileInfo.szFileName));

                    }
                    break;
            }
        }

        void ttclient_OnCmdFileRemove(int fileId, int ChannelId)
        {
            if (ttclient.GetMyChannelID() != ChannelId)
                return;
            foreach (Files item in fileList)
                if (item.FileId == fileId)
                    fileList.Remove(item);
        }
        private void ttclient_OnCmdFileNew(int FileId, int ChannelId)
        {
            ChannelID = ChannelId;
            try
            {
                FileInfo fileInfo = new FileInfo();
                ttclient.GetChannelFileInfo(ChannelId, FileId, out fileInfo);

                string filetoPath = Path.Combine(frmMain.DirBox, fileInfo.szFileName);

                if (!File.Exists(filetoPath))
                {
                    string TempDatDir = Utils.TeamTalk.GetServerInbox() + @"\" + Utils.TeamTalk.GetFileNameDat(fileInfo.szFileName);
                    File.Move(TempDatDir, frmMain.DirBox + @"\" + fileInfo.szFileName);

                    if (frmMain.AbrirArchivo)
                        Process.Start(frmMain.DirBox + @"\" + fileInfo.szFileName);
                    if (frmMain.AbrirCarpeta)
                        Process.Start(frmMain.DirBox);

                    if (frmMain.AchivoRecibido)
                    {
                        //MessageBox.Show(fileInfo.szUsername);
                        //frmMain.frm.Notificar(NickName + " te ha enviado un archivo", NickName);
                    }
                    ttclient.DoDeleteFile(ChannelId, FileId);
                }
            }
            catch (Exception ex) { WriteLog.Save(ex); }

        }
        private static void WriteLoger(string log)
        {
            WriteLog.Write(log);
            //Transfer.FileTransfer.SendMessage(log);
            //frmMain.frm.Transmit("Test", log);
        }

        private void ttclient_OnCmdError(ClientError nErrorNo, int nCmdID)
        {
            switch (nErrorNo)
            {
                case ClientError.CMDERR_INCORRECT_SERVER_PASSWORD:
                    WriteLoger("Invalid server password"); break;
                case ClientError.CMDERR_INVALID_ACCOUNT:
                    WriteLoger("Invalid user account"); break;
                case ClientError.CMDERR_INCORRECT_CHANNEL_PASSWORD:
                    WriteLoger("Invalid channel password"); break;
                case ClientError.CMDERR_CHANNEL_NOT_FOUND:
                    WriteLoger("Channel doesn't exist"); break;
                default:
                    WriteLoger(TeamTalk4.GetErrorMessage(nErrorNo)); break;
            }
        }
        private void OnUserUpdate(int userId, int channelId)
        {
            User lp;
            ttclient.GetUser(userId, out lp);
        }
        private void ttclient_MyselfJoinedChannel(int channelId)
        {

        }

        public void ttclient_OnConnectFailed()
        {
            WriteLoger("Unable to connect!");
            ttclient.Disconnect(); //reset the client, so we can call .Connect() again

        }





        void ttclient_OnCmdProcessing(int nCmdID, bool bActive)
        {
            //if (!bActive && nCmdID == login_cmdid)
            //     this.Close();
        }
        public void OnConnectSuccess()
        {
            WriteLoger("We're connected!");

            login_cmdid = ttclient.DoLogin(frmMain.NickName, "", "KosmoChat", "");

        }
        void ttclient_OnCmdUserLoggedIn(int userId)
        {
            ttclient.DoJoinChannelByID(ttclient.GetMyChannelID(), "");

            ttclient.GetUser(userId, out lpUser);

            WriteLoger("El usuario " + lpUser.szNickname + " se ha logueado correctamente");

        }
        public bool IsGroupVchat;
        public string Toname;
        public bool Senderr;
        private User lpUser;

        private void ttclient_OnUserVideoFrame(int nUserID, int nFrameQueueSize)
        {
            ttclient.GetUser(nUserID, out lpUser);
            MessageBox.Show(lpUser.szNickname + "esta ttclient_OnUserVideoFrame");
/*
            frmGroupvideo value;
            if ((nUserID == 0))
            {
                try
                {
                    if (gviddialogs.TryGetValue(ttclient.GetMyChannelID(), out value))
                    {
                        if (bmp != null)
                        {
                            bmp.Dispose();
                            bmp = null;
                        }
                        ttclient.ReleaseUserVideoFrame(nUserID);
                        VideoFrame lpVideoFrame = default(VideoFrame);
                        if (ttclient.AcquireUserVideoFrame(nUserID, ref lpVideoFrame))
                        {
                            PixelFormat format = PixelFormat.Format32bppRgb;
                            local_bitmap = new Bitmap(lpVideoFrame.nWidth, lpVideoFrame.nHeight, checked(4 * lpVideoFrame.nWidth), format, lpVideoFrame.frameBuffer);
                            value.vown.AssignImage(local_bitmap);
                        }
                        else
                        {
                            value.vown.BitmapImage = null;
                        }
                    }
                    else if (IsGroupVchat)
                    {
                        frmGroupvideo frmGroupvideo = new frmGroupvideo(ttclient, nUserID, Toname, gcusers, Senderr);
                        _vcuserid = ttclient.GetMyChannelID();
                        gviddialogs.Add(ttclient.GetMyChannelID(), frmGroupvideo);
                        frmGroupvideo.FormClosed += gvideodlg_FormClosed;
                        frmGroupvideo.Closevideo += videoclosed;
                        frmGroupvideo.OpenVideoPopup += OpenVideoPopup;
                        frmGroupvideo.CloseVideoPopup += CloseVideoPopup;
                        frmGroupvideo.CancelExcessVideo += CancelMaxVideo;
                        frmGroupvideo.MuteMic += MuteMicChat;
                        frmGroupvideo.MuteMicIcon += MuteMic;
                        frmGroupvideo.TopMost = true;
                        frmGroupvideo.Show();
                        frmGroupvideo.TopMost = false;
                        try
                        {
                            if (ttclient.GetChannelUsers(ttclient.GetMyChannelID(), out lpUserIDs))
                            {
                                int[] array = lpUserIDs;
                                foreach (int num in array)
                                {
                                    if (num != ttclient.GetMyUserID() && !frmGroupvideo.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(num))))
                                    {
                                        frmGroupvideo.AddVideoUsers(ttclient, num, Toname);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.Save(ex);
                            Exception ex2 = ex;
                            ProjectData.ClearProjectError();
                        }
                    }
                }
                catch (Exception ex3)
                {
                    WriteLog.Save(ex3);
                    Exception ex4 = ex3;
                    MessageBox.Show(ex4.StackTrace);
                    ProjectData.ClearProjectError();
                }
            }
            else if (IsGroupVchat)
            {
                frmGroupvideo value2;
                if (!gviddialogs.TryGetValue(ttclient.GetMyChannelID(), out value2))
                {
                    value2 = new frmGroupvideo(ttclient, nUserID, Toname, gcusers, Senderr);
                    _vcuserid = ttclient.GetMyChannelID();
                    gviddialogs.Add(ttclient.GetMyChannelID(), value2);
                    value2.FormClosed += gvideodlg_FormClosed;
                    value2.Closevideo += videoclosed;
                    value2.MuteMic += MuteMicChat;
                    value2.CancelExcessVideo += CancelMaxVideo;
                    value2.MuteMicIcon += MuteMic;
                    value2.TopMost = true;
                    value2.Show();
                    value2.TopMost = false;
                    try
                    {
                        if (ttclient.GetChannelUsers(ttclient.GetMyChannelID(), out lpUserIDs2))
                        {
                            int[] array2 = lpUserIDs2;
                            foreach (int num2 in array2)
                            {
                                if (num2 != ttclient.GetMyUserID() && !value2.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(num2))))
                                {
                                    value2.AddVideoUsers(ttclient, num2, Toname);
                                }
                            }
                        }
                    }
                    catch (Exception ex5)
                    {
                        WriteLog.Save(ex5);
                        Exception ex6 = ex5;
                        MessageBox.Show(ex6.StackTrace);
                        ProjectData.ClearProjectError();
                    }
                }
                else if (!value2.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(nUserID))))
                {
                    value2.AddVideoUsers(ttclient, nUserID, Toname);
                }
            }
            else if (nUserID != 0 && !viddialogs.TryGetValue(nUserID, out dlgv))
            {
                dlgv = new frmVideoChat(ttclient, nUserID, Toname);
                _vcuserid = nUserID;
                viddialogs.Add(nUserID, dlgv);
                dlgv.FormClosed += videodlg_FormClosed;
                dlgv.DetachVideo += DetachVideoWindow;
                dlgv.MuteMic += MuteMicChat;
                dlgv.ChangeMuteMicvideo += ChangeMuteMicvideo;
                dlgv.CloseVideoPopup += CloseVideoPopup;
                dlgv.OpenVideoPopup += OpenVideoPopup;
                dlgv.MuteMicIcon += MuteMic;
                //VideodlgShowEvent?.Invoke();

            }
    */
        }
        public void ChangeDir(string dir)
        {
            
        }

    }
    public class Files
    {
        public int FileId { get; set; }
        public int ChannelId { get; set; }
    }
    public class FileLogic
    {
        public FileLogic(string toUser, string type)
        {
            toUser = ToUser;
            type = Type;
        }
        public int FileId { get; set; }
        public string ToUser { get; set; }
        public string Type { get; set; }
    }
}









namespace TeamTalk.Remote
{
    public class TeamTalk
    {
        public static TeamTalk4 ttclient;
        int login_cmdid = 0;
        private static TextMessage lpTextMessage;
        static int ChannelID;
        public TeamTalk()
        {
            TeamTalk4.SetLicenseInformation("Srimax", 15237601593L);

            ttclient = new TeamTalk4(false);

            ttclient.OnCmdProcessing += new TeamTalk4.CommandProcessing(ttclient_OnCmdProcessing);
            ttclient.OnCmdError += new TeamTalk4.CommandError(ttclient_OnCmdError);
            ttclient.OnConnectSuccess += new TeamTalk4.Connection(OnConnectSuccess);
            ttclient.OnCmdUserJoinedChannel += new TeamTalk4.UserUpdate(OnUserUpdate);
            ttclient.OnCmdUserLoggedIn += new TeamTalk4.UserAuth(ttclient_OnCmdUserLoggedIn);
            ttclient.OnConnectFailed += new TeamTalk4.Connection(ttclient_OnConnectFailed);
            ttclient.OnFileTransfer += new TeamTalk4.FileTransferUpdate(ttclient_OnFileTransfer);
            ttclient.OnCmdFileNew += new TeamTalk4.FileUpdate(ttclient_OnCmdFileNew);
            ttclient.OnCmdMyselfJoinedChannel += new TeamTalk4.MyselfJoinedChannel(ttclient_MyselfJoinedChannel);
            ttclient.OnUserTalking += new TeamTalk4.UserTalking(OnUserTalking);
            ttclient.OnUserVideoFrame += new TeamTalk4.UserVideoFrame(ttclient_OnUserVideoFrame);
            ttclient.OnCmdUserTextMessage += new TeamTalk4.UserTextMessage(OnCmdUserTextMessage);
            ttclient.OnCmdUserJoinedChannel += new TeamTalk4.UserUpdate(ttclient_OnCmdUserJoinedChannel);
            ttclient.OnCmdUserLeftChannel += new TeamTalk4.UserUpdate(ttclient_OnCmdUserLeftChannel);
            ttclient.OnCmdFileRemove += new TeamTalk4.FileUpdate(ttclient_OnCmdFileRemove);

            ttclient.EnablePeerToPeer(TransmitType.TRANSMIT_AUDIO, bEnable: true);
            ttclient.EnablePeerToPeer(TransmitType.TRANSMIT_VIDEO, bEnable: true);
            ttclient.SetKeepAliveInterval(10, 10);
            ttclient.SetServerTimeout(500);

            if (!ServiceManager.GetServiceIsRunning("KosmoChat"))
                ServiceManager.StartService("KosmoChat");

        }
        public static void Connect(string ip)
        {
            if (!ServiceManager.GetServiceIsRunning("KosmoChat"))
                ServiceManager.StartService("KosmoChat");

            Disconnect();

            if (!ttclient.ConnectEx(ip, 14225, 14225, "", 0, 0))
                WriteLoger("No se puede conectar");

        }
        public static void SendFile(string ip, string toUser = "", string file = "")
        {
            if (!ServiceManager.GetServiceIsRunning("KosmoChat"))
                ServiceManager.StartService("KosmoChat");

            Connect(ip);

            if (file == "")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ttclient.DoSendFile(ttclient.GetMyChannelID(), openFileDialog1.FileName);
                }
            }
            else
            {
                ttclient.DoSendFile(ttclient.GetMyChannelID(), file);
            }
        }
        public static void DownloadFile(ListViewItem fileMouseMove)
        {
            string ext = Path.GetExtension(fileMouseMove.SubItems[0].Text);
            string extSinPunto = ext.Replace(".", "");

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = fileMouseMove.SubItems[0].Text;
            saveFileDialog1.Filter = $"Archivo {Modcommon.ToUpperFirst(extSinPunto)}(*{ext})|*{ext}|" + "All Files(*.*)|*.*";

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo[] lpfileInfo;
                ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
                foreach (FileInfo file in lpfileInfo)
                {
                    if (file.szFileName == fileMouseMove.SubItems[0].Text)
                        ttclient.DoRecvFile(ttclient.GetMyChannelID(), file.nFileID, saveFileDialog1.FileName);
                }

            }
        }
        public static void DeleteFile(ListViewItem fileMouseMove)
        {
            FileInfo[] lpfileInfo;
            ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
            foreach (FileInfo file in lpfileInfo)
            {
                if (file.nFileID == Convert.ToInt32(fileMouseMove.SubItems[0].Tag))
                    ttclient.DoDeleteFile(ttclient.GetMyChannelID(), file.nFileID);
            }
        }

        public static void SendMessage(string message)
        {
            lpTextMessage = default(TextMessage);
            lpTextMessage.nMsgType = TextMsgType.MSGTYPE_CHANNEL;
            lpTextMessage.nChannelID = ttclient.GetMyChannelID();
            lpTextMessage.nFromUserID = ttclient.GetMyUserID();
            lpTextMessage.szFromUsername = "";
            //lpTextMessage.nToUserID = lpUser.nUserID;
            lpTextMessage.szMessage = message;
            ttclient.DoTextMessage(lpTextMessage);
        }
        public static void Transmit(TransmitType type)
        {
            ttclient.EnableTransmission(type, true);
        }
        public static void Disconnect()
        {
            try
            {
                ttclient.DoLeaveChannel();
                ttclient.DoLogout();
                ttclient.Disconnect();
            }
            catch { }
        }

        public static void Test()
        {
            FileInfo[] lpfileInfo;
            ttclient.GetChannelFiles(ttclient.GetMyChannelID(), out lpfileInfo);
            foreach (FileInfo file in lpfileInfo)
                ttclient.DoDeleteFile(ttclient.GetMyChannelID(), file.nFileID);
        }






        ///////////////////////////////////////////////////////////////////////////////////////////
        private void ttclient_OnCmdUserJoinedChannel(int nUserID, int nChannelID)
        {
            Channel chan;
            ttclient.GetChannel(nChannelID, out chan);

            ttclient.GetUser(nUserID, out lpUser);
            WriteLoger("El usuario " + lpUser.szNickname + " ingreso al canal " + chan.szName);

            ListViewItem item = new ListViewItem();
            item.Tag = nUserID;
            item.Text = lpUser.szNickname;
            //frmMain.frm.userList.Items.Add(item);
        }
        private void ttclient_OnCmdUserLeftChannel(int nUserID, int nChannelID)
        {
            Channel chan;
            ttclient.GetChannel(nChannelID, out chan);

            ttclient.GetUser(nUserID, out lpUser);
            WriteLoger("El usuario " + lpUser.szNickname + " abandonó el canal " + chan.szName);
        }
        private void OnCmdUserTextMessage(int nUserID, int nMsgID)
        {
            ttclient.GetUser(nUserID, out lpUser);

            if (ttclient.GetTextMessage(nMsgID, true, out lpTextMessage))
            {
                WriteLoger(lpUser.szNickname + ": " + lpTextMessage.szMessage);
            }
        }
        void OnUserTalking(int nUserID, bool bTalking)
        {
            User user;
            if (!ttclient.GetUser(nUserID, out user)) return;
            if (bTalking)
                WriteLoger(user.szNickname + " is talking...");
            else
                WriteLoger(user.szNickname + " stopped talking...");
        }

        private void ttclient_OnFileTransfer(int transferId, FileTransferStatus status)
        {
            switch (status)
            {
                case FileTransferStatus.FILETRANSFER_STARTED:
                    WriteLoger("Carga iniciada");

                    frmFileTransfer transfer = new frmFileTransfer(ttclient, transferId);
                    transfer.Tag = transferId.ToString();
                    transfer.Show();

                    try
                    {
                        FileTransfer fileTransfer = new FileTransfer();
                        if (ttclient.GetFileTransferInfo(transferId, out fileTransfer))
                        {
                            ChannelID = fileTransfer.nChannelID;
                        }
                    }
                    catch { }

                    break;
                case FileTransferStatus.FILETRANSFER_ERROR:
                    WriteLoger("Error al subir archivo");
                    break;
                case FileTransferStatus.FILETRANSFER_FINISHED:
                    {

                        WriteLoger("Archivo subido");

                        //if (fileInfo.szUsername != frmMain.NickName)
                        //ttclient.DoRecvFile(ChannelID, transferId, Path.Combine(frmMain.DirBox, fileInfo.szFileName));

                    }
                    break;
            }
        }

        void ttclient_OnCmdFileRemove(int fileId, int ChannelId)
        {
            if (ttclient.GetMyChannelID() != ChannelId)
                return;
        }
        private void ttclient_OnCmdFileNew(int FileId, int ChannelId)
        {
            ChannelID = ChannelId;
            try
            {
                FileInfo fileInfo = new FileInfo();
                ttclient.GetChannelFileInfo(ChannelId, FileId, out fileInfo);

                string filetoPath = Path.Combine(frmMain.DirBox, fileInfo.szFileName);

                if (!File.Exists(filetoPath))
                {
                    string TempDatDir = Utils.TeamTalk.GetServerInbox() + @"\" + Utils.TeamTalk.GetFileNameDat(fileInfo.szFileName);
                    File.Move(TempDatDir, frmMain.DirBox + @"\" + fileInfo.szFileName);

                    if (frmMain.AbrirArchivo)
                        Process.Start(frmMain.DirBox + @"\" + fileInfo.szFileName);
                    if (frmMain.AbrirCarpeta)
                        Process.Start(frmMain.DirBox);

                    if (frmMain.AchivoRecibido)
                    {
                        //MessageBox.Show(fileInfo.szUsername);
                        //frmMain.frm.Notificar(NickName + " te ha enviado un archivo", NickName);
                    }
                    ttclient.DoDeleteFile(ChannelId, FileId);
                }
            }
            catch (Exception ex) { WriteLog.Save(ex); }

        }
        private static void WriteLoger(string log)
        {
            WriteLog.Write(log);
            //Transfer.FileTransfer.SendMessage(log);
            //frmMain.frm.Transmit("Test", log);
        }

        private void ttclient_OnCmdError(ClientError nErrorNo, int nCmdID)
        {
            switch (nErrorNo)
            {
                case ClientError.CMDERR_INCORRECT_SERVER_PASSWORD:
                    WriteLoger("Invalid server password"); break;
                case ClientError.CMDERR_INVALID_ACCOUNT:
                    WriteLoger("Invalid user account"); break;
                case ClientError.CMDERR_INCORRECT_CHANNEL_PASSWORD:
                    WriteLoger("Invalid channel password"); break;
                case ClientError.CMDERR_CHANNEL_NOT_FOUND:
                    WriteLoger("Channel doesn't exist"); break;
                default:
                    WriteLoger(TeamTalk4.GetErrorMessage(nErrorNo)); break;
            }
        }
        private void OnUserUpdate(int userId, int channelId)
        {
            User lp;
            ttclient.GetUser(userId, out lp);
        }
        private void ttclient_MyselfJoinedChannel(int channelId)
        {

        }

        public void ttclient_OnConnectFailed()
        {
            WriteLoger("Unable to connect!");
            ttclient.Disconnect(); //reset the client, so we can call .Connect() again

        }





        void ttclient_OnCmdProcessing(int nCmdID, bool bActive)
        {
            //if (!bActive && nCmdID == login_cmdid)
            //     this.Close();
        }
        public void OnConnectSuccess()
        {
            WriteLoger("We're connected!");

            login_cmdid = ttclient.DoLogin(frmMain.NickName, "", "KosmoChat", "");

        }
        void ttclient_OnCmdUserLoggedIn(int userId)
        {
            ttclient.DoJoinChannelByID(ttclient.GetMyChannelID(), "");

            ttclient.GetUser(userId, out lpUser);

            WriteLoger("El usuario " + lpUser.szNickname + " se ha logueado correctamente");

        }
        public bool IsGroupVchat;
        public string Toname;
        public bool Senderr;
        private User lpUser;

        private void ttclient_OnUserVideoFrame(int nUserID, int nFrameQueueSize)
        {
            ttclient.GetUser(nUserID, out lpUser);
            MessageBox.Show(lpUser.szNickname + "esta ttclient_OnUserVideoFrame");
            /*
                        frmGroupvideo value;
                        if ((nUserID == 0))
                        {
                            try
                            {
                                if (gviddialogs.TryGetValue(ttclient.GetMyChannelID(), out value))
                                {
                                    if (bmp != null)
                                    {
                                        bmp.Dispose();
                                        bmp = null;
                                    }
                                    ttclient.ReleaseUserVideoFrame(nUserID);
                                    VideoFrame lpVideoFrame = default(VideoFrame);
                                    if (ttclient.AcquireUserVideoFrame(nUserID, ref lpVideoFrame))
                                    {
                                        PixelFormat format = PixelFormat.Format32bppRgb;
                                        local_bitmap = new Bitmap(lpVideoFrame.nWidth, lpVideoFrame.nHeight, checked(4 * lpVideoFrame.nWidth), format, lpVideoFrame.frameBuffer);
                                        value.vown.AssignImage(local_bitmap);
                                    }
                                    else
                                    {
                                        value.vown.BitmapImage = null;
                                    }
                                }
                                else if (IsGroupVchat)
                                {
                                    frmGroupvideo frmGroupvideo = new frmGroupvideo(ttclient, nUserID, Toname, gcusers, Senderr);
                                    _vcuserid = ttclient.GetMyChannelID();
                                    gviddialogs.Add(ttclient.GetMyChannelID(), frmGroupvideo);
                                    frmGroupvideo.FormClosed += gvideodlg_FormClosed;
                                    frmGroupvideo.Closevideo += videoclosed;
                                    frmGroupvideo.OpenVideoPopup += OpenVideoPopup;
                                    frmGroupvideo.CloseVideoPopup += CloseVideoPopup;
                                    frmGroupvideo.CancelExcessVideo += CancelMaxVideo;
                                    frmGroupvideo.MuteMic += MuteMicChat;
                                    frmGroupvideo.MuteMicIcon += MuteMic;
                                    frmGroupvideo.TopMost = true;
                                    frmGroupvideo.Show();
                                    frmGroupvideo.TopMost = false;
                                    try
                                    {
                                        if (ttclient.GetChannelUsers(ttclient.GetMyChannelID(), out lpUserIDs))
                                        {
                                            int[] array = lpUserIDs;
                                            foreach (int num in array)
                                            {
                                                if (num != ttclient.GetMyUserID() && !frmGroupvideo.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(num))))
                                                {
                                                    frmGroupvideo.AddVideoUsers(ttclient, num, Toname);
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        WriteLog.Save(ex);
                                        Exception ex2 = ex;
                                        ProjectData.ClearProjectError();
                                    }
                                }
                            }
                            catch (Exception ex3)
                            {
                                WriteLog.Save(ex3);
                                Exception ex4 = ex3;
                                MessageBox.Show(ex4.StackTrace);
                                ProjectData.ClearProjectError();
                            }
                        }
                        else if (IsGroupVchat)
                        {
                            frmGroupvideo value2;
                            if (!gviddialogs.TryGetValue(ttclient.GetMyChannelID(), out value2))
                            {
                                value2 = new frmGroupvideo(ttclient, nUserID, Toname, gcusers, Senderr);
                                _vcuserid = ttclient.GetMyChannelID();
                                gviddialogs.Add(ttclient.GetMyChannelID(), value2);
                                value2.FormClosed += gvideodlg_FormClosed;
                                value2.Closevideo += videoclosed;
                                value2.MuteMic += MuteMicChat;
                                value2.CancelExcessVideo += CancelMaxVideo;
                                value2.MuteMicIcon += MuteMic;
                                value2.TopMost = true;
                                value2.Show();
                                value2.TopMost = false;
                                try
                                {
                                    if (ttclient.GetChannelUsers(ttclient.GetMyChannelID(), out lpUserIDs2))
                                    {
                                        int[] array2 = lpUserIDs2;
                                        foreach (int num2 in array2)
                                        {
                                            if (num2 != ttclient.GetMyUserID() && !value2.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(num2))))
                                            {
                                                value2.AddVideoUsers(ttclient, num2, Toname);
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex5)
                                {
                                    WriteLog.Save(ex5);
                                    Exception ex6 = ex5;
                                    MessageBox.Show(ex6.StackTrace);
                                    ProjectData.ClearProjectError();
                                }
                            }
                            else if (!value2.videopanels.ContainsKey(Conversions.ToInteger(Conversions.ToString(nUserID))))
                            {
                                value2.AddVideoUsers(ttclient, nUserID, Toname);
                            }
                        }
                        else if (nUserID != 0 && !viddialogs.TryGetValue(nUserID, out dlgv))
                        {
                            dlgv = new frmVideoChat(ttclient, nUserID, Toname);
                            _vcuserid = nUserID;
                            viddialogs.Add(nUserID, dlgv);
                            dlgv.FormClosed += videodlg_FormClosed;
                            dlgv.DetachVideo += DetachVideoWindow;
                            dlgv.MuteMic += MuteMicChat;
                            dlgv.ChangeMuteMicvideo += ChangeMuteMicvideo;
                            dlgv.CloseVideoPopup += CloseVideoPopup;
                            dlgv.OpenVideoPopup += OpenVideoPopup;
                            dlgv.MuteMicIcon += MuteMic;
                            //VideodlgShowEvent?.Invoke();

                        }
                */
        }
        public void ChangeDir(string dir)
        {

        }

    }
}

namespace TeamTalk.Utils
{
    class TeamTalk
    {
        public static void ChangeServerTransferDir(string directory)
        {
            if (ServiceManager.GetServiceIsRunning("KosmoChat"))
                Service.StopService("KosmoChat");

            string tt4prosvc = Path.Combine(Modcommon.AppDataLocal, "VoipServer", "tt4prosvc.xml");

            File.WriteAllLines(tt4prosvc, File.ReadAllLines(tt4prosvc).Select(x =>
            {
                if (x.Contains("<files-root>"))
                    x = $"            <files-root>{directory}</files-root>";
                return x;
            }));

            if (!ServiceManager.GetServiceIsRunning("KosmoChat"))
                ServiceManager.StartService("KosmoChat");
        }
        public static void ConfigureServer(string Directory)
        {
            if (ServiceManager.GetServiceIsRunning("KosmoChat"))
                Service.StopService("KosmoChat");

            string VoipServer = Path.Combine(Modcommon.AppDataLocal, "VoipServer");
            string tt4prosvc = Path.Combine(Modcommon.AppDataLocal, "VoipServer", "tt4prosvc.xml");

            Process CMDDateTime = new Process();
            CMDDateTime.StartInfo.UseShellExecute = false;
            CMDDateTime.StartInfo.FileName = Path.Combine(VoipServer, "tt4prosvc.exe");
            CMDDateTime.StartInfo.Arguments = "-wizard -c " + tt4prosvc;
            CMDDateTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            CMDDateTime.StartInfo.RedirectStandardInput = true;
            CMDDateTime.StartInfo.RedirectStandardOutput = true;
            CMDDateTime.StartInfo.CreateNoWindow = true;
            CMDDateTime.Start();
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Kosmo server");
            CMDDateTime.StandardInput.WriteLine("Bienvenidos a la red");
            CMDDateTime.StandardInput.WriteLine("100");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("0");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine(Directory);
            CMDDateTime.StandardInput.WriteLine("1000000");
            CMDDateTime.StandardInput.WriteLine("1000000");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("14225");
            CMDDateTime.StandardInput.WriteLine("14225");
            CMDDateTime.StandardInput.WriteLine("N");
            CMDDateTime.StandardInput.WriteLine("ttservercert.pem");
            CMDDateTime.StandardInput.WriteLine("ttserverkey.pem");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("");
            CMDDateTime.StandardInput.WriteLine("4");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.WriteLine("0");
            CMDDateTime.StandardInput.WriteLine("10000");
            CMDDateTime.StandardInput.WriteLine("Y");
            CMDDateTime.StandardInput.Flush();
            CMDDateTime.StandardInput.Close();
            CMDDateTime.Close();

            ServiceManager.StartService("KosmoChat");
        }

        public static string GetFileNameDat(string fileName)
        {
            string FileName = "";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.Combine(Modcommon.AppDataLocal, "VoipServer", "tt4prosvc.xml"));

            XmlNodeList files = xDoc.GetElementsByTagName("files");
            XmlNodeList file = ((XmlElement)files[0]).GetElementsByTagName("file");

            for (int i = 0; i < file.Count; i = checked(i + 1))
            {
                XmlElement nodo = (XmlElement)file[i];
                string filename = nodo.GetAttribute("name");
                if (fileName == filename)
                {
                    XmlNodeList NameDAT = (nodo).GetElementsByTagName("internalname");
                    foreach (XmlElement node in NameDAT)
                    {
                        FileName = node.InnerText;
                    }
                }
            }
            return FileName;
        }
        public static string GetServerInbox()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.Combine(Modcommon.AppDataLocal, "VoipServer", "tt4prosvc.xml"));

            XmlNodeList files = xDoc.GetElementsByTagName("file-storage");
            XmlNodeList file = ((XmlElement)files[0]).GetElementsByTagName("files-root");

            XmlElement nodo = (XmlElement)file[0];

            return nodo.InnerText;
        }


        static string ToUser;
        static string lastServer = "";
    }
}
