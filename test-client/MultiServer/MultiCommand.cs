using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    public class MultiCommand
    {
        static string getTag(int type)
        {
            switch (type)
            {
               
                default: return "Sunucular arası hoparlör";
            }
        }
        public static void runCommand(string command)
        {
            JObject cmd = parseCommand(command);
            switch (cmd["CommandName"].ToString())
            {
                case "sendMessage":
                    JObject detail = parseCommand(cmd["Detail"].ToString());
                    Console.WriteLine(detail.ToString());
                    break;
                default:
                    break;
            }
        }

        public static void sendBugleMessage(string nickname, short packageNum, string message)
        {
            try
            {
                dynamic detail = new System.Dynamic.ExpandoObject();
                detail.NickName = nickname;
                detail.packageNum = packageNum;
                detail.Message = message;
                var data = new ICommand
                {
                    CommandName = "sendMessage",
                    Server = ConfigurationManager.AppSettings["ServerKey"],
                    Detail = JsonConvert.SerializeObject(detail),
                };
                MultiClient.sendPackage(data);
            }
            catch (Exception ex)
            {
                Logger.Log("sendBugleMessage: " + ex.ToString());
            }
        }

        static JObject parseCommand(string command)
        {
            return  JObject.Parse(command);
        }
    }
}
