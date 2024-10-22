using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectioString) 
        {
            ConnectionString = connectioString;
        }
        public string ConnectionString { get; set; }
    }
}
