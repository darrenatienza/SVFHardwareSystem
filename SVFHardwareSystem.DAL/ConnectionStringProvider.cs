using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL
{
    public class ConnectionStringProvider
    {
        /// <summary>
        /// Returns database connection base on configuration
        /// </summary>
        /// <returns></returns>
        public static string GetContext()
        {
             
            #if (DEBUG)
                return "DevelopmentContext";
            #else
                return "ProductionContext";
            #endif
        }
    }
}
