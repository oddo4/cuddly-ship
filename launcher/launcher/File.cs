using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using System.Collections.ObjectModel;

namespace launcher
{
    class File
    {
        private string fileName = "LauncherFile.csv";

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public File()
        {

        }

        public File(string FileName)
        {
            this.fileName = FileName;
        }

        public bool ReadFileData(List<CorePath> pathsList)
        {
            var engine = new FileHelperEngine<CorePath>();

            try
            {
                var result = engine.ReadFile(fileName);

                if (result.Any())
                {
                    foreach (CorePath data in result)
                    {
                        pathsList.Add(data);
                    }

                    return true;
                }
                
            }
            catch
            {
                
            }

            return false;
        }

        public bool WriteFileData()
        {
            var engine = new FileHelperEngine<CorePath>();

            try
            {

            }
            catch
            {

            }  

            return false;
        }
    }
}
