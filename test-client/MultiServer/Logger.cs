using Game.Server.Packets.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    public class Logger
    {
        public static void Log(string str)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText("mutliServer.txt"))
                    Log(str, (TextWriter)streamWriter);
            }
            catch (Exception ex)
            {
            }
        }

         static void Log(string logMessage, TextWriter w)
        {
          
            DateTime now = DateTime.Now;
            string longTimeString = now.ToLongTimeString();
            string longDateString = now.ToLongDateString();
            w.WriteLine("[{0} {1}]: {2}", (object)longTimeString, (object)longDateString, logMessage);
          
        }
    }
}
