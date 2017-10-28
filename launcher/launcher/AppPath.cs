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
        public List<string> ExePaths = new List<string>();

        public AppPath(string name)
        {
            this.Name = name;
        }

        public void AddPath(string Path)
        {
            this.ExePaths.Add(Path);
        }
    }
}
