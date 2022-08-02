using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    public class MutliServerMgr
    {
        public static bool Init()
        {
            try
            {
                MultiServer multiServer = new MultiServer();
                multiServer.InitSocket(IPAddress.Parse(ConfigurationManager.AppSettings["IP"]), Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]));
                multiServer.Start();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Init: " + ex.ToString());
                return false;

            }

        }
    }
}
