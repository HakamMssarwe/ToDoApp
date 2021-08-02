using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Utilities
{
    class Helper
    {
       public string GetServerConnectionString(string serverName)
        {
            return ConfigurationManager.ConnectionStrings[serverName].ConnectionString;
        }

    }
}
