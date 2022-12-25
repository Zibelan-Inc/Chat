using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    public class IPAddrHelper
    {
        private static IPAddress ipAddress1;

        private static bool IsIPAddress(string addrString)
        {
            IPAddress address = (IPAddress)null;
            return IPAddress.TryParse(addrString, out address);
        }

        public static IPAddress GetIPAddress(string server)
        {
            return !IsIPAddress(server) ? GetIPAddressFromHostname(server) : IPAddress.Parse(server);
        }

        public static IPAddress GetIPAddressFromHostname(string hostname)
        {
            try
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                    if (hostEntry != null)
                        ipAddress1 = hostEntry.AddressList[0];
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
                IPAddress[] hostAddresses = Dns.GetHostAddresses(hostname);
                int index = 0;
                while (index < hostAddresses.Length)
                {
                    IPAddress ipAddress2 = hostAddresses[index];
                    if (ipAddress2.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string Left = ipAddress2.ToString();
                        if (Operators.CompareString(Left, "0.0.0.0", false) != 0 || Operators.CompareString(Left, "127.0.0.1", false) != 0)
                        {
                            ipAddress1 = ipAddress2;
                            break;
                        }
                    }
                    checked { ++index; }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            return ipAddress1;
        }
    }
}