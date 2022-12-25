using System;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;

namespace Chat
{
    public class ServiceManager
    {
        public static void Load()
        {
            ServiceInstall.LoadServices();
            return;

            if (!GetServiceIsRunning("Chat"))
                StartService("Chat");
        }

        public static bool GetServiceIsRunning(string service)
        {
            ServiceController serviceController = new ServiceController(service);
            if (serviceController.Status == ServiceControllerStatus.Running)
            {
                return true;
            }
            return false;
        }

        public static void StartService(string service)
        {
            ServiceController serviceController = new ServiceController(service);
            if (serviceController.Status != ServiceControllerStatus.Running)
            {
                try
                {
                    serviceController.Start();
                }
                catch { }
            }
        }
    }

    public class ServiceInstall : Installer
    {
        private static ServiceInstall linkServerServiceInstaller = new ServiceInstall();
        public static void LoadServices()
        {
            string Local_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat");
            if (Modcommon.VerifyServiceDir())
            {
                if (!Service.ServiceInstalled("KosmoChat"))
                {
                    linkServerServiceInstaller.Install();
                    Service.InstallService("KosmoChat", "KosmoChat VoIP", "Servicio para la gestion de llamadas VoIP y Escritorio Remoto", Path.Combine(Local_Path, "VoipServer", "tt4prosvc.exe"));
                }
            }

        }

        public void Install()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "KosmoChat";
            serviceInstaller.Description = "KosmoChat VoIP";
            base.Installers.Add(serviceInstaller);
            base.Installers.Add(serviceProcessInstaller);
        }

    }
}
