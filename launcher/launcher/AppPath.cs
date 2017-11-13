using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace launcher
{

    public class AppPath
    {
        public string Name;
        public string AppDirPath;
        public List<string> ExePaths = new List<string>();
        public List<string> SlnPaths = new List<string>();

        public void AddExePath(string Path)
        {
            ExePaths.Add(Path);
        }

        public void AddSlnPath(string Path)
        {
            SlnPaths.Add(Path);
        }

        public AppPath()
        {

        }

        public AppPath(string name, string appDirPath)
        {
            this.Name = name;
            this.AppDirPath = appDirPath;
        }
    }
}
