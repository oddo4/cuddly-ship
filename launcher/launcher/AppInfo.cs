using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace launcher
{
    [DelimitedRecord(",")]

    class AppInfo
    {
        public string AppName = "N/A";
        public string AppVer = "N/A";
        public string AppAuthor = "N/A";

        public AppInfo()
        {

        }

        public AppInfo(string appName, string appVer, string appAuthor)
        {
            this.AppName = appName;
            this.AppVer = appVer;
            this.AppAuthor = appAuthor;
        }
    }
}
