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
        public AppInfo Info = new AppInfo();

        public AppPath(string name)
        {
            this.Name = name;
        }
    }
}
