using System;
using NetFwTypeLib;

namespace Chat.Class
{
    public class FirewallHelper
    {

        public static void CreatePolice(string path, string name, string port)
        {

            INetFwMgr fwMgr = (INetFwMgr)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwMgr"));

            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Description = "Permitiendo acceso a KosmoChat";
            firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            firewallRule.Enabled = true;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = name;
            firewallRule.ApplicationName = name;
            //firewallRule.LocalPorts = port;

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(firewallRule);
        }
        public static void RemovePolice(string name)
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Remove(name);
        }
    }
}
