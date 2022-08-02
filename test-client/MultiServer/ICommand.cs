using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    public class ICommand
    {
        public string CommandName { get; set; }
        public string Server { get; set; }
        public string Detail { get; set; }
    }
}
