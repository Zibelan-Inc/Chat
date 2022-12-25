using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace Chat
{
	public class UserAndSystemInfo
	{
        public string UserDomainname{ get; set;}
        public string Username { get; set; }
        public string HostIP { get; set; }
        public string OS { get; set; }
        public string RAM { get; set; }
        public string Processor { get; set; }
        public string SystemDrive { get; set; }
        public string OSBit { get; set; }
        public string Isadmin { get; set; }
        public string GPU { get; set; }
        private List<string> drivers;
        public void Read()
        {
            drivers = new List<string>();

            HostIP = Ip();
            UserDomainname = Environment.UserDomainName;
            Username = Environment.UserName;
            ComputerInfo computerInfo = new ComputerInfo();
            RAM = $"{(double)computerInfo.TotalPhysicalMemory / 1073741824.0:0.00} GB";
            OS = computerInfo.OSFullName;
            OSBit = Conversions.ToString(Interaction.IIf(Environment.Is64BitOperatingSystem, "64-bit", "32-bit"));
            ManagementObject managementObject = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>().First();
            Processor = (string)managementObject["Name"];
            SystemDrivers();
            Elevate();
            Isadmin = admin ? "administrativo" : "restringido";
            GPU = GiveGPU();
        }

        public void SystemDrivers()
        {
            foreach (var part in DriveInfo.GetDrives())
            {
                drivers.Add(part.ToString());
            }

            foreach (var part in drivers)
            {
                SystemDrive = SystemDrive + " " + part;
            }

        }
        public string GiveGPU()
        {
            string VideoCard = null;
            string VideoCap = null;
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                VideoCard = (obj["Name"]).ToString();
                VideoCap = (SizeSuffix((long)Convert.ToDouble(obj["AdapterRAM"]))).ToString();
            }
            return VideoCard + " - " + VideoCap;
        }
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static string SizeSuffix(long value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return ""; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format(@"{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        public static string Ip()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry iphe = Dns.GetHostEntry(hostname);
            IPAddress ipaddress = null;
            foreach (IPAddress item in iphe.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddress = item;
                    break;
                }
            }
            return ipaddress.ToString();
        }
            public bool admin = false;
            public void Elevate()
            {
                // Get Identity: WindowsIdentity 
                var user = WindowsIdentity.GetCurrent();
                // Set Principal 
                WindowsPrincipal role = new WindowsPrincipal(user);
                #region Test Operating System for UAC: 
                if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 6)
                { // False: 
                admin = false;
                    // Todo: Exception/ Exception Log 
                }
                #endregion
                else
                {
                    #region Test Identity Not Null: 
                    if (user == null)
                    { // False: 
                    admin = false;
                        // Todo: "Exception Log / Exception" 
                    }
                    #endregion else 
                    {
                        #region Ensure Security Role: 
                        if (!(role.IsInRole(WindowsBuiltInRole.Administrator)))
                        { // False: 
                        admin = false;
                            // Todo: "Exception Log / Exception" 
                        }
                        else
                        {
                        // True: 
                        admin = true;
                        }
                        #endregion
                    }
                    // Nested Else 'Close' 
                }
                // Initial Else 'Close' 
            }

    }
}
