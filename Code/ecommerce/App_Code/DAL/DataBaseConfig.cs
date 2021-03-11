using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseConfig
/// </summary>
namespace eCommerce
{
    public class DataBaseConfig
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["eCommerceCS"].ConnectionString.ToString();
    }
}