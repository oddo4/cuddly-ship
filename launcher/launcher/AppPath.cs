using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace launcher
{

    class AppPath
    {
        public string Name;
        public string AppDirPath;
        public List<AppInfo> ExeInfo = new List<AppInfo>();
        public List<string> ExePaths = new List<string>();
        public List<string> SlnPaths = new List<string>();

        public void AddExeInfo(AppInfo Info)
        {
            ExeInfo.Add(Info);
        }

        public void AddExePath(string Path)
        {
            ExePaths.Add(Path);
        }

        public void AddSlnPath(string Path)
        {
            SlnPaths.Add(Path);
        }

        public AppPath(string name, string appDirPath)
        {
            this.Name = name;
            this.AppDirPath = appDirPath;
        }
    }
}
