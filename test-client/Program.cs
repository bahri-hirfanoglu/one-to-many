using fake_server.MultiServer;
using Game.MultiServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fake_server
{
    class Program
    {
        static void Main(string[] args)
        {
            MutliServerMgr.Init();
            while(true)
            {
                string str = Console.ReadLine();
                if(str == "msg")
                {
                    Console.WriteLine("Message >");
                    string msg = Console.ReadLine();
                    Console.WriteLine("Message >");
                    string nickname = Console.ReadLine();
                    MultiCommand.sendBugleMessage(nickname, 55, msg);
                    Console.WriteLine("send packaged");
                }
                if(str == "clear")
                {
                    Console.Clear();
                }
            }
        }
    }
}
