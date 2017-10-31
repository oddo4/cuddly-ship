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
        public string InfoPath;

        public AppInfo()
        {

        }

        public AppInfo(string appName, string appVer, string appAuthor)
        {
            this.AppName = appName;
            this.AppVer = appVer;
            this.AppAuthor = appAuthor;
        }


        public void DisplayAppInfo(TextBox tBoxAppName, TextBox tBoxAppVer, TextBox tBoxAppAuthor)
        {
            tBoxAppName.Text = AppName;
            tBoxAppVer.Text = AppVer;
            tBoxAppAuthor.Text = AppAuthor;
        }
    }
}
