using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; set; }
        public static string SqlConnectionString { get; set; }

        public static void InitializeConnections(DatabaseType dbType)
        {
            
            if (dbType == DatabaseType.Sql)
            {
                //todo setup the sql connector
                Connection = new SQLConnector();
            }

            else if (dbType == DatabaseType.Text)
            {
                Connection = new TextConnector();
            }
        }
    }
}
