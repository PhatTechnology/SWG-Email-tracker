using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Email_tracker.Core.Settings
{
    internal class IOSettings
    {
        public static string ip = "";
        public static string port = "";
        public static string username = "";
        public static string password = "";

        public static string ConString = "datasource="+ip+";port="+port+";username="+username+";password="+password;

        public static string mailLocation = "";

    }
}
