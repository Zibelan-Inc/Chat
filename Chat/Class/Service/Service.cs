using System;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Chat
{
    internal sealed class Service
    {
        public enum ServiceType
        {
            SERVICE_KERNEL_DRIVER = 1,
            SERVICE_FILE_SYSTEM_DRIVER = 2,
            SERVICE_WIN32_OWN_PROCESS = 0x10,
            SERVICE_WIN32_SHARE_PROCESS = 0x20,
            SERVICE_INTERACTIVE_PROCESS = 0x100,
            SERVICETYPE_NO_CHANGE = -1
        }

        public enum ServiceStartType
        {
            SERVICE_BOOT_START = 0,
            SERVICE_SYSTEM_START = 1,
            SERVICE_AUTO_START = 2,
            SERVICE_DEMAND_START = 3,
            SERVICE_DISABLED = 4,
            SERVICESTARTTYPE_NO_CHANGE = -1
        }

        public enum ServiceErrorControl
        {
            SERVICE_ERROR_IGNORE = 0,
            SERVICE_ERROR_NORMAL = 1,
            SERVICE_ERROR_SEVERE = 2,
            SERVICE_ERROR_CRITICAL = 3,
            SERVICEERRORCONTROL_NO_CHANGE = -1
        }

        public enum ServiceStateRequest
        {
            SERVICE_ACTIVE = 1,
            SERVICE_INACTIVE,
            SERVICE_STATE_ALL
        }

        public enum ServiceControlType
        {
            SERVICE_CONTROL_STOP = 1,
            SERVICE_CONTROL_PAUSE,
            SERVICE_CONTROL_CONTINUE,
            SERVICE_CONTROL_INTERROGATE,
            SERVICE_CONTROL_SHUTDOWN,
            SERVICE_CONTROL_PARAMCHANGE,
            SERVICE_CONTROL_NETBINDADD,
            SERVICE_CONTROL_NETBINDREMOVE,
            SERVICE_CONTROL_NETBINDENABLE,
            SERVICE_CONTROL_NETBINDDISABLE,
            SERVICE_CONTROL_DEVICEEVENT,
            SERVICE_CONTROL_HARDWAREPROFILECHANGE,
            SERVICE_CONTROL_POWEREVENT,
            SERVICE_CONTROL_SESSIONCHANGE
        }

        public enum ServiceState
        {
            SERVICE_STOPPED = 1,
            SERVICE_START_PENDING,
            SERVICE_STOP_PENDING,
            SERVICE_RUNNING,
            SERVICE_CONTINUE_PENDING,
            SERVICE_PAUSE_PENDING,
            SERVICE_PAUSED
        }

        public enum ServiceControlAccepted
        {
            SERVICE_ACCEPT_STOP = 1,
            SERVICE_ACCEPT_PAUSE_CONTINUE = 2,
            SERVICE_ACCEPT_SHUTDOWN = 4,
            SERVICE_ACCEPT_PARAMCHANGE = 8,
            SERVICE_ACCEPT_NETBINDCHANGE = 0x10,
            SERVICE_ACCEPT_HARDWAREPROFILECHANGE = 0x20,
            SERVICE_ACCEPT_POWEREVENT = 0x40,
            SERVICE_ACCEPT_SESSIONCHANGE = 0x80
        }

        public enum ServiceControlManagerType
        {
            SC_MANAGER_CONNECT = 1,
            SC_MANAGER_CREATE_SERVICE = 2,
            SC_MANAGER_ENUMERATE_SERVICE = 4,
            SC_MANAGER_LOCK = 8,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x10,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x20,
            SC_MANAGER_ALL_ACCESS = 983103
        }

        public enum ACCESS_TYPE
        {
            SERVICE_QUERY_CONFIG = 1,
            SERVICE_CHANGE_CONFIG = 2,
            SERVICE_QUERY_STATUS = 4,
            SERVICE_ENUMERATE_DEPENDENTS = 8,
            SERVICE_START = 0x10,
            SERVICE_STOP = 0x20,
            SERVICE_PAUSE_CONTINUE = 0x40,
            SERVICE_INTERROGATE = 0x80,
            SERVICE_USER_DEFINED_CONTROL = 0x100,
            SERVICE_ALL_ACCESS = 983551
        }


        public struct QUERY_SERVICE_CONFIG
        {
            public int dwServiceType;

            public int dwStartType;

            public int dwErrorControl;

            public string lpBinaryPathName;

            public string lpLoadOrderGroup;

            public int dwTagId;

            public string lpDependencies;

            public string lpServiceStartName;

            public string lpDisplayName;
        }

        public enum SC_ACTION_TYPE
        {
            SC_ACTION_NONE,
            SC_ACTION_RESTART,
            SC_ACTION_REBOOT,
            SC_ACTION_RUN_COMMAND
        }

        public struct SC_ACTION
        {
            public SC_ACTION_TYPE SCActionType;

            public int Delay;
        }

        public enum InfoLevel
        {
            SERVICE_CONFIG_DESCRIPTION = 1,
            SERVICE_CONFIG_FAILURE_ACTIONS
        }

        public struct SERVICE_DESCRIPTION
        {
            public string lpDescription;
        }

        public struct SERVICE_FAILURE_ACTIONS
        {
            public int dwResetPeriod;

            public string lpRebootMsg;

            public string lpCommand;

            public int cActions;

            public int lpsaActions;
        }

        public const int STANDARD_RIGHTS_REQUIRED = 983040;

        public const int GENERIC_READ = int.MinValue;

        public const int ERROR_INSUFFICIENT_BUFFER = 122;

        public const int SERVICE_NO_CHANGE = -1;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void CopyMemory(IntPtr pDst, SC_ACTION[] pSrc, int ByteLen);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLastError();

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, EntryPoint = "ChangeServiceConfigA")]
        public static extern bool ChangeServiceConfig(int hService, ServiceType dwServiceType, ServiceStartType dwStartType, ServiceErrorControl dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword, string lpDisplayName);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, EntryPoint = "ChangeServiceConfig2A")]
        public static extern bool ChangeServiceConfig2(int hService, InfoLevel dwInfoLevel, [MarshalAs(UnmanagedType.Struct)] ref SERVICE_DESCRIPTION lpInfo);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, EntryPoint = "ChangeServiceConfig2A")]
        public static extern bool ChangeServiceConfig2(int hService, InfoLevel dwInfoLevel, [MarshalAs(UnmanagedType.Struct)] ref SERVICE_FAILURE_ACTIONS lpInfo);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LockServiceDatabase(int hSCManager);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnlockServiceDatabase(int hSCManager);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int OpenService(int hSCManager, string lpServiceName, ACCESS_TYPE dwDesiredAccess);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int CreateService(int hSCManager, string lpServiceName, string lpDescription, ACCESS_TYPE dwDesiredAccess, int iSvcType, int iStartType, int iError, string sPath, string sGroup, int iTag, string sDepends, string sUser, string sPass);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int DeleteService(int hSCManager);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int OpenSCManager(string lpMachineName, string lpDatabaseName, ServiceControlManagerType dwDesiredAccess);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseServiceHandle(int hSCObject);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, EntryPoint = "QueryServiceConfigA")]
        public static extern bool QueryServiceConfig(int hService, [MarshalAs(UnmanagedType.Struct)] ref QUERY_SERVICE_CONFIG lpServiceConfig, int cbBufSize, int pcbBytesNeeded);

        public static bool InstallService(string ServiceName, string DisplayName, string Description, string Exe, string FailureBatchFile = "")
        {
            SC_ACTION[] array = new SC_ACTION[3];
            IntPtr intPtr = default(IntPtr);
            checked
            {
                int num = default(int);
                int hSCManager = default(int);
                int num2 = default(int);
                try
                {
                    if (ServiceInstalled(ServiceName))
                    {
                        try
                        {
                            return StartService(ServiceName);
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            Exception ex2 = ex;
                            throw new Exception("StartService: Unable to start this service. Error: " + ex2.Message);
                        }
                    }
                    num = OpenSCManager(null, null, ServiceControlManagerType.SC_MANAGER_ALL_ACCESS);
                    if (num == 0)
                    {
                        throw new Exception("InstallService: Unable to open Service Control Manager. Error: " + GetLastError().ToString());
                    }
                    hSCManager = LockServiceDatabase(num);
                    num2 = CreateService(num, ServiceName, DisplayName, ACCESS_TYPE.SERVICE_ALL_ACCESS, 16, 2, 1, Exe, null, 0, null, null, null);
                    if (num2 == 0)
                    {
                        CloseServiceHandle(num2);
                        throw new Exception("InstallService:Unable to install service, could not create service handle. Error: " + GetLastError().ToString());
                    }
                    SERVICE_DESCRIPTION lpInfo = default(SERVICE_DESCRIPTION);
                    lpInfo.lpDescription = Description;
                    ChangeServiceConfig2(num2, InfoLevel.SERVICE_CONFIG_DESCRIPTION, ref lpInfo);
                    SERVICE_FAILURE_ACTIONS lpInfo2 = default(SERVICE_FAILURE_ACTIONS);
                    lpInfo2.dwResetPeriod = 0;
                    if (!string.IsNullOrEmpty(FailureBatchFile))
                    {
                        lpInfo2.lpCommand = FailureBatchFile;
                    }
                    lpInfo2.cActions = array.Length;
                    array[0].Delay = 20000;
                    array[0].SCActionType = SC_ACTION_TYPE.SC_ACTION_RESTART;
                    if (!string.IsNullOrEmpty(FailureBatchFile))
                    {
                        array[0].SCActionType = SC_ACTION_TYPE.SC_ACTION_RUN_COMMAND;
                    }
                    array[1].Delay = 20000;
                    array[1].SCActionType = SC_ACTION_TYPE.SC_ACTION_RESTART;
                    array[2].Delay = 20000;
                    array[2].SCActionType = SC_ACTION_TYPE.SC_ACTION_RESTART;
                    intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(default(SC_ACTION)) * 3);
                    CopyMemory(intPtr, array, Marshal.SizeOf(default(SC_ACTION)) * 3);
                    lpInfo2.lpsaActions = intPtr.ToInt32();
                    ChangeServiceConfig2(num2, InfoLevel.SERVICE_CONFIG_FAILURE_ACTIONS, ref lpInfo2);
                }
                catch (Exception ex3)
                {
                    ProjectData.SetProjectError(ex3);
                    Exception ex4 = ex3;
                    throw ex4;
                }
                finally
                {
                    Marshal.FreeHGlobal(intPtr);
                    if (num2 > 0)
                    {
                        CloseServiceHandle(num2);
                    }
                    UnlockServiceDatabase(hSCManager);
                    if (num > 0)
                    {
                        CloseServiceHandle(num);
                    }
                }
                return StartService(ServiceName);
            }
        }

        public static object UninstallService(string ServiceName)
        {
            if (!ServiceInstalled(ServiceName))
            {
                return "";
            }
            if (!StopService(ServiceName))
            {
                return "UninstallService: Could not stop service. Error: " + GetLastError().ToString();
            }
            int num = OpenSCManager(null, null, ServiceControlManagerType.SC_MANAGER_ALL_ACCESS);
            if (num == 0)
            {
                return "UninstallService: Unable to open Service Control Manager. Error: " + GetLastError().ToString();
            }
            int num2 = OpenService(num, ServiceName, ACCESS_TYPE.SERVICE_ALL_ACCESS);
            if (num2 == 0)
            {
                CloseServiceHandle(num);
                return "UninstallService: Unable to open service: " + GetLastError().ToString();
            }
            if (~DeleteService(num2) != 0)
            {
                CloseServiceHandle(num2);
                CloseServiceHandle(num);
                return "UninstallService: Unable to delete service: " + GetLastError().ToString();
            }
            CloseServiceHandle(num2);
            CloseServiceHandle(num);
            return "";
        }

        public static bool ServiceInstalled(string ServiceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            for (int i = 0; i < services.Length; i = checked(i + 1))
            {
                if (Operators.CompareString(services[i].ServiceName, ServiceName, TextCompare: false) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool StopService(string ServiceName)
        {
            int num = 0;
            bool flag = false;
            ServiceController serviceController = new ServiceController(ServiceName);
            if (serviceController.Status == ServiceControllerStatus.Stopped)
            {
                return true;
            }
            serviceController.Stop();
            num = 0;
            while (serviceController.Status != ServiceControllerStatus.Stopped)
            {
                Thread.Sleep(1000);
                num = checked(num + 1);
                if (num > 120)
                {
                    flag = true;
                    break;
                }
                serviceController.Refresh();
            }
            return !flag;
        }

        private static bool StartService(string ServiceName)
        {
            int num = 0;
            bool flag = false;
            ServiceController serviceController = new ServiceController(ServiceName);
            if (serviceController.Status == ServiceControllerStatus.Running)
            {
                return true;
            }
            serviceController.Start();
            num = 0;
            while (serviceController.Status != ServiceControllerStatus.Running)
            {
                num = checked(num + 1);
                if (num > 10)
                {
                    flag = true;
                    break;
                }
                Thread.Sleep(1000);
                serviceController.Refresh();
            }
            serviceController?.Dispose();
            serviceController = null;
            return !flag;
        }
    }
}
