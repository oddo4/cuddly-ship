using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using System.Collections.ObjectModel;

namespace launcher
{
    class FileHelper
    {
        public string fileName = "LauncherFile.csv";

        public FileHelper()
        {

        }

        public FileHelper(string FileName)
        {
            this.fileName = FileName;
        }

        public bool ReadFileData(List<DirPath> pathsList)
        {
            var engine = new FileHelperEngine<DirPath>();

            try
            {
                var result = engine.ReadFile(fileName);

                if (result.Any())
                {
                    foreach (DirPath data in result)
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
        public bool WriteFileData(List<DirPath> result)
        {
            var engine = new FileHelperEngine<DirPath>();

            try
            {
                engine.WriteFile(fileName, result);
                return true;
            }
            catch
            {

            }

            return false;
        }

        public bool ReadAppInfo(List<AppInfo> appInfoList)
        {
            var engine = new FileHelperEngine<AppInfo>();

            try
            {
                var result = engine.ReadFile(fileName);

                if (result.Any())
                {
                    foreach (AppInfo data in result)
                    {
                        appInfoList.Add(data);
                    }

                    return true;
                }
            }
            catch
            {

            }

            return false;
        }

        public bool WriteAppInfo(List<AppInfo> result)
        {
            var engine = new FileHelperEngine<AppInfo>();

            try
            {
                engine.WriteFile(fileName, result);
                return true;
            }
            catch
            {

            }  

            return false;
        }
    }
}
