using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Markalar.Dataconnection
{
    public class DataEntity
    {
        

        
        public static SqlConnection connectsql()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BaglantiCumlem"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

    }
}