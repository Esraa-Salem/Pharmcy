using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Pharmcy.Attributes
{
    public class ConnectionString
    {
        public static string constr( )
        {
            return ConfigurationManager.ConnectionStrings["data_context"].ConnectionString.ToString();
        }
    }
}