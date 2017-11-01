using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace launcher
{
    [DelimitedRecord(",")]

    class DirPath
    {
        public string AppPathString;

        [FieldHidden]
        public List<AppPath> AppList = new List<AppPath>();
        [FieldHidden]
        public List<string> ExePaths = new List<string>();


        public void AddAppList(AppPath appPath)
        {
            AppList.Add(appPath);
        }

        public void AddPath(string Path)
        {
            ExePaths.Add(Path);
        }
    }
}
