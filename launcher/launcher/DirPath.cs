using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace launcher
{
    [DelimitedRecord(",")]

    public class DirPath
    {
        public string DirPathString;
        [FieldHidden]
        public List<AppPath> AppList = new List<AppPath>();

        public DirPath()
        {

        }

        public DirPath(string dirPathString)
        {
            this.DirPathString = dirPathString;
        }

        public void AddAppList(AppPath appPath)
        {
            AppList.Add(appPath);
        }

    }
}
