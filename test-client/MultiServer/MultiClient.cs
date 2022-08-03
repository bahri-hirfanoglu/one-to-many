using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    public class MultiClient
    {
        public static async Task sendPackage(object command)
        {
            await Task.Run(() =>
            {
                try
                {
                    var json = JsonConvert.SerializeObject(command);
                    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(ConfigurationManager.AppSettings["GoIP"]);
                    System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, Convert.ToInt32(ConfigurationManager.AppSettings["GoPort"]));
                    soc.Connect(remoteEP);
                    UTF8Encoding enc = new UTF8Encoding();
                    soc.Send(enc.GetBytes(json.ToString()));
                    soc.Close();
                }
                catch (Exception ex)
                {
                    Logger.Log("sendPackage: " + ex.ToString());
                }
            });

        }
    }
}
