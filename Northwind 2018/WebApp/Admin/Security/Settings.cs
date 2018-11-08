using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security
{
    public static class Settings
    {
        public static string AdminRole = ConfigurationManager.AppSettings["adminRole"];
        public static string EmployeeRole = ConfigurationManager.AppSettings["employeeRole"];
        public static string CustomerRole = ConfigurationManager.AppSettings["customerRole"];
    }
}