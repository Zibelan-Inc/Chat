using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using Chat;

class PingManager
{
    public static BackgroundWorker NetPing = new BackgroundWorker();
    static Socket sock;
    static Socket sockClient;
    private static int MaxTimes = 0;
    public static void Start()
    {
        if (NetPing == null)
            NetPing = new BackgroundWorker();

        NetPing.WorkerSupportsCancellation = true;
        NetPing.DoWork += NetPing_DoWork;

        return;
        sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }



    static List<string> UsersToDelete = new List<string>();
    public static void NetPing_DoWork(object sender, DoWorkEventArgs e)
    {
        if (MaxTimes == 5)
        {
            frmMain.frm.UserList.Rows.Clear();
            frmMain.frm.LoadDefaultUser();
            MaxTimes = 0;
        }
        frmMain.frm.Transmit("RecargarLista");
        MaxTimes++;
        return;

        UsersToDelete.Clear();
        try
        {
            int rowCount = frmMain.frm.UserList.RowCount;
            int num = checked(rowCount - 1);
            for (int i = 0; i <= num; i = checked(i + 1))
            {
                MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, i];
                if (textAndImageCell.UserName != frmMain.NickName)
                {
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(textAndImageCell.IP);
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                    // Create a TCP/IP socket.  
                    sockClient = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.  
                    sockClient.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), sockClient);

                    if (sockClient.Connected)
                    {
                        sockClient.Shutdown(SocketShutdown.Both);
                        sockClient.Close();
                    }

                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        WriteLog.Write(ex.Message);
                        //WriteLog.Write("Ping fallido: " + textAndImageCell.UserName);
                        UsersToDelete.Add(textAndImageCell.UserId);
                    }
                }
            }
        }   catch (Exception ex) { WriteLog.Save(ex); }

        foreach (string user in UsersToDelete)
            frmMain.frm.RemoveUserFromGrid(user);

        //frmMain.frm.Transmit("RecargarLista");

        e.Cancel = true;
        return;
    }
    private static void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);
            WriteLog.Write($"Socket connected to {((IPEndPoint)client.RemoteEndPoint).Address.ToString()}");

        }
        catch (Exception e)
        {
            WriteLog.Write(e.ToString());
        }
    }





}

