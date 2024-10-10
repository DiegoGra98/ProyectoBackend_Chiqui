using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data
{
    public class EmailConfiguration
    {
        public EmailConfiguration(string host,string port,string user,string pass) {
            Host = host;
            Port = Convert.ToInt32(port);
            User = user;
            Pass = pass;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
