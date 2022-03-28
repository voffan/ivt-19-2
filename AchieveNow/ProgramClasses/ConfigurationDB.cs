using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.ProgramClasses
{
    internal class ConfigurationDB
    {
        public bool isRemote { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public ConfigurationDB(bool isRemote, string server = "", string database = "", string user = "", string password = "")
        {
            this.isRemote = isRemote;
            Server = server;
            Database = database;
            User = user;
            Password = password;
        }
    }
}
